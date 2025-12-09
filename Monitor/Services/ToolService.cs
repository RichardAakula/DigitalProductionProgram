using DigitalProductionProgram.Monitor.GET;
using System.Collections.Generic;
using System.Diagnostics;

namespace DigitalProductionProgram.Monitor.Services
{
    internal class ToolService
    {
        public interface IHasId
        {
            long Id { get; }
        }


        //public static void Load_ExtraFieldTemplates(string category)
        //{
        //    var group = Utilities.GetOneFromMonitor<Common.ExtraFieldGroups>($"filter=Name Eq'{category}'");

        //    Monitor.ExtraFieldTemplate = Utilities.GetFromMonitor<Common.ExtraFieldTemplates>($"filter=ParentId Eq'{group.Id}'", "orderby=RowNumber");
        //}
        public static void Load_ExtraFieldTemplates(string category)
        {
            // Hämta grupp i bakgrundstråd
            var group = Task.Run(() =>
                Utilities.GetOneFromMonitor<Common.ExtraFieldGroups>($"filter=Name Eq'{category}'")).Result;

            if (group is null)
                return;

            // Hämta ExtraFieldTemplates i bakgrundstråd
            Monitor.ExtraFieldTemplate = Task.Run(() =>
                Utilities.GetFromMonitor<Common.ExtraFieldTemplates>($"filter=ParentId Eq'{group.Id}'", "orderby=RowNumber")).Result;
        }

        //public static List<string> List_Tools(string Description, string ExtraValue)
        //{
        //    Load_ExtraFieldTemplates("Verktyg");
        //    var list = new List<Equipment.Equipment.Tool>();

        //    var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(Description, '{Description}')");
        //    foreach (var part in parts)
        //    {
        //        var productRecords = Utilities.GetFromMonitor<Inventory.ProductRecords>($"filter=PartId Eq'{part.Id}' &$orderby=SerialNumber");
        //        foreach (var productRecord in productRecords)
        //        {
        //            list.Add(new Equipment.Equipment.Tool
        //            {
        //                IdNumber = productRecord.ChargeNumber,
        //                PartId = part.Id,
        //            });
        //        }
        //    }
        //    if (string.IsNullOrEmpty(ExtraValue))
        //        return list?.Where(x => x != null).Select(x => x.IdNumber).ToList() ?? new List<string>();

        //    //Lägger till extra info i listan för att underlätta för operatörerna
        //    var identifier = Monitor.ExtraFieldTemplate?.FirstOrDefault(t => t.Name == ExtraValue)?.Identifier;
        //    foreach (var tool in list)
        //    {
        //        if (identifier != null)
        //        {
        //            var extraFields = Utilities.GetOneFromMonitor<Common.ExtraFields>($"filter=ParentId Eq'{tool.PartId}' AND Identifier Eq'{identifier}'");
        //            double.TryParse(extraFields.StringValue, out double landLength);
        //            tool.Landlängd_nom = landLength;
        //            tool.IdNumber += $" : {landLength}";

