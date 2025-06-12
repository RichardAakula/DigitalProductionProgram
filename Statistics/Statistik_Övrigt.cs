using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using static DigitalProductionProgram.OrderManagement.Teman;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;


namespace DigitalProductionProgram.Statistics
{
    /// <summary>
    /// För att Lägga till statistik
    /// 1...Lägg till rubrik i rubriker_Chart
    /// 2...Skapa DataTable i rätt kategori
    /// 3...Lägg till DataTable i dt_All
    /// 4...Lägg till beskrivning av datatable m.m. i list_Series_Names
    /// 5...Ladda DataTable
    /// 6...Lägg till DataTable in Load_All_DataTables
    /// </summary>
    /// 
    public partial class Statistik_Övrigt : Form
    {
        private Point? prevPosition;
        private readonly ToolTip tooltip = new ToolTip();
        private int ctr_Queries;
        private static string thisYear => $"{DateTime.Now.Year}";

        private static string lastYear
        {
            get
            {
                var year = DateTime.Now.Year;
                return $"{year - 1}";
            }
        }
        private static string two_Year_Ago
        {
            get
            {
                var year = DateTime.Now.Year;
                return $"{year - 2}";
            }
        }
        private static Dictionary<string, string> Month
        {
            get
            {
                var day = new Dictionary<string, string>
                {
                    {"1",  "Jan"},
                    {"2",  "Feb"},
                    {"3",  "Mars"  },
                    {"4",  "April" },
                    {"5",  "Maj"},
                    {"6",  "Juni"},
                    {"7",  "Juli"},
                    {"8",  "Aug" },
                    {"9",  "Sep"},
                    {"10", "Okt"},
                    {"11", "Nov"},
                    {"12", "Dec"}
                };

                return day;
            }
        }
       

        #region 1...Lägg till rubrik i rubriker_Chart
        private static string[] rubriker_Chart
        {
            get
            {
                string[] strings = {
                    "Extrudering TEF: Visar antal mätningar som gjorts per år.",
                    "Extrudering TEF: Visar hur många mätningar/skift det gjorts per år.",
                    "Extrudering TEF: Visar hur många mätningar det görs per månad.",
                    "Extrudering TEF: Visar antal mätningar som gjorts varje dag sen början.",
                    "Extrudering TEF: Antal mätningar som gjorts/dag senaste veckan",
                    "Extrudering TEF: Visar vilken veckodag som det mäts mest på.",
                    "Extrudering FEP: Visar antal mätningar som gjorts per år.",
                    "Extrudering FEP: Visar hur många mätningar/skift det gjorts per år.",
                    "Extrudering FEP: Visar hur många mätningar det görs per månad.",
                    "Extrudering FEP: Visar antal mätningar som gjorts varje dag sen början.",
                    "Extrudering FEP: Antal mätningar som gjorts/dag senaste veckan",
                    "Extrudering FEP: Visar vilken veckodag som det mäts mest på.",
                    "Krympslang: Visar antal mätningar som gjorts per år.",
                    "Krympslang: Visar hur många mätningar/skift det gjorts per år.",
                    "Krympslang: Visar hur många mätningar det görs per månad.",
                    "Krympslang: Visar antal mätningar som gjorts varje dag sen början.",
                    "Krympslang: Antal mätningar som gjorts/dag senaste veckan",
                    "Krympslang: Visar vilken veckodag som det mäts mest på.",
                    "Slipning: Visar antal mätningar som gjorts per år.",
                    "Slipning: Visar hur många mätningar/skift det gjorts per år.",
                    "Slipning: Visar hur många mätningar det görs per månad.",
                    "Slipning: Visar antal mätningar som gjorts varje dag sen början.",
                    "Slipning: Antal mätningar som gjorts/dag senaste veckan",
                    "Slipning: Visar vilken veckodag som det mäts mest på.",
                    "Svetsning: Visar antal mätningar som gjorts per år.",
                    "Svetsning: Visar hur många mätningar/skift det gjorts per år.",
                    "Svetsning: Visar hur många mätningar det görs per månad.",
                    "Svetsning: Visar antal mätningar som gjorts varje dag sen början.",
                    "Svetsning: Antal mätningar som gjorts/dag senaste veckan",
                    "Svetsning: Visar vilken veckodag som det mäts mest på.",
                    "Visar hur många ordrar det körts/år.",
                    "Visar hur många ordrar det körts/månad.",
                    "Visar hur många ordrar det körts i varje linje.",
                    "Visar hur många ordrar det körts i varje linje/år.",
                    "Visar hur många ordrar det körts senaste månad i varje linje.",
                    "Medeltid i timmar per order.",
                    "Medeltid i timmar per order per år.",
                    "Extrudering: Medelrumstemperatur vid varje linje.",
                    "Extrudering: Medelrumsfuktighet vid varje linje.",
                    "Extrudering: Medeldraghastighet vid varje linje.",
                    "Extrudering: Medeltorktemperatur vid varje linje.",
                    "Extrudering: Medeltemperatur på extruderhuvudet för varje linje.",
                    "Extrudering: Medeltemperatur på munstycket för varje linje.",
                    "Antal gjorda mätningar per linje.",
                    "Antal gjorda mätningar per linje per år.",
                    "Extrudering: MedelID på operatörernas mätningar för alla linjer.",
                    "Extrudering: Antal mätningar gjorda på olika storlekar OD på slang.",
                    "Krympslang: Antal mätningar gjorda på olika storlekar OD på slang.",
                    "Extrudering: Max-, Min- och Medelvärde på slangens OD som är kört med dom vanligaste verktygskombinationerna.",
                    "Krympslang: Visar hur många körningar det är gjorda med dom vanligaste krympslangsrören.",
                    "Hur många bokstäver skrivs i kommentarerna i snitt per order på dom olika avdelningarna.",
                    "Aktivitet: Visar dom 10 mest aktiva personerna senaste 7 dagarna.",
                    "Aktivitet per avdelning.",
                    "Teman",
                    "Laddtider för olika sekvenser i programmet.",
                    "Laddtider för dom 7 senaste dagarna.",
                    "Laddtider för olika linjer.",
                    
                };

                return strings;
            }
        }
        #endregion

        #region 2...DataTables
        private List<string>? List_ProdLinje { get; set; }
        //Mätningar - Extrudering TEF - 6st
        private DataTable? dt_Mätningar_Extrudering_TEF_Year { get; set; }
        private DataTable? dt_Mätningar_Extrudering_TEF_Year_Skift { get; set; }
        private DataTable? dt_Mätningar_Extrudering_TEF_Month { get; set; }
        private DataTable? dt_Mätningar_Extrudering_TEF_Day { get; set; }
        private DataTable? dt_Mätningar_Extrudering_TEF_LastWeek { get; set; }
        private DataTable? dt_Mätningar_Extrudering_TEF_DayOfWeek { get; set; }
        //Mätningar - Extrudering FEP - 6st
        private DataTable? dt_Mätningar_Extrudering_FEP_Year { get; set; }
        private DataTable? dt_Mätningar_Extrudering_FEP_Year_Skift { get; set; }
        private DataTable? dt_Mätningar_Extrudering_FEP_Month { get; set; }
        private DataTable? dt_Mätningar_Extrudering_FEP_Day { get; set; }
        private DataTable? dt_Mätningar_Extrudering_FEP_LastWeek { get; set; }
        private DataTable? dt_Mätningar_Extrudering_FEP_DayOfWeek { get; set; }
        //Mätningar - Krympslang - 6st
        private DataTable? dt_Mätningar_Krymp_Year { get; set; }
        private DataTable? dt_Mätningar_Krymp_Year_Skift { get; set; }
        private DataTable? dt_Mätningar_Krymp_Month { get; set; }
        private DataTable? dt_Mätningar_Krymp_Day { get; set; }
        private DataTable? dt_Mätningar_Krymp_LastWeek { get; set; }
        private DataTable? dt_Mätningar_Krymp_DayOfWeek { get; set; }
        //Mätningar - Slipning - 6st
        private DataTable? dt_Mätningar_Slipning_Year { get; set; }
        private DataTable? dt_Mätningar_Slipning_Year_Skift { get; set; }
        private DataTable? dt_Mätningar_Slipning_Month { get; set; }
        private DataTable? dt_Mätningar_Slipning_Day { get; set; }
        private DataTable? dt_Mätningar_Slipning_LastWeek { get; set; }
        private DataTable? dt_Mätningar_Slipning_DayOfWeek { get; set; }
        //Mätningar - Svetsning - 6st
        private DataTable? dt_Mätningar_Svetsning_Year { get; set; }
        private DataTable? dt_Mätningar_Svetsning_Year_Skift { get; set; }
        private DataTable? dt_Mätningar_Svetsning_Month { get; set; }
        private DataTable? dt_Mätningar_Svetsning_Day { get; set; }
        private DataTable? dt_Mätningar_Svetsning_LastWeek { get; set; }
        private DataTable? dt_Mätningar_Svetsning_DayOfWeek { get; set; }
        //Ordrar - 7st
        private DataTable? dt_Ordrar_Year { get; set; }
        private DataTable? dt_Ordrar_Month { get; set; }
        private DataTable? dt_Ordrar_ProdLinje { get; set; }
        private DataTable? dt_Ordrar_ProdLinje_This_Year { get; set; }
        private DataTable? dt_Ordrar_ProdLinje_This_Month { get; set; }
        private DataTable? dt_Ordrar_Tid_Order_ProdLinje { get; set; }
        private DataTable? dt_Ordrar_Tid_Order_ProdLinje_Year { get; set; }
        //Processkort - Extrudering - 6st
        private DataTable? dt_RumsTemp_ProdLinje { get; set; }
        private DataTable? dt_RumsFukt_ProdLinje { get; set; }
        private DataTable? dt_Dragh_ProdLinje { get; set; }
        private DataTable? dt_TorkTemp_ProdLinje { get; set; }
        private DataTable? dt_Temp_Zon_Huvud_ProdLinje { get; set; }
        private DataTable? dt_Temp_Zon_Munst_ProdLinje { get; set; }
        //Övrigt - 14st
        private DataTable? dt_Mätningar_ProdLinje { get; set; }
        private DataTable? dt_Mätningar_ProdLinje_Year { get; set; }
        private DataTable? dt_Mätningar_Extr_ProdLinje_AvgID { get; set; }
        private DataTable? dt_Mätningar_Extr_OD_Grupp { get; set; }
        private DataTable? dt_Mätningar_Krymp_OD_Grupp { get; set; }
        private DataTable? dt_Mätningar_Verktyg_OD { get; set; }
        private DataTable? dt_RörFaktor_Krymp_QS { get; set; }
        private DataTable? dt_Bokstäver { get; set; }
        private DataTable? dt_Aktivitet_Top_10_Användare { get; set; }
        private DataTable? dt_Aktivitet_Avdelning { get; set; }
        private DataTable? dt_Teman { get; set; }
        #endregion
        
