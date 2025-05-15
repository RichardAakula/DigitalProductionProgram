using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;

using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    public partial class Kragning_TEF : Form
    {
        public Kragning_TEF()
        {
            InitializeComponent();
            Module.IsOkToSave = false;

            Load_Data();

            
            if (Order.IsOrderDone || Korprotokoll.IsProtocol_Open_By_AnotherUser(this))
                Lock_Card();
            else
            {
                Module.IsOkToSave = true;
                Initialize_GUI_Order_EJ_Klar();
            }
        }


        private void Initialize_GUI_Order_EJ_Klar()
        {
            MainProtocol.ProdType.Enabled = true;
            MainProtocol.Påse_Spole.Enabled = true;
            Kommentarer.tb_Comments.Enabled = true;
        }
        private void Lock_Card()
        {
            ControlManager.Lock_Controls(new Control[] { Kommentarer.tb_Comments });
            MainProtocol.Lock_Card();
        }
       

        private void Load_Data()
        {
            MainProtocol.Load_Data();
            Kommentarer.Load_Data();
           
            BaseratPå.Load_Data();
        }
       

        private void Close_Card()
        {
            SaveData.Reset_Processcard_Open(false);
            FormClosing -= Körprotokoll_Kragning_FormClosing;
            Close();
        }
        private void Körprotokoll_Kragning_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Card();
        }

       
    }
}
