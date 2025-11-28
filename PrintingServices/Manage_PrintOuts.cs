using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices.Workoperation_Printouts;

namespace DigitalProductionProgram.PrintingServices
{
    internal class Manage_PrintOuts
    {
        public static PrintPreviewDialog Preview_Diagram_Sökning_Processkort = new PrintPreviewDialog();
        

        public static PrintPreviewDialog Preview_Comments_And_ExtraComments = new PrintPreviewDialog();
        public static PrintPreviewDialog Preview_ExtraComments = new PrintPreviewDialog();
        public static PrintPreviewDialog Preview_Comments_Extra_Rows = new PrintPreviewDialog();
        
       
        public static PrintDocument Print_Diagram_Sökning_Processkort = new PrintDocument();
       

        public static PrintDocument Print_Comments_And_ExtraComments = new PrintDocument();
        public static PrintDocument Print_ExtraComments = new PrintDocument();
        public static PrintDocument Print_Comments_Extra_Rows = new PrintDocument();
        public static PrintDocument Print_Pictures = new PrintDocument();
       
       
        public static Chart? chart_Diagram;

        public static bool IsOkPrintExtraRaderComments = false;
       


        public Manage_PrintOuts()
        {
            Print_Diagram_Sökning_Processkort.PrintPage += Diagram_Sökning_Processkort_PrintPage;
         
            Preview_Comments_And_ExtraComments.Document = Print_Comments_And_ExtraComments;
            Preview_ExtraComments.Document = Print_ExtraComments;
            Preview_Comments_Extra_Rows.Document = Print_Comments_Extra_Rows;
            Preview_Diagram_Sökning_Processkort.Document = Print_Diagram_Sökning_Processkort;
            

            var BlandningPTFE = new Blandning_PTFE();
            var extruderingTef = new Print_Protocol();
            var kragning_TEF = new Kragning_TEF();
            var skärmning = new Skärmning();
            var slipning = new Slipning_TEF();
            var spolning = new Spolning_PTFE();
            var measureprotocol = new Measureprotocol();
        }

        // Add keywords that identify virtual/PDF printers
        private static readonly string[] PdfKeywords = new[] { "pdf", "xps", "microsoft print to pdf", "adobe pdf" };
        public static void Choose_PrintOut()
        {

            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                    Blandning_PTFE.Print_Preview_Order(true);
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    Kragning_TEF.Print_Preview_Order(true);
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Slipning_TEF.Print_PreviewOrder(true);
                    break;
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    Spolning_PTFE.PrintPreview_Order(true);
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Skärmning.Print_Preview_Order(true);
                    break;

                default:
                    _ = Print_Protocol.Print_Preview_Order(true);
                    break;
            }
        }

        // Returns true if we have an acceptable physical printer (or user picked one).
        public static bool IsPrinterSelected
        {
            get
            {
                var settings = new PrinterSettings();
                var current = settings.PrinterName ?? string.Empty;

                // If no valid printer or looks like PDF/XPS -> force selection
                if (!settings.IsValid || ContainsPdfKeyword(current))
                {
                    var message = !settings.IsValid
                        ? "No valid default printer was found. Please select a printer."
                        : $"The current default printer is \"{current}\" which appears to be a PDF/XPS printer. Please select a physical printer.";

                    var result = MessageBox.Show(message, "Printer check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Cancel)
                        return false;

                    return PromptUserToSelectPrinter();
                }

                return true;
            }
        }
        // Shows a PrintDialog to let the operator choose a printer. Returns true if an acceptable choice was made.
        private static bool PromptUserToSelectPrinter()
        {
            using var pd = new PrintDialog();
            pd.AllowSomePages = false;
            pd.AllowSelection = false;
            pd.ShowHelp = false;
            pd.PrinterSettings = new PrinterSettings();

            if (pd.ShowDialog() != DialogResult.OK)
                return false;

            var chosen = pd.PrinterSettings.PrinterName ?? string.Empty;
            if (ContainsPdfKeyword(chosen))
            {
                MessageBox.Show("Selected printer still looks like a PDF/XPS printer. Please choose a physical printer.", "Printer check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ApplyPrinterToAllPrintDocuments(chosen);
            return true;
        }
        private static bool ContainsPdfKeyword(string printerName)
        {
            if (string.IsNullOrWhiteSpace(printerName))
                return true;

            foreach (var k in PdfKeywords)
            {
                if (printerName.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }

            return false;
        }

        // Set the chosen printer on the shared PrintDocument instances.
        private static void ApplyPrinterToAllPrintDocuments(string printerName)
        {
            var docs = new[] { Print_Diagram_Sökning_Processkort, Print_Comments_And_ExtraComments, Print_ExtraComments, Print_Comments_Extra_Rows, Print_Pictures };
            foreach (var doc in docs)
            {
                if (doc != null)
                    doc.PrinterSettings.PrinterName = printerName;
            }
        }

        public static void Preview_Diagram()
        {
            Preview_Diagram_Sökning_Processkort.ShowDialog();
        }

        
        private static void Diagram_Sökning_Processkort_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintVariables.TotalPrintOuts totalPrintOuts = new PrintVariables.TotalPrintOuts();
            Print_Protocol.PrintOut.PageHeader(e, "Blankett: Diagram", totalPrintOuts.TotalPages);
            Print.Diagram.Print_Order_Info(e);
            Print.Diagram.Print_Chart(e, chart_Diagram);
        }
       

    }
}

