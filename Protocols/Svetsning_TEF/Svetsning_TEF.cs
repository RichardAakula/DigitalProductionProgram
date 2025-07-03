using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.Svetsning_TEF
{
    public partial class Svetsning_TEF : Form
    {
        public static DataTable dt_Protocol_Svetsning_Produktion
        {
            get
            {
                var dt = new DataTable();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $@"SELECT Kasserad, Inledande_OrderNr, Inledande_Påse, Inledande_UppmättPinne, Inledande_ID, Inledande_OD, Inledande_Längd, Inspektion_Utsida, Inspektion_Insida, Datum, Tid, AnstNr, Sign, TempID
                                        FROM Korprotokoll_Svetsning_Parametrar {Queries.WHERE_OrderID} ORDER BY Datum, Tid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
        public static DataTable dt_Protocol_Svetsning_MaskinParametrar
        {
            get
            {
                var dt = new DataTable();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $@"SELECT Kasserad, Svets, Tid_Förvärme, Svetsförflyttning, Tid_Bindvärme, Tid_Kylluft, Temperatur, Pinne_OD_Stål, Pinne_OD_PTFE,Värmebackar_Bredd, Värmebackar_Hål, Datum, Tid, AnstNr, Sign 
                                        FROM Korprotokoll_Svetsning_Maskinparametrar {Queries.WHERE_OrderID} ORDER BY Datum, Tid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }


        public Svetsning_TEF()
        {
            InitializeComponent();

            Load_Data();
            
            if (Order.IsOrderDone || Korprotokoll.IsProtocol_Open_By_AnotherUser(this))
                Lock_Card();
            else
                Module.IsOkToSave = true;
        }
       

        private void Lock_Card()
        {
            Module.IsOkToSave = false;
            Kommentarer.tb_Comments.Enabled = false;
            MainProtocol.Enabled = false;
        }
        private void Load_Data()
        {
            Module.IsOkToSave = false;

            MainProtocol.Load_Data();
            Kommentarer.Load_Data();
            Processkort_BaseratPå.Load_Data();

            Module.IsOkToSave = true;
        }
       

        private void Close_Card()
        {
            SaveData.Reset_Processcard_Open(false);
            FormClosing -= Processkort_Svetsning_FormClosing;
            Close();

        }
        private void Processkort_Svetsning_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Card();
        }

        
    }
}