        //        }
        //    }
        //    return list?.Where(x => x != null).Select(x => x.IdNumber).ToList() ?? new List<string>();
        //}
        public static List<string> List_Tools(string Description, string ExtraValue)
        {
            // Hämta ExtraFieldTemplates i bakgrundstråd
            Task.Run(() => Load_ExtraFieldTemplates("Verktyg")).Wait();

            var list = new List<Equipment.Equipment.Tool>();

            // Hämta parts i bakgrundstråd
            var parts = Task.Run(() =>
                Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(Description, '{Description}')")).Result;

            foreach (var part in parts)
            {
                // Hämta productRecords i bakgrundstråd
                var productRecords = Task.Run(() =>
                    Utilities.GetFromMonitor<Inventory.ProductRecords>($"filter=PartId Eq'{part.Id}' &$orderby=SerialNumber")).Result;

                foreach (var productRecord in productRecords)
                {
                    list.Add(new Equipment.Equipment.Tool
                    {
                        IdNumber = productRecord.ChargeNumber,
                        PartId = part.Id,
                    });
                }
            }

            if (string.IsNullOrEmpty(ExtraValue))
                return list?.Where(x => x != null).Select(x => x.IdNumber).ToList() ?? new List<string>();

            // Lägg till extra info i listan för att underlätta för operatörerna
            var identifier = Monitor.ExtraFieldTemplate?.FirstOrDefault(t => t.Name == ExtraValue)?.Identifier;

            foreach (var tool in list)
            {
                if (identifier != null)
                {
                    // Hämta extraFields i bakgrundstråd
                    var extraFields = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Common.ExtraFields>($"filter=ParentId Eq'{tool.PartId}' AND Identifier Eq'{identifier}'")).Result;

                    double.TryParse(extraFields?.StringValue, out double landLength);
                    tool.Landlängd_nom = landLength;
                    tool.IdNumber += $" : {landLength}";
                }
            }

            return list?.Where(x => x != null).Select(x => x.IdNumber).ToList() ?? new List<string>();
        }


       
        public static List<string?> List_Equipment<Table>(string columnName, string filter) where Table : DTO, IHasId, new()
        {
            // Hämta equipment i bakgrundstråd
            var equipment = Task.Run(() => Utilities.GetFromMonitor<Table>(filter)).Result;

            var list = new List<string?>();

            foreach (var item in equipment)
            {
                var prop = typeof(Table).GetProperty(columnName);
                var value = prop?.GetValue(item) as string;
                if (!list.Contains(value))
                    list.Add(value);
            }

            return list;
        }


        //public static void Add_Equipment(List<string> items, Type tableType, string partCode, string? identifier, string? property, int dataType)
        //{
        //    var partCodeId = Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Code Eq'{partCode}'")?.Id ?? 0;
        //    var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=PartCodeId eq'{partCodeId}'");
        //    if (string.IsNullOrEmpty(property))
        //    {
        //        foreach (var part in parts)
        //        {
        //            var idNr = Utilities.GetOneFromMonitor<Common.ExtraFields>($"filter=ParentId eq'{part.Id}' AND Identifier eq'{identifier}'");
        //            if (idNr == null)
        //                continue;
        //           // switch(dataType)
        //           // {
        //            var stringValue = idNr.StringValue;
        //            if (!string.IsNullOrEmpty(stringValue) && items.Contains(stringValue) == false)
        //                items.Add(stringValue);
        //            var decimalValue = idNr.DecimalValue?.ToString();
        //            if (!string.IsNullOrEmpty(decimalValue) && items.Contains(decimalValue) == false)
        //                items.Add(decimalValue);
        //            var intValue = idNr.IntegerValue?.ToString();
        //            if (!string.IsNullOrEmpty(intValue) && items.Contains(intValue) == false)
        //                items.Add(intValue);
        //                //case 1:
        //                //    var stringValue = idNr.StringValue;
        //                //    if (!string.IsNullOrEmpty(stringValue) && items.Contains(stringValue) == false)
        //                //        items.Add(stringValue);
        //                //    break;
        //                //case 0:
        //                //    var decimalValue = idNr.DecimalValue?.ToString();
        //                //    if (!string.IsNullOrEmpty(decimalValue) && items.Contains(decimalValue) == false)
        //                //        items.Add(decimalValue);
        //                break;
        //                //default:
        //                //    var intValue = idNr.IntegerValue?.ToString();
        //                //    if (!string.IsNullOrEmpty(intValue) && items.Contains(intValue) == false)
        //                //        items.Add(intValue);
        //                //    break;
        //            //}
        //        }
        //    }
        //    else
        //    {
        //        var properties = typeof(Inventory.Parts).GetProperty(property);
        //        foreach (var part in parts)
        //        {
        //            var value = properties.GetValue(part)?.ToString();
        //            if (!string.IsNullOrEmpty(value) && items.Contains(value) == false)
        //                items.Add(value);
        //        }
        //    }


        //    return;
        //    //var method = typeof(Utilities).GetMethod("GetFromMonitor").MakeGenericMethod(tableType);
        //    //var equipment = method.Invoke(null, new object[] { new[] { $"filter=PartCodeId eq'{partCodeId}'" } }) as IEnumerable<object>;

