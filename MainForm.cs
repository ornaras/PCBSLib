using PCBS.UserControls;
using System.Drawing;
using System.Windows.Forms;

namespace PCBS
{
    public partial class MainForm : Form
    {
        internal static PCBSDevice CurrentConnection { get; set; } = null;

        public MainForm()
        {
            var tabControl = new TabControl();
            tabControl.Controls.Add(CreatePage("Звук и индикация", new Visual()));
            tabControl.Controls.Add(CreatePage("Code39", new Code39()));

            tabControl.SuspendLayout();
            foreach (Control page in tabControl.Controls)
                page.SuspendLayout();
            SuspendLayout();

            tabControl.Location = new Point(268, 12);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(608, 425);

            ClientSize = new Size(888, 449);
            MinimumSize = MaximumSize = new Size(904, 488);
            MaximizeBox = false;
            Controls.Add(new General());
            Controls.Add(tabControl);
            ShowIcon = false;
            Text = "Тест бибилиотеки PCBSLib";

            tabControl.ResumeLayout(false);
            foreach (Control page in tabControl.Controls)
                page.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static TabPage CreatePage(string text, Control control)
        {
            var page = new TabPage
            {
                Location = new Point(4, 22),
                Size = new Size(600, 399),
                Text = text
            };
            page.Controls.Add(control);
            return page;
        }
    }
}
