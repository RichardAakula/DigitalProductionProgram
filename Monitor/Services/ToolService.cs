using DigitalProductionProgram.Monitor.GET;
using System.Collections.Generic;
using System.Diagnostics;
using DigitalProductionProgram.OrderManagement;

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


       
        private static decimal? ExtractDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            // Matcha tal som 2,50 eller 2.50 eller 2
            var m = System.Text.RegularExpressions.Regex.Match(text, @"\d+([.,]\d+)?");

            if (!m.Success)
                return null;

            var numStr = m.Value.Replace('.', ',');
            if (decimal.TryParse(numStr, out var d))
                return d;

            return null;
        }
        public static async Task Add_Equipment(List<string> items, Type tableType, string partCode, string? name, string? property, string? filterCodeText, string sortMode, int dataType, bool IsItemsMultipleColumns, string? secondaryName = null, string? secondaryCodeText = null)
        {
            // MED EXPAND
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Login_Monitor.TotalLoginAttemps = 0;
            Utilities.CounterMonitorRequests = 0;

            //Denna är här så att det inte blir problem i början ifall nån order blir kvar med fel mall så hämtas ALLA verktyg istället för FEP's och då tar det extremt länge att ladda alla verktyg
            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Extrudering_FEP && string.IsNullOrEmpty(filterCodeText))
            {
                if (partCode == "TIPS")
                    filterCodeText = "Kanyler FEP";
                if (partCode == "DIES")
                    filterCodeText = "Munstycken FEP";
            }


            // Hämta PartCodeId
            var partCodeObj = Utilities.GetOneFromMonitor<Inventory.PartCodes>($"filter=Description Eq'{partCode}'"); //10 ms
            var partCodeId = partCodeObj?.Id ?? 0;

            // Hämta parts
            string filter = "filter=IsNull(BlockedById) ";
            filter += string.IsNullOrEmpty(filterCodeText)
                ? $"AND PartCodeId Eq'{partCodeId}'"
                : $"AND PartCodeId Eq'{partCodeId}' AND ExtraDescription Eq'{filterCodeText}'";

            // --------------------------------------
            // FALL 1: ingen ExtraField – ren property
            // --------------------------------------
            if (string.IsNullOrEmpty(name))
            {
                var parts = Utilities.GetFromMonitor<Inventory.Parts>("select=ExtraDescription", filter, "orderby=ExtraDescription");//Id,PartNumber,

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
               
                var parts = Utilities.GetFromMonitor<Inventory.Parts>("select=ExtraDescription,ExtraFields.Identifier,ExtraFields.StringValue,ExtraFields.IntegerValue,ExtraFields.DecimalValue", "expand=ExtraFields", filter);    //2000-5000 ms

                var identifier = Utilities.GetOneFromMonitor<Common.ExtraFieldTemplates>($"filter=Name Eq'{name}'");    //10ms
                var secondaryIdentifier = Utilities.GetOneFromMonitor<Common.ExtraFieldTemplates>($"filter=Name Eq'{secondaryName}'");  //10ms

                var tempList = new List<(string PrimaryText, decimal? PrimaryNumber, string SecondaryText)>();
                
                foreach (var part in parts) //10ms
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
                            primaryText = field.StringValue;
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

                switch (sortMode)
                {
                    case "numerical":
                        {
                            ordered = tempList
                                .OrderBy(x => ExtractDecimal(x.PrimaryText) == null ? 1 : 0)   // poster utan tal sist
                                .ThenBy(x => ExtractDecimal(x.PrimaryText))                    // sortera på talet
                                .ThenBy(x => x.PrimaryText, StringComparer.CurrentCulture)     // fallback för lika värden
                                .ToList();
                        }
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

           // if (sw.ElapsedMilliseconds > 5000)
            //{
            //    MessageBox.Show(
            //        $"Tid = {sw.ElapsedMilliseconds} \n" +
            //        $"Antal MonitorFrågor = {Utilities.CounterMonitorRequests}. \n" +
            //        $"Antal inloggning Monitor = {Login_Monitor.TotalLoginAttemps}");
            //}
        }





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
