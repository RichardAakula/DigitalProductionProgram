using System;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Blandning_PTFE;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Blandning_PTFE
    {
        public static PrintPreviewDialog Preview_Protocol = new PrintPreviewDialog();
        public static PrintDocument Print_Protocol = new PrintDocument();
        private static PrintVariables.TotalPrintOuts totalPrintOuts;
        public static int Start_Row;
        public static int End_Row;



        public Blandning_PTFE()
        {
            ((Form)Preview_Protocol).WindowState = FormWindowState.Maximized;
            Print_Protocol.PrintPage += Protocol_Print_Page;
            Preview_Protocol.Document = Print_Protocol;

        }

        public static void Print_Preview_Order(bool IsPrinting)
        {
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol, true);
            PrintVariables.CommentIndex = 0;
            Measureprotocol.FirstRowMeasurment = 0;
            Measureprotocol.LastRowMeasurement = 25;
            PrintVariables.Active_PrintOut = 1;
            totalPrintOuts = new PrintVariables.TotalPrintOuts
            {
                PagesBlandning = (int)Math.Ceiling((double)Journal_Blandning_PTFE.TotalRows / 25)
            };


            for (var i = 1; i < totalPrintOuts.PagesBlandning + 1; i++)
            {

                if (IsPrinting)
                    Print_Protocol.Print();
                else
                    Preview_Protocol.ShowDialog();
                PrintVariables.Active_PrintOut += 1;
                Measureprotocol.FirstRowMeasurment = Measureprotocol.LastRowMeasurement +1;
                Measureprotocol.LastRowMeasurement += 25;
            }
        }
       
        private static void Protocol_Print_Page(object sender, PrintPageEventArgs e)
        {
            Print.utskrift_Korprotokoll = Print.List_PrintOut_Korprotokoll;
            PageHeader(e, "Journal för Blandning PTFE.", totalPrintOuts.TotalPages);
            Order_INFO(e);

            PrintOut.Headers(e);
            var y = 156;
            PrintOut.Journal_Values(e, y);

            PrintOut.Extra_Info(e);
            PageFooter_Landscape(e);
            Print.Copy_Landscape(e);
        }



        public class PrintOut
        {
            public const int RowHeight = 20;

            public static int[] width_Pigment = { 44, 71, 59, 65, 80, 78, 85, 30, 70, 80, 110, 50, 50, 80, 40, 50 };
            public static int[] x_Pigment = { 26, 70, 141, 200, 265, 345, 423, 508, 538, 608, 688, 798, 848, 898, 978, 1018 };

            public static int[] width_NoPigment = { 46, 76, 74, 70, 78, 30, 70, 110, 50, 50, 90, 50, 50 };
            public static int[] x_NoPigment = { 26, 72, 148, 222, 292, 370, 400, 470, 580, 630, 680, 770, 820 };

            public static void Headers(PrintPageEventArgs e)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT DISTINCT CodeText, ColumnIndex
                        FROM Protocol.Template as template
                            JOIN Protocol.Description as descr
                                ON descr.id = template.ProtocolDescriptionID
                        WHERE FormTemplateID = @formtemplateid
                        ORDER BY ColumnIndex";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@formtemplateid", 16);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var reader = cmd.ExecuteReader();
                    //int x = 26;
                    var col = 0;
                    while (reader.Read())
                    {
                        int.TryParse(reader["ColumnIndex"].ToString(), out var ColumnIndex);
                        var codetext = reader["CodeText"].ToString();
                        if (Part.IsPartNrSpecial("Blandning Pigment") == false)
                        {
                            if (ColumnIndex == 4 || ColumnIndex == 6 || ColumnIndex == 9) 
                                continue;
                            Print.Thin_Rectangle(e, x_NoPigment[col], 150, width_NoPigment[col], 26);
                            var x = x_NoPigment[col] + width_NoPigment[col] / 2;
                            Print.Print_Rubrik(e, codetext, x, 155, width_NoPigment[col],  true);
                            col++;
                            
                        }
                        else
                        {
                            Print.Thin_Rectangle(e, x_Pigment[col], 150, width_Pigment[col], 26);
                            var x = x_Pigment[col] + width_Pigment[col] / 2;
                            Print.Print_Rubrik(e, codetext, x, 155, width_Pigment[col],  true);
                            col++;
                            
                        }
                    }
                }
            }
            public static void Journal_Values(PrintPageEventArgs e, int y)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                               SELECT DISTINCT Value, TextValue, Uppstart, Ugn, ColumnIndex, template.Type, template.Decimals
                                    FROM [Order].Data AS protocol
                                        JOIN Protocol.Template as template
                                            ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                                        JOIN Protocol.Description as descr
                                            ON descr.id = template.ProtocolDescriptionID
                                    WHERE OrderID = @orderid
                                        AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid)
                                        AND Uppstart BETWEEN @start AND @end
                                        ORDER BY uppstart, ColumnIndex";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@start", Measureprotocol.FirstRowMeasurment);
                    cmd.Parameters.AddWithValue("@end", Measureprotocol.LastRowMeasurement);
                    var reader = cmd.ExecuteReader();
                    var col = 0;
                    while (reader.Read())
                    {
                        int.TryParse(reader["Type"].ToString(), out var type);
                        int.TryParse(reader["ColumnIndex"].ToString(), out var ColumnIndex);
                        if (ColumnIndex == 0)
                        {
                            col = 0;
                            y += RowHeight;
                        }
                            
                        var value = string.Empty;


                        switch (type)
                        {
                            case 0:
                                int.TryParse(reader["Decimals"].ToString(), out var decimals);
                                if (double.TryParse(reader["value"].ToString(), out var NumberValue) == false)
                                    value = string.Empty;
                                else
                                    value = Processcard.Format_Value(NumberValue, decimals);
                                break;
                            case 1:
                                value = reader["textvalue"].ToString();
                                break;
                        }

                        if (Part.IsPartNrSpecial("Blandning Pigment") == false)
                        {
                            if (ColumnIndex == 4 || ColumnIndex == 6 || ColumnIndex == 9)
                                continue;
                            var x = x_NoPigment[col] + width_NoPigment[col] / 2;
                            Print.Thin_Rectangle(e, x_NoPigment[col], y, width_NoPigment[col], RowHeight);
                            Print.Text_Operatör(e, value, x, y+4, width_Pigment[col], true, true);
                            col++;

                        }
                        else
                        {
                            var x = x_Pigment[col] + width_Pigment[col] / 2;
                            Print.Thin_Rectangle(e, x_Pigment[col], y, width_Pigment[col], RowHeight);
                            Print.Text_Operatör(e, value, x, y+4, width_Pigment[col], true, true);
                            col++;
                        }

                       
                    }
                }
            }
            public static void Extra_Info(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("A) 1 = Bra", CustomFonts.A10_B, CustomFonts.black, 40, 700);
                e.Graphics.DrawString("2 = Kornigt, lite klumpar, rent", CustomFonts.A10_B, CustomFonts.black, 57, 720);
                e.Graphics.DrawString("3 = Förorenat, sammanpressat", CustomFonts.A10_B, CustomFonts.black, 57, 740);
            }
        }
    }
}
