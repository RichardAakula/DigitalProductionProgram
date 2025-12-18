using DigitalProductionProgram.DatabaseManagement;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;

namespace DigitalProductionProgram.Övrigt
{
    public partial class BlackBackground : Form
    {
        private readonly string Info;
        [DebuggerStepThrough]
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
               


                //tlp_Main.Controls.Add(load, 0, 1);

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