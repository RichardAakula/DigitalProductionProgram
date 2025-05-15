using System;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.Övrigt;

using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    public partial class Spolning_PTFE : Form
    {
        public Spolning_PTFE()
        {
            InitializeComponent();

            Load_Data();

            Width = (from DataGridViewColumn column in MainProtocol.Journal.dgv_Journal_Input.Columns where column.Visible select column.Width + 1).Sum();

            Module.IsOkToSave = true;
        }

        private void Protocol_Spolning_Load(object sender, EventArgs e)
        {
            DarkTitleBar.UseImmersiveDarkMode(Handle, true);
        }
        private void Load_Data()
        {
            MainProtocol.Load_Data();
            Kommentarer.Load_Data();
        }

        private void Spolning_PTFE_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProtocol.Journal.warning?.Close();
        }
    }
}
