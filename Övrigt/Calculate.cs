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
            //DPP använder en ren sample‑standardavvikelse, medan QC lägger på en extra upplösnings‑/mätsystems­komponent som gör SD lite högre.
            //Därför blir SD, Pp och Ppk alltid något större i QC än i DPP trots identiska mätvärden.
            if (values is null) 
                return null;

            var clean = values.Where(v => v.HasValue).Select(v => v.Value).ToList();
            var n = clean.Count;

            // Sample SD kräver minst 2 observationer
            if (n < 2) return null;

            var mean = clean.Average();
            var sumSq = clean.Sum(v => Math.Pow(v - mean, 2));
            var variance = sumSq / (n - 1);  // ddof = 1
            var sigma = Math.Sqrt(variance);

            return sigma > 0.0 ? sigma : null;
        }

        public static double? Median(IList<double?> values)
        {
            if (values == null || values.Count == 0) 
                return double.NaN;
            var arr = values.ToArray();
            Array.Sort(arr);
            int n = arr.Length;
            if (n % 2 == 1) return arr[n / 2];
            return 0.5 * (arr[n / 2 - 1] + arr[n / 2]);
        }
        
        public static double? Pp(List<double?> values, double? USL, double? LSL)
        {
            if (values == null || !USL.HasValue || !LSL.HasValue)
                return null;

            double? s = StandardDeviation(values);
            if (s is null || s == 0.0) return null;

            double spec = USL.Value - LSL.Value;
            if (spec <= 0) return null;

            double pp = spec / (6.0 * s.Value);
            return pp;   // låt UI runda om det behövs
        }
        public static double? Ppk(List<double?> values, double? USL, double? LSL)
        {
            if (values == null || !USL.HasValue || !LSL.HasValue)
                return null;

            var clean = values.Where(v => v.HasValue).Select(v => v.Value).ToList();
            var n = clean.Count;
            if (n < 2) return null;

            var mean = clean.Average();
            var s = StandardDeviation(values);
            if (s is null || s == 0.0) return null;

            var cpu = (USL.Value - mean) / (3.0 * s.Value);
            var cpl = (mean - LSL.Value) / (3.0 * s.Value);

            return Math.Min(cpu, cpl);
        }

        public static double? PerformanceRatio(List<double?> values, double? USL, double? LSL)
        {
            var sigma = StandardDeviation(values);
            if (!USL.HasValue || !LSL.HasValue || sigma <= 0) return null;
            var spec = USL.Value - LSL.Value;
            if (spec <= 0) return null;

            var pr = (6.0 * sigma / spec) * 100.0;
            return pr;

        }
       
        public static double? UCL(double? avg, double? st_dev)
        {
            return avg + 2 * st_dev;
        }
        public static double? LCL(double? avg, double? st_dev)
        {
            return avg - 2 * st_dev;
        }
        
        
        public static double? Skewness(List<double?> values)
        {
            if (values == null) return null;

            // Ta bort nulls
            var clean = values.Where(v => v.HasValue).Select(v => v.Value).ToList();
            int n = clean.Count;

            if (n < 3)
                return double.NaN;

            double mean = clean.Average();

            // Sample standard deviation (ddof = 1)
            double s = Math.Sqrt(clean.Sum(v => Math.Pow(v - mean, 2)) / (n - 1));
            if (s == 0.0)
                return 0.0;

            // Sum of standardized cubed deviations
            double sumCubed = clean.Sum(v => Math.Pow((v - mean) / s, 3));

            // Bias‑corrected skewness (same as Python SciPy / Excel)
            double skew = (double)n * sumCubed / ((n - 1) * (n - 2));

            return skew;
        }
        public static double? Kurtosis(List<double?> values)
        {
            int n = values?.Count ?? 0;
            if (n < 4) return double.NaN;

            // Två-pass: först mean, sen centrala moment
            double? mean = 0.0;
            for (int i = 0; i < n; i++) mean += values[i];
            mean /= n;

            double? m2 = 0.0, m4 = 0.0;
            for (int i = 0; i < n; i++)
            {
                double? d = values[i] - mean;
                double? d2 = d * d;
                m2 += d2;
                m4 += d2 * d2; // d^4
            }

            // Sample-varians (n-1)
            double? s2 = m2 / (n - 1);
            if (s2 <= 0.0) return 0.0; // alla lika => ingen toppighet (definierat som 0 här)

            // "g2" = sample excess kurtosis utan bias-korrigering: g2 = (n*m4)/(m2^2) - 3
            double? g2 = (n * m4) / (m2 * m2) - 3.0;

            // Bias-korrigerad excess kurtosis (G2), kräver n >= 4:
            // G2 = ((n-1)/((n-2)*(n-3))) * ( (n+1)*g2 + 6 )
            double? G2 = ((n - 1.0) * ((n + 1.0) * g2 + 6.0)) / ((n - 2.0) * (n - 3.0));

            return G2;
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
