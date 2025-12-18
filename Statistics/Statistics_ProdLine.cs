using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.Statistics
{
    public partial class Statistics_ProdLine : Form
    {
        private Point? prevPosition;
        private readonly ToolTip tooltip = new ToolTip();
        private readonly string? ProdLine;
        private int total_Value_Chart;
        private static Dictionary<string, string> Month
        {
            get
            {
                var day = new Dictionary<string, string>
                {
                    {"1",  "Jan"},
                    {"2",  "Feb"},
                    {"3",  "March"  },
                    {"4",  "April" },
                    {"5",  "May"},
                    {"6",  "June"},
                    {"7",  "July"},
                    {"8",  "Aug" },
                    {"9",  "Sep"},
                    {"10", "Oct"},
                    {"11", "Nov"},
                    {"12", "Dec"}
                };

                return day;
            }
        }


        public Statistics_ProdLine(string? prodLine)
        {
            Activity.Start();
            InitializeComponent();
            Translate_Form();
            
            ProdLine = prodLine;
            label_ProdLine.Text = prodLine;
            Fill_dgv();
        }


        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_ProdLine});
        }
        private void Fill_dgv()
        {
            dgv_Text.Columns.Add("Header", LanguageManager.GetString("statsProdLine_Header"));

            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_1"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_2"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_3"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_4"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_5"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_6"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_7"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_8"));
            dgv_Text.Rows.Add(LanguageManager.GetString("statsProdLine_9"));
        }

        private void DataGridView_Text_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            chart.Series.Clear();
            switch (e.RowIndex)
            {
                case 0:
                    Fill_Chart_Vanligaste_Kund();
                    break;
                case 1:
                    Fill_Chart_Vanligaste_ArtikelNr();
                    break;
                case 2:
                    Fill_Chart_Vanligaste_Material();
                    break;
                case 3:
                    Fill_Chart_Antal_Ordar_år();
                    break;
                case 4:
                    Fill_Chart_Antal_Ordar_månad();
                    break;
                case 5:
                    Fill_Chart_Operatör_Line_Clearance();
                    break;
                case 6:
                    Fill_Chart_Mätningar_Linje();
                    break;
                case 7:
                    Fill_Chart_MedelTemp_Zoner();
                    break;
                case 8:
                    Fill_Chart_Vanligaste_Storlek_Slang();
                    break;
            }
        }
        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                if (result.ChartElementType != ChartElementType.DataPoint) 
                    continue;
                if (!(result.Object is DataPoint prop)) 
                    continue;
                var percent = prop.YValues[0] / total_Value_Chart * 100;
                tooltip.Show($"{prop.YValues[0]} - {percent:0.0}%", chart, pos.X + 15, pos.Y - 15);
            }
            //mousePosition = (double)Height / MousePosition.Y;
        }
        

        private void Fill_Chart_Vanligaste_Kund()
        {
            
            chart.Series.Add(LanguageManager.GetString("statsProdLine_1"));
            total_Value_Chart = 0;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT TOP 10 * FROM (
                                SELECT Customer, Count(*) as Antal 
                                    FROM [Order].MainData 
                                        WHERE ProdLine = @prodline
                                        GROUP BY Customer) AS a
                                ORDER BY Antal DESC";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@prodline", ProdLine);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int.TryParse(reader[1].ToString(), out var antal);
                total_Value_Chart += antal;
                string customer = reader[0].ToString();
                chart.Series[0].Points.AddXY(customer, antal);
            }
        }
        private void Fill_Chart_Vanligaste_ArtikelNr()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_2"));
            total_Value_Chart = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT TOP 10 * FROM (
                                SELECT PartNr, Count(*) as Antal 
                                    FROM [Order].MainData 
                                        WHERE ProdLine = @prodline
                                        GROUP BY PartNr) AS a
                                ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[1].ToString(), out var antal);
                    total_Value_Chart += antal;
                    chart.Series[0].Points.AddXY(reader[0].ToString(), antal);
                }
            }
        }
        private void Fill_Chart_Vanligaste_Material()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_3"));
            total_Value_Chart = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT TOP 20 * 
                    FROM 
                    (
                        SELECT pf.Halvfabrikat_Benämning, COUNT(*) AS Antal
                        FROM [Order].PreFab AS pf                            
                        INNER JOIN [Order].MainData AS main
                            ON main.OrderID = pf.OrderID
                        WHERE main.ProdLine = @prodline
                        GROUP BY pf.Halvfabrikat_Benämning
                    ) AS a
                    ORDER BY Antal DESC;";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[1].ToString(), out var antal);
                    total_Value_Chart += antal;
                    chart.Series[0].Points.AddXY(reader[0].ToString(), antal);
                }
            }
        }
        private void Fill_Chart_Antal_Ordar_år()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_4"));
            total_Value_Chart = 0;
            var dt = new DataTable();
            dt.Columns.Add("Year");
            dt.Columns.Add("Total");
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT TOP 10 * FROM(
                                SELECT YEAR(Date_Start) AS Year, COUNT(OrderNr) AS Total FROM [Order].MainData WHERE ProdLine = @prodline
                                GROUP BY YEAR(Date_Start)) AS a
                                ORDER BY Year DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                var reader = cmd.ExecuteReader();
                var row = 0;
                while (reader.Read())
                {
                    if (row > 0 && dt.Rows[row - 1]["Year"].ToString() == reader["Year"].ToString())
                        dt.Rows[row-1]["Total"] = int.Parse(dt.Rows[row - 1]["Total"].ToString()) + int.Parse(reader["Total"].ToString());
                    else
                    {
                        dt.Rows.Add();
                        dt.Rows[row]["Year"] = reader["Year"].ToString();
                        dt.Rows[row]["Total"] = reader["Total"].ToString();
                        row++;
                    }
                   
                }
            }
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                int.TryParse(dt.Rows[i]["Total"].ToString(), out var antal);
                total_Value_Chart += antal; 
                chart.Series[0].Points.AddXY(dt.Rows[i]["Year"], antal);
            }
        }
        private void Fill_Chart_Antal_Ordar_månad()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_5"));
            total_Value_Chart = 0;
            var dt = new DataTable();
            dt.Columns.Add("Month");
            dt.Columns.Add("Total");
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT MONTH(Date_Start) AS Month, COUNT(OrderNr) AS Total 
                    FROM [Order].MainData 
                    WHERE ProdLine = @prodline 
                        AND IsDeleted = 'False'
                    GROUP BY MONTH(Date_Start)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                var reader = cmd.ExecuteReader();
                var row = 0;
                while (reader.Read())
                {
                    if (row > 0 && dt.Rows[row - 1]["Month"].ToString() == reader["Month"].ToString())
                        dt.Rows[row - 1]["Total"] = int.Parse(dt.Rows[row - 1]["Total"].ToString()) + int.Parse(reader["Total"].ToString());
                    else
                    {
                        dt.Rows.Add();
                        dt.Rows[row]["Month"] = reader["Month"].ToString();
                        dt.Rows[row]["Total"] = reader["Total"].ToString();
                        row++;
                    }

                }
            }
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                int.TryParse(dt.Rows[i]["Total"].ToString(), out var antal);
                total_Value_Chart += antal;
                chart.Series[0].Points.AddXY(Month[dt.Rows[i]["Month"].ToString()], antal);
            }
        }
        private void Fill_Chart_Operatör_Line_Clearance()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_6"));
            total_Value_Chart = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                                SELECT LC_Name, Count(LC_Name) as Antal
                                    FROM [Order].MainData
                                    WHERE ProdLine = @prodline
                                    GROUP BY LC_Name
                                ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[1].ToString(), out var total);
                    total_Value_Chart += total;
                    chart.Series[0].Points.AddXY(reader[0].ToString(), total);
                }
            }
        }
        private void Fill_Chart_Mätningar_Linje()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_7"));
            total_Value_Chart = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT [User].Person.Name, COUNT (*) Antal
                             FROM Measureprotocol.MainData
                             INNER JOIN [User].Person
                                ON [User].Person.EmployeeNumber = Measureprotocol.MainData.AnstNr
                             WHERE EXISTS (SELECT * FROM [Order].MainData 
                                WHERE Measureprotocol.MainData.OrderID = [Order].MainData.OrderID 
                                    AND ProdLine = @prodline) 
                                AND AnstNr != '' AND AnstNr > 0
							 GROUP BY [User].Person.Name
                             ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[1].ToString(), out var total);
                    total_Value_Chart += total;
                    chart.Series[0].Points.AddXY(reader[0].ToString(), total);
                }
            }
        }
        private void Fill_Chart_MedelTemp_Zoner()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_8"));
            total_Value_Chart = 0;
            if (IsWorkOperation_Extrusion == false)
                return;
            int[] descrIDs_Zones = {213,214,215,217,218,283,284,285,286,287 };
            var nr = 1;
            foreach(var descrID in descrIDs_Zones)
            {
                var avg_Temp = 0;
                var ctr = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                                SELECT Value
                                FROM [Order].Data
                                WHERE ProtocolDescriptionID = @descriptionid
                                AND EXISTS 
                                    (SELECT * FROM [Order].MainData
                                        WHERE ProdLine = @prodline AND [Order].Data.OrderID = [Order].MainData.OrderID)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", ProdLine);
                    cmd.Parameters.AddWithValue("@descriptionid", descrID);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (int.TryParse(reader[0].ToString(), out var temp))
                        {
                            avg_Temp += temp;
                            ctr++;
                        }
                    }
                    if (ctr > 0)
                    {
                        avg_Temp /= ctr;
                        chart.Series[0].Points.AddXY($"Zon_{nr}", avg_Temp);
                    }
                }

                nr++;
            }
        }
     
        private void Fill_Chart_Vanligaste_Storlek_Slang()
        {
            chart.Series.Add(LanguageManager.GetString("statsProdLine_9"));
            total_Value_Chart = 0;
            var descriptionid = MeasureProtocol_DescriptionID;
            if (descriptionid == 0)
                return;
            for (var i = 0; i < 9; i++)
            {
                double min = i;
                double max = i + 1;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                         SELECT COUNT(Value) as Antal   
                        FROM Measureprotocol.Data WHERE Value BETWEEN {min} AND {max}
                            AND EXISTS 
                            (SELECT * FROM [Order].MainData
                            WHERE ProdLine = @prodline AND [Order].MainData.OrderID = Measureprotocol.Data.OrderID)
                            AND DescriptionId = @descriptionid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", ProdLine);
                    cmd.Parameters.AddWithValue("@descriptionid", descriptionid);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int.TryParse(reader[0].ToString(), out var antal);
                        total_Value_Chart += antal;
                        chart.Series[0].Points.AddXY($"OD: {min}-{max} mm", antal);
                    }
                }
            }
        }

        private static bool IsWorkOperation_Extrusion
        {
            get
            {
                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Grov_PTFE:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                    case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                        return true;
                    default:
                        return false;
                }
            }
        }
        private static int MeasureProtocol_DescriptionID
        {
            get
            {
                switch(Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Grov_PTFE:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                    case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                    case Manage_WorkOperation.WorkOperations.Hackning_PUR_IV:
                    case Manage_WorkOperation.WorkOperations.Hackning_PTFE:
                    case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                        return 11;
                    case Manage_WorkOperation.WorkOperations.Synergy_PTFE_K18:
                        return 10;
                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        return 14;
                    case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
                    case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
                        return 8;
                    default:
                        return 0;
                }
            }
        }
        private void Close_Form_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Statistics_ProdLine_FormClosed(object sender, FormClosedEventArgs e)
        {
            Points.Add_Points(5, $"Statistik_ProdLinje - {ProdLine}");
        }
    }
}
