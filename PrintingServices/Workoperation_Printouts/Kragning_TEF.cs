using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Kragning_TEF
    {
        public static PrintPreviewDialog Preview_Protocol = new PrintPreviewDialog();
        public static PrintDocument Print_Protocol = new PrintDocument();
        private static PrintVariables.TotalPrintOuts totalPrintOuts;

        public Kragning_TEF()
        {
            ((Form)Preview_Protocol).WindowState = FormWindowState.Maximized;
            Print_Protocol.PrintPage += Processkort_PrintPage;
            Preview_Protocol.Document = Print_Protocol;
        }

        public static void Print_Preview_Order(bool IsPrinting)
        {
            totalPrintOuts = new PrintVariables.TotalPrintOuts
            {
                PagesKragning = 1
            };
            PrintVariables.CommentIndex = 0;
            PrintVariables.Active_PrintOut = 1;
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol, false);
            if (IsPrinting) 
                Print_Protocol.Print();
            else
                Preview_Protocol.ShowDialog();

            if (Manage_PrintOuts.IsOkPrintExtraRaderComments)
                Manage_PrintOuts.Print_ExtraComments.Print();
        }

        private static void Processkort_PrintPage(object sender, PrintPageEventArgs e)
        {
            Print.utskrift_Korprotokoll = Print.List_PrintOut_Korprotokoll;
            Print.utskrift_Processkort = Print.List_PrintOut_Processkort;
            PrintVariables.PageHeight = e.PageBounds.Height;

            PageHeader(e, "Protokoll för Kragning", totalPrintOuts.TotalPages);
            PrintOut.Order_Info(e);
            PrintVariables.Y = 190;
            Print.ProcessCardBasedOn.PrintOut(PrintVariables.LeftMargin, e);

            PrintOut.Processcard(e);
            PrintVariables.Y += 190;
            PrintOut.Korprotokoll(e);
            PrintVariables.Y += 10;
            PrintOut.Processkort_Halvfabrikat(e);
            PrintVariables.Y += 10;
            Comments(PrintVariables.LeftMargin, (int)PrintVariables.PageHeight - 130, Print.utskrift_Korprotokoll["Comments"], e);

            PageFooter(e);
            Print.Copy(e);
        }

        public class PrintOut
        {
            public const int RowHeight = 18;
            public static int[] ColWidth = {  60, 61,  59,  61,  59,  60,  60,  60,  130, 60, 45 };
            public static int[] x_Columns = { 62, 122, 183, 242, 303, 362, 422, 482, 542, 672, 732 };
            public static string? BagNr
            {
                get
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        const string query = @"SELECT TextValue FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 172";

                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        con.Open();
                        var value = cmd.ExecuteScalar();
                        if (value != null)
                            return (string)value;
                    }
                    return null;
                }
            }
            public static string? KragningsDon_Nr
            {
                get
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = @"SELECT textvalue FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 173";

                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        con.Open();
                        var value = cmd.ExecuteScalar();
                        if (value != null)
                            return (string)value;
                    }
                    return null;
                }
            }
            public static void Korprotokoll_Data(PrintPageEventArgs e, int y,  int uppstart)
            {
                for (var col = 0; col < x_Columns.Length; col++)
                    Print.Thin_Rectangle(e, x_Columns[col], y, ColWidth[col], RowHeight);
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                                SELECT DISTINCT Value, TextValue, uppstart, RowIndex, template.decimals, template.Type, template.Decimals
                                    FROM [Order].Data AS protocol
                                        JOIN Protocol.Template as template
                                            ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                                        JOIN Protocol.Description as descr
                                            ON descr.id = template.ProtocolDescriptionID
                                    WHERE OrderID = @orderid
                                        AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid)
                                        AND uppstart = @uppstart
                                    ORDER BY RowIndex";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@uppstart", uppstart);
                    var reader = cmd.ExecuteReader();
                    var IsDiscarded = false;
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
                            case 3:
                                value = reader["TextValue"].ToString();
                                break;
                            case 2:
                                IsDiscarded = true;
                                continue;

                        }
                        Print.Text_Operatör(e, value, x_Columns[row] + ColWidth[row] / 2 + 2, y + 3, ColWidth[row], true, true);
                        if (IsDiscarded)
                            e.Graphics.DrawLine(CustomFonts.thickBlack, 69, y + 9, 761, y + 9);
                    }
                }
            }

            public static void Order_Info(PrintPageEventArgs e)
            {
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin, 101, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 85);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 295, 101, 300, 85);
                e.Graphics.DrawLine(CustomFonts.thinBlack, PrintVariables.LeftMargin, 145, 778, 145);
                e.Graphics.DrawLine(CustomFonts.thinBlack, 387, 145, 387, 184);

                string[] strings = { "Kund", "Produkttyp", "Benämning", "Datum", "Namn", "T.O.nr", "Artikelnr", "Från påse/spole nr" };
                int[] x = { 30, 30, 300, 300, 390, 600, 600, 600 };
                int[] y = { 103, 146, 103, 146, 146, 103, 123, 146 };

                string?[] strings_2 = { Print.utskrift_Korprotokoll["Customer"], Print.utskrift_Korprotokoll["ProdType"], Print.utskrift_Korprotokoll["Description"], Print.utskrift_Korprotokoll["Date_Start"], Print.utskrift_Korprotokoll["Name_Start"], Order.OrderNumber, Order.PartNumber, BagNr };
                int[] x_2 = { 35, 35, 305, 305, 395, 665, 665, 605 };
                int[] y_2 = { 123, 166, 123, 166, 166, 106, 126, 166 };
                int[] maxWidth = { 270, 270, 260, 60, 160, 120, 120, 80 };
                for (var i = 0; i < strings.Length; i++)
                {
                    e.Graphics.DrawString(strings[i], CustomFonts.A9_B, CustomFonts.black, x[i], y[i]);
                    Print.Text_Operatör(e, strings_2[i], x_2[i], y_2[i], maxWidth[i], false, true);
                }
            }
            public static void Processcard(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "MASKINPARAMETRAR vid nystart, skiftbyte eller vid större ändring", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);  //292
                
                e.Graphics.DrawString("OBS! Ange vilket kragningsdon som använts och mät ALLTID upp OD på kragningsdonet.", CustomFonts.A9_B, CustomFonts.black, PrintVariables.LeftMargin, PrintVariables.Y + 28);

              
                e.Graphics.FillRectangle(CustomFonts.empty_Space, 27, PrintVariables.Y + 48, 35, 81);          //Empty_Space
                e.Graphics.FillRectangle(CustomFonts.empty_Space, 303, PrintVariables.Y + 129, 239, 20);
                e.Graphics.FillRectangle(CustomFonts.empty_Space, 303, PrintVariables.Y +169, 239, 20);
                e.Graphics.FillRectangle(CustomFonts.empty_Space, 542, PrintVariables.Y +128, 236, 61);
                
                e.Graphics.FillRectangle(CustomFonts.min_max, 27, PrintVariables.Y +129, 276, 20);
                e.Graphics.FillRectangle(CustomFonts.nom, 27, PrintVariables.Y +149, 515, 20);
                e.Graphics.FillRectangle(CustomFonts.min_max, 27, PrintVariables.Y +169, 276, 20);

                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 303, PrintVariables.Y +129, 475, 60);
               
                string?[] strings = { "MIN", "NOM", "MAX" };
                var y = PrintVariables.Y + 130;
                foreach (var letter in strings)
                {
                    e.Graphics.DrawString(letter, CustomFonts.A8_B, CustomFonts.black, 47 - Print.StringWidth(letter, CustomFonts.A8_B, e.Graphics) / 2, y + 3);
                    y += 20;
                }
                e.Graphics.DrawString("Tryckluft", CustomFonts.A10_B, CustomFonts.black, 92, PrintVariables.Y + 50); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 62, PrintVariables.Y + 48, 120, 20);
                e.Graphics.DrawString("Fasthåll-", CustomFonts.A8_B, CustomFonts.black, 70, PrintVariables.Y + 73); e.Graphics.DrawString("ning", CustomFonts.A8_B, CustomFonts.black, 80, PrintVariables.Y + 88); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 62, PrintVariables.Y + 68, 60, 61);
                e.Graphics.DrawString("Finmat-", CustomFonts.A8_B, CustomFonts.black, 130, PrintVariables.Y + 73); e.Graphics.DrawString("ning", CustomFonts.A8_B, CustomFonts.black, 138, PrintVariables.Y + 88); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 122, PrintVariables.Y + 68, 60, 61);
                e.Graphics.DrawString("MPa", CustomFonts.A8_I, CustomFonts.black, 79, PrintVariables.Y + 116); e.Graphics.DrawString("MPa", CustomFonts.A8_I, CustomFonts.black, 139, PrintVariables.Y + 116);
                e.Graphics.DrawString("Induktion", CustomFonts.A10_B, CustomFonts.black, 210, PrintVariables.Y + 50); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 183, PrintVariables.Y + 48, 119, 20);
                e.Graphics.DrawString("Värme", CustomFonts.A8_B, CustomFonts.black, 195, PrintVariables.Y + 73); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 183, PrintVariables.Y + 68, 59, 61);
                e.Graphics.DrawString("Kylning", CustomFonts.A8_B, CustomFonts.black, 251, PrintVariables.Y + 73); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 242, PrintVariables.Y + 68, 60, 61);
                e.Graphics.DrawString("sec", CustomFonts.A8_I, CustomFonts.black, 200, PrintVariables.Y + 116); e.Graphics.DrawString("sec", CustomFonts.A8_I, CustomFonts.black, 255, PrintVariables.Y + 116);
                e.Graphics.DrawString("Verktyg", CustomFonts.A10_B, CustomFonts.black, 388, PrintVariables.Y + 50); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 303, PrintVariables.Y + 48, 239, 20);
                e.Graphics.DrawString("PTFE, ID", CustomFonts.A8_B, CustomFonts.black, 310, PrintVariables.Y + 73); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 303, PrintVariables.Y + 68, 59, 61);
                e.Graphics.DrawString("PTFE, OD", CustomFonts.A8_B, CustomFonts.black, 367, PrintVariables.Y + 73); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 362, PrintVariables.Y + 68, 60, 61);
                e.Graphics.DrawString("mm", CustomFonts.A8_I, CustomFonts.black, 320, PrintVariables.Y + 116); e.Graphics.DrawString("mm", CustomFonts.A8_I, CustomFonts.black, 386, PrintVariables.Y + 116);
                e.Graphics.DrawString("Kragningsdon", CustomFonts.A8_B, CustomFonts.black, 430, PrintVariables.Y + 73); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 422, PrintVariables.Y + 68, 120, 61);
                e.Graphics.DrawString("NR:", CustomFonts.A8_B, CustomFonts.black, 430, PrintVariables.Y + 88);
                Print.Text_Operatör(e, KragningsDon_Nr, 460, PrintVariables.Y + 88);
                e.Graphics.DrawString("OD (mm)", CustomFonts.A8_B, CustomFonts.black, 455, PrintVariables.Y + 102);
                e.Graphics.DrawString("MIN", CustomFonts.A8_I, CustomFonts.black, 440, PrintVariables.Y + 116); e.Graphics.DrawString("MAX", CustomFonts.A8_I, CustomFonts.black, 500, PrintVariables.Y + 116);
                //e.Graphics.DrawLine(CustomFonts.thinBlack, 482, 405, 482, PrintVariables.Y + 129);
                e.Graphics.DrawString("Datum - Tid", CustomFonts.A10_B, CustomFonts.black, 559, PrintVariables.Y + 108); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 543, PrintVariables.Y + 48, 130, 81);
                e.Graphics.DrawString("Anst.Nr", CustomFonts.A10_B, CustomFonts.black, 676, PrintVariables.Y + 108); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 673, PrintVariables.Y + 48, 60, 81);
                e.Graphics.DrawString("Sign", CustomFonts.A10_B, CustomFonts.black, 737, PrintVariables.Y + 108); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 733, PrintVariables.Y + 48, 45, 81);
                
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 27, PrintVariables.Y + 129, 35, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 27, PrintVariables.Y + 149, 35, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 27, PrintVariables.Y + 169, 35, 20);  //MIN/NOM/MAX
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 62, PrintVariables.Y + 129, 60, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 62, PrintVariables.Y + 149, 60, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 62, PrintVariables.Y + 169, 60, 20);  //MIN/NOM/MAX_Tryck_Fasthållning
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 122, PrintVariables.Y + 129, 60, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 122, PrintVariables.Y + 149, 60, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 122, PrintVariables.Y + 169, 60, 20);  //MIN/NOM/MAX_Tryck_Finmatning
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 183, PrintVariables.Y + 129, 59, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 183, PrintVariables.Y + 149, 59, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 183, PrintVariables.Y + 169, 59, 20);  //MIN/NOM/MAX_Ind_Värme
                
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 242, PrintVariables.Y + 129, 60, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 242, PrintVariables.Y + 149, 60, 20); e.Graphics.DrawRectangle(CustomFonts.thinBlack, 242, PrintVariables.Y + 169, 60, 20);  //MIN/NOM/MAX_Ind_Kylning

                
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 303, PrintVariables.Y + 149, 59, 20);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 362, PrintVariables.Y + 149, 60, 20);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 422, PrintVariables.Y + 149, 60, 20); 
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 482, PrintVariables.Y + 149, 60, 20);  //NOM_Verktyg

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    const string query = @"
                            SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                            FROM Protocol.Template AS template
	                            JOIN Processcard.Data AS pc_values
		                            ON pc_values.TemplateID = template.Id
	                            JOIN Protocol.Description AS descr
		                            ON descr.Id = template.ProtocolDescriptionID
                            WHERE pc_values.PartID = @partID
                            ORDER BY ColumnIndex, RowIndex";
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                    var reader = cmd.ExecuteReader();
                    //int ctr = 0;
                    while (reader.Read())
                    {
                        int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                        int.TryParse(reader["RowIndex"].ToString(), out var row);
                        int.TryParse(reader["type"].ToString(), out var type);
                        string? value = null;
                        switch (type)
                        {
                            case 0:
                                value = reader["value"].ToString();
                                break;
                            case 1:
                                value = reader["textvalue"].ToString();
                                break;
                        }
                        switch (col)
                        {
                            case 0:
                                y = PrintVariables.Y + 133;
                                break;
                            case 1:
                                y = PrintVariables.Y + 153;
                                break;
                            case 2:
                                y = PrintVariables.Y + 173;
                                break;
                        }
                        Print.Protocol_InfoText(e, value, false,x_Columns[row] + ColWidth[row] / 2, y, 50, true, false);
                    }
                }
            }
            public static void Korprotokoll(PrintPageEventArgs e)
            {
                for (var uppstart = 1; uppstart < Module.TotalStartUps + 1; uppstart++)
                {
                    Korprotokoll_Data(e, PrintVariables.Y,  uppstart);
                    PrintVariables.Y += RowHeight;
                }
            }
            public static void Processkort_Halvfabrikat(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Halvfabrikat:", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
                Print.Thin_Rectangle(e, 24, PrintVariables.Y + 25, 123,20, "Typ", CustomFonts.A9_BI, false);
                Print.Thin_Rectangle(e, 147, PrintVariables.Y + 25, 120, 20, "ArtikelNr", CustomFonts.A9_BI, false);
                Print.Thin_Rectangle(e, 267, PrintVariables.Y + 25, 100, 20, "LotNr", CustomFonts.A9_BI, false);
                Print.Thin_Rectangle(e, 367, PrintVariables.Y + 25, 50, 20, "ID", CustomFonts.A9_BI, false);
                Print.Thin_Rectangle(e, 417, PrintVariables.Y + 25, 50, 20, "OD", CustomFonts.A9_BI, false);
                Print.Thin_Rectangle(e, 467, PrintVariables.Y + 25, 50, 20, "W", CustomFonts.A9_BI, false);
                Print.Thin_Rectangle(e, 517, PrintVariables.Y + 25, 262, 20, "Längd", CustomFonts.A9_BI, false);

                PrintVariables.Y += 45;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                        SELECT 
                            Typ, 24, 123,
                            Halvfabrikat_ArtikelNr, 147, 120,
                            Halvfabrikat_OrderNr, 267, 100,
                            Halvfabrikat_ID, 367, 50,
                            Halvfabrikat_OD, 417, 50,
                            Halvfabrikat_W, 467, 50,
                            Length, 517, 262,
                            NULL
                        FROM [Order].PreFab WHERE OrderID = @orderid ORDER BY TempID";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount - 1; i+= 3)
                        {
                            int.TryParse(reader[i + 1].ToString(), out var x);
                            int.TryParse(reader[i + 2].ToString(), out var width);
                            Print.Thin_Rectangle(e, x, PrintVariables.Y, width, 20, reader[i].ToString(), CustomFonts.operatörFont, false);
                        }
                            
                        PrintVariables.Y += 20;
                    }
                }
            }
        }
    }
}
