using DigitalProductionProgram.Monitor.GET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalProductionProgram.Monitor.Services
{
    internal class ToolService
    {
        public interface IHasId
        {
            long Id { get; }
        }


        public static void Load_ExtraFieldTemplates(string category)
        {
            var group = Utilities.GetOneFromMonitor<Common.ExtraFieldGroups>($"filter=Name Eq'{category}'");
            Monitor.ExtraFieldTemplate = Utilities.GetFromMonitor<Common.ExtraFieldTemplates>($"filter=ParentId Eq'{group.Id}'", "orderby=RowNumber");
        }

        public static List<string> List_Tools(string Description, string ExtraValue)
        {
            Load_ExtraFieldTemplates("Verktyg");
            var list = new List<Equipment.Equipment.Tool>();

            var parts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=startswith(Description, '{Description}')");
            foreach (var part in parts)
            {
                var productRecords = Utilities.GetFromMonitor<Inventory.ProductRecords>($"filter=PartId Eq'{part.Id}' &$orderby=SerialNumber");
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

            //Lägger till extra info i listan för att underlätta för operatörerna
            var identifier = Monitor.ExtraFieldTemplate?.FirstOrDefault(t => t.Name == ExtraValue)?.Identifier;
            foreach (var tool in list)
            {
                if (identifier != null)
                {
                    var extraFields = Utilities.GetOneFromMonitor<Common.ExtraFields>($"filter=ParentId Eq'{tool.PartId}' AND Identifier Eq'{identifier}'");
                    double.TryParse(extraFields.StringValue, out double landLength);
                    tool.Landlängd_nom = landLength;
                    tool.IdNumber += $" : {landLength}";

                }
            }
            return list?.Where(x => x != null).Select(x => x.IdNumber).ToList() ?? new List<string>();
        }

        public static List<string?> List_Equipment<Table>(string columnName, string filter) where Table : DTO, IHasId, new()
        {
            var equipment = Utilities.GetFromMonitor<Table>(filter);
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

        public static void Add_Equipment(List<string> items, Type tableType, string partCode, string columnName, string filter)
        {
            var partID = Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Description Eq'{partCode}'")?.Id ?? 0;

            var method = typeof(Utilities).GetMethod("GetFromMonitor").MakeGenericMethod(tableType);
            var equipment = method.Invoke(null, new object[] { new[] { $"filter=PartCodeId eq'{partID}'" } }) as IEnumerable<object>;

            if (equipment is null)
                return;
           
            foreach (var item in equipment)
            {
                var prop = tableType.GetProperty(columnName);
                var value = prop?.GetValue(item) as string;
                if (!items.Contains(value))
                    items.Add(value);
            }
        }






        public static List<string?> List_Tools<Table1, Table2>(string templateName)
            where Table1 : DTO, IHasId, new()
            where Table2 : DTO, new()
        {
            var templateID = Utilities.GetOneFromMonitor<Table1>($"filter=Description Eq'{templateName}'")?.Id ?? 0;

            var parts = Utilities.GetFromMonitor<Table2>($"filter=PartTemplateId Eq'{templateID}'");
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
