using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    public partial class BlackBackground : Form
    {
        private const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Modifiers: 1=Alt, 2=Ctrl, 4=Shift, 8=Win
        private const uint MOD_CTRL = 0x0002;
        private const uint MOD_SHIFT = 0x0004;
        private const int HOTKEY_ID = 101; // valfritt id


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

        //Nendan kod hanterar global hotkey för att stänga fönstret vid problem med hjälp av Ctrl+Shift+T
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Ctrl+Shift+T
            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_CTRL | MOD_SHIFT, (uint)Keys.T);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
            base.OnFormClosed(e);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                this.Close();
                this.TopMost = false;
                this.WindowState = FormWindowState.Normal;
                this.Text = "Splash (TopMost: false)";
            }
            base.WndProc(ref m);
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