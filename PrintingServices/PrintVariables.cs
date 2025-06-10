using DigitalProductionProgram.Protocols;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using DigitalProductionProgram.PrintingServices.Workoperation_Printouts;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;
using DigitalProductionProgram.OrderManagement;
using System.Data;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.PrintingServices
{
    internal static class PrintVariables
    {
        public const int RowHeight = 18;
        public static int LeftMargin = 24;
        public static int StartPointProcesscard = 242;

        public static int Active_PrintOut;
        public static int CommentIndex;
        public static int ExtraCommentRow_From;
        public static int ExtraCommentRow_To;
        public static int MachineIndex;
        public static int MaxPaperWidth;
        public static int MaxPaperHeight;
        public static int MaxWidthProcesscardRunProtocol;
        public static int StartUp_From;
        public static int StartUp_To;

        public static int Y;

        public static float PageWidth;
        public static float PageHeight;

        public static bool IsCommentsPrintedOut;

        public class TotalPrintOuts
        {
            private int PagesComments { get; set; }
            public int PagesExtraComments { get; set; }
            public int PagesExtraLineClearance =>
                (Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID ?? 0) == 0 ? 0 : 1;
            public int PagesMainProtocol = 0;
            public int PagesProtocols { get; set; }
            public int PagesMeasureProtocol => Measureprotocol.TotalMeasureProtocols;
            public int PagesCompound
            {
                get
                {
                    return Settings.Settings.SpecialPartNumbers.DataTable_SpecialPartNr("Kompoundering").AsEnumerable().Any(row => Order.PartNumber == row.Field<string>("PartNr")) ? 1 : 0;
                }
            }
            public int PagesFrequencyMarking => FrequencyMarking.IsLäcksökning ? 1 : 0;
            public int PagesKragning { get; set; }
            public int PagesSvetsning { get; set; }
            public int PagesSkärmning { get; set; }
            public int PagesSlipning { get; set; }
            public int PagesBlandning { get; set; }
            public int PagesSpolning { get; set; }

            public void SetPagesExtraComments()
            {
                PagesExtraComments = (int)Math.Ceiling(TotalRowsExtraComments * RowHeight / (MaxPaperHeight - 221));
            }
            public void SetPagesComments(PrintPageEventArgs e, string? comments, int x, int startY, int maxY)
            {
                float pageWidth = e.PageBounds.Width - 2 * x;
                var commentLines = Regex.Split(comments, @"\r\n|\r|\n");
                var firstPageHeight = maxY - startY;
                var otherPageHeight = (int)PageHeight - 130;//130 är extra marginaler uppe och nere
                var pageHeight = firstPageHeight;
                float currentHeight = 0;
                var pageCount = 0;

                foreach (var comment in commentLines)
                {
                    var text = comment.Replace("\t", "    "); // Replace tabs with spaces
                    var textSize = e.Graphics.MeasureString(text, CustomFonts.operatörFont, (int)pageWidth - LeftMargin);

                    if (currentHeight + textSize.Height > pageHeight)
                    {
                        // Move to the next page
                        pageCount++;
                        currentHeight = 0;
                        pageHeight = otherPageHeight; // From now on, we have 1000px per page
                    }

                    currentHeight += (int)textSize.Height;
                }
                PagesComments = pageCount;
            }
            public void SetPagesProtocols(int TotalRows_Template, int MaxRowsRunProtocol)
            {
                var totalPages = 0;
                //totalPrintOutsForModules berättar hur många utskrifter det behövs
                var totalPrintOutsForModules = Math.Ceiling((double)TotalRows_Template / MaxRowsRunProtocol);

                for (var machineIndex = 1; machineIndex < Korprotokoll.Total_Machines + 1; machineIndex++)
                {
                    MachineIndex = machineIndex;
                    var list = Print_Protocol.List_FormTemplateID;
                    var list_ctr = 0;
                    for (var i = 0; i < totalPrintOutsForModules; i++)
                    {
                        var List_FormTemplates = new List<int>();
                        var lastRowModule = 0;
                        var IsActiveFormTemplatesFull = false;
                        do //Lägger till så många FormTemplates som det får rum på ett papper
                        {
                            if (list_ctr == list.Count)
                                break;
                            var formtemplateid = list[list_ctr];
                            //Räknar hur många rader formtemplaten har och lägger till det i totalen och ser om det får rum på pappret
                            lastRowModule += Print_Protocol.TotalRows_FormTemplateID(formtemplateid);

                            if (lastRowModule > MaxRowsRunProtocol)
                            {
                                IsActiveFormTemplatesFull = true;
                                continue;
                            }

                            list_ctr++;
                            List_FormTemplates.Add(formtemplateid);

                        } while (IsActiveFormTemplatesFull == false);

                        var totalPrintOutsForStartUps = Print_Protocol.TotalPrintOutsForStartUps(List_FormTemplates);

                        for (var j = 0; j < totalPrintOutsForStartUps; j++)
                            totalPages ++;
                    }
                }

                PagesProtocols = totalPages;
            }
            

            public int TotalPages => 
                PagesMainProtocol + 
                PagesComments + 
                PagesExtraComments + 
                PagesExtraLineClearance + 
                PagesProtocols + 
                PagesMeasureProtocol + 
                PagesCompound + 
                PagesFrequencyMarking + 
                PagesKragning +
                PagesSvetsning + 
                PagesSkärmning + 
                PagesSlipning +
                PagesBlandning +
                PagesSpolning;
        }
    }
}
