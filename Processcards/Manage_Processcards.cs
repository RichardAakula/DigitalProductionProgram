using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.MainInfo;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;

namespace DigitalProductionProgram.Processcards
{
    public partial class Manage_Processcards : Form
    {
        private int ActiveMainTemplateID;
        private string ActiveTemplateRevision;


        public static string INSERT_INTO_Processkort_Main =>
            @"
                INSERT INTO Processcard.MainData 
                    (PartID, PartGroupID, PartNr, RevNr, ProdLine, ProdType, MainTemplateID, WorkOperationID, Extra_Info, GodkäntDatum, RevÄndratDatum, QA_sign, UpprättatAv_Sign_AnstNr, RevInfo,
                        Historiska_Data, Validerat, Framtagning_Processfönster, Validerade_Loter, Aktiv)
                VALUES 
                    (@partid, @partgroupid, @partnr, @revNr, @prodline, @prodtype, @maintemplateid, (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL), @extraInfo, NULL,  @revÄndratDatum, NULL, @upprättatAvSign, @revInfo, 
                        @histData, @validerat, @framtagning_Processfönster, @validerade_Loter, 'True')";
        public static string UPDATE_Processkort_Main =>
            @"
                UPDATE Processcard.MainData 
                    SET ProdType = @prodtype, Extra_Info = @extraInfo, RevÄndratDatum = @revÄndratDatum, RevInfo = @revInfo, Historiska_Data = @histData, Validerat = @validerat, Framtagning_Processfönster = @framtagning_Processfönster, Validerade_Loter = @validerade_Loter 
                    WHERE PartID = @partID";

        private List<SqlParameter> Parameters_Main
        {
            get
            {
                var Parameters = new List<SqlParameter>
                {
                    new SqlParameter("@revNr", ProcesscardBasedOn.lbl_RevNr.Text),
                    new SqlParameter("@partnr", tb_NewPartNr.Text),
                    new SqlParameter("@maintemplateid", Templates_Protocol.MainTemplate.ID),
                    new SqlParameter("@workoperation", Order.WorkOperation.ToString()),
                    new SqlParameter("@extraInfo", tb_ExtraInfo.Text),
                    new SqlParameter("@revÄndratDatum", DateTime.Now.ToString("yyyy-MM-dd")),
                    new SqlParameter("@upprättatAvSign", ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr.Text),
                    new SqlParameter("@revInfo", tb_RevInfo.Text),
                    new SqlParameter("@histData", ProcesscardBasedOn.rb_HistoricalData.Checked),
                    new SqlParameter("@validerat", ProcesscardBasedOn.rb_Validated.Checked),
                    new SqlParameter("@framtagning_Processfönster",
                        ProcesscardBasedOn.rb_FramtagningAvProcessfönster.Checked),
                    new SqlParameter("@validerade_Loter", ProcesscardBasedOn.tb_Validerade_Loter.Text),

                };

                return Parameters;
            }
        }


