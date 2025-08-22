using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.User;
using ProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.Templates
{
    public partial class Connect_Templates : Form
    {
        private void CheckDataExistInProtocolTemplate(int partID)
        {
            var dt = new DataTable();
            dt.Columns.Add("FormTemplate_Old");
            dt.Columns.Add("MachineIndex_Old");
            dt.Columns.Add("FormTemplate_New");
            dt.Columns.Add("MachineIndex_New");
            var oldTemplate = Templates_Protocol.MainTemplate.Old_MainTemplateID(partID);
            var newTemplate = Templates_Protocol.MainTemplate.ID;
            var list_TemplateID_ToCheckData = new List<int>();


            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                        SELECT FormTemplateID , MainTemplateID, MachineIndex, ModuleName
                        FROM Protocol.FormTemplate 
                        WHERE MainTemplateID IN (@oldtemplateid, @newtemplateid)
                        ORDER BY TemplateOrder, MachineIndex, MainTemplateID";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@oldtemplateid", oldTemplate);
                cmd.Parameters.AddWithValue("@newtemplateid", newTemplate);
                var reader = cmd.ExecuteReader();

                var dataTable = new DataTable();
                dataTable.Load(reader);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var currentModuleName = dataTable.Rows[i]["ModuleName"].ToString();
                    var isUnique = true;

                    // Check if the current ModuleName is unique in the DataTable
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        if (i != j && currentModuleName == dataTable.Rows[j]["ModuleName"].ToString())
                        {
                            isUnique = false;
                            break;
                        }
                    }

                    // Kontrollerar om någon rad saknas i någon modul i den nya mallen, och kontrollerar sedan om data finns i gamla processkorten
                    if (i < dataTable.Rows.Count - 1)
                    {
                        var nextModuleName = dataTable.Rows[i + 1]["ModuleName"].ToString();
                        int.TryParse(dataTable.Rows[i]["FormTemplateID"].ToString(), out var currentFormtemplateID);
                        int.TryParse(dataTable.Rows[i + 1]["FormTemplateID"].ToString(), out var nextFormtemplateID);
                        if (currentModuleName == nextModuleName)
                            AddTemplateID_List(currentFormtemplateID, nextFormtemplateID, ref list_TemplateID_ToCheckData);
                    }

                    // Om en modul helt tagits bort så kontrolleras här att det inte finns data i den modulen i gamla processkorten
                    if (isUnique)
                    {
                        int.TryParse(dataTable.Rows[i]["FormTemplateID"].ToString(), out var currentFormtemplateID);
                        AddTemplateID_List(currentFormtemplateID, 0, ref list_TemplateID_ToCheckData);
                    }
                }

            }


            var string_Templates = string.Join(",", list_TemplateID_ToCheckData);
            if (string.IsNullOrEmpty(string_Templates))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                string query = $@"
                            SELECT Value, TextValue, CodeText, PartNr, RevNr, ProdLine
                            FROM Processcard.Data as data
                            JOIN Processcard.MainData as maindata
                                ON data.PartID = maindata.PartID
	                        JOIN Protocol.Template as template
		                        ON data.TemplateID = template.ID
	                        JOIN Protocol.Description as description
		                        ON description.ID = template.ProtocolDescriptionID
                        WHERE data.PartID = @partid
                            AND TemplateID IN ({string_Templates})";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partid", partID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var textvalue = reader["TextValue"].ToString();
                    var value = reader["value"].ToString();
                    var codeText = reader["CodeText"].ToString();
                    var partnr = reader["PartNr"].ToString();
                    var revnr = reader["RevNr"].ToString();
                    var prodline = reader["ProdLine"].ToString();

                    if (double.TryParse(value, out _))
                    {
                        //if (string.IsNullOrEmpty(qa_Sign) == false)
                            message += $"PartNr: {partnr} / RevNr: {revnr} / ProdLinje: {prodline} - {codeText} - Value: {value}\n";
                            return;
                    }
                    if (string.IsNullOrEmpty(textvalue) == false)
                    {
                        message += $"PartNr: {partnr} / RevNr: {revnr} / ProdLinje: {prodline} - {codeText} - TextValue: {textvalue}\n";
                        return;
                    }
                }
            }
        }

        private string RevNr => ControlValidator.Next_Letter(LastRevNr, true);

        private string LastRevNr;
        private string PartNr;
        private string Workoperation;
        private string ExtraInfo;
        private string QA_Sign;
        private bool IsHistoricalData;
        private bool IsValidated;
        private bool IsDevelopmentOfProcesscard;
        private string ValidatedLots;

        public static DataTable dt_PartList;

        private bool IsOkFilterData;
        private bool IsAutoSelectPartNr { get; set; }
        internal static int MainTemplateID { get; set; }
        public static string TemplateName { get; set; }
        public static string TemplateRevision { get; set; }
        private readonly string NewTemplateRevision;
        private string? message;

        private void Load_Processcard_Data(int partID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            var query = @"
                    SELECT PartGroupID, ProdType, ProdLine, Extra_Info, RevInfo, QA_Sign, Historiska_Data, Validerat, Framtagning_Processfönster, Validerade_Loter
                    FROM Processcard.MainData
                    WHERE PartID = @partid";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partid", partID);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ExtraInfo = reader["Extra_Info"].ToString();
                QA_Sign = reader["QA_Sign"].ToString();
                if (int.TryParse(reader["PartGroupID"].ToString(), out var value))
                    Order.PartGroupID = value;
                Order.ProdLine = reader["ProdLine"].ToString();
                Order.ProdType = reader["ProdType"].ToString();
                bool.TryParse(reader["Historiska_Data"].ToString(), out IsHistoricalData);
                bool.TryParse(reader["Validerat"].ToString(), out IsValidated);
                bool.TryParse(reader["Framtagning_Processfönster"].ToString(), out IsDevelopmentOfProcesscard);
                ValidatedLots = reader["Validerade_Loter"].ToString();
            }
        }

        private List<SqlParameter> Parameters_Main
        {
            get
            {
                var Parameters = new List<SqlParameter>
                {
                    new SqlParameter("@revNr", RevNr),
                    new SqlParameter("@partnr", PartNr),
                    new SqlParameter("@maintemplateid", Templates_Protocol.MainTemplate.ID),
                    new SqlParameter("@workoperation", Workoperation),
                    new SqlParameter("@extraInfo", ExtraInfo),
                    new SqlParameter("@revÄndratDatum", DateTime.Now.ToString("yyyy-MM-dd")),
                    new SqlParameter("@upprättatAvSign", $"{Person.Sign}/{Person.EmployeeNr}"),
                    new SqlParameter("@revInfo", tb_RevInfo.Text),
                    new SqlParameter("@histData", IsHistoricalData),
                    new SqlParameter("@validerat", IsValidated),
                    new SqlParameter("@framtagning_Processfönster", IsDevelopmentOfProcesscard),
                    new SqlParameter("@validerade_Loter", ValidatedLots)

                };

                return Parameters;
            }
        }

        internal class Protocol
        {
            private static int Last_ProtocolMainTemplateID
            {
                get
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        con.Open();
                        var query = @"
                    SELECT TOP 1 ID
                    FROM 
                        (
                            SELECT ID, Revision, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum
                            FROM Protocol.MainTemplate
                            WHERE Name = @name AND Revision < @revision
                        )
                    AS SubQuery";

                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@name", TemplateName);
                        cmd.Parameters.AddWithValue("@revision", TemplateRevision);
                        var value = cmd.ExecuteScalar();
                        if (value != null)
                            return int.Parse(value.ToString());
                    }

                    return 0;
                }
            }
            private static bool IsAutoSelectPartNr { get; set; }
            public static void Load_ProtocolMainTemplateID(string templateName, string revision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = @"
                    SELECT ID FROM Protocol.MainTemplate WHERE Name = @name AND Revision = @revision";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@name", templateName);
                    cmd.Parameters.AddWithValue("@revision", revision);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        MainTemplateID = int.Parse(value.ToString());
                }
            }
            public static void Load_PartList(DataGridView dgv, bool IsAllRevisions)
            {
            
                dt_PartList = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = "";
                    if (IsAutoSelectPartNr)
                        query = Query_PartList_LatestTemplateRevision;
                    else
                        query = IsAllRevisions ? Query_PartList_AllRevisions : Query_PartList_LatestRevision;

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var da = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@new_maintemplateid", MainTemplateID);
                    if (IsAutoSelectPartNr)
                        cmd.Parameters.AddWithValue("@maintemplateid", Last_ProtocolMainTemplateID);
                    da.Fill(dt_PartList);
                    da.Dispose();
                }
                dgv.DataSource = dt_PartList;
                dgv.Columns["PartID"].Visible = false;

