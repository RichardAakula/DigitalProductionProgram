using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.Slipning_TEF;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;


namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Slipning_TEF
    {
        private static Dictionary<string, string?>? List_PrintOut_Slipning_Protocol
        {
            get
            {
                var is_Empty = false;
                var list = new Dictionary<string, string>();
                if (string.IsNullOrEmpty(Order.OrderNumber)) //Om inget ordernummer finns fylls Listan upp med tomma värden
                {
                    Order.PartNumber = "1234567";
                    Order.OrderNumber = "Q12345";
                    Order.Operation = "10";
                    Order.RevNr = string.Empty;
                    is_Empty = true;
                }
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"SELECT TOP(1) *
                            FROM [Order].MainData
                            {Queries.WHERE_OrderID}";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            if (is_Empty)
                            {
                                if (!list.ContainsKey(reader.GetName(i)))
                                    list.Add(reader.GetName(i), string.Empty);
                            }
                            if (!list.ContainsKey(reader.GetName(i)))
                                list.Add(reader.GetName(i), reader[i].ToString());
                        }
                    }
                }
                if (!list.ContainsKey("N/A"))
                    list.Add("N/A", "N/A");
                if (is_Empty)
                {
                    Order.PartNumber = null;
                    Order.OrderNumber = null;
                    Order.Operation = null;
                }
                return list;
            }
        }
        private static Dictionary<string, string?> List_PrintOut_Slipning_ProcessCard
        {
            get
            {
                var is_Empty = false;
                var list = new Dictionary<string, string?>();
                if (string.IsNullOrEmpty(Order.OrderNumber)) //Om inget ordernummer finns fylls Listan upp med tomma värden
                {
                    Order.PartNumber = "1234567";
                    Order.OrderNumber = "Q12345";
                    Order.Operation = "10";
                    Order.RevNr = string.Empty;
                    is_Empty = true;
                }
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT 
                        Matarhjul_Hastighet_nom, 
                        Matarhjul_Vinkel_min, 
                        Matarhjul_Vinkel_nom, 
                        Matarhjul_Vinkel_max, 
                        Helix_Vinkel_nom, 
                        Bladhöjd_min, 
                        Bladhöjd_nom, 
                        Bladhöjd_max, 
                        Arbetsblad_min, 
                        Arbetsblad_nom,  
                        Arbetsblad_max, 
                        Chimshöjd_nom, 
                        Dragprov_enhet, 
                        Historiska_Data, 
                        Validerat, 
                        Framtagning_Processfönster,
                        UpprättatAv_Sign_AnstNr,
                        QA_sign,
                        Validerade_Loter,
                        GodkäntDatum,
                        RevInfo
                    FROM Processkort_Slipning as slipning
                    JOIN Processcard.MainData as maindata
                        ON slipning.PartID = maindata.PartID
                    WHERE maindata.PartID = @partid";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            if (is_Empty)
                            {
                                if (!list.ContainsKey(reader.GetName(i)))
                                    list.Add(reader.GetName(i), string.Empty);
                            }
                            if (!list.ContainsKey(reader.GetName(i)))
                                list.Add(reader.GetName(i), reader[i].ToString());
                        }
                    }
                }
                if (!list.ContainsKey("N/A"))
                    list.Add("N/A", "N/A");
                if (is_Empty)
                {
                    Order.PartNumber = null;
                    Order.OrderNumber = null;
                    Order.Operation = null;
                }
                return list;
            }
        }

        public static PrintPreviewDialog Preview_Protocol = new PrintPreviewDialog();
        public static PrintPreviewDialog Preview_Protocol_Extra = new PrintPreviewDialog();
        public static PrintDocument Print_Protocol = new PrintDocument();
        public static PrintDocument Print_Protocol_Extra = new PrintDocument();
        private static PrintVariables.TotalPrintOuts totalPrintOuts;

        private static int RowMultiplier => Part.IsPartNrSpecial ? 17 : 14;

        public Slipning_TEF()
        {
            ((Form)Preview_Protocol_Extra).WindowState = FormWindowState.Maximized;
            ((Form)Preview_Protocol).WindowState = FormWindowState.Maximized;

            Print_Protocol.PrintPage += Protocol_PrintPage;
            Print_Protocol_Extra.PrintPage += Protocol_Print_ExtraPages;

            Preview_Protocol.Document = Print_Protocol;
            Preview_Protocol_Extra.Document = Print_Protocol_Extra;

        }

        public static void Print_PreviewOrder(bool IsPrinting)
        {
            Part.SetPartNrSpecial("Extra Parametrar Slipning_TEF");

            Measureprotocol.FirstRowMeasurment = 0;
            Measureprotocol.LastRowMeasurement = 25 * RowMultiplier;
            PrintVariables.Active_PrintOut = 1;
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol, false);
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol_Extra, false);
            PrintVariables.CommentIndex = 0;

            var antal_rader_Produktion = Korprotokoll.TotalProductionRows("Korprotokoll_Slipning_Produktion") / RowMultiplier;
            var TotalMainPages = (int)Math.Ceiling(((double)antal_rader_Produktion - 25) / 50);
            totalPrintOuts = new PrintVariables.TotalPrintOuts
            {
                PagesSlipning = 1
            };
            totalPrintOuts.PagesSlipning += TotalMainPages;
            if (Manage_PrintOuts.IsOkPrintExtraRaderComments)
                totalPrintOuts.PagesSlipning += 1;
            if (IsPrinting)
                Print_Protocol.Print();
            else
                Preview_Protocol.ShowDialog();

            for (var i = 0; i < TotalMainPages; i++)
            {
                PrintVariables.Active_PrintOut++;
                Measureprotocol.FirstRowMeasurment = Measureprotocol.LastRowMeasurement + 1;
                Measureprotocol.LastRowMeasurement = Measureprotocol.FirstRowMeasurment + 49 * RowMultiplier;
                if (IsPrinting)
                    Print_Protocol_Extra.Print();
                else
                    Preview_Protocol_Extra.ShowDialog();
            }

            PrintVariables.Y += 220;
            if (Manage_PrintOuts.IsOkPrintExtraRaderComments)
            {
                if (IsPrinting)
                    Manage_PrintOuts.Print_ExtraComments.Print();
                else
                    Manage_PrintOuts.Preview_ExtraComments.ShowDialog();
            }
        }

        private static void Protocol_PrintPage(object sender, PrintPageEventArgs e)
        {
            Print.utskrift_Korprotokoll = List_PrintOut_Slipning_Protocol;
            Print.utskrift_Processkort = List_PrintOut_Slipning_ProcessCard;
            PrintVariables.PageHeight = e.PageBounds.Height;

            PageHeader(e, "Protokoll för sammanfogning av slang, Slipning", totalPrintOuts.TotalPages);
            Order_INFO(e);
            PrintVariables.Y = 135;
            Print.ProcessCardBasedOn.PrintOut(PrintVariables.LeftMargin, e);
            PrintOut.Print_Maskinparametrar_Rutor(e);
           
            PrintOut.Print_Maskinparametrar_Processcard(e);
            PrintVariables.Y += 126;
            PrintOut.Print_Maskinparametrar_Protocol(e);
            PrintVariables.Y += 2;
            Part.SetPartNrSpecial("Extra Parametrar Slipning_TEF");
            if (Part.IsPartNrSpecial)  
            {
                PrintOut.ExtraParametrar_Print_Produktion_Rubriker_Rutor(e);
                PrintOut.ExtraParametrar_Print_Produktion_Parametrar(e);
            }
            else
            {
                PrintOut.Print_Produktion_Rubriker_Rutor(e); 
                PrintOut.Print_Produktion_Parametrar(e); 
            }

            //PrintVariables.Y += 110;
            Comments(PrintVariables.LeftMargin, (int)PrintVariables.PageHeight - 10, Print.utskrift_Korprotokoll["Comments"], e);
            PageFooter(e);
            Print.Copy(e);
        }
        private static void Protocol_Print_ExtraPages(object sender, PrintPageEventArgs e)
        {
            PageHeader(e, "Protokoll för sammanfogning av slang, Slipning", totalPrintOuts.TotalPages);
            Order_INFO(e);
            PrintVariables.Y = 135;
            Part.SetPartNrSpecial("Extra Parametrar Slipning_TEF");
            if (Part.IsPartNrSpecial)
            {
                PrintOut.ExtraParametrar_Print_Produktion_Rubriker_Rutor(e);
                PrintOut.ExtraParametrar_Print_Produktion_Parametrar(e);
            }
            else
            {
                PrintOut.Print_Produktion_Rubriker_Rutor(e);
                PrintOut.Print_Produktion_Parametrar(e);
            }
        }

        public class PrintOut
        {
            public static void Print_Maskinparametrar_Rutor(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Maskinparametrar", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
               
                //Ritar rutor runt rubrikerna för MaskinParmetrar
                int[] x = {     68, 138, 203, 263, 318, 377, 442, 472, 522, 572, 652, 697 };
                int[] width = { 70, 65,  60,  55,  59,  65,  30,  50,  50,  80,  45,  46 };
                for (var i = 0; i < x.Length; i++)
                    Print.Thin_Rectangle(e, x[i], PrintVariables.Y+22, width[i], 50);
                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y+22, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, 50);
                var y = PrintVariables.Y + 74;
              
                string?[] strings = { "MIN", "NOM", "MAX" };
                for (var i = 0; i < strings.Length; i++)
                {
                    var pen = i == 1 ? CustomFonts.nom : CustomFonts.min_max;

                    Print.Filled_Rectangle(e, pen, PrintVariables.LeftMargin, y - 2, 44, 18);
                    e.Graphics.DrawString(strings[i], CustomFonts.A8_B, CustomFonts.black, 45 - Print.StringWidth(strings[i], CustomFonts.A8_B, e.Graphics) / 2, y + 3);
                    y += 18;
                }

                
                Print.Filled_Rectangle(e, CustomFonts.empty_Space, 68, PrintVariables.Y + 72, 711, 54);//229

                Print.Filled_Rectangle(e, CustomFonts.nom, 138, PrintVariables.Y + 90, 304, 18); Print.Filled_Rectangle(e, CustomFonts.nom, 203, PrintVariables.Y + 90, 60, 18); Print.Filled_Rectangle(e, CustomFonts.nom, 318, PrintVariables.Y + 90, 59, 18);
                
                Print.Filled_Rectangle(e, CustomFonts.nom, 472, PrintVariables.Y + 90, 100, 18);
                Print.Filled_Rectangle(e, CustomFonts.nom, 522, PrintVariables.Y + 90, 50, 18);

                Print.Filled_Rectangle(e, CustomFonts.min_max, 203, PrintVariables.Y + 72, 60, 18); Print.Filled_Rectangle(e, CustomFonts.min_max, 203, PrintVariables.Y + 108, 60, 18);  //Matarhjul Vinkel MIN - MAX
                Print.Filled_Rectangle(e, CustomFonts.min_max, 318, PrintVariables.Y + 72, 59, 18); Print.Filled_Rectangle(e, CustomFonts.min_max, 318, PrintVariables.Y + 108, 59, 18);  //Bladhöjd MIN - MAX
                Print.Filled_Rectangle(e, CustomFonts.min_max, 377, PrintVariables.Y + 72, 65, 18); Print.Filled_Rectangle(e, CustomFonts.min_max, 377, PrintVariables.Y + 108, 65, 18);   //Arbetsblad MIN
            }

            public static void Print_HeadersMultipleLines(PrintPageEventArgs e, string?[] strings, string? unit, int x, int y)
            {
                var unit_Y = y + 36;
                foreach (var text in strings)
                {
                    e.Graphics.DrawString(text, CustomFonts.A8_B, CustomFonts.black, x - Print.StringWidth(text, CustomFonts.A8_B, e.Graphics) / 2, y);
                    y += 12;
                }

                if (!string.IsNullOrEmpty(unit))
                    e.Graphics.DrawString(unit, CustomFonts.A8_I, CustomFonts.black, x - Print.StringWidth(unit, CustomFonts.A8_I, e.Graphics) / 2, unit_Y);
            }
            public static void Print_Maskinparametrar_Processcard(PrintPageEventArgs e)
            {
                var data = new Dictionary<string?[], (string unit, int x)>
                {
                    { new[] {"Slipmaskin", "RMG"}, ("rpm", 103)},
                    { new []{"Matarhjul", "Hastighet"}, ("rpm",172) },
                    { new []{"Matar", "hjul", "vinkel"}, ("º", 234) },
                    { new []{ "Helix", "vinkel"}, ("º", 291) },
                    { new []{ "Bladhöjd",}, ("mm", 349) },
                    { new []{ "Arbetsblad", }, (null, 412) },
                    { new []{ "Nr"}, (null, 456) },
                    { new []{ "Chims", "höjd"}, ("mm", 494) },
                    { new []{ "Center", "höjd"}, ("mm", 548) },
                    { new []{ "Datum"}, (null, 614) },
                    { new []{ "Tid"}, (null, 676) },
                    { new []{ "Anst", "Nr" }, (null, 723) },
                    { new []{ "Sign"}, (null, 762) }
                };

                foreach (var entry in data)
                {
                    var texts = entry.Key;
                    var unit = entry.Value.unit;
                    var x = entry.Value.x;
                    Print_HeadersMultipleLines(e, texts, unit, x, PrintVariables.Y + 22);
                }
               
                e.Graphics.DrawString("63,7", CustomFonts.parametrarFont, CustomFonts.parametrar_clr, 532, PrintVariables.Y+92);

                
                //Hämtar Maskinparametrar från Processkortet
                int[] x_arr = { 233, 351, 408, 172, 233, 290, 352, 408, 500, 233, 352, 408 };
                int[] yy = { 
                    PrintVariables.Y + 73, PrintVariables.Y + 73, PrintVariables.Y + 73, 
                    PrintVariables.Y + 92, PrintVariables.Y + 92, PrintVariables.Y + 92, PrintVariables.Y + 92, PrintVariables.Y + 92, PrintVariables.Y + 92, 
                    PrintVariables.Y + 110, PrintVariables.Y + 110, PrintVariables.Y + 110 };
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                    SELECT 
                        Matarhjul_Vinkel_min, 
                        Bladhöjd_min, 
                        Arbetsblad_min, 
                        Matarhjul_Hastighet_nom,                         
                        Matarhjul_Vinkel_nom, 
                        Helix_Vinkel_nom, 
                        Bladhöjd_nom, 
		                Arbetsblad_nom, 
                        Chimshöjd_nom, 
                        Matarhjul_Vinkel_max,
                        Bladhöjd_max, 
                        Arbetsblad_max
                    
                    FROM Processkort_Slipning as slipning
	                    JOIN Processcard.MainData as main
		                    ON slipning.PartID = main.PartID
                    WHERE slipning.PartID = @partID";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < 12; i++)
                    {
                        var value = reader[i].ToString();
                        e.Graphics.DrawString(value, CustomFonts.parametrarFont, CustomFonts.parametrar_clr, x_arr[i] - Print.StringWidth(value, CustomFonts.parametrarFont, e.Graphics) / 2, yy[i]);
                    }
                        
                }
            }
            public static void Print_Maskinparametrar_Protocol(PrintPageEventArgs e)
            {
                if (!string.IsNullOrEmpty(Order.OrderNumber))
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query = $@"
                                    SELECT 
                                        Slipmaskin,             68,  70,
                                        Matarhjul_Hastighet,    138, 65,
                                        Matarhjul_Vinkel,       203, 60,
                                        Helix_Vinkel,           263, 55,
                                        Bladhöjd,               318, 59,
                                        Arbetsblad,             377, 65,
                                        Nr,                     442, 30,
                                        Chimshöjd,              472, 50,
                                        Datum,                  572, 80,
                                        Tid,                    652, 45,
                                        AnstNr,                 697, 45,
                                        Sign,                   742, 37,
                                        Kasserad
                                    FROM Korprotokoll_Slipning_Maskinparametrar WHERE OrderID = @orderid";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount - 1; i+= 3)
                        {
                            var x = int.Parse(reader[i + 1].ToString());
                            var width = int.Parse(reader[i + 2].ToString());
                            Print.Thin_Rectangle(e, x, PrintVariables.Y, width, 18);
                            Print.Text_Operatör(e, reader[i].ToString(), x + width / 2 + 2, PrintVariables.Y + 3, width, true);//+130
                        }
                        Print.Filled_Rectangle(e, CustomFonts.empty_Space,522, PrintVariables.Y, 50, 18);//+127
                        if ((bool)reader["Kasserad"])
                            e.Graphics.DrawLine(CustomFonts.thickBlack, 30, PrintVariables.Y + 6, 755, PrintVariables.Y + 133);//+133
                        PrintVariables.Y += 18;
                    }
                }
            }

            public static void Print_Produktion_Rubriker_Rutor(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Produktion / Slipning:", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
                e.Graphics.DrawString("Inledande", CustomFonts.A10_B, CustomFonts.black, 28, PrintVariables.Y + 26); 
                e.Graphics.DrawString("Mjukslang", CustomFonts.A10_B, CustomFonts.black, 130, PrintVariables.Y + 26); 
                e.Graphics.DrawString("Skärmad slang", CustomFonts.A10_B, CustomFonts.black, 210, PrintVariables.Y + 26); 
                e.Graphics.DrawString("Godkänd, färdig produkt", CustomFonts.A10_B, CustomFonts.black, 330, PrintVariables.Y + 26);

                var text = "Skärmat";
                Part.SetPartNrSpecial("Svetsning TEF Stumning");
                if (Part.IsPartNrSpecial)
                    text = "Mjukspets";
                e.Graphics.DrawString(text, CustomFonts.A8, CustomFonts.black, 50, PrintVariables.Y + 49); 
                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y + 47, 104, 25);
                e.Graphics.DrawString("LotNr", CustomFonts.A8, CustomFonts.black, 42, PrintVariables.Y + 73); 
                Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y + 72, 104, 25); 
                e.Graphics.DrawString("Påse \n  Nr", CustomFonts.A8, CustomFonts.black, 94, PrintVariables.Y + 73); Print.Thin_Rectangle(e, 91, PrintVariables.Y + 72, 37, 25);
                e.Graphics.DrawString("Uppmätt", CustomFonts.A8, CustomFonts.black, 143, PrintVariables.Y + 49); Print.Thin_Rectangle(e, 128, PrintVariables.Y + 47, 80, 50); 
                e.Graphics.DrawString("ID\nmm", CustomFonts.A8, CustomFonts.black, 142, PrintVariables.Y + 71); e.Graphics.DrawString("OD\nmm", CustomFonts.A8, CustomFonts.black, 178, PrintVariables.Y + 71); 
                e.Graphics.DrawLine(CustomFonts.thinBlack, 168, PrintVariables.Y + 72, 168, PrintVariables.Y + 97);
                e.Graphics.DrawString("Uppmätt", CustomFonts.A8, CustomFonts.black, 238, PrintVariables.Y + 49); Print.Thin_Rectangle(e, 208, PrintVariables.Y + 22, 120, 25); 
                e.Graphics.DrawString("ID\nmm", CustomFonts.A8, CustomFonts.black, 218, PrintVariables.Y + 71); e.Graphics.DrawString("OD\nmm", CustomFonts.A8, CustomFonts.black, 258, PrintVariables.Y + 71); 
                e.Graphics.DrawString("Total\nlängd", CustomFonts.A8, CustomFonts.black, 292, PrintVariables.Y + 49); e.Graphics.DrawString("mm", CustomFonts.A8, CustomFonts.black, 295, PrintVariables.Y + 83); e.Graphics.DrawLine(CustomFonts.thinBlack, 248, PrintVariables.Y + 72, 248, PrintVariables.Y + 97); e.Graphics.DrawLine(CustomFonts.thinBlack, 288, PrintVariables.Y + 72, 288, PrintVariables.Y + 97);
                e.Graphics.DrawLine(CustomFonts.thinBlack, PrintVariables.LeftMargin, PrintVariables.Y + 97, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, PrintVariables.Y + 97);

                e.Graphics.DrawString("Antal\ngod-\nkända", CustomFonts.A8, CustomFonts.black, 346, PrintVariables.Y + 56); Print.Thin_Rectangle(e, 328, PrintVariables.Y + 47, 65, 50);
                e.Graphics.DrawString(" Lev.\npåse\n  nr", CustomFonts.A8, CustomFonts.black, 398, PrintVariables.Y + 56); Print.Thin_Rectangle(e, 393, PrintVariables.Y + 47, 40, 50);
                e.Graphics.DrawString("Drag\nprov\nantal", CustomFonts.A8, CustomFonts.black, 436, PrintVariables.Y + 56); Print.Thin_Rectangle(e, 433, PrintVariables.Y + 47, 35, 50);
                e.Graphics.DrawString("Hållfast-\n   het", CustomFonts.A8, CustomFonts.black, 479, PrintVariables.Y + 48); Print.Thin_Rectangle(e, 468, PrintVariables.Y + 47, 60, 50);

                e.Graphics.DrawString(Print.utskrift_Processkort["Dragprov_enhet"], CustomFonts.A8, CustomFonts.black, 478, PrintVariables.Y + 78); e.Graphics.DrawString("%", CustomFonts.A8, CustomFonts.black, 506, PrintVariables.Y + 78); e.Graphics.DrawLine(CustomFonts.thinBlack, 498, PrintVariables.Y + 75, 498, PrintVariables.Y + 97);
                e.Graphics.DrawString("Prov\nantal\n QC", CustomFonts.A8, CustomFonts.black, 533, PrintVariables.Y + 56); Print.Thin_Rectangle(e, 528, PrintVariables.Y + 47, 35, 50);
                e.Graphics.DrawString("Datum - Tid", CustomFonts.A8, CustomFonts.black, 586, PrintVariables.Y + 71); Print.Thin_Rectangle(e, 563, PrintVariables.Y + 47, 125, 50);
                e.Graphics.DrawString("Anst.Nr", CustomFonts.A8, CustomFonts.black, 693, PrintVariables.Y + 71); Print.Thin_Rectangle(e, 688, PrintVariables.Y + 47, 50, 50);
                e.Graphics.DrawString("Sign", CustomFonts.A8, CustomFonts.black, 747, PrintVariables.Y + 71); Print.Thin_Rectangle(e, 738, PrintVariables.Y + 47, 41, 50);

            }
            public static void Print_Produktion_Parametrar(PrintPageEventArgs e)
            {
                //              LotNr, Påse, Mj.ID, Mj.OD_k, Mj.OD_l Sk.ID, Sk.OD, Sk.Längd, AntalGod, LevPåse, DragPr, HållN_k, HållN_l, Håll%_k, Håll%_l, ProvAntal, Datum-Tid, AnstNr, Sign
                int[] x = {     PrintVariables.LeftMargin,    91,   128,   168,     0,      208,   248,   288,      328,      393,     433,    468,     0,       498,     0,       528,      563,        688,    738 };
                int[] width = { 67,    37,   40,    40,      0,      40,    40,    40,       65,       40,      35,     30,      0,       30,      0,       35,       125,        50,     41 };
                const int height = 17;
                if (string.IsNullOrEmpty(Order.OrderNumber))
                    return;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                        SELECT * FROM(SELECT CodeText, Value, Text, Bool, Date_Time, AnstNr, Signature, Column_Index, ROW_NUMBER() OVER(ORDER BY Date_Time, Column_Index) AS RowNum
                        FROM  Korprotokoll_Slipning_Produktion AS prod
                            JOIN [User].Person AS op
	                            ON op.EmployeeNumber = prod.AnstNr  WHERE OrderID = @orderid) AS MyDerivedTable
                        WHERE MyDerivedTable.RowNum BETWEEN @start and @slut";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@start", Measureprotocol.FirstRowMeasurment);
                    cmd.Parameters.AddWithValue("@slut", Measureprotocol.LastRowMeasurement);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string? text = null;
                        var IsOkAddRow = false;
                        if (int.TryParse(reader["Column_Index"].ToString(), out var colIndex))
                        {
                            switch (colIndex)
                            {
                                case 0:
                                case 8:
                                case 9:
                                    text = reader["Text"].ToString();
                                    break;
                                case 1:
                                case 7:
                                case 10:
                                case 13:
                                case 14:
                                    double.TryParse(reader["Value"].ToString(), out var intValue);
                                    text = $"{intValue:0}";
                                    break;
                                //2 Decimaler
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    double.TryParse(reader["Value"].ToString(), out var value);
                                    text = $"{value:0.00}";
                                    break;
                                //1 Decimal
                                case 11:
                                case 12:
                                    double.TryParse(reader["Value"].ToString(), out value);
                                    text = $"{value:0.0}";
                                    break;
                                case 15:
                                    text = reader["Text"].ToString();
                                    IsOkAddRow = true;
                                    break;
                            }
                            Print.Text_Operatör(e, text, x[colIndex] + width[colIndex] / 2 + 1, PrintVariables.Y + 103, width[colIndex], true);
                            Print.Thin_Rectangle(e, x[colIndex], PrintVariables.Y + 98, width[colIndex], height);
                            if (IsOkAddRow)
                                PrintVariables.Y += height;
                        }
                        else
                        {
                            var date = DateTime.Parse(reader["Date_Time"].ToString());
                            Print.Text_Operatör(e, date.ToString("yyyy-MM-dd HH:mm"), 623, PrintVariables.Y + 103, width[colIndex], true);
                            Print.Thin_Rectangle(e, 563, PrintVariables.Y + 98, 125, height);

                            Print.Text_Operatör(e, reader["AnstNr"].ToString(), 715, PrintVariables.Y + 103, 50, true);
                            Print.Thin_Rectangle(e, 688, PrintVariables.Y + 98, 50, height);
                            Print.Text_Operatör(e, reader["Signature"].ToString(), 760, PrintVariables.Y + 103, 41, true);
                            Print.Thin_Rectangle(e, 738, PrintVariables.Y + 98, 42, height);

                            bool.TryParse(reader["Bool"].ToString(), out var IsDiscarded);
                            if (IsDiscarded)
                                e.Graphics.DrawLine(CustomFonts.thickBlack, 30, PrintVariables.Y + 110, 758, PrintVariables.Y + 110);
                        }
                    }
                }

                PrintVariables.Y += 110;
            }

            public static void ExtraParametrar_Print_Produktion_Rubriker_Rutor(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Produktion / Slipning:", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);

                e.Graphics.DrawString("Inledande", CustomFonts.A10_B, CustomFonts.black, 28, PrintVariables.Y + 26);                              Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y + 22, 82, 25);
                e.Graphics.DrawString("Skärmat", CustomFonts.A8, CustomFonts.black, 45, PrintVariables.Y + 52);                                   Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y + 47, 82, 25);
                e.Graphics.DrawString("LotNr", CustomFonts.A8, CustomFonts.black, 36, PrintVariables.Y + 77);                                     Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y + 72, 52, 25);
                e.Graphics.DrawString("Påse \n  Nr", CustomFonts.A8, CustomFonts.black, 78, PrintVariables.Y + 73);                               Print.Thin_Rectangle(e, 76, PrintVariables.Y + 72, 30, 25);



                e.Graphics.DrawString("Mjukslang", CustomFonts.A10_B, CustomFonts.black, 107, PrintVariables.Y + 26);                             Print.Thin_Rectangle(e, 106, PrintVariables.Y + 22, 105, 25);
                e.Graphics.DrawString("Uppmätt", CustomFonts.A8, CustomFonts.black, 138, PrintVariables.Y + 52);                                  Print.Thin_Rectangle(e, 106, PrintVariables.Y + 47, 105, 50);
                e.Graphics.DrawString("ID\nmm", CustomFonts.A8, CustomFonts.black, 114, PrintVariables.Y + 71);                                   e.Graphics.DrawLine(CustomFonts.thinBlack, 141, PrintVariables.Y + 72, 141, PrintVariables.Y + 97);
                e.Graphics.DrawString("OD mm", CustomFonts.A8, CustomFonts.black, 156, PrintVariables.Y + 71);          
                e.Graphics.DrawString("kort", CustomFonts.A8, CustomFonts.black, 148, PrintVariables.Y + 84);                                     e.Graphics.DrawString("lång", CustomFonts.A8, CustomFonts.black, 181, PrintVariables.Y + 84);     e.Graphics.DrawLine(CustomFonts.thinBlack, 176, PrintVariables.Y + 85, 176, PrintVariables.Y + 97);


                e.Graphics.DrawString("Skärmad slang", CustomFonts.A10_B, CustomFonts.black, 210, PrintVariables.Y + 26);                         Print.Thin_Rectangle(e, 211, PrintVariables.Y + 22, 106, 25);
                e.Graphics.DrawString("Uppmätt", CustomFonts.A8, CustomFonts.black, 223, PrintVariables.Y + 52);                                  Print.Thin_Rectangle(e, 211, PrintVariables.Y + 47, 106, 50);
                e.Graphics.DrawString("ID\nmm", CustomFonts.A8, CustomFonts.black, 215, PrintVariables.Y + 71);                                   e.Graphics.DrawLine(CustomFonts.thinBlack, 246, PrintVariables.Y + 72, 246, PrintVariables.Y + 97); 
                e.Graphics.DrawString("OD\nmm", CustomFonts.A8, CustomFonts.black, 252, PrintVariables.Y + 71);                                   e.Graphics.DrawLine(CustomFonts.thinBlack, 281, PrintVariables.Y + 47, 281, PrintVariables.Y + 97);
                e.Graphics.DrawString(" Total\nlängd", CustomFonts.A8, CustomFonts.black, 284, PrintVariables.Y + 52);                            e.Graphics.DrawString("mm", CustomFonts.A8, CustomFonts.black, 289, PrintVariables.Y + 83);

                e.Graphics.DrawString("Godkänd, färdig produkt", CustomFonts.A10_B, CustomFonts.black, 330, PrintVariables.Y + 26);               Print.Thin_Rectangle(e, 317, PrintVariables.Y + 22, 462, 25);
                e.Graphics.DrawString("Antal\ngodk.", CustomFonts.A8, CustomFonts.black, 326, PrintVariables.Y + 56);                             Print.Thin_Rectangle(e, 317, PrintVariables.Y + 47, 45, 50);
                e.Graphics.DrawString(" Lev.\npåse\n  nr", CustomFonts.A8, CustomFonts.black, 370, PrintVariables.Y + 56);                        Print.Thin_Rectangle(e, 362, PrintVariables.Y + 47, 40, 50);
                e.Graphics.DrawString("Drag\nprov\nantal", CustomFonts.A7, CustomFonts.black, 403, PrintVariables.Y + 56);                        Print.Thin_Rectangle(e, 402, PrintVariables.Y + 47, 25, 50);

                e.Graphics.DrawString("Hållfasthet", CustomFonts.A8, CustomFonts.black, 472, PrintVariables.Y + 52);                              Print.Thin_Rectangle(e, 427, PrintVariables.Y + 47, 140, 25);
                e.Graphics.DrawString(Print.utskrift_Processkort["Dragprov_enhet"], CustomFonts.A8, CustomFonts.black, 453, PrintVariables.Y + 72); Print.Thin_Rectangle(e, 427, PrintVariables.Y + 72, 70, 25);
                e.Graphics.DrawString("%", CustomFonts.A8, CustomFonts.black, 522, PrintVariables.Y + 72);                                        Print.Thin_Rectangle(e, 497, PrintVariables.Y + 72, 70, 25);
                e.Graphics.DrawString("kort", CustomFonts.A8, CustomFonts.black, 433, PrintVariables.Y + 84);                                     e.Graphics.DrawString("lång", CustomFonts.A8, CustomFonts.black, 469, PrintVariables.Y + 84);     e.Graphics.DrawLine(CustomFonts.thinBlack, 462, PrintVariables.Y + 85, 462, PrintVariables.Y + 97);
                e.Graphics.DrawString("kort", CustomFonts.A8, CustomFonts.black, 504, PrintVariables.Y + 84);                                     e.Graphics.DrawString("lång", CustomFonts.A8, CustomFonts.black, 539, PrintVariables.Y + 84);     e.Graphics.DrawLine(CustomFonts.thinBlack, 532, PrintVariables.Y + 85, 532, PrintVariables.Y + 97);

                e.Graphics.DrawString("Prov\nantal\n QC", CustomFonts.A8, CustomFonts.black, 570, PrintVariables.Y + 52);                         Print.Thin_Rectangle(e, 567, PrintVariables.Y + 47, 30, 50);
                e.Graphics.DrawString("Datum - Tid", CustomFonts.A8, CustomFonts.black, 614, PrintVariables.Y + 69);                              Print.Thin_Rectangle(e, 597, PrintVariables.Y + 47, 96, 50);
                e.Graphics.DrawString("Anst.Nr", CustomFonts.A8, CustomFonts.black, 698, PrintVariables.Y + 69);                                  Print.Thin_Rectangle(e, 693, PrintVariables.Y + 47, 47, 50);
                e.Graphics.DrawString("Sign", CustomFonts.A8, CustomFonts.black, 749, PrintVariables.Y + 69);                                     Print.Thin_Rectangle(e, 740, PrintVariables.Y + 47, 39, 50);

            }
            public static void ExtraParametrar_Print_Produktion_Parametrar(PrintPageEventArgs e)
            {
                //              LotNr, Påse, Mj.ID, Mj.OD_k, Mj.OD_l, Sk.ID, Sk.OD, Sk.Längd, AntalGod, LevPåse, DragPr, HållN_k, HållN_l, Håll%_k, Håll%_l, ProvAntal, Datum-Tid, AnstNr, Sign
                int[] x = { PrintVariables.LeftMargin,76,   106,   141,     176,     211,   246,   281,      317,      362,     402,    427,     462,     497,     532,     567,      597,        693,    740 };
                int[] width = { 52,    30,   35,    35,      35,      35,    35,    36,       45,       40,      25,     35,      35,      35,      35,      30,       96,         47,     39 };
                const int height = 17;
               
                
                if (string.IsNullOrEmpty(Order.OrderNumber))
                    return;
                var ctr_antalRader = 0;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                        SELECT * FROM(SELECT CodeText, Value, Text, Bool, Date_Time, AnstNr, Signature, Column_Index, ROW_NUMBER() OVER(ORDER BY TempID) AS RowNum
                        FROM  Korprotokoll_Slipning_Produktion AS prod
                            JOIN [User].Person AS op
	                            ON op.EmployeeNumber = prod.AnstNr WHERE OrderID = @orderid) AS MyDerivedTable
                        WHERE MyDerivedTable.RowNum BETWEEN @start and @slut";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@start", Measureprotocol.FirstRowMeasurment);
                    cmd.Parameters.AddWithValue("@slut", Measureprotocol.LastRowMeasurement);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string? text = null;
                        if (int.TryParse(reader["Column_Index"].ToString(), out var colIndex))
                        {
                            switch (colIndex)
                            {
                                case 0: case 8: case 9: case 15:
                                    text = reader["Text"].ToString();
                                    break;
                                case 1: case 7: case 10: case 13: case 14:
                                    double.TryParse(reader["Value"].ToString(), out var intValue);
                                    text = $"{intValue:0}";
                                    break;
                                //2 Decimaler
                                case 2: case 3: case 4: case 5: case 6:
                                    double.TryParse(reader["Value"].ToString(), out var value);
                                    text = $"{value:0.00}";
                                    break;
                                //1 Decimal
                                case 11: case 12:
                                    double.TryParse(reader["Value"].ToString(), out value);
                                    text = $"{value:0.0}";
                                    break;
                            }
                            Print.Text_Operatör(e, text, x[colIndex] + width[colIndex] / 2 + 1, PrintVariables.Y + 103, width[colIndex], true);
                            Print.Thin_Rectangle(e, x[colIndex], PrintVariables.Y + 98, width[colIndex], height);
                        }
                        else
                        {
                            ctr_antalRader++;
                            if (ctr_antalRader > 1)
                                PrintVariables.Y += height;

                            var date = DateTime.Parse(reader["Date_Time"].ToString());
                            Print.Text_Operatör(e, date.ToString("yyyy-MM-dd HH:mm"), 643, PrintVariables.Y + 103, width[colIndex], true);
                            Print.Thin_Rectangle(e, 597, PrintVariables.Y + 98, 96, height);
                            Print.Text_Operatör(e, reader["AnstNr"].ToString(), 718, PrintVariables.Y +103, 50, true);
                            Print.Thin_Rectangle(e, 693, PrintVariables.Y + 98, 47, height);
                            Print.Text_Operatör(e, reader["Signature"].ToString(), 760, PrintVariables.Y + 103, 41, true);
                            Print.Thin_Rectangle(e, 740, PrintVariables.Y + 98, 39, height);
                            bool.TryParse(reader["Bool"].ToString(), out var IsDiscarded);
                            if (IsDiscarded)
                                e.Graphics.DrawLine(CustomFonts.thickBlack, 30, PrintVariables.Y + 116, 755, PrintVariables.Y + 116);
                        }
                      
                    }
                }

                PrintVariables.Y += 122;
            }
        }
    }
}
