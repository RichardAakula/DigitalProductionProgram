using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Statistics
{
    public partial class ProductionLines : Form
    {
        
        private static int Antal_Artiklar(DataTable dt)
        {
            var ctr = 0;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                int.TryParse(dt.Rows[i]["Amount"].ToString(), out var value);
                ctr += value;
            }
            return ctr;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public ProductionLines(string linje)
        {
            InitializeComponent();
            Fill_cb_ProdLinje();
            cb_Linje.Text = linje;
            InitializeForm();

            date_To.Value = DateTime.Now;
        }
        private void ProduktionsLinje_Load(object sender, EventArgs e)
        {
            Fill_DataGridViews();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void InitializeForm()
        {
            Control[] control_Extrudering = { panel_Huvud, panel_Munstycke, panel_Kärn };
            Control[] control_Krympslang = { panel_KrympslangsRör, panel_KrympslangsLinje, panel_Hackhylsa, panel_Anslutningsmuff };
            Order.ProdLine = cb_Linje.Text;

            if (Manage_WorkOperation.Load_WorkOperation() == Manage_WorkOperation.WorkOperations.Extrudering_Termo )
            {
                foreach (var ctrl in control_Krympslang)
                    ctrl.Visible = false;
                foreach (var ctrl in control_Extrudering)
                    ctrl.Visible = true;   
            }
            else if (Manage_WorkOperation.Load_WorkOperation() == Manage_WorkOperation.WorkOperations.Krympslangsblåsning)
            {
                foreach (var ctrl in control_Krympslang)
                    ctrl.Visible = true;
                foreach (var ctrl in control_Extrudering)
                    ctrl.Visible = false;

            }
            else
            {
                foreach (var ctrl in control_Krympslang)
                    ctrl.Visible = false;
                foreach (var ctrl in control_Extrudering)
                    ctrl.Visible = false;
            }
        }

        private void Fill_cb_ProdLinje()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DISTINCT ProdLinje 
                                    FROM [Order].MainData
                                    ORDER BY ProdLinje";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cb_Linje.Items.Add(reader[0].ToString());
            } 
        }

        private void Fill_DataGridViews()
        {
            Fill_dgv_Mätningar();
            Fill_dgv_MestFrekventaArtikelNr();
            Fill_dgv_MestFrekventaKund();
            Fill_dgv_OperatörSomRengörOftast();
            Fill_dgv_HuvudSomAnvändsOftast();
            Fill_dgv_MunstyckeSomAnvändsOftast();
            Fill_dgv_KärnSomAnvändsOftast();
            Fill_dgv_KrympslangsRörSomAnvändsOftast();
            Fill_dgv_KrympslangsLinjeSomAnvändsOftast();
            Fill_dgv_AnslutningsMuff();
            Fill_dgv_Hackhylsa();
         
        }

        private void Fill_dgv_Mätningar()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT COUNT (*) TextValue, [User].Person.Name
                    FROM Measureprotocol.Data AS data
                    INNER JOIN Measureprotokoll.MainData AS maindata
                        ON data.OrderID = maindata.OrderID
                        AND data.RowIndex = maindata.RowIndex
                    INNER JOIN [Order].MainData as kp
                        ON data.OrderID = kp.OrderID
                    INNER JOIN [User].Person
                         ON [User].Person.EmployeeNumber = maindata.AnstNr
                    WHERE kp.ProdLinje = @linje AND Datum_Tid 
                    AND DescriptionID = 48
                    AND Date BETWEEN @dateFrom AND @dateTo
					GROUP BY [User].Person.Name

				    UNION 
                    SELECT COUNT (*) TextValue, [User].Person.Name
                     FROM Measureprotocol.Data AS data
                    INNER JOIN Measureprotokoll.MainData AS maindata
                        ON data.OrderID = maindata.OrderID
                        AND data.RowIndex = maindata.RowIndex
                    INNER JOIN [Order].MainData as kp
                        ON data.OrderID = kp.OrderID
                    INNER JOIN [User].Person
                         ON [User].Person.EmployeeNumber = maindata.AnstNr

					WHERE kp.ProdLinje = @linje
                    AND Date BETWEEN @dateFrom AND @dateTo

                    GROUP BY [User].Person.Name
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);

            dgv_Mätningar.DataSource = dt;
            Resize_dgv(dgv_Mätningar, panel_Mätningar_Linje);
        }

        private void Fill_dgv_MestFrekventaArtikelNr()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT PartNr, Kund, Count(PartNr) as Antal 
                    FROM [Order].MainData 
                    WHERE ProdLinje = @linje AND Date_Start 
                    BETWEEN @dateFrom AND @dateTo GROUP BY PartNr, Kund 
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);
            dgv_FrekvensArtikelNr.DataSource = dt;
            Resize_dgv(dgv_FrekvensArtikelNr, panel_Frekvens_ArtikelNr);
        }
        private void Fill_dgv_MestFrekventaKund()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Kund, Count(PartNr) as Antal 
                    FROM [Order].MainData 
                    WHERE ProdLinje = @linje AND Date_Start 
                    BETWEEN @dateFrom AND @dateTo
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);

            dgv_Kund.DataSource = dt;
            Resize_dgv(dgv_Kund, panel_Frekvens_Kund);
        }
        private void Fill_dgv_OperatörSomRengörOftast()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT LC_Name, Count(LC_Name) as Antal
                    FROM [Order].MainData
                    WHERE ProdLinje = @linje AND Date_Start 
                    BETWEEN @dateFrom AND @dateTo
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);


            dgv_OperatörRengör.DataSource = dt;
            Resize_dgv(dgv_OperatörRengör, panel_Operatör_Rengör);
        }
        private void Fill_dgv_HuvudSomAnvändsOftast()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Huvud, Count(*) as Antal, ProdLinje
                    FROM Korprotokoll.ExtrusionTEF_Equipment
                    JOIN [Order].MainData AS main
                        ON Korprotokoll.ExtrusionTEF_Equipment.Extruder = main.ProdLinje 
                            AND Korprotokoll.ExtrusionTEF_Equipment.OrderID = main.OrderID
                    WHERE ProdLinje = @linje AND Korprotokoll.ExtrusionTEF_Equipment.Datum 
                    BETWEEN @dateFrom AND @dateTo
                    GROUP BY Huvud, ProdLinje
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            dt.Columns.Remove("ProdLinje");
            Fill_dt_Column_Percent(dt);

            dgv_Huvud.DataSource = dt;
            Resize_dgv(dgv_Huvud, panel_Huvud);
        }
        private void Fill_dgv_MunstyckeSomAnvändsOftast()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Munstycke, Count(*) as Antal, ProdLinje
                    FROM Korprotokoll.ExtrusionTEF_Equipment
                    JOIN [Order].MainData AS main
                        ON Korprotokoll.ExtrusionTEF_Equipment.Extruder = main.ProdLinje 
                            AND Korprotokoll.ExtrusionTEF_Equipment.OrderID = main.OrderID
                    WHERE ProdLinje = @linje AND Korprotokoll.ExtrusionTEF_Equipment.Datum 
                    BETWEEN @dateFrom AND @dateTo
                    GROUP BY Munstycke, ProdLinje
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            dt.Columns.Remove("ProdLinje");
            Fill_dt_Column_Percent(dt);

            dgv_Munstycke.DataSource = dt;
            Resize_dgv(dgv_Munstycke, panel_Munstycke);
        }
        private void Fill_dgv_KärnSomAnvändsOftast()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Kärna, Count(*) as Antal, ProdLinje
                    FROM Korprotokoll.ExtrusionTEF_Equipment
                    JOIN [Order].MainData AS main
                        ON Korprotokoll.ExtrusionTEF_Equipment.Extruder = main.ProdLinje 
                            AND Korprotokoll.ExtrusionTEF_Equipment.OrderID = main.OrderID
                    WHERE ProdLinje = @linje AND Korprotokoll.ExtrusionTEF_Equipment.Datum 
                    BETWEEN @dateFrom AND @dateTo
                    GROUP BY Kärna, ProdLinje
                    ORDER BY Antal DESC";
              
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            dt.Columns.Remove("ProdLinje");
            Fill_dt_Column_Percent(dt);

            dgv_Kärn.DataSource = dt;
            Resize_dgv(dgv_Kärn, panel_Kärn);
        }
        private void Fill_dgv_KrympslangsRörSomAnvändsOftast()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT rör, sum(antal) as Antal 
                        FROM (SELECT textvalue as rör, COUNT(textvalue) as antal
	                        FROM [Order].Data 
	                        WHERE ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 1') 
	                            OR ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 2')
	                            OR ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 3') 
                            GROUP BY textvalue) x
                        GROUP BY rör
                    ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                dt.Load(cmd.ExecuteReader());
            }
            dt.Columns.Add("%", typeof(string));

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var antal = double.Parse(dt.Rows[i]["Antal"].ToString());
                double total = Antal_Artiklar(dt);

                dt.Rows[i]["%"] = $"{antal / (total / 3) * 100:0.0}";
            }

            dgv_KrympslangsRör.DataSource = dt;
            Resize_dgv(dgv_KrympslangsRör, panel_KrympslangsRör);
        }
        private void Fill_dgv_KrympslangsLinjeSomAnvändsOftast()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            { 
                var query = @"
                    SELECT textvalue, sum(antal) as Antal 
                    FROM (SELECT textvalue, COUNT(textvalue) as antal 
                        FROM [Order].Data
                        WHERE ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'HS MASKIN')
                    GROUP BY textvalue) x 
                    GROUP BY textvalue ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);

            dgv_KrympslangsLinje.DataSource = dt;
            Resize_dgv(dgv_KrympslangsLinje, panel_KrympslangsLinje);
        }
        private void Fill_dgv_AnslutningsMuff()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT value, sum(antal) as Antal 
                    FROM
	                    (SELECT value, COUNT(value) as antal 
                        FROM [Order].Data 
                        WHERE ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'ANSLUTNINGSMUFF')
                    GROUP BY value)
                        x GROUP BY value ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);

            dgv_Anslutningsmuff.DataSource = dt;
            Resize_dgv(dgv_Anslutningsmuff, panel_Anslutningsmuff);
        }
        private void Fill_dgv_Hackhylsa()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT value, sum(antal) as Antal 
                    FROM
	                    (SELECT value, COUNT(value) as antal 
                        FROM [Order].Data 
                        WHERE ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'HACKHYLSA')
                    GROUP BY value)
                        x GROUP BY value ORDER BY Antal DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@linje", cb_Linje.Text);
                cmd.Parameters.AddWithValue("@dateFrom", date_From.Value);
                cmd.Parameters.AddWithValue("@dateTo", date_To.Value);
                dt.Load(cmd.ExecuteReader());
            }
            Fill_dt_Column_Percent(dt);

            dgv_Hackhylsa.DataSource = dt;
            Resize_dgv(dgv_Hackhylsa, panel_Hackhylsa);
        }
        private void Fill_dt_Column_Percent(DataTable dt)
        {
            dt.Columns.Add("%", typeof(string));
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var antal = double.Parse(dt.Rows[i]["Antal"].ToString());
                double total = Antal_Artiklar(dt);

                dt.Rows[i]["%"] = $"{antal / total * 100:0.0}";
            }
        }

        private static void Resize_dgv(DataGridView dgv, Control panel)
        {
            var width = dgv.Columns.Cast<DataGridViewColumn>().Aggregate(0, (current, col) => current + col.Width);
            dgv.Width = panel.Width = (width + 20);
        }

        private void Linje_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeForm();
            Fill_DataGridViews();

            _ = Activity.Stop($"Produktionslinje - {cb_Linje.Text} - Från {date_From.Value} - {date_To.Value}");
        }
    }
}