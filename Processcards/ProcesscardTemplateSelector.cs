using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using static System.Net.Mime.MediaTypeNames;
using Color = System.Drawing.Color;

namespace DigitalProductionProgram.Processcards
{
    public partial class ProcesscardTemplateSelector : Form
    {
        public bool IsOkClose;
        public bool IsAborted = false;
        private static bool IsDevelopmentOfProcessCard(int? partID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT TOP(1) Framtagning_Processfönster FROM Processcard.MainData
                                WHERE PartID = @partid";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@partid", partID);
            con.Open();
            return Convert.ToBoolean(cmd.ExecuteScalar());
        }
        private readonly bool IsOperatorStartingOrder;
        private readonly bool IsOnlyProcesscard;
        private readonly bool IsAutoSelectTemplate;

        public int totalLabels;
        public enum TemplateType
        {
            TemplateProtocol,
            TemplateMeasureProtocol,
            Workoperations
        }

        public class HeaderButton : Button
        {
            public string? TemplateName { get; set; }
            public int TemplateID { get; set; }
            public string? TemplateRevision { get; set; }
            public string? ProdType { get; set; }
            public string? ProdLine { get; set; }
            public string? RevNr { get; set; }
            public string? Workoperation { get; set; }
            public int WorkoperationID { get; set; }
            public int? PartID { get; set; }
            public int? PartGroupID { get; set; }
            public bool IsProcesscardOkToStart { get; set; }
            public string? LatestRevNr { get; set; }
            public bool IsLatestRevNrSelected { get; set; }

        }
        private static HeaderButton CreateButton(string? text, EventHandler clickEvent, int? id = null, string? workoperation = null, string? revNr = null, string? prodtype = null, string? prodline = null, int? partid = null, int? partGroupID = null, bool isProcesscardOkToStart = false, bool isLatestRevNrSelected = true, string? latestRevNr = null)
        {
            var button = new HeaderButton
            {
                AutoSize = true,
                Cursor = Cursors.Hand,
                Font = new System.Drawing.Font("Palatino Linotype", 10.25f, FontStyle.Bold),
                ForeColor = CustomColors.Teal_Font,
                IsProcesscardOkToStart = isProcesscardOkToStart,
                IsLatestRevNrSelected = isLatestRevNrSelected,
                LatestRevNr = latestRevNr,
                Margin = new Padding(0, 0, 0, 10),
                PartID = partid,
                PartGroupID = partGroupID,
                ProdLine = prodline,
                ProdType = prodtype,
                RevNr = revNr,
                TemplateName = text,
                TemplateID = id ?? 0,
                Text = text,
                Workoperation = workoperation
            };

            button.Click += clickEvent;
            return button;
        }



        public ProcesscardTemplateSelector(bool isOperatorStartingOrder, bool isOnlyProcesscard, bool IsOkSelectLatestRev, bool isAutoSelectTemplate)
        {
            IsOperatorStartingOrder = isOperatorStartingOrder;
            IsOnlyProcesscard = isOnlyProcesscard;
            IsAutoSelectTemplate = isAutoSelectTemplate;
            InitializeComponent();
            Translate_Form();

            Load_Processcard(IsOkSelectLatestRev);

            if (totalLabels == 0)
                _ = Activity.Stop("Problem - Välj ProduktionsLinje");

           
        }
        public ProcesscardTemplateSelector(TemplateType template)
        {
            InitializeComponent();

            switch (template)
            {
                case TemplateType.TemplateProtocol:
                    tlp_InfoLabels.Visible = false;
                    label_Header.Text = "Välj mall för Körprotokoll/Processkort:\n" +
                                        "Detta Artikelnummer har ingen mall för Protokollet kopplat, det finns flera mallar som passar denna operation.";
                    Add_ProtocolTemplates();
                    break;
                case TemplateType.TemplateMeasureProtocol:
                    tlp_InfoLabels.Visible = false;
                    label_Header.Text = "Välj mall för Mätprotokollet:\n" +
                                        "Detta Artikelnummer har ingen mall för Mätprotokoll kopplat, det finns flera mallar som passar denna operation.";
                    Add_MeasureProtocolTemplates();
                    break;
                case TemplateType.Workoperations:
                    tlp_InfoLabels.Visible = false;
                    label_Header.Text = "Välj Arbetsoperation nedan:\n" +
                                        "Detta Artikelnummer tillhör flera Arbetsoperationer.";
                    Add_Workoperations();
                    break;
            }
            SetFormHeight();
        }

