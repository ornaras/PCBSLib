using System.Drawing;
using System.Windows.Forms;

namespace PCBS
{
    internal static class UIGenerator
    {
        public static Label CreateLabel(string text, int y, int w) => new Label()
        {
            Location = new Point(3, y),
            Size = new Size(w, 13),
            Text = text
        };

        public static CheckBox CreateCheckBox(string text, string tag, int y, int w) => new CheckBox()
        {
            Location = new Point(3, y),
            Size = new Size(w, 17),
            Tag = tag,
            Text = text,
        };

        public static NumericUpDown CreateNumberBox(string tag, int x, int y, int w)
        {
            var control = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(control)).BeginInit();
            control.Location = new Point(x, y);
            control.Maximum = 99999;
            control.Size = new Size(w, 20);
            control.Tag = tag;
            ((System.ComponentModel.ISupportInitialize)(control)).EndInit();
            return control;
        }

        public static ComboBox CreateComboBox(string tag, int x, int y, int w, params object[] items)
        {
            var control = new ComboBox()
            {
                Location = new Point(x, y),
                Size = new Size(w, 21),
                Tag = tag
            };
            control.Items.AddRange(items);
            return control;
        }
    }
}