        //    //if (equipment is null)
        //    //    return;

        //    //foreach (var item in equipment)
        //    //{
        //    //    var prop = tableType.GetProperty(columnName);
        //    //    var value = prop?.GetValue(item) as string;
        //    //    if (!items.Contains(value))
        //    //        items.Add(value);
        //    //}
        //}

        //public static async Task Add_Equipment(List<string> items, Type tableType, string partCode, string? name, string? property, string? filterCodeText, int dataType, bool IsItemsMultipleColumns, string? secondaryName = null, string? secondaryCodeText = null)
        //{
        //    //UTAN EXPAND
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    Login_Monitor.TotalLoginAttemps = 0;
        //    Utilities.CounterMonitorRequests = 0;
        //    // Hämta PartCodeId asynkront
        //    var partCodeObj = Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Description Eq'{partCode}'");
        //    var partCodeId = partCodeObj?.Id ?? 0;

        //    // Hämta parts asynkront
        //    string filter = $"filter= IsNull(BlockedById)";
        //    filter += string.IsNullOrEmpty(filterCodeText) ? $"AND PartCodeId Eq'{partCodeId}'" : $"AND PartCodeId Eq'{partCodeId}' AND ExtraDescription Eq'{filterCodeText}'";

        //    var parts = Utilities.GetFromMonitor<Inventory.Parts>("select=Id,PartNumber,ExtraDescription,ExtraFields.StringValue,ExtraFields.IntegerValue,ExtraFields.DecimalValue", filter);

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        var properties = typeof(Inventory.Parts).GetProperty(property);
        //        foreach (var part in parts)
        //        {
        //            var value = properties?.GetValue(part)?.ToString();
        //            if (!string.IsNullOrEmpty(value) && !items.Contains(value))
        //                items.Add(value);
        //        }
        //        sw.Stop();
        //        MessageBox.Show($"Tid = {sw.ElapsedMilliseconds} \n" +
        //                        $"Antal MonitorFrågor = {Utilities.CounterMonitorRequests}. \n" +
        //                        $"Antal inloggning Monitor = {Login_Monitor.TotalLoginAttemps}");
        //        return;
        //    }

        //    if (parts == null)
        //        return;

        //    var tempList = new List<(decimal? SortValue, string DisplayValue)>();
        //    var addedSet = new HashSet<string>(); // För att undvika dubbletter
        //    foreach (var part in parts)
        //    {
        //        // Hämta ExtraFields asynkront
        //        var value = string.Empty;
        //        var identifier = Utilities.GetOneFromMonitor<Common.ExtraFieldTemplates>($"filter=Name Eq'{name}'");

        //        var idNr = Utilities.GetOneFromMonitor<Common.ExtraFields>("select=StringValue,DecimalValue,IntegerValue", $"filter=ParentId eq'{part.Id}' AND Identifier eq'{identifier.Identifier}'");

        //        if (idNr == null)
        //            continue;


        //        var stringValue = idNr.StringValue;
        //        if (!string.IsNullOrEmpty(stringValue))
        //            value = stringValue;

        //        if (idNr.DecimalValue.HasValue)
        //            value = idNr.DecimalValue.Value.ToString("0.00");

        //        var intValue = idNr.IntegerValue?.ToString();
        //        if (!string.IsNullOrEmpty(intValue))
        //            value = intValue;

        //        if (secondaryName != null && IsItemsMultipleColumns)
        //        {
        //            var secondaryIdentifier = Utilities.GetOneFromMonitor<Common.ExtraFieldTemplates>($"filter=Name Eq'{secondaryName}'");
        //            var secondaryIdNr = Utilities.GetOneFromMonitor<Common.ExtraFields>("select=StringValue,DecimalValue,IntegerValue", $"filter=ParentId eq'{part.Id}' AND Identifier eq'{secondaryIdentifier.Identifier}'");
        //            if (secondaryIdNr != null)
        //            {
        //                stringValue = secondaryIdNr.StringValue;
        //                if (!string.IsNullOrEmpty(stringValue))
        //                    value = value + " : " + stringValue;

