using System.Windows.Forms;

namespace DigitalProductionProgram.Help
{
    public partial class Warning : Form
    {
        public Warning(string text, int height)
        {
            InitializeComponent();
            Left = 0;
            Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = height;
            lbl_Warning.Text = text;
            
        }
    }
}
