using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;
using DigitalProductionProgram.Protocols.Skärmning_TEF;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Skärmning
    {
        public static PrintPreviewDialog Preview_MainProtocol = new PrintPreviewDialog();
        public static PrintDocument Print_MainProtocol = new PrintDocument();
        public static PrintPreviewDialog Preview_Protocol = new PrintPreviewDialog();
        public static PrintDocument Print_Protocol = new PrintDocument();

        private static DataTable DataTable_WorkCard_Skärmning
        {
            get
            {
                var dt = new DataTable();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query =
                    $"SELECT TextValue AS Machine, MachineIndex FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 349 GROUP BY TextValue, MachineIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                dt.Load(cmd.ExecuteReader());

                return dt;
            }
        }
        private static int TotalWorkCards
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT MAX (MachineIndex) FROM [Order].Data WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var value = cmd.ExecuteScalar();
                var totalCards = 0;
                if (value != null)
                    int.TryParse(value.ToString(), out totalCards);
                return totalCards;
            }
        }

        private static PrintVariables.TotalPrintOuts totalPrintOuts;

        public Skärmning()
        {
            ((Form)Preview_Protocol).WindowState = FormWindowState.Maximized;
            Print_Protocol.PrintPage += Protocol_PrintPage;
            Preview_Protocol.Document = Print_Protocol;
            Print_MainProtocol.PrintPage += MainProtocol_MainPage;
            Preview_MainProtocol.Document = Print_MainProtocol;
        }
        public static void Print_Preview_Order(bool IsPrinting)
        {
            PrintVariables.Active_PrintOut = 1;
            PrintVariables.CommentIndex = 0;
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol, false);
            totalPrintOuts = new PrintVariables.TotalPrintOuts
            {
                PagesSkärmning = TotalWorkCards + 1 // +1 för huvudprotokollet
            };
            
            if (IsPrinting)
                Print_MainProtocol.Print();
            else
                Preview_MainProtocol.ShowDialog();

            PrintVariables.Active_PrintOut++;
            for (var i = 0; i < TotalWorkCards; i++)
            {
                PrintOut.MachineName = DataTable_WorkCard_Skärmning.Rows[i]["Machine"].ToString();
                int.TryParse(DataTable_WorkCard_Skärmning.Rows[i]["MachineIndex"].ToString(), out PrintOut.MachineIndex);
                if (IsPrinting)
                    Print_Protocol.Print();
                else
                    Preview_Protocol.ShowDialog();
                PrintVariables.Active_PrintOut += 1;
            }
        }
        private static void MainProtocol_MainPage(object sender, PrintPageEventArgs e)
        {
            Print.utskrift_Korprotokoll = Print.List_PrintOut_Korprotokoll;
            Print.utskrift_Processkort = Print.List_PrintOut_Processkort;
            PageHeader(e, "Protokoll för Skärmning", totalPrintOuts.TotalPages);
            Print.ProductInformation(e);
            PrintVariables.Y = 170;
            PreFab(e);
            PageFooter(e);
            Print.Copy(e);
        }

        private static void Protocol_PrintPage(object sender, PrintPageEventArgs e)
        {
            PageHeader(e, "Maskinparametrar", totalPrintOuts.TotalPages);
           
            PrintOut.Print_Maskinparametrar_Rutor_Rubriker(e);
            PrintOut.Print_Maskinparametrar_Processkort(e);
            PrintOut.Print_Maskinparametrar_Körprotokoll(e);
            PrintOut.Print_Produktion_Rubriker_Rutor(e);
            PrintOut.Print_Produktion_Processdata(e);
            PrintOut.Print_Produktion_OperatörsData_Text(e);

            PageFooter(e);
            Print.Copy(e);

        }
        


        public class PrintOut
        {
           




            public static string MachineName;
            public static int MachineIndex;

            public static void Print_Processkort_Halvfabrikat(PrintPageEventArgs e)
            {
                if (string.IsNullOrEmpty(Order.OrderNumber))    //Om användare skriver ut ett tomt processkort behöver Ordernr ändras här
                {
                    Order.OrderNumber = "Q12345";
                    Order.Operation = "10";
                    MachineName = string.Empty;
                    MachineIndex = 0;
                }
                e.Graphics.DrawString("Tråd Benämning", CustomFonts.A8_B, CustomFonts.black, 30, 160);
                e.Graphics.DrawString("Lot nr.", CustomFonts.A9_B, CustomFonts.black, 435, 160);
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query =
                        $"SELECT Halvfabrikat_Benämning, Halvfabrikat_OrderNr FROM [Order].PreFab {Queries.WHERE_OrderID}";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        e.Graphics.DrawString(reader[0].ToString(), CustomFonts.operatörFont,
                            CustomFonts.parametrar_clr, 125, 160);
                        e.Graphics.DrawString(reader[1].ToString(), CustomFonts.operatörFont,
                            CustomFonts.parametrar_clr, 485, 160);
                    }
                }
            }
            public static void Print_Maskinparametrar_Rutor_Rubriker(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Maskinparametrar:", PrintVariables.LeftMargin, 100, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, 100, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 138);


                int[] width = { 48, 40, 48, 62, 62, 50, 45, 65 };
                var x = 62;
                for (var i = 0; i < 8; i++)
                {
                    Print.Thin_Rectangle(e, x, 123, width[i], 42);
                    Print.Thin_Rectangle(e, x, 220, width[i], 18);
                    x += width[i];
                }
                object[,] text = { { "Maskin",      71,  136  },
                                                  { "Sida",        120, 136  },
                                                  { "Antal",       159, 129  },
                                                  { "Trådar",      156, 143  },
                                                  { "Pot.",        218, 122  },
                                                  { "Maskin",      210, 136  },
                                                  { "Hastighet",   203, 150  },
                                                  { "Pot.",        280, 122  },
                                                  { "Travers",     268, 136  },
                                                  { "Hastighet",   264, 150  },
                                                  { "Carrier",     328, 129  },
                                                  { "fjäder",      331, 143  },
                                                  { "PPI",         383, 136  },

                                                  { "ODs",         435, 122  },
                                                  { "oinsmält",    426, 136  } };
                for (var i = 0; i < text.Length / 3; i++)
                    e.Graphics.DrawString((string)text[i, 0], CustomFonts.A8, CustomFonts.black, (int)text[i, 1], (int)text[i, 2]);

                e.Graphics.DrawString("mm", CustomFonts.A8_I, CustomFonts.black, 438, 150);

                Print.Filled_Rectangle(e, CustomFonts.min_max, PrintVariables.LeftMargin, 165, 36, 18); e.Graphics.DrawString("MIN", CustomFonts.A8_B, CustomFonts.black, 32, 167);
                Print.Filled_Rectangle(e, CustomFonts.nom, PrintVariables.LeftMargin, 183, 36, 18); e.Graphics.DrawString("NOM", CustomFonts.A8_B, CustomFonts.black, 30, 185);
                Print.Filled_Rectangle(e, CustomFonts.min_max, PrintVariables.LeftMargin, 201, 36, 18); e.Graphics.DrawString("MAX", CustomFonts.A8_B, CustomFonts.black, 30, 203);

                Print.Filled_Rectangle(e, CustomFonts.nom, 150, 183, 48, 18);
                Print.Filled_Rectangle(e, CustomFonts.nom, 198, 183, 62, 18);
                Print.Filled_Rectangle(e, CustomFonts.nom, 322, 183, 50, 18);
                Print.Filled_Rectangle(e, CustomFonts.nom, 372, 183, 45, 18);
            }
            public static void Print_Maskinparametrar_Processkort(PrintPageEventArgs e)
            {
                int[] x = { 176, 229, 347, 395};
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                             SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                            FROM Protocol.Template AS template
	                            JOIN Processcard.Data AS pc_data
		                            ON pc_data.TemplateID = template.Id
	                            JOIN Protocol.Description AS descr
		                            ON descr.Id = template.ProtocolDescriptionID
                            WHERE pc_data.PartID = @partID
                            AND template.FormTemplateID = @formtemplateid
                            ORDER BY ColumnIndex";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", 11);
                var reader = cmd.ExecuteReader();
                var col = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    var value = string.Empty;

                    switch (type)
                    {
                        case 0://NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }

                    Print.Text_Operatör(e, value, x[col], 185, 60, true, true);
                    col++;
                }
            }
            public static void Print_Maskinparametrar_Körprotokoll(PrintPageEventArgs e)
            {
                int[] x = { 176, 229, 291, 347, 395, 452 };
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                                SELECT DISTINCT Value, TextValue, ColumnIndex, template.decimals, template.Type, template.Decimals
                                    FROM [Order].Data AS protocol
                                        JOIN Protocol.Template as template
                                            ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                                        JOIN Protocol.Description as descr
                                            ON descr.id = template.ProtocolDescriptionID
                                    WHERE OrderID = @orderid
                                        AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid AND ModuleName = 'MASKINPARAMETRAR')
                                        AND template.revision = (SELECT ProtocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid)
                                        ORDER BY ColumnIndex";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);   //formtemplid = 11
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int.TryParse(reader["Type"].ToString(), out var type);
                        int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                        var value = string.Empty;

                        switch (type)
                        {
                            case 0://NumberValue
                                int.TryParse(reader["Decimals"].ToString(), out var decimals);
                                if (double.TryParse(reader["value"].ToString(), out var NumberValue) == false)
                                    value = string.Empty;
                                else
                                    value = Processcard.Format_Value(NumberValue, decimals);
                                break;
                            case 1://TextValue
                                value = reader["textvalue"].ToString();
                                break;
                        }

                        Print.Text_Operatör(e, value, x[col], 222, 60, true, true);
                    }
                }
                string?[] MachineName = MainProtocol_Skärmning_TEF.MachineName(MachineIndex).Split('_');
                Print.Text_Operatör(e, MachineName[0], 88, 222, 50, true);
                Print.Text_Operatör(e, MachineName[1], 132, 222, 50, true);

            }
            public static void Print_Produktion_Rubriker_Rutor(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Produktion / Skärmning", PrintVariables.LeftMargin, 240, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, 262, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 721);

                object[,] text =  { { "Mätare",      57,  265  },
                                    { "Temp °C",     95, 265  },
                                    { "L1",          96, 285  },
                                    { "L2",          127, 285  },
                                    { "ID",          163, 265  },
                                    { "L1",          147, 285  },
                                    { "L2",          181, 285  },
                                    { "OD1",         215, 265  },
                                    { "L1",          202, 285  },
                                    { "L2",          237, 285  },
                                    { "ODs",         272, 265  },
                                    { "L1",          259, 285  },
                                    { "L2",          292, 285  },
                                    { " Verk-\ntyg ID", 313,268 },
                                    { "Kommentarer", 506, 273  },
                                    { "Datum-Tid",   630, 273  },
                                   
                                    { "Anst \n  Nr", 708, 268  },
                                    { "Sign",        744, 273  } };

                for (var i = 0; i < text.Length / 3; i++)
                    e.Graphics.DrawString((string)text[i, 0], CustomFonts.A8, CustomFonts.black, (int)text[i, 1], (int)text[i, 2]);
                var drawFormat = new StringFormat
                {
                    FormatFlags = StringFormatFlags.DirectionVertical,
                };
                e.Graphics.DrawString("Tråd", CustomFonts.A7, CustomFonts.black, 353, 270, drawFormat); e.Graphics.DrawString("slut", CustomFonts.A7, CustomFonts.black, 345, 272, drawFormat);
                e.Graphics.DrawString("Tråd", CustomFonts.A7, CustomFonts.black, 371, 270, drawFormat); e.Graphics.DrawString("av", CustomFonts.A7, CustomFonts.black, 363, 275, drawFormat);
                e.Graphics.DrawString("Trasig", CustomFonts.A7, CustomFonts.black, 390, 265, drawFormat); e.Graphics.DrawString("carrier", CustomFonts.A7, CustomFonts.black, 382, 264, drawFormat);
                e.Graphics.DrawString("Skarv", CustomFonts.A7, CustomFonts.black, 404, 267, drawFormat);
                e.Graphics.DrawString("Spole", CustomFonts.A7, CustomFonts.black, 426, 266, drawFormat); e.Graphics.DrawString("slut", CustomFonts.A7, CustomFonts.black, 418, 271, drawFormat);
                e.Graphics.DrawString("Avslut", CustomFonts.A7, CustomFonts.black, 444, 266, drawFormat); e.Graphics.DrawString("linje", CustomFonts.A7, CustomFonts.black, 436, 272, drawFormat);
                e.Graphics.DrawString("Avrapp-", CustomFonts.A7, CustomFonts.black, 462, 263, drawFormat); e.Graphics.DrawString("orterat", CustomFonts.A7, CustomFonts.black, 454, 264, drawFormat);

                int[] w_Rubriker_Rutor = { 38, 50, 56, 56, 56, 35, 18, 18, 18, 18, 18, 18, 18, 132, 100, 35, 39 };
                var x = 56;
                foreach (var width in w_Rubriker_Rutor)
                {
                    Print.Thin_Rectangle(e, x, 262, width, 37);
                    x += width;
                }

                object[,] dim = { { CustomFonts.min_max, PrintVariables.LeftMargin,  299, 30 },
                                                      { CustomFonts.min_max, 94,  299, 50 },
                                                      { CustomFonts.min_max, 144, 299, 56 },
                                                      { CustomFonts.min_max, 200, 299, 56 },
                                                      { CustomFonts.min_max, 256, 299, 56 },
                                                      { CustomFonts.min_max, 312, 299, 35 },
                                                      { CustomFonts.nom,     PrintVariables.LeftMargin,  317, 30 },
                                                      { CustomFonts.nom,     94,  317, 50 },
                                                      { CustomFonts.nom,     144, 317, 56 },
                                                      { CustomFonts.nom,     200, 317, 56 },
                                                      { CustomFonts.nom,     256, 317, 56 },
                                                      { CustomFonts.nom,     312, 317, 35 },
                                                      { CustomFonts.min_max, PrintVariables.LeftMargin,  335, 30 },
                                                      { CustomFonts.min_max, 94,  335, 50 },
                                                      { CustomFonts.min_max, 144, 335, 56 },
                                                      { CustomFonts.min_max, 200, 335, 56 },
                                                      { CustomFonts.min_max, 256, 335, 56 },
                                                      { CustomFonts.min_max, 312, 335, 35} };

                for (var i = 0; i < dim.Length / 4; i++)
                    Print.Filled_Rectangle(e, (Brush)dim[i, 0], (int)dim[i, 1], (int)dim[i, 2], (int)dim[i, 3], 18);

                e.Graphics.DrawString("MIN", CustomFonts.A8_B, CustomFonts.black, 28, 301);
                e.Graphics.DrawString("NOM", CustomFonts.A8_B, CustomFonts.black, 26, 319);
                e.Graphics.DrawString("MAX", CustomFonts.A8_B, CustomFonts.black, 26, 337);

                e.Graphics.DrawLine(CustomFonts.thinBlack, 119, 282, 119, 299);
                e.Graphics.DrawLine(CustomFonts.thinBlack, 172, 282, 172, 299);
                e.Graphics.DrawLine(CustomFonts.thinBlack, 228, 282, 228, 299);
                e.Graphics.DrawLine(CustomFonts.thinBlack, 284, 282, 284, 299);
            }
            public static void Print_Produktion_Processdata(PrintPageEventArgs e)
            {
                int[] x = { 120,120,120, 175,175,175, 230,230,230, 285,285,285, 330,330,330 };
                int[] y = { 300, 319, 338 };
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                            SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                            FROM Protocol.Template AS template
	                        JOIN Processcard.Data AS pc_data
		                        ON pc_data.TemplateID = template.Id
	                        JOIN Protocol.Description AS descr
		                        ON descr.Id = template.ProtocolDescriptionID
                            WHERE pc_data.PartID = @partID
                                AND template.FormTemplateID = @formtemplateid
                                AND ColumnIndex != 4
								AND ColumnIndex != 6
								AND ColumnIndex != 8
								AND ColumnIndex != 10
                            ORDER BY ColumnIndex";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", 12);
                var reader = cmd.ExecuteReader();
                int col = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    var value = string.Empty;

                    switch (type)
                    {
                        case 0://NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }
                    Print.Text_Operatör(e, value, x[col], y[row], 40, true);
                    col++;
                }
            }
            public static void Print_Produktion_OperatörsData_Text(PrintPageEventArgs e)
            {
                int[,] x_w = { 
                    { 56, 38  }, 
                    { 94, 25 }, 
                    { 119, 25 },
                    { 144, 28 }, 
                    { 172, 28 },
                    { 200, 28 }, 
                    { 228, 28 }, 
                    { 256, 28 }, 
                    { 284, 28 }, 
                    { 312, 35 },
                    { 347, 18 },
                    { 365, 18 },
                    { 383, 18 },
                    { 401, 18 }, 
                    { 419, 18 },
                    { 437, 18 }, 
                    { 455, 18 },
                    { 473, 132 },
                    { 605, 100 }, 
                    { 705, 35 }, 
                    { 740, 39 } };
                var y = 356;

                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT DISTINCT CodeText, Value, TextValue, DateValue, BoolValue, MachineIndex, Uppstart, ColumnIndex, template.Decimals, template.Type
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
                            AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid AND ModuleName = 'PRODUKTION')
							AND MachineIndex = @machine
							AND ColumnIndex > 1
                       ORDER BY Uppstart, ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@machine", MachineIndex);
                var reader = cmd.ExecuteReader();
                var col = 0;
                var lastRow = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["Uppstart"].ToString(), out var row);
                    if (lastRow != row)
                    {
                        y += 18;
                        lastRow = row;
                        col = 0;
                    }
                            
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0:
                            value = reader["Value"].ToString();
                            break;
                        case 1: 
                            value = reader["TextValue"].ToString(); 
                            break;
                        case 2:
                            value = " ";//Vill inte ha N/A i checkboxarna så därav ett whitespace
                            if (bool.TryParse(reader["BoolValue"].ToString(), out var IsFlag))
                                if (IsFlag)
                                    value = "\u2713";
                            break;
                        case 3:
                            DateTime.TryParse(reader["DateValue"].ToString(), out var date);
                            value = date.ToString("yyyy-MM-dd HH:mm");
                            break;
                    }
                    Print.Thin_Rectangle(e, x_w[col, 0], y, x_w[col, 1], 18, value, CustomFonts.operatörFont_small);
                    col++;
                }
            }
        }
    }
}
