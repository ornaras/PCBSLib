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
    public delegate object GetLocker(string path);
    public partial class PCBSDevice : IDisposable
    {
        private bool disposed;
        private Stream _stream;
        private Device _dev;

        public static event Action<string> Logging;
        public string Address => _dev.DevicePath.Substring(4);

        public PCBSDevice(string hidDevicePath) :
            this(DeviceList.Local.GetHidDevices().FirstOrDefault(dev => dev.DevicePath.EndsWith(hidDevicePath))) { }

        public PCBSDevice(int comPort) :
            this(DeviceList.Local.GetSerialDeviceOrNull($"COM{comPort}")) { }

        private PCBSDevice(Device device)
        {
            disposed = false;
            _dev = device;
            _stream = _dev.Open();
            _stream.WriteTimeout = _stream.ReadTimeout = 1000;
        }

        private string SerialSend(string command, int respSize)
        {
            var data = new byte[4 + command.Length];
            var encoding = Encoding.ASCII;
            data[0] = 0xFF;
            data[1] = 0x4D;
            data[2] = 0x0D;
            data[data.Length - 1] = 0x2E;
            encoding.GetBytes(command).CopyTo(data, 3);
            _stream.Write(data, 0, data.Length);
            data = new byte[respSize];
            try
            {
                for (var i = 0; i < respSize; i++)
                {
                    var @byte = _stream.ReadByte();
                    data[i] = (byte)@byte;
                }
            }
            catch (TimeoutException) { }
            var resp = encoding.GetString(data).Replace("\0", "");
            var match = Regex.Match(resp, @"^\d{6}:? ?(?<resp>.+)\u0006\.?$");
            return match.Groups["resp"].Value;
        }

        private string HidSend(string command, int respSize)
        {
            var data = new byte[64];
            var encoding = Encoding.UTF8;
            data[0] = 0xFD;
            data[1] = (byte)(1 + command.Length);
            data[2] = 0xFF;
            data[3] = 0x4D;
            data[4] = 0x0D;
            data[command.Length + 5] = 0x2E;
            encoding.GetBytes(command).CopyTo(data, 5);
            _stream.Write(data, 0, data.Length);
            data = new byte[respSize];
            _ = _stream.Read(data, 0, data.Length);
            var resp = encoding.GetString(data).Replace("\0", "").Substring(2);
            var match = Regex.Match(resp, @"^\d{6}:? ?(?<resp>.+)\u0006\.?$");
            return match.Groups["resp"].Value;
        }

        public string Send(string command, int respSize = 64)
        {
            if (disposed) throw new ObjectDisposedException(nameof(PCBSDevice));
            switch (_dev)
            {
                case SerialDevice _: return SerialSend(command, respSize);
                case HidDevice _: return HidSend(command, respSize);
                default: throw new NotSupportedException();
            }
        }

        public string Set(int address, string value) => Send($"{address}{value}");
        public string Get(int address) => Send($"{address}?");

        public override string ToString() => disposed ? "" : Address;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~PCBSDevice()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
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
                Logging?.Invoke(e.ToString());
                return null;
            }
            finally
            {
                if (!(locker is null))
                    Monitor.Exit(locker);
            }
        }
    }
}