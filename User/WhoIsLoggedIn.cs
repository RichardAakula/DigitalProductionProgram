using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.SqlClient;
using SkiaSharp;

namespace DigitalProductionProgram.User
{
    public partial class WhoIsLoggedIn : Form
    {
        private readonly List<Users> listUsers = new();
        private readonly List<FlowLayoutPanel> panels = new();

        public WhoIsLoggedIn()
        {
            InitializeComponent();

            new Users();

            Log.Activity.Start();
            LoadUsersAsync(); // Async version
            Points.Add_Points(5, "Kollar vem som är inloggad");
        }

        private async void LoadUsersAsync()
        {
            await using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT Name, EmployeeNumber, RoleName 
                FROM [User].Person as person
                JOIN [User].Roles as roles
                    ON person.RoleID = roles.RoleID
                WHERE Online = 'True' 
                    AND CONVERT(date, Last_Point_Time) = CONVERT(date, GETDATE())
                ORDER BY RoleName";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                listUsers.Add(new Users
                {
                    Name = reader["Name"].ToString(),
                    AnstNr = reader["EmployeeNumber"].ToString(),
                    Role = reader["RoleName"].ToString()
                });
            }

            await PrintUsers();
        }

        private static async Task<int?> LastOrderIDAsync(string anstNr)
        {
            var con = new SqlConnection(Database.cs_Protocol);
            try
            {
                var query = @"
                    SELECT mp.OrderID, Date AS Datum
                    FROM Measureprotocol.MainData AS mp 
                        JOIN [Order].MainData AS main
                            ON mp.OrderID = main.OrderID
                    WHERE AnstNr = @employeenumber 

                    UNION 
                    SELECT slip.OrderID, Date_Time
                    FROM Korprotokoll_Slipning_Produktion AS slip 
                        JOIN [Order].MainData AS main
                            ON slip.OrderID = main.OrderID
                    WHERE AnstNr = @employeenumber

                    ORDER BY Datum DESC";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                await con.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    if (int.TryParse(reader["OrderID"].ToString(), out var orderID))
                        return orderID;
                }
                reader.Close();
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        private static async Task<string> LastProdLineAsync(int? orderID)
        {
            if (!orderID.HasValue)
                return "N/A";

            var con = new SqlConnection(Database.cs_Protocol);
            try
            {
                var query = @"
                    SELECT ProdLine, Date_Start AS Datum
                    FROM [Order].MainData 
                    WHERE OrderID = @orderid 
                        AND Date_Start > @date
                    ORDER BY Datum DESC";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddYears(-1));
                await con.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return reader["ProdLine"].ToString();
                }
                reader.Close();
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        private async Task PrintUsers()
        {
            for (var i = 0; i < listUsers.Count; i++)
            {
                AddPanel();
                AddPictureBox(i);
                AddName(i);
                AddEmployeeNr(i);
                AddRole(i);
                await AddProdLineAsync(i);
            }

            // HÄR – rita diagrammet EN gång
            await InitializeChartOperatörInfo(listUsers.Select(u => u.Name).ToList());
        }
        private async Task AddProdLineAsync(int i)
        {
            var orderID = await LastOrderIDAsync(listUsers[i].AnstNr);
            var lbl = new Label
            {
                Text = await LastProdLineAsync(orderID),
                AutoSize = true,
                ForeColor = Color.DodgerBlue
            };
            panels[i].Controls.Add(lbl);
        }

        private void AddPanel()
        {
            var panel = new FlowLayoutPanel
            {
                Size = new Size(150, 260),
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.FromArgb(6, 81, 87),
                Margin = new Padding(15, 5, 0, 0)
            };
            flp_Users.Controls.Add(panel);
            panels.Add(panel);
        }
        private void AddPictureBox(int i)
        {
            var pb = new PictureBox
            {
                Size = new Size(110, 140),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Person.ProfilePicture(listUsers[i].Name)
            };
            panels[i].Controls.Add(pb);
        }
        private void AddName(int i)
        {
            var lbl = new Label
            {
                Text = listUsers[i].Name,
                AutoSize = true,
                ForeColor = Color.FromArgb(181, 210, 207),
                Font = new Font(Font, FontStyle.Bold)
            };
            panels[i].Controls.Add(lbl);
        }
        private void AddEmployeeNr(int i)
        {
            var lbl = new Label
            {
                Text = listUsers[i].AnstNr,
                AutoSize = false,
                ForeColor = Color.FromArgb(171, 150, 85)
            };
            panels[i].Controls.Add(lbl);
        }
        private void AddRole(int i)
        {
            var lbl = new Label
            {
                Text = listUsers[i].Role,
                AutoSize = false,
                ForeColor = Color.White
            };
            panels[i].Controls.Add(lbl);
        }



        private async Task InitializeChartOperatörInfo(List<string> users)
        {
            panel_Chart.Controls.Clear();

            var allCounts = await GetAllLoginCountsAsync();
            int totalLogins = allCounts.Values.Sum();
            if (totalLogins == 0) totalLogins = 1;

            var seriesList = new List<ISeries>();

            var rnd = new Random();

            int xIndex = 0;

            foreach (var user in users)
            {
                allCounts.TryGetValue(user, out int count);
                double pct = count / (double)totalLogins * 100;

                var color = new SKColor(
                    (byte)rnd.Next(50, 200),
                    (byte)rnd.Next(50, 200),
                    (byte)rnd.Next(50, 200));

                seriesList.Add(new ColumnSeries<ObservablePoint>
                {
                    Name = $"{user} ({pct:0.0}%)",
                    Values = [new ObservablePoint(xIndex, count)], // keep unique X for each column

                    Fill = new SolidColorPaint(color),
                    Stroke = null,

                    MaxBarWidth = 150,       // 👈 (valfritt) Begränsar maxbredden
                    
                    Padding = 0,
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsFormatter = point => $"{pct:0.0}%"
                });

                xIndex++;
            }

            var chart = new CartesianChart
            {
                Series = seriesList,

                XAxes =
                [
                    new Axis
                    {
                        Labels = users,     // now matches X indexes
                        LabelsRotation = 15,
                    }
                ],

                YAxes =
                [
                    new Axis
                    {
                        Name = "Antal inloggningar",
                        MinLimit = 0
                    }
                ],

                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                LegendTextPaint = new SolidColorPaint(SKColors.White),
                Dock = DockStyle.Fill
            };

            panel_Chart.Controls.Add(chart);
        }

        public static async Task<Dictionary<string, int>> GetAllLoginCountsAsync()
        {
            var result = new Dictionary<string, int>();

            await using var con = new SqlConnection(Database.cs_Protocol);
            await using var cmd = new SqlCommand(@"
        SELECT p.Name, COUNT(*) AS Cnt
        FROM Log.ActivityLog a
        JOIN [User].Person p ON p.UserID = a.UserID
        WHERE a.Info LIKE 'Loggar in%'
        GROUP BY p.Name
    ", con);

            ServerStatus.Add_Sql_Counter();
            await con.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var name = reader.GetString(0);
                var count = reader.GetInt32(1);
                result[name] = count;
            }

            return result;
        }



        private class Users
        {
            public string? Name;
            public string AnstNr;
            public string Role;
        }

        private void Inloggad_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
