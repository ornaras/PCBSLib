using System;
using System.Linq;
using System.Windows.Forms;

namespace PCBS.UserControls
{
    public class CommandGroup: UserControl
    {
        private readonly string[] onDevice;
        private readonly int[] cmds;

        protected CommandGroup(params int[] cmds)
        {
            this.cmds = cmds;
            onDevice = new string[cmds.Length];
            RegisterControls();
        }

        private void RegisterControls()
        {
            var btnPush = new Button();
            var btnPull = new Button();

            btnPush.Location = new System.Drawing.Point(84, 3);
            btnPush.Size = new System.Drawing.Size(75, 23);
            btnPush.Text = "Записать";
            btnPush.Click += new EventHandler(Push);

            btnPull.Location = new System.Drawing.Point(3, 3);
            btnPull.Size = new System.Drawing.Size(75, 23);
            btnPull.Text = "Считать";
            btnPull.Click += new EventHandler(Pull);

            Controls.Add(btnPull);
            Controls.Add(btnPush);
        }

        private Control FindControl(int command) =>
            Controls.OfType<Control>().FirstOrDefault(c => c.Tag is string tag && tag == $"{command}");

        private string GetCurrentValue(int command)
        {
            switch (FindControl(command))
            {
                case CheckBox check:
                    if (check.CheckState == CheckState.Indeterminate) return null;
                    return check.CheckState == CheckState.Indeterminate ? null : ("0");
                case ComboBox cb: return cb.SelectedIndex == -1 ? null : $"{cb.SelectedIndex}";
                case NumericUpDown nb: return nb.Value < 0 ? null : $"{nb.Value}";
                default: throw new NotImplementedException();
            }
        }

        private void SetCurrentValue(int command, string value)
        {
            switch (FindControl(command))
            {
                case CheckBox check:
                    if(value == "0" || value == "1")
                    {
                        check.Checked = value == "1";
                        break;
                    }
                    check.CheckState = CheckState.Indeterminate;
                    MessageBox.Show($"Не удалось получить текущее значение команды {command}", "", 0, MessageBoxIcon.Warning);
                    break;
                case ComboBox cb:
                    {
                        if (int.TryParse(value, out var d))
                        {
                            cb.SelectedIndex = d;
                            break;
                        }
                    }
                    cb.SelectedIndex = -1;
                    MessageBox.Show($"Не удалось получить текущее значение команды {command}", "", 0, MessageBoxIcon.Warning);
                    break;
                case NumericUpDown nb:
                    {
                        if (int.TryParse(value, out var d))
                        {
                            nb.Value = d;
                            break;
                        }
                    }
                    nb.Value = -1;
                    MessageBox.Show($"Не удалось получить текущее значение команды {command}", "", 0, MessageBoxIcon.Warning);
                    break;
                default: throw new NotImplementedException();
            }
        }

        protected void Pull(object sender, EventArgs e)
        {
            for (var i = 0; i < cmds.Length; i++)
            {
                onDevice[i] = MainForm.CurrentConnection?.Get(cmds[i]) ?? "";
                SetCurrentValue(cmds[i], onDevice[i]);
            }
            MessageBox.Show("Считывание завершено");
        }

        protected void Push(object sender, EventArgs e)
        {
            var countChanged = 0;
            for (var i = 0; i < cmds.Length; i++)
            {
                var currValue = GetCurrentValue(cmds[i]);
                if (currValue == onDevice[i]) continue;
                MainForm.CurrentConnection?.Set(cmds[i], currValue);
                onDevice[i] = currValue;
                countChanged++;
            }
            MessageBox.Show($"Успешно обновлено {countChanged} настроек");
        }
    }
}
