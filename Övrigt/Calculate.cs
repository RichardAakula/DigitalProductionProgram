using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.Measure;

namespace DigitalProductionProgram.Övrigt
{
    public class Calculate
    {
        public static void Reset_Values()
        {
            Measurement_1.x1 = 0;
            Measurement_1.y1 = 0;
            Measurement_1.x2 = 0;
            Measurement_1.y2 = 0;
            Measurement_1.x3 = 0;
            Measurement_1.y3 = 0;
            Measurement_1.x4 = 0;
            Measurement_1.y4 = 0;
            Measurement_1.x5 = 0;
            Measurement_1.y5 = 0;
            Measurement_1.x6 = 0;
            Measurement_1.x7 = 0;
            Measurement_1.y7 = 0;
            Measurement_2.x1 = 0;
            Measurement_2.y1 = 0;
            Measurement_2.x2 = 0;
            Measurement_2.y2 = 0;
            Measurement_2.x3 = 0;
            Measurement_2.y3 = 0;
            Measurement_2.x4 = 0;
            Measurement_2.y4 = 0;
            Measurement_2.x5 = 0;
            Measurement_2.y5 = 0;
            Measurement_2.x6 = 0;
            Measurement_2.y6 = 0;
            Measurement_2.x7 = 0;
            Measurement_2.y7 = 0;

        }
        public static class Measurement_1
        {
            public static double x1, x2, x3, x4, x5, x6, x7;
            public static double y1, y2, y3, y4, y5, y6, y7;

            public static double Wall1 => x1;
            public static double? Wall2 => x3 - x2;
            public static double? Wall3 => y1;
            public static double? Wall4 => y3 - y2;
            public static double? ID_1Layer => (x2 - x1 + (y2 - y1)) / 2 / 1000;
            public static double? ID_2Layer => (x3 - x2 + (y3 - y2)) / 2 / 1000;
            public static double? ID_3Layer => (x4 - x3 + (y4 - y3)) / 2 / 1000;
            public static double? OD_1Layer => (x3 + y3) / 2 / 1000;
            public static double? OD_2Layer => (x5 + y5) / 2 / 1000;
            public static double? OD_3Layer => (x7 + y7) / 2 / 1000;
            public static double? OD_2Layer_Layer1 => (x4 - x1 + y4 - y1) / 2 / 1000;
            public static double? OD_3Layer_Layer1 => (x5 - x2 + y5 - y2) / 2 / 1000;
            public static double? OD_3Layer_Layer2 => (x6 - x1 + y6 - y1) / 2 / 1000;

            public static double? Wall_1Layer => (Wall1 + Wall2 + Wall3 + Wall4) / 4 / 1000;
            public static double? Wall_2Layer => (x2 + (x5 - x3) + y2 + (y5 - y3)) / 4 / 1000;

            public static double? Wall_3Layer => (x3 + (x7 - x4) + y3 + (y7 - y4)) / 4 / 1000;
            public static double? Wall_2Layer_Layer1 => (x1 + (x5 - x4) + (y1) + (y5 - y4)) / 4 / 1000;
            public static double? Wall_2Layer_Layer2 => (x2 - x1 + (x4 - x3) + (y2 - y1) + (y4 - y3)) / 4 / 1000;

            public static double? Wall_3Layer_Layer1 => (x3 - x2 + (x5 - x4) + (y3 - y2) + (y5 - y4)) / 4 / 1000;
            public static double? Wall_3Layer_Layer2
            {
                get
                {
                    double? Wall1 = x2 - x1;
                    double? Wall2 = x6 - x5;
                    double? Wall3 = y2 - y1;
                    double? Wall4 = y6 - y5;

                    return (Wall1 + Wall2 + Wall3 + Wall4) / 4 / 1000;
                }
            }
            public static double? Wall_3Layer_Layer3
            {
                get
                {
                    double? Wall1 = x1;
                    double? Wall2 = x7 - x6;
                    double? Wall3 = y1;
                    double? Wall4 = y7 - y6;

                    return (Wall1 + Wall2 + Wall3 + Wall4) / 4 / 1000;
                }
            }

            public static double? Oval_1Layer => (Math.Max(x3, y3) - Math.Min(x3, y3)) / 1000;
            public static double? Oval_2Layer => (Math.Max(x5, y5) - Math.Min(x5, y5)) / 1000;
            public static double? Oval_3Layer => (Math.Max(x7, y7) - Math.Min(x7, y7)) / 1000;

            public static double? RunOut_1Layer => (Math.Max(Math.Max(x1, x3 - x2), Math.Max(y1, y3 - y2)) - Math.Min(Math.Min(x1, x3 - x2), Math.Min(y1, y3 - y2))) / 1000;
            public static double? RunOut_2Layer => (Math.Max(Math.Max(x2, x5 - x3), Math.Max(y2, y5 - y3)) - Math.Min(Math.Min(x2, x5 - x3), Math.Min(y2, y5 - y3))) / 1000;

