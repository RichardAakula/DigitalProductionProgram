using System;
using Microsoft.Data.SqlClient;
using System.Net.Mail;
using System.Reflection;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.User
{
    public class Person
    {
        public static string? Role = null!;
        

        public static List<string> List_Users(bool IsShowInactiveUsers)
        {
            var list = new List<string>();

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT Name FROM [User].Person
                    WHERE IsActive = 'True'
                    ORDER BY Name";

            var cmd = new SqlCommand(query, con);
               

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader[0].ToString());
            return list;
        }

        public static List<string> List_Roles
        {
            get
            {
                var list = new List<string>();
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                var query = @"
                        SELECT RoleName FROM [User].Roles 
                        WHERE RoleName != 'SuperAdmin'
                        ORDER BY
                        CASE WHEN RoleName = 'Operator' 
                        THEN 0 
                        ELSE 1
                        END, RoleName";
                var cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var role =  reader[0].ToString();
                    list.Add(role);
                }
                if (Role == "SuperAdmin")
                    list.Add("SuperAdmin");
                return list;
            }
        }
        public static List<MailAddress> List_MailAddress
        {
            get
            {
                var list = new List<MailAddress>();

                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT DISTINCT Mail FROM [User].Person";

                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var email = reader[0].ToString();
                    if (eMail.Mail.IsValidEmail(email))
                    {
                        var mail = new MailAddress(email);
                        list.Add(mail);
                    }
                }

                return list;
            }
        }

        public static Image ProfilePicture(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return Properties.Resources.anonym;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Picture FROM [User].Picture WHERE UserID = (SELECT UserID FROM [User].Person WHERE Name = @name)";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            var value = cmd.ExecuteScalar();
            if (value is null)
                return Properties.Resources.anonym;
            var img = (byte[])value;
            var ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        public static int UserID { get; set; }
        public static string? Name { get; set; } = null!;
        public static string? Sign { get; set; } = null!;
        public static string? Password { get; set; } = null!;
        public static string? Mail { get; set; } = null!;
        public static string? EmployeeNr { get; set; } = null!;
        public static bool Online { get; set; }
        public static bool VisaBild { get; set; }

        public static bool IsPasswordOk(string? header)
        {
            var black = new BlackBackground(string.Empty, 60);
            var password = new PasswordManager(header);
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
                InfoText.Show(LanguageManager.GetString("login_Info_7"), CustomColors.InfoText_Color.Bad, "Warning!");
            return false;

        }

        
        public static bool IsOperatorReadMyAnalysis
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                    SELECT * 
                    FROM [User].TimeReadChangeLog as time
                        JOIN [User].Person as person
                            ON person.UserID = time.UserID
                    WHERE month = @month 
                        AND Year = @year 
                        AND Name = @namn";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@month", DateTime.Now.Month.ToString());
                cmd.Parameters.AddWithValue("@year", DateTime.Now.Year.ToString());
                cmd.Parameters.AddWithValue("@namn", Name);
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        public static int Antal_Inloggningar
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT COUNT(*) FROM Log.ActivityLog  WHERE Info = @info";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@info", $"Loggar in: {Name}");
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public static int Antal_Mätningar_Operatör
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT (SELECT COUNT(*) FROM Measureprotocol.MainData WHERE AnstNr = @employeenumber)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@employeenumber", EmployeeNr);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public static int User_Points
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT Points FROM [User].Person WHERE EmployeeNumber = @employeenumber";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@employeenumber", EmployeeNr);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
       
        public static string? Get_SignWithName(string? namn)
        {
            if (string.IsNullOrEmpty(namn))
                return null;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Signature FROM [User].Person WHERE Name = @name";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", namn);
            con.Open();
            return (string)cmd.ExecuteScalar();
        }
        public static string? Get_NameWithAnstNr(string anstNr)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Name FROM [User].Person WHERE EmployeeNumber = @employeenumber";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@employeenumber", anstNr);
            con.Open();
            var name = cmd.ExecuteScalar();
            return name?.ToString();
        }
        public static string? Get_AnstNrWithName(string? name)
        {
            if (string.IsNullOrEmpty(name) || name == "Klicka här för godkännande...")
                return null;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT EmployeeNumber FROM [User].Person WHERE Name = @name";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            var value = cmd.ExecuteScalar();
            return value?.ToString();
        }
        public static int Get_EmployeeID(string employeeNr)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT UserID FROM [User].Person WHERE EmployeeNumber = @employeenumber";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@employeenumber", employeeNr);
            con.Open();
            return (int)cmd.ExecuteScalar();
        }
        public static Version? LastReadChangeLogVersion(string name)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT LastReadChangeLogVersion FROM [User].Person WHERE Name = @name";

            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", name);
            var version = (string)cmd.ExecuteScalar();
            var vers = new Version(version);
            return vers;
        }


        public static void Load_EmployeeNumber(string? namn)
        {
            if (string.IsNullOrEmpty(namn))
                return ;
            using var con = new SqlConnection(Database.cs_Protocol);
            // int anstNr;
            var query = "SELECT EmployeeNumber FROM [User].Person WHERE Name = @name";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", namn);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value != null)
                EmployeeNr = value.ToString();
        }
        public static void Fill_ContextMenu_Name(ContextMenuStrip cm)
        {
            cm.Items.Clear();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Name FROM [User].Person ORDER BY Name";
              
            con.Open();
            var cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                cm.Items.Add(reader[0].ToString());
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
            using (var con = new SqlConnection(Database.cs_Protocol))
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
                con.Open();
                var value = cmd.ExecuteNonQuery();
                if (value < 0)
                {
                    InfoText.Show($"{name} {LanguageManager.GetString("user_AlreadyInSystem")}", CustomColors.InfoText_Color.Bad, null);
                    return;
                }
                if (img != null)
                    Save_ProfilePicture(img, name);
            }
           
            InfoText.Show($"{name} {LanguageManager.GetString("user_AddedInSystem")}", CustomColors.InfoText_Color.Ok, null);
        }
        public static async Task UpdateLastReadChangelogVersion(string? username)
        {
            if (ChangeLog.HighestSelectedVersion is null)
                return;
            await using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    UPDATE [User].Person
                    SET LastReadChangeLogVersion = @lastreadchangelogversion
                    WHERE Name = @name
                        AND (@lastreadchangelogversion > LastReadChangeLogVersion OR LastReadChangeLogVersion IS NULL)";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", username);
            cmd.Parameters.AddWithValue("@lastreadchangelogversion", ChangeLog.HighestSelectedVersion.ToString());

            con.Open();
            await cmd.ExecuteNonQueryAsync();
        }


        public static void Save_ProfilePicture(byte[]? img, string name)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    IF NOT EXISTS (SELECT * FROM [User].Picture WHERE UserID = (SELECT UserID FROM [User].Person WHERE Name = @name)) 
                        INSERT INTO [User].Picture (UserID, Picture)
                        SELECT UserID, @picture 
						FROM [User].Person 
						WHERE Name = @name
                    ELSE
                        UPDATE [User].Picture
                        SET Picture = @picture WHERE UserID = (SELECT UserID FROM [User].Person WHERE Name = @name)";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@picture", img);
            cmd.Parameters.AddWithValue("@name", name);
            if (img != null)
                cmd.ExecuteNonQuery();
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

    public class Points
    {
        public static int TotalPoints { get; set; }

        private static bool Is_Ok_Add_Points
        {
            get
            {
                if (Person.EmployeeNr is null || string.IsNullOrEmpty(Person.EmployeeNr))
                    return false;
                DateTime last_Point;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT Last_Point_Time FROM [User].Person WHERE EmployeeNumber = @employeenumber";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                    con.Open();
                    DateTime.TryParse(cmd.ExecuteScalar().ToString(), out last_Point);
                }
                var span = DateTime.Now - last_Point;

                if (span.TotalSeconds > 20)
                    return true;
                return false;
            }
        }
        public static void Add_Points(int point, string Text)
        {
            if (Is_Ok_Add_Points)
            {
                if (Person.IsUserSignedIn(false) == false)
                    return;
                Activity.Start();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "UPDATE [User].Person SET Points = Points + @points, Last_Point_Time = @time WHERE EmployeeNumber = @employeenumber";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                    cmd.Parameters.AddWithValue("@points", point);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    con.Open();
                    cmd.ExecuteScalar();
                }
                _ = Activity.Stop($"{point} poäng. Totalt: {TotalPoints} poäng: ({Text})");
            }
        }
    }

   


}
