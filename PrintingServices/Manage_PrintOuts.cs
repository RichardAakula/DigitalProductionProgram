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
       
       
        public static Chart chart_Diagram;

        public static bool IsExtraCommentsDone = true;
        public static bool IsOkPrintExtraRaderComments = false;
        public static int next_row_Extra_Comments;
       


        public Manage_PrintOuts()
        {
            Print_Diagram_Sökning_Processkort.PrintPage += Diagram_Sökning_Processkort_PrintPage;
         

            //Print_Comments_And_ExtraComments.PrintPage += Comments_Extrudering_PrintPage;
            //Print_Comments_Extra_Rows.PrintPage += Comments_Extrudering_Extra_Rader_PrintPage;
            //Print_ExtraComments.PrintPage += ExtraComments_PrintPage;

           
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
            var svetsning = new Svetsning();
            var measureprotocol = new Measureprotocol();
        }

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
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Svetsning.Print_Preview_Order(true);
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