//                Filter_List();
            }
            internal static string Query_PartList_AllRevisions =>
            @"
                SELECT 
                    PartNr, 
                    maindata.PartID, 
                    RevNr, 
                    CASE
                        WHEN Framtagning_Processfönster = 1 THEN 'Framtagning Processfönster'
                        WHEN Historiska_Data = 1 THEN 'Historiska Data'
                        WHEN Validerat = 1 THEN 'Validerat processkort'
                        ELSE 'Unknown'
                    END AS Based_On,
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name as Workoperation,  
                    template.Name as TemplateName, 
                    maindata.MainTemplateID as ID, 
                    Revision as Revision,
                    MAX(data.MachineIndex) as TotalMachines
                FROM 
                Processcard.MainData as maindata
                JOIN Workoperation.Names as names ON maindata.WorkoperationID = names.ID
                    LEFT JOIN Protocol.MainTemplate as template ON template.ID = maindata.MainTemplateID
                    LEFT JOIN Processcard.Data as data ON maindata.PartID = data.PartID
                    WHERE Aktiv = 'True'
                GROUP BY 
                    maindata.MainTemplateID, 
                    PartNr, 
                    maindata.PartID, 
                    RevNr, 
                    Framtagning_Processfönster, 
                    Historiska_Data, 
                    Validerat, 
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name, 
                    template.Name,
                    MeasureProtocolMainTemplateID,
                    ProtocolTemplateRevision
                ORDER BY 
                    PartNr, RevNr;";
            internal static string Query_PartList_LatestRevision =>
                @"
                 WITH RankedData AS 
                (
                    SELECT 
                        PartNr, 
                        PartGroupID,
                        maindata.PartID,
                        RevNr, 
                        Framtagning_Processfönster,
                        Historiska_Data,
                        Validerat,
                        QA_Sign,
                        ProdLine, 
                        ProdType, 
                        names.Name as Workoperation, 
                        template.Name as TemplateName,
                        maindata.ProtocolMainTemplateID as ID,
                        Revision as Revision,
                        MAX(data.MachineIndex) OVER (PARTITION BY maindata.PartID) as TotalMachines,
                        ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) as rn
                    FROM 
                    Processcard.MainData as maindata
                        JOIN Workoperation.Names as names ON maindata.WorkoperationID = names.ID
                        JOIN Protocol.MainTemplate as template ON template.ID = maindata.ProtocolMainTemplateID
                        LEFT JOIN Processcard.Data as data ON maindata.PartID = data.PartID
                        WHERE Aktiv = 'True'
                )
                    SELECT 
                        PartNr, 
                        PartID, 
                        RevNr, 
                        CASE
                            WHEN Framtagning_Processfönster = 1 THEN 'Framtagning Processfönster'
                            WHEN Historiska_Data = 1 THEN 'Historiska Data'
                            WHEN Validerat = 1 THEN 'Validerat processkort'
                            ELSE 'Unknown'
                        END AS Based_On,
                        QA_Sign,
                        ProdLine, 
                        ProdType, 
                        Workoperation,
                        TemplateName, 
                        ID,
                        Revision,
                        TotalMachines
                    FROM  
                        RankedData 
                    WHERE 
                        rn = 1
                    ORDER BY 
                        PartNr, RevNr;";
            internal static string Query_PartList_LatestTemplateRevision =>
                @"
               
            WITH RankedData AS 
            (
                SELECT 
                    PartNr, 
                    PartGroupID,
                    PartID,
                    RevNr, 
                    Framtagning_Processfönster,
                    Historiska_Data,
                    Validerat,
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name as Workoperation, 
                    template.Name as TemplateName,
                    maindata.ProtocolMainTemplateID as ID,
                    Revision as Revision,
                    ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) as rn
                FROM Processcard.MainData as maindata
                JOIN Workoperation.Names as names
                    ON maindata.WorkoperationID = names.ID
                JOIN Protocol.MainTemplate as template
                    ON template.ID = maindata.ProtocolMainTemplateID
                WHERE Aktiv = 'True'
            )
            SELECT  
                PartNr, 
                PartID, 
                RevNr, 
                CASE
                    WHEN Framtagning_Processfönster = 1 THEN 'Framtagning Processfönster'
                    WHEN Historiska_Data = 1 THEN 'Historiska Data'
                    WHEN Validerat = 1 THEN 'Validerat processkort'
                    ELSE 'Unknown'
                END AS Based_On,
                QA_Sign,
                ProdLine, 
                ProdType, 
                Workoperation, 
                TemplateName,
                ID,
                Revision, 
            FROM RankedData 
            WHERE rn = 1
                AND ID = @maintemplateid
            ORDER BY PartNr, RevNr";
        }
        internal class MeasureProtocol
        {
            public static void Load_PartList(DataGridView dgv, bool IsAllRevisions)
            {
                dt_PartList = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = IsAllRevisions ? Query_PartList_AllRevisions : Query_PartList_LatestRevision;

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var da = new SqlDataAdapter(cmd);
                    //cmd.Parameters.AddWithValue("@new_maintemplateid", MainTemplateID);

                    da.Fill(dt_PartList);
                    da.Dispose();
                }
                dgv.DataSource = dt_PartList;
                dgv.Columns["PartID"].Visible = false;

                //Filter_List();
            }
            internal static string Query_PartList_AllRevisions =>
                @"
                SELECT 
                    PartNr, 
                    maindata.PartID, 
                    RevNr, 
                    CASE
                        WHEN Framtagning_Processfönster = 1 THEN 'Framtagning Processfönster'
                        WHEN Historiska_Data = 1 THEN 'Historiska Data'
                        WHEN Validerat = 1 THEN 'Validerat processkort'
                        ELSE 'Unknown'
                    END AS Based_On,
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name as Workoperation,  
                    template.Name as TemplateName, 
                    maindata.MeasureProtocolMainTemplateID as ID, 
                    template.Revision as Revision,
                    MAX(data.MachineIndex) as TotalMachines
                FROM 
                Processcard.MainData as maindata
                JOIN Workoperation.Names as names ON maindata.WorkoperationID = names.ID
                    LEFT JOIN MeasureProtocol.MainTemplate as template ON template.MeasureProtocolMainTemplateID = maindata.MeasureProtocolMainTemplateID
                    LEFT JOIN Processcard.Data as data ON maindata.PartID = data.PartID
                    WHERE Aktiv = 'True'
                GROUP BY 
                    maindata.MeasureProtocolMainTemplateID, 
                    PartNr, 
                    maindata.PartID, 
                    RevNr, 
                    Framtagning_Processfönster, 
                    Historiska_Data, 
                    Validerat, 
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name, 
                    template.Name,
                    ID,
                    Revision
                ORDER BY 
                    PartNr, RevNr;";
            internal static string Query_PartList_LatestRevision =>
                @"
                 WITH RankedData AS 
                (
                    SELECT 
                        PartNr, 
                        PartGroupID,
                        maindata.PartID,
                        RevNr, 
                        ProdLine, 
                        ProdType,
                        names.Name as Workoperation, 
                        template.Name as TemplateName,
                        maindata.MeasureProtocolMainTemplateID as ID,
                        template.Revision as Revision,
                        MAX(data.MachineIndex) OVER (PARTITION BY maindata.PartID) as TotalMachines,
                        ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) as rn
                    FROM 
                    Processcard.MainData as maindata
                        LEFT JOIN Workoperation.Names as names ON maindata.WorkoperationID = names.ID
                        LEFT JOIN MeasureProtocol.MainTemplate as template ON template.MeasureProtocolMainTemplateID = maindata.MeasureProtocolMainTemplateID
                        LEFT JOIN Processcard.Data as data ON maindata.PartID = data.PartID
                        WHERE Aktiv = 'True'
                )
                    SELECT 
                        PartNr, 
                        PartID, 
                        RevNr, 
                        ProdLine, 
                        ProdType, 
                        Workoperation,
                        TemplateName, 
                        ID,
                        Revision,
                        TotalMachines
                    FROM  
                        RankedData 
                    WHERE 
                        rn = 1
                    ORDER BY 
                        PartNr, RevNr;";
            
        }

        //LineClearance kopplas i nuläget inte till processkort men sparar koden ifall det behöver kopplas dit.
        //Nu kopplas den automatiskt till senaste RevNr när operatör startar ordern.
        internal class LineClearance
        {
            public static void Load_PartList(DataGridView dgv, bool IsAllRevisions)
            {
                dt_PartList = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = IsAllRevisions ? Query_PartList_AllRevisions : Query_PartList_LatestRevision;

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt_PartList);
                    da.Dispose();
                }
                dgv.DataSource = dt_PartList;
                dgv.Columns["PartID"].Visible = false;

            }
            internal static string Query_PartList_AllRevisions =>
                @"
                SELECT 
                    PartNr, 
                    maindata.PartID, 
                    RevNr, 
                    CASE
                        WHEN Framtagning_Processfönster = 1 THEN 'Framtagning Processfönster'
                        WHEN Historiska_Data = 1 THEN 'Historiska Data'
                        WHEN Validerat = 1 THEN 'Validerat processkort'
                        ELSE 'Unknown'
                    END AS Based_On,
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name as Workoperation,  
                    template.ProtocolTemplateName as TemplateName, 
                    maindata.LineClearanceMainTemplateID as ID, 
                    template.LineClearance_Revision as Revision,
                    MAX(data.MachineIndex) as TotalMachines
                FROM 
                Processcard.MainData as maindata
                JOIN Workoperation.Names as names ON maindata.WorkoperationID = names.ID
                    LEFT JOIN LineClearance.MainTemplate as template ON template.MainTemplateID = maindata.LineClearanceMainTemplateID
                    LEFT JOIN Processcard.Data as data ON maindata.PartID = data.PartID
                    WHERE Aktiv = 'True'
                GROUP BY 
                    maindata.LineClearanceMainTemplateID, 
                    PartNr, 
                    maindata.PartID, 
                    RevNr, 
                    Framtagning_Processfönster, 
                    Historiska_Data, 
                    Validerat, 
                    QA_Sign,
                    ProdLine, 
                    ProdType, 
                    names.Name, 
                    template.ProtocolTemplateName,
                    ID,
                    LineClearance_Revision
                ORDER BY 
                    PartNr, RevNr;";
            internal static string Query_PartList_LatestRevision =>
                @"
                 WITH RankedData AS 
                (
                    SELECT 
                        PartNr, 
                        PartGroupID,
                        maindata.PartID,
                        RevNr, 
                        ProdLine, 
                        ProdType,
                        names.Name as Workoperation, 
                        template.ProtocolTemplateName as TemplateName,
                        maindata.LineClearanceMainTemplateID as ID,
                        template.LineClearance_Revision as Revision,
                        MAX(data.MachineIndex) OVER (PARTITION BY maindata.PartID) as TotalMachines,
                        ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) as rn
                    FROM 
                    Processcard.MainData as maindata
                        LEFT JOIN Workoperation.Names as names ON maindata.WorkoperationID = names.ID
                        LEFT JOIN LineClearance.MainTemplate as template ON template.MainTemplateID = maindata.LineClearanceMainTemplateID
                        LEFT JOIN Processcard.Data as data ON maindata.PartID = data.PartID
                        WHERE Aktiv = 'True'
                )
                    SELECT 
                        PartNr, 
                        PartID, 
                        RevNr, 
                        ProdLine, 
                        ProdType, 
                        Workoperation,
                        TemplateName, 
                        ID,
                        Revision,
                        TotalMachines
                    FROM  
                        RankedData 
                    WHERE 
                        rn = 1
                    ORDER BY 
                        PartNr, RevNr;";
        }
        


        public enum SourceType
        {
            Type_Protocols,
            Type_MeasureProtocols,
            Type_LineClearance
        }

        public Connect_Templates(string mainTemplateName, string newTemplateRevision, bool isAutoSelectPartNr, SourceType source)
        {
            InitializeComponent();
            TemplateName = mainTemplateName;
            TemplateRevision = newTemplateRevision;
            NewTemplateRevision = newTemplateRevision;
            IsAutoSelectPartNr = isAutoSelectPartNr;
            switch (source)
            {
                case SourceType.Type_Protocols:
                    Protocol.Load_ProtocolMainTemplateID(mainTemplateName, newTemplateRevision);
                    Protocol.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
                    btn_ConnectMeasureTemplate.Visible = false;
                    break;
                case SourceType.Type_MeasureProtocols:
                    MeasureProtocol.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
                    btn_CreateNewRevisionProcesscard.Visible = btn_UpdateExistingRevisionProcesscard.Visible = label_Processkort_Godkänt_RevInfo.Visible = tb_RevInfo.Visible = false;
                    break;
                case SourceType.Type_LineClearance:

                    btn_CreateNewRevisionProcesscard.Visible = btn_UpdateExistingRevisionProcesscard.Visible = label_Processkort_Godkänt_RevInfo.Visible = tb_RevInfo.Visible = false;
                    LineClearance.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
                    break;
            }
            Filter_List();

        }
        private void PartTemplateManager_Load(object sender, EventArgs e)
        {
            //Load_PartList_Protocols();
            IsOkFilterData = true;
        }
        private void PartTemplateManager_Shown(object sender, EventArgs e)
        {
            if (IsAutoSelectPartNr)
                dgv_PartList.SelectAll();
        }


       
        
        

        private void Filter_Changed(object sender, EventArgs e)
        {
            Filter_List();
        }
        private void Filter_List()
        {
            if (IsOkFilterData == false)
                return;
            var filterCondition = new StringBuilder();

            if (!string.IsNullOrEmpty(tb_PartNumber.Text))
                filterCondition.Append($"[PartNr] {(chb_Invert_PartNr.Checked ? "NOT LIKE" : "LIKE")} '%{tb_PartNumber.Text}%' ");
            if (!string.IsNullOrEmpty(tb_TemplateName.Text))
            {
                if (filterCondition.Length > 0) filterCondition.Append("AND ");
                filterCondition.Append($"[TemplateName] {(chb_Invert_TemplateName.Checked ? "NOT LIKE" : "LIKE")} '%{tb_TemplateName.Text}%' ");
            }

            if (!string.IsNullOrEmpty(tb_Workoperation.Text))
            {
                if (filterCondition.Length > 0) filterCondition.Append("AND ");
                filterCondition.Append($"[Workoperation] {(chb_Invert_Workoperation.Checked ? "NOT LIKE" : "LIKE")} '%{tb_Workoperation.Text}%' ");
            }

            if (!string.IsNullOrEmpty(tb_ProdType.Text))
            {
                if (filterCondition.Length > 0) filterCondition.Append("AND ");
                filterCondition.Append($"[ProdType] {(chb_Invert_ProdType.Checked ? "NOT LIKE" : "LIKE")} '%{tb_ProdType.Text}%' ");

            }

            if (!string.IsNullOrEmpty(tb_ProdLine.Text))
            {
                if (filterCondition.Length > 0) filterCondition.Append("AND ");
                filterCondition.Append($"[ProdLine] {(chb_Invert_ProdLine.Checked ? "NOT LIKE" : "LIKE")} '%{tb_ProdLine.Text}%' ");
            }
            if (!string.IsNullOrEmpty(tb_Revision.Text))
            {
                if (filterCondition.Length > 0) filterCondition.Append("AND ");
                filterCondition.Append($"[Revision] {(chb_Invert_Revision.Checked ? "NOT LIKE" : "LIKE")} '%{tb_Revision.Text}%' ");
            }

            if (num_Machines.Value > 0)
            {
                if (filterCondition.Length > 0) filterCondition.Append("AND ");
                filterCondition.Append($"[TotalMachines] = '{num_Machines.Value}'");
            }

            dt_PartList.DefaultView.RowFilter = filterCondition.ToString();
            
        }
        private void Filter_ClearText_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            switch (control.Name)
            {
                case "label_PartNumber":
                    tb_PartNumber.Text = string.Empty;
                    break;
                case "label_Workoperation":
                    tb_Workoperation.Text = string.Empty;
                    break;
                case "label_TemplateName":
                    tb_TemplateName.Text = string.Empty;
                    break;
                case "label_ProdType":
                    tb_ProdType.Text = string.Empty;
                    break;
                case "label_ProdLine":
                    tb_ProdLine.Text = string.Empty;
                    break;
                case "label_Machines":
                    num_Machines.Value = 0;
                    break;
            }
            
        }
        private void PartList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lbl_ActiveRow.Text = $"{e.RowIndex + 1}";
        }
        private void PartList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lbl_TotalRows.Text = dgv_PartList.Rows.Count.ToString();
        }
        private void PartList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lbl_TotalRows.Text = dgv_PartList.Rows.Count.ToString();
        }

        private void ShowRevNr_CheckedChanged(object sender, EventArgs e)
        {
            Protocol.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
        }

        private void Set_MeasureProtocolTemplateName(int partID)
        {
            //Behövs för att få MeasureProtocolTemplateID när Processkort MainData skall sparas
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT Name FROM MeasureProtocol.MainTemplate WHERE MeasureProtocolMainTemplateID = (SELECT MeasureProtocolMainTemplateID FROM Processcard.MainData WHERE PartID = @partid)";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partid", partID);
                con.Open();
                var value = cmd.ExecuteScalar();
                
                Templates_MeasureProtocol.MainTemplate.Name = value.ToString();
            }

        }
        private void CreateNewRevisionProcesscard(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_RevInfo.Text))
            {
                InfoText.Show("Du måste fylla i RevisionsInfo före du kopplar den nya mallen till processkort.", CustomColors.InfoText_Color.Warning, "Warning",this);
                return;
            }
            double percent = 0;
            double step_Value = 100f / dgv_PartList.SelectedRows.Count;
            var pbar = new ProgressBar();
            pbar.Show();

            message = "Dessa artiklar är godkända av QA och har data i ett eller flera fält som du har tagit bort: De kommer att krävas ett nytt godkännande av QA.\n\n";
            var list_PartNumbers = new List<string>();
           
            foreach (DataGridViewRow row in dgv_PartList.SelectedRows)
            {
                var partID = int.Parse(row.Cells["PartID"].Value.ToString());
                pbar.Set_ValueProgressBar(percent, $"Kontrollerar data: ArtikelNr: {PartNr}");
                percent += step_Value;
                //Kontrollerar att den nya mallen inte är samma mall som tidigare
                //Bör kunna tas bort, för dessa mallar skall inte finnas med i listan ens
                if (Templates_Protocol.MainTemplate.Old_MainTemplateID(partID) != Templates_Protocol.MainTemplate.ID)
                {
                    var newPartID = (int)Part.Get_NewPartID;
                    var IsOK = true;
                    PartNr = row.Cells["PartNr"].Value.ToString();
                   // pbar.Set_ValueProgressBar(percent, $"Uppdaterar Mall för Artikelnr #{PartNr}");
                   // percent += step_Value;

                    LastRevNr = row.Cells["RevNr"].Value.ToString();
                    Workoperation = row.Cells["Workoperation"].Value.ToString();
                    Load_Processcard_Data(partID);

                    Set_MeasureProtocolTemplateName(partID);
                    Processcard.Save.Save_MainData(ref IsOK, newPartID, Parameters_Main);
                    Update_Processcard.Update_ProcesscardWithNewTemplate(partID, newPartID, Templates_Protocol.MainTemplate.Old_MainTemplateID(partID), MainTemplateID, NewTemplateRevision);

                    //if (Is_DataExistInProtocolTemplate(partID, qa_Sign))
                    //{
                   // list_PartNumbers.Add(row.Cells["PartNr"].Value.ToString());
                    //    list_PartID.Add((int)row.Cells["PartID"].Value);
                    //}
                    //else
                    
                    //Om Person == SuperAdmin så kopieras tidigare QA-signering till nya revisionen, annars lämnas den tom
                    if (Person.Role == "SuperAdmin" &! string.IsNullOrEmpty(QA_Sign))
                        ProcesscardBasedOn.ApproveProcesscard(QA_Sign, DateTime.Now, newPartID, false);
                    else if (!string.IsNullOrEmpty(QA_Sign))
                    {
                        message += $"{PartNr}\n";
                        list_PartNumbers.Add(PartNr);
                    }
                        
                }
                else
                {
                    MessageBox.Show("Kolla varför detta meddelande kommer upp\nDet står längre upp attt if-kontroller bör kunna tas bort");
                }
            }

            if (list_PartNumbers.Count > 0)
            {
               // if (message.Contains("PartNr:"))
                    InfoText.Show(message, CustomColors.InfoText_Color.Warning, "Warning!", this);
            }

            pbar.Close();  

            Protocol.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
            Filter_List();
        }
        private void UpdateExistingRevisionProcesscard(object sender, EventArgs e)
        {
            double percent = 0;
            double step_Value = 100f / dgv_PartList.SelectedRows.Count;
            var pbar = new ProgressBar();
            pbar.Show();
          
            foreach (DataGridViewRow row in dgv_PartList.SelectedRows)
            {
                var partID = int.Parse(row.Cells["PartID"].Value.ToString());
                PartNr = row.Cells["PartNr"].Value.ToString();
                var oldMainTemplatID = int.Parse(row.Cells["ID"].Value.ToString());

                pbar.Set_ValueProgressBar(percent, $"Uppdaterar Mall för Artikelnr #{PartNr}");
                percent += step_Value;
               
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    UPDATE Processcard.MainData 
                    SET ProtocolMainTemplateID = @maintemplateid, ProtocolTemplateRevision = @protocoltemplaterevision

                    WHERE PartID = @partID";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@protocoltemplaterevision", NewTemplateRevision);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Update_Processcard.Update_ProcesscardWithNewTemplate(partID, partID, oldMainTemplatID, MainTemplateID, NewTemplateRevision);
            }

            pbar.Close();

            Protocol.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
        }
        private void ConnectMeasureTemplate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_PartList.SelectedRows)
            {
                var partID = int.Parse(row.Cells["PartID"].Value.ToString());

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    UPDATE Processcard.MainData 
                    SET MeasureProtocolMainTemplateID = @maintemplateid

                    WHERE PartID = @partID";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MeasureProtocol.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
            Filter_List();
        }
        private void ConnectLineClearanceTemplate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_PartList.SelectedRows)
            {
                var partID = int.Parse(row.Cells["PartID"].Value.ToString());

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    UPDATE Processcard.MainData 
                    SET LineClearanceMainTemplateID = @maintemplateid

                    WHERE PartID = @partID";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LineClearance.Load_PartList(dgv_PartList, chb_ShowRevNr.Checked);
            Filter_List();
        }
        private void CompareDataInTemplates_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_PartList.SelectedRows)
            {
                var partID = int.Parse(row.Cells["PartID"].Value.ToString());
                CheckDataExistInProtocolTemplate(partID);
            }
            InfoText.Show(message, CustomColors.InfoText_Color.Info, "Info");
        }

        private void AddTemplateID_List(int FormtemplateID_Old, int FormTemplateID_New, ref List<int> list)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                        WITH UniqueCodeText AS (
                            SELECT description.CodeText
                            FROM Protocol.Template as template
                                JOIN Protocol.Description as description
                                    ON template.ProtocolDescriptionID = description.ID
                                WHERE template.FormTemplateID IN (@oldformtemplateid, @newformtemplateid)
                            GROUP BY description.CodeText
                        HAVING COUNT(DISTINCT template.FormTemplateID) = 1
                        )
                            SELECT template.ID, description.CodeText
                            FROM Protocol.Template as template
                                JOIN Protocol.Description as description
                                    ON template.ProtocolDescriptionID = description.ID
                            WHERE template.ID IN (SELECT ID FROM Protocol.Template WHERE FormTemplateID IN (@oldformtemplateid, @newformtemplateid))
                                AND description.CodeText IN (SELECT CodeText FROM UniqueCodeText)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();


                cmd.Parameters.AddWithValue("@oldformtemplateid", FormtemplateID_Old);
                cmd.Parameters.AddWithValue("@newformtemplateid", FormTemplateID_New);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(int.Parse(reader[0].ToString()));
            }
        }
        private void Update_MainTemplateID_Processcard(int partid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"
                    UPDATE Processcard.MainData
                    SET MainTemplateID = @new_maintemplateid, ProtocolTemplateRevision = @new_revision
                    WHERE PartID = @partid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partid", partid);
                cmd.Parameters.AddWithValue("@new_maintemplateid", MainTemplateID);
                cmd.Parameters.AddWithValue("@new_revision", NewTemplateRevision);
                cmd.ExecuteNonQuery();
            }
        }

        public class Update_Processcard
        {
            private static List<int> Old_FormTemplateIDs { get; set; }

            private static int NewProtocolTemplateID(int oldTemplateID, int machineIndex, int newMainTemplateID, string newTemplateRevision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT ID 
                    FROM Protocol.Template 
                    WHERE FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @newmaintemplateid AND MachineIndex = @machineindex)
                        AND ProtocolDescriptionID = (SELECT ProtocolDescriptionID FROM Protocol.Template WHERE ID = @oldtemplateid)
                        AND (ColumnIndex = (SELECT ColumnIndex FROM Protocol.Template WHERE ID = @oldtemplateid) OR ColumnIndex IS NULL)
                        AND Revision = @newrevision";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@newmaintemplateid", newMainTemplateID);
                    cmd.Parameters.AddWithValue("@machineindex", machineIndex);
                    cmd.Parameters.AddWithValue("@oldtemplateid", oldTemplateID);
                    cmd.Parameters.AddWithValue("@newrevision", newTemplateRevision);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        return (int)value;
                }

                return 0;
            }
            private static void Load_OldFormTemplateIDs(int mainTemplateID)
            {
                Old_FormTemplateIDs = new List<int>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@maintemplateid", mainTemplateID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        Old_FormTemplateIDs.Add(int.Parse(reader["FormTemplateID"].ToString()));
                }
            }
            public static void Update_ProcesscardWithNewTemplate(int oldPartID, int newPartID, int oldMainTemplateID, int newMainTemplateID, string newTemplateRevision)
            {
                ///Hämtar processkorsdata från Processcard.Data och kopierar alla rader med nytt TemplateID (Kopplat till den nya mallen)

                Load_OldFormTemplateIDs(oldMainTemplateID);

                foreach (var FormTemplateID in Old_FormTemplateIDs)
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        const string query = @"
                        SELECT * FROM Processcard.Data WHERE PartID = @partID AND TemplateID IN (SELECT ID FROM Protocol.Template WHERE FormTemplateID = @oldformtemplateid) ORDER BY TemplateID";
                        con.Open();
                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@partID", oldPartID);
                        cmd.Parameters.AddWithValue("@oldformtemplateid", FormTemplateID);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var oldTemplateID = int.Parse(reader["TemplateID"].ToString());
                            int oldMachineIndex;
                            if (int.TryParse(reader["MachineIndex"].ToString(), out var machineindex) == false)
                            {
                                oldMachineIndex = 0;
                                machineindex = 1;
                            }
                            else
                                oldMachineIndex = machineindex;
                            var newTemplateID = NewProtocolTemplateID(oldTemplateID, machineindex, newMainTemplateID, newTemplateRevision);
                            if (newTemplateID != 0)
                                SaveProcesscardData(newPartID, oldPartID, machineindex, oldMachineIndex, oldTemplateID, newTemplateID);

                        }
                    }
                }
            }

            private static void SaveProcesscardData(int newPartID, int oldPartID, int machineindex, int oldMachineIndex, int oldTemplateID, int newTemplateID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                   IF NOT EXISTS (SELECT * FROM Processcard.Data WHERE PartID = @newpartID AND TemplateID = @newtemplateid AND (MachineIndex = @machineindex OR COALESCE(@machineindex, '') = ''))
                        INSERT INTO Processcard.Data (PartID, TemplateID, MachineIndex, Value, TextValue, Type)
                        VALUES (@newpartID, @newtemplateid, @machineindex,
                            (SELECT Value FROM Processcard.Data WHERE PartID = @oldpartID AND TemplateID = @oldtemplateid AND (MachineIndex = @oldmachineindex OR COALESCE(@oldmachineindex, '') = '')),
                            (SELECT TextValue FROM Processcard.Data WHERE PartID = @oldpartID AND TemplateID = @oldtemplateid AND (MachineIndex = @oldmachineindex OR COALESCE(@oldmachineindex, '') = '')),
                            (SELECT Type FROM Processcard.Data WHERE PartID = @oldpartID AND TemplateID = @oldtemplateid AND (MachineIndex = @oldmachineindex OR COALESCE(@oldmachineindex, '') = '')))";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@newpartID", newPartID);
                    cmd.Parameters.AddWithValue("@oldpartID", oldPartID);
                    if (oldMachineIndex == 0)
                        cmd.Parameters.AddWithValue("@oldmachineindex", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@oldmachineindex", oldMachineIndex);


                    if (machineindex == 0)
                        cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@machineindex", machineindex);
                    cmd.Parameters.AddWithValue("@oldtemplateid", oldTemplateID);
                    cmd.Parameters.AddWithValue("@newtemplateid", newTemplateID);
                    var test = cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
