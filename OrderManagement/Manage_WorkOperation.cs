using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.OrderManagement
{
    public partial class Manage_WorkOperation : Form
    {
        public class WorkOperation
        {
            public static List<string> Description
            {
                get
                {
                    var list = new List<string>();
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = @"SELECT Description FROM Workoperation.Names ORDER BY Description";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader["Description"].ToString());

                    return list;
                }
            }
        }


        public static bool IsProductionLineConnectedToWorkoperation(string? prodLinje)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT * FROM Workoperation.ProductionLines WHERE ProductionLine = @prodline";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@prodline", prodLinje);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                return reader.HasRows;
            return false;
        }
        public static bool IsWorkoperationUsing_Measurepoints
        {
            get
            {
                switch (Order.WorkOperation)
                {
                    case WorkOperations.Skärmning:
                    case WorkOperations.Svetsning:
                    case WorkOperations.Slipning:
                    case WorkOperations.Blandning_PTFE:
                        return false;
                    default:
                        return true;

                }
            }
        }
        private static List<string> List_WorkOperationsUsingSameProdLine(string? prodline)
        {
            var names = new List<string>();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT WorkoperationID, Name
                    FROM Workoperation.ProductionLines as prodlines
                    JOIN Workoperation.Names as names
	                    ON prodlines.WorkoperationID = names.ID
                    WHERE ProductionLine = @prodline";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            SQL_Parameter.String(cmd.Parameters, "@prodline", prodline);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                names.Add(reader["Name"].ToString());
            return names;
        }

        public enum WorkOperations
        {
            Nothing = 0,
            Blandning_PTFE = 1,
            Extrudering_FEP = 2,
            Extrudering_PTFE = 3,
            Extrudering_Grov_PTFE = 4,
            Extrudering_Termo = 5,
            Extrudering_Tryck = 6,
            Hackning_TEF = 7,
            Hackning_PUR_IV = 8,
            Hackning_PTFE = 9,          
            Kragning_TEF = 10,
            Kragning_PTFE = 11,
            Kragning_K22_PTFE = 12,
            Krympslangsblåsning = 13,
            HeatShrink = 14,
            Skärmning = 15,
            Slipning = 16,
            Spolning_PTFE = 17,
            Svetsning = 18,
            Synergy_PTFE_K18 = 19,
            Synergy_PTFE_K25 = 24,
            Bump_PTFE = 20,
            Slitting_PTFE = 21,
            Extrusion_HS = 22,
            Kragning_K20_TEF = 23,
            Tapering_Bump_PTFE_K28 = 24,
            Plockning_PTFE,
            Spetsformning_PTFE
        }
        public static List<string> List_Workoperations
        {
            get
            {
                var list = new List<string>();
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                const string query = @"SELECT Name FROM [Workoperation].Names ORDER BY Name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
            }
        }


        public Manage_WorkOperation()
        {
            InitializeComponent();
            Translate_Form();
            Fill_cb_Workoperation(cb_Workoperations);
        }



        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_Workoperation_Header, btn_Workoperation_Choose, btn_Workoperation_Abort});
        }

        public static void Fill_cb_Workoperation(ComboBox cb)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        SELECT Name 
                        FROM Workoperation.Names";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cb.Items.Add(reader[0].ToString());
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            Enum.TryParse(cb_Workoperations.Text, out Order.WorkOperation);

            Add();
            Close();
        }
        public static void Add()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    IF NOT EXISTS 
                        (SELECT ProductionLine FROM Workoperation.ProductionLines WHERE ProductionLine = @prodline)
                    INSERT INTO Workoperation.ProductionLines (ProductionLine, WorkoperationID)
                        VALUES (@prodline, @workoperationID)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@prodline", Order.ProdLine);
            cmd.Parameters.AddWithValue("@workoperationID", Order.WorkoperationID);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void Abort_Click(object sender, EventArgs e)
        {
            Close();
        }


        public static WorkOperations Load_WorkOperation(bool IsUserChooseArbOperation = true, int? orderID = null, int? partID = null, string? prodline = null)
        {
            //Kontrollerar först om Ordern finns sparad och Laddar rätt arbetsoperation
            if (orderID != null)
                return Load_WorkOperationWithOrderID(orderID);
            //Kontrollerar om det finns ett Processkort på PartNr och laddar WorkOperation
            if (partID == null)
                partID = Order.PartID;
            if (partID != null && partID != 0)
                return Load_WorkOperationPartID(partID);
            //Om Ordern ej finns tidigare laddas WorkOperation baserat på Prodlinje
            return Load_WorkOperationProdLine(IsUserChooseArbOperation, prodline);
        }
       
        public static string Workoperation(int? orderID)
        {
            if (orderID is null)
                return null;

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT Name FROM Workoperation.Names
                WHERE ID = (SELECT WorkoperationID FROM [Order].MainData WHERE OrderID = @orderid) AND ID IS NOT NULL";

            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderID);
            var value = cmd.ExecuteScalar();
            if (value != null)
                return value.ToString();

            return null;
        }

        private static WorkOperations Load_WorkOperationWithOrderID(int? orderID)
        {
            if (orderID is null)
                return WorkOperations.Nothing;

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT Name FROM Workoperation.Names
                    WHERE ID = (SELECT WorkoperationID FROM [Order].MainData WHERE OrderID = @orderid) AND ID IS NOT NULL";

            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderID);
            var value = cmd.ExecuteScalar();
            if (value != null)
                return (WorkOperations)Enum.Parse(typeof(WorkOperations), value.ToString());
            return WorkOperations.Nothing;
        }
        private static WorkOperations Load_WorkOperationPartID(int? partID)
        {
            //Kolla om ChooseProcesscard blir aktiverat nedanför någongång?
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                        SELECT DISTINCT Name 
                        FROM Workoperation.Names 
                        WHERE ID = (SELECT WorkoperationID FROM Processcard.MainData WHERE PartID = @partid) AND ID IS NOT NULL";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
            var reader = cmd.ExecuteReader();
            var ctr = 0;
            var WorkOperation = string.Empty;
            while (reader.Read())
            {
                WorkOperation = reader[0].ToString();
                ctr++;
            }

            return (WorkOperations)Enum.Parse(typeof(WorkOperations), WorkOperation);

        }
        public static WorkOperations Load_WorkOperationProdLine(bool IsUserChooseArbOperation, string? prodline)
        {
            if (string.IsNullOrEmpty(prodline))
                prodline = Order.ProdLine;
            var names = List_WorkOperationsUsingSameProdLine(prodline);
           
            if (names.Count > 1 && Order.OrderNumber != null && Order.WorkOperation == WorkOperations.Nothing)
            {
                //Om en produktionslinje tillhör flera arbetsoperationer får operatören nedan välja vilken arbetsoperation ordern hör till
                using  var chooseWorkoperation = new ProcesscardTemplateSelector(ProcesscardTemplateSelector.TemplateType.Workoperations);
                chooseWorkoperation.ShowDialog();

                //var chooseWorkoperation = new ChooseWorkoperation(names, null, ChooseWorkoperation.SourceType.Type_WorkOperation);
                //chooseWorkoperation.ShowDialog();
            }

            if (Order.WorkOperation != WorkOperations.Nothing)
                return Order.WorkOperation;

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Name FROM Workoperation.Names WHERE ID = (SELECT TOP(1) WorkoperationID FROM Workoperation.ProductionLines WHERE ProductionLine = @prodline) AND ID IS NOT NULL";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            if (string.IsNullOrEmpty(prodline))
                Part.Load_ProdLine();
            cmd.Parameters.AddWithValue("@prodline", prodline);
            if (string.IsNullOrEmpty(prodline))
                return WorkOperations.Nothing;

            Enum.TryParse((string)cmd.ExecuteScalar(), out WorkOperations workOperation);

            if (workOperation != WorkOperations.Nothing || IsProductionLineConnectedToWorkoperation(prodline))
                return workOperation;
            //Om Ordern ej finns tidigare laddas WorkOperation baserat på Prodlinje
            if (IsUserChooseArbOperation == false)
                return WorkOperations.Nothing;
            InfoText.Show($"{LanguageManager.GetString("workoperations_Info_1_1")} ({prodline}) {LanguageManager.GetString("workoperations_Info_1_2")}", CustomColors.InfoText_Color.Warning, "Warning!", null);
            using var WorkOperation = new Manage_WorkOperation();
            WorkOperation.ShowDialog();
            return Order.WorkOperation;
        }
    }
}
