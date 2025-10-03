using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PCBS.UserControls
{
    public class CommandGroup: UserControl
    {
        private readonly string[] onDevice;
        private readonly int[] cmds;
        private readonly int? cmdReset;

        protected CommandGroup(int? commandReset, params int[] cmds)
        {
            this.cmds = cmds;
            cmdReset = commandReset;
            onDevice = new string[cmds.Length];
            RegisterControls();
        }

        public CommandGroup() => RegisterControls();

        private void RegisterControls()
        {
            MaximumSize = MinimumSize = new Size(600, 399);

            var btnPull = new Button
            {
                Location = new Point(3, 3),
                Size = new Size(75, 23),
                Text = "Считать"
            };
            btnPull.Click += new EventHandler(Pull);
            Controls.Add(btnPull);

            var btnPush = new Button
            {
                Location = new Point(84, 3),
                Size = new Size(75, 23),
                Text = "Записать"
            };
            btnPush.Click += new EventHandler(Push);
            Controls.Add(btnPush);

            if (cmdReset is int)
            {
                var btnReset = new Button
                {
                    Location = new Point(165, 3),
                    Size = new Size(125, 23),
                    Text = "Сбросить настройки"
                };
                btnReset.Click += new EventHandler(Reset);
                Controls.Add(btnReset);
            }
        }

        private Control FindControl(int command) =>
            Controls.OfType<Control>().FirstOrDefault(c => c.Tag is string tag && tag.Length >= 6 && tag.Substring(0, 6) == $"{command}");

        private static string[] GetControlValues(string tag)
        {
            var parts = tag.Split(':');
            if (parts.Length == 1 || string.IsNullOrWhiteSpace(parts[1]))
                return Array.Empty<string>();
            else if (parts.Length > 2) throw new FormatException();
            return parts[1].Split(',');
        }

        private static (string, string) GetCheckBoxValues(string tag)
        {
            var values = GetControlValues(tag);
            if (values.Length > 2) throw new FormatException();
            return (values.Length >= 1 ? values[0] : "1", values.Length == 2 ? values[1] : "0");
        }

        private static string[] GetComboBoxValues(string tag, int size)
        {
            var values = GetControlValues(tag);
            if (values.Length == 0) return null;
            if (values.Length != size) throw new FormatException();
            return values;
        }

        private string GetCurrentValue(int command)
        {
            switch (FindControl(command))
            {
                case CheckBox check:
                    var (True, False) = GetCheckBoxValues((string)check.Tag);
                    if (check.CheckState == CheckState.Indeterminate) return null;
                    return check.Checked ? False : True;
                case ComboBox cb:
                    if (cb.SelectedIndex == -1)
                        return null;
                    var values = GetComboBoxValues((string)cb.Tag, cb.Items.Count);
                    return values is null ?  $"{cb.SelectedIndex}":values[cb.SelectedIndex];
                case NumericUpDown nb: return nb.Value < 0 ? null : $"{nb.Value}";
                default: throw new NotImplementedException();
            }
        }

        private void SetCurrentValue(int command, string value)
        {
            switch (FindControl(command))
            {
                case CheckBox check:
                    var (True, False) = GetCheckBoxValues((string)check.Tag);
                    if (value == False || value == True)
                    {
                        check.Checked = value == True;
                        return;
                    }
                    check.CheckState = CheckState.Indeterminate;
                    MessageBox.Show($"Не удалось получить текущее значение команды {command}", "", 0, MessageBoxIcon.Warning);
                    break;
                case ComboBox cb:
                    {
                        var values = GetComboBoxValues((string)cb.Tag, cb.Items.Count);
                        if(values is null)
                        {
                            if(int.TryParse(value, out var d))
                            {
                                cb.SelectedIndex = d;
                                return;
                            }
                        }
                        else
                        {
                            for (var i = 0; i < values.Length; i++)
                            {
                                if (values[i] == value)
                                {
                                    cb.SelectedIndex = i;
                                    return;
                                }
                            }
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
            if (MainForm.CurrentConnection is null)
            {
                MessageBox.Show("Отсутствует подключение со сканером", "Не удалось выгрузить данные со сканера", 0, MessageBoxIcon.Hand);
                return;
            }
            var response = MainForm.CurrentConnection.MultiSend(cmds.Select(c => $"{c}?").ToArray());
            for (var i = 0; i < response.Length; i++)
            {
                onDevice[i] = response[i];
                SetCurrentValue(cmds[i], onDevice[i]);
            }
            MessageBox.Show("Считывание завершено");
        }

        protected void Push(object sender, EventArgs e)
        {
            if (MainForm.CurrentConnection is null)
            {
                MessageBox.Show("Отсутствует подключение со сканером", "Не удалось загрузить данные в сканер", 0, MessageBoxIcon.Hand);
                return;
            }
            var countChanged = 0;
            for (var i = 0; i < cmds.Length; i++)
            {
                var currValue = GetCurrentValue(cmds[i]);
                if (currValue == onDevice[i]) continue;
                MainForm.CurrentConnection.Set(cmds[i], currValue);
                onDevice[i] = currValue;
                countChanged++;
            }
            MessageBox.Show($"Успешно обновлено {countChanged} настроек");
        }

        protected void Reset(object sender, EventArgs e)
        {
            MainForm.CurrentConnection?.Get(cmdReset.Value);
            Pull(sender, e);
        }
    }
}
