using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.OrderManagement
{
    public partial class CreateTestOrder : Form
    {
       
        private static string? OrderNr
        {
            get
            {
                var format = "00000";
                var order_Suffix = 0;
                var list_OrderNr = new List<string?>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT OrderNr FROM [Order].MainData WHERE OrderNr Like 'Q%' AND OrderNr != 'Q12345'
                                        ORDER BY OrderNr";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                        list_OrderNr.Add(reader[0].ToString());
                }

                string? orderNr;
                do
                {
                    orderNr = "Q" + order_Suffix.ToString(format);
                    if (list_OrderNr.Contains(orderNr))
                        orderNr = string.Empty;
                    else
                        return orderNr;
                    order_Suffix++;
                } while (string.IsNullOrEmpty(orderNr));
                return orderNr;
            }
        }
        private readonly List<int> Operation = new List<int>();
        public static readonly List<string?> Benämning = new List<string?>();
        public static readonly List<string> ProdGrupp = new List<string>();





        public CreateTestOrder()
        {
            InitializeComponent();
            
            Fill_cb_ArbetsOperation();
        }
       
        private void Fill_cb_ArbetsOperation()
        {
            foreach (var item in Enum.GetValues(typeof(Manage_WorkOperation.WorkOperations)))
                cb_ArbetsOperation.Items.Add(item);
            cb_ArbetsOperation.Items.Remove(0);
            cb_ArbetsOperation.SelectedIndex = 1;
        }

       
        private void ArbetsOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.WorkOperation = (Manage_WorkOperation.WorkOperations)Enum.Parse(typeof(Manage_WorkOperation.WorkOperations), cb_ArbetsOperation.Text);
        }
        private void ArtikelNr_Click(object sender, EventArgs e)
        {
            var list = new List<string?>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT DISTINCT PartNr FROM Processcard.MainData WHERE Aktiv = 'True' AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) AND PartNr != '1234567' ORDER BY PartNr";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.String(cmd.Parameters, "@workoperation", cb_ArbetsOperation.Text);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader.GetString(0));
                    
            }
            //Tar bort dom artiklar som bytt namn
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT ArtikelNr_Gammal FROM Artikelkonvertering";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (list.Contains(reader[0].ToString()))
                        list.Remove(reader[0].ToString());
                }
            }

            var choose_Item = new Choose_Item(list, new Control[] {tb_ArtikelNr}, false);
            choose_Item.ShowDialog();
        }
        private void ArtikelNr_Leave(object sender, EventArgs e)
        {
            lbl_OrderNr.Text = OrderNr;
            cb_Operation.Items.Clear();
            cb_RevNr.Items.Clear();

            var artikelNr = tb_ArtikelNr.Text;
            if (tb_ArtikelNr.Text.Contains("TEST"))
                artikelNr = "A1PX112875";
            Monitor.Monitor.Fill_ComboBox_Operation_Description(cb_Operation, artikelNr, Operation);

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT DISTINCT RevNr FROM Processcard.MainData WHERE PartNr = @partnr AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ORDER BY RevNr";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partnr", tb_ArtikelNr.Text);
            SQL_Parameter.String(cmd.Parameters, "@workoperation", cb_ArbetsOperation.Text);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!cb_RevNr.Items.Contains(reader[0].ToString()))
                    cb_RevNr.Items.Add(reader[0].ToString());
            }
        }
      

        private void StartOrder_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(0, 97, 0);
        }
        private void StartOrder_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(198, 239, 206);
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(255, 199, 206);
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(156, 0, 6);
        }

        private void StartOrder_Click(object sender, EventArgs e)
        {
            Order.OrderNumber = OrderNr;
            Order.OrderID = Order.Create_NewOrderID;
            Order.Operation = Operation[cb_Operation.SelectedIndex].ToString();
           
            Order.PartNumber = tb_ArtikelNr.Text;
            Part.Load_PartID(Order.PartNumber, true,  false, false, Order.WorkOperation.ToString());
            Order.Amount = 0;
            Order.Enhet = "m";
            Order.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            Order.Description = "Test Order";
            Order.Customer = "Optinova Ab";
            Order.ProdType = Benämning[cb_Operation.SelectedIndex];

            Order.ProdGroup = ProdGrupp[cb_Operation.SelectedIndex];
            Order.RevNr = cb_RevNr.Text;

            InfoText.Question("Vill du försöka hämta halvfabrikat till denna order från en tidigare order med samma ArtikelNr?\n\n" +
                          "OBS! Det är inte säkert att rätt halvfabrikat hämtas.", CustomColors.InfoText_Color.Info, "Hämta Halvfabrikat?", this);
            if (InfoText.answer == InfoText.Answer.Yes)
                PreFab.SaveData.INSERT_Halvfabrikat(Monitor.Monitor.OrderId(tb_ArtikelNr.Text));

            if (Processcard.IsMultipleProcesscard(Order.WorkOperation))
            {
                var chooseProcesscard_StartTestOrder = new ProcesscardTemplateSelector(false, false, false, false);
                chooseProcesscard_StartTestOrder.ShowDialog();

            }
            else
                Order.ProdLine = Order.ProdType;

            

            Close();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