        #region 3...Lägg till DataTable i dt_All
        private DataTable?[] dt_All
        {
            get
            {
                DataTable?[] dt = {
                    //Mätningar - Extrudering TEF - 6st
                    dt_Mätningar_Extrudering_TEF_Year,
                    dt_Mätningar_Extrudering_TEF_Year_Skift,
                    dt_Mätningar_Extrudering_TEF_Month,
                    dt_Mätningar_Extrudering_TEF_Day,
                    dt_Mätningar_Extrudering_TEF_LastWeek,
                    dt_Mätningar_Extrudering_TEF_DayOfWeek,
                    //Mätningar - Extrudering FEP - 6st
                    dt_Mätningar_Extrudering_FEP_Year,
                    dt_Mätningar_Extrudering_FEP_Year_Skift,
                    dt_Mätningar_Extrudering_FEP_Month,
                    dt_Mätningar_Extrudering_FEP_Day,
                    dt_Mätningar_Extrudering_FEP_LastWeek,
                    dt_Mätningar_Extrudering_FEP_DayOfWeek,
                    //Mätningar - Krympslang - 6st
                    dt_Mätningar_Krymp_Year,
                    dt_Mätningar_Krymp_Year_Skift,
                    dt_Mätningar_Krymp_Month,
                    dt_Mätningar_Krymp_Day,
                    dt_Mätningar_Krymp_LastWeek,
                    dt_Mätningar_Krymp_DayOfWeek,
                    //Mätningar - Slipning - 6st
                    dt_Mätningar_Slipning_Year,
                    dt_Mätningar_Slipning_Year_Skift,
                    dt_Mätningar_Slipning_Month,
                    dt_Mätningar_Slipning_Day,
                    dt_Mätningar_Slipning_LastWeek,
                    dt_Mätningar_Slipning_DayOfWeek,
                    //Mätningar - Svetsning - 6st
                    dt_Mätningar_Svetsning_Year,
                    dt_Mätningar_Svetsning_Year_Skift,
                    dt_Mätningar_Svetsning_Month,
                    dt_Mätningar_Svetsning_Day,
                    dt_Mätningar_Svetsning_LastWeek,
                    dt_Mätningar_Svetsning_DayOfWeek,
                    //Ordrar - 7st
                    dt_Ordrar_Year,
                    dt_Ordrar_Month,
                    dt_Ordrar_ProdLinje,
                    dt_Ordrar_ProdLinje_This_Year,
                    dt_Ordrar_ProdLinje_This_Month,
                    dt_Ordrar_Tid_Order_ProdLinje,
                    dt_Ordrar_Tid_Order_ProdLinje_Year,
                    //Processkort - Extrudering - 6st
                    dt_RumsTemp_ProdLinje,
                    dt_RumsFukt_ProdLinje,
                    dt_Dragh_ProdLinje,
                    dt_TorkTemp_ProdLinje,
                    dt_Temp_Zon_Huvud_ProdLinje,
                    dt_Temp_Zon_Munst_ProdLinje,
                    //Övrigt - 14st
                    dt_Mätningar_ProdLinje,
                    dt_Mätningar_ProdLinje_Year,
                    dt_Mätningar_Extr_ProdLinje_AvgID,
                    dt_Mätningar_Extr_OD_Grupp,
                    dt_Mätningar_Krymp_OD_Grupp,
                    dt_Mätningar_Verktyg_OD,
                    dt_RörFaktor_Krymp_QS,
                    dt_Bokstäver,
                    dt_Aktivitet_Top_10_Användare,
                    dt_Aktivitet_Avdelning,
                    dt_Teman,
                };
                return dt;
            }
        }
        #endregion

        #region 4...Lägg till beskrivning av datatable m.m. i list_Series_Names
        private string[,] list_Series_Names
        {
            get
            {
                string[,] names =
                {
                    //Rubrik - Namn                                 X-Axel

                    //Mätningar - Extrudering TEF - 6st
                    { "Mätningar / År Extrudering TEF",                     "År",                                       "Antal mätningar"       },
                    { "Mätningar / År / Skift Extrudering TEF",             "År",                                       "Antal mätningar"       },
                    { "Mätningar / Månad Extrudering TEF",                  "Månad",                                    "Antal mätningar"       },
                    { "Mätningar / Dag Extrudering TEF",                    "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Dag senaste vecka Extrudering TEF",      "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Veckodag Extrudering TEF",               "Veckodag",                                 "Antal mätningar"       },
                     //Mätningar - Extrudering FEP - 6st
                    { "Mätningar / År Extrudering FEP",                     "År",                                       "Antal mätningar"       },
                    { "Mätningar / År / Skift Extrudering FEP",             "År",                                       "Antal mätningar"       },
                    { "Mätningar / Månad Extrudering FEP",                  "Månad",                                    "Antal mätningar"       },
                    { "Mätningar / Dag Extrudering FEP",                    "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Dag senaste vecka Extrudering FEP",      "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Veckodag Extrudering FEP",               "Veckodag",                                 "Antal mätningar"       },
                    //Mätningar - Krympslang - 6st
                    { "Mätningar / År Krympslang",                          "År",                                       "Antal mätningar"       },
                    { "Mätningar / År / Skift Krympslang",                  "År",                                       "Antal mätningar"       },
                    { "Mätningar / Månad Krympslang",                       "Månad",                                    "Antal mätningar"       },
                    { "Mätningar / Dag Krympslang",                         "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Dag senaste vecka Krympslang",           "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Veckodag Krympslang",                    "Veckodag",                                 "Antal mätningar"       },
                    //Mätningar - Slipning - 6st
                    { "Mätningar / År Slipning",                            "År",                                       "Antal mätningar"       },
                    { "Mätningar / År / Skift Slipning",                    "År",                                       "Antal mätningar"       },
                    { "Mätningar / Månad Slipning",                         "Månad",                                    "Antal mätningar"       },
                    { "Mätningar / Dag Slipning",                           "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Dag senaste vecka Slipning",             "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Veckodag Slipning",                      "Veckodag",                                 "Antal mätningar"       },
                    //Mätningar - Svetsning - 6st
                    { "Mätningar / År Svetsning",                           "År",                                       "Antal mätningar"       },
                    { "Mätningar / År/Skift Svetsning",                     "År",                                       "Antal mätningar"       },
                    { "Mätningar / Månad Svetsning",                        "Månad",                                    "Antal mätningar"       },
                    { "Mätningar / Dag Svetsning",                          "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Dag senaste vecka Svetsning",            "Dag",                                      "Antal mätningar"       },
                    { "Mätningar / Veckodag Svetsning",                     "Veckodag",                                 "Antal mätningar"       },
                    //Ordrar - 7st
                    { "Ordrar / År",                                        "År",                                       "Antal Ordrar"          },
                    { "Ordrar / Månad",                                     "Månad",                                    "Antal Ordrar"          },
                    { "Ordrar / Linje",                                     "ProduktionsLinje",                         "Antal Ordrar"          },
                    { "Ordrar / Linje År",                                  "ProduktionsLinje",                         "Antal Ordrar"          },
                    { "Ordrar / Linje denna månad",                         "ProduktionsLinje",                         "Antal Ordrar"          },
                    { "Ordrar - Tid(h) / Order / Linje",                    "ProduktionsLinje",                         "Timmar/Order"          },
                    { "Ordrar - Tid(h) / Order / År / Linje",               "ProduktionsLinje",                         "Timmar/Order"          },
                    //Processkort - Extrudering - 6st
                    { "Medel RumsTemp / Linje",                             "ProduktionsLinje",                         "Grader °"              },
                    { "Medel RumsFuktighet / Linje",                        "ProduktionsLinje",                         "Fuktighet %"           },
                    { "Medel Draghastighet / Linje",                        "ProduktionsLinje",                         "m/min"                 },
                    { "Medel TorkTemperatur / Linje",                       "ProduktionsLinje",                         "Grader °"              },
                    { "Medel Temp Zon Huvud / Linje",                       "ProduktionsLinje",                         "Grader °"              },
                    { "Medel Temp Zon Munst. / Linje",                      "ProduktionsLinje",                         "Grader °"              },
                    //Övrigt - 14st
                    { "Mätningar / Linje",                                  "ProduktionsLinje",                         "Antal Mätningar"       },
                    { "Mätningar / Linje År",                               "ProduktionsLinje",                         "Antal Mätningar"       },
                    { "Medel ID / Linje",                                   "ProduktionsLinje",                         "ID mm"                 },
                    { "Mätningar OD storlekar - Extrudering",               "OD",                                       "mm"                    },
                    { "Mätningar OD storlekar - Krympslang",                "OD",                                       "mm"                    },
                    { "Mätningar OD Verktygskombinationer - Extrudering",   "Antal mätningar - Munstycke / Kärna",      "OD mm"                 },
                    { "Användning Krympslangsrör",                          "Rör ID Dimension",                         "Antal ordrar körda"    },
                    { "Antal bokstäver i kommentarsfältet/Order/År",        "År",                                       "Bokstäver/Order"       },
                    { "Aktivitet dom senaste 7 dagarna",                    "Namn",                                     "Timmar"                },
                    { "Aktivitet per Avdelning",                            "Avdelning",                                "Timmar"                },
                    { "Teman som används i programmet",                     "Tema",                                     "%"                     }
                };
                return names;
            }
        }
        #endregion

