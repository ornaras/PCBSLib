using HidSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PCBS
{
    public partial class PCBSDevice : IDisposable
    {
        [Flags]
        public enum ConnTypes : byte { COM = 1, HID = 2 }

        public ConnTypes ConnType
        {
            get
            {
                switch (_dev)
                {
                    case HidDevice _: return ConnTypes.HID;
                    case SerialDevice _: return ConnTypes.COM;
                    default: return 0;
                }
            }
        }

        private bool disposed = true;
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

        public string Send(string command, int respSize = 64)
        {
            if (disposed) throw new ObjectDisposedException(nameof(PCBSDevice));
            command = $"M\x0D{command}.";
            var data = new byte[ConnType == ConnTypes.COM ? 1 + command.Length : 64];
            var encoding = Encoding.UTF8;
            if (ConnType == ConnTypes.COM)
            {
                data[0] = 255;
                encoding.GetBytes(command).CopyTo(data, 1);
            }
            else if (ConnType == ConnTypes.HID)
            {
                data[0] = 0xFD;
                data[1] = (byte)(1 + command.Length);
                data[2] = 0xFF;
                encoding.GetBytes(command).CopyTo(data, 3);
            }
            _stream.Write(data, 0, data.Length);
            data = new byte[respSize];
            switch (ConnType)
            {
                case ConnTypes.COM:
                    try
                    {
                        for (var i = 0; i < respSize; i++)
                        {

                            var @byte = _stream.ReadByte();
                            data[i] = (byte)@byte;
                        }
                    }
                    catch (TimeoutException) { break; }
                    break;
                case ConnTypes.HID:
                    _ = _stream.Read(data, 0, data.Length);
                    break;
            }
            var resp = encoding.GetString(data);
            resp = resp.Replace("\0", "");
            if (ConnType == ConnTypes.HID) 
                resp = resp.Substring(2);
            var match = Regex.Match(resp, @"^\d{6}:? ?(?<resp>.+)\u0006\.?$");
            return match.Groups["resp"].Value;
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
            }
            disposed = true;
        }

        public static IEnumerable<PCBSDevice> Discover(ConnTypes filter = (ConnTypes)3)
        {
            if (filter.HasFlag(ConnTypes.COM))
            {
                foreach (var com in DeviceList.Local.GetSerialDevices())
                {
                    var dev = TryConnect(com);
                    if (!(dev is null)) 
                        yield return dev;
                }
            }
            if (filter.HasFlag(ConnTypes.HID))
            {
                foreach(var hid in DeviceList.Local.GetHidDevices())
                {
                    var dev = TryConnect(hid);
                    if (!(dev is null))
                        yield return dev;
                }
            }
        }

        private static PCBSDevice TryConnect(Device dev)
        {
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
        }
    }
}