using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Measureprotocol
    {
        public static PrintPreviewDialog Preview_MeasureProtocol = new PrintPreviewDialog();
        public static PrintPreviewDialog Preview_MeasureProtocol_Landscape = new PrintPreviewDialog();

        public static PrintDocument Print_MeasureProtocol = new PrintDocument();
        public static PrintDocument Print_MeasureProtocol_Landscape = new PrintDocument();

        public Measureprotocol()
        {
            Print_MeasureProtocol.PrintPage += MeasureProtocol_PrintPage;
            Print_MeasureProtocol_Landscape.PrintPage += MeasureProtocol_Landscape_PrintPage;
            Print_MeasureProtocol_Landscape.DefaultPageSettings.Landscape = true;

            Preview_MeasureProtocol.Document = Print_MeasureProtocol;
            Preview_MeasureProtocol_Landscape.Document = Print_MeasureProtocol_Landscape;

        }


        public static int FirstRowMeasurment { get; set; }
        public static int LastRowMeasurement { get; set; }
        public static int RowHeight = 18;
        private const int width_Date = 122;
        private const int width_ErrorCode = 45;
        private const int width_EmplNr = 50;
        private const int width_Sign = 47;
        private static int totalPrintedRows;
        private static int RowIndex { get; set; }

        public static int X_DateValue
        {
            get
            {
                if (Templates_MeasureProtocol.MainTemplate.ID == null || Templates_MeasureProtocol.MainTemplate.ID == 0)
                    return 0;

                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                                SELECT SUM(ColumnWidth), COUNT(*)
                                FROM MeasureProtocol.Template
                                WHERE MeasureProtocolMainTemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[0].ToString(), out var x);
                    int.TryParse(reader[1].ToString(), out var ctr);
                    return x - ctr * 4 + 26;
                }

                return 0;
            }
        }
        public static bool IsLandscape => X_DateValue > 520;
        private static List<int> List_Width;
        public static int TotalRowsMeasureprotocolPrintOut
        {
            get
            {
                switch (Order.WorkOperation)
                {
                    //case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    //    return IsLandscape ? 20 : 34;

                    case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                        return 8;
                    default:
                        return IsLandscape ? 22 : 36;
                }
            }
        }
        public static int TotalMeasureProtocols => MeasureInformation.TotalMeasurmentsByOperators / TotalRowsMeasureprotocolPrintOut + (MeasureInformation.TotalMeasurmentsByOperators % TotalRowsMeasureprotocolPrintOut > 0 ? 1 : 0);

        private static void MeasureProtocol_PrintPage(object sender, PrintPageEventArgs e)
        {
            Print_MeasureProtocol_Landscape.DefaultPageSettings.Landscape = false;
            PrintVariables.Active_PrintOut++;
            Print_Protocol.PrintOut.PageHeader(e, Sidhuvud_Header, Print_Protocol.totalPrintOuts.TotalPages);
            Order_Info(e);
            Headers_And_Squares(e, TotalRowsMeasureprotocolPrintOut);
            MeasurePoints(e, TotalRowsMeasureprotocolPrintOut);
            Measureprotocol_MainData(e);
            Print_MeasureInstruments(e);
            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Extrudering_FEP)
                Hack_Upptagare_FEP(e);

            Print.Copy(e);
        }
        private static void MeasureProtocol_Landscape_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintVariables.Active_PrintOut++;

            Print_Protocol.PrintOut.PageHeader(e, Sidhuvud_Header, Print_Protocol.totalPrintOuts.TotalPages);
            Order_Info(e);


            Headers_And_Squares(e, TotalRowsMeasureprotocolPrintOut);
            MeasurePoints(e, TotalRowsMeasureprotocolPrintOut);
            Measureprotocol_MainData(e);

            Print_MeasureInstruments_Landscape(e);

            Print.Copy_Landscape(e);
        }



        public static void Order_Info(PrintPageEventArgs e)
        {
            var pt1 = new Point(PrintVariables.LeftMargin, 118);
            var pt2 = new Point(PrintVariables.MaxPaperWidth, 118);
            var pt3 = new Point(PrintVariables.LeftMargin, 148);
            var pt4 = new Point(PrintVariables.MaxPaperWidth, 148);

            Print.Static_InfoText(e, LanguageManager.GetString("label_Customer"), 30, 100);
            Print.Protocol_InfoText(e, Print.utskrift_Korprotokoll["Customer"], false, 100, 100, 500, false, false);

            Print.Static_InfoText(e, LanguageManager.GetString("label_Description"), 30, 130);
            Print.Protocol_InfoText(e, Print.utskrift_Korprotokoll["Description"], false, 100, 130, 500, false, false);

            Print.Static_InfoText(e, "OrderNr - Operation:", PrintVariables.MaxPaperWidth - 70, 100, true);
            Print.Protocol_InfoText(e,$"{Order.OrderNumber}-{Order.Operation}", false, PrintVariables.MaxPaperWidth - 70, 100, 100, false, false);

            Print.Static_InfoText(e, LanguageManager.GetString("label_PartNumber"), PrintVariables.MaxPaperWidth - 70, 130, true);
            Print.Protocol_InfoText(e, Print.utskrift_Korprotokoll["PartNr"], false, PrintVariables.MaxPaperWidth - 70, 130, 100, false, false);

            e.Graphics.DrawLine(CustomFonts.thinBlack, pt1, pt2);
            e.Graphics.DrawLine(CustomFonts.thinBlack, pt3, pt4);
        }
       
        

        public static void Print_MeasureInstruments(PrintPageEventArgs e)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT * FROM MeasureInstruments.Mätdon WHERE OrderID = @id ORDER BY Row";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var y = PrintVariables.MaxPaperHeight - 190;
                while (reader.Read())
                {
                    e.Graphics.DrawString($"{reader["Mätdon"]}:", CustomFonts.A11, CustomFonts.black, 37, y);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, new Point(200, y + 15), new Point(360, y + 15));
                    Print.Text_Operatör(e, reader["Nr"].ToString(), 205, y, 180);

                    y += 22;
                }
            }
            e.Graphics.DrawString(LanguageManager.GetString("startDate"), CustomFonts.A11, CustomFonts.black, 585 - Print.StringWidth(LanguageManager.GetString("startDate"), CustomFonts.A11, e.Graphics), PrintVariables.MaxPaperHeight - 40);
            DateTime.TryParse(Print.utskrift_Korprotokoll["Date_Start"], out var date);
            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
            Print.Text_Operatör(e, formattedDate, 585, PrintVariables.MaxPaperHeight - 39, 160);
            e.Graphics.DrawLine(CustomFonts.thinBlack, new Point(580, PrintVariables.MaxPaperHeight - 25), new Point(740, PrintVariables.MaxPaperHeight - 25));
            
            e.Graphics.DrawString(LanguageManager.GetString("endDate"), CustomFonts.A11, CustomFonts.black, 585 - Print.StringWidth(LanguageManager.GetString("endDate"), CustomFonts.A11, e.Graphics), PrintVariables.MaxPaperHeight - 20);
            DateTime.TryParse(Print.utskrift_Korprotokoll["Date_Stop"], out date);
            dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
            Print.Text_Operatör(e, formattedDate, 585, PrintVariables.MaxPaperHeight - 19, 160);
            e.Graphics.DrawLine(CustomFonts.thinBlack, new Point(580, PrintVariables.MaxPaperHeight - 5), new Point(740, PrintVariables.MaxPaperHeight - 5));
        }
        public static void Print_MeasureInstruments_Landscape(PrintPageEventArgs e)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT * FROM MeasureInstruments.Mätdon WHERE OrderID = @id ORDER BY Row";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var y = 680;
                var x1 = 37;
                var x2 = 200;
                while (reader.Read())
                {
                    e.Graphics.DrawString($"{reader["Mätdon"]}:", CustomFonts.A11, CustomFonts.black, x1, y);
                    e.Graphics.DrawLine(CustomFonts.thinBlack, new Point(x2, y + 15), new Point(x2+140, y + 15));
                    Print.Text_Operatör(e, reader["Nr"].ToString(), x2+5, y, 180);

                    y += 25;
                    if (y > 800)
                    {
                        x1 += 350;
                        x2 += 350;
                        y = 680;
                    }
                }
            }

            e.Graphics?.DrawString(LanguageManager.GetString("startDate"), CustomFonts.A11, CustomFonts.black, PrintVariables.MaxPaperWidth - 256, PrintVariables.MaxPaperHeight - 50);
            e.Graphics?.DrawLine(CustomFonts.thinBlack, new Point(PrintVariables.MaxPaperWidth - 160, PrintVariables.MaxPaperHeight - 30), new Point(PrintVariables.MaxPaperWidth, PrintVariables.MaxPaperHeight - 30));

            e.Graphics?.DrawString(LanguageManager.GetString("endDate"), CustomFonts.A11, CustomFonts.black, PrintVariables.MaxPaperWidth - 251, PrintVariables.MaxPaperHeight - 30);
            e.Graphics?.DrawLine(CustomFonts.thinBlack, new Point(PrintVariables.MaxPaperWidth - 160, PrintVariables.MaxPaperHeight - 10), new Point(PrintVariables.MaxPaperWidth, PrintVariables.MaxPaperHeight - 10));

            if (Print.utskrift_Korprotokoll != null)
            {
                Print.Text_Operatör(e, Print.utskrift_Korprotokoll["Date_Start"], PrintVariables.MaxPaperWidth - 164, PrintVariables.MaxPaperHeight - 47, 160);
                Print.Text_Operatör(e, Print.utskrift_Korprotokoll["Date_Stop"], PrintVariables.MaxPaperWidth - 164, PrintVariables.MaxPaperHeight - 27, 160);
            }
                

            
        }
       
        public static void Hack_Upptagare_FEP(PrintPageEventArgs e)
        {
            e.Graphics?.DrawString("Hack/Uppdatagare nr:", CustomFonts.A11, CustomFonts.black, PrintVariables.MaxPaperWidth + PrintVariables.LeftMargin - 280, PrintVariables.MaxPaperHeight - 190);
            Print.Text_Operatör(e, Korprotokoll.Load_Data(Order.OrderID, 19, 246), PrintVariables.MaxPaperWidth + PrintVariables.LeftMargin - 100, PrintVariables.MaxPaperHeight - 189, 100,false, true); //Hack
        }

        public static void Headers_And_Squares(PrintPageEventArgs e, int TotalRows)
        {
            var x = 26;
            var y = 158;
            const int height = 40;
            List_Width = new List<int>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT 
                    Parameter_UserText, 
                    ColumnWidth 
                FROM MeasureProtocol.Template 
                WHERE MeasureProtocolMainTemplateID = @maintemplateid                   
                ORDER BY ColumnIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var width = int.Parse(reader["ColumnWidth"].ToString()) - 4;
                    var text = reader["Parameter_UserText"].ToString();
                    Print.Header_Measureprotocol(e, x, y, width, height, text);
                    List_Width.Add(width);
                    x += width;
                }
            }

            Print.Header_Measureprotocol(e, x, y, width_Date, height, "Date-Time");
            x += 122;
            List_Width.Add(122);
            Print.Header_Measureprotocol(e, x, y, width_ErrorCode, height, "Error Code");
            x += 45;
            List_Width.Add(45);
            Print.Header_Measureprotocol(e, x, y, width_EmplNr, height, LanguageManager.GetString("label_EmpNr"));
            x += 50;
            List_Width.Add(50);
            Print.Header_Measureprotocol(e, x, y, width_Sign, height, "Sign.");
            List_Width.Add(47);

            //Skriver ut rutor för operatörens mätningar
            x = 26;
            foreach (var col in List_Width)
            {
                y = 198;
                for (var row = 0; row < TotalRows; row++)
                {
                    Print.Thin_Rectangle(e, x, y, col, RowHeight);
                    y += RowHeight;
                }

                x += col;
            }

        }
        public static void MeasurePoints(PrintPageEventArgs e, int TotalRows)
        {
            totalPrintedRows = 0;
            var tempRowindex = -1;
            if (!string.IsNullOrEmpty(Order.OrderNumber))
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT 
                        Parameter_UserText, 
                        DataType, 
                        Value, 
                        TextValue, 
                        BoolValue, 
                        ColumnIndex, 
                        ColumnWidth, 
                        Decimals, 
                        data.RowIndex
                    FROM MeasureProtocol.Data as data
                        JOIN MeasureProtocol.Template as template
                            ON data.DescriptionId = template.DescriptionID
                    WHERE data.OrderID = @orderid 
                        AND MeasureProtocolMainTemplateID = @maintemplateid
                        AND RowIndex BETWEEN @start AND @end
                    ORDER BY RowIndex, ColumnIndex";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@start", FirstRowMeasurment);
                    cmd.Parameters.AddWithValue("@end", LastRowMeasurement);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var x = 26;
                    while (reader.Read())
                    {
                        var col = int.Parse(reader["ColumnIndex"].ToString());
                        var width = int.Parse(reader["ColumnWidth"].ToString()) - 4;
                        RowIndex = int.Parse(reader["RowIndex"].ToString()) - FirstRowMeasurment;
                        if (RowIndex != tempRowindex)
                            totalPrintedRows++;
                        tempRowindex = RowIndex;
                        var type = int.Parse(reader["DataType"].ToString());
                       
                        var value = string.Empty;
                        var y = 196 + RowIndex * RowHeight;

                        if (col == 0)
                            x = 26;

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
                            case 2:
                                bool.TryParse(reader["BoolValue"].ToString(), out var flag);
                                if (flag)
                                    value = "✓";
                                break;
                        }

                        Print.Text_Operatör(e, value, x + width / 2, y + 5, width, true);

                        x += width;
                    }
                }

                //Drar ett streck över oanvända rader
                if (totalPrintedRows >= TotalRows)
                    return;
                var x2 = X_DateValue + width_Date + width_EmplNr + width_ErrorCode + width_Sign;
                var pt1 = new Point(32, 199 + (totalPrintedRows) * RowHeight);
                var pt2 = new Point(x2, TotalRows * RowHeight + 193);
                e.Graphics.DrawLine(CustomFonts.thickBlack, pt1, pt2);
            }
        }
        public static void Measureprotocol_MainData(PrintPageEventArgs e)
        {
            var start_x = X_DateValue;
            if (!string.IsNullOrEmpty(Order.OrderNumber))
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                                SELECT Discarded, Date, ErrorCode, AnstNr, Sign, RowIndex
                                FROM MeasureProtocol.MainData
                                WHERE OrderID = @orderid 
                                AND RowIndex BETWEEN @start AND @end
                                ORDER BY RowIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@start", FirstRowMeasurment);
                cmd.Parameters.AddWithValue("@end", LastRowMeasurement);
                con.Open();
                var reader = cmd.ExecuteReader();
                var x = start_x;
                while (reader.Read())
                {
                    RowIndex = int.Parse(reader["RowIndex"].ToString()) - FirstRowMeasurment;
                    var y = 196 + RowIndex * RowHeight;

                    DateTime.TryParse(reader["Date"].ToString(), out var date);
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    Print.Text_Operatör(e, formattedDate, x + width_Date / 2, y + 4, width_Date, true, true);
                    x += width_Date;
                    Print.Text_Operatör(e, reader["ErrorCode"].ToString(), x + width_ErrorCode / 2, y + 4, width_ErrorCode, true, true);
                    x += width_ErrorCode;
                    Print.Text_Operatör(e, reader["AnstNr"].ToString(), x + width_EmplNr / 2, y + 4, width_EmplNr, true, true);
                    x += width_EmplNr;
                    Print.Text_Operatör(e, reader["Sign"].ToString(), x + width_Sign / 2, y + 4, width_Sign, true, true);

                    bool.TryParse(reader["Discarded"].ToString(), out var IsDiscarded);
                    if(IsDiscarded)
                    {
                        var x2 = X_DateValue + width_Date + width_EmplNr + width_ErrorCode + width_Sign;
                        var pt1 = new Point(28, y + 11);
                        var pt2 = new Point(x2, y + 11);
                        e.Graphics.DrawLine(CustomFonts.thinBlack, pt1, pt2);
                    }

                    x = start_x;
                }
            }
        }

        private static string? Sidhuvud_Header
        {
            get
            {
                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                        return $"Digitalt Mätprotokoll {Order.NumberOfLayers}-Lager: spole/hackning";
                    case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                        return "Digital Measurement Protocol for Extrusion HS";
                    case Manage_WorkOperation.WorkOperations.Hackning_PTFE:
                        return "Digitalt Mätprotokoll för Hackning";
                    case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
                        return "Digitalt Mätprotokoll för Kragning";
                    case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
                        return "Digitalt Mätprotokoll för Kragning K22";
                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        return "Digitalt Mätprotokoll för Krympslang";
                    case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                        return "Digitalt Mätprotokoll för Spolning";
                    case Manage_WorkOperation.WorkOperations.Synergy_PTFE:
                        return "Digitalt Mätprotokoll för Synergy";
                    case Manage_WorkOperation.WorkOperations.HeatShrink:
                        return "Digital Measurement Protocol for HeatShrink";
                    default:
                        return "Digitalt Mätprotokoll spole/hackning";
                     
                }
            }
        }
        
    }
}
