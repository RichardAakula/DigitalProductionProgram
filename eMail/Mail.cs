using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.eMail
{
    internal class Mail
    {
        public static string? Body;

        private static bool IsAutoTestJiraMailSentToday
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        SELECT * FROM Log.ActivityLog WHERE Info = 'Autotest Jira' 
                            AND Date BETWEEN CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                            AND DATEADD(DAY, 1, CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME))";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;

                return false;
            }
        }

       
        public static MailMessage MailMessage(int id)
        {
            var mailMessage = new MailMessage();
            //int[] excludedMailID = { 7, 10 };
            //if (excludedMailID.Contains(id) == false)
            //mailMessage.To.Add("richard_aakulas@hotmail.com");
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Mail FROM Authorities.CustomMail WHERE TemplateID = @id";

            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                mailMessage.To.Add(reader[0].ToString());
            return mailMessage;
        }

        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                return false;
            }

            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public static void Send(string? subject, int customMailID, MailMessage? mailMessage = null)
        {
            var msg = mailMessage ?? MailMessage(customMailID);

            msg.From = new MailAddress("digitalprocessprogram@optinova.com");
            msg.Subject = subject;
            msg.Body = string.Format(LanguageManager.GetString("mail_Body") ?? string.Empty, Person.Name, Person.Mail, Body);
            msg.IsBodyHtml = true;
            var client = new SmtpClient
            {
                Host = "mail.optinova.fi",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25,
                EnableSsl = false,
            };
            if (msg.To.Count > 0)
                client.Send(msg);
            client.Dispose();
        }

        public static void Test()
        {
            Send("Autotest", 1);
        }
        

        public static void Send_TestMail()
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add("anton.bergman@optinova.com");
            var msg = mailMessage;

            msg.IsBodyHtml = true;
            var client = new SmtpClient
            {
                Host = "mail.optinova.fi",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25,
                EnableSsl = false
            };
            if (msg.To.Count > 0)
                client.Send(msg);
            client.Dispose();


        }
        public static void Inform_SuperAdmin_Bug_Create_Processcard(string text)
        {
            Body = $"ArtikelNr: {Order.PartNumber}<br />" +
                   $"ArtikelID: {Order.PartID}<br />" +
                   $"ArtikelGroupID: {Order.PartGroupID}<br />" +
                   $"RevNr: {Order.RevNr}<br />" +
                   $"ProdLinje: {Order.ProdLine}<br />" +
                   $"ProdGrupp: {Order.ProdGroup}<br />" +
                   $"ArbetsOperation: {Order.WorkOperation}<br /> <br />" +
                   $"ErrorMessage: {text}";
            Send("Error Processkortshantering:", 6);
        }
        public static void ProcesscardNeedChanges_FinishOrder()
        {
            if (Order.OrderID != null)
            {
                Body += "Update Process card:<br />" +
                        $"ProdLine: {Order.ProdLine}<br />" +
                        $"ProdGroup: {Order.ProdGroup}<br />" +
                        $"WorkOperation: {Order.WorkOperation}<br /><br />";

                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT * FROM Processcard.ProposedChanges WHERE OrderID = @orderid ORDER BY Datum";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                    return;
                while (reader.Read())
                {
                    Body += $"{reader["Rubrik"]}</b> <br />" +
                            $"{reader["Meddelande"]}" +
                            "<br /><br />";
                }
            }

            

           
            Send($"{Order.WorkOperation}, {Order.PartNumber}, {Order.OrderNumber}-{Order.Operation}", 1);

        }

        public static async void AutoTestJira()
        {
            if (CheckAuthority.IsFactoryAuthorized(CheckAuthority.TemplateFactory.AutoTestJira) &! IsAutoTestJiraMailSentToday)
            {
                Log.Activity.Start();
                Body = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Send("Autotest", 10);
                await Log.Activity.Stop("Autotest Jira");
            }
        }
        public static void Inform_SuperAdmin_Error(string? text)
        {
            Body = text;
            Send("Allmänt fel", 6);
        }
        public static void NotifyCustomerServiceMissingMeasurepoints()
        {
            Part.SetPartNrSpecial("MissingMeasurepoints");
            if (Part.IsPartNrSpecial || Person.Role == "SuperAdmin")
                return;
            InfoText.Show($"{LanguageManager.GetString("mail_MissingMeasurePoints_1")}", CustomColors.InfoText_Color.Warning, null);

            Body = string.Format(LanguageManager.GetString("mail_NotifyCustomerServiceMissingMeasurePoints"), Order.WorkOperation, Order.OrderNumber, Order.Operation, Order.PartNumber, Person.Name);
            Send($"{LanguageManager.GetString("mail_MissingMeasurePoints_2")}", 5);

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"INSERT INTO Parts.PartNrSpecial (PartNr, PartNrDescriptionID )
                               VALUES (@partNr, 3)";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partNr", Order.PartNumber);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public static void NotifyFannyHanssonWrongMeasurePoints(string? text)
        {
            Body = text;
            Send("Fel i Mätpunkter", 7);
        }
        public static void NotifyOrderFinishedCount_3()
        {
            Body = string.Format(LanguageManager.GetString("mail_Body_NotifyOrderFinishedCount_3"), Order.PartNumber, Order.ProdLine, Order.ProdGroup, Order.WorkOperation, Order.OrderNumber, Order.Operation);
            Send(string.Format(LanguageManager.GetString("mail_Subject_NotifyOrderFinishedCount"), Order.PartNumber), 2);
        }
        public static void NotifyOrderStartCount_4to5(int totalorders)
        {
            Body = string.Format(LanguageManager.GetString("mail_Body_NotifyOrderStartCount_4to5"), Order.PartNumber, totalorders, Order.ProdLine, Order.ProdGroup, Order.WorkOperation);
            Send(string.Format(LanguageManager.GetString("mail_Subject_NotifyOrderStartCount"), Order.PartNumber, totalorders), 3);
        }
        public static void NotifyOrderStartCount_6(int totalorders)
        {
            Body = string.Format(LanguageManager.GetString("mail_Body_NotifyOrderStartCount_6"), Order.PartNumber, totalorders, Order.ProdLine, Order.ProdGroup, Order.WorkOperation);
            Send(string.Format(LanguageManager.GetString("mail_Subject_NotifyOrderStartCount"), Order.PartNumber, totalorders), 3);
        }
        public static void NotifyCustomerServiceOrderCount_6()
        {
            Body = string.Format(LanguageManager.GetString("mail_Body_NotifyOrderStartCount_6"), Order.PartNumber, 6, Order.ProdLine, Order.ProdGroup, Order.WorkOperation);
            Send(string.Format(LanguageManager.GetString("mail_Subject_NotifyOrderStartCount"), Order.PartNumber, 6), 4);
        }

        public static void NotifyQAPartNumberNeedApproval(string? latestRevNr)
        {
            if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols)
                return;
            InfoText.Show(string.Format(LanguageManager.GetString("mail_ApproveProcesscard_1"), Order.RevNr), CustomColors.InfoText_Color.Warning, "Warning!");
            Mail.Body = string.Format(LanguageManager.GetString("mail_ApproveProcesscard_2"), Order.PartNumber, latestRevNr, Order.ProdLine, Order.ProdGroup, Order.WorkOperation, Order.OrderNumber, Order.Operation, Order.RevNr);
            Mail.Send(LanguageManager.GetString("mail_ApproveProcesscard"), 8);
        }

        public static void NotifyUserCodeResetPassword(string? code)
        {
            var mail = new MailMessage();
            mail.To.Add(Person.Mail);
            Mail.Body = "Hej, <br /><br />" +
                        $"Du har begärt att återställa ditt lösenord i Digital Production Program.<br />" +
                        $"Använd följande kod för att återställa ditt lösenord:<br /> <b>{code}</b><br />" +
                        "Koden är giltig i 2 minuter.<br /><br />" +
                        "Om du inte har begärt detta, vänligen ignorera detta meddelande.<br /><br />";
            Mail.Send($"Återställning av lösenord för Digital Production Program", 0, mail);
        }
        public static void NotifyAllUsersSpecificInfo()
        {
            var mailMessage = new MailMessage();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Mail FROM [User].Person WHERE Mail IS NOT NULL";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                if (IsValidEmail(reader[0].ToString()))
                    mailMessage.To.Add(reader[0].ToString() ?? string.Empty);
                else
                    MessageBox.Show($@"Epostadressen {reader[0]} är inte giltig, vänligen kontrollera den i databasen [User].Person");

            mailMessage.From = new MailAddress("DigitalProductionProgram@optinova.com");
            mailMessage.Body = "Efter klockan 14:00 på fredag behöver DPP installeras om för att få tillgång till den senaste versionen.<br />" +
                               "Den gamla versionen kommer ej att fungera längre.<br /><br />" +
                                  "1. Avinstallera först det gamla programmet. (Högerklicka på ikonen för DPP och välj Avinstallera/Uninstall)<br />" +
                                  "2. Gå till utforskaren och gå till V:\\Elektroniska Körprotokoll\\V.3.0 och dubbelklicka på filen setup.exe<br />" +
                                  "3. Klart<br /><br />" +
                                  "Kontakta Admin vid bekymmer.";
            mailMessage.Subject = "OBS! DPP Behöver installeras om.";
            mailMessage.IsBodyHtml = true;
            var client = new SmtpClient
            {
                Host = "mail.optinova.fi",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25,
                EnableSsl = false,
            };
            if (mailMessage.To.Count > 0)
                client.Send(mailMessage);
            client.Dispose();

           

        }
        public static void Inform_QA_ApproveProcesscard(string revNr)
        {
            Body = $"ArtikelNr: {Order.PartNumber} - RevNr: {revNr} - ProdLinje: {Order.ProdLine} -  ProduktTyp: {Order.ProdType} - Arbetsoperation: {Order.WorkOperation}";
            Send("Godkänn detta ArtikelNr.", 8);

        }
    }
}
