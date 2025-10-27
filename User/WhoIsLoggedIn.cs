using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.User
{
    public partial class WhoIsLoggedIn : Form
    {
        private readonly List<Users> listUsers = new List<Users>();
        private readonly List<FlowLayoutPanel> panels = new List<FlowLayoutPanel>();

        public WhoIsLoggedIn()
        {
            InitializeComponent();

            new Users();
            if (Person.Role == "SuperAdmin")
                chart_Operatör.Visible = true;

            Log.Activity.Start();
            LoadUsersAsync(); // Async version
            Points.Add_Points(5, "Kollar vem som är inloggad");
        }

        private async void LoadUsersAsync()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
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
            chart_Operatör.Series[0].Points.Clear();
            chart_Operatör.Series[0].Name = "Antal Inloggningar";
            chart_Operatör.ChartAreas[0].AxisX.Interval = 1;

            for (var i = 0; i < listUsers.Count; i++)
            {
                AddPanel();
                AddPictureBox(i);
                AddName(i);
                AddEmployeeNr(i);
                AddRole(i);
                await AddProdLineAsync(i); // Async version
                await InitializeChartOperatörInfo(listUsers[i].Name);
            }
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

        private async Task InitializeChartOperatörInfo(string? user)
        {
            var totalLogIns = TotalLogInsAsync();

            if (!string.IsNullOrEmpty(user))
            {
                var antal = await GetLoginCountAsync(user);
                var percent = antal / (double)totalLogIns * 100;
                chart_Operatör.Series[0].Points.AddXY($"{percent:0.0}% {user}", antal);
            }
        }

        private async Task<int> GetLoginCountAsync(string? name)
        {
            var con = new SqlConnection(Database.cs_Protocol);
            try
            {
                var query = "SELECT COUNT(*) FROM Log.ActivityLog WHERE Program = 'Körprotokoll' AND UserID = (SELECT UserID FROM [User].Person WHERE Name = @name) AND Info LIKE 'Loggar in%'";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@name", name);
                await con.OpenAsync();
                return (int)await cmd.ExecuteScalarAsync();
            }
            finally
            {
                con.Close();
            }
        }

        public static int TotalLogInsAsync()
        {
            var con = new SqlConnection(Database.cs_Protocol);
            try
            {
                const string query = "SELECT COUNT(*) FROM Log.ActivityLog WHERE Program = 'Körprotokoll' AND UserID IS NOT NULL AND Info LIKE 'Loggar in%'";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                con.Close();
            }
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
