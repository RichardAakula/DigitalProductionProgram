using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Templates;
using static DigitalProductionProgram.OrderManagement.Manage_WorkOperation;

namespace DigitalProductionProgram.Processcards
{
    public class Processcard
    {
        public readonly Module module;
      
        public Processcard(Module parentModule)
        {
            module = parentModule;
           
        }

        

        public static readonly List<int> Rows_double = new List<int>();
        public static readonly List<int> Rows_int = new List<int>();
        public static readonly List<int> Rows_string = new List<int>();

        public static bool IsNotUsingProcesscard(WorkOperations workoperation)
        {
            switch (workoperation)
            {
                case WorkOperations.Hackning_TEF:
                case WorkOperations.Blandning_PTFE:
                case WorkOperations.Spolning_PTFE:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsMultipleProcesscard(WorkOperations workoperation, string? partNr = null)
        {
            if (partNr is null)
                partNr = Order.PartNumber;
            if (partNr is null)
                return false;
            var ctr = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT DISTINCT ProdLine, ProdType FROM Processcard.MainData WHERE PartNr = @partnr AND WorkoperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) AND Aktiv = 'True'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partnr", partNr);
                cmd.Parameters.AddWithValue("@workoperation", workoperation.ToString());
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    ctr++;
            }
            return ctr > 1;
        }
        public static bool IsPartNrExist
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT * FROM Processcard.MainData WHERE PartNr = @partnr";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return true;
                return false;
            }
        }
        public static bool IsApproved_By_QA(int? partID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT QA_sign FROM Processcard.MainData WHERE PartID = @partid";
            string qa_Sign = null;

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partid", partID);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value != null)
                qa_Sign = value.ToString();
            if (string.IsNullOrEmpty(qa_Sign))
                return false;
            return true;
        }
        public static bool IsUnderConstruction
        {
            get
            {
                if (Order.PartID is null)
                    return true;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Framtagning_Processfönster FROM Processcard.MainData WHERE PartID = @partid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", Order.PartID);
                    var value = cmd.ExecuteScalar();
                    return !bool.TryParse(value.ToString(), out var isunderconstruction) || isunderconstruction;
                }
            }
        }

        public static List<int> List_UsedColumnsProcesscard(int row, int formtemplateid)
        {
            var list = new List<int>();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        SELECT ColumnIndex FROM Protocol.Template as template
                            JOIN Protocol.Description as descr
                                ON descr.id = template.ProtocolDescriptionID
                        WHERE FormTemplateID = @formtemplateid
                        AND RowIndex = @row ";
            //AND revision = @revision";    //Denna bör gå att vara utan vid nya versionen med Flexibla Protokoll
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
            cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
            cmd.Parameters.AddWithValue("@row", row);
            //cmd.Parameters.AddWithValue("@revision", Active_Processcard_Revision(formtemplateid));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (int.TryParse(reader["ColumnIndex"].ToString(), out var col))
                    list.Add(col);
            }

            return list;
        }
        
        public static string Latest_Processcard_Revision(int formtemplateid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT TOP(1) revision 
                    FROM Protocol.Template 	                    
                    WHERE FormTemplateID = @formtemplateid
                    ORDER BY revision DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();
            }
            return null;
        }

        public static string Format_Value(double value, int decimals)
        {
            switch (decimals)
            {
                default:
                    return $"{value:0}";
                case 1:
                    return $"{value:0.0}";
                case 2:
                    return $"{value:0.00}";
                case 3:
                    return $"{value:0.000}";
            }
        }

        public static int? TemplateID(int row, int col, int formtemplateid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ID FROM Protocol.Template 
                    WHERE FormTemplateID = @formtemplateid
                        AND ColumnIndex = @colIndex 
                        AND RowIndex = @rowIndex 
                        AND Revision = @revision";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@colIndex", col);
                cmd.Parameters.AddWithValue("@rowIndex", row);
                
                con.Open();
                var value = cmd.ExecuteScalar();
                return (int?)value;
            }
        }
        public static int ValueType(int? templ_ID)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT type FROM Protocol.Template
                    WHERE ID = @id";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", templ_ID);
                con.Open();
                var value = cmd.ExecuteScalar();
                return int.Parse(value.ToString());
            }
        }

        
        public static void Load_Data(DataGridView dgv_Processkort, int formtemplateid, bool IsMultipleExtruder = false)
        {
            var Cell_Min = 2;
            if (IsMultipleExtruder)
                Cell_Min = 5;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                    FROM Protocol.Template AS template
                        JOIN Processcard.Data AS pc_data
	                        ON pc_data.TemplateID = template.Id
                        JOIN Protocol.Description AS descr
	                        ON descr.Id = template.ProtocolDescriptionID
                    WHERE pc_data.PartID = @partID
                    AND template.revision = @revision
                    AND template.FormTemplateID = @formtemplateid
                    AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))
                    ORDER BY RowIndex, ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                if (IsMultipleExtruder)
                    cmd.Parameters.AddWithValue("@machineindex", 2);
                else
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
                    int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0://NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);

                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }
                    dgv_Processkort.Rows[row].Cells[Cell_Min + col].Value = value;
                }
            }
        }
        public static string Load_Data(int? partid, string codetext, int formtemplateid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT DISTINCT Value, CodeText, TextValue, descr.Decimals, descr.Type
                    FROM Processcard.Data as processcard
                        JOIN Protocol.Template as template
                            ON processcard.TemplateID = template.ID
                        JOIN Protocol.Description as descr
                            ON descr.ID = template.ProtocolDescriptionID
                        WHERE processcard.PartID = @partid
                            AND MachineIndex = 1
                            AND CodeText = @codetext
                            AND Revision = @revision";
                con.Open();
                var cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partid);
                cmd.Parameters.AddWithValue("@codetext", codetext);
                //cmd.Parameters.AddWithValue("@revision", Active_Processcard_Revision(formtemplateid));
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0: //NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";

                    return value;
                }
            }
            return null;
        }

        public static void Update_Status_Processcard(TextBox tb_PartNr, Button lbl_Aktivera_Inaktivera_ArtikelNr)
        {
            if (string.IsNullOrEmpty(tb_PartNr.Text))
            {
                InfoText.Show("Välj först ett artikelnr före du försöker Aktivera/Inaktivera ett Processkort.", CustomColors.InfoText_Color.Bad, null);
                return;
            }
            bool flag;
            if (lbl_Aktivera_Inaktivera_ArtikelNr.Text == LanguageManager.GetString("deactivatePartNr"))
            {
                InfoText.Question("Är du säker på att du vill inaktivera detta Processkort?\n" +
                              "Alla Revisionsnummer till detta artikelnr kommer nu att bli inaktiva.", CustomColors.InfoText_Color.Info, "Inaktivera Processkort", tb_PartNr.Parent);    //testa parent
                flag = false;
            }
            else
            {
                InfoText.Question("Är du säker på att du vill aktivera detta Processkort?\n" +
                              "Alla Revisionsnummer till detta artikelnr kommer nu att bli aktiva.", CustomColors.InfoText_Color.Info, "Aktivera Processkort", tb_PartNr.Parent);
                flag = true;
            }
            if (InfoText.answer == InfoText.Answer.No)
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"UPDATE Processcard.MainData SET Aktiv = @flag WHERE PartGroupID = @partgroupid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@flag", flag);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partgroupid", Order.PartGroupID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteProcesscard(int? partID)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var IsNoArtikelID = false;
                var query = @"
                    BEGIN TRANSACTION
                        DELETE FROM Processcard.MainData WHERE PartID = @partID ";
                switch (Order.WorkOperation)
                {
                    //IsNoArtikelID används tillfälligt medan Processkortstabellen i databasen byggs om
                    // Nedanstående arbetsoperationer har flyttat processkortsdatan till nya gemensamma tabellen
                    case WorkOperations.Bump_PTFE:
                    case WorkOperations.Extrudering_FEP:
                    case WorkOperations.Extrudering_PTFE:
                    case WorkOperations.Extrudering_Grov_PTFE:
                    case WorkOperations.Extrudering_Termo:
                    case WorkOperations.Extrudering_Tryck:
                    case WorkOperations.Extrusion_HS:
                    case WorkOperations.Hackning_PTFE:
                    case WorkOperations.Kragning_PTFE:
                    case WorkOperations.Kragning_K22_PTFE:
                    case WorkOperations.Kragning_TEF:
                    case WorkOperations.Krympslangsblåsning:
                    
                    case WorkOperations.HeatShrink:
                    case WorkOperations.Skärmning:
                    case WorkOperations.Synergy_PTFE:
                    case WorkOperations.Slitting_PTFE:
                    
                        IsNoArtikelID = true;
                        break;
                    case WorkOperations.Slipning:
                        query += "DELETE FROM Processkort_Slipning";
                        break;
                    case WorkOperations.Svetsning:
                        query += "DELETE FROM Processkort_Svetsning";
                        break;
                }

                if (IsNoArtikelID == false)
                    query += " WHERE PartID = @partID ";
                query += "\n" +
                         "DELETE FROM Processcard.Data WHERE PartID = @partID ";
                query += "\n" +
                         "COMMIT TRANSACTION";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partID", partID);
                cmd.ExecuteNonQuery();
            }
        }
        
        private static void Add_Parameters(SqlCommand cmd, List<SqlParameter> parameters, int partID)
        {
            cmd.Parameters.AddRange(parameters.ToArray());

            SQL_Parameter.NullableINT(cmd.Parameters, "@artID", partID);
            cmd.Parameters.AddWithValue("@partgroupid", Order.PartGroupID);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtype", Order.ProdType);
        }
        public static int TextLength(string? text, Font font, Graphics g)
        {
            return (int)(g.MeasureString(text, font).Width);

        }




        public class Save
        {
            private readonly Module module;
            public Save(Module module)
            {
                this.module = module;
            }

            public string INSERT_Values(string revision)
            {
                string query = null;
                var machineIndex = "NULL";
                if (module.MachineIndex > 0)
                    machineIndex = module.MachineIndex.ToString();

                for (var row = 0; row < module.dgv_Module.Rows.Count; row++)
                {
                    var column = 0;
                    for (var col = module.dgv_Module.Columns.Count - 3; col < module.dgv_Module.Columns.Count; col++)
                    {
                        var pcID = Templates_Protocol.Template.ID(row, column,revision, module.FormTemplateID);
                        column++;
                        if (pcID.HasValue)
                        {
                            var type = ValueType(pcID);
                            switch (type)
                            {
                                case 0: //NumberValue
                                    if (module.dgv_Module.Rows[row].Cells[col].Value != null)
                                    {
                                        if (double.TryParse(module.dgv_Module.Rows[row].Cells[col].Value.ToString(), out var value))
                                            query += $"(@partID, {pcID}, {machineIndex}, {string.Format(CultureInfo.InvariantCulture, "{0}", value)}, NULL, {type}),";
                                        else
                                            query += $"(@partID, {pcID}, {machineIndex}, NULL, NULL, {type}),";
                                    }
                                    else
                                        query += $"(@partID, {pcID}, {machineIndex}, NULL, NULL, {type}),";

                                    break;

                                case 1: //TextValue
                                    if (module.dgv_Module.Rows[row].Cells[col].Value != null)
                                    {
                                        var textValue = module.dgv_Module.Rows[row].Cells[col].Value.ToString();
                                        query += $"(@partID, {pcID}, {machineIndex}, NULL, '{textValue}', {type}),";
                                    }
                                    else
                                        query += $"(@partID, {pcID}, {machineIndex}, NULL, NULL, {type}),";

                                    break;
                            }
                        }
                    }
                }
                //Raderar sista kommatecknet från querybuildern
                if (query is null)
                    return null;
                query = query.Remove(query.Length - 1, 1);
                return query;
            }
            private string UPDATE_Values(string revision)
            {
                    string query = null;
                    var machineIndex = "NULL";
                    if (module.MachineIndex > 0)
                        machineIndex = module.MachineIndex.ToString();

                    for (var row = 0; row < module.dgv_Module.Rows.Count; row++)
                    {
                        var column = 0;
                        for (var col = module.dgv_Module.Columns.Count - 3; col < module.dgv_Module.Columns.Count; col++)
                        {
                            var pcID = Templates_Protocol.Template.ID(row, column, revision, module.FormTemplateID);
                            column++;
                            if (pcID.HasValue)
                            {
                                var type = ValueType(pcID);
                                switch (type)
                                {
                                    case 0: //NumberValue
                                        if (module.dgv_Module.Rows[row].Cells[col].Value != null)
                                        {
                                            if (double.TryParse(module.dgv_Module.Rows[row].Cells[col].Value.ToString(), out var value))
                                                query += $@"
                                                IF NOT EXISTS (SELECT 1 FROM Processcard.Data WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0))
                                                BEGIN
                                                    INSERT INTO Processcard.Data (PartID, TemplateID, Value, MachineIndex) VALUES (@partID, {pcID}, {string.Format(CultureInfo.InvariantCulture, "{0}", value)}, {machineIndex})
                                                END
                                                ELSE
                                                BEGIN
                                                    UPDATE Processcard.Data SET Value = {string.Format(CultureInfo.InvariantCulture, "{0}", value)} WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0)
                                                END";
                                        }
                                        else
                                            query += $@"
                                                IF NOT EXISTS (SELECT 1 FROM Processcard.Data WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0))
                                                BEGIN
                                                    INSERT INTO Processcard.Data (PartID, TemplateID, Value, MachineIndex) VALUES (@partID, {pcID}, NULL, {machineIndex})
                                                END
                                                ELSE
                                                BEGIN
                                                    UPDATE Processcard.Data SET Value = NULL WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0)
                                                END";
                                        break;
                                    case 1: //TextValue
                                        if (module.dgv_Module.Rows[row].Cells[col].Value != null)
                                        {
                                            var textValue = module.dgv_Module.Rows[row].Cells[col].Value.ToString();
                                            query += $@"
                                            IF NOT EXISTS (SELECT 1 FROM Processcard.Data WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0))
                                            BEGIN
                                                INSERT INTO Processcard.Data (PartID, TemplateID, TextValue, MachineIndex) VALUES (@partID, {pcID}, '{textValue}', {machineIndex})
                                            END
                                            ELSE
                                            BEGIN
                                                UPDATE Processcard.Data SET TextValue = '{textValue}' WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0)
                                            END";
                                        }
                                        else
                                            query += $@"
                                            IF NOT EXISTS (SELECT 1 FROM Processcard.Data WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0))
                                                BEGIN
                                            INSERT INTO Processcard.Data (PartID, TemplateID, TextValue, MachineIndex) VALUES (@partID, {pcID}, NULL, {machineIndex})
                                            END
                                            ELSE
                                            BEGIN
                                                UPDATE Processcard.Data SET TextValue = NULL WHERE PartID = @partID AND TemplateID = {pcID} AND COALESCE(MachineIndex, 0) = COALESCE({machineIndex}, 0)
                                            END";
                                        break;
                                }
                            }
                        }
                    }
                    return query;
            }
            private static int ValueType(int? templ_ID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT Type FROM Protocol.Template
                    WHERE ID = @templateid";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@templateid", templ_ID);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    return int.Parse(value.ToString());
                }
            }
            
            public static void Save_MainData(ref bool IsOk, int PartID, List<SqlParameter> parameters = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    INSERT INTO Processcard.MainData 
                    (
                        PartID, 
                        PartGroupID, 
                        PartNr, 
                        RevNr, 
                        ProdLine, 
                        ProdType, 
                        ProtocolMainTemplateID, 
                        MeasureProtocolMainTemplateID,
                        WorkOperationID, 
                        Extra_Info, 
                        GodkäntDatum, 
                        RevÄndratDatum, 
                        QA_sign, 
                        UpprättatAv_Sign_AnstNr, 
                        RevInfo,
                        Historiska_Data, 
                        Validerat, 
                        Framtagning_Processfönster, 
                        Validerade_Loter, 
                        Aktiv
                    )
                    VALUES 
                    (
                        @partid, 
                        @partgroupid, 
                        @partnr, 
                        @revNr, 
                        @prodline, 
                        @prodtype, 
                        @maintemplateid, 
                        (SELECT TOP(1) MeasureProtocolMainTemplateID FROM MeasureProtocol.MainTemplate WHERE Name = @name ORDER BY Revision DESC),
                        (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL), 
                        @extraInfo, 
                        NULL,  
                        @revÄndratDatum, 
                        NULL, 
                        @upprättatAvSign, 
                        @revInfo, 
                        @histData, 
                        @validerat, 
                        @framtagning_Processfönster, 
                        @validerade_Loter, 
                        'True'
                    )";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", PartID);
                    cmd.Parameters.AddWithValue("@name", Templates_MeasureProtocol.MainTemplate.Name);
                    Add_Parameters(cmd, parameters, PartID);
                    con.Open();
                    Manage_Processcards.Execute_cmd(cmd, ref IsOk);
                }
            }
            public void Save_Data(string revision, ref bool IsOk)
            {
                var data = INSERT_Values(revision);
                if (data is null)
                    return;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                        INSERT INTO Processcard.Data (PartID, TemplateID, MachineIndex, Value, TextValue, Type)
                        VALUES {data} ";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", Order.PartID);
                    con.Open();
                    Manage_Processcards.Execute_cmd(cmd, ref IsOk);
                }
            }
           
            public static void Update_MainData(ref bool IsOk, List<SqlParameter> parameters = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    UPDATE Processcard.MainData 
                    SET 
                        ProdType = @prodtype, 
                        MeasureProtocolMainTemplateID = (SELECT TOP(1) MeasureProtocolMainTemplateID FROM MeasureProtocol.MainTemplate WHERE Name = @name ORDER BY Revision DESC),
                        Extra_Info = @extraInfo, 
                        RevÄndratDatum = @revÄndratDatum, 
                        RevInfo = @revInfo, 
                        Historiska_Data = @histData, 
                        Validerat = @validerat, 
                        Framtagning_Processfönster = @framtagning_Processfönster, 
                        Validerade_Loter = @validerade_Loter 
                    WHERE PartID = @partID";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", Order.PartID);
                    cmd.Parameters.AddWithValue("@name", Templates_MeasureProtocol.MainTemplate.Name);
                    Add_Parameters(cmd, parameters, (int)Order.PartID);
                    con.Open();
                    Manage_Processcards.Execute_cmd(cmd, ref IsOk);
                }
            }
            public void Update_Data(string revision, ref bool IsOk)
            {
                var query = UPDATE_Values(revision);
                if (query is null)
                    return;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partID", Order.PartID);
                    con.Open();
                    Manage_Processcards.Execute_cmd(cmd, ref IsOk);
                }
            }
        }

        public class Load
        {
            private readonly Module module;
            public Load(Module module)
            {
                this.module = module;
            }

            public void Load_ProcessData(int formTemplateID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                    SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                    FROM Protocol.Template AS template
                        JOIN Processcard.Data AS pc_data
	                        ON pc_data.TemplateID = template.Id
                        JOIN Protocol.Description AS descr
	                        ON descr.Id = template.ProtocolDescriptionID
                    WHERE pc_data.PartID = @partID
                       -- AND template.revision = @revision    
                        AND template.FormTemplateID = @formtemplateid
                        AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))
                        
                    ORDER BY RowIndex, ColumnIndex";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                    //template.Revision bör ej behövas kvar eftersom MainTemplateID är unikt och revisionen baseras på det
                    // cmd.Parameters.AddWithValue("@revision", Manage_Templates.MainTemplate.Revision);
                    cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                    cmd.Parameters.AddWithValue("@machineindex", module.MachineIndex);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = string.Empty;
                        int.TryParse(reader["RowIndex"].ToString(), out var row);
                        int.TryParse(reader["Type"].ToString(), out var type);
                        int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                        switch (type)
                        {
                            case 0: //NumberValue
                                int.TryParse(reader["Decimals"].ToString(), out var decimals);
                                value = double.TryParse(reader["Value"].ToString(), out var NumberValue) == false ? string.Empty : Format_Value(NumberValue, decimals);
                                break;
                            case 1: //TextValue
                                value = reader["TextValue"].ToString();
                                break;
                        }
                        module.dgv_Module.Rows[row].Cells[col + 8].Value = value;
                    }
                }
                module.dgv_Module.CellValueChanged += module.Module_ValidateData_SaveData_CellValueChanged;
            }
        }
    }
}
