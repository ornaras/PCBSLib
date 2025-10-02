#pragma warning disable S101

using HidSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace PCBS
{
    /// <summary>
    /// Метод получения объекта для синхронизации потоков
    /// </summary>
    /// <param name="path">Адрес устройства</param>
    /// <returns>Объект для синхронизации потоков</returns>
    public delegate object GetLocker(string path);

    /// <summary>
    /// Класс для управления сканерами POScenter SQ-90C, SQ-100C и SG-100C
    /// </summary>
    public class PCBSDevice : IDisposable
    {
        #region Свойства
        /// <summary>
        /// Адрес сканера
        /// </summary>
        public string Address => _dev.DevicePath.Substring(4);
        #endregion

        #region Переменные
        private bool disposed;
        private Stream _stream;
        private Device _dev;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор класс для управления сканером в режиме USB-HID
        /// </summary>
        /// <param name="hidDevicePath">Путь к HID-устройству</param>
        public PCBSDevice(string hidDevicePath) :
            this(DeviceList.Local.GetHidDevices().FirstOrDefault(dev => dev.DevicePath.EndsWith(hidDevicePath))) { }

        /// <summary>
        /// Конструктор класс для управления сканером в режиме USB-COM
        /// </summary>
        /// <param name="comPort">COM-порт к устройству</param>
        public PCBSDevice(int comPort) :
            this(DeviceList.Local.GetSerialDeviceOrNull($"COM{comPort}")) { }

        private PCBSDevice(Device device)
        {
            disposed = false;
            _dev = device;
            _stream = _dev.Open();
            _stream.WriteTimeout = _stream.ReadTimeout = 1000;
        }
        #endregion

        #region Внутренние методы обмена данными
        private string[] SerialSend(string command)
        {
            const int DEFAULT_SIZE_RESPONSE = 64;
            var encoding = Encoding.ASCII;
            data[0] = 0xFF;
            data[1] = 0x4D;
            data[2] = 0x0D;
            data[data.Length - 1] = 0x2E;
            encoding.GetBytes(command).CopyTo(data, 3);
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
            var resp = encoding.GetString(data).Replace("\0", "");
            var matches = Regex.Matches(resp, @"\d{6}:? ?(?<resp>[^\u0006]+)\u0006(;|\.)");
            var result = new string[matches.Count];
            for (var i = 0; i < matches.Count; i++)
                result[i] = matches[i].Groups["resp"].Value;
            return result;
        }

        private string[] HidSend(string command)
        {
            const int SIZE_ARRAYS = 64;
            const int COUNT_CHARACTERS = 61;
            var encoding = Encoding.ASCII;
            var bytes = new byte[3] { 0xFF, 0x4D, 0x0D }
                .Concat(encoding.GetBytes(command))
                .Append((byte)0x2E).ToArray();
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
            var matches = Regex.Matches(dataResponse.ToString(), @"\d{6}:? ?(?<resp>[^\u0006]+)\u0006(;|\.)");
            var result = new string[matches.Count];
            for (var i = 0; i < matches.Count; i++)
                result[i] = matches[i].Groups["resp"].Value;
            return result;
        }
        #endregion

        #region Публичные методы обмена данными

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="command">Команда типа Send, Get и Get/Set. <seealso href="https://github.com/ornaras/PCBSLib/blob/main/README.md#%D0%9A%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D1%8B">Список всех доступных команд.</seealso></param>
        /// <param name="respSize">Размер ответа сканера</param>
        /// <returns>Ответ на выполнение команды</returns>
        /// <remarks>
        /// Для получения и установки значения команды рекомендуется использовать<br/>методы <see cref="Get"/> и <see cref="Set"/> соответственно.
        /// </remarks>
        public string Send(string command)
        {
            if (disposed) throw new ObjectDisposedException(nameof(PCBSDevice));
            switch (_dev)
            {
                case SerialDevice _: return SerialSend(command)[0];
                case HidDevice _: return HidSend(command)[0];
                default: throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Установка значения команды
        /// </summary>
        /// <param name="command">Команда типа Get/Set. <seealso href="https://github.com/ornaras/PCBSLib/blob/main/README.md#%D0%9A%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D1%8B">Список всех доступных команд.</seealso></param>
        /// <returns>Присвоенное значение команды</returns>
        public string Set(int command, string value) => Send($"{command}{value}");

        /// <summary>
        /// Получить текущее значение команды
        /// </summary>
        /// <param name="command">Команда типа Get и Get/Set. <seealso href="https://github.com/ornaras/PCBSLib/blob/main/README.md#%D0%9A%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D1%8B">Список всех доступных команд.</seealso></param>
        /// <returns>Значение команды</returns>
        public string Get(int command) => Send($"{command}?");
        #endregion

        public override string ToString() => disposed ? "" : Address;

        #region Dispose и Деструктор
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~PCBSDevice()
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
        /// <summary>
        /// Поиск подключенных сканеров
        /// </summary>
        /// <param name="getLocker"></param>
        /// <returns>Перечисленние найденных сканеров</returns>
        public static IEnumerable<PCBSDevice> Discover(GetLocker getLocker = null)
        {
            var devList = DeviceList.Local;
            var devFilter = new DeviceFilter(d => d is HidDevice || d is SerialDevice);
            var devices = devList.GetAllDevices(devFilter);
            foreach (var dev in devices)
            {
                if (TryConnect(dev, getLocker) is PCBSDevice pcbs) 
                    yield return pcbs;
            }
        }

        private static PCBSDevice TryConnect(Device dev, GetLocker getLocker)
        {
            var locker = getLocker?.Invoke(dev.DevicePath);
            if (!(locker is null))
                Monitor.Enter(locker);
            PCBSDevice _dev = null;
            try
            {
                _dev = new PCBSDevice(dev);
                var resp = _dev.Set(800001, "1");
                return resp == "1" ? _dev : null;
            }
            catch (Exception e)
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
        #endregion
    }
}