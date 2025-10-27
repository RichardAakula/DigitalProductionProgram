using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using ProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.User
{
    public partial class My_Analysis : Form
    {
        private readonly DateTime Date_month_1 = new DateTime(1, Month_1, 1);
        private readonly DateTime Date_month_2 = new DateTime(1, Month_2, 1);
        private static DateTime Start_Order(int orderid)
        {
            var start = new DateTime();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT Date, NULL, TempID FROM Measureprotocol.MainData WHERE OrderID = @orderid AND MONTH(Date) = @month AND YEAR(Date) = @year
                    UNION 
                    SELECT CAST(Date_Time AS Date), CAST(Date_Time AS time), TempID FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @orderid AND Column_Index IS NULL AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year
                   
                    ORDER BY TempID";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@month", Month_1);
                cmd.Parameters.AddWithValue("@year", Year_1);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime.TryParse(reader[0].ToString(), out var date);
                    if (DateTime.TryParse(reader[1].ToString(), out var time))
                        return date.Date.Add(time.TimeOfDay);
                    return date;
                }
            }
            return start;
        }
        private static DateTime Stop_Order(int orderid)
        {
            var stop = new DateTime();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT Date, NULL, TempID FROM Measureprotocol.MainData WHERE OrderID = @orderid AND MONTH(Date) = @month AND YEAR(Date) = @year 
                    UNION 
                    SELECT CAST(Date_Time AS Date), CAST(Date_Time AS time), TempID FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @orderid AND Column_Index IS NULL AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year
                   
                    ORDER BY TempID DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@month", Month_1);
                cmd.Parameters.AddWithValue("@year", Year_1);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime.TryParse(reader[0].ToString(), out var date);
                    if (DateTime.TryParse(reader[1].ToString(), out var time))
                        return date.Date.Add(time.TimeOfDay);
                    return date;
                }
            }
            return stop;
        }


        private DataTable dt_Mätdata_Operatörer;
        DataTable dt_OrderList;
        DataTable dt_OrderInfo;
        private readonly Stopwatch Watch = new Stopwatch();

       
        private static string AnstNr;

        private static int Month_1
        {
            get
            {
                var month = DateTime.Now.Month - 1;
                if (month == 0)
                    month = 12;
                return month;
            }
        }
        private static int Month_2
        {
            get
            {
                var month = DateTime.Now.Month - 2;
                if (month == 0)
                    month = 12;
                if (month == -1)
                    month = 11;
                return month;
            }
        }
        private static int Year_1
        {
            get
            {
                if (Month_1 == 12)
                    return DateTime.Now.Year - 1;
                return DateTime.Now.Year;
            }
        }
        private static int Year_2
        {
            get
            {
                if (Month_2 > 10)
                    return DateTime.Now.Year - 1;
                return DateTime.Now.Year;
            }
        }
        private static string Time_of_day
        {
            get
            {
                var morgon_Start = new TimeSpan(06, 0, 1);
                var morgon_Slut = new TimeSpan(10, 0, 0);
                var förmiddag_Start = new TimeSpan(10, 0, 1);
                var förmiddag_Slut = new TimeSpan(12, 0, 0);
                var dag_Start = new TimeSpan(12, 0, 1);
                var dag_Slut = new TimeSpan(14, 0, 0);
                var eftermiddag_Start = new TimeSpan(14, 0, 1);
                var eftermiddag_Slut = new TimeSpan(18, 0, 0);
                var kväll_Start = new TimeSpan(18, 0, 1);
                var kväll_Slut = new TimeSpan(22, 0, 0);
                var natt_Start = new TimeSpan(22, 0, 1);
                var natt_Slut = new TimeSpan(06, 0, 0);

                var now = DateTime.Now.TimeOfDay;
                if (now > morgon_Start && now < morgon_Slut)
                    return "God morgon";
                if (now > förmiddag_Start && now < förmiddag_Slut)
                    return "God förmiddag";
                if (now > dag_Start && now < dag_Slut)
                    return "God dag";
                if (now > eftermiddag_Start && now < eftermiddag_Slut)
                    return "God eftermiddag";
                if (now > kväll_Start && now < kväll_Slut)
                    return "God kväll";
                if (now > natt_Start && now < natt_Slut)
                    return "God natt";
                return string.Empty;
            }
        }

        private static double Antal_Mätningar_Tid_per_Order_per_Operatör(int orderid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT (SELECT COUNT(*) FROM Measureprotocol.MainData WHERE OrderID = @orderid AND AnstNr = @employeenumber AND MONTH(Date) = @month AND YEAR(Date) = @year)
                    + (SELECT COUNT(*) FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @orderid AND Column_Index IS NULL AND AnstNr = @employeenumber AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@employeenumber", AnstNr);
                cmd.Parameters.AddWithValue("@month", Month_1);
                cmd.Parameters.AddWithValue("@year", Year_1);
                var antal = (int)cmd.ExecuteScalar();
                return antal;
            }
        }
        private static double TotalMeasurementsPerOrder(int id)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT (SELECT COUNT(*) FROM Measureprotocol.MainData WHERE OrderID = @orderid AND MONTH(Date) = @month AND YEAR(Date) = @year)
                    + (SELECT COUNT(*) FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @orderid AND Column_Index IS NULL AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", id);
                cmd.Parameters.AddWithValue("@month", Month_1);
                cmd.Parameters.AddWithValue("@year", Year_1);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static double TotalActivity(int month, int year)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"SELECT COUNT(*) FROM Log.ActivityLog  WHERE INFO LIKE '%{Person.Get_NameWithAnstNr(AnstNr)}%' AND MONTH(Date) = @month AND YEAR(Date) = @year";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                return (int)cmd.ExecuteScalar();
            }
        }
        private static double TotalOrdersStarted(int month, int year)
        {
            if (string.IsNullOrEmpty(AnstNr))
                return 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT COUNT(*) FROM [Order].MainData WHERE MONTH(Date_Start) = @month AND YEAR(Date_Start) = @year AND Name_Start = @namn";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@namn", Person.Get_NameWithAnstNr(AnstNr));
                return (int)cmd.ExecuteScalar();
            }
        }
        private static double TotalOrdersRunned(int month, int year)
        {
            var startadeOrdrar = (int)TotalOrdersStarted(month, year);
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT
                    (SELECT COUNT (DISTINCT OrderID) FROM Measureprotocol.MainData WHERE MONTH(Date) = @month AND YEAR(Date) = @year AND AnstNr = @employeenumber)
                    + (SELECT COUNT (DISTINCT OrderID) FROM Korprotokoll_Slipning_Produktion WHERE Column_Index IS NULL AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year AND AnstNr = @employeenumber)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@employeenumber", AnstNr);
                if ((int)cmd.ExecuteScalar() < startadeOrdrar)
                    return (int)cmd.ExecuteScalar() + (int)TotalOrdersStarted(month, year);
                return (int)cmd.ExecuteScalar();
            }
        }
        private static double TotalMeasurements(int month, int year)
        {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT
                        (SELECT COUNT(*) FROM Measureprotocol.MainData WHERE MONTH(Date) = @month AND YEAR(Date) = @year AND AnstNr = @employeenumber)
                        + (SELECT COUNT (DISTINCT OrderID) FROM Korprotokoll_Slipning_Produktion WHERE Column_Index IS NULL AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year AND AnstNr = @employeenumber)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@employeenumber", AnstNr);
                    return (int)cmd.ExecuteScalar();
                }
        }
        private static double TotalProcesscardCreated(int month, int year)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"SELECT COUNT(*) FROM Processcard.MainData WHERE MONTH(RevÄndratDatum) = @month AND YEAR(RevÄndratDatum) = @year AND UpprättatAv_Sign_AnstNr LIKE '%{AnstNr}'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                return (int)cmd.ExecuteScalar();
            }
        }
        private double TotalTimeOrder(int rad)
        {
            double tid_Körprotokoll = 0;
            var id = (int)dt_OrderInfo.Rows[rad]["OrderID"];
            
            var tid_Mätprotokoll = Math.Round((Stop_Order(id) - Start_Order(id)).TotalHours, 2);
            if (tid_Mätprotokoll < 1)
                tid_Mätprotokoll = 1;

            if ((int)dt_OrderInfo.Rows[rad]["Antal_Mätningar"] == (int)Antal_Mätningar_Tid_per_Order_per_Operatör(id))
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                            SELECT Date_Start, Date_Stop 
                            FROM [Order].MainData 
                            {Queries.WHERE_OrderID} 
                                AND MONTH(Date_Start) = @month AND YEAR(Date_Start) = @year 
                                AND MONTH(Date_Stop) = @month AND YEAR(Date_Stop) = @year";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@month", Month_1);
                    cmd.Parameters.AddWithValue("@year", Year_1);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var stop = DateTime.Parse(reader[1].ToString());
                        var start = DateTime.Parse(reader[0].ToString());

                        tid_Körprotokoll = Math.Round((stop - start).TotalHours, 2);
                    }
                }
            }
            if (tid_Körprotokoll > 0 && tid_Körprotokoll < 20)
                return tid_Körprotokoll;

            return tid_Mätprotokoll;
        }
        

        public My_Analysis()
        {
            InitializeComponent();
            
            Watch.Start();
            Log.Activity.Start();

            if (Person.Role == "SuperAdmin")
                tb_User.Visible = true;
            else
                Load_Data();
        }


        private void Load_Data()
        {
            Initialize_DataTables();
            AnstNr = Person.EmployeeNr;
            // anstNr = 676;
            lbl_Initialer.Text = Person.Get_SignWithName(Person.Get_NameWithAnstNr(AnstNr));
            var pbar = new ProgressBar();
            pbar.Show();

            pbar.Set_ValueProgressBar(0, "Startar My Analysis");
            Initialize_Chart_Startade_Ordrar();
            pbar.Set_ValueProgressBar(10, "Laddar data till My Analysis...");
            Initialize_Chart_Körda_Ordrar();
            pbar.Set_ValueProgressBar(20, "Laddar data till My Analysis...");
            Initialize_Chart_Antal_Mätningar();
            pbar.Set_ValueProgressBar(30, "Laddar data till My Analysis...");
            Initialize_Chart_Rubrik();
            pbar.Set_ValueProgressBar(50, "Laddar data till My Analysis...");
            Initialize_Chart_Samarbete();
            pbar.Set_ValueProgressBar(70, "Laddar data till My Analysis...");
            Initialize_Chart_ProduktionsLinjer_Aktivitet();
            pbar.Set_ValueProgressBar(80, "Laddar data till My Analysis...");
            Initialize_Chart_Processkort();
            pbar.Set_ValueProgressBar(95, "Laddar data till My Analysis...");
            Initialize_Chart_Parts();

            pbar.Close();
            timer_Start_timer_AutoScroll.Start();
            tlp_Main.MouseWheel += mouseWheel;
        }


        private void Initialize_DataTables()
        {
            dt_Mätdata_Operatörer = new DataTable();
            dt_OrderList = new DataTable();
            dt_OrderInfo = new DataTable();

            dt_Mätdata_Operatörer.Columns.Add("AnstNr", typeof(int));
            dt_Mätdata_Operatörer.Columns.Add("Antal", typeof(int));
            dt_OrderList.Columns.Add("OrderID", typeof(int));

            dt_OrderInfo.Columns.Add("OrderID", typeof(int));
            dt_OrderInfo.Columns.Add("Linje", typeof(string));
            dt_OrderInfo.Columns.Add("TotalTid_h", typeof(double));
            dt_OrderInfo.Columns.Add("Antal_Mätningar", typeof(int));
            dt_OrderInfo.Columns.Add("Medeltid_Mätning", typeof(double));
            dt_OrderInfo.Columns.Add("Operatör_Tid_h", typeof(double));
        }
        private void Initialize_Chart_Rubrik()
        {
            foreach (var t in chart_Rubrik.Series)
                t.Points.Clear();
            var total_Aktivitet = TotalActivity(Month_2, Year_2) + TotalActivity(Month_1, Year_1);
            var percent_Month_1 = Math.Round(TotalActivity(Month_1, Year_1) / total_Aktivitet * 100, 0);
            var percent_Month_2 = Math.Round(TotalActivity(Month_2, Year_2) / total_Aktivitet * 100, 0);

            chart_Rubrik.Series[0].Points.AddXY($"{Date_month_2:MMM} {Year_2} -  {percent_Month_2}%", percent_Month_2);
            chart_Rubrik.Series[0].Points.AddXY($"{Date_month_1:MMM} {Year_1} - {percent_Month_1}%", percent_Month_1);
            chart_Rubrik.Series[0]["PieLabelStyle"] = "Disabled";

            label_Header_Info.Text = $"{Time_of_day} {Person.Get_NameWithAnstNr(AnstNr)}. Här är lite statistik från de 2 senaste månaderna om hur din aktivitet har sett ut. ";
        }

        private void Initialize_Chart_Startade_Ordrar()
        {
            foreach (var t in chart_Startade_Ordrar.Series)
                t.Points.Clear();

            chart_Startade_Ordrar.Series[0].Points.Add(TotalOrdersStarted(Month_2, Year_2));
            chart_Startade_Ordrar.Series[1].Points.Add(0);
            chart_Startade_Ordrar.Series[2].Points.Add(TotalOrdersStarted(Month_1, Year_1));
            chart_Startade_Ordrar.Series[0]["PointWidth"] = "0.3";
            chart_Startade_Ordrar.Series[1]["PointWidth"] = "0.2";
            chart_Startade_Ordrar.Series[2]["PointWidth"] = "0.3";

            chart_Startade_Ordrar.Series[0].Name = $" {Date_month_2:MMM} {Year_2} - {TotalOrdersStarted(Month_2, Year_2)} st";
            chart_Startade_Ordrar.Series[2].Name = $" {Date_month_1:MMM} {Year_1} - {TotalOrdersStarted(Month_1, Year_1)} st";

            set_text_startadeOrdrar();
        }
        private void set_text_startadeOrdrar()
        {
            var max = Math.Max(TotalOrdersStarted(Month_1, Year_1), TotalOrdersStarted(Month_2, Year_2));
            var min = Math.Min(TotalOrdersStarted(Month_1, Year_1), TotalOrdersStarted(Month_2, Year_2));
            var diff = max - min;
            var percent = Math.Round(diff / min * 100, 0);

            if (TotalOrdersStarted(Month_1, Year_1) > TotalOrdersStarted(Month_2, Year_2))
            {
                label_AntalStartadeOrdrar_Info.Text = $"En ökning på \n{percent} % mot förra månaden.";
                label_AntalStartadeOrdrar_Info.ForeColor = CustomColors.Ok_Front;
            }
            else if (TotalOrdersStarted(Month_1, Year_1) < TotalOrdersStarted(Month_2, Year_2))
            {
                label_AntalStartadeOrdrar_Info.Text = $"En minskning på \n{percent} % mot förra månaden.";
                label_AntalStartadeOrdrar_Info.ForeColor = CustomColors.Bad_Front;
            }
            else
            {
                label_AntalStartadeOrdrar_Info.Text = "Du har startat lika många ordrar som förra månaden";
                label_AntalStartadeOrdrar_Info.ForeColor = CustomColors.Neutral_Front;
            }
        }

        private void Initialize_Chart_Körda_Ordrar()
        {
            foreach (var t in chart_Körda_Ordrar.Series)
                t.Points.Clear();

            chart_Körda_Ordrar.Series[0].Points.Add(TotalOrdersRunned(Month_2, Year_2));
            chart_Körda_Ordrar.Series[1].Points.Add(0);
            chart_Körda_Ordrar.Series[2].Points.Add(TotalOrdersRunned(Month_1, Year_1));
            chart_Körda_Ordrar.Series[0]["PointWidth"] = "0.3";
            chart_Körda_Ordrar.Series[1]["PointWidth"] = "0.2";
            chart_Körda_Ordrar.Series[2]["PointWidth"] = "0.3";

            chart_Körda_Ordrar.Series[0].Name = $" {Date_month_2.ToString("MMM")} {Year_2} - {TotalOrdersRunned(Month_2, Year_2)} st";
            chart_Körda_Ordrar.Series[2].Name = $" {Date_month_1.ToString("MMM")} {Year_1} - {TotalOrdersRunned(Month_1, Year_1)} st";

            set_text_körda_Ordrar();
                
        }
        private void set_text_körda_Ordrar()
        {
            var max = Math.Max(TotalOrdersRunned(Month_1, Year_1), TotalOrdersRunned(Month_2, Year_2));
            var min = Math.Min(TotalOrdersRunned(Month_1, Year_1), TotalOrdersRunned(Month_2, Year_2));

            var diff = max - min;
            var percent = Math.Round(diff / min * 100, 0);

            if (TotalOrdersRunned(Month_1, Year_1) > TotalOrdersRunned(Month_2, Year_2))
            {
                label_KördaOrdrar_Info.Text = $"En ökning på \n{percent} % mot förra månaden.";
                label_KördaOrdrar_Info.ForeColor = CustomColors.Ok_Front;
            }
            else if (TotalOrdersRunned(Month_1, Year_1) < TotalOrdersRunned(Month_2, Year_2))
            {
                label_KördaOrdrar_Info.Text =  $"En minskning på \n{percent} % mot förra månaden.";
                label_KördaOrdrar_Info.ForeColor = CustomColors.Bad_Front;
            }
            else
            {
                label_KördaOrdrar_Info.Text = "Du har kört lika många ordrar som förra månaden";
                label_KördaOrdrar_Info.ForeColor = CustomColors.Neutral_Front;
            }
        }

        private void Initialize_Chart_Antal_Mätningar()
        {
            foreach (var t in chart_Antal_Mätningar.Series)
                t.Points.Clear();
            chart_Antal_Mätningar.Series[0].Points.Add(TotalMeasurements(Month_2, Year_2));
            chart_Antal_Mätningar.Series[1].Points.Add(0);
            chart_Antal_Mätningar.Series[2].Points.Add(TotalMeasurements(Month_1, Year_1));
            chart_Antal_Mätningar.Series[0]["PointWidth"] = "0.3";
            chart_Antal_Mätningar.Series[1]["PointWidth"] = "0.2";
            chart_Antal_Mätningar.Series[2]["PointWidth"] = "0.3";

            chart_Antal_Mätningar.Series[0].Name = $"{Date_month_2:MMM} {Year_2} - {TotalMeasurements(Month_2, Year_2)} st";
            chart_Antal_Mätningar.Series[2].Name = $"{Date_month_1:MMM} {Year_1} - {TotalMeasurements(Month_1, Year_1)} st";

            set_Text_antal_Mätningar();
        }
        private void set_Text_antal_Mätningar()
        {
            var max = Math.Max(TotalMeasurements(Month_1, Year_1), TotalMeasurements(Month_2, Year_2));
            var min = Math.Min(TotalMeasurements(Month_1, Year_1), TotalMeasurements(Month_2, Year_2));
            var diff = max - min;
            var percent = Math.Round(diff / min * 100, 0);
            if (TotalMeasurements(Month_1, Year_1) > TotalMeasurements(Month_2, Year_2))
            {
                label_AntalMätningar_Info.ForeColor = CustomColors.Ok_Front;
                label_AntalMätningar_Info.Text = $"En ökning på \n{percent} % mot förra månaden.";
            }
            else if (TotalMeasurements(Month_1, Year_1) < TotalMeasurements(Month_2, Year_2))
            {
                label_AntalMätningar_Info.ForeColor = CustomColors.Bad_Front;
                label_AntalMätningar_Info.Text = $"En minskning på \n{percent} % mot förra månaden.";
            }
            else
            {
                label_AntalMätningar_Info.ForeColor = CustomColors.Neutral_Front;
                label_AntalMätningar_Info.Text = "Du har gjort lika många mätningar som förra månaden";
            }
        }

        private void Initialize_Chart_Samarbete()
        {
            chart_Samarbete.Series[0].Points.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DISTINCT OrderID FROM Measureprotocol.MainData WHERE AnstNr = @employeenumber AND MONTH(Date) = @month AND YEAR(Date) = @year 
                    UNION 
                    SELECT DISTINCT OrderID FROM Korprotokoll_Slipning_Produktion WHERE Column_Index IS NULL AND AnstNr = @employeenumber AND MONTH(Date_Time) = @month AND YEAR(Date_Time) = @year";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@employeenumber", AnstNr);
                cmd.Parameters.AddWithValue("@month", Month_1);
                cmd.Parameters.AddWithValue("@year", Year_1);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Add_operatörer_List((int)reader[0]);
                    dt_OrderList.Rows.Add();
                    dt_OrderList.Rows[dt_OrderList.Rows.Count - 1]["OrderID"] = reader[0].ToString();
                }
            }

            dt_Mätdata_Operatörer.DefaultView.Sort = "Antal DESC";
            dt_Mätdata_Operatörer = dt_Mätdata_Operatörer.DefaultView.ToTable();
            if (dt_Mätdata_Operatörer.Rows.Count == 0)
            {
                tlp_Main.RowStyles[2].Height = 10;
                return;
            }
            tlp_Main.RowStyles[2].Height = 244;
            var total = double.Parse(dt_Mätdata_Operatörer.Compute("Sum(Antal)", string.Empty).ToString());

            var antal_rader = dt_Mätdata_Operatörer.Rows.Count;
            if (antal_rader > 10)
                antal_rader = 10;
            for (var i = 0; i < antal_rader; i++)
            {
                int antal_operatör = Convert.ToInt16(dt_Mätdata_Operatörer.Rows[i][1]);
                var percent = Math.Round(antal_operatör / total * 100, 0);

                chart_Samarbete.Series[0].Points.AddXY($"{percent} % - {Person.Get_NameWithAnstNr(dt_Mätdata_Operatörer.Rows[i][0].ToString())}", percent);
                chart_Samarbete.Series[0]["PieLabelStyle"] = "Disabled";
            }

            label_Samarbete_Info.Text = $"Medarbetare du har samkört ordrar med i {Date_month_1:MMMM} {Year_1}";
        }
        private void Initialize_Chart_ProduktionsLinjer_Aktivitet()
        {
            foreach (var serie in chart_Linjer_Aktivitet.Series)
                serie.Points.Clear();
            //Hämtar ProduktionsLinjer från alla Arbetsoperationer
            for (var i = 0; i < dt_OrderList.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                                SELECT ProdLine FROM [Order].MainData WHERE OrderID = @orderid AND Date_Stop IS NOT NULL";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", dt_OrderList.Rows[i]["OrderID"].ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dt_OrderInfo.Rows.Add();
                        dt_OrderInfo.Rows[dt_OrderInfo.Rows.Count - 1]["Linje"] = reader[0].ToString();
                        dt_OrderInfo.Rows[dt_OrderInfo.Rows.Count - 1]["OrderID"] = dt_OrderList.Rows[i]["OrderID"].ToString();
                    }
                }
            }

            for (var i = 0; i < dt_OrderInfo.Rows.Count; i++)
            {
                //Hämtar Antal mätningar från varje Order
                dt_OrderInfo.Rows[i]["Antal_Mätningar"] = TotalMeasurementsPerOrder((int)dt_OrderInfo.Rows[i]["OrderID"]);

                //Hämtar Totaltid för ordern
                dt_OrderInfo.Rows[i]["TotalTid_h"] = TotalTimeOrder(i);

                //Beräkna Medeltid per mätning per Order

                var tid = double.Parse(dt_OrderInfo.Rows[i]["TotalTid_h"].ToString()) / double.Parse(dt_OrderInfo.Rows[i]["Antal_Mätningar"].ToString());
                dt_OrderInfo.Rows[i]["Medeltid_Mätning"] = tid;

                //Beräknar Operatörens tid för en Order
                if (double.Parse(dt_OrderInfo.Rows[i]["TotalTid_h"].ToString()) > 8)
                    dt_OrderInfo.Rows[i]["Operatör_Tid_h"] = Math.Round(Antal_Mätningar_Tid_per_Order_per_Operatör((int)dt_OrderInfo.Rows[i]["OrderID"]) * double.Parse(dt_OrderInfo.Rows[i]["Medeltid_Mätning"].ToString()) / 3, 2);
                else
                    dt_OrderInfo.Rows[i]["Operatör_Tid_h"] = Math.Round(Antal_Mätningar_Tid_per_Order_per_Operatör((int)dt_OrderInfo.Rows[i]["OrderID"]) * double.Parse(dt_OrderInfo.Rows[i]["Medeltid_Mätning"].ToString()), 2);
            }

            var dt_new = new DataTable();
            dt_new.Columns.Add("Linje", typeof(string));
            dt_new.Columns.Add("Operatör_Tid_h", typeof(double));

            for (var i = 0; i < dt_OrderInfo.Rows.Count; i++)
            {
                var linje = dt_OrderInfo.Rows[i]["Linje"].ToString();
                var is_Exist = dt_new.AsEnumerable().Any(c => c.Field<string>("Linje").Equals(linje));
                if (is_Exist == false)
                {
                    dt_new.Rows.Add();
                    dt_new.Rows[dt_new.Rows.Count - 1]["Linje"] = linje;
                }
            }
            dt_new.DefaultView.Sort = "Operatör_Tid_h DESC";
            dt_new = dt_new.DefaultView.ToTable();
            for (var i = 0; i < dt_new.Rows.Count; i++)
            {
                var total = double.Parse(dt_OrderInfo.AsEnumerable()
                    .Where(y => y.Field<string>("Linje") == dt_new.Rows[i]["Linje"].ToString())
                    .Sum(x => x.Field<double>("Operatör_Tid_h")).ToString());
                dt_new.Rows[i]["Operatör_Tid_h"] = Math.Round(total,0);

                chart_Linjer_Aktivitet.Series[0].Points.AddXY($"{dt_new.Rows[i]["Operatör_Tid_h"]} h - {dt_new.Rows[i]["Linje"]}", double.Parse(dt_new.Rows[i]["Operatör_Tid_h"].ToString()));
                chart_Linjer_Aktivitet.Series[0]["PieLabelStyle"] = "Disabled";
            }
            if (dt_new.Rows.Count == 0)
                tlp_Main.RowStyles[3].Height = 10;
            else
                tlp_Main.RowStyles[3].Height = 244;

            label_Info_ProdLines.Text = $"Produktionslinjer som du har spenderat tid vid i {Date_month_1:MMMM} {Year_1}";
        }

        private void Initialize_Chart_Processkort()
        {
            foreach (var serie in chart_Skapade_Processkort.Series)
                serie.Points.Clear();
            chart_Skapade_Processkort.Series[0].Points.Add(TotalProcesscardCreated(Month_2, Year_2));
            chart_Skapade_Processkort.Series[1].Points.Add(0);
            chart_Skapade_Processkort.Series[2].Points.Add(TotalProcesscardCreated(Month_1, Year_1));
            chart_Skapade_Processkort.Series[0]["PointWidth"] = "0.3";
            chart_Skapade_Processkort.Series[1]["PointWidth"] = "0.2";
            chart_Skapade_Processkort.Series[2]["PointWidth"] = "0.3";

            chart_Skapade_Processkort.Series[0].Name = $"{Date_month_2:MMM} {Year_2} - {TotalProcesscardCreated(Month_2, Year_2)} st";
            chart_Skapade_Processkort.Series[2].Name = $"{Date_month_1:MMM} {Year_1} - {TotalProcesscardCreated(Month_1, Year_1)} st";

            Set_InfoText_Created_Processcards();

            if (TotalProcesscardCreated(Month_2, Year_2) == 0 && TotalProcesscardCreated(Month_1, Year_1) == 0)
                tlp_Main.RowStyles[4].Height = 10;
            else
                tlp_Main.RowStyles[4].Height = 217;
        }
        private void Set_InfoText_Created_Processcards()
        {
            var max = Math.Max(TotalProcesscardCreated(Month_1, Year_1), TotalProcesscardCreated(Month_2, Year_2));
            var min = Math.Min(TotalProcesscardCreated(Month_1, Year_1), TotalProcesscardCreated(Month_2, Year_2));
            var diff = max - min;
            var percent = Math.Round(diff / min * 100, 0);
            if (TotalProcesscardCreated(Month_1, Year_1) > TotalProcesscardCreated(Month_2, Year_2))
            {
                label_Processkort_Info.ForeColor = CustomColors.Ok_Front;
                label_Processkort_Info.Text = $"En ökning på \n{percent} % mot förra månaden.";
            }
            else if (TotalProcesscardCreated(Month_1, Year_1) < TotalProcesscardCreated(Month_2, Year_2))
            {
                label_Processkort_Info.ForeColor = CustomColors.Bad_Front;
                label_Processkort_Info.Text = $"En minskning på \n{percent} % mot förra månaden.";
            }
            else
            {
                label_Processkort_Info.ForeColor = CustomColors.Neutral_Front;
                label_Processkort_Info.Text = "Du har skapat lika många processkort som förra månaden";
            }
        }

       
       

        private void Initialize_Chart_Parts()
        {
            foreach (var serie in chart_Parts.Series)
                serie.Points.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT TOP 10 
                            o.PartNr,
                            COUNT(*) + 
                            (
                                SELECT COUNT(DISTINCT mp.OrderID)
                                FROM MeasureProtocol.MainData mp
                                WHERE mp.OrderID IN 
                                    (
                                        SELECT o2.OrderID
                                        FROM [Order].MainData o2
                                        WHERE o2.PartNr = o.PartNr
                                        AND (o2.Name_Start = @name OR o2.LC_Name = 'Joacim Mattsson'
                                    )
                            )
                            ) AS TotalCount
                        FROM [Order].MainData o
                        WHERE o.Name_Start = @name OR o.LC_Name = @name
                        GROUP BY o.PartNr
                        ORDER BY TotalCount DESC;";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@name", Person.Name);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chart_Parts.Series[0].Points.AddXY($"{reader[1]} st - {reader[0]}", int.Parse(reader[1].ToString()));
                }
            }
            chart_Parts.Series[0]["PieLabelStyle"] = "Disabled";
        }

        private void Add_operatörer_List(int id)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DISTINCT AnstNr FROM Measureprotocol.MainData WHERE OrderID = @orderid
                               UNION
                               SELECT DISTINCT AnstNr FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var is_Exist = dt_Mätdata_Operatörer.AsEnumerable().Any(c => c.Field<int>("AnstNr").Equals(int.Parse(reader[0].ToString())));
                    if (!is_Exist && reader[0].ToString() != AnstNr)
                    {
                        dt_Mätdata_Operatörer.Rows.Add();
                        dt_Mätdata_Operatörer.Rows[dt_Mätdata_Operatörer.Rows.Count - 1][0] = reader[0].ToString();
                    }
                    Add_antal_mätningar_List(id, reader[0].ToString());
                }
            }
        }
        private void Add_antal_mätningar_List(int id, string anstNr)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT (SELECT COUNT(*) FROM Measureprotocol.MainData WHERE AnstNr = @employeenumber AND OrderID = @orderid) 
                                + (SELECT COUNT(*) FROM Korprotokoll_Slipning_Produktion WHERE AnstNr = @employeenumber AND Column_Index IS NULL AND OrderID = @orderid)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", id);
                cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                var antal = (int)cmd.ExecuteScalar();

                for (var i = 0; i < dt_Mätdata_Operatörer.Rows.Count; i++)
                {
                    if (dt_Mätdata_Operatörer.Rows[i][0].ToString() == anstNr)
                    {
                        int.TryParse(dt_Mätdata_Operatörer.Rows[i][1].ToString(), out var old);
                        dt_Mätdata_Operatörer.Rows[i][1] = old + antal;
                    }
                }
            }
        }




        private void User_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;

            using var choose_Item = new Choose_Item(Person.List_Users(true), new[] { ctrl }, false);
            choose_Item.ShowDialog();
          
        }
        private void User_TextChanged(object sender, EventArgs e)
        {
            Person.Name = tb_User.Text;
            Person.Load_EmployeeNumber(Person.Name);
            Load_Data();
        }
        private void timer_AutoScroll_Tick(object sender, EventArgs e)
        {
            if (tlp_Main.VerticalScroll.Value < tlp_Main.VerticalScroll.Maximum)
                tlp_Main.VerticalScroll.Value++;

            if (tlp_Main.VerticalScroll.Value == 540)
                timer_AutoScroll.Stop();
        }
        private void timer_Start_timer_AutoScroll_Tick(object sender, EventArgs e)
        {
            timer_AutoScroll.Start();
        }
        private void mouseWheel(object sender, MouseEventArgs e)
        {
            timer_AutoScroll.Stop();
            timer_Start_timer_AutoScroll.Stop();
        }
        private void tlp_Main_Scroll(object sender, ScrollEventArgs e)
        {
            timer_AutoScroll.Stop();
            timer_Start_timer_AutoScroll.Stop();
        }




        private void My_Analysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            Watch.Stop();

            if (Person.Role == "SuperAdmin")
            {
                Person.Name = "Richard Aakula";
                Person.Load_EmployeeNumber(Person.Name);
            }
            else
            {
                _ = Log.Activity.Stop("My Analysis");
                SaveData.INSERT_Operatör_Tid_Läsa_MyAnalysis(Watch.Elapsed.TotalSeconds);
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}