        private void ProcesscardTemplateSelector_Load(object sender, EventArgs e)
        {
            if (totalLabels == 1)
            {
                foreach (HeaderButton btn in flp_Buttons.Controls.OfType<HeaderButton>())
                    btn.PerformClick();
            }

            if (totalLabels == 0)
            {
                IsOkClose = true;
                Close();
            }

            //Om användare håller på öppna Bläddra gamla ordrar så väljs automatiskt den första mallen i listan pga att det är irrelevant vilken mall som väljs eftersom det ändå väljs automatiskt när ordern öppnas.
            if (IsAutoSelectTemplate)
                foreach (HeaderButton btn in flp_Buttons.Controls.OfType<HeaderButton>())
                    btn.PerformClick();
        }
        private void ProcesscardTemplateSelector_Shown(object sender, EventArgs e)
        {
            SetFormHeight();
        }
        private void Translate_Form()
        {
            Control[] controls = { label_Header, label_Green, label_Brown, label_Orange, label_Red };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        private void Load_Processcard(bool IsOkSelectLatestRev)
        {
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                case Manage_WorkOperation.WorkOperations.Skärmning:
                case Manage_WorkOperation.WorkOperations.Slipning:
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Add_TemplateName();
                    break;
                case Manage_WorkOperation.WorkOperations.Nothing:
                    if (IsOperatorStartingOrder)
                    {
                        Add_MultipleProcesscards(IsOkSelectLatestRev);
                        Add_TemplateName();
                    }
                    else
                    {
                        tlp_InfoLabels.Visible = false;
                        label_Header.Text = LanguageManager.GetString("chooseProtocol_1");
                        Add_TemplateName();
                        //label_Green.Visible = label_Brown.Visible = label_Orange.Visible = label_Red.Visible = false;
                    }
                    break;
                default:
                    label_Header.Text = LanguageManager.GetString("chooseProtocol_3");
                    Add_MultipleProcesscards(IsOkSelectLatestRev);
                    break;
            }
        }





