using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Statistics;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
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
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                 SELECT TOP(1) 
                    Operation, 
                    PartNr, 
                    Amount, 
                    Unit, 
                    Name_Start, 
                    Date_Start, 
                    Date_Stop, 
                    ProdGroup, 
                    ProdLine, 
                    Customer, 
                    Description, 
                    Version, 
                    RevNr, 
                    PartID, 
                    ProtocolTemplateRevision, 
                    orders.LineClearanceMainTemplateID, 
                    orders.MeasureProtocolMainTemplateID,
                    CASE 
                        WHEN orders.LineClearanceMainTemplateID IS NULL THEN NULL 
                        ELSE lc.CenturiLink 
                    END AS CenturiLink, 
                    orders.ProtocolMainTemplateID, 
                    Name, 
                    IsUsingPreFab, 
                    IsMultipleColumnsStartup
                FROM [Order].MainData AS orders
                    LEFT JOIN Protocol.MainTemplate AS maintemplate
                        ON orders.ProtocolMainTemplateID = maintemplate.ID
                    LEFT JOIN Protocol.FormTemplate AS formtemplate
                        ON orders.ProtocolMainTemplateID = formtemplate.MainTemplateID
                    LEFT JOIN LineClearance.MainTemplate AS lc
                        ON lc.ProtocolMainTemplateID = maintemplate.ID
                WHERE OrderID = @orderid
                ORDER BY IsMultipleColumnsStartup DESC";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cb_Operation.Text = reader["Operation"].ToString();
                    Order.PartNumber = lbl_ArtikelNr.Text = reader["PartNr"].ToString();
                    lbl_Antal.Text = reader["Amount"].ToString();
                    Order.Enhet = lbl_Enhet.Text = reader["Unit"].ToString();
                    Order.ProdGroup = lbl_ProdGroup.Text = reader["ProdGroup"].ToString();
                    lbl_ProdLine.Text = reader["ProdLine"].ToString();
                    Order.Customer = lbl_Customer.Text = reader["Customer"].ToString();
                    Order.Description = lbl_Benämning.Text = reader["Description"].ToString();
                    lbl_Version.Text = reader["Version"].ToString();
                    lbl_OrderStartedBy.Text = reader["Name_Start"].ToString();

                    DateTime.TryParse(reader["Date_Start"].ToString(), out var start);
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    var formattedDate = start.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    Order.StartTime = lbl_Start.Text = formattedDate;

                    if (DateTime.TryParse(reader["Date_Stop"].ToString(), out var end))
                    {
                        dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                        formattedDate = end.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                        Order.StopTime = lbl_Stopp.Text = formattedDate;
                    }

                    Order.RevNr = lbl_RevNr.Text = reader["RevNr"].ToString();
                    TryParse(reader["PartID"].ToString(), out var artID);
                    Order.PartID = artID;
                    if (TryParse(reader["ProtocolMainTemplateID"].ToString(), out var mainTemplateID))
                        Templates_Protocol.MainTemplate.ID = mainTemplateID;
                    if (TryParse(reader["LineClearanceMainTemplateID"].ToString(), out var lc_MainTemplateID))
                        Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID = lc_MainTemplateID;
                    if (TryParse(reader["MeasureProtocolMainTemplateID"].ToString(), out var mpMainTemplateID))
                        Templates_MeasureProtocol.MainTemplate.ID = mpMainTemplateID;

                    Templates_LineClearance.MainTemplate.LineClearance_CenturiLink = reader["CenturiLink"].ToString();
                    bool.TryParse(reader["IsMultipleColumnsStartup"].ToString(), out var isUsingOven);
                    Templates_Protocol.MainTemplate.IsUsingOven = isUsingOven;
                    Templates_Protocol.MainTemplate.Name = reader["Name"].ToString();
                    Templates_Protocol.MainTemplate.Revision = reader["ProtocolTemplateRevision"].ToString();
                    bool.TryParse(reader["IsUsingPreFab"].ToString(), out var isUsingPrefab);
                    PreFab.IsUsingPreFab = isUsingPrefab;

                }
                if (string.IsNullOrEmpty(lbl_Version.Text))
                    lbl_Version.Text = "N/A";
            }
            lbl_TotalOrders.Text = $"{Part.TotalOrdersRun} orders";
            lbl_RevNr.Text = Order.RevNr;
            Order.Amount = Parse(lbl_Antal.Text);

            if (Monitor.Monitor.Operations is null)
                cb_Operation.Text = $"{Order.Operation}";
            else
                cb_Operation.Text = $"{Order.Operation} - {Monitor.Monitor.Operations.Description}";
        }
        public void Customer_Click(object sender, EventArgs e)
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
            Part.Load_PartID(Order.PartNumber, true, false,Order.WorkOperation.ToString());
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
            cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged!;

            //Monitor.Monitor.Fill_cb_Operation(cb_Operation, Order.OrderNumber);
            if (cb_Operation.Items.Count == 0)
            {
                InfoText.Show(LanguageManager.GetString("monitorInfo_1"), CustomColors.InfoText_Color.Bad, "Warning", this.Parent);
                cb_Operation.BackColor = CustomColors.Bad_Back;
            }
            else
            {
                cb_Operation.BackColor = Color.White;
                cb_Operation.Focus();
            }
        }

        public void Set_Operation(string? operation)
        {
            var search = operation + " -";

            for (var i = 0; i < cb_Operation.Items.Count; i++)
            {
                if (cb_Operation.Items[i].ToString().StartsWith(search))
                {
                    cb_Operation.SelectedIndex = i;
                    break;
                }
            }
        }
        private void ProdLine_Click(object sender, EventArgs e)
        {
            var black = new BlackBackground(string.Empty, 80);
            var prod = new Statistics_ProdLine(lbl_ProdLine.Text);
            black.Show();
            prod.ShowDialog();
            black.Close();
        }
        public void OrderNr_Validated(object? sender, EventArgs e)
        {
            var ordernr = tb_OrderNr.Text;
            Clear();
            tb_OrderNr.Text = ordernr;
            StartOrder();
        }

        public void StartOrder()
        {
            cb_Operation.Enabled = true;
            cb_Operation.Text = string.Empty;

            if (string.IsNullOrEmpty(tb_OrderNr.Text))
                panel_tb_OrderNr.BackColor = tb_OrderNr.BackColor = Color.Khaki;
            else
                panel_tb_OrderNr.BackColor = tb_OrderNr.BackColor = Color.White;

            //Gör det möjligt att öppna en order på bara OrderID
            if (string.IsNullOrEmpty(tb_OrderNr.Text))
                return;
            string operation = null;
            if (char.IsDigit(tb_OrderNr.Text[0]))
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT OrderNr, Operation FROM [Order].MainData WHERE OrderID = @id";

                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", tb_OrderNr.Text);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tb_OrderNr.Text = reader["OrderNr"].ToString();
                        operation = reader["Operation"].ToString();
                    }
                }
                Fill_cb_Operation();
               // cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged!;
                for (var i = 0; i < cb_Operation.Items.Count; i++)
                {
                    if (cb_Operation.Items[i].ToString().Substring(0, 5).Contains(operation))
                    {
                        cb_Operation.SelectedIndex = i;
                        mainForm.Operation_SelectedIndexChanged(cb_Operation, EventArgs.Empty);
                        return;
                    }
                }
            }
            else
                Fill_cb_Operation();
        }


       
        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            if (lbl != null)
                Clipboard.SetText(lbl.Text);
        }
    }

}
