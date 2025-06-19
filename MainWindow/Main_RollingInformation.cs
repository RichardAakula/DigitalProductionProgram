using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Measure;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_RollingInformation : UserControl
    {
        internal static int TotalOrdersPerYear(string årtal)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT COUNT(*) FROM [Order].MainData WHERE YEAR(Date_Start) = @year";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@year", årtal);
            con.Open();
            return (int)cmd.ExecuteScalar();
        }
        internal static int TotalOrdersSpecificWeekDay()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT COUNT(*) FROM [Order].MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) AND DATENAME(DW, Date_Start) = @weekdayname";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            SQL_Parameter.String(cmd.Parameters, "@workoperation", Order.WorkOperation.ToString());
            cmd.Parameters.AddWithValue("@weekdayname", Tips.WeekDayName);
            con.Open();
            return (int)cmd.ExecuteScalar();
        }
        internal static int MinYear_OrderStart { get; set; }
        internal static void Load_MinYear_OrderStart()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT YEAR(Date_Start) FROM [Order].MainData ORDER BY YEAR(Date_Start)";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            object value = cmd.ExecuteScalar();
            if (value != null)
                MinYear_OrderStart = (int)cmd.ExecuteScalar();
        }


        private static int Total_Tips;
        private static int CounterTips;

        public static Dictionary<string, double> AverageCommentLengthsPerOperation()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
        SELECT wn.Name, AVG(LEN(md.Comments)) AS AvgLength
        FROM [Order].MainData md
        JOIN Workoperation.Names wn ON md.WorkOperationID = wn.ID
        WHERE md.Comments IS NOT NULL AND wn.ID IS NOT NULL
        GROUP BY wn.Name";

            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            con.Open();

            var result = new Dictionary<string, double>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(0);
                var avg = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader[1]);
                result[name] = avg;
            }

            return result;
        }

        private Tips? tips;
        public class Tip
        {
            public string Content { get; set; }

            public Tip(string content)
            {
                Content = content;
            }
        }
        private class Tips
        {
            private readonly List<Tip> tipsList = new List<Tip>();
            private static DayOfWeek WeekDay
            {
                get
                {
                    var random = new Random();
                    var randomDayNumber = random.Next(0, 7);
                    var randomWeekday = (DayOfWeek)randomDayNumber;

                    return randomWeekday;
                }
            }
            private static string Year
            {
                get
                {
                    var rnd = new Random();
                    return rnd.Next(MinYear_OrderStart, DateTime.Now.Year).ToString();
                }
            }
            public static string? WeekDayName { get; private set; }
            public string GetRandomTip()
            {
                var random = new Random();
                var index = random.Next(tipsList.Count);
                if (tipsList.Count > 0)
                    return tipsList[index].Content;
                return "";
            }

            public static void Load_WeekDay()
            {
                WeekDayName = DateTimeFormatInfo.GetInstance(new CultureInfo("en-US")).GetDayName(WeekDay);
            }
            public void AddTip(string content)
            {
                tipsList.Add(new Tip(content));
                Total_Tips++;
            }


            public static void AddTips_FutureInfo(Tips? tips)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                //ID > 200 är pga av att jag missat att läggga in ReleasDatum på dom allra första releaserna
                const string query = "SELECT Tags, Description FROM Log.ChangeLog WHERE ReleaseDate IS NULL AND VisibleToUser = 'True' AND ID > 200";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    tips.AddTip($"{LanguageManager.GetString("rollingTips_FutureUpdate")} {reader["Tags"]}: {reader["Description"]}");
            }
            public static void AddTips_OrderStartDays(Tips? tips)
            {
                if (!string.IsNullOrEmpty(Order.OrderNumber) || Order.List_Orders != null)
                {
                    var antal = TotalOrdersSpecificWeekDay();
                    double percent;
                    if (Order.List_Orders == null)
                        percent = double.NaN;
                    else
                        percent = antal / (double)Order.List_Orders.Count * 100;
                    tips.AddTip($"På {WeekDayName}ar startas {percent:0.0}% av alla ordrar för {Order.WorkOperation}");
                }
            }
            public static void AddTips_TotalOrdersPerYear(Tips? tips)
            {
                if (TotalOrdersPerYear(Year) > 0)
                    tips.AddTip($"{TotalOrdersPerYear(Year)} {LanguageManager.GetString("rollingTips_5")} {Year} {LanguageManager.GetString("rollingTips_6")}");
            }
            public static void AddTips_UserInfo(Tips? tips)
            {
                if (!string.IsNullOrEmpty(Person.Name))
                {
                    tips.AddTip($"{LanguageManager.GetString("rollingTips_1")} {Person.Antal_Mätningar_Operatör} {LanguageManager.GetString("rollingTips_2")}");
                    tips.AddTip($"{LanguageManager.GetString("rollingTips_3")} {Person.Antal_Inloggningar} {LanguageManager.GetString("rollingTips_4")}");
                }
            }
        }




        public Main_RollingInformation()
        {
            InitializeComponent();
        }
        private void Main_RollingInformation_Load(object sender, EventArgs e)
        {
            if (DesignMode || Program.IsInDesignMode())
                return;
            Zumbach.Zumbach.Load_MeasureStats();
            Load_MinYear_OrderStart();
        }



        public void Load_list_Tips()
        {
            if (Machines.List_ProdLine.Count == 0)
                return;
            Tips.Load_WeekDay();
            CounterTips = 0;
            switch (Monitor.Monitor.factory)
            {
                case Monitor.Monitor.Factory.Godby:
                case Monitor.Monitor.Factory.Holding:
                    Load_Tips_Godby();
                    break;
                case Monitor.Monitor.Factory.Thailand:
                    Load_Tips_Thailand();
                    break;
            }

        }

        private void Load_Tips_Godby()
        {
            tips = new Tips();
            //Total_Tips = 0;
            var totalMeasuremnents = MeasureInformation.AllMeasurementCounts();
            var commentLengths = AverageCommentLengthsPerOperation();
           

            foreach (var kvp in totalMeasuremnents)
            {
                var workoperation = kvp.Key.Replace('_', ' '); // Om du vill snygga till namnet
                tips.AddTip($"Antal mätningar ({workoperation}): {kvp.Value} st.");
            }
            foreach (var kvp in commentLengths)
            {
                var workop = kvp.Key.Replace('_', ' ');
                var avg = Math.Round(kvp.Value, 1);
                tips.AddTip($"I snitt skrivs det {avg} bokstäver per order i kommentarsfältet för ordrar körda på {workop}.");
            }

            tips.AddTip("Du kan spara upp till 3 bilder för varje order.");
            tips.AddTip($"Just nu finns det {Order.Total_Orders} ordrar i systemet.");
            tips.AddTip("Rapportera gärna in bugfixar eller förbättringar via Hjälpmenyn.");
            tips.AddTip("Ordernummer med Blå färg kan du högerklicka på för att förhandsgranska.");
            tips.AddTip("Högerklicka på en textruta i processkortet för att få fram värdet från dom 10 senaste körningarna.");
            tips.AddTip("I inställningarna kan du välja vilka arbetsoperationer du vill se i snabböppnarutan");
            tips.AddTip("I modulen Mätinformation kan du klicka på varje rads rubrik för att visa datan i diagrammet under.");
            tips.AddTip("I processkortet för Krympslang kan du få info om röret du använder genom att klicka på positionsnumret till höger om röret du valt.");
            tips.AddTip($"Antal mätningar mätta med Zumbach just nu: {Zumbach.Zumbach.TotalMeasurements}");
            tips.AddTip($"Antal mätpunkter mätta med Zumbach just nu: {Zumbach.Zumbach.TotalMeasurePoints}");

            Tips.AddTips_OrderStartDays(tips);
            Tips.AddTips_TotalOrdersPerYear(tips);
            Tips.AddTips_UserInfo(tips);
            Tips.AddTips_FutureInfo(tips);

        }
        private void Load_Tips_Thailand()
        {
            tips = new Tips();
            var totalMeasuremnents = MeasureInformation.AllMeasurementCounts();
            foreach (var kvp in totalMeasuremnents)
            {
                var workoperation = kvp.Key.Replace('_', ' '); // Om du vill snygga till namnet
                tips.AddTip($"Measurements made in: ({workoperation}): {kvp.Value}.");
            }


            tips.AddTip($"Right now there is {Order.Total_Orders} saved orders in the system.");
            tips.AddTip("Please, report bugs and improvements for the program in the Menu Help-Report a bug/improvement");
            tips.AddTip($"Total Measurements made with Zumbach now: {Zumbach.Zumbach.TotalMeasurements}");
            tips.AddTip($"Total Measurepoints made with Zumbach now: {Zumbach.Zumbach.TotalMeasurePoints}");

            Tips.AddTips_FutureInfo(tips);
            Tips.AddTips_UserInfo(tips);

        }
        public void Change_Theme()
        {
            this.BackColor = Teman.backColor_Menu;
            lbl_Tips.ForeColor = Teman.foreColor_Menu;
        }
        public void Change_Tips()
        {
            if (tips != null && Total_Tips > CounterTips)
            {
                CounterTips++;
                lbl_Tips.Invoke((MethodInvoker)(() => lbl_Tips.Text = tips.GetRandomTip()));
            }

            else
                Load_list_Tips();

            timer_MoveLabel.Start();
        }

        private void timer_MoveLabel_Tick(object sender, EventArgs e)
        {
            Change_Tips();
        }

       
    }
}
