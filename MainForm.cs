using System.Windows.Forms;

namespace PCBS
{
    public partial class MainForm : Form
    {
        internal static PCBSDevice CurrentConnection { get; set; } = null;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
