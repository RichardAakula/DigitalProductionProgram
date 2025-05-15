using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    public partial class Skärmning_TEF : Form
    {
        public Skärmning_TEF()
        {
            InitializeComponent();
            
            MainProtocol.Activate_Events();

            Load_Data();

            if (Order.IsOrderDone || Korprotokoll.IsProtocol_Open_By_AnotherUser(this))
            {
                
                MainProtocol.Lock_All_control();
            }
            else
                Module.IsOkToSave = true;
        }

        private void Load_Data()
        {
            // Extruderingsprotokoll.IsOkSave = false;

            ProcesskortBaserat_På.Load_Data();
            MainProtocol.Load_Data();
            
            // Extruderingsprotokoll.IsOkSave = true;
        }
        
      

        private void Close_Card()
        {
            SaveData.Reset_Processcard_Open(false);
            FormClosing -= Skärmning_FormClosing;
            Close();

            // MainForm.processkortÖppet = false;
        }
        private void Skärmning_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Card();

        }

        
    }
}
