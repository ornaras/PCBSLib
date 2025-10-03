using HidSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PCBS.UserControls
{
    public partial class General : UserControl
    {
        public General()
        {
            InitializeComponent();
            RefreshConnTypes(null, null);
        }

        private void Connect(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;
            if (btn.Text == "Подключиться")
            {
                switch (cbConnType.Text)
                {
                    case "USB-COM":
                        {
                            var port = cbConnPort.Text.ToUpperInvariant().Replace("COM", "");
                            if (!int.TryParse(port, out var numbPort) || !PCBSDevice.TryConnect(numbPort, out var conn))
                            {
                                MessageBox.Show("Не удалось подключиться к устройству...", "", 0, MessageBoxIcon.Stop);
                                return;
                            }
                            btn.Text = "Отключиться";
                            MainForm.CurrentConnection = conn;
                        }
                        break;
                    case "USB-HID":
                        {
                            if (!PCBSDevice.TryConnect(cbConnPort.Text, out var conn))
                            {
                                MessageBox.Show("Не удалось подключиться к устройству...", "", 0, MessageBoxIcon.Stop);
                                return;
                            }
                            btn.Text = "Отключиться";
                            MainForm.CurrentConnection = conn;
                        }
                        break;
                    default:
                        MessageBox.Show("Неизвестный тип подключения", "", 0, MessageBoxIcon.Stop);
                        break;
                }
            }
            else
            {
                MainForm.CurrentConnection?.Dispose();
                btn.Text = "Подключиться";
            }
            tbSerial.Text = MainForm.CurrentConnection?.Get(811005) ?? "";
            tbFirmware.Text = MainForm.CurrentConnection?.Get(809004) ?? "";
        }

        private void OnChangedConnType(object sender, EventArgs e) => RefreshConnTypes(sender, e);

        private void RefreshConnTypes(object sender, EventArgs e)
        {
            cbConnPort.Items.Clear();
            DeviceFilter filter;
            switch (cbConnType.Text)
            {
                case "USB-HID":
                    filter = dev => dev is HidDevice;
                    break;
                case "USB-COM":
                    filter = dev => dev is SerialDevice &&
                        dev.DevicePath.ToUpperInvariant().Contains("COM");
                    break;
                default: return;
            }
            foreach (var dev in DeviceList.Local.GetAllDevices(filter))
                cbConnPort.Items.Add(dev.DevicePath.Substring(4));
        }

        private void PushRawValue(object sender, EventArgs e) =>
            tbValueRaw.Text = MainForm.CurrentConnection?.Set(int.Parse(tbCodeRaw.Text), tbValueRaw.Text);

        private void PullRawValue(object sender, EventArgs e) =>
            tbValueRaw.Text = MainForm.CurrentConnection?.Get(int.Parse(tbCodeRaw.Text));

        private void SendCombinedCommand(object sender, EventArgs e)
        {
            tbCombinedResponse.Clear();
            var requests = tbCombinedRequest.Text.Split(';');
            var responses = MainForm.CurrentConnection?.MultiSend(requests);
            for(var i = 0; i < responses.Length; i++)
            {
                var resp = responses[i];
                if (string.IsNullOrEmpty(resp))
                {
                    tbCombinedResponse.SelectionColor = Color.Red;
                    tbCombinedResponse.AppendText($"ERR {requests[i]}\n");
                }
                else
                {
                    tbCombinedResponse.SelectionColor = Color.Black;
                    tbCombinedResponse.AppendText($"OK {requests[i].Substring(0, 6)}: {resp}\n");
                }
            }
        }
    }
}
