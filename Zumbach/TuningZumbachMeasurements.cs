using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Measure;

using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Zumbach
{

    internal class TuningZumbachMeasurements
    {
        private static MeasureWithZumbach MeasureWithZumbach;
        private static readonly List<int> List_ZumbachID = new List<int>();


        private static bool IsOkDeleteMeasurepoint(int serie, double value, double value_Before, double value_After)
        {
            //Om värdet är mindre än LSL så tas det inte bort
            if (value < MeasureWithZumbach.ExpOD_LSL)
                //if (value > avg + 0.05 || value < avg - 0.05)
                return false;
            //Om värdet är ganska likt det föregående eller nästa värde så är det ok att radera det
            if (value < value_Before + 0.005 && value > value_Before - 0.005)
                return true;
            if (value < value_After + 0.005 && value > value_After - 0.005)
                return true;
            return false;
        }
        private static int MinMeasurePoints_Measurement(Chart chartZumbach)
        {
            //Om det ej finns 3 positioner så returneras 0, annars returneras minsta antal mätpunkter på dom 3 positioner
            var min = int.MaxValue;
            foreach (var serie in chartZumbach.Series)
            {
                if (serie.Points.Count == 0)
                    return 0;
                if (serie.Points.Count < min)
                    min = serie.Points.Count;
            }

            return min;
        }
        private static int MaxMeasurePoints_Measurement(Chart chartZumbach)
        {
            var max = int.MinValue;
            foreach (var serie in chartZumbach.Series)
            {
                if (serie.Points.Count > 0)
                    if (serie.Points.Count > max)
                        max = serie.Points.Count;
            }
            return max;
        }
        private static int TotalDeletedMeasurepoints;
        private static int TotalIterations;
        private static int totalt_Antal_Mätpunkter_Checkade;
        public static bool IsTuningCharts;
        private static readonly bool IsExitTuningCharts = false;
        private static bool IsDiscarded(int bag)
        {
            var search = $"Bag = {bag}";
            var rows = MeasureWithZumbach.ZumbachData.Select(search);
            if (rows.Length == 0)
                return true;

            return bool.TryParse(rows[0]["Discarded"].ToString(), out var IsDiscarded) == false || IsDiscarded;
        }

       

        public static void TuneOrder(MeasureWithZumbach zumbach)
        {
            MeasureWithZumbach = zumbach;
            TotalDeletedMeasurepoints = 0;
            TotalIterations = 0;
            IsTuningCharts = true;
            
            Looping_ThroughMeasurements(1, MeasureWithZumbach.chartZumbach);

            if (List_ZumbachID.Count > 0)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "DELETE FROM Zumbach.Data WHERE ID IN (" + string.Join(",", List_ZumbachID.ToArray()) + ")";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.ExecuteScalar();
            }

            if (Person.Role == "SuperAdmin")
            {
                InfoText.Show($"ArtikelNr - {Order.PartNumber}\n\n" +

                              $"Antal Raderade värden totalt på ordern = {TotalDeletedMeasurepoints} st\n" +
                              $"Antal Iterationer totalt = {TotalIterations} st\n" +
                              $"Antal Mätningar = {totalt_Antal_Mätpunkter_Checkade} st\n\n",
                    CustomColors.InfoText_Color.Info, "Info", zumbach);
            }

            IsTuningCharts = false;
        }

        private static void Looping_ThroughMeasurements(int activeMeasurement, Chart chartZumbach)
        {
            if (Zumbach.DataTable_Measurements.Rows.Count < 1)
                return;
            var IsOkTuneData = true;
            //Loop # 2 Loopar igenom varje mätning
            for (var measurement = activeMeasurement; measurement < Zumbach.DataTable_Measurements.Rows.Count + 1; measurement++)
            {
                if (chartZumbach.Series[0].Points.Count == chartZumbach.Series[1].Points.Count && chartZumbach.Series[1].Points.Count == chartZumbach.Series[2].Points.Count)
                {
                    MeasureWithZumbach.Change_Measurement(1, "btn_Up", null);
                    //MeasureWithZumbach.Refresh();
                    continue;
                }
                    
                if (IsDiscarded(measurement) == false)
                {
                    totalt_Antal_Mätpunkter_Checkade++;
                    CheckingForSimilarData(measurement, ref IsOkTuneData, chartZumbach);
                    if (IsOkTuneData) 
                        OptimizePositions_StartEnd(chartZumbach);
                    MeasureWithZumbach.Refresh();

                    //Kommer en varning om det skiljer mer än 150 mätpunkter mellan positionerna
                    if (IsOkTuneData)
                    {
                        if (MaxMeasurePoints_Measurement(chartZumbach) - MinMeasurePoints_Measurement(chartZumbach) > 150 && MinMeasurePoints_Measurement(chartZumbach) < 100)
                        {
                            InfoText.Question($"{LanguageManager.GetString("tuneZumbachData_Measurement")}: #{measurement}\n" +
                                          $"{LanguageManager.GetString("tuneZumbachData_7")} {MaxMeasurePoints_Measurement(chartZumbach) - MinMeasurePoints_Measurement(chartZumbach)} {LanguageManager.GetString("tuneZumbachData_8")}",
                                CustomColors.InfoText_Color.Warning, "Warning!", null);
                            if (InfoText.answer == InfoText.Answer.No)
                                IsOkTuneData = false;
                            _ = Log.Activity.Stop($"Zumbach - > 125 punkter mellan minsta och största mätning - Operatör svarat {InfoText.answer}");
                        }
                    }

                    if (IsOkTuneData)
                    {
                        Looping_ThroughPositions(MinMeasurePoints_Measurement(chartZumbach),  measurement, chartZumbach);
                        MeasureWithZumbach.Refresh();
                    }

                    IsOkTuneData = true;
                }

                MeasureWithZumbach.Change_Measurement(1, "btn_Up", null);
                MeasureWithZumbach.Refresh();
            }

        }
        private static void Looping_ThroughPositions(int min_Points, int measureMent, Chart chartZumbach)
        {
            //Loopar igenom alla serier
            for (var serie = 0; serie < 3; serie++)
            {
                if (chartZumbach.Series[serie].Points.Count > min_Points)   //Kontrollerar att den aktiva Serien inte är minst
                    TuningPosition(serie, min_Points, measureMent, chartZumbach);

                chartZumbach.Refresh();
            }
        }
        private static void TuningPosition(int serie, int min_Points, int measureMent, Chart chartZumbach)
        {
            var Problem_Iterations = 0;
            var ctr = 0;
           
            var rnd = new Random();
            //Loop #3 - Går igenom alla mätpunkter i dom serier som är längre än den kortaste
            if (min_Points == 0)
                return;
            do
            {
                if (IsExitTuningCharts)
                    break;
                // Problem_Iterations++;
                TotalIterations++;
                if (chartZumbach.Series[serie].Points.Count > min_Points)
                {
                    var value = chartZumbach.Series[serie].Points[ctr].YValues[0];
                    if (ctr > 0 && ctr < chartZumbach.Series[serie].Points.Count)
                    {
                        var value_Before = chartZumbach.Series[serie].Points[ctr - 1].YValues[0];
                        var value_After = chartZumbach.Series[serie].Points[ctr + 1].YValues[0];
                        if (IsOkDeleteMeasurepoint(serie, value, value_Before, value_After))
                        {
                            var row = MeasureWithZumbach.ZumbachData.Select($"OD = '{value}' AND Bag = {measureMent} AND Position = {serie + 1}");
                            var found_Value = false;
                            foreach (var t in row)
                            {
                                var tempID = int.Parse(t["ID"].ToString());
                                if (found_Value)
                                    break;
                                if (!List_ZumbachID.Contains(tempID))
                                {
                                    List_ZumbachID.Add(tempID);
                                    found_Value = true;
                                }
                            }
                            if (found_Value == false)
                                goto Slut;

                            chartZumbach.Invoke(new Action<int, int, Chart>(Invoke_Zumbach_Remove_Point), serie, ctr, chartZumbach);
                            chartZumbach.Refresh();

                        Slut:;

                        }
                        else
                            Problem_Iterations++;
                    }
                    ctr += rnd.Next(5, 10);
                    if (ctr > chartZumbach.Series[serie].Points.Count - 2)
                        ctr = 0;
                }
                if (Problem_Iterations > 15000)
                {
                    InfoText.Show($"{LanguageManager.GetString("tuneZumbachData_9")}", CustomColors.InfoText_Color.Bad, "Info", chartZumbach);
                    break;
                }
            } while (chartZumbach.Series[serie].Points.Count > min_Points);
        }
       
        private static void OptimizePositions_StartEnd(Chart chartZumbach)
        {
            var antal_DataPunkter_Slutet = 0;
            var antal_DataPunkter_Början = 0;

            var total_DataPunkter = chartZumbach.Series[0].Points.Count + chartZumbach.Series[1].Points.Count + chartZumbach.Series[2].Points.Count;
            for (var i = 0; i < 3; i++)
            {
                var decrease_Row = 1;
                var first_Index = 0;
                // int[]     //Går att snabba upp detta genom att ta bort uppdatering av chartZumbach och istället bara använda dt_Zumbach
                if (chartZumbach.Series[i].Points.Count > 20)
                {
                    antal_DataPunkter_Slutet += chartZumbach.Series[i].Points.Count;
                    bool IsDone;
                    do
                    {
                        var OD_first = chartZumbach.Series[i].Points[0].YValues[0];
                        var OD_first_1 = chartZumbach.Series[i].Points[1].YValues[0];
                        var OD_first_2 = chartZumbach.Series[i].Points[2].YValues[0];
                        //Raderar onaturligt varierande data i början av mätning som kan orsakas när operatör för in slangen i mätstationen
                        if (OD_first > (OD_first_1 + 0.02) || OD_first < (OD_first_1 - 0.02) || OD_first > (OD_first_2 + 0.02) || OD_first < (OD_first_2 - 0.02))
                        {
                            if (first_Index < chartZumbach.Series[i].Points.Count)
                                chartZumbach.Series[i].Points.RemoveAt(first_Index);
                            else
                            {
                                IsDone = true;
                                continue;
                            }

                            int zd_Row;
                            if (MeasureWithZumbach.Measurement < 2)
                                zd_Row = antal_DataPunkter_Början;
                            else
                                zd_Row = int.Parse(Zumbach.DataTable_Measurements.Rows[MeasureWithZumbach.Measurement - 2][1].ToString()) + antal_DataPunkter_Början;

                            var tempID = int.Parse(MeasureWithZumbach.ZumbachData.Rows[zd_Row]["ID"].ToString());
                            List_ZumbachID.Add(tempID);
                            first_Index++;
                            TotalIterations++;
                        }


                        var OD_last = chartZumbach.Series[i].Points[chartZumbach.Series[i].Points.Count - 1].YValues[0];
                        var OD_last_1 = chartZumbach.Series[i].Points[chartZumbach.Series[i].Points.Count - 2].YValues[0];
                        var OD_last_2 = chartZumbach.Series[i].Points[chartZumbach.Series[i].Points.Count - 3].YValues[0];

                        if (OD_last > OD_last_1 + 0.02 || OD_last < OD_last_1 - 0.02 || OD_last > OD_last_2 + 0.02 || OD_last < OD_last_2 - 0.02)
                        {

                            chartZumbach.Series[i].Points.RemoveAt(chartZumbach.Series[i].Points.Count - 1);
                            var test = int.Parse(Zumbach.DataTable_Measurements.Rows[MeasureWithZumbach.Measurement - 1][1].ToString());
                            var zd_Row = test - (total_DataPunkter - antal_DataPunkter_Slutet);
                            var tempID = int.Parse(MeasureWithZumbach.ZumbachData.Rows[zd_Row - decrease_Row]["ID"].ToString());  //-1 kan bli fel om en punkt har raderats från serien tidigare?
                            List_ZumbachID.Add(tempID);

                            TotalIterations++;
                            decrease_Row++;
                            IsDone = false;
                        }
                        else
                            IsDone = true;


                    } while (IsDone == false);
                    antal_DataPunkter_Början += chartZumbach.Series[i].Points.Count;
                }
            }
        }
        private static void CheckingForSimilarData(int measureMent, ref bool IsOkTuneData, Chart chartZumbach)
        {
            for (var serie = 0; serie < 3; serie++)
            {
                var ctr_Liknande_Point = 0;
                if (IsOkTuneData == false)
                    return;
                //Skrotar mätning om det saknas för mycket data på någon position
                if (chartZumbach.Series[serie].Points.Count < 100 && chartZumbach.Series[serie].Points.Count > 0)
                {
                    InfoText.Question($"{LanguageManager.GetString("tuneZumbachData_Measurement")}: {measureMent}\n" +
                                  $"Position {serie + 1}:\n" +
                                  $"{LanguageManager.GetString("tuneZumbachData_1")} {chartZumbach.Series[serie].Points.Count} {LanguageManager.GetString("tuneZumbachData_Measurepoints")}." +
                                  $"{LanguageManager.GetString("tuneZumbachData_2")}\n" +
                                  $"{LanguageManager.GetString("tuneZumbachData_3")}", CustomColors.InfoText_Color.Info, "Warning!");
                    if (InfoText.answer == InfoText.Answer.Yes)
                    {
                        MeasureWithZumbach.DiscardMeasureMent(measureMent);
                        IsOkTuneData = false;
                        break;
                    }
                }

                //Loopar igenom hela serien och letar efter data som har fastnat på samma OD
                for (var point = 1; point < chartZumbach.Series[serie].Points.Count; point++)
                {
                    ctr_Liknande_Point = chartZumbach.Series[serie].Points[point].YValues[0] == chartZumbach.Series[serie].Points[point - 1].YValues[0] ? ctr_Liknande_Point + 1 : 0;

                    if (ctr_Liknande_Point > 60)
                    {
                        InfoText.Question($"{LanguageManager.GetString("tuneZumbachData_Measurement")}: {measureMent}\n" +
                                      $"Position {serie + 1}\n" +
                                      $"{LanguageManager.GetString("tuneZumbachData_4")} OD = {chartZumbach.Series[serie].Points[point].YValues[0]}\n" +
                                      $"{LanguageManager.GetString("tuneZumbachData_3")}", CustomColors.InfoText_Color.Info, "Warning!");
                        if (InfoText.answer == InfoText.Answer.Yes)
                        {
                            MeasureWithZumbach.DiscardMeasureMent(measureMent);
                            IsOkTuneData = false;
                            break;
                        }

                        return;
                    }
                }
            }
        }

        private static void Invoke_Zumbach_Remove_Point(int serie, int ctr, Chart chartZumbach)
        {
            chartZumbach.Series[serie].Points.RemoveAt(ctr);
        }
    }
}
