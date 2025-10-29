using System.Diagnostics;
using DigitalProductionProgram.Monitor.GET;

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


        //public static List<string?> List_Equipment<Table>(string columnName, string filter) where Table : DTO, IHasId, new()
        //{
        //    var equipment = Utilities.GetFromMonitor<Table>(filter);
        //    var list = new List<string?>();
        //    foreach (var item in equipment)
        //    {
        //        var prop = typeof(Table).GetProperty(columnName);
        //        var value = prop?.GetValue(item) as string;
        //        if (!list.Contains(value))
        //            list.Add(value);
        //    }

        //    return list;
        //}
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

        public static async Task Add_Equipment(List<string> items, Type tableType, string partCode, string? identifier, string? property, string? filterCodeText, int dataType)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Hämta PartCodeId asynkront
            var partCodeObj = await Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Code Eq'{partCode}'");
            var partCodeId = partCodeObj?.Id ?? 0;

            // Hämta parts asynkront
            string filter = string.Empty;
            filter = string.IsNullOrEmpty(filterCodeText) ? $"filter=PartCodeId eq'{partCodeId}'" : $"filter=PartCodeId eq'{partCodeId}' AND ExtraDescription Eq'{filterCodeText}'";

            var parts = await Utilities.GetFromMonitor<Inventory.Parts>("select=Id,PartNumber,ExtraDescription", filter);

            if (parts == null)
                return;

            if (string.IsNullOrEmpty(property))
            {
                foreach (var part in parts)
                {
                    // Hämta ExtraFields asynkront
                    var idNr = await Utilities.GetOneFromMonitor<Common.ExtraFields>("select=StringValue,DecimalValue,IntegerValue", $"filter=ParentId eq'{part.Id}' AND Identifier eq'{identifier}'");

                    if (idNr == null)
                        continue;

                    var stringValue = idNr.StringValue;
                    if (!string.IsNullOrEmpty(stringValue) && !items.Contains(stringValue))
                        items.Add(stringValue);

                    var decimalValue = idNr.DecimalValue?.ToString();
                    if (!string.IsNullOrEmpty(decimalValue) && !items.Contains(decimalValue))
                        items.Add(decimalValue);

                    var intValue = idNr.IntegerValue?.ToString();
                    if (!string.IsNullOrEmpty(intValue) && !items.Contains(intValue))
                        items.Add(intValue);
                }
            }
            else
            {
                var properties = typeof(Inventory.Parts).GetProperty(property);
                foreach (var part in parts)
                {
                    var value = properties?.GetValue(part)?.ToString();
                    if (!string.IsNullOrEmpty(value) && !items.Contains(value))
                        items.Add(value);
                }
            }

            sw.Stop();
            MessageBox.Show(sw.ElapsedMilliseconds.ToString());
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
