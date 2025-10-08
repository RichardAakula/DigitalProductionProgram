using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.LineClearance;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;
using System.Text.RegularExpressions;
using DigitalProductionProgram.ControlsManagement;
using static DigitalProductionProgram.PrintingServices.PrintVariables;
using static DigitalProductionProgram.PrintingServices.Workoperation_Printouts.Print_Protocol.PrintOut;
using FrequencyMarking = DigitalProductionProgram.Protocols.ExtraProtocols.FrequencyMarking;
using PreFab = DigitalProductionProgram.Protocols.ExtraProtocols.PreFab;

namespace DigitalProductionProgram.PrintingServices.Workoperation_Printouts
{
    internal class Print_Protocol
    {
        public static PrintPreviewDialog Preview_MainProtocol = new();
        public static PrintPreviewDialog Preview_RunProtocol = new();
        public static PrintPreviewDialog Preview_Comments = new();
        public static PrintPreviewDialog Preview_ExtraComments = new();
        public static PrintPreviewDialog Preview_LineClearance = new();
        public static PrintPreviewDialog Preview_FrequencyMarking = new();
        public static PrintPreviewDialog Preview_Compound_Protocol = new();

        public static PrintDocument Print_MainProtocol = new();
        public static PrintDocument Print_RunProtocol = new();
        public static PrintDocument Print_Comments = new();
        public static PrintDocument Print_ExtraComments = new();
        public static PrintDocument Print_LineClearance = new();
        public static PrintDocument Print_Compund_Protocol = new();
        public static PrintDocument Print_FrequencyMarking = new();
        public static TotalPrintOuts? totalPrintOuts;

        public Print_Protocol()
        {
            Print_MainProtocol.PrintPage += PrintPage_MainProtocol;
            Print_RunProtocol.PrintPage += PrintPage_RunProtocol;
            Print_Comments.PrintPage += Print_Page_Comments;
            Print_ExtraComments.PrintPage += Print_Page_ExtraComments;
            Print_LineClearance.PrintPage += ExtraLineClearance_Print_Page;
            Print_Compund_Protocol.PrintPage += Print_Compound_Protocol_PrintPage;
            Print_FrequencyMarking.PrintPage += Frekvensmarkering_PrintPage;
            Print_FrequencyMarking.DefaultPageSettings.Landscape = true;


            Preview_RunProtocol.Document = Print_RunProtocol;
            Preview_MainProtocol.Document = Print_MainProtocol;
            Preview_Compound_Protocol.Document = Print_Compund_Protocol;
            Preview_Comments.Document = Print_Comments;
            Preview_LineClearance.Document = Print_LineClearance;
            Preview_ExtraComments.Document = Print_ExtraComments;
            Preview_FrequencyMarking.Document = Print_FrequencyMarking;
        }

        public static void Set_DefaultPaperSize(PrintDocument document, bool IsLandscapeMode)
        {
            var paperName = document.DefaultPageSettings.PaperSize.PaperName;

            // Set the orientation
            document.DefaultPageSettings.Landscape = IsLandscapeMode;

            // Set the paper size based on the specified format
            var size = paperName == "Letter" ? new PaperSize("Letter", 850, 1100) : new PaperSize("A4", 827, 1169); // Width and Height in hundredths of an inch
            document.DefaultPageSettings.PaperSize = size;

            // Get the paper size after setting it
            var defaultPaperSize = document.DefaultPageSettings.PaperSize;

            // Adjust width and height based on orientation
            var paperWidth = IsLandscapeMode ? defaultPaperSize.Height : defaultPaperSize.Width;
            var paperHeight = IsLandscapeMode ? defaultPaperSize.Width : defaultPaperSize.Height;

            // Calculate the maximum dimensions

            PrintVariables.MaxPaperWidth = paperWidth - PrintVariables.LeftMargin * 2;
            PrintVariables.MaxPaperHeight = paperHeight - PrintVariables.LeftMargin * 2;
            PrintVariables.MaxWidthProcesscardRunProtocol = PrintVariables.MaxPaperWidth - PrintVariables.StartPointProcesscard;
        }

        private static int TotalRows_Template
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        WITH RankedTemplates AS 
                        (
                            SELECT 
                                FormTemplateID, 
                                RowIndex, 
                                ROW_NUMBER() OVER (PARTITION BY FormTemplateID, RowIndex ORDER BY ID) AS rn
                            FROM Protocol.Template
                            WHERE FormTemplateID IN 
                                ( SELECT FormTemplateID
                                    FROM Protocol.FormTemplate
                                    WHERE MainTemplateID = @maintemplateid
                                )
                        )
                        SELECT COUNT(*)
                        FROM RankedTemplates
                        WHERE rn = 1
                        AND RowIndex IS NOT NULL";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        return int.Parse(value.ToString());
                }

