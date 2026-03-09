using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Statistics;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static System.Int32;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_OrderInformation : UserControl
    {
        public Main_Form? mainForm;
        public static List<string>? List_ProdGroup;


        public Main_OrderInformation()
        {
            InitializeComponent();
            lbl_Version.Text = $"Version: {ChangeLog.CurrentVersion}";
        }

        public void Translate_Form()
        {
            var controls = new Control[] { label_OrderNr, label_PartNumber, label_Amount, label_OrderStartedBy, label_Start, label_Stop, label_Operation, label_Description, label_Customer, label_ProdGroup, label_ProdLine, label_TotalOrders };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        public void Change_Theme()
        {
            BackColor = Color.Transparent;
            tlp_Main.BackColor = Teman.backColor_OrderInformation;
            Teman.IterateThroughControls(tlp_Main, Teman.foreColor_OrderInformation);
        }
        public void Clear()
        {
            Control[] ctrl =
            {
                tb_OrderNr, cb_Operation, lbl_ArtikelNr, lbl_RevNr, lbl_Antal, lbl_OrderStartedBy, lbl_Start, lbl_ProdGroup,
                lbl_ProdLine, lbl_Stopp, lbl_Customer, lbl_Benämning, lbl_Enhet, lbl_TotalOrders
            };

            foreach (var control in ctrl)
                control.Text = string.Empty;

            cb_Operation.DataSource = null;
            tb_OrderNr.BackColor = Color.Khaki;
            tb_OrderNr.Enabled = true;
        }

        public void Load_Data()
        {
            if (Order.OrderID is null)
                return;

            Database.ExecuteSafe(con =>
            {
                const string query = """
                

                                                                                  SELECT TOP (1)
                                                                                     orders.Operation,
                                                                                     orders.PartNr,
                                                                                     orders.Amount,
                                                                                     orders.Unit,
                                                                                     orders.Name_Start,
                                                                                     orders.Date_Start,
                                                                                     orders.Date_Stop,
                                                                                     orders.ProdGroup,
                                                                                     orders.ProdLine,
                                                                                     orders.Customer,
                                                                                     orders.Description,
                                                                                     orders.Version,
                                                                                     orders.RevNr,
                                                                                     orders.PartID,
                                                                                     maintemplate.Revision AS ProtocolTemplateRevision,
                                                                                     CA.MainTemplateID AS LineClearanceMainTemplateId,
                                                                                     orders.MeasureProtocolMainTemplateID,
                                                                                     orders.WorkoperationID,
                                                                                     CA.CenturiLink,                              -- från cross apply
                                                                                     orders.ProtocolMainTemplateID,
                                                                                     maintemplate.Name AS ProtocolTemplateName,
                                                                                     measure.Name AS MeasureprotocolTemplateName,
                                                                                     IsUsingPreFab,
                                                                                     IsMultipleColumnsStartup
                                                                                 FROM [Order].MainData AS orders
                                                                                 LEFT JOIN Protocol.MainTemplate AS maintemplate
                                                                                     ON orders.ProtocolMainTemplateID = maintemplate.ID
                                                                                 LEFT JOIN Protocol.FormTemplate AS formtemplate
                                                                                     ON orders.ProtocolMainTemplateID = formtemplate.MainTemplateID
                                                                                 OUTER APPLY 
                                                                                 (
                                                                                     SELECT TOP (1)
                                                                                         lc.MainTemplateID,
                                                                                         lc.CenturiLink,
                                                                                         lc.LineClearance_Revision
                                                                                     FROM LineClearance.MainTemplate AS lc
                                                                                     WHERE lc.WorkoperationID = orders.WorkoperationId
                                                                                     ORDER BY lc.LineClearance_Revision DESC
                                                                                 ) AS CA

                                                                                 LEFT JOIN MeasureProtocol.MainTemplate AS measure
                                                                                     ON orders.MeasureProtocolMainTemplateID = measure.MeasureProtocolMainTemplateID
                                                                                 WHERE orders.OrderID = @orderid
                                                                                 ORDER BY IsMultipleColumnsStartup DESC;
                
                """;

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = Order.OrderID;
                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                    return;

                cb_Operation.Text = reader["Operation"]?.ToString();
                Order.PartNumber = lbl_ArtikelNr.Text = reader["PartNr"]?.ToString();
                lbl_Antal.Text = reader["Amount"]?.ToString();
                Order.Enhet = lbl_Enhet.Text = reader["Unit"]?.ToString();
                Order.ProdGroup = lbl_ProdGroup.Text = reader["ProdGroup"]?.ToString();
                lbl_ProdLine.Text = reader["ProdLine"]?.ToString();
                Order.Customer = lbl_Customer.Text = reader["Customer"]?.ToString();
                Order.Description = lbl_Benämning.Text = reader["Description"]?.ToString();
                lbl_Version.Text = reader["Version"]?.ToString();
                lbl_OrderStartedBy.Text = reader["Name_Start"]?.ToString();

                if (DateTime.TryParse(reader["Date_Start"]?.ToString(), out var start))
                {
                    var fmt = CultureInfo.CurrentCulture.DateTimeFormat;
                    Order.StartTime = lbl_Start.Text = start.ToString($"{fmt.ShortDatePattern} {fmt.ShortTimePattern}", CultureInfo.CurrentCulture);
                }

                if (DateTime.TryParse(reader["Date_Stop"]?.ToString(), out var end))
                {
                    var fmt = CultureInfo.CurrentCulture.DateTimeFormat;
                    Order.StopTime = lbl_Stopp.Text = end.ToString($"{fmt.ShortDatePattern} {fmt.ShortTimePattern}", CultureInfo.CurrentCulture);
                }

                Order.RevNr = lbl_RevNr.Text = reader["RevNr"]?.ToString();

                TryParse(reader["PartID"].ToString(), out var partid);
                Order.PartID = partid;

                if (TryParse(reader["ProtocolMainTemplateID"]?.ToString(), out var protocolTemplateId))
                    Templates_Protocol.MainTemplate.ID = protocolTemplateId;

                if (TryParse(reader["LineClearanceMainTemplateId"]?.ToString(), out var lcTemplateId))
                    Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID = lcTemplateId;

                Templates_MeasureProtocol.MainTemplate.ID = reader["MeasureProtocolMainTemplateID"] is DBNull ? null : Convert.ToInt32(reader["MeasureProtocolMainTemplateID"]);
                Templates_MeasureProtocol.MainTemplate.Name = reader["MeasureprotocolTemplateName"]?.ToString();
                Templates_LineClearance.MainTemplate.LineClearance_CenturiLink = reader["CenturiLink"]?.ToString();
                bool.TryParse(reader["IsMultipleColumnsStartup"]?.ToString(), out var isUsingOven);
                Templates_Protocol.MainTemplate.IsUsingOven = isUsingOven;
                Templates_Protocol.MainTemplate.Name = reader["ProtocolTemplateName"]?.ToString();
                Templates_Protocol.MainTemplate.Revision = reader["ProtocolTemplateRevision"]?.ToString();
                bool.TryParse(reader["IsUsingPreFab"]?.ToString(), out var isUsingPrefab);
                PreFab.IsUsingPreFab = isUsingPrefab;
            });

            if (string.IsNullOrEmpty(lbl_Version.Text))
                lbl_Version.Text = "N/A";

            lbl_TotalOrders.Text = $"{Part.TotalOrdersRun} orders";
            lbl_RevNr.Text = Order.RevNr;
            Order.Amount = Parse(lbl_Antal.Text);

            if (Monitor.Monitor.Operations is null)
                cb_Operation.Text = $"{Order.Operation}";
            else
                cb_Operation.Text = $"{Order.Operation} - {Monitor.Monitor.Operations.Description}";
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_Customer.Text))
                return;
            if (string.IsNullOrEmpty(Monitor.Monitor.Customer.Url) == false)
                Process.Start(Monitor.Monitor.Customer.Url);
        }
        public void LoadMainForm_NewOrder()
        {
            //Startar ny Order
            lbl_ArtikelNr.Text = Order.PartNumber = Monitor.Monitor.Part.PartNumber;
            Part.Load_PartID(Order.PartNumber, true, false, false, Order.WorkOperation.ToString());
            lbl_Antal.Text = $"{Monitor.Monitor.Operations.PlannedQuantity:0}";
            Order.Amount = Parse(lbl_Antal.Text);
            lbl_ProdGroup.Text = Monitor.Monitor.WorkCenter.Number;
            lbl_ProdLine.Text = Order.ProdLine;
            if (Monitor.Monitor.Customer != null)
                lbl_Customer.Text = Order.Customer = Monitor.Monitor.Customer.Name;
            lbl_Customer.ForeColor = Color.DodgerBlue;
            lbl_Customer.Click += Customer_Click;
            lbl_Customer.Cursor = Cursors.Hand;
            lbl_Benämning.Text = Order.Description = Monitor.Monitor.Part.Description;
            lbl_Enhet.Text = Order.Enhet = Monitor.Monitor.Unit.Code;
            lbl_Start.Text = Order.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            lbl_OrderStartedBy.Text = Person.Name;
        }
        public void Fill_cb_Operation()
        {
            List_ProdGroup = new List<string>();
            if (string.IsNullOrEmpty(tb_OrderNr.Text))
            {
                panel_tb_OrderNr.BackColor = tb_OrderNr.BackColor = Color.Khaki;
                return;
            }
            cb_Operation.Enabled = true;
            panel_tb_OrderNr.BackColor = tb_OrderNr.BackColor = Color.White;
            Order.OrderNumber = tb_OrderNr.Text;
            Monitor.Monitor.Load_Order(tb_OrderNr.Text);

            cb_Operation.SelectedIndexChanged -= mainForm.Operation_SelectedIndexChanged!;
            cb_Operation.DataSource = Monitor.Monitor.List_Operations(Order.OrderNumber, List_ProdGroup);
            cb_Operation.DisplayMember = "Display";
            cb_Operation.ValueMember = "Operation";
            cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged!;

            //Monitor.Monitor.Fill_cb_Operation(cb_Operation, Order.OrderNumber);
            if (cb_Operation.Items.Count == 0)
            {
                InfoText.Show(Properties.Resources.monitorInfo_1, CustomColors.InfoText_Color.Bad, "Warning", this.Parent);
                cb_Operation.BackColor = CustomColors.Bad_Back;
            }
            else
            {
                cb_Operation.BackColor = Color.White;
                cb_Operation.Focus();
            }
        }

        public void Set_Operation(int? operation)
        {
            cb_Operation.SelectedValue = operation;
            return;
        }
        private void ProdLine_Click(object sender, EventArgs e)
        {
            using var black = new BlackBackground(string.Empty, 80);
            using var prod = new Statistics_ProdLine(lbl_ProdLine.Text);
            black.Show();
            prod.ShowDialog();
            black.Close();
        }
        public void OrderNr_Validated(object? sender, EventArgs e)
        {
            var ordernr = tb_OrderNr.Text;
            Clear();
            tb_OrderNr.Text = ordernr;
            string test = cb_Operation.Text;
            if (string.IsNullOrEmpty(tb_OrderNr.Text) || tb_OrderNr.Text.Length < 2)
            {
                panel_tb_OrderNr.BackColor = tb_OrderNr.BackColor = Color.Khaki;
                cb_Operation.Enabled = false;
                return;
            }
            StartOrder();
        }
        private void cb_Operation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                mainForm?.Operation_SelectedIndexChanged(sender, e);
            }
        }
        public void StartOrder()
        {
            cb_Operation.Enabled = true;
            cb_Operation.Text = string.Empty;

            bool hasOrderNr = !string.IsNullOrWhiteSpace(tb_OrderNr.Text);
            panel_tb_OrderNr.BackColor = tb_OrderNr.BackColor = hasOrderNr
                ? Color.White
                : Color.Khaki;

            // Gör det möjligt att öppna en order på bara OrderID
            if (!hasOrderNr)
                return;

            if (!char.IsDigit(tb_OrderNr.Text[0]))
            {
                Fill_cb_Operation();
                return;
            }

            int? operation = null;

            Database.ExecuteSafe(con =>
            {
                const string query = "SELECT OrderNr, Operation FROM [Order].MainData WHERE OrderId = @id";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = tb_OrderNr.Text;
                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                    return;

                tb_OrderNr.Text = reader["OrderNr"]?.ToString() ?? string.Empty;
                operation = Parse(reader["Operation"]?.ToString() ?? string.Empty);
            });

            Fill_cb_Operation();
            cb_Operation.SelectedValue = string.Empty;

            if (operation is null)
                return;

            foreach (Operation_Description item in cb_Operation.Items)
            {
                if (item.Operation == operation)
                {
                    cb_Operation.SelectedValue = operation;
                    return;
                }
            }
        }




        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            if (lbl != null)
                Clipboard.SetText(lbl.Text);
        }

        public class Operation_Description
        {
            public int Operation { get; set; }
            public string Description { get; set; }

            public string Display => $"{Operation} - {Description}";
        }

        private void label_PartNumber_Click(object sender, EventArgs e)
        {
            if (EasterEgg_Code.IsGameStarted)
                InfoText.Show(EasterEgg_Code.Level_1.Riddle_1, CustomColors.InfoText_Color.Info, "The Cipher Wheel", this);
        }

        
    }

}
