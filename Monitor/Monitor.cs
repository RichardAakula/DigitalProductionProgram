using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using NAudio.CoreAudioApi;
using NCalc.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static DigitalProductionProgram.Monitor.GET.Inventory;

namespace DigitalProductionProgram.Monitor
{
    internal class Monitor
    {
        public static Monitor Current { get; } = new Monitor();


        public static Factory factory;
        public enum Factory
        {
            Godby,
            Holding,
            Thailand,
            ValleyForge,
            Nothing
        }

        public static Status status;
        public enum Status
        {
            Ok,
            Warning,
            Bad
        }
        public static Label? lbl_Monitorstatus;
        public static Panel? panel_Monitorstatus;
        public static string? MonitorStatus;
        public static List<string>? List_PartNr;


        //public string? PartNumber { get; set; }
        public Inventory.Parts? Part { get; private set; }
        public static Inventory.Parts? Part_Material;
        public static Manufacturing.ManufacturingOrders? Order;
        public static Manufacturing.ManufacturingOrderOperations? Operations;
        public static Sales.Customers? Customer;
        public static Common.Units? Unit;
        public static Common.Departments? Department;
        public static Manufacturing.WorkCenters? WorkCenter;
        public static List<Common.ExtraFieldTemplates>? ExtraFieldTemplate;

        public static DataTable? DataTable_Measurepoints { get; set; }

        public static async Task<DataTable> DataTable_CandleFilter()
        {
            var dt = new DataTable(); 
            dt.Columns.Add("Item1", typeof(string));
            dt.Columns.Add("Item2", typeof(string));
            var parts = await Utilities.GetFromMonitor<Inventory.Parts>("filter=startswith(Description, 'Candle')");
            foreach (var part in parts)
                dt.Rows.Add($"{part.PartNumber}", $"{part.Description}");
            return dt;
        }
        public static Dictionary<string, string> WorkCenters = null!;
        public static bool IsPartNumberExistInMonitor(string partNumber)
        {
            var partNr = Utilities.GetOneFromMonitor<Inventory.Parts>("select=PartNumber", $"filter=PartNumber Eq'{partNumber}'");
            return partNr != null;
        }
        //public static List<string?> PreFab_BatchNr(string? partNumber)
        //{
        //    var list = new List<string?>
        //    {
        //        "N/A",
        //        string.Empty
        //    };
        //    // Monitor_Login.Login_Monitor();
        //    var partId = Utilities.GetOneFromMonitor<Inventory.Parts>("select=Id", $"filter=PartNumber Eq'{partNumber}'");
        //    if (partId is null)
        //        return null;
        //    var PartLocationsId = Utilities.GetFromMonitor<Inventory.PartLocations>($"filter=PartId Eq'{partId.Id}' AND Balance gt'0' AND (WarehouseId Eq 1 OR WarehouseId Eq 5) AND LifeCycleState Eq 10");
        //    foreach (var id in PartLocationsId)
        //    {
        //        var partLocationProductRecords = Utilities.GetFromMonitor<Inventory.PartLocationProductRecords>($"filter=PartLocationId Eq'{id.Id}' AND Quantity gt '0'");
        //        if (partLocationProductRecords != null)
        //        {
        //            foreach (var partLocationId in partLocationProductRecords)
        //            {
        //                var productRecordId = Utilities.GetFromMonitor<Inventory.ProductRecords>($"filter=Id Eq'{partLocationId.ProductRecordId}'");
        //                if (productRecordId == null) 
        //                    continue;
        //                foreach (var lotNr in productRecordId.Where(lotNr => lotNr != null && !list.Contains(lotNr.SerialNumber)))
        //                    list.Add(lotNr.SerialNumber);
        //            }
        //        }
        //    }
        //    return list;
        //}
        public static async Task<List<string?>> PreFab_BatchNr(string? partNumber)
        {
            var list = new List<string?>
            {
                "N/A",
                string.Empty
            };

            if (string.IsNullOrWhiteSpace(partNumber))
                return list;

            // Hämta partId
            var part = await Utilities.GetOneFromMonitor<Inventory.Parts>(
                "select=Id",
                $"filter=PartNumber Eq'{partNumber}'"
            );

            if (part is null)
                return list;

            // Hämta PartLocations med saldo
            var partLocations = await Utilities.GetFromMonitor<Inventory.PartLocations>(
                $"filter=PartId Eq'{part.Id}' AND Balance gt 0 AND (WarehouseId Eq 1 OR WarehouseId Eq 5) AND LifeCycleState Eq 10"
            );

            if (partLocations == null || partLocations.Count == 0)
                return list;

            foreach (var location in partLocations)
            {
                // Hämta PartLocationProductRecords
                var records = await Utilities.GetFromMonitor<Inventory.PartLocationProductRecords>(
                    $"filter=PartLocationId Eq'{location.Id}' AND Quantity gt 0"
                );

                if (records == null || records.Count == 0)
                    continue;

                foreach (var record in records)
                {
                    // Hämta motsvarande ProductRecord
                    var productRecords = await Utilities.GetFromMonitor<Inventory.ProductRecords>(
                        $"filter=Id Eq'{record.ProductRecordId}'"
                    );

                    if (productRecords == null)
                        continue;

                    foreach (var product in productRecords)
                    {
                        if (!string.IsNullOrWhiteSpace(product.SerialNumber) && !list.Contains(product.SerialNumber))
                            list.Add(product.SerialNumber);
                    }
                }
            }

            return list;
        }

        //public static List<string?> List_RazorTypes
        //{
        //    get
        //    {
        //        var parts = Utilities.GetFromMonitor<Inventory.Parts>("filter=startswith(Description, 'Rakblad')");

        //        return parts.Select(part => part.ExtraDescription).ToList();
        //    }
        //}
        public static async Task<List<string?>> List_RazorTypes()
        {
            var parts = await Utilities.GetFromMonitor<Inventory.Parts>("filter=startswith(Description, 'Rakblad')");

            // Om inget hittas, returnera tom lista
            if (parts == null)
                return new List<string?>();

            return parts
                .Where(p => !string.IsNullOrEmpty(p.ExtraDescription))
                .Select(p => p.ExtraDescription)
                .ToList();
        }

        public static async Task<List<string>> List_CandleFilter_PartNr(string description)
        {
            var list = new List<string>();

            // Hämta alla delar vars Description börjar med t.ex. "Candle"
            var parts = await Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(Description, '{description}')");

            if (parts == null || parts.Count == 0)
                return list;

            foreach (var part in parts)
            {
                if (!string.IsNullOrEmpty(part.PartNumber))
                    list.Add(part.PartNumber);
            }

            return list;
        }
        //public static List<Inventory.Parts> List_Part_Types(string Description)
        //{
        //    var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(Description, '{Description}')");
        //    return parts;
        //   // return parts.Select(part => part.Description).ToList();
        //}
        //public static List<string?> List_CandleFilter_PartNr(string description)
        //{
        //    var list = new List<string>();
        //    var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(Description, '{description}')");
        //    foreach (var part in parts)
        //        list.Add($"{part.PartNumber}");