        #region 5...Ladda DataTable
        //Mätningar - Extrudering TEF - 6st
        private void Load_dt_Mätning_Extrudering_TEF_Year()
        {
            dt_Mätningar_Extrudering_TEF_Year = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData
                            WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_TEF_Year.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_TEF_Year_Skift()
        {
            dt_Mätningar_Extrudering_TEF_Year_Skift = new DataTable();
            dt_Mätningar_Extrudering_TEF_Year_Skift.Columns.Add("Year");
            dt_Mätningar_Extrudering_TEF_Year_Skift.Columns.Add("MorgonSkift");
            dt_Mätningar_Extrudering_TEF_Year_Skift.Columns.Add("Kvällskift");
            dt_Mätningar_Extrudering_TEF_Year_Skift.Columns.Add("Nattskift");
            var row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData
                            WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2013 
                        AND (CAST(Date as time) BETWEEN '06:00' AND '13:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Extrudering_TEF_Year_Skift.Rows.Add();
                    dt_Mätningar_Extrudering_TEF_Year_Skift.Rows[row][0] = reader[0].ToString();
                    dt_Mätningar_Extrudering_TEF_Year_Skift.Rows[row][1] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData 
                        WHERE EXISTS (SELECT * FROM [Order].MainData
                            WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2013 
                        AND (CAST(Date as time) BETWEEN '14:00' AND '21:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Extrudering_TEF_Year_Skift.Rows[row][2] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                    WHERE EXISTS (SELECT * FROM [Order].MainData
                        WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                            AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                            AND YEAR(Date) > 2013 
                            AND (CAST(Date as time) BETWEEN '22:00' AND '23:59' OR CAST(Date as time) BETWEEN '00:00' AND '05:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Extrudering_TEF_Year_Skift.Rows[row][3] = reader[1].ToString();
                    row++;
                }
            }
        }
        private void Load_dt_Mätning_Extrudering_TEF_Month()
        {
            dt_Mätningar_Extrudering_TEF_Month = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT MONTH(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                    WHERE EXISTS (SELECT * FROM [Order].MainData 
                        WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                            AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID) 
                    GROUP BY MONTH(Date) 
                    ORDER BY MONTH(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_TEF_Month.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_TEF_Day()
        {
            dt_Mätningar_Extrudering_TEF_Day = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT CAST(Date as Date), COUNT(*) AS Antal
                    FROM Measureprotocol.MainData
                    WHERE EXISTS (SELECT * FROM [Order].MainData 
                        WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                            AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID) 
						AND YEAR(Date) > 2013 
                    GROUP BY CAST(Date as Date) ORDER BY CAST(Date as Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_TEF_Day.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_TEF_LastWeek()
        {
            dt_Mätningar_Extrudering_TEF_LastWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DATENAME(WEEKDAY, Date), COUNT(*) AS Antal, Date
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData 
                            WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND Date > @date 
                    GROUP BY DATENAME(WEEKDAY, Date), Date
					ORDER BY Date";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-7));
                dt_Mätningar_Extrudering_TEF_LastWeek.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_TEF_DayOfWeek()
        {
            dt_Mätningar_Extrudering_TEF_DayOfWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DATENAME(WEEKDAY, Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData 
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                    GROUP BY DATENAME(WEEKDAY, Date) 
                    ORDER BY CASE DATENAME(WEEKDAY, Date)
                        WHEN 'Monday' Then 1
                        WHEN 'Tuesday' Then 2
                        WHEN 'Wednesday' Then 3
                        WHEN 'Thursday' Then 4
                        WHEN 'Friday' Then 5
                        WHEN 'Saturday' Then 6
                        WHEN 'Sunday' Then 7
                    END";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_TEF_DayOfWeek.Load(cmd.ExecuteReader());
            }
        }
        //Mätningar - Extrudering FEP - 6st
        private void Load_dt_Mätning_Extrudering_FEP_Year()
        {
            dt_Mätningar_Extrudering_FEP_Year = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE WorkOperationID = 1
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_FEP_Year.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_FEP_Year_Skift()
        {
            dt_Mätningar_Extrudering_FEP_Year_Skift = new DataTable();
            dt_Mätningar_Extrudering_FEP_Year_Skift.Columns.Add("Year");
            dt_Mätningar_Extrudering_FEP_Year_Skift.Columns.Add("MorgonSkift");
            dt_Mätningar_Extrudering_FEP_Year_Skift.Columns.Add("Kvällskift");
            dt_Mätningar_Extrudering_FEP_Year_Skift.Columns.Add("Nattskift");
            var row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE WorkOperationID = 1
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2019 
                        AND CAST(Date AS Time) BETWEEN '06:00' AND '13:59'  
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Extrudering_FEP_Year_Skift.Rows.Add();
                    dt_Mätningar_Extrudering_FEP_Year_Skift.Rows[row][0] = reader[0].ToString();
                    dt_Mätningar_Extrudering_FEP_Year_Skift.Rows[row][1] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData 
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE WorkOperationID = 1
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2019
                        AND CAST(Date AS Time) BETWEEN '14:00' AND '21:59'  
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Extrudering_FEP_Year_Skift.Rows[row][2] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE WorkOperationID = 1
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2019
                        AND (CAST(Date AS Time) BETWEEN '22:00' AND '23:59' OR CAST(Date AS Time) BETWEEN '00:00' AND '05:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Extrudering_FEP_Year_Skift.Rows[row][3] = reader[1].ToString();
                    row++;
                }
            }
        }
        private void Load_dt_Mätning_Extrudering_FEP_Month()
        {
            dt_Mätningar_Extrudering_FEP_Month = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT MONTH(Date), COUNT(*) AS Antal 
                        FROM Measureprotocol.MainData
                            WHERE EXISTS (SELECT * From [Order].MainData
                                WHERE WorkOperationID = 1
                                    AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID) 
                        GROUP BY MONTH(Date) 
                        ORDER BY MONTH(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_FEP_Month.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_FEP_Day()
        {
            dt_Mätningar_Extrudering_FEP_Day = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                                SELECT CAST(Date as Date), COUNT(*) AS Antal 
                                FROM Measureprotocol.MainData
                                    WHERE EXISTS (SELECT * From [Order].MainData
                                        WHERE WorkOperationID = 1
                                            AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID) 
                                GROUP BY Date
                                ORDER BY Date";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_FEP_Day.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_FEP_LastWeek()
        {
            dt_Mätningar_Extrudering_FEP_LastWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DATENAME(WEEKDAY, Date), COUNT(*) AS Antal, CAST(Date as date)
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData 
                            WHERE WorkOperationID = 1
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND CAST(Date as date) > @date 
                    GROUP BY DATENAME(WEEKDAY, Date), CAST(Date as date)
					ORDER BY CAST(Date as date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-7));
                dt_Mätningar_Extrudering_FEP_LastWeek.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Extrudering_FEP_DayOfWeek()
        {
            dt_Mätningar_Extrudering_FEP_DayOfWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DATENAME(WEEKDAY, Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE WorkOperationID = 1
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                    GROUP BY DATENAME(WEEKDAY, Date) 
                    ORDER BY CASE DATENAME(WEEKDAY, Date)
                        WHEN 'Monday' Then 1
                        WHEN 'Tuesday' Then 2
                        WHEN 'Wednesday' Then 3
                        WHEN 'Thursday' Then 4
                        WHEN 'Friday' Then 5
                        WHEN 'Saturday' Then 6
                        WHEN 'Sunday' Then 7
                    END";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Extrudering_FEP_DayOfWeek.Load(cmd.ExecuteReader());
            }
        }
        //Mätningar - Krympslang - 6st
        private void Load_dt_Mätning_Krymp_Year()
        {
            dt_Mätningar_Krymp_Year = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData
                            WHERE WorkOperationID = 10
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Krymp_Year.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Krymp_Year_Skift()
        {
            dt_Mätningar_Krymp_Year_Skift = new DataTable();
            dt_Mätningar_Krymp_Year_Skift.Columns.Add("Year");
            dt_Mätningar_Krymp_Year_Skift.Columns.Add("MorgonSkift");
            dt_Mätningar_Krymp_Year_Skift.Columns.Add("Kvällskift");
            dt_Mätningar_Krymp_Year_Skift.Columns.Add("Nattskift");
            var row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData
                            WHERE WorkOperationID = 10
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2013 
                        AND (CAST(Date as Time) BETWEEN '06:00' AND '13:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Krymp_Year_Skift.Rows.Add();
                    dt_Mätningar_Krymp_Year_Skift.Rows[row][0] = reader[0].ToString();
                    dt_Mätningar_Krymp_Year_Skift.Rows[row][1] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData
                            WHERE WorkOperationID = 10
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND YEAR(Date) > 2013 
                        AND (CAST(Date as time) BETWEEN '14:00' AND '21:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Krymp_Year_Skift.Rows[row][2] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT YEAR(Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                    WHERE EXISTS (SELECT * FROM [Order].MainData
                        WHERE WorkOperationID = 10
                            AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                            AND YEAR(Date) > 2013 
                            AND (CAST(Date as Time) BETWEEN '22:00' AND '23:59' OR CAST(Date as Time) BETWEEN '00:00' AND '05:59')
                    GROUP BY Year(Date) 
                    ORDER BY Year(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Krymp_Year_Skift.Rows[row][3] = reader[1].ToString();
                    row++;
                }
            }
        }
        private void Load_dt_Mätning_Krymp_Month()
        {
            dt_Mätningar_Krymp_Month = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT MONTH(Date), COUNT(*) AS Antal 
                        FROM Measureprotocol.MainData
                            WHERE EXISTS (SELECT * From [Order].MainData
                                WHERE WorkOperationID = 10
                                    AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID) 
                        GROUP BY MONTH(Date) 
                        ORDER BY MONTH(Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Krymp_Month.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Krymp_Day()
        {
            dt_Mätningar_Krymp_Day = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                                SELECT CAST(Date as Date), COUNT(*) AS Antal 
                                FROM Measureprotocol.MainData
                                    WHERE EXISTS (SELECT * From [Order].MainData
                                        WHERE WorkOperationID = 10
                                            AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID) 
                                GROUP BY CAST(Date as Date)
                                ORDER BY CAST(Date as Date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Krymp_Day.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Krymp_LastWeek()
        {
            dt_Mätningar_Krymp_LastWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DATENAME(WEEKDAY, Date), COUNT(*) AS Antal, CAST(Date as date)
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * FROM [Order].MainData 
                            WHERE WorkOperationID = 10
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                        AND CAST(Date as date) > @date 
                    GROUP BY DATENAME(WEEKDAY, Date), CAST(Date as date)
					ORDER BY CAST(Date as date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-7));
                dt_Mätningar_Krymp_LastWeek.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Krymp_DayOfWeek()
        {
            dt_Mätningar_Krymp_DayOfWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DATENAME(WEEKDAY, Date), COUNT(*) AS Antal 
                    FROM Measureprotocol.MainData
                        WHERE EXISTS (SELECT * From [Order].MainData
                            WHERE WorkOperationID = 10
                                AND Measureprotocol.MainData.OrderID = [Order].MainData.OrderID)
                    GROUP BY DATENAME(WEEKDAY, Date) 
                    ORDER BY CASE DATENAME(WEEKDAY, Date)
                        WHEN 'Monday' Then 1
                        WHEN 'Tuesday' Then 2
                        WHEN 'Wednesday' Then 3
                        WHEN 'Thursday' Then 4
                        WHEN 'Friday' Then 5
                        WHEN 'Saturday' Then 6
                        WHEN 'Sunday' Then 7
                    END";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Krymp_DayOfWeek.Load(cmd.ExecuteReader());
            }
        }
        //Mätningar - Slipning - 6st
        private void Load_dt_Mätning_Slipning_Year()
        {
            dt_Mätningar_Slipning_Year = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT YEAR(Date_Time), COUNT(*) AS Antal FROM Korprotokoll_Slipning_Produktion WHERE Column_Index IS NULL GROUP BY Year(Date_Time) ORDER BY Year(Date_Time)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Slipning_Year.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Slipning_Year_Skift()
        {
            dt_Mätningar_Slipning_Year_Skift = new DataTable();
            dt_Mätningar_Slipning_Year_Skift.Columns.Add("Year");
            dt_Mätningar_Slipning_Year_Skift.Columns.Add("MorgonSkift");
            dt_Mätningar_Slipning_Year_Skift.Columns.Add("Kvällskift");
            dt_Mätningar_Slipning_Year_Skift.Columns.Add("Nattskift");
            var row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT YEAR(Date_Time), COUNT(*) AS Antal 
                                    FROM Korprotokoll_Slipning_Produktion
                                    WHERE(CAST(Date_Time AS time) BETWEEN '06:00' AND '13:59')
                                        AND Column_Index IS NULL
                                    GROUP BY Year(Date_Time) ORDER BY Year(Date_Time)";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Slipning_Year_Skift.Rows.Add();
                    dt_Mätningar_Slipning_Year_Skift.Rows[row][0] = reader[0].ToString();
                    dt_Mätningar_Slipning_Year_Skift.Rows[row][1] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT YEAR(Date_Time), COUNT(*) AS Antal 
                                    FROM Korprotokoll_Slipning_Produktion
                                    WHERE(CAST(Date_Time AS time) BETWEEN '14:00' AND '21:59')
                                        AND Column_Index IS NULL
                                    GROUP BY Year(Date_Time) ORDER BY Year(Date_Time)";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Slipning_Year_Skift.Rows[row][2] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT YEAR(Date_Time), COUNT(*) AS Antal 
                                    FROM Korprotokoll_Slipning_Produktion
                                    WHERE(CAST(Date_Time AS time) BETWEEN '22:00' AND '23:59' OR CAST(Date_Time AS time) BETWEEN '00:00' AND '05:59')
                                        AND Column_Index IS NULL
                                    GROUP BY Year(Date_Time) ORDER BY Year(Date_Time)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Slipning_Year_Skift.Rows[row][3] = reader[1].ToString();
                    row++;
                }
            }
        }
        private void Load_dt_Mätning_Slipning_Month()
        {
            dt_Mätningar_Slipning_Month = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT MONTH(Date_Time), COUNT(*) AS Antal FROM Korprotokoll_Slipning_Produktion WHERE Column_Index IS NULL GROUP BY MONTH(Date_Time) ORDER BY MONTH(Date_Time)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Slipning_Month.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Slipning_Day()
        {
            dt_Mätningar_Slipning_Day = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT CAST(Date_Time AS Date), COUNT(*) AS Antal FROM Korprotokoll_Slipning_Produktion WHERE Column_Index IS NULL GROUP BY CAST(Date_Time AS Date) ORDER BY CAST(Date_Time AS Date)";

                
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Slipning_Day.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Slipning_LastWeek()
        {
            dt_Mätningar_Slipning_LastWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DATENAME(WEEKDAY, Date_Time), COUNT(*) AS Antal 
                    FROM Korprotokoll_Slipning_Produktion
                    WHERE Column_Index IS NULL AND Date_Time > @date 
                    GROUP BY DATENAME(WEEKDAY, Date_Time), CAST(Date_Time AS date)
                    ORDER BY CAST(Date_Time AS date)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-7));
                dt_Mätningar_Slipning_LastWeek.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Slipning_DayOfWeek()
        {
            dt_Mätningar_Slipning_DayOfWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DATENAME(WEEKDAY, Date_Time), COUNT(*) AS Antal 
                    FROM Korprotokoll_Slipning_Produktion
                    WHERE Column_Index IS NULL
                    GROUP BY DATENAME(WEEKDAY, Date_Time) 
                    ORDER BY CASE DATENAME(WEEKDAY, Date_Time)
                    WHEN 'Monday' Then 1
                    WHEN 'Tuesday' Then 2
                    WHEN 'Wednesday' Then 3
                    WHEN 'Thursday' Then 4
                    WHEN 'Friday' Then 5
                    WHEN 'Saturday' Then 6
                    WHEN 'Sunday' Then 7
                    END";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Slipning_DayOfWeek.Load(cmd.ExecuteReader());
            }
        }
        //Mätningar - Svetsning - 6st
        private void Load_dt_Mätning_Svetsning_Year()
        {
            dt_Mätningar_Svetsning_Year = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT YEAR(Datum), COUNT(*) AS Antal FROM Korprotokoll_Svetsning_Parametrar WHERE Tid > '' AND Tid != '-' GROUP BY Year(Datum) ORDER BY Year(Datum)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Svetsning_Year.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Svetsning_Year_Skift()
        {
            dt_Mätningar_Svetsning_Year_Skift = new DataTable();
            dt_Mätningar_Svetsning_Year_Skift.Columns.Add("Year");
            dt_Mätningar_Svetsning_Year_Skift.Columns.Add("MorgonSkift");
            dt_Mätningar_Svetsning_Year_Skift.Columns.Add("Kvällskift");
            dt_Mätningar_Svetsning_Year_Skift.Columns.Add("Nattskift");
            var row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT YEAR(Datum), COUNT(*) AS Antal FROM Korprotokoll_Svetsning_Parametrar WHERE Tid BETWEEN '06:00' AND '13:59'  GROUP BY Year(Datum) ORDER BY Year(Datum)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Svetsning_Year_Skift.Rows.Add();
                    dt_Mätningar_Svetsning_Year_Skift.Rows[row][0] = reader[0].ToString();
                    dt_Mätningar_Svetsning_Year_Skift.Rows[row][1] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT YEAR(Datum), COUNT(*) AS Antal FROM Korprotokoll_Svetsning_Parametrar WHERE Tid BETWEEN '14:00' AND '21:59' GROUP BY Year(Datum) ORDER BY Year(Datum)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Svetsning_Year_Skift.Rows[row][2] = reader[1].ToString();
                    row++;
                }
            }
            row = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT YEAR(Datum), COUNT(*) AS Antal FROM Korprotokoll_Svetsning_Parametrar WHERE Tid BETWEEN '22:00' AND '23:59' OR Tid BETWEEN '00:00' AND '05:59' GROUP BY Year(Datum) ORDER BY Year(Datum)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Mätningar_Svetsning_Year_Skift.Rows[row][3] = reader[1].ToString();
                    row++;
                }
            }
        }
        private void Load_dt_Mätning_Svetsning_Month()
        {
            dt_Mätningar_Svetsning_Month = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT MONTH(Datum), COUNT(*) AS Antal FROM Korprotokoll_Svetsning_Parametrar WHERE Tid > '' AND Tid != '-' GROUP BY MONTH(Datum) ORDER BY MONTH(Datum)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Svetsning_Month.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Svetsning_Day()
        {
            dt_Mätningar_Svetsning_Day = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Datum, COUNT(*) AS Antal FROM Korprotokoll_Svetsning_Parametrar WHERE Tid > '' AND Tid != '-' GROUP BY Datum ORDER BY Datum";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Svetsning_Day.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Svetsning_LastWeek()
        {
            dt_Mätningar_Svetsning_LastWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DATENAME(WEEKDAY, Datum), COUNT(*) AS Antal 
                    FROM Korprotokoll_Svetsning_Parametrar 
                    WHERE Tid > '' AND Tid != '-' AND Datum > @date 
                    GROUP BY DATENAME(WEEKDAY, Datum), Datum
                    ORDER BY Datum";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-7));
                dt_Mätningar_Svetsning_LastWeek.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Mätning_Svetsning_DayOfWeek()
        {
            dt_Mätningar_Svetsning_DayOfWeek = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT DATENAME(WEEKDAY, Datum), COUNT(*) AS Antal
                    FROM Korprotokoll_Svetsning_Parametrar 
                    WHERE Tid > '' AND Tid != '-' 
                    GROUP BY DATENAME(WEEKDAY, Datum) 
                    ORDER BY CASE DATENAME(WEEKDAY, Datum)
                    WHEN 'Monday' Then 1 
                    WHEN 'Tuesday' Then 2 
                    WHEN 'Wednesday' Then 3
                    WHEN 'Thursday' Then 4
                    WHEN 'Friday' Then 5
                    WHEN 'Saturday' Then 6
                    WHEN 'Sunday' Then 7
                    END
                    ";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Mätningar_Svetsning_DayOfWeek.Load(cmd.ExecuteReader());
            }
        }
        //Ordrar - 7st
        private void Load_dt_Ordrar_Year()
        {
            dt_Ordrar_Year = new DataTable();
            dt_Ordrar_Year.Columns.Add("År");
            dt_Ordrar_Year.Columns.Add("Antal");
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT YEAR(Date_Start), COUNT(OrderNr) FROM [Order].MainData WHERE YEAR(Date_Start) > 2000
                                    GROUP BY YEAR(Date_Start)
                                    ORDER BY YEAR(Date_Start)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                var year = 0;
                var antal = 0;
                var row = 0;
                while (reader.Read())
                {
                    if (year == int.Parse(reader[0].ToString()))
                    {
                        antal = antal + int.Parse(reader[1].ToString());
                        dt_Ordrar_Year.Rows[row - 1][1] = antal;
                    }
                    else
                    {
                        year = int.Parse(reader[0].ToString());
                        antal = int.Parse(reader[1].ToString());
                        dt_Ordrar_Year.Rows.Add(year.ToString(), antal.ToString());
                        row++;
                    }

                }
            }
        }
        private void Load_dt_Ordrar_Month()
        {
            dt_Ordrar_Month = new DataTable();
            dt_Ordrar_Month.Columns.Add("Månad");
            dt_Ordrar_Month.Columns.Add("Antal");
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT MONTH(Date_Start), COUNT(OrderNr) FROM [Order].MainData WHERE YEAR(Date_Start) > 2000
                                    GROUP BY MONTH(Date_Start)
                                    ORDER BY Month(Date_Start)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                var month = 0;
                var antal = 0;
                var row = 0;
                while (reader.Read())
                {
                    if (month == int.Parse(reader[0].ToString()))
                    {
                        antal = antal + int.Parse(reader[1].ToString());
                        dt_Ordrar_Month.Rows[row - 1][1] = antal;
                    }
                    else
                    {
                        month = int.Parse(reader[0].ToString());
                        antal = int.Parse(reader[1].ToString());
                        dt_Ordrar_Month.Rows.Add(month.ToString(), antal.ToString());
                        row++;
                    }

                }
            }
        }
        private void Load_dt_Ordrar_ProdLinje()
        {
            dt_Ordrar_ProdLinje = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT ProdLine, COUNT(OrderNr) FROM [Order].MainData WHERE ProdLine > '' GROUP BY ProdLine HAVING COUNT(OrderNr) > 10";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Ordrar_ProdLinje.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Ordrar_ProdLinje_ThisYear()
        {
            dt_Ordrar_ProdLinje_This_Year = new DataTable();
            dt_Ordrar_ProdLinje_This_Year.Columns.Add("ProdLine");
            dt_Ordrar_ProdLinje_This_Year.Columns.Add(thisYear);
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT ProdLine, COUNT(OrderNr) FROM [Order].MainData
                                WHERE ProdLine > '' AND YEAR(Date_Start) = YEAR(getdate()) GROUP BY ProdLine HAVING COUNT(OrderNr) > 10";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Ordrar_ProdLinje_This_Year.Rows.Add();
                    dt_Ordrar_ProdLinje_This_Year.Rows[dt_Ordrar_ProdLinje_This_Year.Rows.Count - 1][0] = reader[0].ToString();
                    dt_Ordrar_ProdLinje_This_Year.Rows[dt_Ordrar_ProdLinje_This_Year.Rows.Count - 1][1] = reader[1].ToString();
                }
                //dt_Ordrar_ProdLinje_This_Year.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Ordrar_ProdLinje_LastYear()
        {
            dt_Ordrar_ProdLinje_This_Year.Columns.Add(lastYear);
            for (var i = 0; i < dt_Ordrar_ProdLinje_This_Year.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT ProdLine, COUNT(OrderNr) FROM [Order].MainData
                                WHERE ProdLine > '' AND YEAR(Date_Start) = @lastYear GROUP BY ProdLine HAVING ProdLine = @prodline";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@lastYear", lastYear);
                    cmd.Parameters.AddWithValue("@prodline", dt_Ordrar_ProdLinje_This_Year.Rows[i][0].ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dt_Ordrar_ProdLinje_This_Year.Rows[i][2] = reader[1].ToString();
                    }
                }
            }
        }
        private void Load_dt_Ordrar_ProdLinje_2_YearAgo()
        {
            dt_Ordrar_ProdLinje_This_Year.Columns.Add(two_Year_Ago);
            for (var i = 0; i < dt_Ordrar_ProdLinje_This_Year.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT ProdLine, COUNT(OrderNr) FROM [Order].MainData
                                WHERE ProdLine > '' AND YEAR(Date_Start) = @2YearAgo GROUP BY ProdLine HAVING ProdLine = @prodline";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@2YearAgo", two_Year_Ago);
                    cmd.Parameters.AddWithValue("@prodline", dt_Ordrar_ProdLinje_This_Year.Rows[i][0].ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        dt_Ordrar_ProdLinje_This_Year.Rows[i][3] = reader[1].ToString();
                }
            }
        }
        private void Load_dt_Ordrar_ProdLinje_ThisMonth()
        {
            dt_Ordrar_ProdLinje_This_Month = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT ProdLine, COUNT(OrderNr) FROM [Order].MainData
                                WHERE ProdLine > '' AND Date_Start >= @date
                                GROUP BY ProdLine";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
                dt_Ordrar_ProdLinje_This_Month.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Ordrar_Tid_Order_ProdLinje()
        {
            dt_Ordrar_Tid_Order_ProdLinje = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT ProdLine, AVG(DATEDIFF(HOUR,  Date_Start, Date_Stop))
                                FROM [Order].MainData
                                WHERE Date_Start IS NOT NULL
                                    AND Date_Stop IS NOT NULL
                                    AND ProdLine > ''
                                    AND YEAR(Date_Start) > 2017
                                GROUP BY ProdLine
                                HAVING AVG(DATEDIFF(HOUR, Date_Start, Date_Stop)) < 1000";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Ordrar_Tid_Order_ProdLinje.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Ordrar_Tid_Order_ProdLinje_Year()
        {

            dt_Ordrar_Tid_Order_ProdLinje_Year = new DataTable();
            dt_Ordrar_Tid_Order_ProdLinje_Year.Columns.Add("ProdLine");
            dt_Ordrar_Tid_Order_ProdLinje_Year.Columns.Add(thisYear);
            dt_Ordrar_Tid_Order_ProdLinje_Year.Columns.Add(lastYear);
            dt_Ordrar_Tid_Order_ProdLinje_Year.Columns.Add(two_Year_Ago);
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"SELECT ProdLine, AVG(DATEDIFF(HOUR, Date_Start, Date_Stop))
                                FROM [Order].MainData
                                WHERE Date_Start IS NOT NULL
                                    AND Date_Stop IS NOT NULL
                                    AND ProdLine > ''
                                    AND YEAR(Date_Start) = @thisYear
                                GROUP BY ProdLine
                                HAVING AVG(DATEDIFF(HOUR, Date_Start, Date_Stop)) < 1000 AND AVG(DATEDIFF(HOUR, Date_Start, Date_Stop)) > 5";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@thisYear", thisYear);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt_Ordrar_Tid_Order_ProdLinje_Year.Rows.Add();
                    dt_Ordrar_Tid_Order_ProdLinje_Year.Rows[dt_Ordrar_Tid_Order_ProdLinje_Year.Rows.Count - 1][0] = reader[0].ToString();
                    dt_Ordrar_Tid_Order_ProdLinje_Year.Rows[dt_Ordrar_Tid_Order_ProdLinje_Year.Rows.Count - 1][1] = reader[1].ToString();
                }
            }
            for (var i = 0; i < dt_Ordrar_Tid_Order_ProdLinje_Year.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT ProdLine, AVG(DATEDIFF(HOUR,  Date_Start, Date_Stop))
                                FROM [Order].MainData
                                WHERE Date_Start IS NOT NULL
                                    AND Date_Stop IS NOT NULL
                                    AND ProdLine > ''
                                    AND YEAR(Date_Start) = @lastYear
                                    AND ProdLine = @prodline
                                GROUP BY ProdLine";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", dt_Ordrar_Tid_Order_ProdLinje_Year.Rows[i][0]);
                    cmd.Parameters.AddWithValue("@lastYear", lastYear);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        dt_Ordrar_Tid_Order_ProdLinje_Year.Rows[i][2] = reader[1].ToString();

                }

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT ProdLine, AVG(DATEDIFF(HOUR,  Date_Start, Date_Stop))
                                FROM [Order].MainData
                                WHERE Date_Start IS NOT NULL
                                    AND Date_Stop IS NOT NULL
                                    AND ProdLine > ''
                                    AND YEAR(Date_Start) = @twoYearAgo
                                    AND ProdLine = @prodline
                                GROUP BY ProdLine";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", dt_Ordrar_Tid_Order_ProdLinje_Year.Rows[i][0]);
                    cmd.Parameters.AddWithValue("@twoYearAgo", two_Year_Ago);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        dt_Ordrar_Tid_Order_ProdLinje_Year.Rows[i][3] = reader[1].ToString();
                }
            }
        }
        //Processkort - Extrudering - 6st
        private void Load_dt_RumsTemp_ProdLinje()
        {
            dt_RumsTemp_ProdLinje = new DataTable();
            dt_RumsTemp_ProdLinje.Columns.Add("ProdLine");
            dt_RumsTemp_ProdLinje.Columns.Add("Temp");
            foreach (var ProdLine in List_ProdLinje)
            {
                var list_temp = new List<double>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT Rum_Temp FROM [Order].MainData WHERE Rum_Temp IS NOT NULL AND ProdLine = @prodline";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", ProdLine);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var temp))
                            if (temp < 30)
                                list_temp.Add(temp);
                    }

                    if (list_temp.Count <= 50) 
                        continue;
                    var temp_Avg = Math.Round(list_temp.Average(), 3);
                    dt_RumsTemp_ProdLinje.Rows.Add();
                    dt_RumsTemp_ProdLinje.Rows[dt_RumsTemp_ProdLinje.Rows.Count - 1][0] = ProdLine;
                    dt_RumsTemp_ProdLinje.Rows[dt_RumsTemp_ProdLinje.Rows.Count - 1][1] = temp_Avg;
                }
            }
        }
        private void Load_dt_RumsFukt_ProdLinje()
        {
            dt_RumsFukt_ProdLinje = new DataTable();
            dt_RumsFukt_ProdLinje.Columns.Add("ProdLine");
            dt_RumsFukt_ProdLinje.Columns.Add("Fukt");
            foreach (var ProdLine in List_ProdLinje)
            {
                var list_Fukt = new List<double>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT Rum_Fukt FROM [Order].MainData WHERE Rum_Fukt IS NOT NULL AND ProdLine = @prodline";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", ProdLine);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var Fukt))
                            if (Fukt < 100)
                                list_Fukt.Add(Fukt);
                    }

