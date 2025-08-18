using HidSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;

namespace PCBS
{
    public partial class PCBSDevice : IDisposable
    {
        public PCBSConnTypes ConnType { get; private set; }

        private bool disposed = true;
        private Stream _stream;
        private SerialPort _port;
        private HidDevice _hid;

        public static event Action<string> Logging;

        public PCBSDevice(string port)
        {
            ConnType = PCBSConnTypes.COM;
            disposed = false;
            _port = new SerialPort(port);
            _port.Open();
            _stream = _port.BaseStream;
            _stream.WriteTimeout = _stream.ReadTimeout = 5000;
        }

        public PCBSDevice(int vid, int pid, int release, string serial) : 
            this(DeviceList.Local.GetHidDeviceOrNull(vid, pid, release, serial)) { }

        private PCBSDevice(HidDevice device)
        {
            ConnType = PCBSConnTypes.HID;
            disposed = false;
            _hid = device;
            _stream = _hid.Open();
            _stream.WriteTimeout = _stream.ReadTimeout = 5000;
        }

        public string Send(string command, int respSize = 64)
        {
            if (disposed) throw new ObjectDisposedException(nameof(PCBSDevice));
            command = $"M\x0D{command}.";
            var data = new byte[ConnType == PCBSConnTypes.COM ? 1 + command.Length : 64];
            var encoding = Encoding.UTF8;
            if (ConnType == PCBSConnTypes.COM)
            {
                data[0] = 255;
                encoding.GetBytes(command).CopyTo(data, 1);
            }
            else if (ConnType == PCBSConnTypes.HID)
            {
                data[0] = 0xFD;
                data[1] = 0x0B;
                data[2] = 0xFF;
                encoding.GetBytes(command).CopyTo(data, 3);
            }
            _stream.Write(data, 0, data.Length);
            data = new byte[respSize];
            var count = _stream.Read(data, 0, data.Length);
            var resp = encoding.GetString(data);
            resp = resp.Replace("\0", "");
            return ConnType == PCBSConnTypes.HID ? resp.Substring(2) : resp;
        }

        public override string ToString()
        {
            if (disposed) return "";
            return ConnType == PCBSConnTypes.COM ? _port.PortName : _hid.DevicePath;
        }

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
                    _port?.Close();
                    _port?.Dispose();
                }
            }
            disposed = true;
        }

        public static IEnumerable<PCBSDevice> Discover(PCBSConnTypes filter = (PCBSConnTypes)3)
        {
            if (filter.HasFlag(PCBSConnTypes.COM))
            {
                foreach (var com in SerialPort.GetPortNames())
                {
                    var dev = TryConnectCOM(com);
                    if (!(dev is null)) 
                        yield return dev;
                }
            }
            if (filter.HasFlag(PCBSConnTypes.HID))
            {
                foreach(var hid in DeviceList.Local.GetHidDevices())
                {
                    var dev = TryConnectHID(hid);
                    if (!(dev is null))
                        yield return dev;
                }
            }
        }

        private static PCBSDevice TryConnectCOM(string port)
        {
            PCBSDevice dev = null;
            try
            {
                dev = new PCBSDevice(port);
                var resp = dev.Send("8000011");
                return resp == "8000011\x06." ? dev : null;
            }
            catch (Exception e)
            {
                dev?.Dispose();
                Logging?.Invoke(e.ToString());
                return null;
            }
        }

        private static PCBSDevice TryConnectHID(HidDevice dev)
        {
            PCBSDevice _dev = null;
            try
            {
                _dev = new PCBSDevice(dev);
                var resp = _dev.Send("8000011");
                return resp == "8000011\x06." ? _dev : null;
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