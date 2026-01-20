using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace DigitalProductionProgram.MainWindow
{
    public partial class ActiveOrdersUser : UserControl
    {
       
        private Main_OrderInformation? orderInformation;

        private class OrderLabel : Label
        {
            public int? OrderID { get; init; }
        }

        public ActiveOrdersUser()
        {
            InitializeComponent();
        }


        public void Change_Theme()
        {
            BackColor = Color.Transparent;
        }
        public void Translate_Form()
        {
            label_Header_ActiveOrders.Text = LanguageManager.GetString("label_Header_ActiveOrders");
        }


        private void DisposeControl(Control control)
        {
            if (control != null && !control.IsDisposed)
            {
                control.Dispose();
            }
        }
        private void Clear_OrderNr()
        {
            var labels = flp_Main.Controls.OfType<Label>().Where(lbl => lbl != label_Header_ActiveOrders).ToList();
            foreach (var lbl in labels.Where(lbl => lbl != label_Header_ActiveOrders))
                lbl.Invoke(new Action(() => DisposeControl(lbl)));
        }
        public void Load_OrderNr(Main_OrderInformation? OrderInformation)
        {
            Clear_OrderNr();
            var ctr = 0;
            orderInformation = OrderInformation;

            Database.ExecuteSafe(con =>
            {
                const string query = @"
            SELECT DISTINCT TOP(5) OrderNr, Operation, mp.OrderID,
                   Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue
            FROM Measureprotocol.MainData AS mp
            JOIN [Order].MainData AS main ON mp.OrderID = main.OrderID
            JOIN [Settings].QuickStart_Color AS color ON main.WorkoperationID = color.WorkoperationID
            WHERE AnstNr = @employeenumber AND main.IsOrderDone = 0
              AND mp.Date > @thisyear

            UNION

            SELECT DISTINCT TOP(5) OrderNr, Operation, slipning.OrderID,
                   Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue
            FROM Korprotokoll_Slipning_Produktion AS slipning
            JOIN [Order].MainData AS main ON slipning.OrderID = main.OrderID
            JOIN [Settings].QuickStart_Color AS color ON main.WorkoperationID = color.WorkoperationID
            JOIN Workoperation.Names AS workoperation ON main.WorkoperationID = workoperation.ID
            WHERE AnstNr = @employeenumber AND main.IsOrderDone = 0";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@employeenumber", SqlDbType.Int).Value = Person.EmployeeNr;
                cmd.Parameters.Add("@thisyear", SqlDbType.NVarChar, 4).Value = DateTime.Now.Year.ToString();

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int orderID = reader.GetInt32(reader.GetOrdinal("OrderID"));

                    int backR = reader.IsDBNull(reader.GetOrdinal("Back_Red")) ? 255 : reader.GetInt32(reader.GetOrdinal("Back_Red"));
                    int backG = reader.IsDBNull(reader.GetOrdinal("Back_Green")) ? 255 : reader.GetInt32(reader.GetOrdinal("Back_Green"));
                    int backB = reader.IsDBNull(reader.GetOrdinal("Back_Blue")) ? 255 : reader.GetInt32(reader.GetOrdinal("Back_Blue"));

                    int foreR = reader.IsDBNull(reader.GetOrdinal("Fore_Red")) ? 0 : reader.GetInt32(reader.GetOrdinal("Fore_Red"));
                    int foreG = reader.IsDBNull(reader.GetOrdinal("Fore_Green")) ? 0 : reader.GetInt32(reader.GetOrdinal("Fore_Green"));
                    int foreB = reader.IsDBNull(reader.GetOrdinal("Fore_Blue")) ? 0 : reader.GetInt32(reader.GetOrdinal("Fore_Blue"));

                    var lbl = new OrderLabel
                    {
                        ForeColor = Color.FromArgb(foreR, foreG, foreB),
                        BackColor = Color.FromArgb(backR, backG, backB),
                        Text = $"{reader["OrderNr"]} - {reader["Operation"]}",
                        OrderID = orderID,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding = new Padding(5, 0, 0, 0),
                        Margin = new Padding(25, 0, 0, 1),
                        AutoSize = false,
                        Width = 120,
                        Cursor = Cursors.Hand,
                        Font = new Font("Arial", 10)
                    };

                    lbl.Click += OpenOrder_Click;
                    flp_Main.Invoke(() => flp_Main.Controls.Add(lbl));

                    ctr++;
                    if (ctr == 5)
                        break;
                }
            });
        }

        public void OpenOrder_Click(object? sender, EventArgs e)
        {
            var lbl = (OrderLabel)sender;
            Debug.Assert(orderInformation != null, nameof(orderInformation) + " != null");
            orderInformation.cb_Operation.Enabled = true;
           // var ordernr = lbl.Text.Substring(0, lbl.Text.IndexOf('-') - 1);
           // var operation = lbl.Text.Substring(lbl.Text.IndexOf('-') + 2, lbl.Text.Length - ordernr.Length - 3);

            orderInformation.tb_OrderNr.Text = lbl?.OrderID.ToString();
            orderInformation.StartOrder();
            return;
            //orderInformation.tb_OrderNr.Text = ordernr;
            //orderInformation.cb_Operation.Select();
            //var ctr = 0;
            //foreach (string op in orderInformation.cb_Operation.Items)
            //{
            //    var opnr = op.Substring(0, op.IndexOf('-') - 1);
            //    if (opnr == operation)
            //        orderInformation.cb_Operation.SelectedIndex = ctr;
            //    ctr++;
            //}


        }

        private void KnockKnock_EasterEggCode(object sender, MouseEventArgs e)
        {
            EasterEgg_Code.Level_2.KnockKnock(this, e.Location);
        }

     
    }


}
