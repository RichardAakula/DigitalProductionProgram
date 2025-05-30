using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.User;
using DigitalProductionProgram.EasterEggs;
using System.Reflection;
using DigitalProductionProgram.ControlsManagement;
using static Azure.Core.HttpHeader;

namespace DigitalProductionProgram.MainWindow
{
    public partial class ActiveOrdersUser : UserControl
    {
       
        private Main_OrderInformation? orderInformation;

        private class OrderLabel : Label
        {
            public string? OrderID { get; init; }
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
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT DISTINCT TOP(5) OrderNr, Operation, mp.OrderID,  Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue
                    FROM Measureprotocol.MainData AS mp
                JOIN[Order].MainData as main

                ON mp.OrderID = main.OrderID

                JOIN[Settings].QuickStart_Color as color

                ON main.WorkoperationID = color.WorkoperationID

                WHERE AnstNr = @employeenumber AND main.IsOrderDone = 'False'
                AND mp.Date > @thisyear

                UNION

                    SELECT DISTINCT TOP(5) OrderNr, Operation, slipning.OrderID,  Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue
                    FROM Korprotokoll_Slipning_Produktion as slipning

                JOIN[Order].MainData as main

                ON slipning.OrderID = main.OrderID

                JOIN[Settings].QuickStart_Color as color

                ON main.WorkoperationID = color.WorkoperationID

                JOIN Workoperation.Names as workoperation

                ON main.WorkoperationID = workoperation.ID
                WHERE AnstNr = @employeenumber AND main.IsOrderDone = 'False'

                UNION

                    SELECT DISTINCT TOP(5) OrderNr, Operation, svetsning.OrderID, Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue
                    FROM Korprotokoll_Svetsning_Parametrar as svetsning

                JOIN[Order].MainData as main

                ON svetsning.OrderID = main.OrderID

                JOIN[Settings].QuickStart_Color as color

                ON main.WorkoperationID = color.WorkoperationID

                JOIN Workoperation.Names as workoperation

                ON main.WorkoperationID = workoperation.ID
                WHERE AnstNr = @employeenumber AND main.IsOrderDone = 'False'";
            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
            var thisyear = DateTime.Now.ToString("yyyy");
            cmd.Parameters.AddWithValue("@thisyear", DateTime.Now.ToString("yyyy"));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var lbl = new OrderLabel
                {
                    ForeColor = Color.FromArgb(int.Parse(reader["Fore_Red"].ToString()), int.Parse(reader["Fore_Green"].ToString()), int.Parse(reader["Fore_Blue"].ToString())),
                    BackColor = Color.FromArgb(int.Parse(reader["Back_Red"].ToString()), int.Parse(reader["Back_Green"].ToString()), int.Parse(reader["Back_Blue"].ToString())),
                    Text = $"{reader["OrderNr"]} - {reader["Operation"]}",
                    OrderID = reader["OrderID"].ToString(),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 0, 0, 0),
                    Margin = new Padding(25, 0, 0, 1),
                    AutoSize = false,
                    Width = 120,
                    Cursor = Cursors.Hand,
                    Font = new Font("Arial", 10),

                };
                lbl.Click += OpenOrder_Click;
                flp_Main.Invoke(new Action(() => flp_Main.Controls.Add(lbl)));
                ctr++;
                if (ctr == 5)
                    return;
            }
        }
        public void OpenOrder_Click(object sender, EventArgs e)
        {
            var lbl = (OrderLabel)sender;
            orderInformation.cb_Operation.Enabled = true;
            var ordernr = lbl.Text.Substring(0, lbl.Text.IndexOf('-') - 1);
            var operation = lbl.Text.Substring(lbl.Text.IndexOf('-') + 2, lbl.Text.Length - ordernr.Length - 3);

            orderInformation.tb_OrderNr.Text = lbl.OrderID;
            orderInformation.StartOrder();
            return;
            orderInformation.tb_OrderNr.Text = ordernr;
            orderInformation.cb_Operation.Select();
            var ctr = 0;
            foreach (string op in orderInformation.cb_Operation.Items)
            {
                var opnr = op.Substring(0, op.IndexOf('-') - 1);
                if (opnr == operation)
                    orderInformation.cb_Operation.SelectedIndex = ctr;
                ctr++;
            }


        }

        private void KnockKnock_EasterEggCode(object sender, MouseEventArgs e)
        {
            EasterEgg_Code.Level_2.KnockKnock(this, e.Location);
        }

     
    }


}