        //                if (secondaryIdNr.DecimalValue.HasValue)
        //                    value = value + " : " + secondaryIdNr.DecimalValue.Value.ToString("0.0");

        //                intValue = secondaryIdNr.IntegerValue?.ToString();
        //                if (!string.IsNullOrEmpty(intValue))
        //                    value = value + " : " + intValue;
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(value) && addedSet.Add(value))
        //        {
        //            var firstPart = value.Split(':')[0].Trim();

        //            if (!decimal.TryParse(firstPart, out var parsed))
        //                parsed = decimal.MaxValue;

        //            tempList.Add((parsed, value));
        //        }

        //    }
        //    items.Clear();

        //    // Om du vill att N/A alltid ska vara först
        //    items.Add("N/A");

        //    foreach (var entry in tempList.OrderBy(x => x.SortValue))
        //    {
        //        items.Add(entry.DisplayValue);
        //    }
        //    sw.Stop();
        //    MessageBox.Show($"Tid = {sw.ElapsedMilliseconds} \n" +
        //                    $"Antal MonitorFrågor = {Utilities.CounterMonitorRequests}. \n" +
        //                    $"Antal inloggning Monitor = {Login_Monitor.TotalLoginAttemps}");
        //}

        public static async Task Add_Equipment(List<string> items, Type tableType, string partCode, string? name, string? property, string? filterCodeText, string sortMode, int dataType, bool IsItemsMultipleColumns, string? secondaryName = null, string? secondaryCodeText = null)
        {
            // MED EXPAND
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Login_Monitor.TotalLoginAttemps = 0;
            Utilities.CounterMonitorRequests = 0;

            // Hämta PartCodeId
            var partCodeObj = Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Description Eq'{partCode}'");
            var partCodeId = partCodeObj?.Id ?? 0;

            // Hämta parts
            string filter = "filter= IsNull(BlockedById)";
            filter += string.IsNullOrEmpty(filterCodeText)
                ? $"AND PartCodeId Eq'{partCodeId}'"
                : $"AND PartCodeId Eq'{partCodeId}' AND ExtraDescription Eq'{filterCodeText}'";

            // --------------------------------------
            // FALL 1: ingen ExtraField – ren property
            // --------------------------------------
            if (string.IsNullOrEmpty(name))
            {
                var parts = Utilities.GetFromMonitor<Inventory.Parts>("select=Id,PartNumber,ExtraDescription", filter,"orderby=ExtraDescription");

                var properties = typeof(Inventory.Parts).GetProperty(property);

                foreach (var part in parts)
                {
                    var value = properties?.GetValue(part)?.ToString();
                    if (!string.IsNullOrEmpty(value) && !items.Contains(value))
                        items.Add(value);
                }
            }

            // --------------------------------------
            // FALL 2: ExtraFields används
            // --------------------------------------
            else
            {
                var parts = Utilities.GetFromMonitor<Inventory.Parts>(
                    "select=Id,PartNumber,ExtraDescription,ExtraFields.Identifier,ExtraFields.StringValue,ExtraFields.IntegerValue,ExtraFields.DecimalValue",
                    "expand=ExtraFields",
                    filter);

                var identifier = Utilities.GetOneFromMonitor<Common.ExtraFieldTemplates>($"filter=Name Eq'{name}'");
                var secondaryIdentifier = Utilities.GetOneFromMonitor<Common.ExtraFieldTemplates>($"filter=Name Eq'{secondaryName}'");

                var tempList = new List<(string PrimaryText, decimal? PrimaryNumber, string SecondaryText)>();

                foreach (var part in parts)
                {
                    string primaryText = "";
                    decimal? primaryNumber = null;
                    string secondaryText = "";

                    // ----- PRIMARY FIELD -----
                    foreach (var field in part.ExtraFields)
                    {
                        if (field.Identifier != identifier.Identifier)
                            continue;

                        // Decimal
                        if (field.DecimalValue.HasValue)
                        {
                            primaryNumber = field.DecimalValue.Value;
                            primaryText = field.DecimalValue.Value.ToString("0.00");
                            break;
                        }

                        // Integer
                        if (field.IntegerValue.HasValue)
                        {
                            primaryNumber = field.IntegerValue.Value;
                            primaryText = field.IntegerValue.Value.ToString();
                            break;
                        }

                        // String
                        if (!string.IsNullOrEmpty(field.StringValue))
                        {
                            primaryText = field.StringValue;

                        }
                    }

                    // ----- SECONDARY FIELD -----
                    if (secondaryIdentifier != null)
                    {
                        foreach (var field in part.ExtraFields)
                        {
                            if (field.Identifier != secondaryIdentifier.Identifier)
                                continue;

                            if (!string.IsNullOrEmpty(field.StringValue))
                            {
                                secondaryText = field.StringValue;
                                break;
                            }

                            if (field.DecimalValue.HasValue)
                            {
                                secondaryText = field.DecimalValue.Value.ToString("0.0");
                                break;
                            }

                            if (field.IntegerValue.HasValue)
                            {
                                secondaryText = field.IntegerValue.Value.ToString();
                                break;
                            }
                        }
                    }

                    tempList.Add((primaryText, primaryNumber, secondaryText));
                }

                // --------- SORTERING ---------
                List<(string PrimaryText, decimal? PrimaryNumber, string SecondaryText)> ordered = null;

                switch(sortMode)
                {
                    case "numerical":
                    // Sortera numeriskt när möjligt
                    ordered = tempList
                        .OrderBy(x => x.PrimaryNumber.HasValue ? 0 : 1) // tal först
                        .ThenBy(x => x.PrimaryNumber)                  // sortera tal
                        .ThenBy(x => x.PrimaryText, StringComparer.CurrentCulture) // fallback text
                        .ToList();
                    break;
                    case "alpha":
                    // Ren alfabetisk sortering
                    ordered = tempList
                        .OrderBy(x => x.PrimaryText, StringComparer.CurrentCulture)
                        .ToList();
                    break;
                }


                // Bygg resultat
                foreach (var entry in ordered)
                {
                    string finalText = entry.SecondaryText == ""
                        ? entry.PrimaryText
                        : $"{entry.PrimaryText} : {entry.SecondaryText}";

                    if (!string.IsNullOrEmpty(finalText) && !items.Contains(finalText))
                        items.Add(finalText);
                }
            }


            sw.Stop();
            if (sw.ElapsedMilliseconds > 5000)
            {
                MessageBox.Show(
                    $"Tid = {sw.ElapsedMilliseconds} \n" +
                    $"Antal MonitorFrågor = {Utilities.CounterMonitorRequests}. \n" +
                    $"Antal inloggning Monitor = {Login_Monitor.TotalLoginAttemps}");
            }
        }