                _ = Activity.Stop($"Error: Skriver ut Körprotokoll - Fel TotalRows_Template. MainTemplateID = {Templates_Protocol.MainTemplate.ID}");
                return 0;
            }
        }
        public static List<int> List_FormTemplateID
        {
            get
            {
                var list = new List<int>();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query =
                    @"SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid AND MachineIndex = @machineindex ORDER BY TemplateOrder";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@machineindex", PrintVariables.MachineIndex);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(int.Parse(reader["FormTemplateID"].ToString()));

                return list;
            }
        }
        public static List<int> Active_FormTemplates = new List<int>();

        public static int TotalRows_FormTemplateID(int formtemplateid)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                        WITH RankedTemplates AS 
                        (
                            SELECT 
                                FormTemplateID, 
                                RowIndex, 
                                ROW_NUMBER() OVER (PARTITION BY FormTemplateID, RowIndex ORDER BY ID) AS rn
                            FROM Protocol.Template
                            WHERE FormTemplateID = @formtemplateid
                        )
                        SELECT COUNT(*)
                        FROM RankedTemplates
                        WHERE rn = 1
                        AND RowIndex IS NOT NULL";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value != null)
                return int.Parse(value.ToString() ?? string.Empty);
            return 0;
        }

        public static int TotalPrintOutsForStartUps(List<int> List_FormTemplates)
        {
            //Kontrollerar maxbredden på kolumnerna på körprotokoll samt processkort för inkommande FormTemplates och kollar hur många utskrifter som krävs för dessa
            if (List_FormTemplates.Count == 0)
                return 0;
            var max_Width = PrintVariables.MaxWidthProcesscardRunProtocol;

            var processcard_MinWidth = 0;
            var processcard_NomWidth = 0;
            var processcard_MaxWidth = 0;
            var runProtocol_ColWidth = 0;
            var totalStartUps = Module.TotalStartUps;
            var max_RunProtocolWidth = 100;
            foreach (var formtemplateid in List_FormTemplates)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                            SELECT Processcard_MinWidth, Processcard_ColWidth, Processcard_MaxWidth, RunProtocol_ColWidth 
                            FROM Protocol.FormTemplate
                            WHERE FormTemplateID = @formtemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["Processcard_ColWidth"].ToString(), out processcard_NomWidth);
                    int.TryParse(reader["Processcard_MinWidth"].ToString(), out processcard_MinWidth);
                    int.TryParse(reader["Processcard_MaxWidth"].ToString(), out processcard_MaxWidth);
                    int.TryParse(reader["RunProtocol_ColWidth"].ToString(), out runProtocol_ColWidth);
                }

                var space_Left = PrintVariables.MaxPaperWidth - PrintVariables.StartPointProcesscard - (processcard_MinWidth + processcard_NomWidth + processcard_MaxWidth);
                if (space_Left < max_Width)
                    max_Width = space_Left;

                if (runProtocol_ColWidth > max_RunProtocolWidth)
                    max_RunProtocolWidth = runProtocol_ColWidth;
            }
            //Dividerar totalt antal uppstarter med hur många uppstarter som får rum på aktiv sida
            var maxStartupsPerPage = max_Width / max_RunProtocolWidth;
            return (int)Math.Ceiling(totalStartUps / (double)maxStartupsPerPage);
        }
        public static int MaxStartUpPerPrintOut(List<int> List_FormTemplates)
        {
            var max_Width = PrintVariables.MaxWidthProcesscardRunProtocol;
            var processcard_MinWidth = 0;
            var processcard_NomWidth = 0;
            var processcard_MaxWidth = 0;
            var runProtocol_ColWidth = 0;
            var maxStartups = int.MaxValue;

            foreach (var formtemplateid in List_FormTemplates)
            {
                var isOkCalculate = false;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                            SELECT DISTINCT 
                                Processcard_MinWidth, 
                                Processcard_ColWidth, 
                                Processcard_MaxWidth,
                                RunProtocol_ColWidth, 
                                ColumnIndex
                            FROM Protocol.FormTemplate AS formtemplate
                            JOIN Protocol.Template AS template
                                ON formtemplate.FormTemplateID = template.FormTemplateID
                            WHERE formtemplate.FormTemplateID = @formtemplateid
                                AND (
                                    ColumnIndex IS NOT NULL 
                                    OR NOT EXISTS 
                                        (
                                            SELECT 1 
                                            FROM Protocol.Template 
                                            WHERE FormTemplateID = @formtemplateid 
                                            AND ColumnIndex IS NOT NULL
                                        )
                                    )";
                //--AND formtemplate.MaintemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                int columnCounter = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["Processcard_ColWidth"].ToString(), out processcard_NomWidth);
                    int.TryParse(reader["Processcard_MinWidth"].ToString(), out processcard_MinWidth);
                    int.TryParse(reader["Processcard_MaxWidth"].ToString(), out processcard_MaxWidth);

                    //if (int.TryParse(reader["Processcard_MinWidth"].ToString(), out processcard_MinWidth) == false)
                    //    processcard_MinWidth = processcard_NomWidth;

                    //if (int.TryParse(reader["Processcard_MaxWidth"].ToString(), out processcard_MaxWidth) == false)
                    //    processcard_MaxWidth = processcard_NomWidth;
                    int.TryParse(reader["RunProtocol_ColWidth"].ToString(), out runProtocol_ColWidth);
                    columnCounter++;
                    isOkCalculate = true;
                }

                if (isOkCalculate)
                {
                    var startups = (int)Math.Floor(((double)max_Width - (processcard_MinWidth + processcard_NomWidth + processcard_MaxWidth)) / runProtocol_ColWidth);
                    if (startups < maxStartups)
                        maxStartups = startups;
                }
            }
            return maxStartups;
        }


        public static async Task Print_Preview_Order(bool IsPrinting)
        {
            totalPrintOuts = new TotalPrintOuts();
            CommentIndex = 0;

            MaximizeAllWindows();
            InitializeGlobalPrintValues();
            Set_DefaultPaperSize(Print_MainProtocol, false);

            var MaxRowsRunProtocol = (MaxPaperHeight - 180 - LeftMargin) / RowHeight;
            var totalPrintOutsForModules = Math.Ceiling((double)TotalRows_Template / MaxRowsRunProtocol);

            totalPrintOuts.SetPagesExtraComments();
            totalPrintOuts.SetPagesProtocols(TotalRows_Template, MaxRowsRunProtocol);
            totalPrintOuts.PagesMainProtocol = 1;

            await PrintMainProtocolAsync(IsPrinting);
            await PrintCommentsAsync(IsPrinting);
            await PrintExtraCommentsAsync(IsPrinting);
            await PrintLineClearanceAsync(IsPrinting);
            await PrintRunProtocolsAsync(IsPrinting, totalPrintOutsForModules, MaxRowsRunProtocol);
            await PrintMeasureProtocolsAsync(IsPrinting);
            if (FrequencyMarking.IsLäcksökning)
                await PrintFrequencyMarking(IsPrinting);
            if (Protocol_Compund.IsCompound)
                await PrintCompoundProtocol(IsPrinting);
        }
        private static void MaximizeAllWindows()
        {
            ((Form)Preview_MainProtocol).WindowState = FormWindowState.Maximized;
            ((Form)Preview_ExtraComments).WindowState = FormWindowState.Maximized;
            ((Form)Preview_Comments).WindowState = FormWindowState.Maximized;
            ((Form)Preview_RunProtocol).WindowState = FormWindowState.Maximized;
            ((Form)Preview_LineClearance).WindowState = FormWindowState.Maximized;
            ((Form)Measureprotocol.Preview_MeasureProtocol).WindowState = FormWindowState.Maximized;
            ((Form)Measureprotocol.Preview_MeasureProtocol_Landscape).WindowState = FormWindowState.Maximized;
        }
        private static void InitializeGlobalPrintValues()
        {
            Measureprotocol.FirstRowMeasurment = 1;
            Measureprotocol.LastRowMeasurement = Measureprotocol.TotalRowsMeasureprotocolPrintOut;
            Active_PrintOut = 0;
            Y = 0;
            CommentIndex = 0;
            Print.utskrift_Korprotokoll = Print.List_PrintOut_Korprotokoll;
            Print.utskrift_Processkort = Print.List_PrintOut_Processkort;
            IsCommentsPrintedOut = false;
            ExtraCommentRow_From = 0;
            ExtraCommentRow_To = 0;
        }
        private static Task PrintMainProtocolAsync(bool isPrinting)
        {
            Set_DefaultPaperSize(Print_MainProtocol, false);

            if (isPrinting)
                Print_MainProtocol.Print();
            else
                Preview_MainProtocol.ShowDialog();
            return Task.CompletedTask;
        }
        private static Task PrintCommentsAsync(bool isPrinting)
        {
            if (IsCommentsPrintedOut) return Task.FromResult(Task.CompletedTask);

            var commentLines = Regex.Split(Print.utskrift_Korprotokoll?["Comments"] ?? string.Empty, @"\r\n|\r|\n");

            while (CommentIndex < commentLines.Length)
            {
                if (isPrinting)
                    Print_Comments.Print();
                else
                    Preview_Comments.ShowDialog();
            }

            return Task.FromResult(Task.CompletedTask);
        }
        private static Task PrintExtraCommentsAsync(bool isPrinting)
        {
            if (totalPrintOuts == null) return Task.CompletedTask;
            for (var i = 0; i < totalPrintOuts.PagesExtraComments; i++)
            {
                ExtraCommentRow_To += (MaxPaperHeight - 221) / RowHeight;
                PrintVariables.Y = 0;

                if (isPrinting)
                    Print_ExtraComments.Print();
                else
                    Preview_ExtraComments.ShowDialog();

                ExtraCommentRow_From = ExtraCommentRow_To + 1;
            }

            return Task.CompletedTask;
        }
        private static Task PrintLineClearanceAsync(bool isPrinting)
        {
            if ((Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID ?? 0) == 0)
                return Task.CompletedTask;

            CommentIndex = 0;

            if (isPrinting)
                Print_LineClearance.Print();
            else
                Preview_LineClearance.ShowDialog();

            return Task.CompletedTask;
        }
        private static async Task PrintRunProtocolsAsync(bool isPrinting, double totalPrintOutsForModules, int maxRowsRunProtocol)
        {

            for (var machineIndex = 1; machineIndex <= Korprotokoll.Total_Machines; machineIndex++)
            {
                MachineIndex = machineIndex;
                var list = List_FormTemplateID;
                var list_ctr = 0;

                for (var i = 0; i < totalPrintOutsForModules; i++)
                {
                    await Activity.Stop($"Skriver ut Körprotokoll - {i + 1} / {totalPrintOutsForModules}");
                    StartUp_From = 1;
                    StartUp_To = 0;
                    Active_FormTemplates = new List<int>();
                    var lastRowModule = 0;
                    var IsActiveFormTemplatesFull = false;

                    //Kontrollerar hur många moduler som får plats på aktuell sida
                    do
                    {
                        if (list_ctr == list.Count)
                            break;

                        var formtemplateid = list[list_ctr];
                        lastRowModule += TotalRows_FormTemplateID(formtemplateid);

                        if (lastRowModule > maxRowsRunProtocol)
                        {
                            IsActiveFormTemplatesFull = true;
                            continue;
                        }

                        list_ctr++;
                        Active_FormTemplates.Add(formtemplateid);

                    } while (!IsActiveFormTemplatesFull);

                    if (Active_FormTemplates.Count == 0)
                        break;

                    var totalPrintOutsForStartUps = TotalPrintOutsForStartUps(Active_FormTemplates);

                    for (var j = 0; j < totalPrintOutsForStartUps; j++)
                    {
                        StartUp_To += MaxStartUpPerPrintOut(Active_FormTemplates);
                        Active_PrintOut++;

                        if (isPrinting)
                            Print_RunProtocol.Print();
                        else
                            Preview_RunProtocol.ShowDialog();

                        StartUp_From = StartUp_To + 1;
                    }
                }
            }

            return;
        }
        private static async Task PrintMeasureProtocolsAsync(bool isPrinting)
        {
            try
            {
                var totalPrintOutsMeasureProtocol = Measureprotocol.TotalMeasureProtocols + 1;

                for (var ctr = 1; ctr < totalPrintOutsMeasureProtocol; ctr++)
                {
                    Activity.Start();

                    if (Measureprotocol.IsLandscape)
                    {
                        Set_DefaultPaperSize(Measureprotocol.Print_MeasureProtocol_Landscape, true);

                        if (isPrinting)
                            Measureprotocol.Print_MeasureProtocol_Landscape.Print();
                        else
                            Measureprotocol.Preview_MeasureProtocol_Landscape.ShowDialog();
                    }
                    else
                    {
                        Set_DefaultPaperSize(Measureprotocol.Print_MeasureProtocol, false);

                        if (isPrinting)
                            Measureprotocol.Print_MeasureProtocol.Print();
                        else
                            Measureprotocol.Preview_MeasureProtocol.ShowDialog();
                    }

                    Measureprotocol.FirstRowMeasurment = Measureprotocol.LastRowMeasurement + 1;
                    Measureprotocol.LastRowMeasurement += Measureprotocol.TotalRowsMeasureprotocolPrintOut;

                    await Activity.Stop($"Skriver ut Mätprotokoll - {ctr} / {totalPrintOutsMeasureProtocol - 1}");
                }
            }
            catch (Exception e)
            {
                _ = Activity.Stop($"Skriver ut Mätprotokoll\n e.Message {e.Message} e.StackTrace {e.StackTrace}");
            }
        }
        private static Task PrintFrequencyMarking(bool isPrinting)
        {
            Set_DefaultPaperSize(Print_FrequencyMarking, true);
            if (isPrinting)
                Print_FrequencyMarking.Print();
            else
                Preview_FrequencyMarking.ShowDialog();
            return Task.CompletedTask;
        }
        private static Task PrintCompoundProtocol(bool isPrinting)
        {
            Set_DefaultPaperSize(Print_Compund_Protocol, true);
            ((Form)Preview_Compound_Protocol).WindowState = FormWindowState.Maximized;
            if (isPrinting)
                Print_Compund_Protocol.Print();
            else
                Preview_Compound_Protocol.ShowDialog();
            return Task.CompletedTask;
        }


        private static void PrintPage_MainProtocol(object sender, PrintPageEventArgs e)
        {
            PrintVariables.PageWidth = e.PageBounds.Width;
            PrintVariables.PageHeight = e.PageBounds.Height;
            PrintVariables.Active_PrintOut++;

            Order_INFO(e);
            Measurepoints(e);
            PrintVariables.Y = 130;
            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Extrudering_FEP)
            {
                Extra_Info_FEP(e);
                PrintVariables.Y += 30;
            }

            Print.Rubrik(e, "Line Clearance", PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
            Line_Clearance(e);

            Print.ProcessCardBasedOn.PrintOut(PrintVariables.LeftMargin, e);

            if (PreFab.IsUsingPreFab)
            {
                PreFab(e);
                Y += 30;
            }

            var maxY = (int)PrintVariables.PageHeight - 60;
            var comments = Print.utskrift_Korprotokoll["Comments"];
            totalPrintOuts.SetPagesComments(e, comments, PrintVariables.LeftMargin, PrintVariables.Y, maxY);
            PageHeader(e, Templates_Protocol.MainTemplate.Name, totalPrintOuts.TotalPages);
            Comments(PrintVariables.LeftMargin, maxY, comments, e);

            Print.Copy(e);
            PageFooter(e);
        }
        private static void PrintPage_RunProtocol(object sender, PrintPageEventArgs e)
        {
            if (totalPrintOuts != null)
                PageHeader(e, Templates_Protocol.MainTemplate.Name, totalPrintOuts.TotalPages);
            Order_INFO(e);
            e.Graphics?.DrawString(LanguageManager.GetString("print_IsValueCritical"), CustomFonts.parametrarFont_Bold, CustomFonts.black, LeftMargin, 130);
            e.Graphics?.DrawString(LanguageManager.GetString("print_OutOfTolerance"), CustomFonts.parametrarFont_Bold, CustomFonts.black, LeftMargin, 141);
            PrintOut.LoadUsedColumns();
            PageWidth = e.PageBounds.Width;
            PageHeight = e.PageBounds.Height;
            var y = 153;

            var totalrows = 0;
            foreach (var formtemplateid in Active_FormTemplates)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        SELECT ModuleName, IsHeaderVisible, Processcard_MinWidth, Processcard_ColWidth, Processcard_MaxWidth, RunProtocol_ColWidth, IsMultipleColumnsStartup 
                        FROM Protocol.FormTemplate                           
                        WHERE FormTemplateID = @formtemplateid
                            AND MainTemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                var isHeaderVisible = false;
                while (reader.Read())
                {
                    bool.TryParse(reader["IsHeaderVisible"].ToString(), out isHeaderVisible);
                    bool.TryParse(reader["IsMultipleColumnsStartup"].ToString(), out var isModuleUsingOven);
                    var moduleName = reader["ModuleName"].ToString();
                    int.TryParse(reader["Processcard_ColWidth"].ToString(), out var processcard_NomWidth);

                    if (int.TryParse(reader["Processcard_MinWidth"].ToString(), out var processcard_MinWidth) == false)
                        processcard_MinWidth = processcard_NomWidth;
                    if (int.TryParse(reader["Processcard_MaxWidth"].ToString(), out var processcard_MaxWidth) == false)
                        processcard_MaxWidth = processcard_NomWidth;
                    int.TryParse(reader["RunProtocol_ColWidth"].ToString(), out var runProtocol_ColWidth);
                    PrintModule(e, formtemplateid, y, moduleName, processcard_MinWidth, processcard_NomWidth, processcard_MaxWidth, runProtocol_ColWidth, ref totalrows, isHeaderVisible, isModuleUsingOven);
                }

                y += totalrows * RowHeight;
                if (isHeaderVisible)
                    y += RowHeight;
            }

            Print.Copy(e);
        }

        private static void Print_Page_Comments(object sender, PrintPageEventArgs e)
        {
            Active_PrintOut++;
            PageHeader(e, Templates_Protocol.MainTemplate.Name, totalPrintOuts.TotalPages);
            Order_INFO(e);

            PrintVariables.Y = 150;
            Comments(LeftMargin, (int)PageHeight - 130, Print.utskrift_Korprotokoll["Comments"], e);
        }
        private static void Print_Page_ExtraComments(object sender, PrintPageEventArgs e)
        {
            Active_PrintOut++;
            PageHeader(e, Templates_Protocol.MainTemplate.Name, totalPrintOuts.TotalPages);
            Order_INFO(e);

            PrintVariables.Y = 150;
            Extra_Comments(e);
        }
        private static void Print_Compound_Protocol_PrintPage(object sender, PrintPageEventArgs e)
        {
            PageHeader(e, "Blankett: Kompounderingsregistrering PUR-kompound", totalPrintOuts.TotalPages);
            Print.Compound_Protocol.Print_OrderInfo(e);
            Print.Compound_Protocol.Print_Samples(e);
            Print.Compound_Protocol.Print_Sidfot(e);
        }
        private static void Frekvensmarkering_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintVariables.Active_PrintOut++;
            PageHeader(e, "Blankett: Frekvensmarkering av hål i slang", totalPrintOuts.TotalPages);

            Print.FrequencyMarking.Order_Info(e);
            Print.FrequencyMarking.Rubriker(e);
            Print.FrequencyMarking.YtterRutor(e);
            Print.FrequencyMarking.InreRutor(e);
            Print.FrequencyMarking.Operatör_Text(e);
            Print.FrequencyMarking.Sidfot(e);
            Print.Copy_Landscape(e);
        }
        private static void ExtraLineClearance_Print_Page(object sender, PrintPageEventArgs e)
        {
            PrintVariables.Active_PrintOut += 1;
            PageHeader(e, $"Extra LineClearance: {Templates_Protocol.MainTemplate.Name}", totalPrintOuts.TotalPages);
            Order_INFO(e);
            Print.ExtraLineClearance.Info(e, 160);
            var y = 200;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT FormTemplateID, Category FROM LineClearance.FormTemplate WHERE MainTemplateID = @maintemplateid ORDER BY TemplateOrder";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.TryParse(reader["FormTemplateID"].ToString(), out var formtemplateID))
                    {
                        LineClearance_Extra.Fill_Tasks(formtemplateID, out var tasks);
                        Print.ExtraLineClearance.Add_Task(e, ref y, reader["Category"].ToString(), tasks);
                        y += 30;
                    }

                }
            }
            Print.Thin_Rectangle(e, PrintVariables.LeftMargin, 190, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, y - 190);
            Print.ExtraLineClearance.Text_DoneByAndApprovedBy(e, y + 10);
            PrintVariables.Y = y + 60;
            Print.ExtraLineClearance.Kommentarer(e);
        }


        internal class PrintOut
        {
            public static Dictionary<(int row, int formtemplateid), List<int>> UsedColumns { get; } = new();
            public static void LoadUsedColumns()
            {
                UsedColumns.Clear();

                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                SELECT template.FormTemplateID, template.RowIndex, template.ColumnIndex
                FROM Protocol.Template AS template
                JOIN Protocol.Description AS descr ON descr.ID = template.ProtocolDescriptionID
                WHERE template.FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid) AND template.RowIndex IS NOT NULL";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);

                con.Open(); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var formId = Convert.ToInt32(reader["FormTemplateID"]);
                    var row = Convert.ToInt32(reader["RowIndex"]);
                    if (reader["ColumnIndex"] is DBNull)
                        continue;

                    var col = Convert.ToInt32(reader["ColumnIndex"]);

                    var key = (row, formId);
                    if (!UsedColumns.TryGetValue(key, out var list))
                    {
                        list = new List<int>();
                        UsedColumns[key] = list;
                    }

                    list.Add(col);
                }
            }

            private static bool IsModuleOnlyNomValues(int formtemplateid)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"SELECT * FROM Protocol.Template WHERE FormTemplateID = @formtemplateid AND (ColumnIndex = 0 OR ColumnIndex = 2)";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return false;

                return true;
            }
            private static bool IsTemplateMissingProcesscard
            {
                get
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        const string query =
                            @"SELECT * FROM Protocol.Template WHERE FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid) AND (ColumnIndex IN (0,1,2))";
                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            return false;
                    }
                    return true;
                }
            }

            public static double TotalRowsExtraComments
            {
                get
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = $"SELECT COUNT(Row) FROM [Order].ExtraComments WHERE OrderID = @orderid";
                        con.Open();
                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        var value = cmd.ExecuteScalar();
                        if (int.TryParse(value.ToString(), out var totalRows))
                            return totalRows;
                    }
                    return 0;
                }
            }

            public static void PageHeader(PrintPageEventArgs e, string? templateName, int totalPages)
            {
                var vers = Order.VersionNr_ActiveOrder;
                Image img = Properties.Resources.NewLogo_BW;
                e.Graphics.DrawImage(img, LeftMargin, 12);
                Print.TemplateHeader(e, $"{LanguageManager.GetString("template")}: {templateName}");

                e.Graphics.DrawString(LanguageManager.GetString("form"), CustomFonts.A12_BI, CustomFonts.black, MaxPaperWidth - 304, LeftMargin + 12);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, MaxPaperWidth - 309, LeftMargin + 6, 309, 23);

                e.Graphics.DrawString("DPP-Version: " + vers, CustomFonts.A8, CustomFonts.black, PrintVariables.MaxPaperWidth - 448, 55);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, MaxPaperWidth - 456, 53, 147, 17);

                e.Graphics.DrawString(LanguageManager.GetString("date") + Program.RelaseDate(vers), CustomFonts.A8, CustomFonts.black, MaxPaperWidth - 304, 55);

                e.Graphics.DrawString($"{LanguageManager.GetString("preparedBy")} RA", CustomFonts.A8, CustomFonts.black, MaxPaperWidth - 135, 55);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, MaxPaperWidth - 139, 53, 139, 17);

                Print.Text_PageNumber(e, $"{LanguageManager.GetString("page")} {Active_PrintOut}/{totalPages}", MaxPaperWidth, 74);
            }
            public static void PageFooter(PrintPageEventArgs e)
            {
                const int x = 100;
                var y = PrintVariables.MaxPaperHeight - 30;
                var text = LanguageManager.GetString("finishedOrder");

                e.Graphics.DrawString(text, CustomFonts.A11_B, CustomFonts.black, x - 10, y);//1110
                var width_Text = Print.StringWidth(text, CustomFonts.A11_B, e.Graphics);
                var formattedDate = string.Empty;
                if (!string.IsNullOrEmpty(Order.OrderNumber))
                {
                    var date = DateTime.Now;
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
                    e.Graphics.DrawString(formattedDate, CustomFonts.operatörFont, CustomFonts.black, x + width_Text, y + 3);//1113
                }

                var width_Date = Print.StringWidth(formattedDate, CustomFonts.operatörFont, e.Graphics) + 10;

                e.Graphics.DrawRectangle(CustomFonts.thinBlack, width_Text + x, y - 2, width_Date, 20);//1108
                var width_Name = PrintVariables.MaxPaperWidth - (width_Text + x + width_Date);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, width_Text + x + width_Date, y - 2, width_Name, 20);//1108
            }
            public static void PageFooter_Landscape(PrintPageEventArgs e)
            {
                e.Graphics.DrawString("Avslutat Order: Datum / sign", CustomFonts.A11_B, CustomFonts.black, 630, 750);
                if (!string.IsNullOrEmpty(Order.OrderNumber))
                    e.Graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), CustomFonts.operatörFont, CustomFonts.black, 855, 752);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 851, 748, 79, 20);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 930, 748, 159, 20);
            }



            public static void Order_INFO(PrintPageEventArgs e)
            {
                e.Graphics.DrawLine(CustomFonts.thinBlack, LeftMargin, 110, MaxPaperWidth, 110);

                Print.Static_InfoText(e, LanguageManager.GetString("label_Customer"), LeftMargin, 95);
                Print.Protocol_InfoText(e, Order.Customer, false, 88, 95, 280, false, true);

                Print.Static_InfoText(e, LanguageManager.GetString("label_ProdType"), 360, 95);
                Print.Protocol_InfoText(e, Order.ProdType, false, 440, 95, 150, false, true);

                Print.Static_InfoText(e, LanguageManager.GetString("label_Description"), LeftMargin, 115);
                Print.Protocol_InfoText(e, Order.Description, false, 100, 115, 235, false, true);

                Print.Static_InfoText(e, "OrderNr-Operation:", MaxPaperWidth - 70, 95, true);
                Print.Protocol_InfoText(e, $"{Order.OrderNumber}-{Order.Operation}", false, MaxPaperWidth, 95, 100, false, true, true);

                Print.Static_InfoText(e, LanguageManager.GetString("label_PartNumber"), MaxPaperWidth - 70, 115, true);
                Print.Protocol_InfoText(e, $"{Order.PartNumber}", false, MaxPaperWidth, 115, 100, false, true, true);

                e.Graphics.DrawLine(CustomFonts.thinBlack, LeftMargin, 130, MaxPaperWidth, 130);
            }

            public static void Measurepoints(PrintPageEventArgs e)
            {
                var ctr = 0;
                int[] x_codetext = { 335, 405, 470, 550 };
                int[] x_Value = { 353, 428, 508, 603 };
                string[] codetext = { "ID", "OD", "WALL", "LENGTH" };
                foreach (var text in codetext)
                {
                    // Fix for CS8602: Dereference of a possibly null reference.
                    e.Graphics?.DrawString("Co-extrudering", CustomFonts.A8, CustomFonts.black, 50, 138);
                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query = @"
                        SELECT Value FROM [Order].Data
                        WHERE OrderID = @id
                        AND ProtocolDescriptionID = 
	                        (SELECT ID FROM Protocol.Description WHERE CodeText = @codetext)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@codetext", text);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var value = reader["value"].ToString();
                        e.Graphics?.DrawString(text, CustomFonts.A8_BI, CustomFonts.black, x_codetext[ctr], 115);
                        Print.Protocol_InfoText(e, value, false, x_Value[ctr], 115, 100, false, false);
                        ctr++;
                    }
                }
            }
            public static void Extra_Info_FEP(PrintPageEventArgs e)
            {
                Print.Thin_Rectangle(e, 30, 137, 15, 15);
                e.Graphics?.DrawString("Co-extrudering", CustomFonts.A8, CustomFonts.black, 50, 138);

                e.Graphics?.DrawLine(CustomFonts.thinBlack, 138, 130, 138, 160);
                e.Graphics?.DrawString("Antal Stripes:", CustomFonts.A8, CustomFonts.black, 144, 138);

                e.Graphics?.DrawLine(CustomFonts.thinBlack, 274, 130, 274, 160);
                Print.Thin_Rectangle(e, 280, 137, 15, 15);
                e.Graphics?.DrawString("Singel extrudering", CustomFonts.A8, CustomFonts.black, 300, 138);


                e.Graphics?.DrawLine(CustomFonts.thinBlack, 430, 130, 430, 160);
                Print.Thin_Rectangle(e, 435, 137, 15, 15);
                e.Graphics?.DrawString("Clear", CustomFonts.A8, CustomFonts.black, 455, 138);


                e.Graphics?.DrawLine(CustomFonts.thinBlack, 530, 130, 530, 160);
                Print.Thin_Rectangle(e, 535, 137, 15, 15);
                e.Graphics?.DrawString("Röntgen", CustomFonts.A8, CustomFonts.black, 555, 138);

                int[] ProtocolDescriptionID = { 251, 250, 247, 248, 252 };
                int[] x = { 31, 218, 281, 436, 536 };

                for (var i = 0; i < ProtocolDescriptionID.Length; i++)
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = "SELECT BoolValue, Value FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", ProtocolDescriptionID[i]);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (string.IsNullOrEmpty(reader[1].ToString()))
                        {
                            if (!bool.TryParse(reader[0].ToString(), out var IsChecked))
                                continue;
                            if (IsChecked)
                                e.Graphics.DrawString("\u2714", CustomFonts.operatörFont, CustomFonts.parametrar_clr, x[i], 139);
                        }
                        else
                        {
                            Print.Text_Operatör(e, reader[1].ToString(), x[i], 136, 500);
                            e.Graphics?.DrawString("st", CustomFonts.A8, CustomFonts.black, 235, 141);
                        }
                    }
                }

                e.Graphics?.DrawLine(CustomFonts.thinBlack, 605, 130, 605, 160);
            }


            public static void Line_Clearance(PrintPageEventArgs e)
            {
                string? LineClearanceTemplate;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT LineClearance_Template FROM Protocol.MainTemplate WHERE ID = @maintemplateid";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    LineClearanceTemplate = value == DBNull.Value ? null : (string)value;
                }

                if ((Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID ?? 0) != 0)
                    return;


                switch (LineClearanceTemplate)
                {
                    case "A":
                        Print.LineClearance.LineClearance_A(e);
                        PrintVariables.Y += 80;
                        break;
                    case "B"://HS
                        Print.LineClearance.LineClearance_B(e);
                        Y += 85;
                        break;
                }

            }

            public static void PreFab(PrintPageEventArgs e)
            {
                Print.Rubrik(e, LanguageManager.GetString("btn_PreFab"), LeftMargin, Y, MaxPaperWidth - LeftMargin);
                Y += 24;

                var dt_Halvfabrikat = Protocols.ExtraProtocols.PreFab.DataTable_PreFab(Order.OrderID, true);
                var antal_Halvfabrikat = dt_Halvfabrikat.Rows.Count;

                var partNrMaterialKey = LanguageManager.GetString("partNrMaterial") ?? "partNrMaterial";
                var partNumberKey = LanguageManager.GetString("label_PartNumber") ?? "label_PartNumber";

                var columns = new Dictionary<string, (int Width, string DataKey)>
                {
                    { partNrMaterialKey, (87, partNumberKey) },
                    { "Material", (321, LanguageManager.GetString("label_Description") ?? "label_Description") },
                    { "Extruder", (160, "Extruder:") },
                    { "Batch Nr", (110, "BatchNr:") },
                    { LanguageManager.GetString("preFab_BestBefore") ?? "preFab_BestBefore", (100, LanguageManager.GetString("preFab_BestBefore") ?? "preFab_BestBefore") }
                };


                // Draw headers
                var currentX = LeftMargin;
                foreach (var entry in columns)
                {
                    e.Graphics?.DrawRectangle(CustomFonts.thinBlack, currentX, Y - 2, entry.Value.Width, 18);
                    e.Graphics?.DrawString(entry.Key, CustomFonts.A9_I, CustomFonts.black, currentX + 2, Y);
                    currentX += entry.Value.Width;
                }

                Y += 20; // Move down after headers

                for (var i = 0; i < antal_Halvfabrikat; i++)
                {
                    currentX = LeftMargin; // Reset X for each row

                    foreach (var entry in columns)
                    {
                        e.Graphics?.DrawRectangle(CustomFonts.thinBlack, currentX, Y, entry.Value.Width, 18);
                        string? text;
                        var value = dt_Halvfabrikat?.Rows[i][entry.Value.DataKey];
                        if (value is DateTime dateValue)
                            text = dateValue.ToShortDateString();
                        else
                            text = dt_Halvfabrikat?.Rows[i][entry.Value.DataKey].ToString();

                        Print.Text_Operatör(e, text, currentX + 2, Y + 4, entry.Value.Width - 4);
                        currentX += entry.Value.Width; // Move X to the next column
                    }

                    Y += 18; // Move down for the next row
                }
            }
            public static void Comments(int x, int maxY, string? comments, PrintPageEventArgs e)
            {
                float pageWidth = e.PageBounds.Width - 2 * x;
                Print.Rubrik(e, LanguageManager.GetString("label_Comments"), x, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
                var startY = PrintVariables.Y;

                PrintVariables.Y += 40;

                const float padding = 10;
                var commentLines = Regex.Split(comments, @"\r\n|\r|\n"); //comments.Split(new[] { Environment.NewLine }, StringSplitOptions.None);


                while (CommentIndex < commentLines.Length)
                {
                    var text = commentLines[PrintVariables.CommentIndex].Replace("\t", "    "); // Replace tab with four spaces
                    var textSize = e.Graphics.MeasureString(text, CustomFonts.operatörFont, (int)pageWidth - PrintVariables.LeftMargin);

                    var rect = new RectangleF(x + 4, PrintVariables.Y - 10, pageWidth - PrintVariables.LeftMargin, textSize.Height + 2 * padding);

                    var stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near,
                        FormatFlags = StringFormatFlags.LineLimit
                    };

                    PrintVariables.Y += (int)textSize.Height + 4;
                    if (PrintVariables.Y > maxY)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, PrintVariables.LeftMargin, startY, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, PrintVariables.Y - startY);
                        return;
                    }

                    e.Graphics.DrawString(text, CustomFonts.operatörFont, CustomFonts.operatör_clr, rect, stringFormat);

                    if (PrintVariables.Y > maxY)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, PrintVariables.LeftMargin, startY, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, PrintVariables.Y - startY);
                        PrintVariables.CommentIndex++;

                        return;
                    }
                    PrintVariables.CommentIndex++;
                }
                PrintVariables.IsCommentsPrintedOut = true;
                e.Graphics.DrawRectangle(Pens.Black, PrintVariables.LeftMargin, startY, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin, PrintVariables.Y - startY);

            }
            public static void Extra_Comments(PrintPageEventArgs e)
            {
                PrintVariables.Y += 20;
                Print.Rubrik(e, LanguageManager.GetString("extraComments"), PrintVariables.LeftMargin, PrintVariables.Y, PrintVariables.MaxPaperWidth - PrintVariables.LeftMargin);
                PrintVariables.Y += 22;
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, PrintVariables.LeftMargin, PrintVariables.Y, 50, 35);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 74, PrintVariables.Y, 525, 35);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 599, PrintVariables.Y, 85, 35);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 684, PrintVariables.Y, 45, 35);
                e.Graphics.DrawRectangle(CustomFonts.thinBlack, 729, PrintVariables.Y, 50, 35);
                e.Graphics.DrawString($"{LanguageManager.GetString("spool_1")} /", CustomFonts.A8, CustomFonts.black, 30, PrintVariables.Y + 5);
                e.Graphics.DrawString(LanguageManager.GetString("spool_2"), CustomFonts.A8, CustomFonts.black, 36, PrintVariables.Y + 18);
                e.Graphics.DrawString(LanguageManager.GetString("comments"), CustomFonts.A8, CustomFonts.black, 78, PrintVariables.Y + 12);
                e.Graphics.DrawString(LanguageManager.GetString("date"), CustomFonts.A8, CustomFonts.black, 621, PrintVariables.Y + 12);
                e.Graphics.DrawString("Sign:", CustomFonts.A8, CustomFonts.black, 691, PrintVariables.Y + 12);
                e.Graphics.DrawString(LanguageManager.GetString("label_EmpNr"), CustomFonts.A8, CustomFonts.black, 733, PrintVariables.Y + 12);

                PrintVariables.Y += 35;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT * FROM [Order].ExtraComments WHERE OrderID = @orderid AND Row BETWEEN @rowfrom AND @rowto ORDER BY Row";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@rowfrom", PrintVariables.ExtraCommentRow_From);
                    cmd.Parameters.AddWithValue("@rowto", PrintVariables.ExtraCommentRow_To);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Print.Thin_Rectangle(e, PrintVariables.LeftMargin, PrintVariables.Y, 50, PrintVariables.RowHeight);
                        Print.Thin_Rectangle(e, 74, PrintVariables.Y, 525, PrintVariables.RowHeight);
                        Print.Thin_Rectangle(e, 599, PrintVariables.Y, 85, PrintVariables.RowHeight);
                        Print.Thin_Rectangle(e, 684, PrintVariables.Y, 45, PrintVariables.RowHeight);
                        Print.Thin_Rectangle(e, 729, PrintVariables.Y, 50, PrintVariables.RowHeight);
                        Print.Text_Operatör(e, reader["Spole"].ToString(), 53, PrintVariables.Y + 4, 50, true);
                        Print.Text_Operatör(e, reader["Kommentar"].ToString(), 78, PrintVariables.Y + 4, 523);
                        if (DateTime.TryParse(reader["Datum"].ToString(), out var date))
                        {
                            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                            var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                            Print.Text_Operatör(e, date.Year > 1900 ? formattedDate : date.ToString("HH:mm"), 641, PrintVariables.Y + 4, 90, true);
                        }

                        var anstNr = reader["AnstNr"].ToString();
                        if (!string.IsNullOrEmpty(anstNr))
                            Print.Text_Operatör(e, Person.Get_SignWithName(Person.Get_NameWithAnstNr(anstNr)), 706, PrintVariables.Y + 4, 50, true);
                        else
                            Print.Text_NA(e, 706, PrintVariables.Y + 4, true);
                        Print.Text_Operatör(e, reader["AnstNr"].ToString(), 754, PrintVariables.Y + 4, 50, true);
                        PrintVariables.Y += PrintVariables.RowHeight;
                    }
                }
                if (TotalRowsExtraComments > PrintVariables.ExtraCommentRow_To)
                    PrintVariables.ExtraCommentRow_From = PrintVariables.ExtraCommentRow_To + 1;
            }

            public static void PrintModule(PrintPageEventArgs e, int formtemplateid, int y, string moduleName, int processcard_MinWidth, int processcard_NomWidth, int processcard_MaxWidth, int runProtocol_ColWidth, ref int totalrows, bool isHeaderVisible, bool isModuleUsingOven)
            {
                var isModuleOnlyNomValues = IsModuleOnlyNomValues(formtemplateid);

                Protocol_Template(e, y, moduleName, formtemplateid, processcard_MinWidth, processcard_NomWidth, processcard_MaxWidth, ref totalrows, isHeaderVisible);
                Processcard_Parameters(e, y, formtemplateid, PrintVariables.MachineIndex, isHeaderVisible);
                int x;
                if (isModuleOnlyNomValues)
                    x = 196 + 46 + processcard_NomWidth;
                else
                    x = 196 + 46 + (processcard_MinWidth + processcard_NomWidth + processcard_MaxWidth);


                Print.RunProtocol.StartUps(e, x, y, totalrows, runProtocol_ColWidth, formtemplateid, StartUp_From, StartUp_To, MachineIndex, isHeaderVisible, isModuleUsingOven);
            }
            public static void PrintHeader(PrintPageEventArgs e, int y, int formtemplateid, int[] colWidth)
            {
                Print.Filled_Rectangle(e, CustomFonts.empty_Space, PrintVariables.LeftMargin, y, 172, PrintVariables.RowHeight);
                Print.Thin_Rectangle(e, 196, y, 46, PrintVariables.RowHeight);

                e.Graphics.DrawString(LanguageManager.GetString("unit"), CustomFonts.A8_BI, CustomFonts.black, 199, y + 2);
                if (IsTemplateMissingProcesscard)
                    return;
                if (IsModuleOnlyNomValues(formtemplateid))
                {
                    Print.Filled_Rectangle(e, CustomFonts.nom, PrintVariables.StartPointProcesscard, y, colWidth[1], PrintVariables.RowHeight);
                    e.Graphics.DrawString("NOM", CustomFonts.A7_B, CustomFonts.black, PrintVariables.StartPointProcesscard + colWidth[1] / 2 - Print.StringWidth("NOM", CustomFonts.A7_B, e.Graphics) / 2, y + 4);
                }
                else
                {
                    string?[] array = new[] { "MIN", "NOM", "MAX" };
                    var x = PrintVariables.StartPointProcesscard;
                    Brush[] brushes = { CustomFonts.min_max, CustomFonts.nom, CustomFonts.min_max };
                    for (var i = 0; i < 3; i++)
                    {
                        Print.Filled_Rectangle(e, brushes[i], x, y, colWidth[i], PrintVariables.RowHeight);
                        e.Graphics.DrawString(array[i], CustomFonts.A7_B, CustomFonts.black, x + colWidth[i] / 2 - Print.StringWidth(array[i], CustomFonts.A7_B, e.Graphics) / 2, y + 4);
                        x += colWidth[i];
                    }
                }
            }
            public static void Protocol_Template(PrintPageEventArgs e, int y, string leftHeader, int formtemplateid, int minWidth, int nomWidth, int maxWidth, ref int totalrows, bool isHeaderVisible)
            {
                totalrows = 0;
                if (isHeaderVisible)
                {
                    PrintHeader(e, y, formtemplateid, new int[] { minWidth, nomWidth, maxWidth });
                    y += RowHeight;
                }

                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                SELECT DISTINCT 
                    descr.CodeText, 
                    unit.UnitName AS Unit, 
                    template.RowIndex, 
                    template.ColumnIndex, 
                    template.IsValueCritical
                FROM Protocol.Template AS template
                JOIN Protocol.Description AS descr
                    ON descr.ID = template.ProtocolDescriptionID
                LEFT JOIN Protocol.Unit AS unit
                    ON descr.UnitID = unit.ID
                JOIN Protocol.FormTemplate AS formtemplate
                    ON template.FormTemplateID = formtemplate.FormTemplateID
                WHERE template.FormTemplateID = @formtemplateid
                    AND template.RowIndex IS NOT NULL
                ORDER BY template.RowIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var isModuleOnlyNomValues = IsModuleOnlyNomValues(formtemplateid);
                while (reader.Read())
                {
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    var codetext = reader["CodeText"].ToString();
                    var unit = reader["Unit"].ToString();
                    bool.TryParse(reader["IsValueCritical"].ToString(), out bool isValueCritical);

                    var x = StartPointProcesscard;

                    if (int.TryParse(reader["ColumnIndex"].ToString(), out var col) == false)
                    {
                        Print.Protocol_InfoText(e, codetext, isValueCritical, 44, y + RowHeight * row + 3, 154, false, true);             //Skriver ut CodeText
                        if (isModuleOnlyNomValues)
                            Print.Filled_Rectangle(e, CustomFonts.empty_Space, x, y + RowHeight * row, nomWidth, RowHeight);
                        else
                            Print.Filled_Rectangle(e, CustomFonts.empty_Space, x, y + RowHeight * row, minWidth + nomWidth + maxWidth, RowHeight);

                        Print.Print_Unit(e, unit, 196, y + RowHeight * row, RowHeight, 46);
                        Print.Thin_Rectangle(e, 42, y + RowHeight * row, 154, RowHeight);
                        totalrows++;
                        continue;
                    }

                    switch (col)
                    {
                        case 0:
                            Print.Filled_Rectangle(e, CustomFonts.min_max, x, y + RowHeight * row, maxWidth, RowHeight);
                            break;
                        case 1:
                            if (isModuleOnlyNomValues)
                                Print.Filled_Rectangle(e, CustomFonts.nom, x, y + RowHeight * row, nomWidth, RowHeight);                         //NOM bakgrund Går över MIN/NOM/MAX
                            else
                                Print.Filled_Rectangle(e, CustomFonts.nom, x + minWidth, y + RowHeight * row, nomWidth, RowHeight);      //NOM bakgrund: Går över NOM
                            Print.Thin_Rectangle(e, 42, y + RowHeight * row, 154, RowHeight);                                            //Rutor runt CodeText
                            Print.Protocol_InfoText(e, codetext, isValueCritical, 44, y + RowHeight * row + 3, 154, false, true);         //Skriver ut CodeText
                            Print.Print_Unit(e, unit, 196, y + RowHeight * row, RowHeight, 46);
                            totalrows++;
                            break;

                        case 2:
                            Print.Filled_Rectangle(e, CustomFonts.min_max, x + minWidth + nomWidth, y + RowHeight * row, maxWidth, RowHeight);
                            break;
                    }

                    if (isModuleOnlyNomValues == false)
                    {//Gör oanvända rutor "svarta"
                        if (UsedColumns.TryGetValue((row, formtemplateid), out var usedCols))
                        {
                            for (var column = 2; column < 5; column++)
                            {
                                if (usedCols.Contains(column - 2))
                                    continue;
                                switch (column)
                                {
                                    case 2:
                                        Print.Filled_Rectangle(e, CustomFonts.empty_Space, x, y + RowHeight * row, minWidth, RowHeight);
                                        break;
                                    case 3:
                                        Print.Filled_Rectangle(e, CustomFonts.empty_Space, x + minWidth, y + RowHeight * row, nomWidth, RowHeight);
                                        break;
                                    case 4:
                                        Print.Filled_Rectangle(e, CustomFonts.empty_Space, x + minWidth + nomWidth, y + RowHeight * row, maxWidth, RowHeight);
                                        break;
                                }
                            }
                        }
                    }

                }
                Print.Processcard.LEFT_Header(e, new[] { leftHeader }, totalrows * RowHeight, y);
            }
            public static void Processcard_Parameters(PrintPageEventArgs e, int y, int formtemplateid, int machineindex, bool isHeaderVisible)
            {
                var isModuleOnlyNomValues = IsModuleOnlyNomValues(formtemplateid);
                if (isHeaderVisible)
                    y += PrintVariables.RowHeight;
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                var query = @"
                            SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals, Processcard_MinWidth, Processcard_ColWidth, Processcard_MaxWidth
                            FROM Protocol.Template AS template
	                            JOIN Processcard.Data AS pc_values
		                            ON pc_values.TemplateID = template.Id
	                            JOIN Protocol.Description AS descr
		                            ON descr.Id = template.ProtocolDescriptionID
                                JOIN Protocol.FormTemplate as formtemplate
		                            ON template.FormTemplateID = formtemplate.FormTemplateID
                            WHERE pc_values.PartID = @partID
                                AND template.FormTemplateID = @formtemplateid
                                AND (COALESCE(pc_values.MachineIndex, 0) = COALESCE(@machineindex, 0))
                                AND formtemplate.MainTemplateID = @maintemplateid
                            ORDER BY RowIndex, ColumnIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@machineindex", machineindex);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int? column = null;
                    int x = StartPointProcesscard;
                    var value = string.Empty;
                    int.TryParse(reader["Type"].ToString(), out var type);
                    if (int.TryParse(reader["ColumnIndex"].ToString(), out var col))
                        column = col;
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    int.TryParse(reader["Processcard_ColWidth"].ToString(), out var nomWidth);
                    if (int.TryParse(reader["Processcard_MinWidth"].ToString(), out var minWidth) == false)
                        minWidth = nomWidth;
                    if (int.TryParse(reader["Processcard_MaxWidth"].ToString(), out var maxWidth) == false)
                        maxWidth = nomWidth;
                    switch (type)
                    {
                        case 0:
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            value = double.TryParse(reader["Value"].ToString(), out var NumberValue) == false ? string.Empty : Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1:
                            value = reader["TextValue"].ToString();
                            break;
                    }

                    if (column is null)
                        continue;
                    if (isModuleOnlyNomValues)
                        Print.Protocol_InfoText(e, value, false, x + nomWidth * (int)column / 2, y + PrintVariables.RowHeight * row + 2, nomWidth, true, true);
                    else
                    {
                        var textPosition = 0;
                        var colWidth = 0;
                        switch (column)
                        {
                            case 0:
                                textPosition = x + minWidth / 2;
                                colWidth = minWidth;
                                break;
                            case 1:
                                textPosition = x + minWidth + nomWidth / 2;
                                colWidth = nomWidth;
                                break;
                            case 2:
                                textPosition = x + minWidth + nomWidth + maxWidth / 2;
                                colWidth = maxWidth;
                                break;
                        }

                        Print.Protocol_InfoText(e, value, false, textPosition, y + PrintVariables.RowHeight * row + 2, colWidth, true, true);
                    }
                }
            }
        }
    }
}

