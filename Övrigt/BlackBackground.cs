using DigitalProductionProgram.DatabaseManagement;
using System;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    public partial class BlackBackground : Form
    {
        private readonly string Info;

        public BlackBackground(string info, int opacity, bool IsIconVisible = false)
        {
            InitializeComponent();

            Info = info;
            lblInfo.Text = info;
            Cursor = Cursors.AppStarting;
            Opacity = (double)opacity/100;
            if (IsIconVisible)
            {
                pb_Icon.Visible = true;
            }
                
            Refresh();
        }
      

        private void BlackBackground_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BlackBackground_Load(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = Info;
            
            Refresh();
        }
       
    }
}