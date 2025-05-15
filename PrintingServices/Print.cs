using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices.Workoperation_Printouts;
using DigitalProductionProgram.Protocols.MainInfo;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.PrintingServices
{
    internal class Print
    {
        public static bool IsPrinterInstalled
        {
            get
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    var printerSettings = new PrinterSettings
                    {
                        PrinterName = printer
                    };

                    return printerSettings.IsValid;
                }

                return false;
            }
        }

        public static Dictionary<string, string?>? utskrift_Korprotokoll;
        public static Dictionary<string, string?>? utskrift_Processkort;
        public static Dictionary<string, string?>? List_PrintOut_Korprotokoll
        {
            get
            {
                var korprotokoll = new Dictionary<string, string>();

                if (Order.OrderID is null) //Om inget ordernummer finns fylls Listan upp med tomma värden
                    return List_PrintOut_Korprotokoll_empty;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT TOP(1) OrderNr, PartNr, RevNr, ProdType, Amount, Unit, Customer, Description, Date_Start, Date_Stop, Name_Start, LC_Rengjort_Extrudern_Ja, LC_Rengjort_Extrudern_Nej_Samma_Mtrl, LC_Rengjort_Extrudern_Mjukt_Hårt, LC_Rengjort_Extrudern_Ljus_Mörk, LC_Name, LC_Date, Rum_Temp, Rum_Fukt, Comments, LC_Comments, Version
                        FROM [Order].MainData AS main
                        WHERE main.OrderID = @id";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                        korprotokoll.Add(reader.GetName(i), reader[i].ToString() ?? string.Empty);

                    korprotokoll.TryAdd("N/A", "N/A");
                }

                return korprotokoll;
            }
        }
        public static Dictionary<string, string?>? List_PrintOut_Korprotokoll_empty
        {
            get
            {
                var list_utskrift_Extrudering = new Dictionary<string, string>();

                Order.PartNumber = "1234567";
                Order.OrderNumber = "Q12345";
                Order.Operation = "10";
                Order.RevNr = string.Empty;
                Order.ProdType = string.Empty;
                Order.ProdLine = string.Empty;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@revNr", Order.RevNr);
                    cmd.Parameters.AddWithValue("@prodtype", Order.ProdType);
                    cmd.Parameters.AddWithValue("@prodline", Order.ProdLine);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            if (!list_utskrift_Extrudering.ContainsKey(reader.GetName(i)))
                                list_utskrift_Extrudering.Add(reader.GetName(i), string.Empty);
                        }
                        list_utskrift_Extrudering.TryAdd("N/A", "N/A");
                    }
                }

                Order.PartNumber = null;
                Order.OrderNumber = null;
                Order.Operation = null;
                Order.RevNr = null;

                return list_utskrift_Extrudering;
            }
        }
        public static Dictionary<string, string?> List_PrintOut_Processkort
        {
            get
            {
                var korparametrar = new Dictionary<string, string?>();
                var query = "SELECT * FROM Processcard.MainData WHERE PartID = @partid";

                using var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!korparametrar.ContainsKey(reader.GetName(i)))
                            korparametrar.Add(reader.GetName(i), reader[i].ToString() ?? string.Empty);
                    }

                    korparametrar.TryAdd("N/A", "N/A");
                }
                return korparametrar.Count == 0 ? List_utskrift_Extrudering_Processkort_TEF_empty : korparametrar;
            }
        }

        public static Dictionary<string, string?> List_utskrift_Extrudering_Processkort_TEF_empty
        {
            get
            {
                var korparametrar = new Dictionary<string, string?>();
                using var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand("SELECT TOP(1) * FROM Processcard.MainData", con);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        korparametrar.Add(reader.GetName(i), "N/A");
                    }

                }
                korparametrar.Add("N/A", "N/A");
                return korparametrar;
            }

        }

        
        public static float StringWidth(string? text, Font font, Graphics? g)
        {
            var size = g.MeasureString(text, font);
            return (int)size.Width;
        }
        public static bool IsTextDate(string? text)
        {
            if (text.Contains('-') && text.Contains(':') && text.Length > 15)
                return true;
            return false;
        }
        public static void Static_InfoText(PrintPageEventArgs e, string? text, float x, int y, bool IsRightMargin = false, bool IsSmallFont = false)
        {
            var font = CustomFonts.Info;
            if (IsSmallFont)
                font = CustomFonts.A8;
            if (IsRightMargin)
                if (e.Graphics != null)
                    x -= StringWidth(text, font, e.Graphics);
            e.Graphics?.DrawString(text, font, CustomFonts.black, x, y);
        }

        public static void Print_Unit(PrintPageEventArgs e, string text, int x, int y, int height, int width)
        {
            Thin_Rectangle(e, x, y, width, height);
            x += width / 2;
           
            e.Graphics?.DrawString(text, CustomFonts.A8, CustomFonts.black, x - TextRenderer.MeasureText(text, CustomFonts.A8).Width / 2f, y + 3);
            
        }

        public static void Protocol_InfoText(PrintPageEventArgs e, string? text, bool isValueCritical, float x, int y, int MaxWidth, bool IsCenter, bool IsWrap, bool IsRightMargin = false)
        {
            if (IsRightMargin)
                x -= StringWidth(text, CustomFonts.parametrarFont, e.Graphics);

            if (text == "Direkt Hackning")
                if (text == "True")
                    text = "✓";
            if (text == "False")
                text = " ";
            if (string.IsNullOrEmpty(text) || ControlValidator.IsStringNA(text))
                Text_NA(e, x, y, IsCenter);
            else
            {
                var string_Length = StringWidth(text, CustomFonts.parametrarFont, e.Graphics);
                if (string_Length < MaxWidth || IsWrap == false)
                {
                    //1 Rad - Normal Font
                    var font = CustomFonts.parametrarFont;
                    if (isValueCritical)
                        font = CustomFonts.parametrarFont_Bold;

                    PrintTextProcesskort_1_Row(e, font, text, x, y, IsCenter);
                    return;
                }

                string_Length = StringWidth(text, CustomFonts.parametrarFont_small, e.Graphics);
                var TotalRows = (int)Math.Ceiling(string_Length / (double) MaxWidth);
                switch (TotalRows)
                {
                    case 1:
                        PrintTextProcesskort_1_Row(e, CustomFonts.parametrarFont_small, text, x, y, IsCenter);
                        break;
                    case 2:
                        PrintTextProcesskrot_2_Rows(e, text, x, y, MaxWidth, IsCenter);
                        break;
                    case 3:
                        PrintTextProcesskort_3_Rows(e, text, x, y, MaxWidth, IsCenter);
                        break;
                }
            }
        }

        public static void Text_Operatör(PrintPageEventArgs e, string? text, int x, int y, int maxWidth = 10000, bool IsCenter = false, bool IsWrap = false, bool is_Ok_NA = true)
        {
            if ((string.IsNullOrEmpty(text) || text == "N/A") && is_Ok_NA)
                Text_NA(e, x, y, IsCenter);
            else
            {

                if (StringWidth(text, CustomFonts.operatörFont, e.Graphics) > maxWidth)
                {
                    if (IsWrap && StringWidth(text, CustomFonts.operatörFont_small, e.Graphics) > maxWidth)
                    {
                        var text_1 = text.Substring(0, text.IndexOf('+') + 1);
                        var text_2 = text.Substring(text_1.Length, text.Length - text_1.Length);
                        if (StringWidth(text_2, CustomFonts.operatörFont_small, e.Graphics) > maxWidth)
                        {
                            text = text_2;
                            text_1 = text.Substring(0, text.Length / 2);
                            text_2 = text.Substring(text_1.Length, text.Length - text_1.Length);
                        }
                        if (IsTextDate(text))
                        {
                            text_1 = text.Substring(0, 10);
                            text_2 = text.Substring(11, 5);
                        }
                        if (IsCenter)
                        {
                            e.Graphics.DrawString(text_1, CustomFonts.operatörFont_small, CustomFonts.operatör_clr, x - (TextRenderer.MeasureText(text_1, CustomFonts.operatörFont_small).Width / 2f), y - 2);
                            e.Graphics.DrawString(text_2, CustomFonts.operatörFont_small, CustomFonts.operatör_clr, x - (TextRenderer.MeasureText(text_2, CustomFonts.operatörFont_small).Width / 2f), y + 6);
                        }
                        else
                        {
                            e.Graphics.DrawString(text_1, CustomFonts.operatörFont_small, CustomFonts.operatör_clr, x, y - 2);
                            e.Graphics.DrawString(text_2, CustomFonts.operatörFont_small, CustomFonts.operatör_clr, x, y + 6);
                        }
                    }
                    else
                    {
                        Font font;
                        var size = 8;
                        if (maxWidth > 0)
                        {
                            float width;
                            do
                            {
                                size--;
                                font = new Font("Courier New", size);
                                width = StringWidth(text, font, e.Graphics);
                            } while (width > maxWidth && size >= 5);
                        }
                        else
                            font = new Font("Courier New", size);
                        if (IsCenter)
                            e.Graphics.DrawString(text, font, CustomFonts.operatör_clr, x - TextRenderer.MeasureText(text, font).Width / 2.0f, y + 2);
                        else
                            e.Graphics.DrawString(text, font, CustomFonts.operatör_clr, x, y + 2);
                    }
                }
                else
                {
                    if (IsCenter)
                        e.Graphics.DrawString(text, CustomFonts.operatörFont, CustomFonts.operatör_clr, x - TextRenderer.MeasureText(text, CustomFonts.operatörFont).Width / 2f, y);
                    else
                        e.Graphics.DrawString(text, CustomFonts.operatörFont, CustomFonts.operatör_clr, x, y);
                }
            }
        }
        
        public static void Text_PageNumber(PrintPageEventArgs e, string? text, int x, int y)
        {
            var font = new Font("Arial", 9, FontStyle.Italic);
            x -= (int)StringWidth(text, font , e.Graphics);
            e.Graphics.DrawString(text, font, CustomFonts.operatör_clr, x, y);
        }

        public static void Text_StartUp_Header(PrintPageEventArgs e, string text, int x, int y)
        {
            e.Graphics.DrawString(text, CustomFonts.A8_BI, CustomFonts.operatör_clr, x - TextRenderer.MeasureText(text, CustomFonts.operatörFont_small).Width / 2f, y);
        }
        public static void Text_StartUpWithOven_Header(PrintPageEventArgs e, int startup, int x, int y, int colwidth)
        {
            var totalOvens = Module.SinteringOven.TotalOvens(startup);

            for (var oven = 1; oven < totalOvens + 1; oven++)
            {
                var text = $"{startup}-Ugn# {oven}";
                Print.Filled_Rectangle(e, CustomFonts.lightGray, x - colwidth / 2, y - 3, colwidth, PrintVariables.RowHeight);
                e.Graphics.DrawString(text, CustomFonts.A8_BI, CustomFonts.operatör_clr, x - TextRenderer.MeasureText(text, CustomFonts.operatörFont_small).Width / 2f, y);
                x += colwidth;
            }
                
        }
        private static void PrintTextProcesskort_1_Row(PrintPageEventArgs e, Font font, string? text, float x, int y, bool IsCenter)
        {
            if (IsCenter)
                e.Graphics.DrawString(text, font, CustomFonts.parametrar_clr, x - StringWidth(text, font, e.Graphics) / 2, y);
            else
                e.Graphics.DrawString(text, font, CustomFonts.parametrar_clr, x, y);
        }
        private static void PrintTextProcesskrot_2_Rows(PrintPageEventArgs e, string? text, float x, int y, int MaxWidth, bool IsCenter)
        {
            var text_1 = text.Substring(0, text.Length / 2);
            var text_2 = text.Substring(text_1.Length, text.Length - text_1.Length);
            text_1 = text_1.TrimStart(); text_1 = text_1.TrimEnd();
            text_2 = text_2.TrimStart(); text_2 = text_2.TrimEnd();

            if (IsCenter)
            {
                e.Graphics.DrawString(text_1, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x - StringWidth(text_1, CustomFonts.parametrarFont_small, e.Graphics) / 2, y - 3);
                e.Graphics.DrawString(text_2, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x - StringWidth(text_2, CustomFonts.parametrarFont_small, e.Graphics) / 2, y + 7);
            }
            else
            {
                e.Graphics.DrawString(text_1, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x, y - 4);
                e.Graphics.DrawString(text_2, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x, y + 6);
            }
        }
        private static void PrintTextProcesskort_3_Rows(PrintPageEventArgs e, string? text, float x, int y, int MaxWidth, bool IsCenter)
        {
            var StringLength = text.Length / 3;
            var text_1 = text.Substring(0, StringLength);
            var text_2 = text.Substring(text_1.Length, StringLength);
            var text_3 = text.Substring(text_1.Length + text_2.Length, text.Length - (text_1.Length + text_2.Length));
            
            text_1 = text_1.TrimStart(); text_1 = text_1.TrimEnd();
            text_2 = text_2.TrimStart(); text_2 = text_2.TrimEnd();
            text_3 = text_3.TrimStart(); text_3 = text_3.TrimEnd();
            if (IsCenter)
            {
                e.Graphics.DrawString(text_1, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x - StringWidth(text_1,CustomFonts.parametrarFont_small, e.Graphics) / 2, y - 10);
                e.Graphics.DrawString(text_2, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x - StringWidth(text_2, CustomFonts.parametrarFont_small, e.Graphics) / 2, y - 1);
                e.Graphics.DrawString(text_3, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x - StringWidth(text_3, CustomFonts.parametrarFont_small, e.Graphics) / 2, y + 10);
            }
            else
            {
                e.Graphics.DrawString(text_1, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x, y - 10);
                e.Graphics.DrawString(text_2, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x, y - 1);
                e.Graphics.DrawString(text_3, CustomFonts.parametrarFont_small, CustomFonts.parametrar_clr, x, y + 0);
            }

        }

        private static int Total_Lines(string? text)
        {
            var ctr = 1;
            char[] chars = { '+', '-', ' ', '/' };
            foreach (var c in text)
                if (chars.Contains(c))
                    ctr++;
            return ctr;
        }
        private static string? Text_Line(string? text)
        {
            char[] chars = {'+', '-', ' ', '/'  };
            foreach(var c in chars)
                if (text.Contains(c))
                    return text.Substring(0, text.IndexOf(c) + 1);
            return text;
        }
        public static void Print_Rubrik(PrintPageEventArgs e, string? text, int x, int y, int maxWidth, bool IsCenter = false)
        {
            var lines = new List<string?>();
            var total_lines = Total_Lines(text);

            if (total_lines > 1)
            {
                for (var i = 0; i < total_lines - 1; i++)
                {
                    var textLine = Text_Line(text);
                    lines.Add(textLine);
                    text = text.Remove(0, textLine.Length);
                    if (i == total_lines - 2)
                        lines.Add(text);
                }
            }
            else
                lines.Add(text);

            for (var i = 0; i < lines.Count - 1; i++)
            {
                var new_line = lines[i] + lines[i + 1];
                if (StringWidth(new_line, CustomFonts.A7_B, e.Graphics) < maxWidth)
                {
                    lines[i] = new_line;
                    lines.RemoveAt(i + 1);
                }
            }
            y -= 4;
            foreach (var line in lines)
            {
                if (IsCenter)
                    e.Graphics.DrawString(line, CustomFonts.A7_B, CustomFonts.black, x - StringWidth(line, CustomFonts.A7_B, e.Graphics) / 2, y);
                else
                    e.Graphics.DrawString(line, CustomFonts.A7_B, CustomFonts.black, x, y);
                y += 10;
            }
        }


        public static void Filled_Rectangle(PrintPageEventArgs e, Brush clr, int x, int y, int width, int height)
        {
            e.Graphics.FillRectangle(clr, x, y, width, height);
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, x, y, width, height);
        }
        public static void Thin_Rectangle(PrintPageEventArgs e, int x, int y, float width, float height, string? text = null, Font font = null, bool IsCenter = true)
        {
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, x, y, width, height);
            if (text != null)
            {
                if (string.IsNullOrEmpty(text))
                    text = "N/A";
                if (IsCenter)
                    e.Graphics.DrawString(text, font, CustomFonts.black, x + width / 2 - StringWidth(text, font, e.Graphics) / 2, y + height / 2 - 4);
                else
                    e.Graphics.DrawString(text, font, CustomFonts.black, x + 5,y + height / 2 - 4 );       
            }
        }
        public static void Header_Measureprotocol(PrintPageEventArgs e, int x, int y, int width, int height, string? text)
        {
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, x, y, width, height);

            var headers = text.Split(' ').ToList();
            var font = CustomFonts.A6_B;
            switch (headers.Count)
            {
                case 1:
                    var textwidth = TextRenderer.MeasureText(headers[0], font).Width;
                    var X = x + width / 2 - TextRenderer.MeasureText(headers[0], font).Width / 2;
                    e.Graphics.DrawString(headers[0], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[0], font).Width / 2, y + 15);
                    break;
                case 2:
                   
                    if (StringWidth($"{headers[0]} {headers[1]}", font, e.Graphics) > width-2)
                    {
                        e.Graphics.DrawString(headers[0], font, CustomFonts.black, x + width / 2 - (TextRenderer.MeasureText(headers[0], font).Width / 2), y + 8);
                        e.Graphics.DrawString(headers[1], font, CustomFonts.black, x + width / 2 - (TextRenderer.MeasureText(headers[1], font).Width / 2), y + 19);
                    }
                    else
                        e.Graphics.DrawString($"{headers[0]} {headers[1]}", font, CustomFonts.black, x + width / 2 - (TextRenderer.MeasureText($"{headers[0]} {headers[1]}", font).Width / 2), y + 15);
                    break;

                case 3:
                   if (StringWidth($"{headers[0]} {headers[1]}", font, e.Graphics) > width-2)
                   {
                        // Om 0+1 är för stora
                        if (StringWidth($"{headers[1]} {headers[2]}", font, e.Graphics) > width-2)
                        {
                            e.Graphics.DrawString(headers[0], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[0], font).Width / 2, y + 2);
                            e.Graphics.DrawString(headers[1], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[1], font).Width / 2, y + 13);
                            e.Graphics.DrawString(headers[2], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[2], font).Width / 2, y + 24);
                        }
                        else
                        {
                            e.Graphics.DrawString(headers[0], font, CustomFonts.black, x + width / 2 - (TextRenderer.MeasureText(headers[0], font).Width / 2), y + 8);
                            e.Graphics.DrawString($"{headers[1]} {headers[2]}", font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText($"{headers[1]} {headers[2]}", font).Width / 2, y + 19);
                        }
                   }
                   else
                   {
                        e.Graphics.DrawString($"{headers[0]} {headers[1]}", font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText($"{headers[0]} {headers[1]}", font).Width / 2, y + 8);
                        e.Graphics.DrawString(headers[2], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[2], font).Width / 2, y + 19);
                   }
                        
                   break;

                case 4:
                    e.Graphics.DrawString(headers[0], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[0], font).Width / 2, y + 1);
                    e.Graphics.DrawString(headers[1], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[1], font).Width / 2, y + 10);
                    e.Graphics.DrawString(headers[2], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[2], font).Width / 2, y + 19);
                    e.Graphics.DrawString(headers[3], font, CustomFonts.black, x + width / 2 - TextRenderer.MeasureText(headers[3], font).Width / 2, y + 28);
                    break;

            }

            
        }
        public static void Thick_Rectangle(PrintPageEventArgs e, int x, int y, int width, int height)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), x, y, width, height);
        }
        public static void Text_NA(PrintPageEventArgs e, float x, int y, bool is_Center)
        {
            if (!string.IsNullOrEmpty(Order.OrderNumber))
            {
                if (is_Center)
                    e.Graphics.DrawString("N/A", CustomFonts.N_A, CustomFonts.red, x - (TextRenderer.MeasureText("N/A", CustomFonts.N_A).Width / 2), y + 1);
                else
                    e.Graphics.DrawString("N/A", CustomFonts.N_A, CustomFonts.red, x, y + 1);
            }

        }
        public static void Rubrik(PrintPageEventArgs e, string? text, int x, int y, int width)
        {
            e.Graphics.FillRectangle(CustomFonts.back_Rubrik, x, y, width, 22);
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, x, y, width, 22);
            e.Graphics.DrawString(text, CustomFonts.A10_B, CustomFonts.front_Rubrik, x + 3, y + 3);
        }

        public static void TemplateHeader(PrintPageEventArgs e, string text)
        {
            e.Graphics.FillRectangle(CustomFonts.back_Rubrik, PrintVariables.LeftMargin, 70, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 22);
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin, 70, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 22);
            e.Graphics.DrawString(text, new Font("Arial", 12, FontStyle.Bold), CustomFonts.black, PrintVariables.LeftMargin + 3, 72);
        }
        
        
        public static void ProductInformation(PrintPageEventArgs e)
        {
            Rubrik(e, LanguageManager.GetString("productInfo"), PrintVariables.LeftMargin, 89, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin, 111, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 68);
            e.Graphics.DrawRectangle(CustomFonts.thinBlack, 430, 111, 210, 68);

            //6 rader, 2 kolumner + 4 kolumner i z-led(djup)
            object[,,] text = { 
                { { LanguageManager.GetString("label_Customer"),      30,  114 }, { utskrift_Korprotokoll["Customer"],       125, 116 } },
                { { LanguageManager.GetString("label_Description"),   30,  137 }, { utskrift_Korprotokoll["Description"],    125, 139 } },
                { { LanguageManager.GetString("date"),                435, 114 }, { utskrift_Korprotokoll["Date_Start"],     485, 116 } },
                { { LanguageManager.GetString("name"),                435, 137 }, { utskrift_Korprotokoll["Name_Start"],     485, 139 } },
                { { LanguageManager.GetString("label_OrderNr"),       643, 114 }, { Order.OrderNumber,                       703, 116 } },
                { { LanguageManager.GetString("label_PartNumber"),        643, 137 }, { utskrift_Korprotokoll["PartNr"],         703, 139 } } };

            for (var x = 0; x < 6; x++)
            {
                Protocol_InfoText(e, (string)text[x, 0, 0], false, (int)text[x,0,1], (int)text[x, 0, 2], 200, false, true);
                Text_Operatör(e, (string)text[x, 1, 0], (int)text[x, 1, 1], (int)text[x, 1, 2], 300, false, true);
                //e.Graphics.DrawString((string)text[x, 0, 0], Pennor.A9_B, Pennor.black, (int)text[x, 0, 1], (int)text[x, 0, 2]);
                //e.Graphics.DrawString((string)text[x, 1, 0], Pennor.operatörFont, Pennor.parametrar_clr, (int)text[x, 1, 1], (int)text[x, 1, 2]);
            }
        }
       
       
        
        
        
       
        public static void Copy(PrintPageEventArgs e)
        {
            if (Order.Is_PrintOutCopy && !string.IsNullOrEmpty(Order.OrderNumber))
            {
                var fnt = new Font("Arial Narrow", 200);
                e.Graphics.RotateTransform(55f);
                e.Graphics.DrawString(LanguageManager.GetString("copy"), fnt, new SolidBrush(Color.FromArgb(100, Color.Gray)), 300, -150);
                e.Graphics.RotateTransform(-55f);
            }
        }
        public static void Copy_Landscape(PrintPageEventArgs e)
        {
            if (Order.Is_PrintOutCopy && !string.IsNullOrEmpty(Order.OrderNumber))
            {
                var fnt = new Font("Arial Narrow", 200);
                e.Graphics.RotateTransform(35f);
                e.Graphics.DrawString(LanguageManager.GetString("copy"), fnt, new SolidBrush(Color.FromArgb(100, Color.Gray)), 300, -150);
                e.Graphics.RotateTransform(-35);
            }
        }


       
        public class Diagram
        {
            public static void Print_Order_Info(PrintPageEventArgs e)
            {
                Rubrik(e, "Produktinformation:", PrintVariables.LeftMargin, 89, PrintVariables.MaxPaperWidth);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin, 111, PrintVariables.MaxPaperWidth, 48);

                //6 rader, 2 kolumner + 4 kolumner i z-led(djup)
                object[,,] text =                       { { { "Kund",                          30,  114 }, { Order.Customer,              125, 116 } },
                                                          { { "Benämning",                     30,  137 }, { Order.Description,         125, 139 } },
                                                          { { "T.O.nr",                        628, 114 }, { Order.OrderNumber,           698, 116 } },
                                                          { { "ArtikelNr",                     628, 137 }, { Order.PartNumber,         698, 139 } } };

                for (var x = 0; x < 4; x++)
                {
                    e.Graphics.DrawString((string)text[x, 0, 0], CustomFonts.A9_B, CustomFonts.black, (int)text[x, 0, 1], (int)text[x, 0, 2]);
                    e.Graphics.DrawString((string)text[x, 1, 0], CustomFonts.operatörFont, CustomFonts.parametrar_clr, (int)text[x, 1, 1], (int)text[x, 1, 2]);
                }
            }
            public static void Print_Chart(PrintPageEventArgs e, Chart chart)
            {
                //Rectangle rect = new Rectangle(160, -800, 1000, 804);
                var rect = new Rectangle(160, -800, 1000, 804);
                e.Graphics.RotateTransform(90f);
                chart.Printing.PrintPaint(e.Graphics, rect);
                e.Graphics.RotateTransform(-90f);
            }
        }
       
        

        public class Processcard
        {
            public static void LEFT_Header(PrintPageEventArgs e, string[] headers, int height, int y)
            {
                for (int i = 0; i < headers.Length; i++)
                    headers[i] = headers[i].Replace("\n", "").Replace("\r", "");
            

                Thin_Rectangle(e, PrintVariables.LeftMargin, y, 18, height);
                var font = CustomFonts.Con7_B;
                var letterHeight = (int)Math.Round(e.Graphics.MeasureString("A", font).Height, 0);
                //int letterHeight = 12;
                var distance = 14;
                var headersLength = headers[0].Length;
                var x = 29;
                if (headers.Length > 1)
                {//Om 2 rubriker skall skrivas parallellt bredvid varandra
                    x = 33;
                    headersLength = Math.Max(headers[0].Length, headers[1].Length);
                }

                if (headersLength * letterHeight > height)
                {//Om Rubriken är högre än rutan så minskas fontstorleken
                    font = CustomFonts.Con5_B;
                    distance = 8;
                    letterHeight = 8;
                    if (headers.Length == 1)
                        x = 30;
                }

                foreach (var header in headers)
                {
                    var _y = y + (height - letterHeight * header.Length) / 2;
                    foreach (var _char in header)
                    {
                        e.Graphics.DrawString(_char.ToString(), font, CustomFonts.black, x, _y);
                        _y += distance;
                    }
                    x -= 6;
                }
            }
        }

        internal class ProcessCardBasedOn
        {
            public static void PrintOut(int x, PrintPageEventArgs e)
            {
                Header(e, x);
                CheckBoxes(e, x);
                Info(e, x);
                ValidatedOnOrders(e, x);
                ApprovedProcesscard(e, x);
                RevisionInfo(e, x);                    
               
            }

            private static void Header(PrintPageEventArgs e, int x)
            {
                Rubrik(e, LanguageManager.GetString("btn_ProcesscardBasedOn"), x, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
            }
            private static void CheckBoxes(PrintPageEventArgs e, int x)
            {
                var checkboxes = new (string Key, string Label, int Offset)[]
                {
                    ("Historiska_Data", "rb_HistoricalData", 25),
                    ("Validerat", "rb_Validated", 45),
                    ("Framtagning_Processfönster", "rb_FramtagningAvProcessfönster", 65)
                };

                var anyChecked = false;

                foreach (var (key, label, offset) in checkboxes)
                {
                    e.Graphics.DrawRectangle(CustomFonts.thickBlack, x + 9, PrintVariables.Y + offset, 12, 12);
                    Protocol_InfoText(e, LanguageManager.GetString(label), false, x + 24, PrintVariables.Y + offset, 100, false, false);

                    if (bool.TryParse(utskrift_Processkort[key], out var isChecked) && isChecked)
                    {
                        e.Graphics.DrawString("\u2714", CustomFonts.A7, CustomFonts.black, 34, PrintVariables.Y + offset + 1);
                        anyChecked = true;
                    }
                }

                // If none of the checkboxes were checked, check "Framtagning av Processfönster"
                if (!anyChecked)
                    e.Graphics.DrawString("\u2714", CustomFonts.A7, CustomFonts.black, 34, PrintVariables.Y + 66);
            }
            private static void Info(PrintPageEventArgs e, int x)
            {
                var estBy = LanguageManager.GetString("label_EstablishedBy");
                var appBy = LanguageManager.GetString("label_ApprovedBy");
                Protocol_InfoText(e, "Rev.Nr:", false, x + 631, PrintVariables.Y + 31, 50, false, false);
                Protocol_InfoText(e, estBy, false, x + 674 - TextRenderer.MeasureText(estBy, CustomFonts.parametrarFont).Width, PrintVariables.Y + 51, 200, false, false);
                Protocol_InfoText(e, appBy, false, x + 674 - TextRenderer.MeasureText(appBy, CustomFonts.parametrarFont).Width, PrintVariables.Y + 71, 200, false, false);


                int[] kolumn = { x + 24, x + 674 };
                int[] rad = { PrintVariables.Y + 25, PrintVariables.Y + 45, PrintVariables.Y + 65 };

                for (var r = 0; r < 3; r++)
                    e.Graphics.DrawRectangle(CustomFonts.thinBlack, kolumn[1] + 5, rad[r] + 5, 60, 15);

                if (string.IsNullOrEmpty(Order.RevNr))
                    Text_NA(e, kolumn[1] + 28, rad[0] + 7, false);
                else
                    e.Graphics.DrawString(Order.RevNr, CustomFonts.operatörFont, CustomFonts.parametrar_clr, (kolumn[1]) + 28, rad[0] + 7);

                if (string.IsNullOrEmpty(utskrift_Processkort["UpprättatAv_Sign_AnstNr"]))
                    Text_NA(e, kolumn[1] + 10, rad[1] + 7, false);
                else
                    e.Graphics.DrawString(utskrift_Processkort["UpprättatAv_Sign_AnstNr"], CustomFonts.operatörFont, CustomFonts.parametrar_clr, (kolumn[1]) + 10, rad[1] + 7);

                if (string.IsNullOrEmpty(utskrift_Processkort["QA_sign"]))
                    Text_NA(e, kolumn[1] + 10, rad[2] + 7, false);
                else
                    e.Graphics.DrawString(utskrift_Processkort["QA_sign"], CustomFonts.operatörFont, CustomFonts.parametrar_clr, (kolumn[1]) + 10, rad[2] + 7);

            }
            private static void ValidatedOnOrders(PrintPageEventArgs e, int x)
            {
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, x + 220, PrintVariables.Y + 25, 200, 45);

                if (string.IsNullOrEmpty(utskrift_Processkort["Validerade_Loter"]) || utskrift_Processkort["Validerade_Loter"] == "N/A")
                    Text_NA(e, x + 221, PrintVariables.Y + 25, false);
                else
                    e.Graphics.DrawString(utskrift_Processkort["Validerade_Loter"], CustomFonts.operatörFont, CustomFonts.parametrar_clr, x + 221, PrintVariables.Y + 25);
            }
            private static void ApprovedProcesscard(PrintPageEventArgs e, int x)
            {
                var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                e.Graphics.DrawString(LanguageManager.GetString("label_ProcesscardApprovedDate"), CustomFonts.M8_B, CustomFonts.black, x + 64, PrintVariables.Y + 80);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, x + 250, PrintVariables.Y + 80, 120, 15);
                string date;
                if (utskrift_Processkort["GodkäntDatum"] == "N/A" || string.IsNullOrEmpty(Order.RevNr))
                    date = "N/A";
                else if (string.IsNullOrEmpty(utskrift_Processkort["GodkäntDatum"]))
                    date = string.Empty;
                else
                    date = DateTime.Parse(utskrift_Processkort["GodkäntDatum"]).ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
                

                if (date == "N/A" || date == string.Empty)
                    Text_NA(e, x + 254, PrintVariables.Y + 83, false);
                else
                    e.Graphics.DrawString(date, CustomFonts.operatörFont, CustomFonts.parametrar_clr, x + 254, PrintVariables.Y + 83);
            }
            private static void RevisionInfo(PrintPageEventArgs e, int x)
            {
                var rectangle_StartY = PrintVariables.Y;

                e.Graphics.DrawString(LanguageManager.GetString("revisionInfo"), CustomFonts.M8_B, CustomFonts.black, x+10, PrintVariables.Y + 100);
                int yStartInnerRectangle = PrintVariables.Y + 115;
                PrintVariables.Y += 130;
                
                var revInfo = utskrift_Processkort["RevInfo"];
                float pageWidth = e.PageBounds.Width - 2 * x;
                const float padding = 10;


                var commentLines = Regex.Split(revInfo, @"\r\n|\r|\n"); //comments.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var index = 0;
                float totalHeight = 0;
                while (index < commentLines.Length)
                {
                    var text = commentLines[index].Replace("\t", "    "); // Replace tab with four spaces
                    var textSize = e.Graphics.MeasureString(text, CustomFonts.operatörFont, (int)pageWidth - PrintVariables.LeftMargin);

                    var rect = new RectangleF(x + 4, PrintVariables.Y - 10, pageWidth - PrintVariables.LeftMargin, textSize.Height + 2 * padding);
                    totalHeight += textSize.Height;
                    var stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near,
                        FormatFlags = StringFormatFlags.LineLimit
                    };

                    e.Graphics.DrawString(text, CustomFonts.operatörFont, CustomFonts.operatör_clr, rect, stringFormat);
                    PrintVariables.Y += (int)textSize.Height + 4;// RowHeight;//* (int)padding + 10;
                    index++;
                }
                var yEndInnerRectangle = PrintVariables.Y - yStartInnerRectangle;
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin + 2, yStartInnerRectangle, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin - 4, yEndInnerRectangle - 2);

                e.Graphics.DrawRectangle(CustomFonts.thinBlack, x, rectangle_StartY, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, PrintVariables.Y - rectangle_StartY); 
            }
        }
        internal class ExtraLineClearance
        {
            public static void Info(PrintPageEventArgs e, int y)
            {
                var instruction =  Templates_LineClearance.MainTemplate.LineClearance_CenturiLink.Substring(Templates_LineClearance.MainTemplate.LineClearance_CenturiLink.LastIndexOf('/') + 1);
                e.Graphics.DrawString($"Före tillverkning av order: {Order.OrderNumber} är Lince Clearance uförd enligt instruktion {instruction}.", CustomFonts.A9_BI, CustomFonts.black, 40, y);
            }
           
            public static void Add_Task(PrintPageEventArgs e, ref int y, string header, string[] tasks)
            {
                e.Graphics.DrawString($"{header}:", CustomFonts.A11_B, CustomFonts.black, 30, y);

                y += 20;
                foreach (var t in tasks)
                {
                    e.Graphics.DrawString($"· {t}", CustomFonts.A9, CustomFonts.black, 35, y);
                    Thin_Rectangle(e, 700, y, 15, 15, "✓", CustomFonts.operatörFont);
                    y += 25;
                }
            }
            public static void Text_DoneByAndApprovedBy(PrintPageEventArgs e, int y)
            {
                var LC_AnstNr = string.Empty;
                var LC_Approved_AnstNr = string.Empty;
                var LC_Name = string.Empty;
                var LC_Approved_Name = string.Empty;
                var LC_Date = new DateTime();
                var LC_Approved_Date = new DateTime();
                var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = Properties.Resources.Load_LineClearance;
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LC_Name = reader["LC_Name"].ToString();
                        LC_Approved_Name = reader["LC_Approved_Name"].ToString();
                        DateTime.TryParse(reader["LC_Date"].ToString(), out LC_Date);
                        DateTime.TryParse(reader["LC_Approved_Date"].ToString(), out LC_Approved_Date);
                        if (!string.IsNullOrEmpty(LC_Name))
                            LC_AnstNr = Person.Get_AnstNrWithName(LC_Name);
                        if (!string.IsNullOrEmpty(LC_Approved_Name))
                            LC_Approved_AnstNr = Person.Get_AnstNrWithName(LC_Approved_Name);
                    }
                }

                e.Graphics.DrawString("Line Clearance utförd av:    Anst.Nr:", new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic), CustomFonts.black, 42, y);
                e.Graphics.DrawString($"{LC_AnstNr}", CustomFonts.C10_B, CustomFonts.black, 270, y);
                e.Graphics.DrawString("Namn:", CustomFonts.A10_I, CustomFonts.black, 310, y);
                e.Graphics.DrawString($"{LC_Name}", CustomFonts.C10_B, CustomFonts.black, 360, y);
                e.Graphics.DrawString("Datum/Tid:", CustomFonts.A10_I, CustomFonts.black, 550, y);
                
                var formattedDate = LC_Date.ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
                e.Graphics.DrawString($"{formattedDate}", CustomFonts.C10_B, CustomFonts.black, 630, y);
                e.Graphics.DrawString("Godkänd för produktion av:    Anst.Nr:", new Font("Arial", 9f, FontStyle.Bold | FontStyle.Italic), CustomFonts.black, 28, y + 30);
                e.Graphics.DrawString($"{LC_Approved_AnstNr}", CustomFonts.C10_B, CustomFonts.black, 270, y + 30);
                e.Graphics.DrawString("Namn:", CustomFonts.A10_I, CustomFonts.black, 310, y + 30);
                e.Graphics.DrawString($"{LC_Approved_Name}", CustomFonts.C10_B, CustomFonts.black, 360, y + 30);
                e.Graphics.DrawString("Datum/Tid:", CustomFonts.A10_I, CustomFonts.black, 550, y + 30);
                formattedDate = LC_Approved_Date.ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
                e.Graphics.DrawString($"{formattedDate}", CustomFonts.C10_B, CustomFonts.black, 630, y + 30);
            }

            public static void Kommentarer(PrintPageEventArgs e)
            {
                var comments = utskrift_Korprotokoll["LC_Comments"];
                Print_Protocol.PrintOut.Comments(PrintVariables.LeftMargin, (int)PrintVariables.PageHeight - 130, comments,  e);
            }
        }

        public static class LineClearance
        {
            public static void LineClearance_A(PrintPageEventArgs e)
            {
                e.Graphics.DrawString(LanguageManager.GetString("print_LineClearance_1"), CustomFonts.A9, CustomFonts.black, 305, PrintVariables.Y + 5);
                Print.Thin_Rectangle(e, 391, PrintVariables.Y + 22, 148, 22);
                Print.Thin_Rectangle(e, 539, PrintVariables.Y + 22, 240, 22);
                if (DateTime.TryParse(Print.utskrift_Korprotokoll["LC_Date"], out var date))
                    e.Graphics.DrawString(date.ToString("yyyy-MM-dd HH:mm"), CustomFonts.operatörFont, CustomFonts.operatör_clr, 400, PrintVariables.Y + 26);
                else
                    Print.Text_NA(e, 470, PrintVariables.Y + 26, true);
                Print.Text_Operatör(e, Print.utskrift_Korprotokoll["LC_Name"], 550, PrintVariables.Y + 26, 500, false, true);

                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y + 44, 515, 25);
                Print.Thin_Rectangle(e, 539, PrintVariables.Y + 44, 100, 25);
                Print.Thin_Rectangle(e, 639, PrintVariables.Y + 44, 70, 25);
                Print.Thin_Rectangle(e, 709, PrintVariables.Y + 44, 70, 25);

                e.Graphics.DrawString(LanguageManager.GetString("label_RoomTempMoist"), CustomFonts.A8, CustomFonts.black, 541, PrintVariables.Y + 52);
                Print.Text_Operatör(e, Print.utskrift_Korprotokoll["Rum_Temp"], 653, PrintVariables.Y + 51, 40);
                e.Graphics.DrawString("C°", CustomFonts.A8, CustomFonts.black, 690, PrintVariables.Y + 52);
                Print.Text_Operatör(e, Print.utskrift_Korprotokoll["Rum_Fukt"], 719, PrintVariables.Y + 51, 40);
                e.Graphics.DrawString("%Re", CustomFonts.A8, CustomFonts.black, 750, PrintVariables.Y + 52);
            }
            public static void LineClearance_B(PrintPageEventArgs e)
            {
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 387, 162, 122, 20);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 509, 162, 270, 20);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin, 182, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 19);

                e.Graphics.DrawString(LanguageManager.GetString("print_LineClearance_1"), CustomFonts.A9, CustomFonts.black, 292, 168);

                if (DateTime.TryParse(Print.utskrift_Korprotokoll["LC_Date"], out var date))
                    e.Graphics.DrawString(date.ToString("yyyy-MM-dd HH:mm"), CustomFonts.operatörFont, CustomFonts.operatör_clr, 390, 168);
                Print.Text_Operatör(e, Print.utskrift_Korprotokoll["LC_Name"], 512, 168, 500, false, true);

                e.Graphics.DrawString(LanguageManager.GetString("chb_TempKalibCheck"), CustomFonts.A10_B, CustomFonts.black, 26, 183);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 405, 185, 12, 12);
                if (MainInfo_C.Is_TempKalibChecked)
                    e.Graphics.DrawString("\u2714", CustomFonts.A8, CustomFonts.black, 404, 186);
            }
        }
        public static class RunProtocol
        {
            public static void StartUps(PrintPageEventArgs e, int x, int y, int totalRows, int colWidth, int formtemplateid, int startUp_From, int startUp_To, int machineindex, bool IsHeaderVisible, bool IsModuleUsingOven)
            {
                var org_colWidth = colWidth;
                var totalStartUps = Module.TotalStartUps;

                for (var startup = startUp_From; startup < startUp_To + 1; startup++)
                {
                    if (Templates_Protocol.MainTemplate.IsUsingOven && IsModuleUsingOven == false)
                    {
                        using var con = new SqlConnection(Database.cs_Protocol);
                        const string query = "SELECT MAX(Ugn) FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @startup";
                        con.Open();
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        cmd.Parameters.AddWithValue("@startup", startup);
                        var total = cmd.ExecuteScalar();
                        if (total != null)
                            if (short.TryParse(total.ToString(), out var result))
                                colWidth = result * org_colWidth;
                    }
                    if (startup > totalStartUps)
                        return;
                    if (IsHeaderVisible)
                    {
                        if (IsModuleUsingOven)
                            Print.Text_StartUpWithOven_Header(e, startup, x + colWidth / 2, y + 3, colWidth);
                        else
                        {
                            Print.Filled_Rectangle(e, CustomFonts.lightGray, x, y, colWidth, PrintVariables.RowHeight);
                            Print.Text_StartUp_Header(e, startup.ToString(), x + colWidth / 2, y + 3);
                        }

                        y += PrintVariables.RowHeight;
                    }

                    if (IsModuleUsingOven)
                    {
                        DataWithOven(e, y, x, colWidth, totalRows, machineindex, startup, formtemplateid);
                        x += colWidth * Module.SinteringOven.TotalOvens(startup);
                    }

                    else
                    {
                        Data(e, y, x, colWidth, totalRows, machineindex, startup, formtemplateid);
                        x += colWidth;
                    }


                    if (IsHeaderVisible)
                        y -= PrintVariables.RowHeight;
                }

            }
            private static void Data(PrintPageEventArgs e, int y, int x, int width, int totalRows, int machineindex, int uppstart, int formtemplateid)
            {
                //for (var row = 0; row < totalRows; row++)
                //    Print.Thin_Rectangle(e, x, y + PrintVariables.RowHeight * row, width, PrintVariables.RowHeight);

                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                SELECT 
                    MAX(CASE WHEN template.ColumnIndex = 0 THEN minValue.Value END) AS MinValue,
                    MAX(CASE WHEN template.ColumnIndex = 1 THEN nomValue.Value END) AS NomValue,
                    MAX(CASE WHEN template.ColumnIndex = 2 THEN maxValue.Value END) AS MaxValue,
                    protocol.Value, 
                    protocol.TextValue, 
                    protocol.DateValue, 
                    protocol.Uppstart, 
                    protocol.Ugn, 
                    template.RowIndex, 
                    template.Type, 
                    template.Decimals    
                FROM 
                    Protocol.Template AS template
                LEFT JOIN [Order].Data AS protocol
                    ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                    AND protocol.OrderID = @orderid
                    AND protocol.Uppstart = @startup
                    AND (COALESCE(protocol.MachineIndex, 0) = COALESCE(@machineindex, 0))
                JOIN Protocol.Description AS descr
                    ON descr.id = template.ProtocolDescriptionID
    
                -- Hämta Min-värdet (ColumnIndex = 0)
                LEFT JOIN Processcard.Data AS minValue
                    ON minValue.TemplateID = template.ID
                    AND template.ColumnIndex = 0
                    AND minValue.PartID = @partid
    
                -- Hämta Nom-värdet (ColumnIndex = 1)
                LEFT JOIN Processcard.Data AS nomValue
                    ON nomValue.TemplateID = template.ID
                    AND template.ColumnIndex = 1
                    AND nomValue.PartID = @partid
    
                -- Hämta Max-värdet (ColumnIndex = 2)
                LEFT JOIN Processcard.Data AS maxValue
                    ON maxValue.TemplateID = template.ID
                    AND template.ColumnIndex = 2
                    AND maxValue.PartID = @partid
                WHERE 
                    template.FormTemplateID = @formtemplateid
                    AND template.RowIndex IS NOT NULL
                GROUP BY
                    protocol.Value, 
                    protocol.TextValue, 
                    protocol.DateValue, 
                    protocol.Uppstart, 
                    protocol.Ugn, 
                    template.RowIndex, 
                    template.Type, 
                    template.Decimals
                ORDER BY 
                    template.RowIndex";
                var cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@partid", Order.PartID);
                cmd.Parameters.AddWithValue("@startup", uppstart);
                cmd.Parameters.AddWithValue("@machineindex", machineindex);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    var value = string.Empty;

                    switch (type)
                    {
                        case 0:
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            double.TryParse(reader["MinValue"].ToString(), out var MinValue);
                            double.TryParse(reader["MaxValue"].ToString(), out var MaxValue);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                            {
                                var belowMin = MinValue > 0 && NumberValue < MinValue;
                                var aboveMax = MaxValue > 0 && NumberValue > MaxValue;

                                if (belowMin || aboveMax)
                                    value = $"{Processcards.Processcard.Format_Value(NumberValue, decimals)}*";
                                else
                                    value = Processcards.Processcard.Format_Value(NumberValue, decimals);
                            }
                            
                            break;
                        case 1:
                            value = reader["TextValue"].ToString();
                            break;
                        case 3:
                            value = reader["DateValue"].ToString();
                            break;
                    }
                    Print.Thin_Rectangle(e, x, y + PrintVariables.RowHeight * row, width, PrintVariables.RowHeight);

                    Print.Text_Operatör(e, value, x + width / 2 + 2, y + PrintVariables.RowHeight * row + 2, width, true, true);
                }
            }
            private static void DataWithOven(PrintPageEventArgs e, int y, int x, int width, int totalRows, int machineindex, int startup, int formtemplateid)
            {
                var totalOvens = Module.SinteringOven.TotalOvens(startup);

                for (var oven = 1; oven < totalOvens + 1; oven++)
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        const string query = @"
                            SELECT DISTINCT 
                                protocol.Value, 
                                protocol.TextValue, 
                                protocol.DateValue, 
                                protocol.Uppstart, 
                                protocol.Ugn, 
                                template.RowIndex, 
                                template.Type, 
                                template.Decimals
                            FROM 
                                Protocol.Template AS template
                                    LEFT JOIN [Order].Data AS protocol
                                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                                        AND protocol.OrderID = @orderid
                                        AND protocol.Uppstart = @startup
                                        AND protocol.Ugn = @oven
                                        AND (COALESCE(protocol.MachineIndex, 0) = COALESCE(@machineindex, 0))
                                    JOIN Protocol.Description AS descr
                                        ON descr.id = template.ProtocolDescriptionID
                            WHERE 
                                template.FormTemplateID = @formtemplateid
                                    --AND template.revision = (SELECT ProtocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid)
                                    AND template.RowIndex IS NOT NULL
                            ORDER BY 
                                template.RowIndex;";
                        var cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        cmd.Parameters.AddWithValue("@startup", startup);
                        cmd.Parameters.AddWithValue("@oven", oven);
                        cmd.Parameters.AddWithValue("@machineindex", machineindex);
                        cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int.TryParse(reader["Type"].ToString(), out var type);
                            int.TryParse(reader["RowIndex"].ToString(), out var row);
                            var value = string.Empty;

                            switch (type)
                            {
                                case 0:
                                    int.TryParse(reader["Decimals"].ToString(), out var decimals);
                                    if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                        value = string.Empty;
                                    else
                                        value = Processcards.Processcard.Format_Value(NumberValue, decimals);
                                    break;
                                case 1:
                                    value = reader["TextValue"].ToString();
                                    break;
                                case 3:
                                    value = reader["DateValue"].ToString();
                                    break;
                            }

                            Print.Thin_Rectangle(e, x, y + PrintVariables.RowHeight * row, width, PrintVariables.RowHeight);
                            Print.Text_Operatör(e, value, x + width / 2 + 2, y + PrintVariables.RowHeight * row + 2, width, true, true);
                        }
                    }
                    x += width;
                }
            }
        }

        internal class Compound_Protocol
        {
            public static void Print_OrderInfo(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("ARTIKEL NR", CustomFonts.A8_BI, CustomFonts.black, PrintVariables.LeftMargin, 120);
                Print.Text_Operatör(e, Order.PartNumber, 110, 120);
                e.Graphics.DrawString("ORDER NR", CustomFonts.A8_BI, CustomFonts.black, PrintVariables.LeftMargin, 150);
                Print.Text_Operatör(e, Order.OrderNumber, 110, 150);

                Print_Halvfabrikat(e);
                e.Graphics.DrawString("kg", CustomFonts.A8_BI, CustomFonts.black, 520, 120);
                e.Graphics.DrawString("kg", CustomFonts.A8_BI, CustomFonts.black, 520, 150);
                Print_MainInfo(e);

                e.Graphics.DrawLine(CustomFonts.thinBlack, PrintVariables.LeftMargin, 135, 1106, 135);
                e.Graphics.DrawLine(CustomFonts.thinBlack, PrintVariables.LeftMargin, 165, 1106, 165);
            }
            private static void Print_Halvfabrikat(PrintPageEventArgs e)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Halvfabrikat_Benämning, Halvfabrikat_OrderNr FROM [Order].PreFab WHERE OrderID = @id ORDER BY Halvfabrikat_Benämning DESC";
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    var y = 120;
                    while (reader.Read())
                    {
                        e.Graphics.DrawString($"{reader["Halvfabrikat_Benämning"]} - LotNr:", CustomFonts.A8_BI, CustomFonts.black, 200, y);
                        Print.Text_Operatör(e, $"{reader["Halvfabrikat_OrderNr"]}", 395, y);
                        y += 30;
                    }

                }
            }
            private static void Print_MainInfo(PrintPageEventArgs e)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Weight75D, Weight55D, Date, Name FROM [Order].Compound_Main WHERE OrderID = @id";
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Print.Text_Operatör(e, $"{reader["Weight75D"]}", 540, 120);
                        Print.Text_Operatör(e, $"{reader["Weight55D"]}", 540, 150);

                        e.Graphics.DrawString("DATUM", CustomFonts.A8_BI, CustomFonts.black, 600, 120);
                        Print.Text_Operatör(e, $"{reader["Date"]}", 750, 120);

                        e.Graphics.DrawString("OPERATÖR Sign/Anst.nr", CustomFonts.A8_BI, CustomFonts.black, 600, 150);
                        Print.Text_Operatör(e, $"{reader["Name"]}", 750, 150);

                        e.Graphics.DrawString("Rumstemp. °C", CustomFonts.A8_BI, CustomFonts.black, 950, 120);
                        Print.Text_Operatör(e, Print.utskrift_Korprotokoll["Rum_Temp"], 1040, 120);
                        e.Graphics.DrawString("Rel. fukt. %", CustomFonts.A8_BI, CustomFonts.black, 950, 150);
                        Print.Text_Operatör(e, Print.utskrift_Korprotokoll["Rum_Fukt"], 1040, 150);
                    }

                }
            }

            public static void Print_Samples(PrintPageEventArgs e)
            {
                var font = CustomFonts.A8_B;
                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, 200, 74, 45, "Prov", font);
                Print.Thin_Rectangle(e, 100, 200, 150, 45, "Datum/Tid", font);
                Print.Thin_Rectangle(e, 250, 200, 140, 45);
                e.Graphics.DrawString("Pelletsstorlek", font, CustomFonts.black, 276, 202);
                e.Graphics.DrawString("(längd, tjocklek)", font, CustomFonts.black, 270, 217);
                e.Graphics.DrawString("mm", font, CustomFonts.black, 310, 230);

                Print.Thin_Rectangle(e, 390, 200, 140, 45, "Bulkvikt g/l", font);
                Print.Thin_Rectangle(e, 530, 200, 576, 45, "Kommentarer", font);

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Sample, DateTime, Size, BulkWeight, Comments FROM [Order].Compound WHERE OrderID = @id ORDER BY TempID";
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    var y = 245;
                    while (reader.Read())
                    {
                        Print.Thin_Rectangle(e, PrintVariables.LeftMargin, y, 74, 30, reader["Sample"].ToString(), CustomFonts.operatörFont);
                        Print.Thin_Rectangle(e, 100, y, 150, 30, reader["DateTime"].ToString(), CustomFonts.operatörFont);
                        Print.Thin_Rectangle(e, 250, y, 140, 30, reader["Size"].ToString(), CustomFonts.operatörFont);
                        Print.Thin_Rectangle(e, 390, y, 140, 30, reader["BulkWeight"].ToString(), CustomFonts.operatörFont);
                        Print.Thin_Rectangle(e, 530, y, 576, 30, reader["Comments"].ToString(), CustomFonts.operatörFont);

                        y += 30;
                    }

                }
            }
            public static void Print_Sidfot(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("Limsnummer ankomstkontroll:", CustomFonts.A9, CustomFonts.black, PrintVariables.LeftMargin, 650);
                e.Graphics.DrawString("Godkänd:", CustomFonts.A9_B, CustomFonts.black, PrintVariables.LeftMargin, 690);
                e.Graphics.DrawString("Datum ____________________", CustomFonts.A9, CustomFonts.black, 100, 690);
                e.Graphics.DrawString("Sign./AnstNr. ____________________", CustomFonts.A9, CustomFonts.black, 330, 690);
            }
        }
        public class FrequencyMarking
        {
            public static void Order_Info(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("OrderNr:", CustomFonts.A10_B, CustomFonts.black, PrintVariables.LeftMargin, 100); e.Graphics.DrawLine(CustomFonts.thinBlack, 89, 113, 155, 113); Print.Protocol_InfoText(e, Order.OrderNumber, false, 91, 100, 66, false, false);
                e.Graphics.DrawString("Kund:", CustomFonts.A10_B, CustomFonts.black, 160, 100); e.Graphics.DrawLine(CustomFonts.thinBlack, 205, 113, 745, 113); Print.Protocol_InfoText(e, Print.utskrift_Korprotokoll["Customer"], false, 207, 100, 540, false, false);
                // e.Graphics.DrawString("ID:", Pennor.A10_B, Pennor.black, 750, 100);         e.Graphics.DrawLine(Pennor.thinBlack, 775, 113, 845, 113);  Text_Processkort(e, $"{MeasurePoints.Value(MeasurePoints.TextValue.ID, "NOM")}", 777, 100, 70, false, false);
                // e.Graphics.DrawString("OD:", Pennor.A10_B, Pennor.black, 850 , 100);        e.Graphics.DrawLine(Pennor.thinBlack, 878, 113, 945, 113);  Text_Processkort(e, $"{MeasurePoints.Value(MeasurePoints.TextValue.OD, "NOM")}", 880, 100, 67, false, false);
                // e.Graphics.DrawString("Wall:", Pennor.A10_B, Pennor.black, 950, 100);       e.Graphics.DrawLine(Pennor.thinBlack, 993, 113, 1106, 113); Text_Processkort(e, $"{MeasurePoints.Value(MeasurePoints.TextValue.Wall, "NOM")}", 995, 100, 113, false, false);

            }
            public static void Rubriker(PrintPageEventArgs e)
            {
                var x = 30;
                for (var kolumn = 0; kolumn < 3; kolumn++)
                {
                    e.Graphics.DrawString("Spole\n   nr", CustomFonts.A8_I, CustomFonts.black, x - 1, 130);
                    e.Graphics.DrawString("Material \nBatch.nr", CustomFonts.A8_I, CustomFonts.black, x + 48, 130);
                    e.Graphics.DrawString("Antal\n hål", CustomFonts.A8_I, CustomFonts.black, x + 113, 130);
                    e.Graphics.DrawString("Antal\nmeter", CustomFonts.A8_I, CustomFonts.black, x + 152, 130);
                    e.Graphics.DrawString("Datum - Tid", CustomFonts.A8_I, CustomFonts.black, x + 201, 130);
                    e.Graphics.DrawString("Anst\n  nr", CustomFonts.A8_I, CustomFonts.black, x + 284, 130);
                    e.Graphics.DrawString("Sign", CustomFonts.A8_I, CustomFonts.black, x + 322, 130);
                    x += 359;
                }
            }
            public static void YtterRutor(PrintPageEventArgs e)
            {
                Print.Thick_Rectangle(e, PrintVariables.LeftMargin, 127, 1080, 644);
                var x = 28;
                for (var kolumner = 0; kolumner < 3; kolumner++)
                {
                    Print.Thin_Rectangle(e, x, 129, 358, 640);
                    x += 359;
                }
                e.Graphics.DrawLine(CustomFonts.thinBlack, 28, 156, 1104, 156);
            }
            public static void InreRutor(PrintPageEventArgs e)
            {
                var x = 28;
                var inner_x = 28;
                var y = 157;
                int[] width = { 34, 78, 36, 42, 90, 38, 40 };
                for (var kolumn = 0; kolumn < 3; kolumn++)
                {
                    for (var rad = 0; rad < 34; rad++)
                    {
                        for (var inner_Kolumn = 0; inner_Kolumn < 7; inner_Kolumn++)
                        {
                            Print.Thin_Rectangle(e, inner_x, y, width[inner_Kolumn], 18);
                            inner_x += width[inner_Kolumn];
                        }
                        inner_x = x;
                        y += 18;
                    }
                    e.Graphics.DrawLine(CustomFonts.thinBlack, x + 34, 129, x + 34, 174);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, x + 112, 129, x + 112, 174);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, x + 148, 129, x + 148, 174);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, x + 190, 129, x + 190, 174);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, x + 280, 129, x + 280, 174);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, x + 318, 129, x + 318, 174);
                    x += 359;
                    y = 157;
                }
            }
            public static void Operatör_Text(PrintPageEventArgs e)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                            SELECT 
                                Kasserad, 
                                SpolNr, 
                                Material_Lot, 
                                Antal_hål, 
                                Antal_meter, 
                                Datum_Tid, 
                                Anst_Nr, 
                                Sign 
                            FROM [Order].Läcksökning 
                            WHERE OrderID = @orderid 
                            ORDER BY TempID";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var ctr = 0;
                    var y = 160;
                    var x = 30;
                    int[] inner_x = { 16, 72, 130, 168, 232, 298, 335 };
                    int[] maxWidth = { 34, 78, 36, 42, 90, 38, 40 };
                    while (reader.Read())
                    {
                        for (var i = 1; i < reader.FieldCount; i++)
                        {

                            if (i == 5)
                            {
                                if (DateTime.TryParse(reader[i].ToString(), out var date))
                                    Print.Text_Operatör(e, date.ToString("yyyy-MM-dd HH:mm"), inner_x[i - 1] + x, y, maxWidth[i - 1], true);
                            }
                            else
                                Print.Text_Operatör(e, reader[i].ToString(), inner_x[i - 1] + x, y, maxWidth[i - 1], true);
                        }
                        if (bool.TryParse(reader[0].ToString(), out var is_Skrotad))
                            if (is_Skrotad)
                                e.Graphics.DrawLine(CustomFonts.thickBlack, x, y + 6, x + 350, y + 6);
                        y += 18;
                        ctr++;

                        if (ctr == 34 || ctr == 68)
                        {
                            x += 359;
                            y = 160;
                        }

                    }
                    Stryk_Över_Tomma_Rader(e, ctr);
                }
            }
            public static void Stryk_Över_Tomma_Rader(PrintPageEventArgs e, int rader)
            {
                int x, y;
                if (rader < 34)//Stryk över kolumn 1/2/3
                {
                    x = 32;
                    y = 163 + (rader * 18);
                    e.Graphics.DrawLine(CustomFonts.thickBlack, x, y, x + 350, 765);
                    x += 359;
                    y = 163;
                    e.Graphics.DrawLine(CustomFonts.thickBlack, x, y, x + 350, 765);
                    x += 359;
                    e.Graphics.DrawLine(CustomFonts.thickBlack, x, y, x + 350, 765);

                }
                if (rader > 33 && rader < 68)//stryk över kolumn 2/3
                {
                    x = 391;
                    y = 163 + ((rader - 34) * 18);
                    e.Graphics.DrawLine(CustomFonts.thickBlack, x, y, x + 350, 765);
                    y = 163;
                    x += 359;
                    e.Graphics.DrawLine(CustomFonts.thickBlack, x, y, x + 350, 765);
                }
                if (rader > 67 && rader < 102)//stryk över kolumn 3
                {
                    x = 750;
                    y = 163 + ((rader - 68) * 18);
                    e.Graphics.DrawLine(CustomFonts.thickBlack, x, y, x + 350, 765);
                }
            }
            public static void Sidfot(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("OBS! Endast spolar med hål noteras i blanketten.", CustomFonts.A11_B, CustomFonts.black, 32, 774);
            }
        }
    }
}