        private bool Is_ProdlineChecked()
        {
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    return !string.IsNullOrEmpty(tb_ProdLine.Text);
                    
                default:
                    return true;
            }
        }
        private bool Is_ProdTypeChecked
        {
            get
            {
                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                    case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                    case Manage_WorkOperation.WorkOperations.HeatShrink:
                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        return !string.IsNullOrEmpty(tb_ProdType.Text);

                    default:
                        return true;
                }
            }
        }

        public static bool IsProcesscardUnderManagement;
        public static bool IsData_Loading;
        public static bool IsUpdateProcesscard;
        private bool IsAllDone
        {
            get
            {
                //Om specifik kontroll av data behövs, tex för FEP. Hämta från Version 3.8.11.2 eller tidigare
                if (Monitor.Monitor.IsPartNumberExistInMonitor(tb_NewPartNr.Text) == false)
                {
                    InfoText.Show($"{LanguageManager.GetString("missingPartNumber_1")} ({tb_NewPartNr.Text}) {LanguageManager.GetString("missingPartNumber_2")}", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }
                Control?[] control = {tb_NewPartNr, ProcesscardBasedOn.lbl_RevNr, ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr, tb_RevInfo, cb_MeasureProtocolTemplateName };
                foreach (var ctrl in control)
                {
                    if (string.IsNullOrEmpty(ctrl.Text))
                    {
                        ControlValidator.SoftBlink(ctrl, Color.White, Color.Red, 400, 200);
                        InfoText.Show($"{LanguageManager.GetString("processcard_MissingInfo")}",CustomColors.InfoText_Color.Bad, "Warning!", this);
                        return false;
                    }
                }
                switch(Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                        break;
                }
                tb_NewPartNr.BackColor = Color.White;
                return true;
            }
        }
        private bool IsActive;
        private bool IsPartIDHaveOrdersRunned
        {
            get
            {
                if (string.IsNullOrEmpty(Order.PartNumber))
                    return false;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT * FROM [Order].MainData WHERE PartID = @artID ";
                    if (Processcard.IsMultiple_Processcard(Order.WorkOperation, Order.PartNumber))
                        query += $"AND ProdLine = '{Order.ProdLine}' AND ProdType = '{Order.ProdType}'";

                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@artID", Order.PartID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        InfoText.Show($"{LanguageManager.GetString("saveProcesscard_Info_2_1")} ({tb_NewPartNr.Text}: {ProcesscardBasedOn.lbl_RevNr.Text})\n" +
                                      $"{LanguageManager.GetString("saveProcesscard_Info_2_2")}", CustomColors.InfoText_Color.Bad, "Warning", this);
                        return true;
                    }
                    return false;
                }
            }
        }
        private bool IsPartRevisionNrExist
        {
            get
            {
                if (string.IsNullOrEmpty(tb_NewPartNr.Text) || string.IsNullOrEmpty(ProcesscardBasedOn.lbl_RevNr.Text))
                    return true;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT * FROM Processcard.MainData WHERE PartNr = @partnr AND RevNr = @revNr AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                    cmd.Parameters.AddWithValue("@revNr", ProcesscardBasedOn.lbl_RevNr.Text);
                    cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        InfoText.Show(LanguageManager.GetString("processCard_Info_2"), CustomColors.InfoText_Color.Bad, "Warning", this);
                        return true;
                    }
                    return false;
                }
            }
        }
       
        private int FormTemplateID { get; set; }

        private void LoadFormTeplateID()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT DISTINCT FormTemplateID, MainTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = (SELECT MainTemplateID FROM Workoperation.Names WHERE ID = @workoperationid)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.TryParse(reader["FormTemplateID"].ToString(), out var formTemplateID))
                        FormTemplateID = formTemplateID;
                    if (int.TryParse(reader["MainTemplateID"].ToString(), out var mainTemplateID))
                        Templates_Protocol.MainTemplate.ID = mainTemplateID;
                }
            }
        }





        //------------------------------------------------------------------------------------------------------------------------------------------------------
        private string IncomingPartNr{ get; }
        public Manage_Processcards(string partnr = null)
        {
            InitializeComponent();
            Translate_Form();
            tb_NewPartNr.TextChanged -= ArtikelNr_TextChanged;
            LoadFormTeplateID();
            Initialize_GUI();
            IsLoadingData = false;
            tb_NewPartNr.Text = string.Empty;
            
            
            Fill_cb_ProtocolTemplateNames();
            Fill_cb_MeasureProtocolTemplateNames();

            if (cb_ProtocolTemplateName.Items.Count > 0)
                cb_ProtocolTemplateName.SelectedIndex = 0;
            cb_TemplateRevision.SelectedIndex = cb_TemplateRevision.Items.Count - 1;

            Change_UI_WorkOperation();
            
            ProcesscardBasedOn.rb_FramtagningAvProcessfönster.Enabled = true;
            ProcesscardBasedOn.rb_HistoricalData.Enabled = true;
            ProcesscardBasedOn.rb_Validated.Enabled = true;
            ProcesscardBasedOn.lbl_RevNr.Text = "A";
            ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr.Enabled = true;
            ProcesscardBasedOn.lbl_QA_Sign.Enabled = true;

            IncomingPartNr = partnr;

            tb_NewPartNr.TextChanged += ArtikelNr_TextChanged;

            if (Person.Role == "SuperAdmin")
            {
                btn_LoadOldData.Visible = true;
                btn_UpdateTemplate.Visible = true;
                btn_NewTemplate.Visible = true;
                btn_Info.Visible = true;
            }

            var IsOkWarnUser = !CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ApproveProcessCard, false);
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageProcesscards, IsOkWarnUser) == false)
            {
                btn_Save_Processcard.Enabled = false;
                btn_DeActivate_PartNr.Enabled = false;
                btn_ClearProcessCard.Enabled = false;
                btn_DeleteProcesscard.Enabled = false;
            }
            else
                Module.IsOkShowList = true;

            if (Person.Role != "SuperAdmin")
                btn_UpdateTemplate.Enabled = false;
            
        }
        private void Manage_Processcards_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IncomingPartNr)) 
               tb_PartNr.Text = IncomingPartNr;
            Set_Height_tlp_Protocol();

            ProcesscardBasedOn.lbl_RevNr.Click += RevNrChanged;
        }

       





        //-------------------- INITIALIZE GUI --------------------
        private void Translate_Form()
        {
            label_PartNumber.Text = LanguageManager.GetString("label_PartNumber");
            label_ProductType.Text = LanguageManager.GetString("label_ProdType");

            LanguageManager.TranslationHelper.TranslateControls(new Control[]
            {
               btn_ReloadPartNr, chb_HideInactive_PartNr,label_List_PartNr, label_Inactive,  label_ProdLine, label_Info_Prodline, label_Info_TotalLayer, btn_Save_Processcard, btn_DeActivate_PartNr, btn_ClearProcessCard, 
               btn_DeleteProcesscard, label_ProcessCard_ExtraInfo, label_ProtocolTemplateName
            });
            ProcesscardBasedOn.Translate_Form();

        }
        private void Initialize_GUI()
        {
            if (Person.Role == "SuperAdmin")
                btn_CopyPartNr.Visible = true;
        }
        private void FillComboBox(ComboBox comboBox, string query, Dictionary<string, object> parameters, EventHandler selectedIndexChangedHandler = null, bool setLastSelected = false)
        {
            // Optionally detach event handler if provided
            if (selectedIndexChangedHandler != null)
                comboBox.SelectedIndexChanged -= selectedIndexChangedHandler;

            comboBox.Items.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            using (var cmd = new SqlCommand(query, con))
            {
                // Add parameters
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assumes the first column is what you need (you can adjust as needed)
                        comboBox.Items.Add(reader[0].ToString());
                    }
                }
            }

            // Optionally set the last item as selected
            if (setLastSelected && comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = comboBox.Items.Count - 1;
            }

            // Reattach event handler if provided
            if (selectedIndexChangedHandler != null)
                comboBox.SelectedIndexChanged += selectedIndexChangedHandler;
        }


        private void Fill_cb_ProtocolTemplateRevision()
        {
            var query = @"SELECT DISTINCT Revision FROM Protocol.MainTemplate WHERE Name = @name";
            var parameters = new Dictionary<string, object>
            {
                { "@name", cb_ProtocolTemplateName.Text }
            };
            // Detach and reattach the event handler, and set the last item as selected.
            FillComboBox(cb_TemplateRevision, query, parameters, ProtocolTemplateRevision_SelectedIndexChanged, setLastSelected: true);
        }
        private void Fill_cb_ProtocolTemplateNames()
        {
            var query = @"SELECT DISTINCT Name FROM Protocol.MainTemplate WHERE WorkoperationID = @workoperationID ORDER BY Name";
            var parameters = new Dictionary<string, object>
            {
                { "@workoperationid", Order.WorkoperationID }
            };
            // Detach and reattach the event handler.
            FillComboBox(cb_ProtocolTemplateName, query, parameters, TemplateName_SelectedIndexChanged);
        }
        private void Fill_cb_MeasureProtocolTemplateNames()
        {
            var query = @"SELECT DISTINCT Name FROM MeasureProtocol.MainTemplate WHERE WorkoperationID = @workoperationID ORDER BY Name";
            var parameters = new Dictionary<string, object>
            {
                { "@workoperationid", Order.WorkoperationID }
            };
            // No event handler detachment needed here.
            FillComboBox(cb_MeasureProtocolTemplateName, query, parameters);
        }


        private void Set_Height_tlp_Protocol()
        {
            
        }

        private void Change_UI_WorkOperation()
        {
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    InfoText.Show("Denna arbetsoperation använder inte Processkort.", CustomColors.InfoText_Color.Bad, "Warning", this);
                    Close();
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    Change_UI_Kragning();
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Change_UI_Skärmning();
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Change_UI_Slipning();
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Change_UI_Svetsning();
                    break;
                case Manage_WorkOperation.WorkOperations.Nothing:
                    break;
                default:
                    tab_Main.SelectedTab = tp_Protocol;
                    break;
            }

            panel_ProductionLine.Visible = Templates_Protocol.MainTemplate.IsProcesscardUsingProdline;
            dgv_Revision.BackgroundColor = flp_Left.BackColor = tlp_Machines.BackColor = tp_Protocol.BackColor = CustomColors.Load_BackColor_WorkOperation(Order.WorkOperation.ToString());
        }

        private void Change_UI_Inactive_ArtikelNr()
        {
            label_Inactive.Visible = true;
            btn_DeActivate_PartNr.Text = LanguageManager.GetString("activatePartNr");
        }
        private void Change_UI_Active_ArtikelNr()
        {
            label_Inactive.Visible = false;
            btn_DeActivate_PartNr.Text = LanguageManager.GetString("deactivatePartNr");
        }

        private void Change_UI_Kragning()
        {
            tab_Main.SelectedTab = tp_Kragning;
            tlp_Main.ColumnStyles[0].Width = 744;
            tlp_Main_Processkort.Width = 462;
            tlp_Main_Processkort.Height = 240;

            panel_ProductionLine.Visible = false;
            flp_ExtraInfo.Visible = false;

            tb_ProdType.Visible = false;
            label_ProductType.Visible = false;

            Processkort_Kragning.dgv_Processkort.ReadOnly = false;
            Processkort_Kragning.Load_Info();
        }
        private void Change_UI_Skärmning()
        {
            tab_Main.SelectedTab = tp_Skärmning;
            tlp_Main.ColumnStyles[0].Width = 324;
            tlp_Main_Processkort.Width = 320;
            tlp_Main_Processkort.Height = 280;

            panel_ProductionLine.Visible = false;
            panel_Tips.Visible = false;

            tb_ProdType.Visible = false;
            label_ProductType.Visible = false;
        }
        private void Change_UI_Slipning()
        {
            tab_Main.SelectedTab = tp_Slipning;
            tlp_Main.ColumnStyles[0].Width = 447;
            tlp_Main_Processkort.Width = 430;
            tlp_Main_Processkort.Height = 210;

            panel_ProductionLine.Visible = false;
            panel_Tips.Visible = false;
            flp_ExtraInfo.Visible = false;

            tb_ProdType.Visible = false;
            label_ProductType.Visible = false;
        }
        private void Change_UI_Svetsning()
        {
            tab_Main.SelectedTab = tp_Svetsning;
            tlp_Main.ColumnStyles[0].Width = 855;
            tlp_Main_Processkort.Width = 590;
            tlp_Main_Processkort.Height = 195;

            panel_ProductionLine.Visible = false;
            panel_Tips.Visible = false;
            flp_ExtraInfo.Visible = false;

            tb_ProdType.Visible = false;
            label_ProductType.Visible = false;
        }


        private void Clear_Data()
        {
            Order.PartID = null;
            Order.PartGroupID = null;
            switch (Order.WorkOperation)
            {
               
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Processcard_Skärmning.Clear_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Processkort_Slipning.Clear_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Processkort_Svetsning.Clear_Data();
                    break;
            }

            ProcesscardBasedOn.Clear_Data();

            tb_ProdType.Text = string.Empty;
            tb_NewPartNr.Text = string.Empty;
            dgv_Revision.DataSource = null;
            tb_RevInfo.Text = string.Empty;
            tb_ExtraInfo.Text = string.Empty;
        }
        


        //------------------------- LOAD -------------------------
        private void Choose_And_Load_PartNr()
        {
            Order.PartNumber = tb_PartNr.Text;

            if (Processcard.IsMultiple_Processcard(Order.WorkOperation, Order.PartNumber))
            {
                var black = new BlackBackground("", 70);
                var chooseProcesscard = new ProcesscardTemplateSelector(false, true, true);
                black.Show();
                chooseProcesscard.ShowDialog();
                black.Close();
            }
            else
            {
                Part.Load_PartID(Order.PartNumber, false, true, Order.WorkOperation.ToString());
                Part.Load_PartGroup_ID(Order.PartNumber, Order.WorkOperation);
            }
            
            Load_Data_Processcard(true);
        }
        private void Load_Data_Processcard(bool is_HämtaInfo_dgv_Rev, bool IsTemplateAlreadySet = false) 
        {
            var org_artikelNr = Order.PartNumber;
            Order.PartNumber = tb_PartNr.Text;
            if (is_HämtaInfo_dgv_Rev)
            {
                Load_Processcard_Info();
            }


            Change_UI_Active_ArtikelNr();
            IsData_Loading = true;

            if (IsTemplateAlreadySet == false)
            {
                Load_ProcessCard_MainData();
                ProcesscardBasedOn.Load_Data();
            }
                

            switch (Order.WorkOperation)
            {
                default:
                    LoadTemplate();
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    Processkort_Kragning.Load_Info();
                    Processkort_Kragning.Load_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Processcard_Skärmning.Load_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Processkort_Slipning.Load_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Processkort_Svetsning.Load_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Nothing:
                    break;
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                case Manage_WorkOperation.WorkOperations.Hackning_PUR_IV:
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                case Manage_WorkOperation.WorkOperations.Plockning_PTFE:
                {
                    InfoText.Show("Denna arbetsoperation saknar Processkort. Kontakta Admin vid bekymmer.", CustomColors.InfoText_Color.Bad, "Warning", this);
                    break;
                }
            }

            Set_Height_tlp_Protocol();
            tb_NewPartNr.SelectAll();
            tb_NewPartNr.BackColor = Color.Khaki;
            cb_TemplateRevision.SelectedIndexChanged -= ProtocolTemplateRevision_SelectedIndexChanged;
            if (IsTemplateAlreadySet == false)
                cb_TemplateRevision.Text = Templates_Protocol.MainTemplate.Revision;
                
           
            cb_TemplateRevision.SelectedIndexChanged += ProtocolTemplateRevision_SelectedIndexChanged;
            //if (is_HämtaInfo_dgv_Rev)
            //{
            //    dgv_Revision.CellEnter -= DataGridView_Revision_CellClick;
            //    Load_Processcard_Info();
            //    dgv_Revision.CellEnter += DataGridView_Revision_CellClick;
            //}

            IsUpdateProcesscard = true;
            Order.PartNumber = org_artikelNr;

            IsData_Loading = false;
        }
        private void Load_ProcessCard_MainData()
        {
            tb_ProdLine.TextChanged -= ProdLinje_TextChanged;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT *, protocoltemplate.Name as ProtocolName, measuretemplate.Name as MeasureTemplateName, measuretemplate.Revision
                    FROM Processcard.MainData as maindata
                    JOIN Protocol.MainTemplate as protocoltemplate
                        ON maindata.ProtocolMainTemplateID = protocoltemplate.ID
                    LEFT JOIN MeasureProtocol.MainTemplate as measuretemplate
                        ON maindata.MeasureProtocolMainTemplateID = measuretemplate.MeasureProtocolMainTemplateID
                    WHERE PartID = @partid";
                
                con.Open();
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order.PartID = (int?)reader["PartID"];
                    tb_NewPartNr.Text = reader["PartNr"].ToString();
                    tb_ProdLine.Text = Order.ProdLine = reader["ProdLine"].ToString();
                    tb_ProdType.Text = Order.ProdType = reader["ProdType"].ToString();
                    int.TryParse(reader["ProtocolMainTemplateID"].ToString(), out var maintemplateID);
                    cb_TemplateRevision.Text = reader["Revision"].ToString();
                    Templates_Protocol.MainTemplate.ID = maintemplateID;
                    num_NumberOfLayers.Value = int.TryParse(reader["NumberOfLayers"].ToString(), out var Layers) ? Layers : 0;
                    cb_ProtocolTemplateName.Text = reader["ProtocolName"].ToString();
                    cb_MeasureProtocolTemplateName.Text = reader["MeasureTemplateName"].ToString();
                    tb_RevInfo.Text = reader["RevInfo"].ToString();
                    tb_ExtraInfo.Text = reader["Extra_Info"].ToString();
                    bool.TryParse(reader["Aktiv"].ToString(), out IsActive);
                }
            }
            if (IsActive)
                Change_UI_Active_ArtikelNr();
            else
                Change_UI_Inactive_ArtikelNr();

            tb_ProdLine.TextChanged += ProdLinje_TextChanged;
        }
        private void Load_Processcard_Info()
        {
            if (Order.PartGroupID is null)
                return;

            // 🔥 Reset DataGridView before adding new data
            dgv_Revision.EndEdit();
            dgv_Revision.ClearSelection();
            dgv_Revision.Rows.Clear();
            dgv_Revision.CellEnter -= Revision_CellEnter;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = "SELECT RevNr, RevInfo, RevÄndratDatum, UpprättatAv_Sign_AnstNr, PartID FROM Processcard.MainData WHERE PartGroupID = @partgroupid ORDER BY RevNr DESC";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partgroupid", Order.PartGroupID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int partID = reader.GetInt32(4);
                        int totalOrders = Part.TotalOrders_WithProcesscard(partID); // Get total orders
                        DateTime.TryParse(reader["RevÄndratDatum"].ToString(), out DateTime date);


                        // 🔥 Add row directly to DataGridView
                        dgv_Revision.Rows.Add(reader["RevNr"],
                            reader["RevInfo"],
                            date.ToShortDateString(),
                            reader["UpprättatAv_Sign_AnstNr"],
                            partID,
                            totalOrders); // Computed Total Orders column
                    }
                }
            }
            if (Person.Role == "QA")
                dgv_Revision.Columns["col_TotalOrders"].Visible = false;

            dgv_Revision.CellEnter += Revision_CellEnter;
        }


        private void ClearTemplate()
        {
            tlp_Machines.Controls.Clear();
            if (tlp_Machines.ColumnCount > 1)
                tlp_Machines.ColumnCount--;
        }
        private void LoadTemplate()
        {
            if (Templates_Protocol.MainTemplate.ID == ActiveMainTemplateID && Templates_Protocol.MainTemplate.Revision == ActiveTemplateRevision)
            {
                foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
                {
                    foreach (TableLayoutPanel tlp in machine.Controls)
                    foreach (var module in tlp.Controls.OfType<Module>())
                    {
                        module.Clear_ProcessData();
                        module.load_processcard.Load_ProcessData(module.FormTemplateID);
                    }
                }
                return;
            }

            ClearTemplate();

            var width = 0;
            ActiveMainTemplateID = Templates_Protocol.MainTemplate.ID;
            ActiveTemplateRevision = Templates_Protocol.MainTemplate.Revision;

            AddMachine(0, 1, ref width);
            if (Machine.Is_MultipleMachines)
            {
                tlp_Machines.ColumnCount++;
               
                for (var i = 0; i < tlp_Machines.ColumnCount; i++)
                    tlp_Machines.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 100f / tlp_Machines.ColumnCount);

                AddMachine(1, 2, ref width);
            }
            tlp_Main.ColumnStyles[0].Width = width + 26;
            if (dataTables_ProcessData.Count > 0)
            {
                InfoText.Show("Laddar data från tidigare mall till den nya mallen", CustomColors.InfoText_Color.Info, string.Empty,this);
                Load_ProcessDataFromOldTemplateRevision();
            }
        }


        
        private void AddMachine(int columnIndex, byte machineIndex, ref int width)
        {
          //  var isUsingPrefab = false;
            var isAutheticationNeeded = false;
            var machine = new Machine(machineIndex, ref isAutheticationNeeded, ref width, true)
            {
                Dock = DockStyle.Fill,
                Name = machineIndex.ToString(),
                Margin = new Padding(3,0,0,0)
                
            };
            //Tar bort Uppstart eftersom det inte skall användas vid processkortshantering
            machine.Remove_StartUp();
            
            tlp_Machines.Controls.Add(machine);
            tlp_Machines.SetCellPosition(machine, new TableLayoutPanelCellPosition(columnIndex, 0));
           
        }

        private readonly List<DataTable> dataTables_ProcessData = new List<DataTable>();
        private void CopyProcessDataToNewTemplateRevision()
        {
            foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
            {
                foreach (TableLayoutPanel tlp in machine.Controls)
                foreach (var module in tlp.Controls.OfType<Module>())
                {
                    var dt = new DataTable();
                    dt.Columns.Add("CodeText");
                    dt.Columns.Add("Min");
                    dt.Columns.Add("Nom");
                    dt.Columns.Add("Max");
                    dt.TableName = module.LeftHeader;
                    foreach (DataGridViewRow row in module.dgv_Module.Rows)
                    {
                        var codetext = row.Cells["col_CodeText"].Value;
                        var min = row.Cells["col_Min"].Value;
                        var nom = row.Cells["col_Nom"].Value;
                        var max = row.Cells["col_Max"].Value;
                        if (!string.IsNullOrEmpty(codetext.ToString()))
                            dt.Rows.Add(codetext, min, nom, max);
                    }
                    dataTables_ProcessData.Add(dt);
                }
            }
        }

        private void Load_ProcessDataFromOldTemplateRevision()
        {
            foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
            {
                foreach (TableLayoutPanel tlp in machine.Controls)
                {
                    foreach (var module in tlp.Controls.OfType<Module>())
                    {
                        foreach (var dt in dataTables_ProcessData)
                        {
                           // if (dt.TableName == module.LeftHeader)
                           {
                               foreach (DataGridViewRow row in module.dgv_Module.Rows)
                               {
                                   foreach (DataRow dataRow in dt.Rows)
                                   {
                                       string codeText = dataRow["CodeText"].ToString();
                                       if (row.Cells["col_CodeText"].Value.ToString() == dataRow["CodeText"].ToString())
                                       {
                                           row.Cells["col_Min"].Value = dataRow["Min"].ToString();
                                           row.Cells["col_Nom"].Value = dataRow["Nom"].ToString();
                                           row.Cells["col_Max"].Value = dataRow["Max"].ToString();
                                       }

                                   }
                               }
                           }

                        }
                    }
                }
            }
            dataTables_ProcessData.Clear();
        }

        //------------------------- SAVE -------------------------
        private bool IsOkToSaveProcesscard
        {
            get
            {
                if (Is_ProdlineChecked() == false)
                {
                    InfoText.Show(LanguageManager.GetString("saveProcesscard_Info_1"), CustomColors.InfoText_Color.Warning, "ProdLine", this);
                    ControlValidator.SoftBlink(tb_ProdLine, Color.Red, Color.Black);
                    return false;
                }
                if (Is_ProdTypeChecked == false)
                {
                    InfoText.Show(LanguageManager.GetString("saveProcesscard_Info_8"), CustomColors.InfoText_Color.Warning, "ProdType", this);
                    ControlValidator.SoftBlink(tb_ProdType, Color.Red, Color.Black);
                    return false;
                }
                if (string.IsNullOrEmpty(cb_TemplateRevision.Text))
                {
                    InfoText.Show(LanguageManager.GetString("saveProcesscard_Info_9"), CustomColors.InfoText_Color.Warning, string.Empty, this);
                    ControlValidator.SoftBlink(cb_TemplateRevision, Color.Red, Color.Black);
                    return false;
                }

                if (IsAllDone == false)
                    return false;

                if (!string.IsNullOrEmpty(ProcesscardBasedOn.lbl_QA_Sign.Text))
                {
                    InfoText.Show(LanguageManager.GetString("saveProcesscard_Info_2"), CustomColors.InfoText_Color.Warning, "Warning", this);
                    return false;
                }
                return true;
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (IsOkToSaveProcesscard == false)
                return;

            Order.PartNumber = tb_NewPartNr.Text;
            tb_RevInfo.Select();

            var is_Ok = false;
            Templates_Protocol.MainTemplate.Revision = cb_TemplateRevision.Text;
            Templates_MeasureProtocol.MainTemplate.Name = cb_MeasureProtocolTemplateName.Text;

            if (IsUpdateProcesscard)
                if (IsPartIDHaveOrdersRunned == false)
                    Update_Processcard(ref is_Ok);
                else
                    return;
            else
            {
                if (IsPartRevisionNrExist)
                    return;
                Save_ProcessCard(ref is_Ok);
            }

            if (is_Ok == false)
                return;
            Choose_And_Load_PartNr();
            IsUpdateProcesscard = true;
            Points.Add_Points(10, "Sparar/Uppdaterar Processkortet");
        }
        private void Save_ProcessCard(ref bool IsOk)
        {
            var pbar = new ProgressBar();
            pbar.Show();
            pbar.Set_ValueProgressBar(0, $"Saving Processcard {Order.PartNumber} - RevNr {Order.RevNr}");

            Order.PartID = Part.Get_NewPartID;
            if (Part.IsPartNr_Exist(tb_NewPartNr.Text, Order.WorkOperation.ToString(), tb_ProdLine.Text, tb_ProdType.Text) == false)
                Part.Create_NewPartGroup_ID();
            else
                Part.Load_PartGroup_ID(Order.PartNumber, Order.WorkOperation);


            switch (Order.WorkOperation)
            {
                default:
                    Processcard.Save.Save_MainData(ref IsOk, (int)Order.PartID, Parameters_Main);
                    foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
                    {
                        foreach (TableLayoutPanel tlp in machine.Controls)
                            foreach (var module in tlp.Controls.OfType<Module>())
                            {
                                if (IsOk == false)
                                    continue;
                                module.save_processcard.Save_Data(cb_TemplateRevision.Text, ref IsOk);
                            }
                    }

                    if (IsOk == false)
                        Processcard.DeleteProcesscard(Order.PartID);
                    break;
               
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    Processkort_Kragning.Save_Data(ref IsOk, Parameters_Main);
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Processcard_Skärmning.Save_Data(ref IsOk, Parameters_Main);
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Processkort_Slipning.Save_Data(ref IsOk, Parameters_Main);
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Processkort_Svetsning.Save_Data(ref IsOk, Parameters_Main);
                    break;
            }

            pbar.Close();
            if (!IsOk)
                return;

            InfoText.Show($@"{LanguageManager.GetString("saveProcesscard_Info_3_1")} {tb_NewPartNr.Text}, Revision: {ProcesscardBasedOn.lbl_RevNr.Text}
{LanguageManager.GetString("saveProcesscard_Info_3_2")}", CustomColors.InfoText_Color.Ok, null, this);

            Load_Processcard_Info();
            Order.PartGroupID = null;
            
        }


        //------------------------- UPDATE -------------------------
        private void Update_Processcard(ref bool IsOk)
        {
            var pbar = new ProgressBar();
            pbar.Show();
            pbar.Set_ValueProgressBar(0, $"Updating Processcard {Order.PartNumber} - RevNr {Order.RevNr}");
            switch (Order.WorkOperation)
            {
                default:
                    Processcard.Save.Update_MainData(ref IsOk, Parameters_Main);
                    foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
                    {
                        foreach (TableLayoutPanel tlp in machine.Controls)
                        foreach (var module in tlp.Controls.OfType<Module>())
                        {
                            if (IsOk == false)
                                continue;
                            module.save_processcard.Update_Data(cb_TemplateRevision.Text, ref IsOk);
                        }
                    }
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    Processkort_Kragning.Update_Data(ref IsOk, Parameters_Main);
                    break;
               
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Processcard_Skärmning.Update_Data(ref IsOk, Parameters_Main);
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Processkort_Slipning.Update_Data(ref IsOk, Parameters_Main);
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Processkort_Svetsning.Update_Data(ref IsOk, Parameters_Main);
                    break;
               
                case Manage_WorkOperation.WorkOperations.Nothing:
                    break;
            }

            pbar.Close();
            if (!IsOk)
                return;

            
            InfoText.Show($"{LanguageManager.GetString("saveProcesscard_Info_4")} {tb_NewPartNr.Text}, revision: {ProcesscardBasedOn.lbl_RevNr.Text}", CustomColors.InfoText_Color.Ok, null,this);

            dgv_Revision.CellEnter -= Revision_CellEnter;
            Load_Processcard_Info();
            dgv_Revision.CellEnter += Revision_CellEnter;

        }
        private void Update_Processkort_NumberOfLayers(object sender, EventArgs e)
        {
            if (IsData_Loading)
                return;
            if (IsUpdateProcesscard == false)
            {
                InfoText.Show(LanguageManager.GetString("saveProcesscard_Info_5"), CustomColors.InfoText_Color.Warning, "Warning", this);
                num_NumberOfLayers.Value = 0;
                return;
            }
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"UPDATE Processcard.MainData SET NumberOfLayers = @layers WHERE PartID = @partid";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partid", Order.PartID);
                SQL_Parameter.Int(cmd.Parameters, "@layers", num_NumberOfLayers.Value.ToString(CultureInfo.InvariantCulture));
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        

        public static void Execute_cmd(IDbCommand cmd, ref bool IsOk)
        {
            try
            {
                cmd.ExecuteNonQuery();
                IsOk = true;
            }
            catch (Exception e)
            {
                IsOk = false;
                InfoText.Show(LanguageManager.GetString("saveProcesscard_Info_6"),
                    CustomColors.InfoText_Color.Bad, "Warning!");

                if (Person.Role != "SuperAdmin")
                    Mail.Inform_SuperAdmin_Bug_Create_Processcard(e.Message);
                
                InfoText.Show(e.Message, CustomColors.InfoText_Color.Info, null);
            }
        }

        //---------------Events---------------
        private bool IsLoadingData;
        private void Revision_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsLoadingData)
                return;
            IsLoadingData = true;
            cb_TemplateRevision.SelectedIndexChanged -= ProtocolTemplateRevision_SelectedIndexChanged;

            ProcesscardBasedOn.lbl_RevNr.Text = dgv_Revision.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (int.TryParse(dgv_Revision.Rows[e.RowIndex].Cells[4].Value.ToString(), out var partID))
                Order.PartID = partID;
            if (Order.PartID != 0)
                Load_Data_Processcard(false);

            cb_TemplateRevision.SelectedIndexChanged += ProtocolTemplateRevision_SelectedIndexChanged;
            IsLoadingData = false;
        }
        private void PartNr_Enter(object sender, EventArgs e)
        {
            var artikelNr_Aktiv = chb_HideInactive_PartNr.Checked;
            var list = new List<string>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = "SELECT DISTINCT PartNr FROM Processcard.MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) AND Aktiv = @aktiv ORDER BY PartNr DESC";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@aktiv", artikelNr_Aktiv);
                SQL_Parameter.String(cmd.Parameters, "@workoperation", Order.WorkOperation.ToString());
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() != "1234567")    //PartNr 1234567 används när man förhandsgranskar ett tomt processkort och bör inte visas i listan
                        list.Add(reader[0].ToString());
                }
                reader.Close();
            }

            var choose_Item = new Choose_Item(list, new Control[] {tb_PartNr}, false);
            choose_Item.ShowDialog();
        }
        private void PartNr_TextChanged(object sender, EventArgs e)
        {
            ProcesscardBasedOn.lbl_RevNr.Text = string.Empty;
            tb_NewPartNr.TextChanged -= ArtikelNr_TextChanged;
            Choose_And_Load_PartNr();
            tb_NewPartNr.TextChanged += ArtikelNr_TextChanged;
        }
        private void ReloadPartNr_Click(object sender, EventArgs e)
        {
            ProcesscardBasedOn.lbl_RevNr.Text = string.Empty;
            tb_NewPartNr.TextChanged -= ArtikelNr_TextChanged;
            Choose_And_Load_PartNr();
            tb_NewPartNr.TextChanged += ArtikelNr_TextChanged;
        }
        private void ProdType_Click(object sender, EventArgs e)
        {
            var ctrl = (Control) sender;
            var choose_Item = new Choose_Item(MainInfo_B.List_ProdType("Processcard.MainData"), new[] { ctrl }, false, true);
            choose_Item.ShowDialog();
        }
        private void ProdType_TextChanged(object sender, EventArgs e)
        {
            if (tb_ProdType.Text != Order.ProdType)
                Order.ProdType = tb_ProdType.Text;
        }
        private void ArtikelNr_TextChanged(object sender, EventArgs e)
        {
            ProcesscardBasedOn.lbl_RevNr.Text = "A";
            ProcesscardBasedOn.lbl_QA_Sign.Text = string.Empty;
            ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr.Text = string.Empty;
            IsUpdateProcesscard = false;
        }
        private void ProdLine_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Equipment.Equipment.List_ProdLines, new[] { ctrl }, false);
            choose_Item.ShowDialog();
        }
        private void ProdLinje_TextChanged(object sender, EventArgs e)
        {
            Order.PartGroupID = null;
            if (tb_ProdLine.Text != Order.ProdLine)
            {
                IsUpdateProcesscard = false;
                Order.ProdLine = tb_ProdLine.Text;
                ProcesscardBasedOn.lbl_RevNr.Text = "A";
                ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr.Text = string.Empty;
                ProcesscardBasedOn.lbl_QA_Sign.Text = string.Empty;
            }
        }

        private void NewPartNr_Enter(object sender, EventArgs e)
        {
            //Used if List_PartNr is filled. Right now it takes to long to fill this, so it must be filled somehow async
            if (Monitor.Monitor.List_PartNr is null)
                return;
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Monitor.Monitor.List_PartNr, new[] { ctrl }, false, true);
            choose_Item.ShowDialog();
        }

        private void ProtocolTemplateRevision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressSelectionChanged) 
                return;
            Templates_Protocol.MainTemplate.Revision = cb_TemplateRevision.Text;
            Templates_Protocol.MainTemplate.Set_MainTemplateID(cb_ProtocolTemplateName.Text, cb_TemplateRevision.Text);
            Load_Data_Processcard(false, true);
        }
        private void TemplateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_cb_ProtocolTemplateRevision();
            Templates_Protocol.MainTemplate.Load_MainTemplateID(cb_ProtocolTemplateName.Text, cb_TemplateRevision.Text);
            Templates_Protocol.MainTemplate.Revision = cb_TemplateRevision.Text;
           
            //LoadTemplate();
        }
        private void TemplateName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CopyProcessDataToNewTemplateRevision();
            LoadTemplate();
        }
        private bool suppressSelectionChanged;
        private void RevNrChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr.Text) == false && cb_TemplateRevision.Items.Count > 1 && cb_TemplateRevision.SelectedIndex < cb_TemplateRevision.Items.Count - 1)
            {
                suppressSelectionChanged = true; // Prevent event from firing

                cb_TemplateRevision.SelectedIndex = cb_TemplateRevision.Items.Count - 1;

                InfoText.Show($"Detta processkort är kopplat till en äldre revision av Mallen.\n" +
                              $"Den senaste Revision av Mallen aktiveras nu.", CustomColors.InfoText_Color.Info, "Warning", this);
                CopyProcessDataToNewTemplateRevision();
                Templates_Protocol.MainTemplate.Revision = cb_TemplateRevision.Text;
                Templates_Protocol.MainTemplate.Set_MainTemplateID(cb_ProtocolTemplateName.Text, cb_TemplateRevision.Text);
                LoadTemplate();
                suppressSelectionChanged = false; // Allow event firing again
            }

            IsUpdateProcesscard = false;
            ProcesscardBasedOn.lbl_UpprättatAv_Sign_AnstNr.Text = string.Empty;
            cb_TemplateRevision.SelectedIndexChanged += ProtocolTemplateRevision_SelectedIndexChanged;
        }

        private void NewTemplate_Click(object sender, EventArgs e)
        {
            var newTemplate = new Templates_Protocol();
            newTemplate.Show();
        }
        private void Info_Click(object sender, EventArgs e)
        {
                InfoText.Show(
                    $@"
OrderNr = {Order.OrderNumber} 
OrderID = {Order.OrderID}
Operation = {Order.Operation}
PartNr = {Order.PartNumber} 
PartID = {Order.PartID}
PartGroupID = {Order.PartGroupID}
RevNr = {Order.RevNr}
WorkOperation = {Order.WorkOperation}
WorkOperationID = {Order.WorkoperationID}
ProdLinje = {Order.ProdLine}
ProduktTyp = {Order.ProdType}
ProdGrupp = {Order.ProdGroup} 
Kund = {Order.Customer}
Benämning = {Order.Description}

Theme = {Teman.Theme}
Name = {Person.Name} - {Person.EmployeeNr}
Befattning = {Person.Role}
MonitorCompany = {Database.MonitorCompany}

ManageProcesscards = {IsProcesscardUnderManagement}
pg_pgrkod = {Order.ProdGrupp_pgrKod}

Measureprotocol.MainTemplateID = {Templates_MeasureProtocol.MainTemplate.ID}
Protocol.MainTemplateID = {Templates_Protocol.MainTemplate.ID}
Protocol.TemplateRevision = {Templates_Protocol.MainTemplate.Revision}

HS-Machine = {Equipment.Equipment.HS_Machine}", CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void Töm_Processkort_Click(object sender, EventArgs e)
        {
            Clear_Data();
        }
        

        private void Aktivera_Inaktivera_ArtikelNr_Click(object sender, EventArgs e)
        {
            Processcard.Update_Status_Processcard(tb_NewPartNr, btn_DeActivate_PartNr);
            Load_Data_Processcard(false);
        }
        private void Delete_Processcard_Click(object sender, EventArgs e)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.DeleteProcessCards) && !string.IsNullOrEmpty(tb_NewPartNr.Text) && !string.IsNullOrEmpty(ProcesscardBasedOn.lbl_RevNr.Text))
            {
                if (Part.TotalOrdersRun > 0)
                {
                    InfoText.Show(LanguageManager.GetString("delete_Processcard_1"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return;
                }
                InfoText.Question($"{LanguageManager.GetString("saveProcesscard_Info_7_1")}\n\n" +
                    $"{LanguageManager.GetString("label_PartNumber")} {tb_NewPartNr.Text}\n" +
                    $"{LanguageManager.GetString("label_RevNr")} {ProcesscardBasedOn.lbl_RevNr.Text}\n" +
                    $"{LanguageManager.GetString("label_ProdLine")} {tb_ProdLine.Text}\n" +
                    $"{LanguageManager.GetString("label_ProdType")} {tb_ProdType.Text}\n" +
                    $"{Order.WorkOperation}\n\n" +
                    $"{LanguageManager.GetString("saveProcesscard_Info_7_2")}", CustomColors.InfoText_Color.Warning, "WARNING!", this);
                if (InfoText.answer == InfoText.Answer.Yes)
                    Processcard.DeleteProcesscard(Order.PartID);

                dgv_Revision.Rows.RemoveAt(0);
                dgv_Revision.Rows[0].Selected = true;
            }
            

        }
        private void UpdateTemplate_Click(object sender, EventArgs e)
        {
            //if (Order.PartID != null)
                //Template.Update_ProcesscardWithNewTemplate((int)Order.PartID, Template.Old_MainTemplateID((int)Order.PartID), Order.MainTemplateID, cb_TemplateRevision.Text);
        }
        private void CopyPartNr_Click(object sender, EventArgs e)
        {
            var Parts = new List<string>();
            if (string.IsNullOrEmpty(tb_ProdLine.Text))
            {
                InfoText.Show("Du måste först välja en Prodlinje som du vill kopiera artiklar ifrån.", CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (string.IsNullOrEmpty(tb_RevInfo.Text))
            {
                InfoText.Show("Du måste fylla i Revisionsinfo före du kopierar processkort.", CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            InfoText.PromptForText("Välj här vilken Produktionslinje du vill kopiera till.", CustomColors.InfoText_Color.Info, "Välj ProduktionsLinje", this, Equipment.Equipment.List_ProdLines);
            Order.ProdLine = InfoText.return_Text;
            if (string.IsNullOrEmpty(tb_ProdLine.Text))
                return;
            var ActiveProdLines = new List<string>
            {
                "R5",
                "R6",
                "OPEX08",
                "OPEX09",
                "OPEX13"
            };

            //using (var con = new SqlConnection(Database.cs_Protocol))
            //{
            //    con.Open();
            //    var query = @"
            //       SELECT DISTINCT PartNr FROM Processcard.MainData WHERE PartNr LIKE '358%' AND Aktiv = 'True'";

            //    var cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@prodline", tb_ProdLine.Text);
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //        Parts.Add(reader[0].ToString());
            //}

            foreach (var prodline in ActiveProdLines)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = @"
                        WITH RankedData AS 
                        (
                            SELECT PartID, PartNr, RevNr, ROW_NUMBER() OVER (PARTITION BY PartNr ORDER BY RevNr DESC) AS rn
                            FROM Processcard.MainData
                            WHERE PartNr NOT IN 
                            (
                                SELECT PartNr
                                FROM Processcard.MainData
                                WHERE ProdLine = @prodline
                            )
                            AND PartNr LIKE '358%'
                            AND Aktiv = 'True'
                        )
                        SELECT PartID, PartNr, RevNr
                        FROM RankedData
                        WHERE rn = 1
                        ORDER BY PartNr;";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@prodline", prodline);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        Parts.Add(reader[1].ToString());
                }


                // InfoText.Show($"Är du säker på att du vill skapa {Parts.Count} st nya processkort.", CustomColors.InfoText_Color.Warning, null, null, null, 0, true);
                // if (InfoText.answer == InfoText.Answer.No)
                //     return;

                foreach (var partNr in Parts)
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        con.Open();
                        var query = @"
                        SELECT TOP(1) m.PartID, m.MainTemplateID, m.ProtocolTemplateRevision, m.PartGroupID, m.PartNr, m.RevNr, m.ProdType,
                            (SELECT TextValue FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1024) AS MunstyckeTyp,
                            (SELECT TextValue FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1025) AS Munstycke,
	                        (SELECT Value FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1026) AS Munstycke_LL,
	                        (SELECT TextValue FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1027) AS KärnaTyp,
                            (SELECT TextValue FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1028) AS Kärna,
	                        (SELECT Value FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1029) AS Kärna_LL,
                            (SELECT MachineIndex FROM Processcard.Data WHERE PartID = m.PartID AND TemplateID = 1029) AS MachineIndex
                        FROM Processcard.MainData m
                        WHERE m.PartNr = @partnr
                        ORDER BY m.RevNr DESC";

                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@partnr", partNr);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var result = 0;
                            var maintemplateid = reader["MainTemplateID"].ToString();
                            SaveCopiedPartNr_MainData(reader["PartNr"].ToString(), reader["ProdType"].ToString(), prodline, maintemplateid, ref result);
                            if (result == 0)
                                continue;
                            int.TryParse(reader["MachineIndex"].ToString(), out var machineindex);
                            SaveCopiedPartNr_Data(1024, machineindex, 0, reader["MunstyckeTyp"].ToString(), 1);
                            SaveCopiedPartNr_Data(1025, machineindex, 0, reader["Munstycke"].ToString(), 1);
                            double.TryParse(reader["Munstycke_LL"].ToString(), out var munstycke_ll);
                            SaveCopiedPartNr_Data(1026, machineindex, munstycke_ll, null, 0);

                            SaveCopiedPartNr_Data(1027, machineindex, 0, reader["KärnaTyp"].ToString(), 1);
                            SaveCopiedPartNr_Data(1028, machineindex, 0, reader["Kärna"].ToString(), 1);
                            double.TryParse(reader["Kärna_LL"].ToString(), out var kärna_ll);
                            SaveCopiedPartNr_Data(1029, machineindex, kärna_ll, null, 0);
                        }
                    }
                }
            }

            InfoText.Show($"{Parts.Count} st nya processkort har skapats för Prodlinje {Order.ProdLine}", CustomColors.InfoText_Color.Ok, "Info", this);
        }

        private void SaveCopiedPartNr_MainData(string partnr, string prodtype, string prodline, string maintemplateid, ref int result)
        {
            Order.PartID = Part.Get_NewPartID;
            Part.Create_NewPartGroup_ID();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"
                    IF NOT EXISTS (SELECT * FROM Processcard.MainData WHERE PartNr = @partnr AND RevNr = 'A' AND ProdLine = @prodline AND ProdType = @prodtype)
                    BEGIN
                    INSERT INTO Processcard.MainData 
                        VALUES (@partid, @partgroupid, @partnr, 'A', @prodline, @prodtype,@templaterevision, @workoperationid, 'False', @numberoflayers, NULL, NULL, @revdatum, NULL, @upprättatsig, @revinfo, 'False', 'False', 'True', NULL, 'True')
                    SELECT 1
                    END
                    ELSE
                        BEGIN
                    SELECT 0
                    END";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partid", Order.PartID);
                cmd.Parameters.AddWithValue("@templaterevision", Processcard.Latest_Processcard_Revision(FormTemplateID));
                cmd.Parameters.AddWithValue("@partgroupid", Order.PartGroupID);
                cmd.Parameters.AddWithValue("@partnr", partnr);
                cmd.Parameters.AddWithValue("@prodline", prodline);
                cmd.Parameters.AddWithValue("@prodtype", prodtype);
                cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
                cmd.Parameters.AddWithValue("@numberoflayers", num_NumberOfLayers.Value);
                cmd.Parameters.AddWithValue("@revdatum", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@upprättatsig", $"{Person.Sign}/{Person.EmployeeNr}");
                cmd.Parameters.AddWithValue("@revinfo", tb_RevInfo.Text);
                result = Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
        private static void SaveCopiedPartNr_Data(int templateid, int machineindex, double value, string textvalue, int type)
        {

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"
                        INSERT INTO Processcard.Data 
                        VALUES (@partid, @templateid, @machineindex, @value, @textvalue, @type)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partid", Order.PartID);
                cmd.Parameters.AddWithValue("@templateid", templateid);
                cmd.Parameters.AddWithValue("@machineindex", machineindex);
                if (value > 0)
                    cmd.Parameters.AddWithValue("@value", value);
                else
                    cmd.Parameters.AddWithValue("@value", DBNull.Value);
                if (!string.IsNullOrEmpty(textvalue))
                    cmd.Parameters.AddWithValue("@textvalue", textvalue);
                else
                    cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.ExecuteScalar();
            }
        }






        //------------------------- CLOSE -------------------------
        private void Lägg_till_nytt_Processkort_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Order.ProdLinje = org_ProdLinje;
            Main_Form.Timer_UpdateChart.Start();
        }
        private void Skapa_Uppdatera_Processkort_Activated(object sender, EventArgs e)
        {
            IsProcesscardUnderManagement = true;
        }

       
    }
}