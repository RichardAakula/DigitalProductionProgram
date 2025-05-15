using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using OfficeOpenXml;
using Module = DigitalProductionProgram.Protocols.Protocol.Module;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;

namespace DigitalProductionProgram.Browse_Protocols
{
    internal class Export_Data_Excel
    {
        
        public static List<string> orderlist;

        [Obsolete]
        public static void StartExport(DataGridView dgv)
        {
            StartExport_Extrudering_FEP(dgv);

        }

       

[Obsolete("Obsolete")]
private static void StartExport_Extrudering_FEP(DataGridView dgv)
    {
        var orgOrderID = Order.OrderID;
        var pbar = new ProgressBar();
        pbar.Show();
        var step = 100 / (double)dgv.Rows.Count;
        double percent = 0;

        // Välj var du vill spara filen
        var savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Export.xlsx");

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var sheet_Tools = package.Workbook.Worksheets.Add("Verktyg");
            var sheet_Extruder_1 = package.Workbook.Worksheets.Add("Extruder 1");
            var sheet_Extruder_2 = package.Workbook.Worksheets.Add("Extruder 2");
            var sheet_Formning = package.Workbook.Worksheets.Add("Formning");
            var sheet_Prod = package.Workbook.Worksheets.Add("Prod");

            var excelRow = 2;
            for (var row = 0; row < dgv.Rows.Count; row++)
            {
                pbar.Set_ValueProgressBar(percent, "Överför Verktyg till Excel ");
                percent += step;

                Order.OrderID = int.Parse(dgv.Rows[row].Cells["orderlist_OrderID"].Value.ToString());
                var totalUppstarter = Module.TotalStartUps;

                for (var uppstart = 1; uppstart <= totalUppstarter; uppstart++)
                {
                    Export_Sheet_Tools(sheet_Tools, excelRow, row, uppstart, dgv);
                    Export_Sheet_Extruder(sheet_Extruder_1, excelRow, row, uppstart, 0, dgv);
                    Export_Sheet_Extruder(sheet_Extruder_2, excelRow, row, uppstart, 2, dgv);
                    Export_Sheet_Formning(sheet_Formning, excelRow, row, uppstart, dgv);
                    Export_Sheet_Prod(sheet_Prod, excelRow, row, uppstart, dgv);
                    excelRow++;
                }
            }

            // Spara filen
            package.SaveAs(new FileInfo(savePath));
        }

        pbar.Close();
        MessageBox.Show("Export klar. Fil sparad på skrivbordet.");
        Order.OrderID = orgOrderID;
    }

   

        



