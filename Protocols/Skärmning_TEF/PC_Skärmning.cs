using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    public partial class PC_Skärmning : UserControl
    {
        private Control[] AllControls
        {
            get
            {
                var ctrl = new Control[]
                {
                    tb_Temp_min, tb_Temp_nom, tb_Temp_max,
                    tb_ID_min, tb_ID_nom, tb_ID_max,
                    tb_OD1_min, tb_OD1_nom, tb_OD1_max,
                    tb_ODs_min, tb_ODs_nom, tb_ODs_max,
                    tb_Verktyg_ID_min, tb_Verktyg_ID_nom, tb_Verktyg_ID_max
                };
                return ctrl;
            }
        }

        public PC_Skärmning()
        {
            InitializeComponent();
        }

        public void Clear_Data()
        {
            foreach(Control control in tlp_Main.Controls)
                if (control is TextBox tb)
                    tb.Clear();
        }

        public void Load_Data()
        {
            if (Order.PartID is null)
                return;
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
                        AND template.FormTemplateID = @formtemplateid
                        AND ColumnIndex % 2 = 0
                    ORDER BY ColumnIndex, RowIndex";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", 12);
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
                    switch (type)
                    {
                        case 0:
                            AllControls[ctr].Text = reader["Value"].ToString();
                            break;
                        case 1:
                            AllControls[ctr].Text = reader["TextValue"].ToString();
                            break;
                    }
                    ctr++;
                }
            }

            Control[] control = {tb_Antal_Trådar_nom, tb_Pot_Maskin_Hastighet_nom, tb_Carrier_fjäder_nom, tb_PPI_nom };
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
                        AND template.FormTemplateID = @formtemplateid
                    ORDER BY ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", 11);
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
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
                    control[ctr].Text = value;
                    ctr++;
                }
            }
        }
        public void Save_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    BEGIN TRANSACTION
                        INSERT INTO Processcard.Data (PartID, TemplateID, Value, TextValue, Type)
                        VALUES {INSERT_ValuesFormTemplateID_12} 
                        INSERT INTO Processcard.Data (PartID, TemplateID, Value, TextValue, Type)
                        VALUES {INSERT_ValuesFormTemplateID_11} 
                        {Manage_Processcards.INSERT_INTO_Processkort_Main}

                    COMMIT TRANSACTION";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            Add_Parameters(cmd, parameters);
            con.Open();
            Manage_Processcards.Execute_cmd(cmd, ref IsOk);
        }

       
        public string INSERT_ValuesFormTemplateID_11
        {
            get
            {
                string query = null;

                int[] columns = {0, 1, 3, 4};
                TextBox[] tb = {tb_Antal_Trådar_nom, tb_Pot_Maskin_Hastighet_nom, tb_Carrier_fjäder_nom, tb_PPI_nom};
                var ctr = 0;
                foreach (var col in columns)
                {
                    var pcID = Processcard.TemplateID(0, col,11);
                    if (pcID.HasValue)
                    {
                        var type = Processcard.ValueType(pcID);
                        switch (type)
                        {
                            case 0: //NumberValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    if (double.TryParse(tb[ctr].Text, out var value))
                                        query += $"(@partID, {pcID}, {string.Format(CultureInfo.InvariantCulture, "{0}", value)}, NULL, {type}),";
                                    else
                                        query += $"(@partID, {pcID}, NULL, NULL, {type}),";
                                }
                                else
                                    query += $"(@partID, {pcID}, NULL, NULL, {type}),";
                                break;

                            case 1: //TextValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    var textValue = tb[ctr].Text;
                                    query += $"(@partID, {pcID}, NULL, '{textValue}', {type}),";
                                }
                                else
                                    query += $"(@partID, {pcID}, NULL, NULL, {type}),";
                                break;
                        }
                    }
                    ctr++;
                }
                query = query.Remove(query.Length - 1, 1);
                return query;
            }
        }
        public string INSERT_ValuesFormTemplateID_12
        {
            get
            {
                string query = null;
               
                TextBox[] tb =
                {
                    tb_Temp_min, tb_Temp_nom, tb_Temp_max, tb_Temp_min, tb_Temp_nom, tb_Temp_max,
                    tb_ID_min, tb_ID_nom, tb_ID_max, tb_ID_min, tb_ID_nom, tb_ID_max,
                    tb_OD1_min, tb_OD1_nom, tb_OD1_max, tb_OD1_min, tb_OD1_nom, tb_OD1_max,
                    tb_ODs_min, tb_ODs_nom, tb_ODs_max, tb_ODs_min, tb_ODs_nom, tb_ODs_max,
                    tb_Verktyg_ID_min, tb_Verktyg_ID_nom, tb_Verktyg_ID_max
                };
                int[] col =
                {
                    0,0,0,1,1,1,
                    2,2,2,3,3,3,
                    4,4,4,5,5,5,
                    6,6,6,7,7,7,
                    8,8,8
                };
                int[] row =
                {
                    0,1,2,0,1,2,
                    0,1,2,0,1,2,
                    0,1,2,0,1,2,
                    0,1,2,0,1,2,
                    0,1,2
                };
                for (var ctr = 0; ctr < tb.Length; ctr++)
                {
                    var pcID = Processcard.TemplateID(row[ctr], col[ctr],  12);
                    if (pcID.HasValue)
                    {
                        var type = Processcard.ValueType(pcID);
                        switch (type)
                        {
                            case 0: //NumberValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    if (double.TryParse(tb[ctr].Text, out var value))
                                        query += $"(@partID, {pcID}, {string.Format(CultureInfo.InvariantCulture, "{0}", value)}, NULL, {type}),";
                                    else
                                        query += $"(@partID, {pcID}, NULL, NULL, {type}),";
                                }
                                else
                                    query += $"(@partID, {pcID}, NULL, NULL, {type}),";
                                break;

                            case 1: //TextValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    var textValue = tb[ctr].Text;
                                    query += $"(@partID, {pcID}, NULL, '{textValue}', {type}),";
                                }
                                else
                                    query += $"(@partID, {pcID}, NULL, NULL, {type}),";
                                break;
                        }
                    }
                }
                query = query.Remove(query.Length - 1, 1);
                return query;
            }
        }
        public string UPDATE_ValuesFormTemplateID_11
        {
            get
            {
                string query = null;

                int[] columns = { 0, 1, 3, 4 };
                TextBox[] tb = { tb_Antal_Trådar_nom, tb_Pot_Maskin_Hastighet_nom, tb_Carrier_fjäder_nom, tb_PPI_nom };
                var ctr = 0;
                foreach (var col in columns)
                {
                    var pcID = Processcard.TemplateID(0, col,  11);
                    if (pcID.HasValue)
                    {
                        var type = Processcard.ValueType(pcID);
                        switch (type)
                        {
                            case 0: //NumberValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    if (double.TryParse(tb[ctr].Text, out var value))
                                        query += $"UPDATE Processcard.Data SET value = {string.Format(CultureInfo.InvariantCulture, "{0}", value)} WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                }
                                else
                                    query += $"UPDATE Processcard.Data SET value = NULL WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                break;

                            case 1: //TextValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    var textValue = tb[ctr].Text;
                                    query += $"UPDATE Processcard.Data SET textvalue = '{textValue}' WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                }
                                else
                                    query += $"UPDATE Processcard.Data SET textvalue = NULL WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                break;
                        }
                    }
                    ctr++;
                }

                return query;
            }
        }
        public string UPDATE_ValuesFormTemplateID_12
        {
            get
            {
                string query = null;

                TextBox[] tb =
                {
                    tb_Temp_min, tb_Temp_nom, tb_Temp_max, tb_Temp_min, tb_Temp_nom, tb_Temp_max,
                    tb_ID_min, tb_ID_nom, tb_ID_max, tb_ID_min, tb_ID_nom, tb_ID_max,
                    tb_OD1_min, tb_OD1_nom, tb_OD1_max, tb_OD1_min, tb_OD1_nom, tb_OD1_max,
                    tb_ODs_min, tb_ODs_nom, tb_ODs_max, tb_ODs_min, tb_ODs_nom, tb_ODs_max,
                    tb_Verktyg_ID_min, tb_Verktyg_ID_nom, tb_Verktyg_ID_max
                };
                int[] col =
                {
                    0,0,0,1,1,1,
                    2,2,2,3,3,3,
                    4,4,4,5,5,5,
                    6,6,6,7,7,7,
                    8,8,8
                };
                int[] row =
                {
                    0,1,2,0,1,2,
                    0,1,2,0,1,2,
                    0,1,2,0,1,2,
                    0,1,2,0,1,2,
                    0,1,2
                };
                for (var ctr = 0; ctr < tb.Length; ctr++)
                {
                    var pcID = Processcard.TemplateID(row[ctr], col[ctr], 12);
                    if (pcID.HasValue)
                    {
                        var type = Processcard.ValueType(pcID);
                        switch (type)
                        {
                            case 0: //NumberValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    if (double.TryParse(tb[ctr].Text, out var value))
                                        query += $"UPDATE Processcard.Data SET value = {string.Format(CultureInfo.InvariantCulture, "{0}", value)} WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                }
                                else
                                    query += $"UPDATE Processcard.Data SET value = NULL WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                break;

                            case 1: //TextValue
                                if (!string.IsNullOrEmpty(tb[ctr].Text))
                                {
                                    var textValue = tb[ctr].Text;
                                    query += $"UPDATE Processcard.Data SET textvalue = '{textValue}' WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                }
                                else
                                    query += $"UPDATE Processcard.Data SET textvalue = NULL WHERE PartID = @partID AND TemplateID = {pcID} \n";
                                break;
                        }
                    }
                }

                return query;
            }
        }
        public void Update_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    BEGIN TRANSACTION
                        {UPDATE_ValuesFormTemplateID_11}
                        {UPDATE_ValuesFormTemplateID_12}
                        {Manage_Processcards.UPDATE_Processkort_Main}

                    COMMIT TRANSACTION";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                Add_Parameters(cmd, parameters);
                con.Open();
                Manage_Processcards.Execute_cmd(cmd, ref IsOk);
            }
        }

        private void Add_Parameters(SqlCommand cmd, List<SqlParameter> parameters)
        {
            cmd.Parameters.AddRange(parameters.ToArray());

            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
            cmd.Parameters.AddWithValue("@partgroupid", Order.PartGroupID);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtype", Order.ProdType);

        }

        private void EnterToTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