                    if (list_Fukt.Count > 50)
                    {
                        var Fukt_Avg = Math.Round(list_Fukt.Average(), 3);
                        dt_RumsFukt_ProdLinje.Rows.Add();
                        dt_RumsFukt_ProdLinje.Rows[dt_RumsFukt_ProdLinje.Rows.Count - 1][0] = ProdLine;
                        dt_RumsFukt_ProdLinje.Rows[dt_RumsFukt_ProdLinje.Rows.Count - 1][1] = Fukt_Avg;
                    }
                }
            }
        }
        private void Load_dt_Draghastighet_ProdLinje()
        {
            dt_Dragh_ProdLinje = new DataTable();
            dt_Dragh_ProdLinje.Columns.Add("ProdLine");
            dt_Dragh_ProdLinje.Columns.Add("Draghastighet");
            foreach (var ProdLine in List_ProdLinje)
            {
                var list_temp = new List<double>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT Value 
                        FROM [Order].Data  as data
                        LEFT JOIN [Order].MainData AS main
                            ON main.OrderID = data.OrderID
                        WHERE ProtocolDescriptionID = 99 AND  Value IS NOT NULL 
                            AND ProdLine = @prodline";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", ProdLine);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var dragH))
                            list_temp.Add(dragH);
                    }

                    if (list_temp.Count > 0)
                    {
                        var temp_Avg = Math.Round(list_temp.Average(), 2);
                        dt_Dragh_ProdLinje.Rows.Add();
                        dt_Dragh_ProdLinje.Rows[dt_Dragh_ProdLinje.Rows.Count - 1][0] = ProdLine;
                        dt_Dragh_ProdLinje.Rows[dt_Dragh_ProdLinje.Rows.Count - 1][1] = temp_Avg;
                    }
                }
            }


        }
        private void Load_dt_TorkTemp_ProdLinje()
        {
            dt_TorkTemp_ProdLinje = new DataTable();
            dt_TorkTemp_ProdLinje.Columns.Add("ProdLine");
            dt_TorkTemp_ProdLinje.Columns.Add("Draghastighet");
            foreach (var Prodlinje in List_ProdLinje)
            {
                var list_TorkTemp = new List<double>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT Value 
                        FROM [Order].Data AS data
                        LEFT JOIN [Order].MainData AS main
                            ON main.OrderID = data.OrderID
                        WHERE ProtocolDescriptionID = 276 
                            AND ProdLine = @prodline AND LEN(Value) < 4";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", Prodlinje);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var TorkTemp))
                            list_TorkTemp.Add(TorkTemp);
                    }

                    if (list_TorkTemp.Count > 0)
                    {
                        var temp_Avg = Math.Round(list_TorkTemp.Average(), 0);
                        dt_TorkTemp_ProdLinje.Rows.Add();
                        dt_TorkTemp_ProdLinje.Rows[dt_TorkTemp_ProdLinje.Rows.Count - 1][0] = Prodlinje;
                        dt_TorkTemp_ProdLinje.Rows[dt_TorkTemp_ProdLinje.Rows.Count - 1][1] = temp_Avg;
                    }
                }
            }
        }
        private void Load_dt_Temp_Zon_Huvud_ProdLinje()
        {
            dt_Temp_Zon_Huvud_ProdLinje = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ProdLine, AVG(Value)
                    FROM [Order].Data AS extruder
	                    LEFT JOIN [Order].MainData AS main
	                        ON main.OrderID = extruder.OrderID
                    WHERE ProtocolDescriptionID = 283 AND ProdLine IS NOT NULL AND ProdLine IS NOT NULL
                    GROUP BY ProdLine";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Temp_Zon_Huvud_ProdLinje.Load(cmd.ExecuteReader());
            }
        }
        private void Load_dt_Temp_Zon_Munst_ProdLinje()
        {
            dt_Temp_Zon_Munst_ProdLinje = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ProdLine, AVG(Value)
                    FROM [Order].Data AS extruder
	                    LEFT JOIN [Order].MainData AS main
	                        ON main.OrderID = extruder.OrderID
                    WHERE ProtocolDescriptionID = 284 AND ProdLine IS NOT NULL AND ProdLine IS NOT NULL
                    GROUP BY ProdLine";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                dt_Temp_Zon_Munst_ProdLinje.Load(cmd.ExecuteReader());
            }
        }
        //Övrigt - 16st
        private void Load_dt_Mätningar_ProdLinje()
        {
            dt_Mätningar_ProdLinje = new DataTable();
            dt_Mätningar_ProdLinje.Columns.Add("ProdLine");
            dt_Mätningar_ProdLinje.Columns.Add("Antal");
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ProdLine, COUNT(*) AS Antal
                    FROM Measureprotocol.MainData as mp
                    JOIN [Order].MainData as korprotokoll
	                    ON mp.OrderID = korprotokoll.OrderID
                    WHERE ProdLine > '' AND ProdLine != '-'
                    GROUP BY ProdLine
                    ORDER BY ProdLine";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.Parse(reader[1].ToString()) > 50)
                    {
                        dt_Mätningar_ProdLinje.Rows.Add(reader[0].ToString(), reader[1].ToString());
                    }
                }
            }
        }
        private void Load_dt_Mätningar_ProdLinje_ThisYear()
        {
            dt_Mätningar_ProdLinje_Year = new DataTable();
            dt_Mätningar_ProdLinje_Year.Columns.Add("ProdLine");
            dt_Mätningar_ProdLinje_Year.Columns.Add(thisYear);
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ProdLine, COUNT(*) AS Antal
                    FROM Measureprotocol.MainData as mp
                    JOIN [Order].MainData as korprotokoll
	                    ON mp.OrderID = korprotokoll.OrderID
                    WHERE ProdLine > '' AND ProdLine != '-' AND YEAR(Date) = @thisYear
                    GROUP BY ProdLine
                    ORDER BY ProdLine";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@thisYear", thisYear);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.Parse(reader[1].ToString()) > 50)
                    {
                        dt_Mätningar_ProdLinje_Year.Rows.Add(reader[0].ToString(), reader[1].ToString());
                    }
                }
            }
        }
        private void Load_dt_Mätningar_ProdLinje_LastYear()
        {
            dt_Mätningar_ProdLinje_Year.Columns.Add(lastYear);
            for (var i = 0; i < dt_Mätningar_ProdLinje_Year.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT ProdLine, COUNT(*) AS Antal
                        FROM Measureprotocol.MainData as mp
                            JOIN [Order].MainData as korprotokoll
	                            ON mp.OrderID = korprotokoll.OrderID
                        WHERE ProdLine = @prodline AND YEAR(Date) = @lastYear
                        GROUP BY ProdLine
                        ORDER BY ProdLine";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@lastYear", lastYear);
                    cmd.Parameters.AddWithValue("@prodline", dt_Mätningar_ProdLinje_Year.Rows[i][0].ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dt_Mätningar_ProdLinje_Year.Rows[i][2] = reader[1].ToString();
                    }
                }
            }
        }
        private void Load_dt_Mätningar_ProdLinje_2_YearAgo()
        {
            dt_Mätningar_ProdLinje_Year.Columns.Add(two_Year_Ago);
            for (var i = 0; i < dt_Mätningar_ProdLinje_Year.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT ProdLine, COUNT(*) AS Antal
                        FROM Measureprotocol.MainData as mp
                            JOIN [Order].MainData as korprotokoll
	                            ON mp.OrderID = korprotokoll.OrderID
                        WHERE ProdLine = @prodline AND YEAR(Date) = @2YearAgo
                        GROUP BY ProdLine
                        ORDER BY ProdLine";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@2YearAgo", two_Year_Ago);
                    cmd.Parameters.AddWithValue("@prodline", dt_Mätningar_ProdLinje_Year.Rows[i][0].ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dt_Mätningar_ProdLinje_Year.Rows[i][3] = reader[1].ToString();
                    }
                }
            }
        }
        private void Load_dt_Mätning_Extr_ProdLinje_AvgID()
        {
            dt_Mätningar_Extr_ProdLinje_AvgID = new DataTable();
            dt_Mätningar_Extr_ProdLinje_AvgID.Columns.Add("ProdLine");
            dt_Mätningar_Extr_ProdLinje_AvgID.Columns.Add("ID");
            foreach (var ProdLine in List_ProdLinje)
            {
                var value_id = new List<double>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT Value 
                        FROM Measureprotocol.Data as data
                            JOIN [Order].MainData as korprotokoll
                                ON data.OrderID = korprotokoll.OrderID
                            WHERE EXISTS (SELECT * FROM [Order].MainData
                                WHERE (WorkOperationID = 4 OR WorkOperationID = 5)
                                    AND data.OrderID = korprotokoll.OrderID)
                            AND DescriptionID = 1
                            AND ProdLine = @prodline";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@prodline", ProdLine);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var id))
                            value_id.Add(id);
                    }
                    double id_Avg = 0;
                    if (value_id.Count > 0)
                        id_Avg = Math.Round(value_id.Average(), 3);
                    if (value_id.Count > 100)
                    {
                        dt_Mätningar_Extr_ProdLinje_AvgID.Rows.Add();
                        dt_Mätningar_Extr_ProdLinje_AvgID.Rows[dt_Mätningar_Extr_ProdLinje_AvgID.Rows.Count - 1][0] = ProdLine;
                        dt_Mätningar_Extr_ProdLinje_AvgID.Rows[dt_Mätningar_Extr_ProdLinje_AvgID.Rows.Count - 1][1] = id_Avg;
                    }
                }
            }
        }
        private void Load_dt_Mätningar_Extr_OD_Grupp()
        {
            dt_Mätningar_Extr_OD_Grupp = new DataTable();
            dt_Mätningar_Extr_OD_Grupp.Columns.Add("Grupp");
            dt_Mätningar_Extr_OD_Grupp.Columns.Add("Antal");
            for (var i = 0; i < 9; i++)
            {
                var ctr = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                        SELECT Value FROM Measureprotocol.Data WHERE Value BETWEEN {i} AND {i + 1} AND DescriptionID = 11";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var value))
                            if (value > i && value < (i + 1))
                                ctr++;
                    }
                    dt_Mätningar_Extr_OD_Grupp.Rows.Add($"{i}-{i + 1}mm", ctr);
                }
            }
        }
        private void Load_dt_Mätningar_Krymp_OD_Grupp()
        {
            dt_Mätningar_Krymp_OD_Grupp = new DataTable();
            dt_Mätningar_Krymp_OD_Grupp.Columns.Add("Grupp");
            dt_Mätningar_Krymp_OD_Grupp.Columns.Add("Antal");
            for (var i = 1; i < 13; i++)
            {
                var ctr = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT Value FROM Measureprotocol.Data WHERE Value BETWEEN {i} AND {i + 1} AND DescriptionID = 16";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (double.TryParse(reader[0].ToString(), out var value))
                            if (value > i && value < (i + 1))
                                ctr++;

                    }
                    dt_Mätningar_Krymp_OD_Grupp.Rows.Add($"{i}-{i + 1}mm", ctr);
                }
            }
        }
        private void Load_dt_RörFaktor_Krymp_QS()
        {
            dt_RörFaktor_Krymp_QS = new DataTable();
            dt_RörFaktor_Krymp_QS.Columns.Add("Rör");
            dt_RörFaktor_Krymp_QS.Columns.Add("Antal");
            dt_RörFaktor_Krymp_QS.Columns.Add("Rör ID", typeof(double));

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT TOP(12) COUNT(*), SUBSTRING(textvalue, 3, 5) AS Rör
                    FROM [Order].Data 
                    WHERE ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 1')
                        OR ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 2') 
                        OR ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 3')
                    GROUP BY SUBSTRING(textvalue, 3, 5)
                    ORDER BY COUNT(*) DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double.TryParse(reader[1].ToString(), out var Rör_ID);
                    dt_RörFaktor_Krymp_QS.Rows.Add();

                    dt_RörFaktor_Krymp_QS.Rows[dt_RörFaktor_Krymp_QS.Rows.Count - 1]["Rör"] = reader[1].ToString();
                    dt_RörFaktor_Krymp_QS.Rows[dt_RörFaktor_Krymp_QS.Rows.Count - 1]["Rör ID"] = Rör_ID;
                    dt_RörFaktor_Krymp_QS.DefaultView.Sort = "Rör ID ASC";
                    dt_RörFaktor_Krymp_QS = dt_RörFaktor_Krymp_QS.DefaultView.ToTable();
                }
            }

            for (var i = 0; i < dt_RörFaktor_Krymp_QS.Rows.Count; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = @"SELECT COUNT(*) FROM [Order].Data 
                                        WHERE textvalue LIKE @rör 
                                            AND (ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 1') 
                                            OR ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 2')
                                            OR ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = 'RÖR ID# POS 3'))";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@rör", $"%{dt_RörFaktor_Krymp_QS.Rows[i]["Rör"]}%");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        dt_RörFaktor_Krymp_QS.Rows[i]["Antal"] = reader[0].ToString();
                }
            }


            dt_RörFaktor_Krymp_QS.Columns.Remove("Rör ID");
        }
        private void Load_dt_Bokstäver_Per_Order_Per_År()
        {
            dt_Bokstäver = new DataTable();
            dt_Bokstäver.Columns.Add("År");
           
            var row = 0;
            for (var i = 2008; i < DateTime.Now.Year + 1; i++)
            {
                dt_Bokstäver.Rows.Add();
                dt_Bokstäver.Rows[row][0] = i;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT AVG(LEN(Comments)), WorkOperationID
	                                    FROM [Order].MainData
	                                    WHERE YEAR(Date_Start) = @year AND OrderNr NOT LIKE 'Q%'                                   
                                    GROUP BY WorkOperationID
                                    HAVING AVG(LEN(Comments)) > 0 ";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@year", i);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var columnName = $"Antal Bokstäver - {reader["WorkOperationID"]}";
                        if (dt_Bokstäver.Columns.Contains(columnName) == false)
                            dt_Bokstäver.Columns.Add(columnName);
                        dt_Bokstäver.Rows[row][columnName] = reader[0].ToString();
                    }
                }
                row++;
            }
        }
        private void Load_dt_Aktivitet_Top_10_Användare()
        {
            dt_Aktivitet_Top_10_Användare = new DataTable();
            dt_Aktivitet_Top_10_Användare.Columns.Add("Namn");
            dt_Aktivitet_Top_10_Användare.Columns.Add("Tid");

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT TOP 10 SUM(LoadingTime) / 60 / 60 AS LoadingTime, Name
                    FROM Log.ActivityLog as log
                        JOIN [User].Person as person
                            ON log.UserID = person.UserID
                    WHERE Info = 'Aktivitet'
                        AND Date BETWEEN @date_From AND @date_To
                    GROUP BY Name
                    ORDER BY LoadingTime DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@date_From", DateTime.Now.AddDays(-7));
                cmd.Parameters.AddWithValue("@date_To", DateTime.Now.AddDays(1));
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    dt_Aktivitet_Top_10_Användare.Rows.Add();
                    dt_Aktivitet_Top_10_Användare.Rows[ctr][0] = reader["Name"];
                    dt_Aktivitet_Top_10_Användare.Rows[ctr][1] = reader["LoadingTime"];
                    ctr++;
                }
            }
        }
        private void Load_dt_Aktivitet_Avdelning()
        {
            dt_Aktivitet_Avdelning = new DataTable();
            dt_Aktivitet_Avdelning.Columns.Add("Avdelning");
            dt_Aktivitet_Avdelning.Columns.Add("Tid");

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT SUM(LoadingTime) / 60 / 60 as LoadingTime, [User].Person.RoleID as Role
                    FROM Log.ActivityLog
                    JOIN [User].Person
	                    ON [Log].ActivityLog.UserID = [User].Person.UserID
                    WHERE Info = 'Aktivitet'
                    GROUP BY  [User].Person.RoleID
                    ORDER BY LoadingTime DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    dt_Aktivitet_Avdelning.Rows.Add();
                    dt_Aktivitet_Avdelning.Rows[ctr][0] = reader["Role"];
                    dt_Aktivitet_Avdelning.Rows[ctr][1] = reader["LoadingTime"];
                    ctr++;
                }
            }
        }
        private void Load_dt_Teman()
        {
            dt_Teman = new DataTable();
            dt_Teman.Columns.Add("Tema");
            dt_Teman.Columns.Add("Procent", typeof(double));
            var row = 0;
            foreach (Themes tema in Enum.GetValues(typeof(Themes)))
            {
                dt_Teman.Rows.Add();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"SELECT COUNT(*) FROM Log.ActivityLog WHERE Info = '{tema}' AND UserID != (SELECT UserID FROM [User].Person WHERE Name ='Richard Aakula')";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var ctr = (int)cmd.ExecuteScalar();
                    dt_Teman.Rows[row][0] = tema.ToString();
                    dt_Teman.Rows[row][1] = ctr; 
                }
                row++;
            }
            var total = (double)dt_Teman.Compute("SUM(Procent)", string.Empty);
            for (var i = 0; i < dt_Teman.Rows.Count; i++)
            {
                var percent = Math.Round(double.Parse(dt_Teman.Rows[i][1].ToString()) / total * 100, 1);
                dt_Teman.Rows[i][1] = percent;
            }

        }
        #endregion

        #region 6...Lägg till DataTable in Load_All_DataTables
        private List<Action> Load_All_DataTables
        {
            get
            {
                var methods = new List<Action>
                {
                    Load_List_ProdLinje,
                    //Mätningar - Extrudering TEF - 6st
                    Load_dt_Mätning_Extrudering_TEF_Year,
                    Load_dt_Mätning_Extrudering_TEF_Year_Skift,
                    Load_dt_Mätning_Extrudering_TEF_Month,
                    Load_dt_Mätning_Extrudering_TEF_Day,
                    Load_dt_Mätning_Extrudering_TEF_LastWeek,
                    Load_dt_Mätning_Extrudering_TEF_DayOfWeek,
                    //Mätningar - Extrudering FEP - 6st
                    Load_dt_Mätning_Extrudering_FEP_Year,
                    Load_dt_Mätning_Extrudering_FEP_Year_Skift,
                    Load_dt_Mätning_Extrudering_FEP_Month,
                    Load_dt_Mätning_Extrudering_FEP_Day,
                    Load_dt_Mätning_Extrudering_FEP_LastWeek,
                    Load_dt_Mätning_Extrudering_FEP_DayOfWeek,
                    //Mätningar - Krympslang - 6st
                    Load_dt_Mätning_Krymp_Year,
                    Load_dt_Mätning_Krymp_Year_Skift,
                    Load_dt_Mätning_Krymp_Month,
                    Load_dt_Mätning_Krymp_Day,
                    Load_dt_Mätning_Krymp_LastWeek,
                    Load_dt_Mätning_Krymp_DayOfWeek,
                    //Mätningar - Slipning - 6st
                    Load_dt_Mätning_Slipning_Year,
                    Load_dt_Mätning_Slipning_Year_Skift,
                    Load_dt_Mätning_Slipning_Month,
                    Load_dt_Mätning_Slipning_Day,
                    Load_dt_Mätning_Slipning_LastWeek,
                    Load_dt_Mätning_Slipning_DayOfWeek,
                    //Mätningar - Svetsning - 6st
                    Load_dt_Mätning_Svetsning_Year,
                    Load_dt_Mätning_Svetsning_Year_Skift,
                    Load_dt_Mätning_Svetsning_Month,
                    Load_dt_Mätning_Svetsning_Day,
                    Load_dt_Mätning_Svetsning_LastWeek,
                    Load_dt_Mätning_Svetsning_DayOfWeek,
                    //Ordrar - 7st
                    Load_dt_Ordrar_Year,
                    Load_dt_Ordrar_Month,
                    Load_dt_Ordrar_ProdLinje,
                    Load_dt_Ordrar_ProdLinje_ThisYear,  Load_dt_Ordrar_ProdLinje_LastYear, Load_dt_Ordrar_ProdLinje_2_YearAgo,
                    Load_dt_Ordrar_ProdLinje_ThisMonth,
                    Load_dt_Ordrar_Tid_Order_ProdLinje,
                    Load_dt_Ordrar_Tid_Order_ProdLinje_Year,
                    //Processkort - Extrudering - 6st
                    Load_dt_RumsTemp_ProdLinje,
                    Load_dt_RumsFukt_ProdLinje,
                    Load_dt_Draghastighet_ProdLinje,
                    Load_dt_TorkTemp_ProdLinje,
                    Load_dt_Temp_Zon_Huvud_ProdLinje,
                    Load_dt_Temp_Zon_Munst_ProdLinje,
                    //Övrigt - 13st
                    Load_dt_Mätningar_ProdLinje,
                    Load_dt_Mätningar_ProdLinje_ThisYear, Load_dt_Mätningar_ProdLinje_LastYear, Load_dt_Mätningar_ProdLinje_2_YearAgo,
                    Load_dt_Mätning_Extr_ProdLinje_AvgID,
                    Load_dt_Mätningar_Extr_OD_Grupp,
                    Load_dt_Mätningar_Krymp_OD_Grupp,
                    Load_dt_RörFaktor_Krymp_QS,
                    Load_dt_Bokstäver_Per_Order_Per_År,
                    Load_dt_Aktivitet_Top_10_Användare,
                    Load_dt_Aktivitet_Avdelning,
                    Load_dt_Teman
                };
                return methods;
            }
        }
        #endregion

        #region 7...Välj Typ av Chart
        private SeriesChartType chartType(int row)
        {
            switch (row)
            {
                case 3:
                case 9:
                    return SeriesChartType.Line;
            }
            return SeriesChartType.Column;
        }
        #endregion




        public Statistik_Övrigt()
        {
            Activity.Start();
            var pbar = new ProgressBar();
            pbar.Show();
            double antal_Laddningar = Load_All_DataTables.Count;
            double value = 0;
            var step = 100 / antal_Laddningar;

            InitializeComponent();
            foreach (var method in Load_All_DataTables)
            {
                value += step;
                pbar.Set_ValueProgressBar(value, "Laddar Statistik...");
                method();
            }
            
            Fill_dgv_List_Statistik();
            Initialize_dgv_TotalWidth();

            pbar.Close();
            ctr_Queries = 0;
            
            Load_Chart(true, 0);
            _ = Activity.Stop("Statistik - Random - F7");
            timer_Change_Chart.Enabled = true;
            timer_Change_Chart.Start();
        }


        private void Fill_dgv_List_Statistik()
        {
            dgv_List_Statistik.Columns.Add("Namn", "Namn");
            for (var i = 0; i < list_Series_Names.GetLength(0); i++)
                dgv_List_Statistik.Rows.Add(list_Series_Names[i, 0]);
        }
        private void Load_List_ProdLinje()
        {
            List_ProdLinje = new List<string>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT DISTINCT ProdLine FROM [Order].MainData WHERE ProdLine IS NOT NULL AND ProdLine > '' ORDER BY ProdLine";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
               
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    List_ProdLinje.Add(reader[0].ToString());
            }
        }

       


        private void Load_Chart(bool is_select_Row_dgv, int step = 100)
        {
            if (step == 100)
            {
                var rnd = new Random();
                ctr_Queries = rnd.Next(dt_All.Length);
            }
            else
                ctr_Queries = step;
            ///Laddar rätt DataTable
            var dt = dt_All[ctr_Queries];

            ///Tömmer tidigare chart
            for (var i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].Points.Clear();
                if (i > dt.Columns.Count)
                    chart.Series[i].IsVisibleInLegend = false;
                else
                    chart.Series[i].IsVisibleInLegend = true;
            }

            chart.Legends[0].Enabled = false;
            

            ///Loopar igenom alla rader i DataTable och lägger till data i Chart
            ///Om det finns flera än 2 kolumner läggs den datan till som extra Serier
            //chart.Series[0].IsVisibleInLegend = false;
            //chart.Series[1].IsVisibleInLegend = false;
           // chart.Series[2].IsVisibleInLegend = false;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var x = dt.Rows[i][0].ToString();
                if (list_Series_Names[ctr_Queries, 1] == "Månad")
                    x = Month[x];

                double.TryParse(dt.Rows[i][1].ToString(), out var y);
                chart.Series[0].Points.AddXY(x, y);

                chart.Legends[0].Enabled = true;
                chart.Series[0].Name = dt.Columns[1].ColumnName;

                if (dt.Columns.Count > 2)
                {
                    for (var col = 1; col < dt.Columns.Count - 1; col++)
                    {
                        if (chart.Series.Count < col)
                            break;
                        chart.Series[col].IsVisibleInLegend = true;
                        chart.Series[col].Name = dt.Columns[col + 1].ColumnName;
                        double.TryParse(dt.Rows[i][col + 1].ToString(), out y);
                        chart.Series[col].Points.Add(y);
                    }
                }
              
            }
            foreach (var Serie in chart.Series)
                Serie.ChartType = chartType(step);

            Change_GUI_Chart();
            

            dgv_List_Statistik.RowEnter -= DataGridView_List_Statistik_RowEnter;
            if (is_select_Row_dgv)
                dgv_List_Statistik.CurrentCell = dgv_List_Statistik.Rows[ctr_Queries].Cells[0];

            dgv_List_Statistik.RowEnter += DataGridView_List_Statistik_RowEnter;
        }
        private void Change_GUI_Chart()
        {
            ///Skriver ut namnet för varje axel
            chart.ChartAreas[0].AxisX.Title = list_Series_Names[ctr_Queries, 1];
            chart.ChartAreas[0].AxisY.Title = list_Series_Names[ctr_Queries, 2];
            ///Skriver ut vilken statistik av max antal
            lbl_Chart_Index.Text = $"{ctr_Queries + 1} av {dt_All.Length}";

            try
            {
                chart.Titles[0].Text = rubriker_Chart[ctr_Queries];
            }
            catch
            {
                chart.Titles[0].Text = list_Series_Names[ctr_Queries, 0];
            }
            if (list_Series_Names[ctr_Queries, 1] == "Dag")
                chart.ChartAreas[0].AxisX.Interval = chart.Series[0].Points.Count / 10;
            else
                chart.ChartAreas[0].AxisX.Interval = 1;

            

        }
        private void Initialize_dgv_TotalWidth()
        {
            var width = 0;
            for (var i = 0; i < list_Series_Names.GetLength(0); i++)
            {
                var text = list_Series_Names[i, 0];
                if (TextRenderer.MeasureText(text, dgv_List_Statistik.Font).Width > width)
                    width = TextRenderer.MeasureText(text, dgv_List_Statistik.Font).Width;
            }
            tlp_Main.ColumnStyles[0].Width = width + 20;
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                if (result.ChartElementType != ChartElementType.DataPoint) 
                    continue;
                if (result.Object is DataPoint prop)
                    tooltip.Show($"{prop.YValues[0]}", chart, pos.X + 15, pos.Y - 15);
            }
            //mousePosition = (double)Height / MousePosition.Y;
        }
        private void Timer_Change_Chart_Tick(object sender, EventArgs e)
        {
            Load_Chart(true);
            timer_Change_Chart.Interval = 10000;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            timer_Change_Chart.Start();
            timer_Change_Chart.Interval = 10000;

            var step = ctr_Queries + 1;
            if (step > dt_All.Length - 1)
                step = 0;
            Load_Chart(true,step);
        }
        private void Previous_Click(object sender, EventArgs e)
        {
            timer_Change_Chart.Start();
            timer_Change_Chart.Interval = 60000;

            var step = ctr_Queries - 1;
            if (step < 0)
                step = dt_All.Length - 1;
            Load_Chart(true, step);
        }
        private void Chart_Click(object sender, EventArgs e)
        {
            Close();
        }

      
        private void DataGridView_List_Statistik_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            timer_Change_Chart.Stop();
            if (e.RowIndex < list_Series_Names.Length)
                Load_Chart(false, e.RowIndex);
        }
    }
}
