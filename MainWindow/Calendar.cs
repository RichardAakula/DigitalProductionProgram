using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    public partial class LoggedInUsers : Form
    {
        public LoggedInUsers()
        {
            InitializeComponent();
            Main_Calendar.Fill_OnlineMonitorUsers();
            timer_UpdateUsers.Start();
        }

        private async void Timer_UpdateUsers_Tick(object sender, EventArgs e)
        {
            await Main_Calendar.Clear_ListAsync();
            Main_Calendar.Fill_OnlineMonitorUsers();
        }

        private void LoggedInUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer_UpdateUsers.Dispose();
        }
    }
}
