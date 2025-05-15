using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;

namespace DigitalProductionProgram.PrintingServices
{
    internal class CustomFonts
    {
        public static void change_To_NA(Control ctrl)
        {
            ctrl.Text = "N/A";
            ctrl.ForeColor = Color.Black;
            var font_Name = ctrl.Font.Name;
            ctrl.Font = new Font(font_Name, 7F);
        }
        public static Pen thinBlack = new Pen(Color.Black, 0);
        public static Pen mediumBlack = new Pen(Color.Black, 1);
        public static Pen thickBlack = new Pen(Color.Black, 2);
        public static Pen thickRed = new Pen(Color.Red, 2);
        public static SolidBrush gray = new SolidBrush(Color.Gray);
        public static SolidBrush operatör_clr = new SolidBrush(Color.FromArgb(30,30,30));
        public static SolidBrush parametrar_clr = new SolidBrush(Color.DarkSlateGray);
        public static SolidBrush lightGray = new SolidBrush(Color.LightGray);
        public static SolidBrush dimGray = new SolidBrush(Color.DimGray);
        public static SolidBrush empty_Space = new SolidBrush(Color.DarkGray);
        public static SolidBrush min_max = new SolidBrush(Color.FromArgb(230,230,230));
        public static SolidBrush nom = new SolidBrush(Color.LightGray);
        public static SolidBrush back_Rubrik = new SolidBrush(Color.FromArgb(235, 235, 235));
        public static SolidBrush front_Rubrik = new SolidBrush(Color.DodgerBlue);
        public static SolidBrush black = new SolidBrush(Color.Black);
        public static SolidBrush red = new SolidBrush(Color.Red);

        public static Font A5 = new Font("Arial", 5);
        public static Font A6 = new Font("Arial", 6);
        public static Font A6_B = new Font("Arial", 6,FontStyle.Bold);
        public static Font A7 = new Font("Arial", 7);
        public static Font A7_I = new Font("Arial", 7, FontStyle.Italic);
        public static Font A7_B = new Font("Arial", 7, FontStyle.Bold);
        public static Font A8 = new Font("Arial", 8);
        public static Font A8_B = new Font("Arial", 8, FontStyle.Bold);
        public static Font A8_I = new Font("Arial", 8, FontStyle.Italic);
        public static Font A8_BI = new Font("Arial", 8, FontStyle.Bold | FontStyle.Italic);
        public static Font A9 = new Font("Arial", 9);
        public static Font A9_B = new Font("Arial", 9, FontStyle.Bold);
        public static Font A9_I = new Font("Arial", 9, FontStyle.Italic);
        public static Font A9_BI = new Font("Arial", 9, FontStyle.Bold | FontStyle.Italic);
        public static Font A10_B = new Font("Arial", 10, FontStyle.Bold);
        public static Font A10_BI = new Font("Arial", 10, FontStyle.Bold | FontStyle.Italic);
        public static Font A10_I = new Font("Arial", 10, FontStyle.Italic);
        public static Font A11 = new Font("Arial", 11);
        public static Font A11_B = new Font("Arial", 11, FontStyle.Bold);
        public static Font A12_B = new Font("Arial", 12, FontStyle.Bold);
        public static Font A12_BI = new Font("Arial", 9, FontStyle.Bold | FontStyle.Italic);
        public static Font Arial14 = new Font("Arial", 14);
        public static Font C5 = new Font("Courier New", 5);
        public static Font C7 = new Font("Courier New", 7);
        public static Font Con5_B = new Font("Consolas", 5, FontStyle.Bold);
        public static Font Con7_B = new Font("Consolas", 7, FontStyle.Bold);
        public static Font C6_B = new Font("Courier New", 6, FontStyle.Bold);
        public static Font C8_B = new Font("Courier New", 8, FontStyle.Bold);
        public static Font N_A = new Font("Courier New", 7);
        public static Font Info = new Font("Arial", 8, FontStyle.Bold | FontStyle.Italic);
        public static Font operatörFont_small = new Font("Courier New", 6);
        public static Font operatörFont = new Font("Courier New", 8);
        public static Font måttFont = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        public static Font parametrarFont_small = new Font("Consolas", 6);
        public static Font parametrarFont_Extra_small = new Font("Consolas", 5);
        public static Font parametrarFont = new Font("Consolas", 8);
        public static Font parametrarFont_Bold = new Font("Consolas", 8, FontStyle.Bold);
        public static Font C9 = new Font("Courier New", 9);
        public static Font C10 = new Font("Courier New", 10);
        public static Font C10_B = new Font("Courier New", 10, FontStyle.Bold);

