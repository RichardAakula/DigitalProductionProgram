using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net.Mail;
using System.Reflection;

namespace DigitalProductionProgram.User
{
    public abstract class Person
    {
        public static string? Role = null!;


        public static List<string?> List_Users(bool IsShowInactiveUsers)
        {
            return Database.ExecuteSafe(con =>
            {
                var list = new List<string?>();
                const string query = @"
                SELECT Name
                FROM [User].Person
                WHERE IsActive = 'True'
                ORDER BY Name";

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader[0]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                        list.Add(name);
                }

                return list;
            });
        }


        public static List<string> List_Roles
        {
            get
            {
                var roles = Database.ExecuteSafe(con =>
                {
                    var list = new List<string>();

                    const string query = @"
                        SELECT RoleName
                        FROM [User].Roles
                        WHERE RoleName != 'SuperAdmin'
                        ORDER BY
                        CASE WHEN RoleName = 'Operator' THEN 0 ELSE 1 END,
                        RoleName";

                    using var cmd = new SqlCommand(query, con);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var role = reader[0]?.ToString();
                        if (!string.IsNullOrEmpty(role))
                            list.Add(role);
                    }
                    return list;
                });

                // Lägg till SuperAdmin om nuvarande användare är SuperAdmin
                if (Role == "SuperAdmin" && !roles.Contains("SuperAdmin"))
                    roles.Add("SuperAdmin");

                return roles;
            }
        }
        public static List<MailAddress> List_MailAddress
        {
            get
            {
                var list = Database.ExecuteSafe(con =>
                {
                    var tempList = new List<MailAddress>();
                    const string query = "SELECT DISTINCT Mail FROM [User].Person";
                    using var cmd = new SqlCommand(query, con);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var email = reader[0]?.ToString();
                        if (!string.IsNullOrEmpty(email) && eMail.Mail.IsValidEmail(email))
                            tempList.Add(new MailAddress(email));
                    }
                    return tempList;
                });
                return list;
            }
        }

        public static Image ProfilePicture(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return Properties.Resources.anonym;

            return Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT Picture 
                    FROM [User].Picture 
                    WHERE UserID = (
                        SELECT UserID 
                        FROM [User].Person 
                        WHERE Name = @name)";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                var value = cmd.ExecuteScalar();
                if (value == null || value == DBNull.Value)
                    return Properties.Resources.anonym;

                var imgData = (byte[])value;
                try
                {
                    using var ms = new MemoryStream(imgData);
                    using var tmp = Image.FromStream(ms);
                    return (Image)tmp.Clone();
                }
                catch
                {
                    InfoText.Show(Properties.Resources.error_ProfilePicture, CustomColors.InfoText_Color.Bad, "Error");
                    return Properties.Resources.anonym;
                }
            }) ?? Properties.Resources.anonym; // Om ExecuteSafe returnerar null
        }

       
        public static int UserID { get; set; }
        public static string? Name { get; set; }
        public static string? Sign { get; set; }
        public static string? Password { get; set; } = null!;
        public static string? Mail { get; set; }
        public static string? EmployeeNr { get; set; }
        public static bool Online { get; set; }
        public static bool VisaBild { get; set; }

        public static bool IsPasswordOk(string? header)
        {
            using var black = new BlackBackground(string.Empty, 60);
            using var password = new PasswordManager(header);
            black.Show();
            password.ShowDialog();
            black.Close();
            return password.IsOk;
        }
        public static bool IsUserSignedIn(bool is_Ok_Show_Message)
        {
            if (!string.IsNullOrEmpty(Name)) 
                return true;

            if (is_Ok_Show_Message)
                InfoText.Show(Properties.Resources.login_Info_7, CustomColors.InfoText_Color.Bad, "Warning!");
            return false;

        }


        public static bool IsOperatorReadMyAnalysis
        {
            get
            {
                var result = Database.ExecuteSafe(con =>
                {
                    const string query = @"
                        SELECT 1
                        FROM [User].TimeReadChangeLog AS time
                        JOIN [User].Person AS person
                            ON person.UserID = time.UserID
                        WHERE month = @month 
                            AND Year = @year 
                            AND Name = @namn";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@month", DateTime.Now.Month.ToString());
                    cmd.Parameters.AddWithValue("@year", DateTime.Now.Year.ToString());
                    cmd.Parameters.AddWithValue("@namn", Name);
                    using var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                });
                return result;
            }
        }


        public static int TotalLoginsByUser
        {
            get
            {
                var result = Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT COUNT(*) FROM Log.ActivityLog WHERE Info = @info";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@info", $"Logging in: {Name}");
                    var scalar = cmd.ExecuteScalar();
                    return scalar != null ? Convert.ToInt32(scalar) : 0; // null-säker och typ-säker
                });
                return result;
            }
        }

        public static int TotalMeasurementsByUser
        {
            get
            {
                var result = Database.ExecuteSafe(con =>
                {
                    const string query = @"SELECT COUNT(*) FROM Measureprotocol.MainData WHERE AnstNr = @employeenumber";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@employeenumber", EmployeeNr);
                    var scalar = cmd.ExecuteScalar();
                    return scalar != null ? Convert.ToInt32(scalar) : 0; // null-säker och typ-säker
                });

                return result;
            }
        }

        public static int User_Points
        {
            get
            {
                var result = Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Points FROM [User].Person WHERE EmployeeNumber = @employeenumber";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@employeenumber", EmployeeNr);

                    var scalar = cmd.ExecuteScalar();
                    return scalar != null ? Convert.ToInt32(scalar) : 0;
                });

                return result;
            }
        }


        public static string? Get_SignWithName(string? namn)
        {
            if (string.IsNullOrEmpty(namn))
                return null;

            var result = Database.ExecuteSafe(con =>
            {
                const string query = "SELECT Signature FROM [User].Person WHERE Name = @name";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", namn);
                var scalar = cmd.ExecuteScalar();
                return scalar?.ToString();
            });

            return result;
        }
        public static string? Get_NameWithAnstNr(string anstNr)
        {
            var result = Database.ExecuteSafe(con =>
            {
                const string query = "SELECT Name FROM [User].Person WHERE EmployeeNumber = @employeenumber";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                var scalar = cmd.ExecuteScalar();
                return scalar?.ToString();
            });

            return result;
        }

        public static string? Get_EmployeeNrWithName(string? name)
        {
            if (string.IsNullOrEmpty(name) || name == "Klicka här för godkännande...")
                return null;

            var result = Database.ExecuteSafe(con =>
            {
                const string query = "SELECT EmployeeNumber FROM [User].Person WHERE Name = @name";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                var value = cmd.ExecuteScalar();
                return value?.ToString(); // null-säker konvertering
            });

            return result;
        }
        public static int Get_EmployeeID(string employeeNr)
        {
            var result = Database.ExecuteSafe(con =>
            {
                const string query = "SELECT UserID FROM [User].Person WHERE EmployeeNumber = @employeenumber";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@employeenumber", employeeNr);

                var value = cmd.ExecuteScalar();
                return value != null ? Convert.ToInt32(value) : 0; // null-säker och typ-säker
            });

            return result;
        }

        public static async Task<Version?> LastReadChangeLogVersion(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            var result = await Database.ExecuteSafeAsync(async con =>
            {
                const string query = "SELECT LastReadChangeLogVersion FROM [User].Person WHERE Name = @name";
                await using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);

                var scalar = await cmd.ExecuteScalarAsync();
                return Version.TryParse(scalar?.ToString(), out var ver) ? ver : null;
            });
            return result;
        }



        public static void Load_EmployeeNumber(string? namn)
        {
            if (string.IsNullOrEmpty(namn))
                return;

            var value = Database.ExecuteSafe(con =>
            {
                var query = "SELECT EmployeeNumber FROM [User].Person WHERE Name = @name";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", namn);
                return cmd.ExecuteScalar();
            });

            if (value != null)
                EmployeeNr = value.ToString();
        }

        public static void Fill_ContextMenu_Name(ContextMenuStrip cm)
        {
            cm.Items.Clear();

            Database.ExecuteSafe(con =>
            {
                const string query = "SELECT Name FROM [User].Person ORDER BY Name";

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader[0]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                        cm.Items.Add(name);
                }
            });
        }

        public static void Clear()
        {
            EmployeeNr = string.Empty;
            Role = string.Empty;
            Name = string.Empty;
            Sign = null;
            VisaBild = false;
            Online = false;
            Mail = null;
            Points.TotalPoints = 0;
        }
        public static void Add(string name, string sign, string anstNr, string password, string roleName, string mail, byte[]? img)
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                IF NOT EXISTS 
                (
                    SELECT * FROM [User].Person WHERE Name = @name
                )
                INSERT INTO [User].Person
                (
                    Name, 
                    Signature, 
                    EmployeeNumber, 
                    Online, 
                    Password, 
                    RoleID, 
                    Mail, 
                    CreatedDate, 
                    LastReadChangeLogVersion, 
                    UtbildadVerktyg, 
                    Points, 
                    Vote_Last_Gallup, 
                    Seen_Gallup_result, 
                    IsActive
                )
                VALUES 
                (
                    @name, 
                    @signature, 
                    @employeenumber, 
                    'False', 
                    @password, 
                    (SELECT RoleID FROM [User].Roles WHERE RoleName = @role),
                    @mail, 
                    @createddate, 
                    @lastreadchangelogversion, 
                    @utbildadVerktyg, 
                    0, 
                    'True', 
                    'True', 
                    'True'
                )";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@signature", sign);
                cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                cmd.Parameters.AddWithValue("@password", PasswordManager.ConvertToHashedPassword(password));
                cmd.Parameters.AddWithValue("@role", roleName);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastreadchangelogversion", "0.0.0.0");
                cmd.Parameters.AddWithValue("@utbildadVerktyg", "0.0.0.0");
                var value = cmd.ExecuteNonQuery();
                if (value < 0)
                    InfoText.Show($"{name} {Properties.Resources.user_AlreadyInSystem}", CustomColors.InfoText_Color.Bad, null);

                if (img != null)
                    Save_ProfilePicture(img, name);
            });
           
            InfoText.Show($"{name} {Properties.Resources.user_AddedInSystem}", CustomColors.InfoText_Color.Ok, null);
        }
        public static void UpdatePassword( string newPassword)
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                UPDATE [User].Person
                SET Password = @password
                WHERE UserID = @userid";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userid", Person.UserID);
                cmd.Parameters.AddWithValue("@password", PasswordManager.ConvertToHashedPassword(newPassword));

                cmd.ExecuteNonQuery();
            });
            
        }

        public static async Task UpdateLastReadChangelogVersion(string? username)
        {
            if (ChangeLog.HighestSelectedVersion is null || username is null)
                return;

            var newVersion = new Version(ChangeLog.HighestSelectedVersion.ToString());
            var currentVersion = await LastReadChangeLogVersion(username);

            if (currentVersion == null || newVersion > currentVersion)
            {
                await Database.ExecuteSafeAsync(async con =>
                {
                    const string query = @"
                UPDATE [User].Person
                SET LastReadChangeLogVersion = @lastreadchangelogversion
                WHERE Name = @name";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", username);
                    cmd.Parameters.AddWithValue("@lastreadchangelogversion", newVersion.ToString());
                    await cmd.ExecuteNonQueryAsync();
                    return true;

                });
            }
        }

        public static void Save_ProfilePicture(byte[]? img, string name)
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                IF NOT EXISTS 
                (
                    SELECT 1 FROM [User].Picture 
                    WHERE UserID = (SELECT UserID FROM [User].Person WHERE Name = @name)
                )
                BEGIN
                    INSERT INTO [User].Picture (UserID, Picture)
                    SELECT UserID, @picture 
                    FROM [User].Person 
                    WHERE Name = @name
                END
                ELSE
                BEGIN
                    UPDATE [User].Picture
                    SET Picture = @picture 
                    WHERE UserID = (SELECT UserID FROM [User].Person WHERE Name = @name)
                END";

                using var cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@picture", SqlDbType.VarBinary, -1).Value = img ?? (object)DBNull.Value;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;

                cmd.ExecuteNonQuery();
            });
            
        }

        
    }
    public class Grade
    {
        private const int _1 = 0;
        private const int _2 = 80;
        private const int _3 = 100;
        private const int _4 = 160;
        private const int _5 = 240;
        private const int _6 = 340;
        private const int _7 = 460;
        private const int _8 = 600;
        private const int _9 = 800;
        private const int _10 = 1120;
        private const int _11 = 1520;
        private const int _12 = 2080;
        private const int _13 = 2840;
        private const int _14 = 3840;
        private const int _15 = 5120;
        private const int _16 = 6640;
        private const int _17 = 8480;
        private const int _18 = 10680;
        private const int _19 = 13200;
        private const int _20 = 16040;
        private const int _21 = 19280;
        private const int _22 = 22880;
        private const int _23 = 26840;
        private const int _24 = 31240;
        private const int _25 = 36040;
        private const int _26 = 41240;
        private const int _27 = 47000;
        private const int _28 = 53320;
        private const int _29 = 60720;
        private const int _30 = 70120;
        private const int _31 = 82120;
        private const int _32 = 100120;
        private const int _33 = 126120;

        public static double percent_Grade(int grade)
        {
            var gr = $"_{grade}";
            double value = 0;
           // var type = typeof(Grade);

            int[] grades = {_1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31,_32,_33 };
            if (gr == "_0")
                value = (_1 - (double)Points.TotalPoints / _1);

            for (var i = 1; i < grades.Length; i++)
            {
                if (gr == $"_{i}")
                {
                    value = (grades[i] - (double)Points.TotalPoints) / (grades[i] - (double)grades[i-1]);
                    break;
                }
            }

            return 1 - value;
           
        }
        
        public static int grade
        {
            get
            {
                var grade = 0;
                int[] grades = { _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _29, _30, _31, _32, _33 };

                for (var i = 0; i < grades.Length; i++)
                {
                    if (Points.TotalPoints > grades[i])
                        grade = i + 1;
                }

                return grade;
            }
        }
        public static Stream? Img_Grade
        {
            get
            {
                try
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    return assembly.GetManifestResourceStream($"DigitalProductionProgram.Resources.Grades.{grade}.png");
                }
                catch
                {
                    return null;
                }
            }
        }
    }

    public static class Points
    {
        public static int TotalPoints { get; set; }

        private static bool Is_Ok_Add_Points
        {
            get
            {
                if (string.IsNullOrEmpty(Person.EmployeeNr))
                    return false;

                var last_Point = Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Last_Point_Time FROM [User].Person WHERE EmployeeNumber = @employeenumber";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                    var scalar = cmd.ExecuteScalar();
                    return scalar != null && DateTime.TryParse(scalar.ToString(), out var dt) ? dt : DateTime.MinValue;
                });
                var span = DateTime.Now - last_Point;
                return span.TotalSeconds > 20;
            }
        }

        public static void Add_Points(int point, string Text)
        {
            if (!Is_Ok_Add_Points)
                return;

            if (!Person.IsUserSignedIn(false))
                return;
            Activity.Start();
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    UPDATE [User].Person
                    SET Points = Points + @points,
                        Last_Point_Time = @time
                    WHERE EmployeeNumber = @employeenumber";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@points", point);
                cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery(); 
                
            });

            _ = Activity.Stop($"{point} points. Totally: {TotalPoints} points: ({Text})");
        }

    }




}
