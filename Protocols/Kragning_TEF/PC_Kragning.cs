using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    public partial class PC_Kragning : UserControl
    {
        public DataGridView dgv_Korprotokoll;
        public PC_Kragning()
        {
            InitializeComponent();
            Kragningsdon_Nr.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            Templates_Protocol.MainTemplate.Revision = "A";
        }


        public void Load_Info()
        {
            dgv_Processkort.Rows.Clear();
            dgv_Processkort.Columns.Clear();
            for (var col = 0; col < 8; col++)
            {
                dgv_Processkort.Columns.Add(col.ToString(), "");
                dgv_Processkort.Columns[col].Width = (int)tlp_Main.ColumnStyles[col + 1].Width;
            }

            for (var row = 0; row < 3; row++)
                dgv_Processkort.Rows.Add();

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT DISTINCT CodeText, RowIndex, ColumnIndex, template.Type, template.Decimals
                    FROM Protocol.Template as template
	                    JOIN Protocol.Description as descr
		                    ON descr.Id = template.ProtocolDescriptionID
                    WHERE FormTemplateID = @formtemplateid
                    AND ColumnIndex IS NOT NULL
                    ORDER BY RowIndex";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@formtemplateid", 8);
                //cmd.Parameters.AddWithValue("@revision", Processcard.Active_Processcard_Revision(8));
                var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int.TryParse(reader["RowIndex"].ToString(), out var row);
                int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                int.TryParse(reader["Type"].ToString(), out var type);
                int.TryParse(reader["Decimals"].ToString(), out var decimals);
               // switch (type)
              //  {
                    //case 0: //NumberValue
                    //    if (decimals > 0)
                    //        Processcard.Rows_double.Add(row);
                    //    else
                    //        Processcard.Rows_int.Add(row);
                    //    break;
                    //case 1: //TextValue
                    //    Processcard.Rows_string.Add(row);
                    //    break;
               // }
                switch (col)
                {
                    case 0://MIN
                    case 2://MAX
                        dgv_Processkort.Rows[col].Cells[row].Style.BackColor = Color.Gainsboro;
                        dgv_Processkort.Rows[col].Cells[row].Style.ForeColor = Color.DodgerBlue;
                        break;
                    case 1://NOM
                        dgv_Processkort.Rows[col].Cells[row].Style.BackColor = Color.Silver;
                        dgv_Processkort.Rows[col].Cells[row].Style.ForeColor = Color.ForestGreen;
                        break;

                }
            }
        }
        public void Load_Data()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                    FROM Protocol.Template AS template
                        JOIN Processcard.Data AS pc_data
	                        ON pc_data.TemplateID = template.Id
                        JOIN Protocol.Description AS descr
	                        ON descr.Id = template.ProtocolDescriptionID
                    WHERE pc_data.PartID = @partID
                    
                    ORDER BY RowIndex, ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["ColumnIndex"].ToString(), out var row);
                    int.TryParse(reader["RowIndex"].ToString(), out var col);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0://NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);

                        if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                            value = string.Empty;
                        else
                            value = Processcard.Format_Value(NumberValue, decimals);
                        break;
                    case 1://TextValue
                        value = reader["TextValue"].ToString();
                        break;
                }
                   
                dgv_Processkort.Rows[row].Cells[col].Value = value;
            }
        }

        public void Lock_TextBoxes()
        {
            Kragningsdon_Nr.ReadOnly = false;
        }

        public string INSERT_Values()
        {
            string query = null;

            for (var col = 0; col < dgv_Processkort.Columns.Count; col++)
            {
                for (var row = 0; row < 3; row++)
                {
                    var Template_ID = Processcard.TemplateID(col, row,  8);
                    if (Template_ID.HasValue)
                    {
                        var type = Processcard.ValueType(Template_ID);
                        switch (type)
                        {
                            case 0://NumberValue
                                if (dgv_Processkort.Rows[row].Cells[col].Value != null)
                                {
                                    if (double.TryParse(dgv_Processkort.Rows[row].Cells[col].Value.ToString(), out var value))
                                        query += $"(@partid, {Template_ID}, {string.Format(CultureInfo.InvariantCulture, "{0}", value)}, NULL, {type}),";
                                    else
                                        query += $"(@partid, {Template_ID}, NULL, NULL, {type}),";
                                }
                                else
                                    query += $"(@partid, {Template_ID}, NULL, NULL, {type}),";
                                break;
                            case 1://TextValue
                                if (dgv_Processkort.Rows[row].Cells[col].Value != null)
                                {
                                    var textValue = dgv_Processkort.Rows[row].Cells[col].Value.ToString();
                                    query += $"(@partid, {Template_ID}, NULL, '{textValue}', {type}),";
                                }
                                else
                                    query += $"(@partid, {Template_ID}, NULL, NULL, {type}),";

                                break;
                        }
                    }
                }
            }
            query = query.Remove(query.Length - 1, 1);
            return query;
        }
        public string UPDATE_Values()
        {
            string query = null;

            for (var col = 0; col < dgv_Processkort.Columns.Count; col++)
            {
                for (var row = 0; row < 3; row++)
                {
                    var Template_ID = Processcard.TemplateID(col, row,  8);
                    if (Template_ID.HasValue)
                    {
                        var type = Processcard.ValueType(Template_ID);
                        switch (type)
                        {
                            case 0://NumberValue
                                if (dgv_Processkort.Rows[row].Cells[col].Value != null)
                                {
                                    if (double.TryParse(dgv_Processkort.Rows[row].Cells[col].Value.ToString(), out var value))
                                        query += $"UPDATE Processcard.Data SET value = {string.Format(CultureInfo.InvariantCulture, "{0}", value)} WHERE PartID = @partID AND TemplateID = {Template_ID} \n";
                                }
                                else
                                    query += $"UPDATE Processcard.Data SET value = NULL WHERE PartID = @partID AND TemplateID = {Template_ID} \n";
                                break;
                            case 1://TextValue
                                if (dgv_Processkort.Rows[row].Cells[col].Value != null)
                                {
                                    var textValue = dgv_Processkort.Rows[row].Cells[col].Value.ToString();
                                    query += $"UPDATE Processcard.Data SET textvalue = '{textValue}' WHERE PartID = @partID AND TemplateID = {Template_ID} \n";
                                }
                                else
                                    query += $"UPDATE Processcard.Data SET textvalue = NULL WHERE PartID = @partID AND TemplateID = {Template_ID} \n";
                                break;
                        }
                    }
                }
            }
            return query;
        }
        public void Save_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    BEGIN TRANSACTION
                        INSERT INTO Processcard.Data (PartID, TemplateID, Value, TextValue, Type)
                        VALUES {INSERT_Values()}  
                        
                        {Manage_Processcards.INSERT_INTO_Processkort_Main} 
                    COMMIT TRANSACTION";

                
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partid", Order.PartID);
            if (parameters != null)
                Add_Parameters(cmd, parameters);
            con.Open();
            Manage_Processcards.Execute_cmd(cmd, ref IsOk);
        }
        public void Update_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    BEGIN TRANSACTION
                        {UPDATE_Values()} ";
            if (parameters != null)
                query += $"{Manage_Processcards.UPDATE_Processkort_Main} ";

            query += "COMMIT TRANSACTION";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partid", Order.PartID);
            if (parameters != null)
                Add_Parameters(cmd, parameters);
            con.Open();
            Manage_Processcards.Execute_cmd(cmd, ref IsOk);
        }

        public void Add_Parameters(SqlCommand cmd, List<SqlParameter> parameters)
        {
            cmd.Parameters.AddRange(parameters.ToArray());
          //  SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtype", Order.ProdType);
            cmd.Parameters.AddWithValue("@partgroupid", Order.PartGroupID);
        }

        private void Kragningsdon_Nr_TextChanged(object sender, EventArgs e)
        {
            if (Module.IsOkToSave)
                KP_Kragning.INSERT_Data_Kragning(dgv_Korprotokoll, 173,0, Kragningsdon_Nr.Text, 1);
        }
    }
}