        //    return list;
        //}

        //public static List<string?> List_PartNumber_FilterType()
        //{
        //    var list = new List<string>();
        //    var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(PartNumber, 'Filter')");
        //    foreach (var part in parts)
        //        list.Add($"{part.PartNumber}");
        //    return list;
        //}
        public static async Task<List<string?>> List_PartNumber_FilterType()
        {
            var list = new List<string?>();

            // Om GetFromMonitor har en async-version:
            var parts = await Utilities.GetFromMonitor<Inventory.Parts>("filter=startswith(PartNumber, 'Filter')");

            // Om inte, kan du göra:
            // var parts = await Task.Run(() => Utilities.GetFromMonitor<Inventory.Parts>("filter=startswith(PartNumber, 'Filter')"));

            foreach (var part in parts)
                list.Add(part.PartNumber);

            return list;
        }

        //public static List<string> List_Serialnumber_Extrusion_Filter(string? partnr)
        //{
        //    if (string.IsNullOrEmpty(partnr))
        //        return new List<string> { "N/A" };
        //    var parts = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partnr}'");
        //    if (parts is null)
        //        return new List<string> { "N/A" };
        //    var partId = parts.Id;
        //    var partLocations = Utilities.GetFromMonitor<Inventory.ProductRecords>($"filter=PartId Eq'{partId}' AND LifeCycleState Eq 0");
        //    return (from part in partLocations where part.SerialNumber != null select part.SerialNumber).ToList();
        //}
        public static async Task<List<string>> List_Serialnumber_Extrusion_Filter(string? partnr)
        {
            if (string.IsNullOrEmpty(partnr))
                return new List<string> { "N/A" };

            // Hämta delen asynkront
            var part = await Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partnr}'");
            if (part is null)
                return new List<string> { "N/A" };

            var partId = part.Id;

            // Hämta produktposter asynkront
            var partLocations = await Utilities.GetFromMonitor<Inventory.ProductRecords>($"filter=PartId Eq'{partId}' AND LifeCycleState Eq 0");

            return partLocations
                .Where(p => p.SerialNumber != null)
                .Select(p => p.SerialNumber!)
                .ToList();
        }


        //public static DataTable DataTable_MeasuringTemplates
        //{
        //    get
        //    {
        //        var table = new DataTable();
        //        table.Columns.Add("Description", typeof(string));
        //        table.Columns.Add("FormTemplateId", typeof(long));

        //        var parameters = Utilities.GetFromMonitor<Common.MeasuringTemplates>("select=FormTemplateId,Description");

        //        var distinctDescriptions = new HashSet<string>();

        //        foreach (var parameter in parameters)
        //        {
        //            if (distinctDescriptions.Add(parameter.Description))
        //            {
        //                // Add the row to the DataTable only if the description is distinct
        //                var row = table.NewRow();
        //                row["Description"] = parameter.Description;
        //                row["FormTemplateId"] = parameter.FormTemplateId;
        //                table.Rows.Add(row);
        //            }
        //        }