        public static Font M8 = new Font("Monaco", 8F);
        public static Font M8_B = new Font("Monaco", 8F, FontStyle.Bold);
        public static Font P12_B = new Font("Palatino LinoType", 12F, FontStyle.Bold);
    }

    public class CustomColors
    {
        public static Color Empty_Back = Color.FromArgb(60, 60, 60);
        public static Color Discarded_Back = Color.DimGray;
        public static Color Discarded_Front = Color.FromArgb(60, 60, 60);
        public static Color Ok_Back = Color.FromArgb(198, 239, 206);
        public static Color Ok_Front = Color.FromArgb(0, 97, 0);
        public static Color Bad_Back = Color.FromArgb(255, 199, 206);
        public static Color Bad_Front = Color.FromArgb(156, 0, 6);
        public static Color Warning_Back = Color.FromArgb(255, 235, 156);
        public static Color Warning_Front = Color.FromArgb(156, 101, 0);
        public static Color Neutral_Back = Color.FromArgb(180, 198, 231);
        public static Color Neutral_Front = Color.DarkSlateGray;
        //public static Color 


        public static Color Teal = Color.FromArgb(6, 81, 87);
        public static Color Teal_Font = Color.FromArgb(181, 210, 207);
        public static Color CoolGrey = Color.FromArgb(81, 85, 92);
        public static Color CoolGrey_Font = Color.FromArgb(147, 146, 153);
        public static Color MediumGrey = Color.FromArgb(185, 188, 189);
        public static Color MediumGrey_Font = Color.FromArgb(147, 150, 149);
        public static Color LightGrey = Color.FromArgb(214, 216, 213);
        public static Color LightGrey_Font = Color.FromArgb(185, 182, 185);
        public static Color Parmesan = Color.FromArgb(239, 228, 177);
        public static Color Parmesan_Font = Color.FromArgb(171, 150, 85);
        public static Color LightTeal = Color.FromArgb(45, 113, 122);
        public static Color Blue = Color.FromArgb(63, 115, 140);
        public static Color Blue_Font = Color.FromArgb(187, 215, 228);
        public static Color LightBlue = Color.FromArgb(184, 220, 231);
        public static Color LightBlue_Font = Color.FromArgb(119, 142, 162);

        public static Color Aqua = Color.FromArgb(112, 198, 176);
        public static Color Aqua_Font = Color.FromArgb(57, 108, 121);
        public static Color Load_BackColor_WorkOperation(string workoperation)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT Back_Red, Back_Green, Back_Blue FROM Settings.QuickStart_Color WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)";
            con.Open();

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@workoperation", workoperation);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (int.TryParse(reader["Back_Red"].ToString(), out var BackRed) == false)
                    Mail.Inform_SuperAdmin_Error($"Arbetsoperation: {workoperation} saknar färger i databastabellen [Settings].QuickStart_Color, fixa!!!");
                int.TryParse(reader["Back_Green"].ToString(), out var BackGreen);
                int.TryParse(reader["Back_Blue"].ToString(), out var BackBlue);

                return Color.FromArgb(BackRed, BackGreen, BackBlue);
            }

            return Color.FromArgb(255, 255, 255);
        }
        public static Color Load_ForeColor_Workoperation(string workoperation)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT Fore_Red, Fore_Green, Fore_Blue FROM Settings.QuickStart_Color WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)";
            con.Open();

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@workoperation", workoperation);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int.TryParse(reader["Fore_Red"].ToString(), out var BackRed);
                int.TryParse(reader["Fore_Green"].ToString(), out var BackGreen);
                int.TryParse(reader["Fore_Blue"].ToString(), out var BackBlue);

                return Color.FromArgb(BackRed, BackGreen, BackBlue);
            }

            return Color.FromArgb(0, 0, 0);
        }

       
     

        public static Color Info_Front = SystemColors.ControlDarkDark;
        public static Color Info_Back = SystemColors.Info;
        public static Color Parametrar_Saknas_Back = Color.FromArgb(250, 250, 250);
        public static Color Parametrar_Saknas_Front = Color.Red;

        public enum InfoText_Color
        {
            Info,
            Ok, 
            Bad,
            Warning,
            Neutral
        }
    }
    
}