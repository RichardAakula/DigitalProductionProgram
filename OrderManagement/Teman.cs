using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.OrderManagement
{
    internal class Teman
    {
        public static Themes Theme;
        public enum Themes
            {
                Beach = 0,
                Forest = 1,
                Sky = 2,
                Sun = 3,
                Water = 4,
                Winter = 5,
                Black = 6,
                Pink = 7,
                Light = 8,
                Cars = 9,
                Animals = 10,
                Music = 11,
                Houses = 12,
                Dark = 13,
                Nature = 14,
                Discography = 15,
                Beta = 17,
                Optinova = 18
            }
        public static Image rndBackPic
        {
            get
            {
                if (Monitor.Monitor.factory == Monitor.Monitor.Factory.Thailand && Person.Role == "SuperAdmin")
                    return null;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) Image FROM [Settings].Themes WHERE Theme = @theme ORDER BY NEWID()";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@theme", Theme.ToString());
                object value;
                try
                {
                    value = cmd.ExecuteScalar();
                }
                catch (SqlException exc)
                {
                    return null;
                }
                    
                if (value is null)
                    return null;
                var img = (byte[])value;
                var ms = new MemoryStream(img);
                return Image.FromStream(ms);
            }
        }

        public static Color backColor_Panels, backColor_LeftPanel, backColor_RightPanel, backColor_Main, backColor_Buttons, backColor_Menu, backColor_PriorityPlan, backColor_OrderInformation, backColor_MeasurePoints, backColor_MeasureStats, backColor_Chart, backColor_ExtraInfo,
            foreColor_LeftPanel, foreColor_Buttons, foreColor_PriorityPlan, foreColor_OrderInformation, foreColor_MeasurePoints, foreColor_MeasureStats, foreColor_ExtraInfo,  foreColor_Menu;

        public static Dictionary<string, Action> load_Themes
            {
                get
                {
                Dictionary<string, Action> themes = new Dictionary<string, Action>
                {
                    { "Sky", Sky },
                    { "Pink", Pink },
                    { "Forest", Forest },
                    { "Water", Water },
                    { "Winter", Winter },
                    { "Beach", Beach },
                    { "Black", Black },
                    { "Light", Light },
                    { "Sun", Sun },
                    { "Cars", Cars },
                    { "Animals", Animals },
                    { "Music", Music },
                    { "Houses", Houses },
                    { "Dark", Dark },
                    { "Nature", Nature },
                    { "Discography", Discography },
                    { "Beta", Beta},
                    { "Optinova", Optinova}
                };

                return themes;
                }
            }


        public static void Choose_Theme()
        {
            try
            {
                load_Themes[Theme.ToString()]();
            }
            catch(Exception e)
            {
                _ = Activity.Stop($"try-catch: Choose_Theme(); {e.Message}");
            }
        }


        public static void Beach()
        {
            Theme = Themes.Beach;

            backColor_Main = Color.FromArgb(180, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.Black);
            foreColor_Menu = CustomColors.Parmesan_Font;

            backColor_Buttons = Color.FromArgb(180, Color.Black);
            foreColor_Buttons = CustomColors.CoolGrey_Font;

            backColor_OrderInformation = Color.FromArgb(140, Color.Black);
            backColor_Chart = Color.RosyBrown;
            foreColor_OrderInformation = Color.Snow;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.Lime;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(210, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Bisque;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(129,99,99);
            foreColor_LeftPanel = Color.Coral;

            backColor_PriorityPlan = Color.FromArgb(60, 60, 60);
            foreColor_PriorityPlan = Color.Olive;

        }
        public static void Forest()
        {
            Theme = Themes.Forest;

            backColor_Main = Color.FromArgb(180, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.Black);
            foreColor_Menu = CustomColors.Parmesan_Font;

            backColor_Buttons = Color.FromArgb(180, Color.DarkGreen);
            foreColor_Buttons = Color.Snow;

            backColor_OrderInformation =  Color.FromArgb(140, Color.Black);
            backColor_Chart = Color.DarkGreen;
            foreColor_OrderInformation = Color.Snow;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.Lime;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(210, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Bisque;

            backColor_LeftPanel = backColor_RightPanel = Color.DarkOliveGreen;
            foreColor_LeftPanel = Color.LightGreen;

            backColor_PriorityPlan = Color.FromArgb(60, 60, 60);
            foreColor_PriorityPlan = Color.Olive;
        }
        public static void Sky()
        {
            Theme = Themes.Sky;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.Black);
            foreColor_Menu = CustomColors.Parmesan_Font;

            backColor_Buttons = Color.FromArgb(180, Color.Black);
            foreColor_Buttons = Color.DeepSkyBlue;

            backColor_OrderInformation =  Color.FromArgb(140, Color.Black);
            backColor_Chart = Color.DeepSkyBlue;
            foreColor_OrderInformation = Color.Snow;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.Aquamarine;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(210, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Bisque;

            backColor_LeftPanel = backColor_RightPanel = Color.DeepSkyBlue;
            foreColor_LeftPanel = Color.DarkSlateGray;

            backColor_PriorityPlan = Color.FromArgb(60, 60, 60);
            foreColor_PriorityPlan = Color.Maroon;
        }
        public static void Sun()
        {
            Theme = Themes.Sun;

            backColor_Main = Color.FromArgb(140, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.Black);
            foreColor_Menu = CustomColors.Parmesan_Font;

            backColor_Buttons = Color.FromArgb(180, Color.Black);
            foreColor_Buttons = Color.Yellow;

            backColor_OrderInformation = backColor_Chart = Color.FromArgb(140, Color.Black);
            backColor_Chart = Color.DarkGoldenrod;
            foreColor_OrderInformation = Color.LightGoldenrodYellow;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.Gold;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(210, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Bisque;

            backColor_LeftPanel = backColor_RightPanel = Color.Yellow;
            foreColor_LeftPanel = Color.DarkSlateGray;

            backColor_PriorityPlan = Color.DarkGoldenrod;
            foreColor_PriorityPlan = Color.Black;
        }
        public static void Water()
        {
            Theme = Themes.Water;

            backColor_Main = Color.FromArgb(220, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.DarkBlue);
            foreColor_Menu = Color.LightSkyBlue;

            backColor_Buttons = Color.FromArgb(180, Color.DarkBlue);
            foreColor_Buttons = Color.LightSkyBlue;

            backColor_OrderInformation =  Color.FromArgb(140, Color.Blue);
            backColor_Chart = Color.Blue;
            foreColor_OrderInformation = Color.LightGoldenrodYellow;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.LightBlue;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(230, Color.MidnightBlue);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.LightSkyBlue;

            backColor_LeftPanel = backColor_RightPanel = Color.DodgerBlue;
            foreColor_LeftPanel = Color.LightGreen;

            backColor_PriorityPlan = Color.LightSkyBlue;
            foreColor_PriorityPlan = Color.MidnightBlue;
        }
        public static void Winter()
        {
            Theme = Themes.Winter;

            backColor_Main = Color.FromArgb(200, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.Black);
            foreColor_Menu = Color.FloralWhite;

            backColor_Buttons = Color.FromArgb(180, Color.Black);
            foreColor_Buttons = Color.FloralWhite;

            backColor_OrderInformation = Color.FromArgb(140, Color.White);
            backColor_Chart = Color.Black;
            foreColor_OrderInformation = Color.Black;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.FloralWhite;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(160, Color.White);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Black;

            backColor_LeftPanel = backColor_RightPanel = Color.LightGray;
            foreColor_LeftPanel = Color.DarkOliveGreen;

            backColor_PriorityPlan = Color.NavajoWhite;
            foreColor_PriorityPlan = Color.Black;
        }
        public static void Black()
        {
            Theme = Themes.Black;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(200, Color.Black);
            foreColor_Menu = Color.SteelBlue;

            backColor_Buttons = Color.FromArgb(200, Color.Black);
            foreColor_Buttons = Color.FloralWhite;

            backColor_OrderInformation =  Color.FromArgb(140, Color.Black);
            backColor_Chart = Color.Black;
            foreColor_OrderInformation = Color.NavajoWhite;

            backColor_ExtraInfo = Color.FromArgb(140, Color.Black);
            foreColor_ExtraInfo = Color.DarkGoldenrod;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(160, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Orange;

            backColor_LeftPanel = backColor_RightPanel = Color.Black;
            foreColor_LeftPanel = Color.IndianRed;

            backColor_PriorityPlan = Color.FromArgb(20,20,20);
            foreColor_PriorityPlan = Color.Maroon;
        }
        public static void Light()
        {
            Theme = Themes.Light;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(200, Color.Black);
            foreColor_Menu = Color.FloralWhite;

            backColor_Buttons = Color.FromArgb(200, Color.Black);
            foreColor_Buttons = Color.FloralWhite;

            backColor_OrderInformation = Color.FromArgb(140, Color.Black);
            backColor_Chart = Color.Gray;
            foreColor_OrderInformation = Color.NavajoWhite;

            backColor_ExtraInfo = Color.Snow;
            foreColor_ExtraInfo = Color.DarkSlateGray;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(100, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Black;

            backColor_LeftPanel = backColor_RightPanel = Color.LightGray;
            foreColor_LeftPanel = Color.DimGray;

            backColor_PriorityPlan = Color.FromArgb(220,220,220);
            foreColor_PriorityPlan = Color.Maroon;
        }
        public static void Pink()
        {
            Theme = Themes.Pink;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(200, Color.DarkOrchid);
            foreColor_Menu = Color.FloralWhite;

            backColor_Buttons = Color.FromArgb(200, Color.DeepPink);
            foreColor_Buttons = Color.LightPink;

            backColor_OrderInformation = Color.FromArgb(190, Color.DarkOrchid);
            backColor_Chart = Color.Orchid;
            foreColor_OrderInformation = Color.NavajoWhite;

            backColor_ExtraInfo = Color.FromArgb(180, Color.Black);
            foreColor_ExtraInfo = Color.DarkOrchid;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(160, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Pink;

            backColor_LeftPanel = backColor_RightPanel = Color.Purple;
            foreColor_LeftPanel = Color.Pink;

            backColor_PriorityPlan = Color.DarkMagenta;
            foreColor_PriorityPlan = Color.LightCyan;
        }
        public static void Cars()
        {
            Theme = Themes.Cars;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(200, Color.DarkSlateGray);
            foreColor_Menu = Color.Sienna;

            backColor_Buttons = Color.FromArgb(200, Color.DarkSlateGray);
            foreColor_Buttons = Color.Sienna;

            backColor_OrderInformation = Color.FromArgb(190, Color.Black);
            backColor_Chart = Color.Sienna;
            foreColor_OrderInformation = Color.Sienna;

            backColor_ExtraInfo = Color.FromArgb(180, Color.Black);
            foreColor_ExtraInfo = Color.Sienna;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(160, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Pink;

            backColor_LeftPanel = backColor_RightPanel = Color.DarkSlateGray;
            foreColor_LeftPanel = Color.Sienna;

            backColor_PriorityPlan = Color.DarkSlateGray;
            foreColor_PriorityPlan = Color.NavajoWhite;
        }
        public static void Animals()
        {
            Theme = Themes.Animals;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(180, Color.Maroon);
            foreColor_Menu = Color.GreenYellow;

            backColor_Buttons = Color.FromArgb(200, Color.DarkSlateGray);
            foreColor_Buttons = Color.PaleGreen;

            backColor_OrderInformation = Color.FromArgb(190, Color.Black);
            backColor_Chart = Color.DarkSlateGray;
            foreColor_OrderInformation = Color.OldLace;

            backColor_ExtraInfo = Color.FromArgb(180, Color.Black);
            foreColor_ExtraInfo = Color.OldLace;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(160, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Pink;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(110,110,0);
            foreColor_LeftPanel = Color.OldLace;

            backColor_PriorityPlan = Color.DarkSlateGray;
            foreColor_PriorityPlan = Color.NavajoWhite;
        }
        public static void Music()
        {
            Theme = Themes.Music;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(35,35,35);
            foreColor_Menu = Color.GreenYellow;

            backColor_Buttons = Color.FromArgb(35, 35, 35);
            foreColor_Buttons = Color.PaleVioletRed;

            backColor_OrderInformation = Color.FromArgb(190, Color.Black);
            backColor_Chart = Color.BurlyWood;
            foreColor_OrderInformation = Color.DarkRed;

            backColor_ExtraInfo = Color.FromArgb(190, Color.Black);
            foreColor_ExtraInfo = Color.OldLace;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(190, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Pink;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(35, 35, 35);
            foreColor_LeftPanel = Color.OldLace;

            backColor_PriorityPlan = Color.FromArgb(35, 35, 35);
            foreColor_PriorityPlan = Color.NavajoWhite;
        }
        public static void Houses()
        {
            Theme = Themes.Houses;
            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(15, 15, 15);
            foreColor_Menu = Color.GreenYellow;

            backColor_Buttons = Color.FromArgb(35, 35, 35);
            foreColor_Buttons = Color.MistyRose;

            backColor_OrderInformation = Color.FromArgb(190, Color.Black);
            backColor_Chart = Color.PaleVioletRed;
            foreColor_OrderInformation = Color.PaleVioletRed;

            backColor_ExtraInfo = Color.FromArgb(190, Color.Black);
            foreColor_ExtraInfo = Color.OldLace;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(190, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.RosyBrown;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(45, 50, 50);
            foreColor_LeftPanel = Color.OldLace;

            backColor_PriorityPlan = Color.FromArgb(35, 35, 35);
            foreColor_PriorityPlan = Color.NavajoWhite;
        }
        public static void Dark()
        {
            Theme = Themes.Dark;

            backColor_Menu = Color.FromArgb(15, 15, 15);
            foreColor_Menu = Color.Gray;

            backColor_Buttons = Color.FromArgb(30, 30, 35);
            foreColor_Buttons = Color.MistyRose;

            backColor_OrderInformation = Color.FromArgb(200, Color.Black);
            backColor_Chart = Color.FromArgb(38, 38, 38);
            foreColor_OrderInformation = Color.DarkGray;

            backColor_ExtraInfo = Color.FromArgb(200, Color.Black);
            foreColor_ExtraInfo = Color.Gray;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(220, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.Gray;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(25, 25, 25);
            foreColor_LeftPanel = Color.Gray;

            backColor_PriorityPlan = Color.FromArgb(20, 20, 20);
            foreColor_PriorityPlan = Color.DimGray;
        }
        public static void Nature()
        {
            Theme = Themes.Nature;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(15, 66, 15);
            foreColor_Menu = Color.GreenYellow;

            backColor_Buttons = Color.FromArgb(35, 78, 35);
            foreColor_Buttons = Color.MistyRose;

            backColor_OrderInformation = Color.FromArgb(180, Color.DarkGreen);
            backColor_Chart = Color.FromArgb(35, 78, 35);
            foreColor_OrderInformation = Color.White;

            backColor_ExtraInfo = Color.FromArgb(190, Color.Black);
            foreColor_ExtraInfo = Color.OldLace;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(220, Color.DarkGreen);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.White;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(45, 120, 50);
            foreColor_LeftPanel = Color.OldLace;

            backColor_PriorityPlan = Color.FromArgb(35, 95, 35);
            foreColor_PriorityPlan = Color.DarkGoldenrod;
        }
        public static void Discography()
        {
            Theme = Themes.Discography;

            backColor_Main = Color.FromArgb(210, Color.Black);

            backColor_Menu = Color.FromArgb(25, 20, 25);
            foreColor_Menu = Color.GreenYellow;

            backColor_Buttons = Color.FromArgb(30, 30, 35);
            foreColor_Buttons = Color.MistyRose;

            backColor_OrderInformation = Color.FromArgb(180, Color.Black);
            backColor_Chart = Color.FromArgb(20,20,20);
            foreColor_OrderInformation = Color.PaleGoldenrod;

            backColor_ExtraInfo = Color.FromArgb(190, Color.Black);
            foreColor_ExtraInfo = Color.Gold;

            backColor_MeasurePoints = backColor_MeasureStats = Color.FromArgb(220, Color.Black);
            foreColor_MeasurePoints = foreColor_MeasureStats = Color.White;

            backColor_LeftPanel = backColor_RightPanel = Color.FromArgb(35, 35, 35);
            foreColor_LeftPanel = Color.Gold;

            backColor_PriorityPlan = Color.FromArgb(45, 45, 45);
            foreColor_PriorityPlan = Color.DarkGoldenrod;
        }
        public static void Beta()
        {
            Theme = Themes.Beach;

            backColor_Panels = Color.FromArgb(180, Color.Red);

            foreColor_Menu = Color.LightGreen;
            foreColor_ExtraInfo = Color.Lime;
            foreColor_Buttons = Color.White;
            foreColor_PriorityPlan = Color.Olive;
        }

        public static void Optinova()
        {
            Theme = Themes.Optinova;
            backColor_Main = Color.FromArgb(35, 35, 35); //CustomColors.LightGrey;

            backColor_Menu = CustomColors.Teal;
            foreColor_Menu = CustomColors.Teal_Font;

            backColor_Buttons = CustomColors.Parmesan;
            foreColor_Buttons = CustomColors.Parmesan_Font;

            backColor_OrderInformation = CustomColors.Blue;
            foreColor_OrderInformation = CustomColors.Blue_Font;

            backColor_Chart = CustomColors.Teal;

            backColor_ExtraInfo = CustomColors.Blue;
            foreColor_ExtraInfo = CustomColors.Blue_Font;

            backColor_MeasurePoints = backColor_MeasureStats = CustomColors.LightBlue;
            foreColor_MeasurePoints = foreColor_MeasureStats = CustomColors.LightBlue_Font;

            backColor_LeftPanel = backColor_RightPanel = CustomColors.CoolGrey;
            foreColor_LeftPanel = CustomColors.CoolGrey_Font;

            backColor_PriorityPlan = CustomColors.MediumGrey;
            foreColor_PriorityPlan = CustomColors.MediumGrey_Font;
        }

        public static void IterateThroughControls(Control parentControl, Color color)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                switch (ctrl)
                {
                    case Label label:
                        if (label.Text != "NaN")
                            label.ForeColor = color;
                        break;
                    default:
                        IterateThroughControls(ctrl, color);
                        break;
                }
            }
        }
    }
}