        //public static List<string?> List_Tools<Table1, Table2>(string templateName)
        //    where Table1 : DTO, IHasId, new()
        //    where Table2 : DTO, new()
        //{
        //    var templateID = Utilities.GetOneFromMonitor<Table1>($"filter=Description Eq'{templateName}'")?.Id ?? 0;

        //    var parts = Utilities.GetFromMonitor<Table2>($"filter=PartTemplateId Eq'{templateID}'");
        //    var list = new List<string?>();
        //    foreach (var part in parts)
        //    {
        //        var descriptionProp = typeof(Table2).GetProperty("Description");
        //        var value = descriptionProp?.GetValue(part) as string;
        //        if (!list.Contains(value))
        //            list.Add(value);
        //    }

        //    return list;
        //}


        //public static async Task Add_Equipment(List<string> items, Type tableType, string partCode, string? name, string? property, string? filterCodeText, int dataType, bool IsItemsMultipleColumns, string? secondaryName = null, string? secondaryCodeText = null)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    // Hämta PartCodeId asynkront
        //    var partCodeObj = await Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Code Eq'{partCode}'");
        //    var partCodeId = partCodeObj?.Id ?? 0;

        //    // Hämta parts asynkront
        //    string filter = string.Empty;
        //    filter = string.IsNullOrEmpty(filterCodeText) ? $"filter=PartCodeId eq'{partCodeId}'" : $"filter=PartCodeId eq'{partCodeId}' AND ExtraDescription Eq'{filterCodeText}'";