        private static void Export_Sheet_Tools(ExcelWorksheet sheet, int excelRow, int row, int uppstart, DataGridView dgv_Orderlist)
    {
        using var con = new SqlConnection(Database.cs_Protocol);
        var query = @"
        SELECT DISTINCT Value, TextValue, DateValue, MachineIndex, Uppstart, RowIndex, template.Decimals, template.Type
        FROM [Order].Data AS protocol
            JOIN Protocol.Template as template
                ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
            JOIN Protocol.Description as descr
                ON descr.id = template.ProtocolDescriptionID
        WHERE OrderID = @orderid
            AND FormTemplateID = @formtemplateid
            AND template.revision = @revision
            AND RowIndex IS NOT NULL
            AND Uppstart = @uppstart
        ORDER BY MachineIndex, RowIndex";
        con.Open();
        var cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
        cmd.Parameters.AddWithValue("@uppstart", uppstart);
        cmd.Parameters.AddWithValue("@formtemplateid", 1);
        cmd.Parameters.AddWithValue("@revision", Korprotokoll.ProtocolTemplateRevision.OrderNr(Order.OrderID));

        var reader = cmd.ExecuteReader();
        var col = 5;
        while (reader.Read())
        {
            int.TryParse(reader["type"].ToString(), out var type);

            var value = string.Empty;
            switch (type)
            {
                case 0: // NumberValue
                    int.TryParse(reader["Decimals"].ToString(), out var decimals);
                    if (double.TryParse(reader["Value"].ToString(), out var NumberValue))
                        value = Processcard.Format_Value(NumberValue, decimals);
                    break;
                case 1: // TextValue
                    value = reader["TextValue"].ToString();
                    break;
                case 2: // BoolValue
                        // Implementera om du vill hantera bool-värden.
                    break;
                case 3: // DateValue
                    if (DateTime.TryParse(reader["DateValue"].ToString(), out var date))
                        value = date.ToString("yyyy-MM-dd HH:mm");
                    break;
            }

            sheet.Cells[excelRow, col].Value = value;
            col++;
            if (col == 9)
                col = 5;
        }

        // Fyll i allmän information i början av raden
        sheet.Cells[excelRow, 1].Value = dgv_Orderlist.Rows[row].Cells["orderlist_PartNr"].Value?.ToString();
        sheet.Cells[excelRow, 2].Value = dgv_Orderlist.Rows[row].Cells["orderlist_RevNr"].Value?.ToString();
        sheet.Cells[excelRow, 3].Value = dgv_Orderlist.Rows[row].Cells["orderlist_OrderNr"].Value?.ToString();
        sheet.Cells[excelRow, 4].Value = uppstart;

        // Rubriker på första raden
        string[] kolumn_Rubriker_Körprotokoll = { "ArtikelNr", "RevNr", "OrderNr", "Uppstart", "Kärna", "Kärna LL", "Munstycke", "Munstycke LL" };
        for (var i = 0; i < kolumn_Rubriker_Körprotokoll.Length; i++)
        {
            var cell = sheet.Cells[1, i + 1];
            cell.Value = kolumn_Rubriker_Körprotokoll[i];
            cell.Style.Font.Bold = true;
            cell.Style.WrapText = true;
            sheet.Column(i + 1).AutoFit();
        }
    }
        private static void Export_Sheet_Extruder(ExcelWorksheet sheet, int excelRow, int row, int uppstart, int machine, DataGridView dgv_Orderlist)
        {
            string[] headers = { "ArtikelNr", "RevNr", "OrderNr", "Uppstart", "Zon 1", "Zon 2", "Zon 3", "Zon 4", "Zon 5", "Zon 6", "Zon 7", "Zon 8", "Zon 9", "Skruvhastighet", "Belastning" };

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
            SELECT DISTINCT Value, TextValue, DateValue, MachineIndex, Uppstart, RowIndex, template.Decimals, template.Type
            FROM [Order].Data AS protocol
                JOIN Protocol.Template as template
                    ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                JOIN Protocol.Description as descr
                    ON descr.id = template.ProtocolDescriptionID
            WHERE OrderID = @orderid
                AND FormTemplateID = @formtemplateid
                AND template.revision = @revision
                AND RowIndex IS NOT NULL
                AND Uppstart = @uppstart
                AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))
            ORDER BY MachineIndex, RowIndex";

            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@uppstart", uppstart);
            cmd.Parameters.AddWithValue("@machineindex", machine);
            cmd.Parameters.AddWithValue("@formtemplateid", 5);
            cmd.Parameters.AddWithValue("@revision", Korprotokoll.ProtocolTemplateRevision.OrderNr(Order.OrderID));

            var reader = cmd.ExecuteReader();
            var col = 5;
            while (reader.Read())
            {
                int.TryParse(reader["type"].ToString(), out var type);

                var value = string.Empty;
                switch (type)
                {
                    case 0: // NumberValue
                        int.TryParse(reader["Decimals"].ToString(), out var decimals);
                        if (double.TryParse(reader["Value"].ToString(), out var numberValue))
                            value = Processcard.Format_Value(numberValue, decimals);
                        break;
                    case 1: // TextValue
                        value = reader["TextValue"].ToString();
                        break;
                    case 2: // BoolValue
                        // Lägg till logik om du vill hantera detta
                        break;
                    case 3: // DateValue
                        if (DateTime.TryParse(reader["DateValue"].ToString(), out var date))
                            value = date.ToString("yyyy-MM-dd HH:mm");
                        break;
                }

                sheet.Cells[excelRow, col].Value = value;
                col++;
                if (col == headers.Length + 1)
                    col = 5;
            }

            // Grundläggande orderinfo i början av raden
            sheet.Cells[excelRow, 1].Value = dgv_Orderlist.Rows[row].Cells["orderlist_PartNr"].Value?.ToString();
            sheet.Cells[excelRow, 2].Value = dgv_Orderlist.Rows[row].Cells["orderlist_RevNr"].Value?.ToString();
            sheet.Cells[excelRow, 3].Value = dgv_Orderlist.Rows[row].Cells["orderlist_OrderNr"].Value?.ToString();
            sheet.Cells[excelRow, 4].Value = uppstart;

            // Rubriker i rad 1
            for (var i = 0; i < headers.Length; i++)
            {
                var cell = sheet.Cells[1, i + 1];
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.WrapText = true;
                sheet.Column(i + 1).AutoFit();
            }
        }
        private static void Export_Sheet_Formning(ExcelWorksheet sheet, int excelRow, int row, int uppstart, DataGridView dgv_Orderlist)
        {
            string[] headers = {
        "ArtikelNr", "RevNr", "OrderNr", "Uppstart", "Läcksökning", "Antistat", "Luft/Gas Körna", "Draghastighet",
        "Kylk. Avst.", "Vattenfl.", "ID Kalib.", "Upptagning", "Hackning Hastighet", "Hackrör ID", "Används Ugn?", "Ugn Temp"
    };

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
            SELECT DISTINCT Value, TextValue, DateValue, MachineIndex, Uppstart, RowIndex, template.Decimals, template.Type
            FROM [Order].Data AS protocol
                JOIN Protocol.Template as template
                    ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                JOIN Protocol.Description as descr
                    ON descr.id = template.ProtocolDescriptionID
            WHERE OrderID = @orderid
                AND FormTemplateID = @formtemplateid
                AND template.revision = @revision
                AND RowIndex IS NOT NULL
                AND Uppstart = @uppstart
            ORDER BY MachineIndex, RowIndex";

            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@uppstart", uppstart);
            cmd.Parameters.AddWithValue("@formtemplateid", 14);
            cmd.Parameters.AddWithValue("@revision", Korprotokoll.ProtocolTemplateRevision.OrderNr(Order.OrderID));

            var reader = cmd.ExecuteReader();
            var col = 5;
            while (reader.Read())
            {
                int.TryParse(reader["type"].ToString(), out var type);

                var value = string.Empty;
                switch (type)
                {
                    case 0: // NumberValue
                        int.TryParse(reader["Decimals"].ToString(), out var decimals);
                        if (double.TryParse(reader["Value"].ToString(), out var numberValue))
                            value = Processcard.Format_Value(numberValue, decimals);
                        break;
                    case 1: // TextValue
                        value = reader["TextValue"].ToString();
                        break;
                    case 2: // BoolValue
                        // Om du vill visa boolska värden: value = "Ja"/"Nej" t.ex.
                        break;
                    case 3: // DateValue
                        if (DateTime.TryParse(reader["DateValue"].ToString(), out var date))
                            value = date.ToString("yyyy-MM-dd HH:mm");
                        break;
                }

                sheet.Cells[excelRow, col].Value = value;
                col++;
                if (col == headers.Length + 1)
                    col = 5;
            }

            // Grundläggande info
            sheet.Cells[excelRow, 1].Value = dgv_Orderlist.Rows[row].Cells["orderlist_PartNr"].Value?.ToString();
            sheet.Cells[excelRow, 2].Value = dgv_Orderlist.Rows[row].Cells["orderlist_RevNr"].Value?.ToString();
            sheet.Cells[excelRow, 3].Value = dgv_Orderlist.Rows[row].Cells["orderlist_OrderNr"].Value?.ToString();
            sheet.Cells[excelRow, 4].Value = uppstart;

            // Rubriker
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = sheet.Cells[1, i + 1];
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.WrapText = true;
                sheet.Column(i + 1).AutoFit();
            }
        }
        private static void Export_Sheet_Prod(ExcelWorksheet sheet, int excelRow, int row, int uppstart, DataGridView dgv_Orderlist)
        {
            string[] headers = { "ArtikelNr", "RevNr", "OrderNr", "Uppstart", "Spole/Påse", "Längd/Antal", "Start", "Stopp" };

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
            SELECT DISTINCT Value, TextValue, DateValue, MachineIndex, Uppstart, RowIndex, template.Decimals, template.Type
            FROM [Order].Data AS protocol
                JOIN Protocol.Template as template
                    ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
                JOIN Protocol.Description as descr
                    ON descr.id = template.ProtocolDescriptionID
            WHERE OrderID = @orderid
                AND FormTemplateID = @formtemplateid
                AND template.revision = @revision
                AND RowIndex IS NOT NULL
                AND Uppstart = @uppstart
            ORDER BY MachineIndex, RowIndex";

            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@uppstart", uppstart);
            cmd.Parameters.AddWithValue("@formtemplateid", 17);
            cmd.Parameters.AddWithValue("@revision", Korprotokoll.ProtocolTemplateRevision.OrderNr(Order.OrderID));

            var reader = cmd.ExecuteReader();
            var col = 5;
            while (reader.Read())
            {
                int.TryParse(reader["type"].ToString(), out var type);

                var value = string.Empty;
                switch (type)
                {
                    case 0: // NumberValue
                        int.TryParse(reader["Decimals"].ToString(), out var decimals);
                        if (double.TryParse(reader["Value"].ToString(), out var numberValue))
                            value = Processcard.Format_Value(numberValue, decimals);
                        break;
                    case 1: // TextValue
                        value = reader["TextValue"].ToString();
                        break;
                    case 2: // BoolValue
                        // Du kan lägga till "Ja"/"Nej" här om det behövs.
                        break;
                    case 3: // DateValue
                        if (DateTime.TryParse(reader["DateValue"].ToString(), out var date))
                            value = date.ToString("yyyy-MM-dd HH:mm");
                        break;
                }

                sheet.Cells[excelRow, col].Value = value;
                col++;
                if (col == headers.Length + 1)
                    col = 5;
            }

            // Grundläggande orderdata
            sheet.Cells[excelRow, 1].Value = dgv_Orderlist.Rows[row].Cells["orderlist_PartNr"].Value?.ToString();
            sheet.Cells[excelRow, 2].Value = dgv_Orderlist.Rows[row].Cells["orderlist_RevNr"].Value?.ToString();
            sheet.Cells[excelRow, 3].Value = dgv_Orderlist.Rows[row].Cells["orderlist_OrderNr"].Value?.ToString();
            sheet.Cells[excelRow, 4].Value = uppstart;

            // Rubriker
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = sheet.Cells[1, i + 1];
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.WrapText = true;
                sheet.Column(i + 1).AutoFit();
            }
        }

    }
}
