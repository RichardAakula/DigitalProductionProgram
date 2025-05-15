using System;
using System.Windows.Forms;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Blandning_PTFE
{
    public partial class Blandning_PTFE : Form
    {
        public Blandning_PTFE()
        {
            InitializeComponent();
           
            Load_Data();

            if (Korprotokoll.IsProtocol_Open_By_AnotherUser(this) || string.IsNullOrEmpty(Person.EmployeeNr) || Order.IsOrderDone)
            {
                MainProtocol.Journal.btn_SaveRow.Enabled = false;
                MainProtocol.Journal.btn_EditRow.Enabled = false;
            }
            Change_FormWidth();
            MainProtocol.Journal.btn_EditRow.Click += Btn_EditRow_Click;

        }

        private void Btn_EditRow_Click(object sender, EventArgs e)
        {
            if (Journal_Blandning_PTFE.row_User == Person.Sign)
                Top = 75;
        }

        private void Protocol_Blandning_PTFE_Load(object sender, EventArgs e)
        {
            DarkTitleBar.UseImmersiveDarkMode(Handle, true);
        }

        public void Change_FormWidth()
        {
            if (Part.IsPartNrSpecial("Blandning Pigment") == false)
                Width = 871;
            else
                Width = 1092;
        }

        private void Load_Data()
        {
            MainProtocol.Load_Data();
        }

        private void Blandning_PTFE_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProtocol.Journal.warning?.Close();
        }
    }
}