        //        return table;
        //    }
        //}
        public static async Task<DataTable> DataTable_MeasuringTemplates()
        {
            var table = new DataTable();
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("FormTemplateId", typeof(long));

            // Hämta mallarna asynkront
            var parameters = await Utilities.GetFromMonitor<Common.MeasuringTemplates>("select=FormTemplateId,Description");
            // Om Utilities inte har async-version, använd:
            // var parameters = await Task.Run(() => Utilities.GetFromMonitor<Common.MeasuringTemplates>("select=FormTemplateId,Description"));

            var distinctDescriptions = new HashSet<string>();

            foreach (var parameter in parameters)
            {
                if (distinctDescriptions.Add(parameter.Description))
                {
                    var row = table.NewRow();
                    row["Description"] = parameter.Description;
                    row["FormTemplateId"] = parameter.FormTemplateId;
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        //public static List<string> List_MonitorParameters(int formtemplateid)
        //{
        //    var list = new List<string> { "Bag", "StripesAvg", "PreFab" };
        //    var FormTemplateSelectionRows = Utilities.GetOneFromMonitor<Common.FormTemplateSelectionRows>($"filter=FormTemplateId Eq'{formtemplateid}'");
        //    var parameters = Utilities.GetFromMonitor<Common.FormTemplateRows>("select=Description", $"filter=FormTemplateSelectionRowId Eq'{FormTemplateSelectionRows.Id}'");

        //    foreach (var parameter in parameters.Where(parameter => list.Contains(parameter.Description) == false))
        //        list.Add(parameter.Description);

        //    return list;
        //}
        public static async Task<List<string>> List_MonitorParameters(int formTemplateId)
        {
            var list = new List<string> { "Bag", "StripesAvg", "PreFab" };

            // Hämta FormTemplateSelectionRows asynkront
            var formTemplateSelectionRow = await Utilities.GetOneFromMonitor<Common.FormTemplateSelectionRows>(
                $"filter=FormTemplateId Eq'{formTemplateId}'"
            );

            if (formTemplateSelectionRow is null)
                return list; // Om inget hittas, returnera standardlistan

            // Hämta FormTemplateRows asynkront
            var parameters = await Utilities.GetFromMonitor<Common.FormTemplateRows>(
                $"select=Description",
                $"filter=FormTemplateSelectionRowId Eq'{formTemplateSelectionRow.Id}'"
            );

            foreach (var parameter in parameters.Where(p => !list.Contains(p.Description)))
                list.Add(parameter.Description);

            return list;
        }

        public static List<string> List_ProdGroup
        {
            get
            {
                return WorkCenters.Select(kvp => kvp.Key).ToList();
            }
        }
        public static List<string> List_ProdLine
        {
            get
            {
                return WorkCenters.Select(kvp => kvp.Value).ToList();
            }
        }




        //public static List<TimeRecording.AttendanceChart> List_Users
        //{
        //    get
        //    {
        //        Login_Monitor.Login_API("003.1");

        //        var date = DateTime.Now.ToString("yyyy-MM-dd");
        //        var users = Utilities.GetFromMonitor<TimeRecording.AttendanceChart>($"select=FirstName,LastName,IsClosedInterval,AbsenceDescription,IntervalStart,IntervalEnd&$filter=startswith(IntervalStart, '{date}')&$orderby=IntervalStart");

        //        return users;
        //    }
        //}
        public static async Task<List<TimeRecording.AttendanceChart>> List_Users()
        {
            // Logga in innan hämtning
            await Task.Run(() => Login_Monitor.Login_API("003.1"));

            var date = DateTime.Now.ToString("yyyy-MM-dd");

            // Hämta användare asynkront
            var users = await Utilities.GetFromMonitor<TimeRecording.AttendanceChart>(
                $"select=FirstName,LastName,IsClosedInterval,AbsenceDescription,IntervalStart,IntervalEnd&$filter=startswith(IntervalStart, '{date}')&$orderby=IntervalStart"
            );

            // Om Utilities inte har async-version, använd Task.Run:
            // var users = await Task.Run(() => Utilities.GetFromMonitor<TimeRecording.AttendanceChart>(
            //     $"select=FirstName,LastName,IsClosedInterval,AbsenceDescription,IntervalStart,IntervalEnd&$filter=startswith(IntervalStart, '{date}')&$orderby=IntervalStart"
            // ));

            return users;
        }


        //public static AutoCompleteStringCollection AutoFillOrdernr
        //{
        //    get
        //    {
        //        var list = new AutoCompleteStringCollection();

        //        var ordernr = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrders>("select=OrderNumber");
        //        if (ordernr is null)
        //            return list;
        //        foreach (var order in ordernr)
        //            list.Add(order.OrderNumber);

        //        return list;
        //    }
        //}
        public static async Task<AutoCompleteStringCollection> AutoFillOrdernr()
        {
            var list = new AutoCompleteStringCollection();

            // Hämta ordernummer asynkront
            var ordernr = await Utilities.GetFromMonitor<Manufacturing.ManufacturingOrders>("select=OrderNumber");

            // Om det inte finns några order, returnera tom lista
            if (ordernr is null)
                return list;

            foreach (var order in ordernr)
                list.Add(order.OrderNumber);

            return list;
        }

        //public static decimal Balance(string partNumber, string serialNumber = null)
        //{
        //    var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partNumber}'");
        //    if (part == null)
        //        return 0;
        //    var filter = $"filter=PartId Eq'{part.Id}'";
        //    if (string.IsNullOrEmpty(serialNumber) == false)
        //        filter += $" AND SerialNumber Eq'{serialNumber}'";
        //    var productRecordsId = Utilities.GetOneFromMonitor<Inventory.ProductRecords>(filter);
        //    if (productRecordsId is null)
        //        return 0;
        //    var partLocationProductRecords = Utilities.GetFromMonitor<Inventory.PartLocationProductRecords>($"filter=ProductRecordId Eq'{productRecordsId.Id}' AND Quantity gt'0'");
        //    decimal quantity = 0;
        //    foreach (var id in partLocationProductRecords)
        //        quantity += id.Quantity;

        //    return quantity;
        //}
        public static async Task<decimal> Balance(string partNumber, string? serialNumber = null)
        {
            // Hämta delen asynkront
            var part = await Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partNumber}'");
            if (part is null)
                return 0;

            var filter = $"filter=PartId Eq'{part.Id}'";
            if (!string.IsNullOrEmpty(serialNumber))
                filter += $" AND SerialNumber Eq'{serialNumber}'";

            // Hämta ProductRecord asynkront
            var productRecord = await Utilities.GetOneFromMonitor<Inventory.ProductRecords>(filter);
            if (productRecord is null)
                return 0;

            // Hämta PartLocationProductRecords asynkront
            var partLocationProductRecords = await Utilities.GetFromMonitor<Inventory.PartLocationProductRecords>(
                $"filter=ProductRecordId Eq'{productRecord.Id}' AND Quantity gt'0'"
            );

            decimal quantity = 0;
            foreach (var record in partLocationProductRecords)
                quantity += record.Quantity;

            return quantity;
        }

        //public static string BestBeforeDate(string partNumber, string serialNumber)
        //{
        //    var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partNumber}'");
        //    if (part == null || string.IsNullOrEmpty(serialNumber))
        //        return null;
        //    var filter = $"filter=PartId Eq'{part.Id}' AND SerialNumber Eq'{serialNumber}'";
        //    var productRecords = Utilities.GetOneFromMonitor<Inventory.ProductRecords>(filter);
        //    if (productRecords is null)
        //        return null;
        //    if (DateTime.TryParse(productRecords.BestBeforeDate, out var date) == false)
        //        return "N/A";
        //    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
        //    var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
        //    return formattedDate;
        //}
        public static async Task<string?> BestBeforeDate(string partNumber, string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
                return null;

            // Hämta delen asynkront
            var part = await Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partNumber}'");
            if (part is null)
                return null;

            // Hämta produktposten asynkront
            var productRecord = await Utilities.GetOneFromMonitor<Inventory.ProductRecords>(
                $"filter=PartId Eq'{part.Id}' AND SerialNumber Eq'{serialNumber}'"
            );
            if (productRecord is null)
                return null;

            // Konvertera BestBeforeDate
            if (!DateTime.TryParse(productRecord.BestBeforeDate, out var date))
                return "N/A";

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            return date.ToString(dateTimeFormat.ShortDatePattern, CultureInfo.CurrentCulture);
        }

        //public static double? MeasurePoint(string? PartNr, string Description, int Operation = 0)
        //{
        //    var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{PartNr}'");
        //    if (part == null)
        //        return null;
        //    var filter = $"filter=PartId Eq'{part.Id}'";
        //    if (Operation > 0)
        //        filter += $" AND OperationNumber Eq'{Operation}'";
        //    var operations = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperations>(filter, "orderby=ActualFinishDate DESC");
        //    if (operations is null)
        //        return null;
        //    var ManufacturingOrderOperationControlDataRows = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperationControlDataRows>($"filter=ManufacturingOrderOperationId Eq'{operations.Id}'");
        //    if (ManufacturingOrderOperationControlDataRows is null)
        //        return null;
        //    var FormTemplateSelectionRows = Utilities.GetOneFromMonitor<Common.FormTemplateSelectionRows>($"filter=FormTemplateId Eq'{ManufacturingOrderOperationControlDataRows.OverridenFormTemplateId}'");
        //    var MeasurePoint = Utilities.GetOneFromMonitor<Common.FormTemplateRows>($"filter=FormTemplateSelectionRowId Eq'{FormTemplateSelectionRows.Id}' AND Description Eq'{Description}'");
        //    if (MeasurePoint is null) 
        //        return null;
        //    return MeasurePoint.Value;

        //}
        public static async Task<double?> MeasurePoint(string? partNr, string description, int operation = 0)
        {
            if (string.IsNullOrEmpty(partNr))
                return null;

            // Hämta delen asynkront
            var part = await Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{partNr}'");
            if (part is null)
                return null;

            // Hämta operationen asynkront
            var filterOperation = $"filter=PartId Eq'{part.Id}'";
            if (operation > 0)
                filterOperation += $" AND OperationNumber Eq'{operation}'";

            var operations = await Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperations>(
                filterOperation,
                "orderby=ActualFinishDate DESC"
            );
            if (operations is null)
                return null;

            // Hämta kontrollrader asynkront
            var controlDataRows = await Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperationControlDataRows>(
                $"filter=ManufacturingOrderOperationId Eq'{operations.Id}'"
            );
            if (controlDataRows is null)
                return null;

            // Hämta FormTemplateSelectionRows asynkront
            var formTemplateSelectionRow = await Utilities.GetOneFromMonitor<Common.FormTemplateSelectionRows>(
                $"filter=FormTemplateId Eq'{controlDataRows.OverridenFormTemplateId}'"
            );
            if (formTemplateSelectionRow is null)
                return null;

            // Hämta MeasurePoint asynkront
            var measurePoint = await Utilities.GetOneFromMonitor<Common.FormTemplateRows>(
                $"filter=FormTemplateSelectionRowId Eq'{formTemplateSelectionRow.Id}' AND Description Eq'{description}'"
            );

            if (measurePoint is null)
                return null;

            return measurePoint.Value;
        }

        //public static string Units(string artikelNr)
        //{
        //    var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{artikelNr}'");
        //    if (part is null)
        //        return "N/A";
        //    var enhet = Utilities.GetOneFromMonitor<Common.Units>($"filter=Id Eq'{part.StandardUnitId}'");

        //    return enhet.Code;
        //}
        public static async Task<string> Units(string artikelNr)
        {
            // Hämta delen i en bakgrundstråd
            var part = await Task.Run(() => Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{artikelNr}'"));
            if (part is null)
                return "N/A";

            // Hämta enhet i en bakgrundstråd
            var enhet = await Task.Run(() => Utilities.GetOneFromMonitor<Common.Units>($"filter=Id Eq'{part.StandardUnitId}'"));

            return enhet?.Code ?? "N/A";
        }


        //public static Common.Persons User(int EmployeeNumber)
        //{
        //    var person = Utilities.GetOneFromMonitor<Common.Persons>($"filter=EmployeeNumber Eq'{EmployeeNumber}'");
        //    return person;
        //}
        public static async Task<Common.Persons?> User(int employeeNumber)
        {
            var person = await Task.Run(() => Utilities.GetOneFromMonitor<Common.Persons>($"filter=EmployeeNumber Eq'{employeeNumber}'"));
            return person;
        }

        //public static Common.Persons User(string FirstName, string LastName)
        //{
        //    var person = Utilities.GetOneFromMonitor<Common.Persons>($"filter=EmployeeNumber Eq'{FirstName}' AND LastName Eq'{LastName}'");
        //    return person;
        //}
        public static Common.Persons? User(string firstName, string lastName)
        {
            var person = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.Persons>($"filter=FirstName Eq'{firstName}' AND LastName Eq'{lastName}'")
            ).Result;

            return person;
        }

        public static long OrderId(string artikelNr)
        {
            var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=PartNumber Eq'{artikelNr}'");
            var order = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=PartId Eq '{part.Id}'", "orderby=StartDate DESC");
            if (order is null)
                return 0;
            return order.Id;
        }

        public static void Set_Monitorstatus(Status Status, string text)
        {
            Log.Activity.Start();
            switch(Status)
            {
                case Status.Ok:
                {
                    status = Status.Ok;
                    MonitorStatus = $"Connection to Monitor ok: Responsetime = {text} ms";
                    if (lbl_Monitorstatus != null) lbl_Monitorstatus.ForeColor = Color.FromArgb(198, 239, 206);
                    if (panel_Monitorstatus != null) ServerStatus.DrawPanelMonitorStatus(panel_Monitorstatus, Color.FromArgb(198, 239, 206));
                    break;
                }
                case Status.Warning:
                    status = Status.Warning;
                    MonitorStatus = $"Connection to Monitor is bad, but working: Responsetime = {text} ms";
                    if (lbl_Monitorstatus != null) lbl_Monitorstatus.ForeColor = Color.FromArgb(156, 101, 0);
                    if (panel_Monitorstatus != null) ServerStatus.DrawPanelMonitorStatus(panel_Monitorstatus, Color.FromArgb(255, 235, 156));
                    break;
                case Status.Bad:
                {
                    status = Status.Bad;
                    MonitorStatus = $"Connection to Monitor is not working, please contact Admin.\n\n{text}";
                    if (lbl_Monitorstatus != null) lbl_Monitorstatus.ForeColor = Color.FromArgb(156, 0, 6);
                    if (panel_Monitorstatus != null) ServerStatus.DrawPanelMonitorStatus(panel_Monitorstatus, Color.FromArgb(255, 199, 206));
                    Main_Form.timer_ReloginMonitor = 10; // Börjar logga in automatiskt efter 10 sekunder om anslutningen till Monitor är dålig
                        break;
                }
           }
            _ = Log.Activity.Stop($"ResponseTime to Monitor: {text}");
        }

        public void Load_OrderInformation()
        {
            Load_Order(OrderManagement.Order.OrderNumber);
            Load_Operations(int.Parse(OrderManagement.Order.Operation));
            Load_Part();
            if (Operations is null == false)
                Load_PartMaterial(Monitor.Operations.OperationNumber);
            Load_Customer();
            Load_Unit();
            Load_WorkCenter(OrderManagement.Order.ProdGroup);

            Load_Department();
        }
        public static void Load_Order(string? ordernr)
        {
            if (string.IsNullOrEmpty(ordernr))
                return;

            // Hämta order i bakgrundstråd
            Order = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=OrderNumber Eq'{ordernr}'")
            ).Result;

            if (Order is null)
            {
                // Order kan vara NULL om det är en testorder eller väldigt gammal order
                OrderManagement.Order.Load_OrderInformation_TestOrder();
            }
        }

