using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Svetsning
    {
        private static Dictionary<string, string?>? List_PrintOut_Svetsning_Protocol
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
                    const string query = @"SELECT TOP(1) *
                            FROM [Order].MainData
                            WHERE OrderID = @orderid";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
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
        private static Dictionary<string, string?> List_PrintOut_Svetsning_ProcessCard
        {
            get
            {
                var is_Empty = false;
                var list = new Dictionary<string, string?>();
                if (Order.OrderID is null) //Om inget ordernummer finns fylls Listan upp med tomma värden
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
                        SELECT TOP(1) Tid_Förvärme_min, Tid_Förvärme_nom, Tid_Förvärme_max, Svetsförflyttning_min, Svetsförflyttning_nom, Svetsförflyttning_max, Tid_Bindvärme_min, Tid_Bindvärme_nom, 
                            Tid_Bindvärme_max, Tid_Kylluft_min, Tid_Kylluft_nom, Tid_Kylluft_max, Temp_min, Temp_nom, Temp_max, Pinne_OD_Stål_nom, Pinne_OD_PTFE_nom, Värmebackar_Bredd_nom, Värmebackar_Hål_nom,
                            main.Extra_Info, main.Validerade_Loter, main.GodkäntDatum, main.QA_sign, main.UpprättatAv_Sign_AnstNr, main.RevInfo, main.RevÄndratDatum, main.Historiska_Data, main.Validerat, main.Framtagning_Processfönster, main.Aktiv
                    
                        FROM Processkort_Svetsning as svetsning
                        JOIN Processcard.MainData as main
                            ON svetsning.PartID = main.PartID
                        WHERE svetsning.PartID = @artID";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@artID", Order.PartID);
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

        public static PrintDocument Print_Protocol = new PrintDocument();
        public static PrintDocument Print_Protocol_ExtraPage = new PrintDocument();
        public static PrintPreviewDialog Preview_Protocol = new PrintPreviewDialog();
        public static PrintPreviewDialog Preview_Protocol_ExtraPage = new PrintPreviewDialog();
        private static PrintVariables.TotalPrintOuts totalPrintOuts;
        


        private const int TotalRowsExtraPrintOut = 45;

        public Svetsning()
        {
            ((Form)Preview_Protocol_ExtraPage).WindowState = FormWindowState.Maximized;
            ((Form)Preview_Protocol).WindowState = FormWindowState.Maximized;

            Print_Protocol.PrintPage += Protocol_PrintPage;
            Print_Protocol_ExtraPage.PrintPage += Protocol_ExtraPage_PrintPage;

            Preview_Protocol.Document = Print_Protocol;
            Preview_Protocol_ExtraPage.Document = Print_Protocol_ExtraPage;
        }



        public static void Print_Preview_Order(bool IsPrinting)
        {
            Measureprotocol.FirstRowMeasurment = 1;
            Measureprotocol.LastRowMeasurement = 10;
            PrintVariables.Active_PrintOut = 1;
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol, false);
            PrintVariables.CommentIndex = 0;


            var TotalRowsProduction = Korprotokoll.TotalProductionRows("Korprotokoll_Svetsning_Parametrar");
            var TotalExtraPrintOuts = (int)Math.Ceiling(((double)TotalRowsProduction - 10) / TotalRowsExtraPrintOut);
            totalPrintOuts = new PrintVariables.TotalPrintOuts
            {
                PagesSvetsning = 1
            };
            totalPrintOuts.PagesSvetsning += TotalExtraPrintOuts;
            if (IsPrinting)
                Print_Protocol.Print();
            else
                Preview_Protocol.ShowDialog();                

            for (var i = 0; i < TotalExtraPrintOuts + 0; i++)
            {
                PrintVariables.Active_PrintOut++;
                Measureprotocol.FirstRowMeasurment = Measureprotocol.LastRowMeasurement + 1;
                Measureprotocol.LastRowMeasurement = Measureprotocol.FirstRowMeasurment + TotalRowsExtraPrintOut;
                if (IsPrinting)
                    Print_Protocol_ExtraPage.Print();
                else
                    Preview_Protocol_ExtraPage.ShowDialog();
            }
            Workoperation_Printouts.Print_Protocol.Set_DefaultPaperSize(Print_Protocol_ExtraPage, false);
            if (Manage_PrintOuts.IsOkPrintExtraRaderComments)
            {
                if (IsPrinting)
                    Manage_PrintOuts.Print_ExtraComments.Print();
                else
                    Manage_PrintOuts.Preview_ExtraComments.ShowDialog();
            }

            totalPrintOuts.PagesSvetsning = 0;
        }

    

       

        private void Protocol_PrintPage(object sender, PrintPageEventArgs e)
        {
            Print.utskrift_Korprotokoll = List_PrintOut_Svetsning_Protocol;
            Print.utskrift_Processkort = List_PrintOut_Svetsning_ProcessCard;
            PrintVariables.PageWidth = e.PageBounds.Width;
            PrintVariables.PageHeight = e.PageBounds.Height;
            PageHeader(e, "Protokoll för sammanfogning av slang, Svetsning", totalPrintOuts.TotalPages);
            Order_INFO(e);
            
            PrintVariables.Y = 135;
            Print.ProcessCardBasedOn.PrintOut(PrintVariables.LeftMargin, e);

            PrintOut.Print_MaskinParametrar_Rubriker(e);
            PrintOut.Print_MaskinParametrar(e);

            PrintVariables.Y += 20;
            PrintOut.Print_MeasureProtocol_HeadersAndSquares(e);
            PrintVariables.Y += 110;
            PrintOut.Print_MeasureProtocol_Values(e);
            PrintVariables.Y += 10;
            PrintOut.PrintPreFab(e);

            PrintVariables.Y += 10;
            Comments(PrintVariables.LeftMargin, (int)PrintVariables.PageHeight - 130, Print.utskrift_Korprotokoll["Comments"], e);
            PageFooter(e);
            Print.Copy(e);
        }
        private static void Protocol_ExtraPage_PrintPage(object sender, PrintPageEventArgs e)
        {
            PageHeader(e, "Protokoll för sammanfogning av slang, Svetsning", totalPrintOuts.TotalPages);
            Order_INFO(e);
            PrintVariables.Y = 135;
            PrintOut.Print_MeasureProtocol_HeadersAndSquares(e);
            PrintVariables.Y += 110;
            PrintOut.Print_MeasureProtocol_Values(e);
        }

        public class PrintOut
        {
            public static void Print_MaskinParametrar_Rubriker(PrintPageEventArgs e)
            {
                Print.Rubrik(e, "Maskinparametrar:", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin); //237

                //Skriver ut ProcessparameterRubriker samt rutor
                Print.Filled_Rectangle(e, CustomFonts.empty_Space, PrintVariables.LeftMargin, PrintVariables.Y + 22, 37, 42);
                var y1 = PrintVariables.Y + 22;
                var y2 = PrintVariables.Y + 36;
                var y3 = PrintVariables.Y + 50;
              
                Print.Static_InfoText(e, "Svets", 85, y2, false, true);
                Print.Static_InfoText(e, "Förvärme", 141, y2, false,true);
                Print.Static_InfoText(e, "sek", 157, y3, false, true);
                Print.Static_InfoText(e, "Svets", 204, y1, false, true);
                Print.Static_InfoText(e, "förflyttning", 193, y2, false, true);
                Print.Static_InfoText(e, "mm", 209, y3, false, true); 
                Print.Static_InfoText(e, "Tid", 269, y1, false, true);
                Print.Static_InfoText(e, "Bindvärme", 252, y2, false, true);
                Print.Static_InfoText(e, "sek", 270, y3, false, true);
                Print.Static_InfoText(e, "Tid", 320, y1, false, true);
                Print.Static_InfoText(e, "kylluft", 314, y2, false, true);
                Print.Static_InfoText(e, "sek", 321, y3, false, true);
                Print.Static_InfoText(e, "Temp", 356, y1, false, true);
                Print.Static_InfoText(e, "ºC", 363, y3, false, true);
                Print.Static_InfoText(e, "Stål", 397, y2, false, true);
                Print.Static_InfoText(e, "mm", 399, y3, false, true);
                Print.Static_InfoText(e, "PTFE", 446, y2, false, true);
                Print.Static_InfoText(e, "mm", 450, y3, false, true);
                Print.Static_InfoText(e, "Bredd", 501, y2, false, true);
                Print.Static_InfoText(e, "mm", 506, y3, false, true);
                Print.Static_InfoText(e, "Hål", 544, y2, false, true);
                Print.Static_InfoText(e, "mm", 543, y3, false, true);
                Print.Static_InfoText(e, "Datum", 590, y2, false, true);
                Print.Static_InfoText(e, "Tid", 660, y2, false, true);
                Print.Static_InfoText(e, "AnstNr", 698, y2, false, true);
                Print.Static_InfoText(e, "Sign", 743, y2, false, true);
                
                e.Graphics.DrawString("Pinne OD", CustomFonts.A8_B, CustomFonts.black, 420, y1);
                e.Graphics.DrawString("Värmebackar", CustomFonts.A8_B, CustomFonts.black, 495, y1);

                int[] x = { 61, 141, 193, 251, 309, 354, 568, 648, 693, 738 };
                int[] w = { 80, 52, 58, 58, 45, 35, 80, 45, 45, 41 };
                for (var i = 0; i < 10; i++)
                    Print.Thin_Rectangle(e, x[i], y1, w[i], 42);
               
                //e.Graphics.DrawLine(CustomFonts.thinBlack, 389, y1, 569, y1);
                e.Graphics.DrawLine(CustomFonts.thinBlack, 389, PrintVariables.Y+35, 568, PrintVariables.Y + 35);
                
                e.Graphics.DrawLine(CustomFonts.thinBlack, 426, PrintVariables.Y+35, 426, PrintVariables.Y + 64);  //Linje Mellan Stål och PTFE
                e.Graphics.DrawLine(CustomFonts.thinBlack, 494, PrintVariables.Y+35, 494, PrintVariables.Y + 64);  //Linje Mellan PTFE och Bredd
                e.Graphics.DrawLine(CustomFonts.thinBlack, 536, PrintVariables.Y+35, 536, PrintVariables.Y + 64);  //Linje Mellan Bredd och Hål
               
                //Ritar ut MIN/NOM/MAX Rutor
                string?[] strings = { "MIN", "NOM", "MAX" };
                var y = PrintVariables.Y+64;
                SolidBrush pen = null;

                for (var i = 0; i < 3; i++)
                {
                    if (i == 1)
                        pen = CustomFonts.nom;
                    else
                        pen = CustomFonts.min_max;
                    Print.Filled_Rectangle(e, pen, PrintVariables.LeftMargin, y, 37, 18);
                    e.Graphics.DrawString(strings[i], CustomFonts.A8_B, CustomFonts.black, 44 - Print.StringWidth(strings[i], CustomFonts.A8_B, e.Graphics) / 2, y + 3);
                    y += 18;
                }
               
                //Ritar ut resterande MIN/NOM/MAX Rutor som Processparametrarna står i

                y = PrintVariables.Y + 64;
                x = new[] { 61, 141, 193, 251, 309, 354, 389, 426, 494, 536, 568, 648, 693, 738 };
                w = new[] { 80, 52, 58, 58, 45, 35, 38, 68, 42, 32, 80, 45, 45, 41 };
                for (var rad = 0; rad < 3; rad++)
                {
                    for (var kol = 0; kol < x.Length; kol++)
                    {
                        if (rad == 0 || rad == 2)
                            pen = CustomFonts.min_max;
                        if (rad == 1)
                            pen = CustomFonts.nom;
                        Print.Filled_Rectangle(e, pen, x[kol], y, w[kol], 18);
                    }
                    y += 18;
                    if (rad == 2)
                        y++;
                }
                
                Print.Filled_Rectangle(e, CustomFonts.empty_Space, 61, PrintVariables.Y+64, 80, 54);
                Print.Filled_Rectangle(e, CustomFonts.empty_Space, 389, PrintVariables.Y+64, 390, 18);
                Print.Filled_Rectangle(e, CustomFonts.empty_Space, 389, PrintVariables.Y+100, 390, 18);
            }
            public static void Print_MaskinParametrar(PrintPageEventArgs e)
            {
                string?[] strings_ = {Print.utskrift_Processkort["Tid_Förvärme_min"], Print.utskrift_Processkort["Svetsförflyttning_min"], Print.utskrift_Processkort["Tid_Bindvärme_min"], Print.utskrift_Processkort["Tid_Kylluft_min"], Print.utskrift_Processkort["Temp_min"],
                                     Print.utskrift_Processkort["Tid_Förvärme_nom"], Print.utskrift_Processkort["Svetsförflyttning_nom"], Print.utskrift_Processkort["Tid_Bindvärme_nom"], Print.utskrift_Processkort["Tid_Kylluft_nom"], Print.utskrift_Processkort["Temp_nom"], Print.utskrift_Processkort["Pinne_OD_Stål_nom"],Print.utskrift_Processkort["Pinne_OD_PTFE_nom"], Print.utskrift_Processkort["Värmebackar_Bredd_nom"],  Print.utskrift_Processkort["Värmebackar_Hål_nom"],
                                     Print.utskrift_Processkort["Tid_Förvärme_max"], Print.utskrift_Processkort["Svetsförflyttning_max"], Print.utskrift_Processkort["Tid_Bindvärme_max"], Print.utskrift_Processkort["Tid_Kylluft_max"], Print.utskrift_Processkort["Temp_max"] };
                int[] x_ = {                     168,                                223,                               281,                           333,                         372,
                                                 168,                                223,                               281,                           333,                         372,                  409,                          460,                           516,                                553,
                                                 168,                                223,                               281,                           333,                         372 };

                int[] y_ = {                     PrintVariables.Y+67,                PrintVariables.Y+67,               PrintVariables.Y+67,           PrintVariables.Y+67,         PrintVariables.Y+67,
                                                 PrintVariables.Y+84,                PrintVariables.Y+84,               PrintVariables.Y+84,           PrintVariables.Y+84,         PrintVariables.Y+84,                  PrintVariables.Y+84,                          PrintVariables.Y+84,                           PrintVariables.Y+84,                                PrintVariables.Y+84,
                                                 PrintVariables.Y+103,                PrintVariables.Y+103,               PrintVariables.Y+103,        PrintVariables.Y+103,        PrintVariables.Y+103 };

                for (var i = 0; i < strings_.Length; i++)
                    e.Graphics.DrawString(strings_[i], CustomFonts.parametrarFont, CustomFonts.parametrar_clr, x_[i] - Print.StringWidth(strings_[i], CustomFonts.parametrarFont, e.Graphics) / 2, y_[i]);

                PrintVariables.Y += 118;
                //Hämtar Operatörens Maskinparametrar
                const int height = 18;
                if (!string.IsNullOrEmpty(Order.OrderNumber))
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = $@"
                            SELECT  Svets,              61, 80, 
                                    Tid_Förvärme,       141, 52,
                                    Svetsförflyttning,  193, 58,
                                    Tid_Bindvärme,      251, 58,
                                    Tid_Kylluft,        309, 45, 
                                    Temperatur,         354, 35,
                                    Pinne_OD_Stål,      389, 37,
                                    Pinne_OD_PTFE,      426, 68,
                                    Värmebackar_Bredd,  494, 42,
                                    Värmebackar_Hål,    536, 32,
                                    Datum,              568, 80,
                                    Tid,                648, 45,
                                    AnstNr,             693, 45,
                                    Sign,               738, 41,
                                    Kasserad
                            
                            FROM Korprotokoll_Svetsning_Maskinparametrar WHERE OrderID = @orderid";

                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            for (var i = 0; i < reader.FieldCount - 1; i += 3)
                            {
                                var x = int.Parse(reader[i + 1].ToString());
                                var maxWidth = int.Parse(reader[i + 2].ToString());
                                Print.Thin_Rectangle(e, x, PrintVariables.Y, maxWidth, height);
                                Print.Text_Operatör(e, reader[i].ToString(), x + maxWidth / 2,  PrintVariables.Y, maxWidth, true);
                            }

                            if ((bool)reader["Kasserad"])
                                e.Graphics.DrawLine(CustomFonts.thickBlack, 60, PrintVariables.Y + 6, 755, PrintVariables.Y + 6);
                            PrintVariables.Y += height;
                        }
                    }
                }
               
            }
            public static void Print_MeasureProtocol_HeadersAndSquares(PrintPageEventArgs e)
            {
                var margin = PrintVariables.LeftMargin;
                Print.Rubrik(e, "Produktion / Svetsning", margin, PrintVariables.Y, PrintVariables.MaxPaperWidth - margin);
                e.Graphics.DrawString("Inledande", CustomFonts.A10_B, CustomFonts.black, 28, PrintVariables.Y + 32); e.Graphics.DrawString("Inspektion, färdig svets", CustomFonts.A10_B, CustomFonts.black, 368, PrintVariables.Y + 32);

                e.Graphics.DrawString("Skärmat", CustomFonts.A8, CustomFonts.black, 50, PrintVariables.Y + 52); 
                Print.Thin_Rectangle(e, margin, PrintVariables.Y + 50, 104, 15);
                e.Graphics.DrawString("LotNr", CustomFonts.A8, CustomFonts.black, 42, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, margin, PrintVariables.Y + 65, 104, 45); 
                e.Graphics.DrawString("Påse \n  Nr", CustomFonts.A8, CustomFonts.black, 94, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 91, PrintVariables.Y + 65, 37, 45);
                e.Graphics.DrawString("Uppmätt\n  pinne", CustomFonts.A8, CustomFonts.black, 135, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 128, PrintVariables.Y + 50, 60, 60);
                e.Graphics.DrawString("Uppmätt vid produktionsstart", CustomFonts.A8, CustomFonts.black, 194, PrintVariables.Y + 52); 
                Print.Thin_Rectangle(e, 188, PrintVariables.Y + 50, 180, 15);
                e.Graphics.DrawString("     ID\nskärmat", CustomFonts.A8, CustomFonts.black, 195, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 188, PrintVariables.Y + 65, 60, 45); 
                e.Graphics.DrawString("    OD\nskärmat", CustomFonts.A8, CustomFonts.black, 254, PrintVariables.Y + 75); 
                Print.Thin_Rectangle(e, 248, PrintVariables.Y + 65, 60, 45); 
                e.Graphics.DrawString(" Längd\nskärmat", CustomFonts.A8, CustomFonts.black, 316, PrintVariables.Y + 75); 
                Print.Thin_Rectangle(e, 308, PrintVariables.Y + 65, 60, 45);
                e.Graphics.DrawString("Visuell test", CustomFonts.A8, CustomFonts.black, 391, PrintVariables.Y + 52); 
                Print.Thin_Rectangle(e, 368, PrintVariables.Y + 50, 110, 15); 
                e.Graphics.DrawString("Utsida\n  (JA)", CustomFonts.A8, CustomFonts.black, 375, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 368, PrintVariables.Y + 65, 55, 45); 
                e.Graphics.DrawString("Insida\n  (JA)", CustomFonts.A8, CustomFonts.black, 432, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 423, PrintVariables.Y + 65, 55, 45);
                e.Graphics.DrawString("Datum", CustomFonts.A8, CustomFonts.black, 502, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 478, PrintVariables.Y + 50, 90, 60);
                e.Graphics.DrawString("Tid", CustomFonts.A8, CustomFonts.black, 592, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 568, PrintVariables.Y + 50, 70, 60);
                e.Graphics.DrawString("Anst.Nr", CustomFonts.A8, CustomFonts.black, 654, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 638, PrintVariables.Y + 50, 70, 60);
                e.Graphics.DrawString("Sign", CustomFonts.A8, CustomFonts.black, 729, PrintVariables.Y + 81); 
                Print.Thin_Rectangle(e, 708, PrintVariables.Y + 50, 71, 60);

               // int[] x = { 26, 91, 128, 188, 248, 308, 368, 423, 478, 568, 638, 708 };
               // int[] width = { 65, 37, 60, 60, 60, 60, 55, 55, 90, 70, 70, 71 };
               // var height = 17;
                //var antalRader = Variables.Y + 111 + antal_rader * height + height;

                //for (var rad = Variables.Y + 111; rad < antalRader; rad += height)
                //{
                //    for (var kol = 0; kol < x.Length; kol++)
                //        Print.Thin_Rectangle(e, x[kol], rad, width[kol], height);
                //}

               // e.Graphics.DrawLine(CustomFonts.mediumBlack, 368, Variables.Y + 111, 368, antalRader);
            }
            public static void Print_MeasureProtocol_Values(PrintPageEventArgs e)
            {
                if (Order.OrderID is null)
                    return;
                const int RowHeight = 17;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = $@"
                        SELECT  Inledande_OrderNr,      24 AS x, 67 AS width, 
                                Inledande_Påse,         91,      37, 
                                Inledande_UppmättPinne, 128,     60, 
                                Inledande_ID,           188,     60, 
                                Inledande_OD,           248,     60, 
                                Inledande_Längd,        308,     60, 
                                Inspektion_Utsida,      368,     55, 
                                Inspektion_Insida,      423,     55, 
                                Datum,                  478,     90, 
                                Tid,                    568,     70, 
                                AnstNr,                 638,     70, 
                                Sign,                   708,     70, 
                                Kasserad
                        FROM(SELECT *, ROW_NUMBER() OVER(ORDER BY Datum, TID) AS RowNum
                            FROM Korprotokoll_Svetsning_Parametrar WHERE OrderID = @orderid) AS MyDerivedTable 
                            WHERE MyDerivedTable.RowNum BETWEEN @start and @slut";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@start", Measureprotocol.FirstRowMeasurment);
                cmd.Parameters.AddWithValue("@slut", Measureprotocol.LastRowMeasurement);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        
                    for (var i = 0; i < reader.FieldCount - 1; i += 3)
                    {
                        var x = int.Parse(reader[i + 1].ToString());
                        var maxWidth = int.Parse(reader[i + 2].ToString());
                        Print.Thin_Rectangle(e, x, PrintVariables.Y, maxWidth, RowHeight);

                        if (i == 18 || i == 21) //Om kolumn = Utsida/Insida(boolean)
                        {
                            if ((bool)reader[i])
                                Print.Text_Operatör(e, "✓", (x + int.Parse(reader[i + 2].ToString()) / 2 + 1), PrintVariables.Y + 2, maxWidth, true);
                        }
                        else
                            Print.Text_Operatör(e, reader[i].ToString(), x + maxWidth / 2 + 1, PrintVariables.Y, maxWidth, true);
                    }
                        
                    if ((bool)reader["Kasserad"])
                        e.Graphics.DrawLine(CustomFonts.thickBlack, 30, PrintVariables.Y + 6, 755, PrintVariables.Y + 6);
                    PrintVariables.Y += RowHeight;
                }

                //if (!string.IsNullOrEmpty(Order.OrderNumber) && ctr_antalRader < antal_Rader)
                //    e.Graphics.DrawLine(CustomFonts.thinBlack, 30, PrintVariables.Y, 767, (PrintVariables.Y - ctr_antalRader * RowHeight) + antal_Rader * RowHeight - 4 + RowHeight);
            }
            public static void PrintPreFab(PrintPageEventArgs e)
            {
                int margin = PrintVariables.LeftMargin;
                Print.Rubrik(e, "Halvfabrikat:", margin, PrintVariables.Y, PrintVariables.MaxPaperWidth - margin);
                e.Graphics.DrawString("Slang", CustomFonts.A9_BI, CustomFonts.black, 30, PrintVariables.Y + 23); Print.Thin_Rectangle(e, margin, PrintVariables.Y + 22, 122, 20);
                e.Graphics.DrawString("ArtikelNr", CustomFonts.A9_BI, CustomFonts.black, 148, PrintVariables.Y + 23); Print.Thin_Rectangle(e, 146, PrintVariables.Y + 22, 120, 20);
                e.Graphics.DrawString("LotNr", CustomFonts.A9_BI, CustomFonts.black, 270, PrintVariables.Y + 23); Print.Thin_Rectangle(e, 266, PrintVariables.Y + 22, 100, 20);
                e.Graphics.DrawString("ID", CustomFonts.A9_BI, CustomFonts.black, 370, PrintVariables.Y + 23); Print.Thin_Rectangle(e, 366, PrintVariables.Y + 22, 50, 20);
                e.Graphics.DrawString("OD", CustomFonts.A9_BI, CustomFonts.black, 420, PrintVariables.Y + 23); Print.Thin_Rectangle(e, 416, PrintVariables.Y + 22, 50, 20);
                e.Graphics.DrawString("W", CustomFonts.A9_BI, CustomFonts.black, 470, PrintVariables.Y + 23); Print.Thin_Rectangle(e, 466, PrintVariables.Y + 22, 50, 20);
                e.Graphics.DrawString("Längd", CustomFonts.A9_BI, CustomFonts.black, 520, PrintVariables.Y + 23); Print.Thin_Rectangle(e, 516, PrintVariables.Y + 22, 263, 20);

                if (string.IsNullOrEmpty(Order.OrderNumber))
                    return;

                PrintVariables.Y += 43;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {   //första talet motsvarar X, andra talet = Width
                    var query = $@"
                        SELECT Typ, 24 AS x, 122 AS width, Halvfabrikat_ArtikelNr, 146, 120, Halvfabrikat_OrderNr, 266, 100, Halvfabrikat_ID, 366, 50, Halvfabrikat_OD, 416, 50, Halvfabrikat_W, 466, 50, Length, 516, 263
                        FROM [Order].Prefab
                        {Queries.WHERE_OrderID} 
                        ORDER BY TempID";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                  
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i += 3)
                        {
                            Print.Thin_Rectangle(e, int.Parse(reader[i + 1].ToString()), PrintVariables.Y, int.Parse(reader[i + 2].ToString()), 20);
                            e.Graphics.DrawString(reader[i].ToString(), CustomFonts.operatörFont, CustomFonts.parametrar_clr, int.Parse(reader[i + 1].ToString()) + 5, PrintVariables.Y);
                        }

                        PrintVariables.Y += 20;
                    }
                }
            }
        }
    }
}