        private void Add_MultipleProcesscards(bool IsOkSelectLatestRev)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                WITH OrderedRevisions AS 
                (
                    SELECT 
                        PartID, 
                        PartGroupID, 
                        RevNr, 
                        ProdLine,
                        ProdType,
                        QA_sign,
                        Historiska_Data, 
                        Validerat,  
                        Framtagning_Processfönster,
                        ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) AS RowNum, -- Latest revision first
                        COUNT(*) OVER (PARTITION BY PartGroupID) AS TotalRevisions,
                        MIN(RevNr) OVER (PARTITION BY PartGroupID) AS FirstRev, -- First revision 
                        MAX(RevNr) OVER (PARTITION BY PartGroupID) AS LatestRev, -- Latest revision
                        MAX(CASE WHEN Framtagning_Processfönster = 'True' THEN RevNr END) OVER (PARTITION BY PartGroupID) AS LatestFramtagningRev, -- Latest revision where Framtagning_Processfönster = TRUE
                        MAX(CASE WHEN QA_sign IS NOT NULL THEN RevNr END) OVER (PARTITION BY PartGroupID) AS LatestApprovedRev -- Find latest approved revision
                    FROM Processcard.MainData 
                    WHERE PartNr = @partnr
                        AND WorkoperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation)
                 ),
                    CheckAllNulls AS 
                    (
                        -- Find PartGroupIDs where ALL revisions have QA_sign = NULL
                        SELECT PartGroupID 
                        FROM OrderedRevisions 
                        GROUP BY PartGroupID 
                        HAVING COUNT(*) = COUNT(CASE WHEN QA_sign IS NULL THEN 1 END) 
                    )
                SELECT DISTINCT 
                    PartID, 
                    PartGroupID, 
                    RevNr, 
                    ProdLine, 
                    ProdType, 
                    QA_sign, 
                    Historiska_Data, 
                    Validerat, 
                    Framtagning_Processfönster,
                    LatestRev,
                    CASE WHEN RevNr = LatestRev THEN 1 ELSE 0 END AS LatestRevSelected
                FROM OrderedRevisions
                WHERE (@IsOkSelectLatestRev = 1 AND RevNr = LatestRev) -- Select LatestRev if IsOkSelectLatestRev is true
                    OR (@IsOkSelectLatestRev = 0 AND ((RevNr = LatestApprovedRev)
                    OR (RevNr = FirstRev AND PartGroupID IN (SELECT PartGroupID FROM CheckAllNulls) AND Framtagning_Processfönster = 'False')
                    OR (RevNr = LatestFramtagningRev AND PartGroupID IN (SELECT PartGroupID FROM CheckAllNulls) AND EXISTS (SELECT 1 FROM OrderedRevisions WHERE PartGroupID = OrderedRevisions.PartGroupID AND Framtagning_Processfönster = 'True'))
                ))
                ORDER BY PartGroupID, RevNr DESC;";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@partnr", SqlDbType.NVarChar).Value = Order.PartNumber;
            cmd.Parameters.Add("@workoperation", SqlDbType.NVarChar).Value = Order.WorkOperation.ToString();
            cmd.Parameters.Add("@IsOkSelectLatestRev", SqlDbType.Bit).Value = IsOkSelectLatestRev;

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var text = $"{reader["ProdLine"]} / {reader["ProdType"]}";
                int.TryParse(reader["PartID"].ToString(), out var partid);
                int.TryParse(reader["PartGroupID"].ToString(), out var partGroupID);
                var prodType = reader["ProdType"].ToString();
                var prodLine = reader["ProdLine"].ToString();
                var revNr = reader["RevNr"].ToString();
                var latestRevNr = reader["LatestRev"].ToString();
                var isLatestRevNrSelected = Convert.ToBoolean(reader["LatestRevSelected"]);

                Add_Button_Processcard(text, Order.WorkOperation.ToString(), prodType, prodLine, revNr, partid, partGroupID, !IsOperatorStartingOrder, true, latestRevNr, isLatestRevNrSelected);
            }
            Add_Button_Processcard("Processkort saknas", Order.WorkOperation.ToString(), null, null, null, null, null, true, false, null, true);
        }
        private void Add_Workoperations()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT WorkoperationID, Name
                    FROM Workoperation.ProductionLines as prodlines
                    JOIN Workoperation.Names as names
	                    ON prodlines.WorkoperationID = names.ID
                    WHERE ProductionLine = @prodline";
            var cmd = new SqlCommand(query, con);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var workoperation = reader["Name"].ToString();
                int.TryParse(reader["WorkoperationID"].ToString(), out var workoperationID);
                Add_Button_Workoperations(workoperation, workoperationID);
            }
        }
        private void Add_ProtocolTemplates()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                WITH RankedRevisions AS (
                    SELECT Name, Revision, ID,
                    ROW_NUMBER() OVER (PARTITION BY Name ORDER BY Revision DESC) AS RevisionRank
                FROM Protocol.MainTemplate
                WHERE WorkoperationID = @workoperationid
                )
                SELECT Name, Revision, ID
                FROM RankedRevisions
                WHERE RevisionRank = 1
                ORDER BY Name;";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var templatename = reader["Name"].ToString();
                int.TryParse(reader["ID"].ToString(), out var id);
                Add_Button_ProtocolTemplate(templatename, templatename, id);
            }
        }
        private void Add_MeasureProtocolTemplates()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    WITH RankedTemplates AS 
                        (
                            SELECT 
                                MeasureProtocolMainTemplateID,
                                Name, 
                                Revision,	
                                WorkoperationID, 
                                ROW_NUMBER() OVER (PARTITION BY Name ORDER BY Revision DESC) AS rn
                            FROM MeasureProtocol.MainTemplate
                        )
                    SELECT 
                        MeasureProtocolMainTemplateID, 
                        Name, 
                        Revision, 
                        WorkoperationID
                    FROM RankedTemplates
                        WHERE 
                            rn = 1
	                      AND WorkoperationID = @workoperationid
                    ORDER BY Name ";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var templatename = reader["Name"].ToString();
                int.TryParse(reader["MeasureProtocolMainTemplateID"].ToString(), out var id);
                var revision = reader["Revision"].ToString();
                Add_Button_MeasureprotocolTemplate(templatename, revision, id);
            }
        }
        private void Add_TemplateName()
        {
            // var org_Arbetsoperation = Order.WorkOperation;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT DISTINCT maintemplate.Name, workoperation.Name
                    FROM Processcard.MainData AS processcard
                        LEFT JOIN Protocol.MainTemplate AS maintemplate
                            ON processcard.ProtocolMainTemplateID = maintemplate.ID
                        LEFT JOIN Workoperation.Names AS workoperation
                            ON maintemplate.WorkoperationID = workoperation.ID
                    WHERE processcard.PartNr = @partnumber ";
            if (IsOnlyProcesscard == false)
                query +=
                    @"UNION
                    SELECT DISTINCT maintemplate.Name, workoperation.Name
                    FROM [Order].MainData AS protocol
                        LEFT JOIN Protocol.MainTemplate AS maintemplate
                            ON protocol.ProtocolMainTemplateID = maintemplate.ID
                        LEFT JOIN Workoperation.Names AS workoperation
                            ON maintemplate.WorkoperationID = workoperation.ID
                    WHERE protocol.PartNr = @partnumber
                    ORDER BY maintemplate.Name";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var templatename = reader[0].ToString();
                var workoperation = reader[1].ToString();
                if (workoperation != null) Add_Button_ProtocolTemplate(templatename, templatename, 0, workoperation, null, null, Order.PartID, Order.PartGroupID, true);
            }
        }

        private void Add_Button_Processcard(string? text, string workoperation, string? prodtype, string? prodline, string? revNr, int? partid, int? partGroupID, bool isProcesscardOkToStart, bool isOkCheckPartNumber, string? latestRevNr, bool isLatestRevNrSelected)
        {
            totalLabels++;
            var btn = CreateButton(text, Button_Processcard_MouseClick, null, workoperation, revNr, prodtype, prodline, partid, partGroupID, isProcesscardOkToStart, isLatestRevNrSelected, latestRevNr);
            flp_Buttons.Controls.Add(btn);
            Height += btn.Height + 3;

            if (isOkCheckPartNumber && IsOperatorStartingOrder)
                SetForeColor_Label(btn, partid);
        }
        private void Add_Button_ProtocolTemplate(string? templatename, string? text, int id, string? workoperation = null, string? prodtype = null, string? prodline = null, int? partid = null, int? partGroupID = null, bool isProcesscardOkToStart = false, bool isOkCheckPartNumber = false)
        {
            totalLabels++;
            var btn = CreateButton(templatename, Button_ProtocolTemplate_MouseClick, id, workoperation, null, prodtype, prodline, partid, partGroupID, isProcesscardOkToStart);

            flp_Buttons.Controls.Add(btn);
            Height += btn.Height + 3;
        }
        private void Add_Button_Workoperations(string? workoperation, int workoperationID)
        {
            totalLabels++;
            var btn = CreateButton(workoperation, Button_Workoperation_MouseClick, workoperationID);

            flp_Buttons.Controls.Add(btn);
            Height += btn.Height + 3;
        }
        private void Add_Button_MeasureprotocolTemplate(string? measureProtocolTemplateName, string? revision, int id)
        {
            totalLabels++;
            var btn = CreateButton(measureProtocolTemplateName, Button_MeasureProtocolTemplate_MouseClick, id);
            btn.TemplateRevision = revision;

            flp_Buttons.Controls.Add(btn);
            Height += btn.Height + 3;
        }

        private void SetForeColor_Label(Button btn, int? partID)
        {
            if (btn.Text == $"{LanguageManager.GetString("chooseProcesscard_Info_1")} / ")
            {
                btn.ForeColor = CustomColors.Ok_Front;
                btn.BackColor = CustomColors.Ok_Back;
                return;
            }

            //Om Processkort under Framarbetning och mindre än tre ordrar körda
            if (IsDevelopmentOfProcessCard(partID) && Part.TotalOrders_PartID(partID) > 2)
            {
                // IsProcesscardOkStart[i] = true;
                btn.ForeColor = Color.DarkOrange;
                btn.BackColor = Color.Brown;
            }

            //Godkänd av QA eller under framtagning av Processkort och körd under 3 gånger
            else if (Processcard.IsApproved_By_QA(partID) || (IsDevelopmentOfProcessCard(partID) && Part.TotalOrders_PartID(partID) < 3))
            {
                // IsProcesscardOkStart[i] = true;
                btn.ForeColor = CustomColors.Ok_Front;
                btn.BackColor = CustomColors.Ok_Back;
            }
            //Ej godkänd av QA
            else
            {
                // IsProcesscardOkStart[i] = false;
                btn.ForeColor = CustomColors.Bad_Front;
                btn.BackColor = CustomColors.Bad_Back;
            }
            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Nothing)
            {
                // IsProcesscardOkStart[i] = true;
                btn.ForeColor = Color.Gray;
                btn.BackColor = Color.Transparent;
            }
        }
        private void SetFormHeight()
        {
            var totalHeight = 0;
            foreach (Control control in flp_Buttons.Controls)
            {
                totalHeight += control.Height;
                totalHeight += control.Margin.Bottom;
            }

            totalHeight += label_Header.Height + (tlp_InfoLabels.Visible ? tlp_InfoLabels.Height : 0) + flp_Buttons.Padding.Top + 41;

            this.Height = totalHeight;
        }

        private void Button_Processcard_MouseClick(object? sender, EventArgs e)
        {
            var lbl = sender as HeaderButton;

            if (Enum.TryParse(lbl?.Workoperation, out Manage_WorkOperation.WorkOperations workOperation))
                Order.WorkOperation = workOperation;

            Order.PartID = lbl?.PartID;
            Order.PartGroupID = lbl?.PartGroupID;
            Order.ProdType = lbl?.ProdType;
            Order.ProdLine = lbl?.ProdLine;
            Order.RevNr = lbl?.RevNr;

            if (lbl?.IsLatestRevNrSelected == false && IsOperatorStartingOrder)
                Mail.NotifyQAPartNumberNeedApproval(lbl.LatestRevNr);

            _ = Activity.Stop($"TemplateSelector: Valde Processkort {lbl?.Text}");
            IsAborted = false;
            IsOkClose = true;
            Close();
        }
        private void Button_MeasureProtocolTemplate_MouseClick(object? sender, EventArgs e)
        {
            var lbl = sender as HeaderButton;
            Templates_MeasureProtocol.MainTemplate.Name = lbl?.TemplateName;
            if (lbl != null)
            {
                Templates_MeasureProtocol.MainTemplate.ID = lbl.TemplateID;
                Templates_MeasureProtocol.MainTemplate.Revision = lbl.TemplateRevision;

                _ = Activity.Stop($"TemplateSelector: Valde Mätprotokoll {lbl.Text}");
            }

            IsAborted = false;
            IsOkClose = true;
            Close();
        }
        private void Button_ProtocolTemplate_MouseClick(object? sender, EventArgs e)
        {
            var lbl = sender as HeaderButton;
            Templates_Protocol.MainTemplate.Name = lbl?.TemplateName;
            if (lbl != null)
            {
                Templates_Protocol.MainTemplate.ID = lbl.TemplateID;
                if (Enum.TryParse(lbl.Workoperation, out Manage_WorkOperation.WorkOperations workOperation))
                    Order.WorkOperation = workOperation;

                _ = Activity.Stop($"TemplateSelector: Valde Protokoll-mall {lbl.Text}");
            }

            IsAborted = false;
            IsOkClose = true;
            Close();

        }
        private void Button_Workoperation_MouseClick(object? sender, EventArgs e)
        {
            var lbl = sender as HeaderButton;

            if (Enum.TryParse(lbl?.Workoperation, out Manage_WorkOperation.WorkOperations workOperation))
                Order.WorkOperation = workOperation;

            _ = Activity.Stop($"TemplateSelector: Valde Arbetsoperation {lbl?.Text}");
            IsOkClose = true;
            Close();
        }

        private void ChooseProcesscard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsOkClose && e.CloseReason == CloseReason.UserClosing)
            {
                IsAborted = true;
                return;
            }

            if (IsOkClose)
                return;

            Order.PartID = null;
            Order.RevNr = null;
            Order.OrderNumber = null;
            Order.Customer = null;
            Order.PartGroupID = null;
            Order.ProdType = null;
            Order.ProdLine = null;
            Order.PartNumber = null;
        }

        
    }
}