        //    var parts = await Utilities.GetFromMonitor<Inventory.Parts>("select=Id,PartNumber,ExtraDescription", filter);

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        var properties = typeof(Inventory.Parts).GetProperty(property);
        //        foreach (var part in parts)
        //        {
        //            var value = properties?.GetValue(part)?.ToString();
        //            if (!string.IsNullOrEmpty(value) && !items.Contains(value))
        //                items.Add(value);
        //        }

        //        return;
        //    }

        //    if (parts == null)
        //        return;

        //    // Bygg ett OData-filter manuellt
        //    var templateFilter = $"filter=Name eq '{name}'";
        //    if (!string.IsNullOrEmpty(secondaryName))
        //        templateFilter += $" or Name eq '{secondaryName}'";

        //    var templates = await Utilities.GetFromMonitor<Common.ExtraFieldTemplates>(templateFilter);

        //    var primaryIdentifier = templates.FirstOrDefault(t => t.Name == name)?.Identifier;
        //    var secondaryIdentifier = templates.FirstOrDefault(t => t.Name == secondaryName)?.Identifier;

        //    // Bygg lista av ParentIds
        //    var partIds = string.Join(" or ", parts.Select(p => $"ParentId eq '{p.Id}'"));
        //    var fieldFilter = $"filter={partIds}";

        //    // Hämta alla ExtraFields för dessa ParentIds
        //    var allExtraFields = await Utilities.GetFromMonitor<Common.ExtraFields>("select=ParentId,Identifier,StringValue,DecimalValue,IntegerValue", fieldFilter);

        //    // --- Lokalt arbete ---
        //    foreach (var part in parts)
        //    {
        //        var partFields = allExtraFields.Where(f => f.ParentId == part.Id).ToList();
        //        if (partFields.Count == 0) continue;

        //        var valueField = partFields.FirstOrDefault(f => f.Identifier == primaryIdentifier);
        //        var value = GetFieldValue(valueField);

        //        if (IsItemsMultipleColumns && secondaryName != null)
        //        {
        //            var secField = partFields.FirstOrDefault(f => f.Identifier == secondaryIdentifier);
        //            var secValue = GetFieldValue(secField);
        //            if (!string.IsNullOrEmpty(secValue))
        //                value = $"{value} : {secValue}";
        //        }

        //        if (!string.IsNullOrEmpty(value) && !items.Contains(value))
        //            items.Add(value);
        //    }

        //    // Hjälpmetod
        //    static string GetFieldValue(Common.ExtraFields? field)
        //    {
        //        if (field == null) return string.Empty;
        //        if (!string.IsNullOrEmpty(field.StringValue)) return field.StringValue;
        //        if (field.DecimalValue.HasValue) return field.DecimalValue.ToString();
        //        if (field.IntegerValue.HasValue) return field.IntegerValue.ToString();
        //        return string.Empty;
        //    }




        //    sw.Stop();
        //    MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        //}


        public static List<string?> List_Tools<Table1, Table2>(string templateName)
            where Table1 : DTO, IHasId, new()
            where Table2 : DTO, new()
        {
            // Hämta templateID i bakgrundstråd
            var templateID = Task.Run(() =>
                Utilities.GetOneFromMonitor<Table1>($"filter=Description Eq'{templateName}'")?.Id ?? 0
            ).Result;

            // Hämta parts i bakgrundstråd
            var parts = Task.Run(() =>
                Utilities.GetFromMonitor<Table2>($"filter=PartTemplateId Eq'{templateID}'")
            ).Result;

            var list = new List<string?>();

            foreach (var part in parts)
            {
                var descriptionProp = typeof(Table2).GetProperty("Description");
                var value = descriptionProp?.GetValue(part) as string;
                if (!list.Contains(value))
                    list.Add(value);
            }

            return list;
        }


    }
}
