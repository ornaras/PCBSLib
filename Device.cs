#pragma warning disable S101

using HidSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PCBS
{
    public delegate object GetLocker(string path);

    public class Device : IDisposable
    {
        #region Свойства
        public string Address => _dev.DevicePath.Substring(4);
        #endregion

        #region Переменные
        private bool disposed;
        private Stream _stream;
        private HidSharp.Device _dev;

        private readonly Encoding encoding = Encoding.ASCII;
        #endregion

        #region Конструкторы
        private Device(HidSharp.Device device)
        {
            disposed = false;
            _dev = device;
            _stream = _dev.Open();
            _stream.WriteTimeout = _stream.ReadTimeout = 1000;
        }
        #endregion

        #region Внутренние методы обмена данными
        private Result[] SerialSend(string command)
        {
            const int DEFAULT_SIZE_RESPONSE = 64;
            var data = GenerateRequest(command);
            _stream.Write(data, 0, data.Length);
            data = new byte[DEFAULT_SIZE_RESPONSE];
            var readed = 0;
            do
            {
                try { 
                    for (; readed < data.Length; readed++)
                    {
                        var @byte = _stream.ReadByte();
                        data[readed] = (byte)@byte;
                    }
                }
                catch (TimeoutException) { }
                if (data.Length > readed) break;
                Array.Resize(ref data, data.Length + DEFAULT_SIZE_RESPONSE);
            } while (true);
            return ParseResponses(encoding.GetString(data).Replace("\0", ""));
        }

        private Result[] HidSend(string command)
        {
            const int SIZE_ARRAYS = 64;
            const int COUNT_CHARACTERS = 61;

            /* Сканер в режиме USB-HID поддерживает общение пакетами по 64 байта в следующем формате:
             * | ---- | ------------ | ----------------- | --------------- |
             * | Байт | Первый пакет | Последующий пакет | Последний пакет |
             * | ---- | ------------ | ----------------- | --------------- |
             * |   1  |                         253                        |
             * |   2  |          Размер контента (массива команд)          |
             * | 3-63 |                    Массив команд                   |
             * |  64  |       0      |         0         |        1        |
             * | ---- | ------------ | ----------------- | --------------- |
             */

            var bytes = GenerateRequest(command);
            var count = (int)Math.Ceiling(bytes.Length / (double)COUNT_CHARACTERS);
            var data = new byte[SIZE_ARRAYS];
            var dataResponse = new StringBuilder();
            data[0] = 0xFD;
            for (var y = 0; y < count; y++)
            {
                var dataSize = Math.Min(bytes.Length - (y * COUNT_CHARACTERS), COUNT_CHARACTERS);
                data[1] = (byte)dataSize;
                data[SIZE_ARRAYS - 1] = (byte)(y == count - 1 ? 0 : 1);
                for (var i = 0; i <= COUNT_CHARACTERS; i++)
                    data[i + 2] = 0;
                for (var x = 0; x < dataSize; x++)
                    data[x + 2] = bytes[y * COUNT_CHARACTERS + x];
                _stream.Write(data, 0, data.Length);
            }
            do
            {
                var _resp = new byte[SIZE_ARRAYS];
                try { _ = _stream.Read(_resp, 0, SIZE_ARRAYS); }
                catch (TimeoutException) { break; }
                dataResponse.Append(encoding.GetString(_resp.Skip(5).Take(_resp[1]).ToArray()));
            } while (true);
            return ParseResponses(dataResponse.ToString());
        }

        private byte[] GenerateRequest(string req) => 
            new byte[3] { 0xFF, 0x4D, 0x0D }
                .Concat(encoding.GetBytes(req))
                .Append((byte)0x2E).ToArray();

        private static Result[] ParseResponses(string raw)
        {
            if (!raw.EndsWith(".")) throw new FormatException("Ответ не целостен");
            var responses = raw.Substring(0, raw.Length - 1).Split(';');
            return responses.Select(resp => new Result(resp)).ToArray();
        }
        #endregion

        #region Публичные методы обмена данными
        public Result[] Send(IEnumerable<string> commands)
        {
            if (disposed) throw new ObjectDisposedException(nameof(Device));
            switch (_dev)
            {
                case SerialDevice _: return SerialSend(string.Join(";", commands));
                case HidDevice _: return HidSend(string.Join(";", commands));
                default: throw new NotSupportedException();
            }
        }

        public Result Send(string command)
        {
            if (disposed) throw new ObjectDisposedException(nameof(Device));
            switch (_dev)
            {
                case SerialDevice _: return SerialSend(command)[0];
                case HidDevice _: return HidSend(command)[0];
                default: throw new NotSupportedException();
            }
        }

        public Result Set(int code, string value) => Send($"{code}{value}");

        public Result Get(int code) => Send($"{code}?");
        #endregion

        public override string ToString() => disposed ? "" : Address;

        #region Dispose и Деструктор
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Device()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _stream?.Dispose();
                    _stream = null;
                    _dev = null;
                }
                disposed = true;
            }
        }
        #endregion

        #region Статические методы
        public static IEnumerable<Device> Discover(GetLocker getLocker = null)
        {
            var devList = DeviceList.Local;
            var devFilter = new DeviceFilter(d => d is HidDevice || d is SerialDevice);
            var devices = devList.GetAllDevices(devFilter);
            foreach (var dev in devices)
            {
                if (TryConnect(dev, getLocker) is Device pcbs) 
                    yield return pcbs;
            }
        }

        private static Device TryConnect(HidSharp.Device dev, GetLocker getLocker)
        {
            var locker = getLocker?.Invoke(dev.DevicePath);
            if (!(locker is null)) 
                Monitor.Enter(locker);
            Device _dev = null;
            try
            {
                _dev = new Device(dev);
                if (!_dev.Set(800001, "1").IsSuccess)
                    throw new InvalidDataException();
                return _dev;
            }
            catch (Exception)
            {
                _dev?.Dispose();
                return null;
            }
            finally
            {
                if (!(locker is null))
                    Monitor.Exit(locker);
            }
        }

        public static Device CreateAsHid(string devicePath)
        {
            bool pred(HidDevice d) => d.DevicePath == $@"\\?\{devicePath}";
            var hid = DeviceList.Local.GetHidDevices().FirstOrDefault(pred) 
                ?? throw new ArgumentException();
            var dev = new Device(hid);
            if (dev.Set(800001, "1").IsSuccess) return dev;
            throw new InvalidDataException();
        }

        public static Device CreateAsCom(byte numberPort)
        {
            bool pred(SerialDevice d) => d.DevicePath == $@"\\?\COM{numberPort}";
            var com = DeviceList.Local.GetSerialDevices().FirstOrDefault(pred) 
                ?? throw new ArgumentException();
            var dev = new Device(com);
            if (dev.Set(800001, "1").IsSuccess) return dev;
            throw new InvalidDataException();
        }
        #endregion
    }
}