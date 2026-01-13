using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static DigitalProductionProgram.PrintingServices.PrintVariables;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{

    internal class Spolning_PTFE
    {
        public static PrintPreviewDialog Preview_Protocol = new PrintPreviewDialog();
        public static PrintDocument Print = new PrintDocument();
        //private static PrintVariables.TotalPrintOuts totalPrintOuts;
        public static int Start;

        public Spolning_PTFE()
        {
            Print.PrintPage += Protocol_Print_Page;
            Preview_Protocol.Document = Print;

            Print.DefaultPageSettings.Landscape = true;

            Print.DefaultPageSettings.PaperSize = new PaperSize("PaperA4", 826, 1168);
        }



        public static async Task PrintPreview_Order(bool IsPrinting)
        {
            Part.SetPartNrSpecial("Spolning Stripes");
            Print_Protocol.totalPrintOuts = new PrintVariables.TotalPrintOuts
            {
                PagesSpolning = (int)Math.Ceiling((double)Module.TotalStartUps / 24)
            };
            Print_Protocol.SetHeightMeasureInstruments();
            Print_Protocol.totalPrintOuts.PagesExtraMeasureInstruments = 1;

            PrintVariables.CommentIndex = 0;

            Measureprotocol.FirstRowMeasurment = 1;
            Measureprotocol.LastRowMeasurement = Measureprotocol.TotalRowsMeasureprotocolPrintOut;
            ((Form)Preview_Protocol).WindowState = FormWindowState.Maximized;
            ((Form)Measureprotocol.Preview_MeasureProtocol).WindowState = FormWindowState.Maximized;
            ((Form)Measureprotocol.Preview_MeasureProtocol_Landscape).WindowState = FormWindowState.Maximized;

            Print_Protocol.Set_DefaultPaperSize(Print, true);

            PrintVariables.Active_PrintOut = 1;
            // Print Out Protocol
            Start = 0;
            var antal_Utskrifter = Print_Protocol.totalPrintOuts.PagesSpolning;
            for (var i = 1; i < antal_Utskrifter + 1; i++)
            {
                if (IsPrinting)
                    Print.Print();
                else
                    Preview_Protocol.ShowDialog();
                Start += 24;
                if (i < antal_Utskrifter)
                    PrintVariables.Active_PrintOut ++;
            }
            //Skrivet ut Mätdon
            if (Print_Protocol.Height_MeasureInstruments > 0)
               await Print_Protocol.PrintMeasureInstruments(IsPrinting);

            //Printing Measurement Protocol
            await Print_Protocol.PrintMeasureProtocolsAsync(IsPrinting);
           
        }

        private static void Protocol_Print_Page(object sender, PrintPageEventArgs e)
        {
            PrintingServices.Print.utskrift_Korprotokoll = PrintingServices.Print.List_PrintOut_Korprotokoll;

            Print_Protocol.PrintOut.PageHeader(e, "Blankett: Elektronisk Journal för Spolning.", Print_Protocol.totalPrintOuts.TotalPages);
            Print_Protocol.PrintOut.Order_INFO(e);
            PrintOut.Headers(e);
            var y = 195;
            for (var row = 1; row < 25; row++)
            {
                PrintOut.Journal_Values(e, row + Start, y);
               y += PrintOut.RowHeight;
            }

            PrintOut.Extra_Info(e);
            Print_Protocol.PrintOut.PageFooter_Landscape(e);
            PrintingServices.Print.Copy_Landscape(e);
        }



        public class PrintOut
        {
            public const int RowHeight = 20;
            public static int[] width_Pigment
            {
                get
                {
                    if (Templates_Protocol.MainTemplate.ID == 37)
                        return new[] { 32, 37, 32, 58, 48, 28, 33, 58, 48, 35, 45, 58, 37, 32, 40, 36, 34, 36, 38, 36, 90, 36, 36, 112 };
                    return new[] { 32, 37, 32, 70, 58, 48, 28, 33, 58, 48, 35, 45, 58, 37, 32, 40, 36, 34, 36, 38, 36, 90, 36, 36, 50, 112 };
                }
            }
            public static int[] width_NoPigment
            {
                get
                {
                    if (Templates_Protocol.MainTemplate.ID == 37)
                        return new[] { 32, 38, 32, 65, 52, 30, 35, 70, 40, 35, 40, 40, 35, 40, 40, 40, 90, 40, 40, 120 };
                    return new[] { 32, 38, 32, 70, 65, 52, 30, 35, 70, 40, 35, 40, 40, 35, 40, 40, 40, 90, 40, 40, 50, 120 };
                }
            }
            public static void Headers(PrintPageEventArgs e)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT DISTINCT codetext, ColumnIndex
                        FROM Protocol.Template as template
                            JOIN Protocol.Description as descr
                                ON descr.id = template.ProtocolDescriptionID
                        WHERE FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @protocolmaintemplateid)  
                        ORDER BY ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var x = 26;
                var col = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["ColumnIndex"].ToString(), out var ColumnIndex);
                    var codetext = reader["codetext"].ToString();
                    if (Part.IsPartNrSpecial == false)
                    {
                        if (ColumnIndex > 6 && ColumnIndex < 11)
                            continue;
                        PrintingServices.Print.Thin_Rectangle(e, x, 150, width_NoPigment[col], 45);
                        var x_text = x + width_NoPigment[col] / 2;
                        PrintingServices.Print.Print_Rubrik(e, codetext, x_text, 155, width_NoPigment[col],  true);
                        if (col < width_NoPigment.Length - 1)
                            x += width_NoPigment[col];
                        col++;
                    }
                    else
                    {
                        PrintingServices.Print.Thin_Rectangle(e, x, 150, width_Pigment[col], 45);
                        var x_text = x + width_Pigment[col] / 2;
                        PrintingServices.Print.Print_Rubrik(e, codetext, x_text, 155, width_Pigment[col],  true);
                        if (col < width_Pigment.Length - 1)
                            x += width_Pigment[col];
                        col++;
                    }
                }
            }
            public static void Journal_Values(PrintPageEventArgs e, int row, int y)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                               SELECT DISTINCT Value, TextValue, Uppstart, Ugn, ColumnIndex, template.Type, template.Decimals
                                    FROM [Order].Data AS protocol
                                        JOIN Protocol.Template as template
                                            ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                                        JOIN Protocol.Description as descr
                                            ON descr.id = template.ProtocolDescriptionID
                                    WHERE OrderID = @orderid
                                        AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @protocolmaintemplateid)
                                        AND uppstart = @row
                                        ORDER BY uppstart, ColumnIndex";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@row", row);
                var reader = cmd.ExecuteReader();
                var col = 0;
                var x = 26;
                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["ColumnIndex"].ToString(), out var ColumnIndex);
                    var value = string.Empty;

                    switch (type)
                    {
                        case 0:
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1:
                            value = reader["TextValue"].ToString();
                            break;
                        case 2:
                            value = "\u221A";
                            break;
                        case 3:
                            if (DateTime.TryParse(reader["TextValue"].ToString(), out var date) == false)
                                break;
                            if (date.TimeOfDay.TotalSeconds == 0)
                                value = date.ToString("yyyy-MM-dd");
                            else
                                value = date.ToString("yyyy-MM-dd HH:mm");
                            break;
                    }

                    if (Part.IsPartNrSpecial == false)
                    {
                        if (ColumnIndex is > 6 and < 11)
                            continue;
                        try
                        {
                            PrintingServices.Print.Thin_Rectangle(e, x, y, width_NoPigment[col], RowHeight);
                        }
                        catch
                        {
                            if (Person.Role == "SuperAdmin")
                                MessageBox.Show(row.ToString());
                        } 
                            
                        var x_text = x + width_NoPigment[col] / 2;
                        PrintingServices.Print.Text_Operatör(e, value, x_text, y + 4, width_NoPigment[col], true, true);
                        if (col < width_NoPigment.Length - 1)
                            x += width_NoPigment[col];
                        col++;

                    }
                    else
                    {
                        PrintingServices.Print.Thin_Rectangle(e, x, y, width_Pigment[col], RowHeight);
                        var x_text = x + width_Pigment[col] / 2;
                        PrintingServices.Print.Text_Operatör(e, value, x_text, y + 4, width_Pigment[col], true, true);
                        if (col < width_Pigment.Length - 1)
                            x += width_Pigment[col];
                        col++;
                    }
                }
            }
            public static void Extra_Info(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("Bedömning av:", CustomFonts.A10_B, CustomFonts.black, 40, 700);
                e.Graphics.DrawString("a) kvalitet; \u221A = BRA", CustomFonts.A10_B, CustomFonts.black, 57, 720);
                e.Graphics.DrawString("b) fel i slangen; 1 = Sällsynt; 2 = Lite; 3 = Ofta", CustomFonts.A10_B, CustomFonts.black, 57, 740);
            }
        }


    }


}
