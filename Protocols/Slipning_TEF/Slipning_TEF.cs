using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    public partial class Slipning_TEF : Form
    {
        public static DataTable dt_Protocol_Slipning_MaskinParametrar
        {
            get
            {
                var dt = new DataTable();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $@"SELECT Kasserad, Slipmaskin, Matarhjul_Hastighet, Matarhjul_Vinkel, Helix_Vinkel, Bladhöjd, Arbetsblad, Nr, Chimshöjd, Datum, Tid, AnstNr, Sign 
                                        FROM Korprotokoll_Slipning_Maskinparametrar {Queries.WHERE_OrderID} ORDER BY Datum, Tid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }


        public Slipning_TEF()
        {
            InitializeComponent();
            Part.SetPartNrSpecial("Extra Parametrar Slipning_TEF");

            if (Part.IsPartNrSpecial == false)
                Width = 907;
           
            MainProtocol.Produktion.Fill_Inledande_LotNr();

            Load_Data();
            MainProtocol.Produktion.Change_GUI();
            if (Order.IsOrderDone)
                Lock_Card();
            else
                Module.IsOkToSave = true;

            if (Korprotokoll.IsProtocol_Open_By_AnotherUser(this))
                Lock_Card();

        }


        private void Lock_Card()
        {
            Module.IsOkToSave = false;
            Kommentarer.tb_Comments.Enabled = false;
            MainProtocol.Produktion.lbl_Transfer_Produktion.Enabled = false;
            MainProtocol.Produktion.lbl_Kassera_Produktion.Enabled = false;
            MainProtocol.Produktion.lbl_Edit_Row_Produktion.Enabled = false;

            MainProtocol.Maskinparametrar.Enabled = false;
        }
        private void Load_Data()
        {
            Module.IsOkToSave = false;

            MainProtocol.MainInfo.Load_Data(Order.OrderID);
            MainProtocol.Load_Data();
            Kommentarer.Load_Data();

            Baserat_På.Load_Data();

            Module.IsOkToSave = true;
        }

        private void Close_Card()
        {
            SaveData.Reset_Processcard_Open(false);
            FormClosing -= Processkort_Slipning_FormClosing;
            Close();
            
        }
        private void Processkort_Slipning_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!MainProtocol.Produktion.IsProduktion_Slipning_Data_Saved && Module.IsOkToSave)
            {
                InfoText.Show("Du har inte överfört datan från Produktion/Slipning. Tryck på den gröna pilen eller radera datan i rutorna.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                e.Cancel = true;
                return;
            }

            Close_Card();

        }
    }
}