        //public static void Load_Operations(int operation)
        //{
        //    if (Order is null)
        //    {
        //        if (Person.Role != "SuperAdmin")
        //            InfoText.Show(LanguageManager.GetString("monitorDeletedOrder"), CustomColors.InfoText_Color.Warning, "Warning", null);
        //        return;
        //    }
        //    Operations = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=ManufacturingOrderId Eq'{Order.Id}' AND OperationNumber Eq'{operation}'");
        //}
        public static void Load_Operations(int operation)
        {
            if (Order is null)
            {
                if (Person.Role != "SuperAdmin")
                    InfoText.Show(LanguageManager.GetString("monitorDeletedOrder"), CustomColors.InfoText_Color.Warning, "Warning", null);
                return;
            }

            // Hämta operation i bakgrundstråd
            Operations = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperations>(
                    $"filter=ManufacturingOrderId Eq'{Order.Id}' AND OperationNumber Eq'{operation}'")).Result;
        }

        //public static void Load_Customer()
        //{
        //    if (Order is null)
        //        return;
        //    Customer = Utilities.GetOneFromMonitor<Sales.Customers>($"filter=Id Eq'{Order.CustomerId}'");
        //}
        public static void Load_Customer()
        {
            if (Order is null)
                return;

            // Hämta kund i bakgrundstråd
            Customer = Task.Run(() =>
                Utilities.GetOneFromMonitor<Sales.Customers>($"filter=Id Eq'{Order.CustomerId}'")
            ).Result;
        }

        //public static void Load_Department()
        //{
        //    if (WorkCenter is null)
        //        return;
        //    Department = Utilities.GetOneFromMonitor<Common.Departments>($"filter=Id Eq'{WorkCenter.DepartmentId}'");
        //}
        public static void Load_Department()
        {
            if (WorkCenter is null)
                return;

            // Hämta avdelning i bakgrundstråd
            Department = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.Departments>($"filter=Id Eq'{WorkCenter.DepartmentId}'")
            ).Result;
        }


        //public void Load_Part()
        //{
        //    if (Order is null)
        //        return;
        //    Part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=Id Eq'{Order.PartId}'");
        //}
        public void Load_Part()
        {
            if (Order is null)
                return;

            // Hämta delen i bakgrundstråd
            Part = Task.Run(() =>
                Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=Id Eq'{Order.PartId}'")
            ).Result;
        }


        //public static void Load_PartMaterial(int Operation = 0)
        //{
        //    if (Order is null)
        //        return;
        //    var order = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=OrderNumber Eq'{Order.OrderNumber}'");
        //    string filter;
        //    if (Operation == 0)
        //        filter = $"filter=ManufacturingOrderId Eq'{order.Id}'";
        //    else
        //        filter = $"filter=ManufacturingOrderId Eq'{order.Id}' AND ToOperationNumber Eq'{Operation}'";
        //    var materials = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderMaterials>(filter);
        //    if (materials is null)
        //        return;
        //    Part_Material = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=Id Eq'{materials.PartId}'");
        //}
        public static void Load_PartMaterial(int operation = 0)
        {
            if (Order is null)
                return;

            // Hämta order i bakgrundstråd
            var order = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=OrderNumber Eq'{Order.OrderNumber}'")
            ).Result;

            if (order is null)
                return;

            // Bygg filter
            string filter = operation == 0
                ? $"filter=ManufacturingOrderId Eq'{order.Id}'"
                : $"filter=ManufacturingOrderId Eq'{order.Id}' AND ToOperationNumber Eq'{operation}'";

            // Hämta material i bakgrundstråd
            var materials = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderMaterials>(filter)
            ).Result;

            if (materials is null)
                return;

            // Hämta Part_Material i bakgrundstråd
            Part_Material = Task.Run(() =>
                Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=Id Eq'{materials.PartId}'")).Result;
        }

        //public static void Load_WorkCenter(string prodgrupp)
        //{
        //    WorkCenter = Utilities.GetOneFromMonitor<Manufacturing.WorkCenters>($"filter=Number Eq'{prodgrupp}'");
        //}
        public static void Load_WorkCenter(string prodgrupp)
        {
            // Hämta WorkCenter i bakgrundstråd
            WorkCenter = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.WorkCenters>($"filter=Number Eq'{prodgrupp}'")
            ).Result;
        }

        //public static void Load_WorkCenters()
        //{
        //    WorkCenters = new Dictionary<string, string>();
        //    var listWorkcenter = Utilities.GetFromMonitor<Manufacturing.WorkCenters>("select=Number,Description", "orderby=Number");

        //    if (listWorkcenter is null)
        //       return;
        //    foreach (var workcenter in listWorkcenter)
        //        WorkCenters.Add(workcenter.Number, workcenter.Description);
        //}
        public static void Load_WorkCenters()
        {
            WorkCenters = new Dictionary<string, string>();

            // Hämta listan av WorkCenters i bakgrundstråd
            var listWorkcenter = Task.Run(() =>
                Utilities.GetFromMonitor<Manufacturing.WorkCenters>("select=Number,Description", "orderby=Number")
            ).Result;

            if (listWorkcenter is null)
                return;

            foreach (var workcenter in listWorkcenter)
                WorkCenters.Add(workcenter.Number, workcenter.Description);
        }

        //public void Load_Unit()
        //{
        //    if (Order is null)
        //        return;
        //    var partUnit = Utilities.GetOneFromMonitor<Common.PartUnitUsages>($"filter=PartId Eq'{Part.Id}'");
        //    Unit = Utilities.GetOneFromMonitor<Common.Units>($"filter=Number Eq'{partUnit.UnitId}'");
        //}
        public void Load_Unit()
        {
            if (Order is null)
                return;

            // Hämta partUnit i bakgrundstråd
            var partUnit = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.PartUnitUsages>($"filter=PartId Eq'{Part.Id}'")).Result;

            if (partUnit is null)
                return;

            // Hämta Unit i bakgrundstråd
            Unit = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.Units>($"filter=Number Eq'{partUnit.UnitId}'")).Result;
        }

        //public static void Load_DataTable_Measurpoints(string? OrderNr, string? Operation, bool IsOkWarnNoMeasurpoints)
        //{
        //    DataTable_Measurepoints = new DataTable();
        //    DataTable_Measurepoints.Columns.Add("Description");             //0
        //    DataTable_Measurepoints.Columns.Add("USL", typeof(double));     //1
        //    DataTable_Measurepoints.Columns.Add("UCL", typeof(double));     //2
        //    DataTable_Measurepoints.Columns.Add("NOM", typeof(double));     //3
        //    DataTable_Measurepoints.Columns.Add("LCL", typeof(double));     //4 
        //    DataTable_Measurepoints.Columns.Add("LSL", typeof(double));     //5
        //    if (Manage_WorkOperation.IsWorkoperationUsing_Measurepoints == false)
        //        return;
        //    var order = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=OrderNumber Eq'{OrderNr}'");
        //    if (order is null)
        //        return;

        //    var operations = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=ManufacturingOrderId Eq'{order.Id}' AND OperationNumber Eq'{Operation}'");
        //    if (operations is null)
        //        return;
        //    var ManufacturingOrderOperationControlDataRows = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperationControlDataRows>($"filter=ManufacturingOrderOperationId Eq'{operations.Id}'");
        //    if (ManufacturingOrderOperationControlDataRows is null)
        //    {
        //        if (!IsOkWarnNoMeasurpoints || OrderManagement.Order.IsOrderDone || factory == Factory.Holding)
        //            return;
        //        if (factory != Factory.Holding)
        //            Mail.NotifyCustomerServiceMissingMeasurepoints();
        //        return;
        //    }

        //    var FormTemplateSelectionRows = Utilities.GetOneFromMonitor<Common.FormTemplateSelectionRows>($"filter=FormTemplateId Eq'{ManufacturingOrderOperationControlDataRows.OverridenFormTemplateId}'");
        //    var Measurepoints = Utilities.GetFromMonitor<Common.FormTemplateRows>($"filter=FormTemplateSelectionRowId eq'{FormTemplateSelectionRows.Id}' AND " +
        //                                                                   "(LowerBoundary gt'0' OR UpperBoundary gt'0' OR Value gt'0' OR MinValue gt'0' OR MaxValue gt'0') AND Description neq'Concentricity' AND Description neq 'Amount (per bag/spool)'", "orderby=RowIndex");
        //    foreach (var mp in Measurepoints)
        //        DataTable_Measurepoints.Rows.Add(mp.Description, mp.Value + mp.MaxValue, mp.Value + mp.UpperBoundary, mp.Value, mp.Value + mp.LowerBoundary, mp.Value + mp.MinValue);

        //}
        public static void Load_DataTable_Measurpoints(string? OrderNr, string? Operation, bool IsOkWarnNoMeasurpoints)
        {
            DataTable_Measurepoints = new DataTable();
            DataTable_Measurepoints.Columns.Add("Description");             //0
            DataTable_Measurepoints.Columns.Add("USL", typeof(double));     //1
            DataTable_Measurepoints.Columns.Add("UCL", typeof(double));     //2
            DataTable_Measurepoints.Columns.Add("NOM", typeof(double));     //3
            DataTable_Measurepoints.Columns.Add("LCL", typeof(double));     //4 
            DataTable_Measurepoints.Columns.Add("LSL", typeof(double));     //5

            if (Manage_WorkOperation.IsWorkoperationUsing_Measurepoints == false)
                return;

            // Hämta order i bakgrundstråd
            var order = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=OrderNumber Eq'{OrderNr}'")
            ).Result;

            if (order is null)
                return;

            // Hämta operationen i bakgrundstråd
            var operations = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=ManufacturingOrderId Eq'{order.Id}' AND OperationNumber Eq'{Operation}'")
            ).Result;

            if (operations is null)
                return;

            // Hämta kontrollrader i bakgrundstråd
            var ManufacturingOrderOperationControlDataRows = Task.Run(() =>
                Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrderOperationControlDataRows>($"filter=ManufacturingOrderOperationId Eq'{operations.Id}'")
            ).Result;

            if (ManufacturingOrderOperationControlDataRows is null)
            {
                if (!IsOkWarnNoMeasurpoints || OrderManagement.Order.IsOrderDone || factory == Factory.Holding)
                    return;
                if (factory != Factory.Holding)
                    Mail.NotifyCustomerServiceMissingMeasurepoints();
                return;
            }

            // Hämta FormTemplateSelectionRows i bakgrundstråd
            var FormTemplateSelectionRows = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.FormTemplateSelectionRows>($"filter=FormTemplateId Eq'{ManufacturingOrderOperationControlDataRows.OverridenFormTemplateId}'")).Result;

            // Hämta Measurepoints i bakgrundstråd
            var Measurepoints = Task.Run(() =>
                Utilities.GetFromMonitor<Common.FormTemplateRows>($"filter=FormTemplateSelectionRowId eq'{FormTemplateSelectionRows.Id}' AND " +
                                                                  "(LowerBoundary gt'0' OR UpperBoundary gt'0' OR Value gt'0' OR MinValue gt'0' OR MaxValue gt'0') AND Description neq'Concentricity' AND Description neq 'Amount (per bag/spool)'", "orderby=RowIndex")).Result;

            foreach (var mp in Measurepoints)
                DataTable_Measurepoints.Rows.Add(
                    mp.Description,
                    mp.Value + mp.MaxValue,
                    mp.Value + mp.UpperBoundary,
                    mp.Value,
                    mp.Value + mp.LowerBoundary,
                    mp.Value + mp.MinValue
                );
        }


        public static void Fill_cb_ProdGrupp(ComboBox cb_ProdGrupp, ComboBox cb_ProdGrupp_Benämning)
        {
            foreach (var kvp in WorkCenters)
            {
                cb_ProdGrupp.Items.Add(kvp.Key);
                cb_ProdGrupp_Benämning.Items.Add(kvp.Value);
            }
            
        }

        //public static List<Main_OrderInformation.Operation_Description> List_Operations(string? ordernr, List<string>? ProdGroup)
        //{
        //    List<Main_OrderInformation.Operation_Description> ops = new();
        //    if (ProdGroup != null) 
        //        ProdGroup.Clear();
        //    if (Order != null)
        //    {
        //        var operations = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=ManufacturingOrderId Eq'{Order.Id}'", "orderby=OperationNumber ASC");
        //        foreach (var operation in operations)
        //        {
        //            var prodline = Utilities.GetOneFromMonitor<Manufacturing.WorkCenters>($"filter=Id Eq'{operation.WorkCenterId}'");
        //            ops.Add(new Main_OrderInformation.Operation_Description { Operation = operation.OperationNumber, Description = prodline.Description });
        //            if (Main_OrderInformation.List_ProdGroup != null)
        //                Main_OrderInformation.List_ProdGroup.Add(prodline.Number);
        //        }
        //    }


        //    //if (list_Operations.Count == 0)
        //    if (ops.Count == 0)
        //    {
        //        using var con = new SqlConnection(Database.cs_Protocol);
        //        const string query = @"SELECT Operation, ProdLine AS Description, ProdGroup FROM [Order].MainData WHERE OrderNr = @orderNr";

        //        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
        //        cmd.Parameters.AddWithValue("@orderNr", ordernr);
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            int.TryParse(reader["Operation"].ToString(), out int operation);
        //            string description = reader["Description"]?.ToString() ?? "";
        //            ops.Add(new Main_OrderInformation.Operation_Description{Operation = operation, Description = description});

        //            //list_Operations.Add($"{reader["Operation"]} - {reader["Description"]}");
        //            if (Main_OrderInformation.List_ProdGroup != null)
        //                Main_OrderInformation.List_ProdGroup.Add(reader["ProdGroup"].ToString());
        //        }
        //    }

        //    return ops;
        //}
        public static List<Main_OrderInformation.Operation_Description> List_Operations(string? ordernr, List<string>? ProdGroup)
        {
            List<Main_OrderInformation.Operation_Description> ops = new();

            ProdGroup?.Clear();

            if (Order != null)
            {
                // Hämta operations i bakgrundstråd
                var operations = Task.Run(() =>
                    Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=ManufacturingOrderId Eq'{Order.Id}'", "orderby=OperationNumber ASC")).Result;

                foreach (var operation in operations)
                {
                    // Hämta WorkCenter i bakgrundstråd
                    var prodline = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Manufacturing.WorkCenters>($"filter=Id Eq'{operation.WorkCenterId}'")).Result;

                    ops.Add(new Main_OrderInformation.Operation_Description
                    {
                        Operation = operation.OperationNumber,
                        Description = prodline.Description
                    });

                    if (Main_OrderInformation.List_ProdGroup != null)
                        Main_OrderInformation.List_ProdGroup.Add(prodline.Number);
                }
            }

            // Fallback till SQL om inga operations hittades
            if (ops.Count == 0)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"SELECT Operation, ProdLine AS Description, ProdGroup FROM [Order].MainData WHERE OrderNr = @orderNr";

                var cmd = new SqlCommand(query, con);
                ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderNr", ordernr);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int.TryParse(reader["Operation"].ToString(), out int operation);
                    string description = reader["Description"]?.ToString() ?? "";

                    ops.Add(new Main_OrderInformation.Operation_Description
                    {
                        Operation = operation,
                        Description = description
                    });

                    if (Main_OrderInformation.List_ProdGroup != null)
                        Main_OrderInformation.List_ProdGroup.Add(reader["ProdGroup"].ToString());
                }
            }

            return ops;
        }


        //public static void Fill_cb_Halvfabrikat_ArtikelNr(ComboBox cb)
        //{
        //    if (Order is null)
        //        return;
        //    var partIds = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderMaterials>("select=PartId", $"filter=ManufacturingOrderId Eq'{Order.Id}'");
        //    if (partIds is null)
        //    {
        //        MessageBox.Show($"{Order.Id}");
        //        return;
        //    }

        //    foreach (var partId in partIds)
        //    {
        //        var partNumber = Utilities.GetFromMonitor<Inventory.Parts>($"filter=Id Eq'{partId.PartId}'");
        //        cb.Items.Add(partNumber[0].PartNumber);
        //    }
        //}
        public static void Fill_cb_Halvfabrikat_ArtikelNr(ComboBox cb)
        {
            if (Order is null)
                return;

            // Hämta partIds i bakgrundstråd
            var partIds = Task.Run(() =>
                Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderMaterials>("select=PartId", $"filter=ManufacturingOrderId Eq'{Order.Id}'")).Result;
            if (partIds is null)
            {
                MessageBox.Show($"{Order.Id}");
                return;
            }

            foreach (var partId in partIds)
            {
                // Hämta parts i bakgrundstråd
                var parts = Task.Run(() =>
                    Utilities.GetFromMonitor<Inventory.Parts>($"filter=Id Eq'{partId.PartId}'")
                ).Result;

                if (parts.Count > 0)
                    cb.Items.Add(parts[0].PartNumber);
            }
        }

        //public static void Fill_ComboBox_Operation_Description(ComboBox cb, string artikelNr, List<int> list_Operation)
        //{
        //    var list_WorkCenterId = new List<long>();
        //    var list_Items = new List<string>();


        //    var part = Utilities.GetOneFromMonitor<Inventory.Parts>("select=Id", $"filter=PartNumber Eq'{artikelNr}'");
        //    var art_id = part.Id.ToString();

        //    var operations = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderOperations>("select=OperationNumber,WorkCenterId", $"filter=PartId Eq'{art_id}'", "orderby=OperationNumber");
        //    foreach (var operation in operations)
        //    {
        //       // if (!list_WorkCenterId.Contains(operation.WorkCenterId))
        //       // {
        //            list_WorkCenterId.Add(operation.WorkCenterId);
        //            list_Operation.Add(operation.OperationNumber); 
        //        //}
        //    }

        //    for (var i = 0; i < list_Operation.Count; i++)
        //    {
        //        var descriptions = Utilities.GetOneFromMonitor<Manufacturing.OperationRows>("select=Description", $"filter=OperationNumber Eq'{list_Operation[i]}' AND WorkCenterId Eq'{list_WorkCenterId[i]}'");
        //        if (descriptions != null)
        //            if (!list_Items.Contains($"{list_Operation[i]} - {descriptions.Description}"))
        //            {
        //                list_Items.Add($"{list_Operation[i]} - {descriptions.Description}");
        //                cb.Items.Add($"{list_Operation[i]} - {descriptions.Description}");
        //                CreateTestOrder.Benämning.Add($"{descriptions.Description}");
        //                CreateTestOrder.ProdGrupp.Add($"{list_WorkCenterId[i]}");
        //            }

        //    }
        //}
        public static void Fill_ComboBox_Operation_Description(ComboBox cb, string artikelNr, List<int> list_Operation)
        {
            var list_WorkCenterId = new List<long>();
            var list_Items = new List<string>();

            // Hämta part i bakgrundstråd
            var part = Task.Run(() =>
                Utilities.GetOneFromMonitor<Inventory.Parts>("select=Id", $"filter=PartNumber Eq'{artikelNr}'")).Result;

            if (part is null)
                return;

            var art_id = part.Id.ToString();

            // Hämta operations i bakgrundstråd
            var operations = Task.Run(() =>
                Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderOperations>(
                    "select=OperationNumber,WorkCenterId", $"filter=PartId Eq'{art_id}'", "orderby=OperationNumber")).Result;

            foreach (var operation in operations)
            {
                list_WorkCenterId.Add(operation.WorkCenterId);
                list_Operation.Add(operation.OperationNumber);
            }

            for (var i = 0; i < list_Operation.Count; i++)
            {
                // Hämta descriptions i bakgrundstråd
                var descriptions = Task.Run(() =>
                    Utilities.GetOneFromMonitor<Manufacturing.OperationRows>(
                        "select=Description",
                        $"filter=OperationNumber Eq'{list_Operation[i]}' AND WorkCenterId Eq'{list_WorkCenterId[i]}'"
                    )
                ).Result;

                if (descriptions != null)
                {
                    var itemText = $"{list_Operation[i]} - {descriptions.Description}";
                    if (!list_Items.Contains(itemText))
                    {
                        list_Items.Add(itemText);
                        cb.Items.Add(itemText);
                        CreateTestOrder.Benämning.Add(descriptions.Description);
                        CreateTestOrder.ProdGrupp.Add(list_WorkCenterId[i].ToString());
                    }
                }
            }
        }


        public static async Task Fill_ComboBox_PartCodes(ComboBox cb)
        {
            var partCodes = await Utilities.GetFromMonitor<Inventory.PartCodes>("select=Code,Description", "filter=Alias Eq 'TOOLS'");

            var list = partCodes?.ToList() ?? new List<Inventory.PartCodes>();

            cb.DataSource = list;
            cb.DisplayMember = "Description"; // vad användaren ser
            cb.ValueMember = "Code";
        }

        public static async Task Fill_ComboBox_Propertys(ComboBox cb)
        {
            var fieldGroup = await Utilities.GetOneFromMonitor<Common.ExtraFieldGroups>("filter=Name eq'Variables'");
            if (fieldGroup is null)
            {
                // eventuellt gör en tom lista eller returnera tidigt
                cb.DataSource = new List<Common.ExtraFieldTemplates>();
                return;
            }

            var properties = await Utilities.GetFromMonitor<Common.ExtraFieldTemplates>("select=Name,Identifier", $"filter=ParentId Eq'{fieldGroup.Id}'", "orderby=RowNumber");

            // Sätt DataSource på UI-tråden — om du redan är på UI-tråden (vanligt i Load) går det direkt
            var list = properties?.ToList() ?? new List<Common.ExtraFieldTemplates>();
            cb.DataSource = list;
            cb.DisplayMember = "Name";
            cb.ValueMember = "Identifier";
        }


        //public static List<string> List_All_Tools()
        //{
        //    // var list = new List<Equipment.Equipment.Tool>();
        //    var list = new List<string>();
        //    var sw = new Stopwatch();
        //    sw.Start();

        //    var partCodes = Utilities.GetFromMonitor<Inventory.PartCodes>($"filter=Alias Eq'TOOLS'");

        //    foreach (var partCode in partCodes)
        //    {
        //        var test = partCode.Alias;
        //        var test2 = partCode.Description;
        //        var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=PartCodeId Eq'{partCode.Id}'");

        //        foreach (var part in parts)
        //        {
        //            var idNr = Utilities.GetOneFromMonitor<Common.ExtraFields>($"filter=ParentId Eq'{part.Id}' AND Identifier Eq'P119'");
        //            if (idNr != null)
        //                list.Add(idNr.StringValue);

        //        }
        //    }
        //    sw.Stop();
        //    MessageBox.Show($"Antal verktyg: {list.Count}\nTid för hämtning: {sw.ElapsedMilliseconds} ms");

        //    return list;
        //}
        public static List<string> List_All_Tools()
        {
            var list = new List<string>();
            var sw = new Stopwatch();
            sw.Start();

            // Hämta partCodes i bakgrundstråd
            var partCodes = Task.Run(() =>
                Utilities.GetFromMonitor<Inventory.PartCodes>($"filter=Alias Eq'TOOLS'")).Result;

            foreach (var partCode in partCodes)
            {
                var parts = Task.Run(() =>
                    Utilities.GetFromMonitor<Inventory.Parts>($"filter=PartCodeId Eq'{partCode.Id}'")).Result;

                foreach (var part in parts)
                {
                    var idNr = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Common.ExtraFields>($"filter=ParentId Eq'{part.Id}' AND Identifier Eq'P119'")).Result;

                    if (idNr != null)
                        list.Add(idNr.StringValue);
                }
            }

            sw.Stop();
            MessageBox.Show($"Antal verktyg: {list.Count}\nTid för hämtning: {sw.ElapsedMilliseconds} ms");

            return list;
        }

        public static List<string> List_All_Tools_2()
        {
            var list = new List<string>();
            var sw = new Stopwatch();
            sw.Start();

            // Hämta partCodes i bakgrundstråd
            var partCodes = Task.Run(() => Utilities.GetFromMonitor<Inventory.PartCodes>($"filter=Alias Eq'TOOLS'")).Result;

            foreach (var partCode in partCodes)
            {
                var parts = Task.Run(() => Utilities.GetFromMonitor<Inventory.Parts>($"filter=PartCodeId eq'{partCode.Id}'",$"select=Id,PartNumber,ExtraDescription", "expand=ExtraFields")).Result;
                if (parts is null)
                    continue;
                foreach (var part in parts)
                {
                    foreach (var field in part.ExtraFields)
                    {
                        if (field.Identifier == "121")
                        {
                            if (field != null)
                                list.Add(field.StringValue);
                        }
                    }
                }

            }

            sw.Stop();
            MessageBox.Show($"Antal verktyg: {list.Count}\nTid för hämtning: {sw.ElapsedMilliseconds} ms");

            return list;
        }

        //public static void Fill_ComboBox_List_ExtraFields(ComboBox cb)
        //{
        //    var fieldGroup = Utilities.GetOneFromMonitor<Common.ExtraFieldGroups>("filter=Name eq'Verktyg'");
        //    if (fieldGroup is null)
        //        return;
        //    var fields = Utilities.GetFromMonitor<Common.ExtraFieldTemplates>($"filter=ParentId Eq'{fieldGroup.Id}'", "orderby=RowNumber");

            //    // Skapa en ny lista och lägg till en extra rad - Denna används om Användaren vill att man skall välja Typ(Description) istället för ID-nummer
            //    var extendedFields = new List<Common.ExtraFieldTemplates>
            //    {
            //        new Common.ExtraFieldTemplates { Name = "Description", Identifier = "Description" }
            //    };
            //    extendedFields.AddRange(fields);

            //    cb.DataSource = extendedFields;

            //    cb.DisplayMember = "Name"; // vad användaren ser
            //    cb.ValueMember = "Identifier";
            //}
        public static void Fill_ComboBox_List_ExtraFields(ComboBox cb)
        {
            // Hämta fieldGroup i bakgrundstråd
            var fieldGroup = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.ExtraFieldGroups>("filter=Name eq'Verktyg'")).Result;

            if (fieldGroup is null)
                return;

            // Hämta fields i bakgrundstråd
            var fields = Task.Run(() =>
                Utilities.GetFromMonitor<Common.ExtraFieldTemplates>($"filter=ParentId Eq'{fieldGroup.Id}'", "orderby=RowNumber")).Result;

            // Skapa en ny lista och lägg till en extra rad
            var extendedFields = new List<Common.ExtraFieldTemplates>
            {
                new Common.ExtraFieldTemplates { Name = "Description", Identifier = "Description" }
            };
            extendedFields.AddRange(fields);

            cb.DataSource = extendedFields;
            cb.DisplayMember = "Name";      // vad användaren ser
            cb.ValueMember = "Identifier";  // det underliggande värdet
        }


    }
}
