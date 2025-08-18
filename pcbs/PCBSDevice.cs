using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;

namespace PCBS
{
    public partial class PCBSDevice : IDisposable
    {
        public string Address { get; private set; }
        public PCBSConnTypes ConnType => 
            Address.StartsWith("COM") ? PCBSConnTypes.COM : PCBSConnTypes.HID;

        private bool disposed = true;
        private Stream _stream;
        private SerialPort _port;

        public static event Action<string> Logging;

        public PCBSDevice(string address)
        {
            disposed = false;
            if (ConnType == PCBSConnTypes.COM)
            {
                _port = new SerialPort(address);
                _port.Open();
                _stream = _port.BaseStream;
            }
            _stream.WriteTimeout = _stream.ReadTimeout = 5000;
            Address = address;
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
            _stream.Write(data, 0, data.Length);
            data = new byte[respSize];
            var count = _stream.Read(data, 0, data.Length);
            if (count != data.Length) Array.Resize(ref data, count);
            return encoding.GetString(data);
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
                    PCBSDevice dev = null;
                    var success = false;
                    try
                    {
                        dev = new PCBSDevice(com);
                        var resp = dev.Send("8000011");
                        success = resp == "8000011\x06.";
                    }
                    catch (Exception e)
                    {
                        dev?.Dispose();
                        Logging?.Invoke(e.ToString());
                        success = false;
                    }
                    if (success) yield return dev;
                }
            }
        }
    }
}