            public static double? RunOut_3Layer => (Math.Max(Math.Max(x3, x7 - x4), Math.Max(y3, y7 - y4)) - Math.Min(Math.Min(x3, x7 - x4), Math.Min(y3, y7 - y4))) / 1000;
            public static double? RunOut_2Layer_Layer1 => (Math.Max(Math.Max(x1, x5 - x4), Math.Max(y1, y5 - y4)) - Math.Min(Math.Min(x1, x5 - x4), Math.Min(y1, y5 - y4))) / 1000;
            public static double? RunOut_2Layer_Layer2 => (Math.Max(Math.Max(x2 - x1, x4 - x3), Math.Max(y2 - y1, y4 - y3)) - Math.Min(Math.Min(x2 - x1, x4 - x3), Math.Min(y2 - y1, y4 - y3))) / 1000;


            public static double? RunOut_3Layer_Layer1 => (Math.Max(Math.Max(x3 - x2, x5 - x4), Math.Max(y3 - y2, y5 - y4)) - Math.Min(Math.Min(x3 - x2, x5 - x4), Math.Min(y3 - y2, y5 - y4))) / 1000;
            public static double? RunOut_3_Layer_Layer2 => (Math.Max(Math.Max(x2 - x1, x6 - x5), Math.Max(y2 - y1, y6 - y5)) - Math.Min(Math.Min(x2 - x1, x6 - x5), Math.Min(y2 - y1, y6 - y5))) / 1000;
            public static double? RunOut_3_Layer_Layer3 => (Math.Max(Math.Max(x1, x7 - x6), Math.Max(y1, y7 - y6)) - Math.Min(Math.Min(x1, x7 - x6), Math.Min(y1, y7 - y6))) / 1000;

            public static double? Conc => Math.Min(Math.Min(x1, x3 - x2), Math.Min(y1, y3 - y2)) / Math.Max(Math.Max(x1, x3 - x2), Math.Max(y1, y3 - y2)) * 100;
        }

        public static class Measurement_2
        {
            public static double x1, x2, x3, x4, x5, x6, x7;
            public static double y1, y2, y3, y4, y5, y6, y7;

            public static double Wall1 => x1;
            public static double? Wall2 => x3 - x2;
            public static double? Wall3 => y1;
            public static double? Wall4 => y3 - y2;

            public static double? ID => (x2 - x1 + (y2 - y1)) / 2 / 1000;
            public static double? OD => (x3 + y3) / 2 / 1000;
            public static double? Wall => (Wall1 + Wall2 + Wall3 + Wall4) / 4 / 1000;
        }



        public static double? StandardDeviation(List<double?> values)
        {
            double? ctr = values.Count;
            if (values.Count < 1)
                return 0;
            var avg = values.Average();
            var sum = values.Sum(d => (d - avg) * (d - avg));

            double? std_Dev = Math.Sqrt((double)sum / (double)ctr);
            return std_Dev;
        }
        public static double? Cp(List<double?> values, double? USL, double? LSL)
        {
            var stdDev = StandardDeviation(values);
            var cp = (USL - LSL) / (6 * stdDev);
            if (cp != null) 
                return Math.Round(cp.Value, 2);
            return null;
        }
        public static double? Cpk(List<double?> values, double? USL, double? LSL)
        {
            var cpl = Cpl(values, LSL);
            var cpu = Cpu(values, USL);
            if (USL == 0)
                if (cpl != null)
                    return Math.Round(cpl.Value, 2);
            if (LSL == 0)
                if (cpu != null)
                    return Math.Round(cpu.Value, 2);
            if (cpl != null)
                if (cpu != null)
                    return Math.Round(Math.Min(cpl.Value, cpu.Value), 2);
            return null;
        }
        public static double? Cpl(List<double?> values, double? LSL)
        {
            if (values.Count > 0)
            {
                var avg = values.Average();
                var cpl = (avg - LSL) / (3 * StandardDeviation(values));
                return cpl;
            }

            return 0;
        }
        public static double? Cpu(List<double?> values, double? USL)
        {
            if (values.Count > 0)
            {
                var avg = values.Average();
                var cpu = (USL - avg) / (3 * StandardDeviation(values));
                return cpu;
            }

            return 0;
        }
        public static double? UCL(double? avg, double? st_dev)
        {
            return avg + 2 * st_dev;
        }
        public static double? LCL(double? avg, double? st_dev)
        {
            return avg - 2 * st_dev;
        }

        public class Diagram
        {
            public static double min_Value(Chart chart, int serie, int min, double max)
            {
                var value = double.MaxValue;
                for (var i = min; i < max-1; i++)
                {
                    if (chart.Series[serie].Points.Count > 0 && i < chart.Series[serie].Points.Count)
                        if (chart.Series[serie].Points[i].YValues[0] < value)
                            value = chart.Series[serie].Points[i].YValues[0];
                }
                return value;
            }
            public static int min_Serie(double min_Position_1, double min_Position_2, double min_Position_3)
            {
                if (min_Position_1 < Math.Min(min_Position_2, min_Position_3))
                    return 1;
                if (min_Position_2 < Math.Min(min_Position_1, min_Position_3))
                    return 2;
                if (min_Position_3 < Math.Min(min_Position_1, min_Position_2))
                    return 3;

                return 0;
            }
        }

    }
}
