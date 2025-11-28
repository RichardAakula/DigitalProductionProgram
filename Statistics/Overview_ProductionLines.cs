using System.Diagnostics;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using CustomProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.Statistics
{
    public partial class Overview_ProductionLines : Form
    {
        private int ctr;
        private int ctr_pBar = 5;
        private int ctrPictures => (screenWidth / panelWidth);
        private readonly int screenWidth;
        private const int panelWidth = 350;
        private const int panelHeight = 350;
        private const int lbl_x = 100;


        private readonly List<ProductionLines> productionLines = new List<ProductionLines>();
        private readonly List<Panel> panels = new List<Panel>();
        private readonly CustomProgressBar pbar;




        public Overview_ProductionLines()
        {
            InitializeComponent();
            Translate_Form();

            pbar = new CustomProgressBar();
            pbar.Show();
            pbar.Set_ValueProgressBar(0, "Loading Data...");
            this.Refresh();
            panel_Main.HorizontalScroll.Visible = false;
            screenWidth = Screen.FromControl(this).Bounds.Size.Width;
            Order.Save_TempOrderInfo();


            Load_ProdLines();
            PrintInfo();
            timer_UpdateInfo.Start();
            CustomProgressBar.close();
            pbar.Close();
            Order.Restore_TempOrderInfo();
        }


        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_ProductionLines_Header, label_ProductionLines_Green, label_ProductionLines_Red, label_ProductionLines_Info});
        }
        private void Load_ProdLines()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                // 🔹 1. Hämta antal rader
                const string countQuery = @"
                    SELECT COUNT(*) FROM 
                        (
                            SELECT ProdLine
                            FROM 
                                (
                                    SELECT ProdLine, ROW_NUMBER() OVER(PARTITION BY ProdLine ORDER BY Date_Start DESC) rowNumber
                                    FROM [Order].MainData
                                    WHERE ProdLine > '' AND (IsDeleted = 'False' OR IsDeleted IS NULL) AND IsOrderDone = 'False'
                                ) a
                            WHERE rowNumber = 1
                        ) AS b";

                var totalCount = 0;
                using (var countCmd = new SqlCommand(countQuery, con))
                {
                    ServerStatus.Add_Sql_Counter();
                    con.Open();
                    totalCount = (int)countCmd.ExecuteScalar();
                    con.Close();
                }

                // 🔹 2. Hämta faktiska rader
                const string query = @"
                    SELECT * 
                        FROM 
                            (
                                SELECT ProdLine, PartNr, Customer, OrderNr, Operation, Description, Amount, Unit, Date_Start, IsOrderDone, ROW_NUMBER() 
                                OVER
                                    (
                                        PARTITION BY ProdLine 
                                        ORDER BY Date_Start DESC
                                    ) rowNumber
                                FROM [Order].MainData
                        WHERE ProdLine > '' AND (IsDeleted = 'False' OR IsDeleted IS NULL) AND IsOrderDone = 'False'
                            ) a
                    WHERE rowNumber = 1
                    ORDER BY IsOrderDone, Date_Start";

                using (var cmd = new SqlCommand(query, con))
                {
                    ServerStatus.Add_Sql_Counter();
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var ctr = 0;
                        while (reader.Read())
                        {
                            bool.TryParse(reader["IsOrderDone"].ToString(), out var isOrderDone);

                            productionLines.Add(new ProductionLines
                            {
                                ProdLine = reader["ProdLine"].ToString(),
                                PartNr = reader["PartNr"].ToString(),
                                Customer = reader["Customer"].ToString(),
                                OrderNr = reader["OrderNr"].ToString(),
                                Operation = reader["Operation"].ToString(),
                                Description = reader["Description"].ToString(),
                                Amount = reader["Amount"].ToString(),
                                Pcs = reader["Unit"].ToString(),
                                Start = reader["Date_Start"].ToString(),
                                IsOrderDone = isOrderDone
                            });

                            // 🔹 3. Uppdatera progressbar baserat på totalCount
                            ctr++;
                            double progress = totalCount > 0 ? (ctr / (double)totalCount) * 100 : 0;
                            pbar.Set_ValueProgressBar(ctr, LanguageManager.GetString("loadingProductionlines_1"), progress, true);

                            this.Refresh();
                        }
                    }
                }
            }

            ctr_pBar = 30; // Valfri logik, som du hade innan
        }


        private void PrintInfo()
        {
            if (productionLines == null || productionLines.Count == 0)
                return;

            var x = 20;
            var y = 100;
            var total = productionLines.Count;

            double startProgress = ctr_pBar;
            double add = (100.0 - startProgress) / total;

            for (var i = 0; i < total; i++)
            {
                ctr = i;
                Order.OrderNumber = productionLines[ctr].OrderNr;
                Order.Operation = productionLines[ctr].Operation;

                double newProgress = startProgress + (i + 1) * add;
                newProgress = Math.Min(100.0, newProgress);
                ctr_pBar = (int)newProgress;

                pbar.Set_ValueProgressBar(ctr_pBar, LanguageManager.GetString("loadingProductionlines_2"), newProgress, true);

                this.Refresh();

                // Skriv ut panelen
                Print_Panel(x, y);
                PrintPanelContent();

                // Layout-placering
                x = x + panelWidth + 20;
                if ((i + 1) % ctrPictures == 0)
                {
                    x = 20;
                    y = y + panelHeight + 20;
                }
            }
            ctr_pBar = 100;
        }


        private void AddLabel(string? titleKey, string? value, int y, bool isOrderDone)
        {
            var title = LanguageManager.GetString(titleKey);

            var valueLabel = new Label
            {
                Text = isOrderDone ? "N/A" : value,
                AutoSize = true,
                ForeColor = isOrderDone ? Color.Red : Color.White,
                Location = new Point(lbl_x, y),
                MaximumSize = new Size(215, 30)
            };
            valueLabel.Click += Copy_TextClick;

            var titleLabel = new Label
            {
                Text = title,
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, y)
            };

            panels[ctr].Controls.Add(valueLabel);
            panels[ctr].Controls.Add(titleLabel);
        }
        private void Print_Panel(int x, int y)
        {
            var panel = new Panel
            {
                Size = new Size(panelWidth, panelHeight),
                BorderStyle = BorderStyle.FixedSingle,
                Name = ctr.ToString(),
                Location = new Point(x, y),
                Cursor = Cursors.Hand
            };
            panel.Click += Panel_Click;
            panel_Main.Controls.Add(panel);
            panels.Add(panel);
        }
        private void PrintPanelContent()
        {
            var line = productionLines[ctr];
            bool isDone = line.IsOrderDone;

            // Rad 1: Namn
            var nameLabel = new Label
            {
                Text = line.ProdLine,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                ForeColor = isDone ? Color.FromArgb(156, 0, 6) : Color.FromArgb(0, 97, 0),
                Location = new Point((panelWidth / 2) - TextRenderer.MeasureText(line.ProdLine, new Font("Arial", 12, FontStyle.Bold)).Width / 2, 10)
            };
            panels[ctr].Controls.Add(nameLabel);
           
            // Rad 2–6: Generiska fält
            AddLabel("label_OrderNr", line.OrderNr, 50, isDone);
            AddLabel("label_Customer", line.Customer, 85, isDone);
            AddLabel("label_Description", line.Description, 120, isDone);
            AddLabel("label_Amount", $"{line.Amount} {line.Pcs}", 155, isDone);

            AddLabel("dateStart", line.Start, 245, isDone);

            // Rad 7: Runtime
            AddOrderRuntimeLabel(line.Start, isDone, 280);

            // Rad 8: Produktionstid
            AddTotalProductionTimeLabel(line.ProdLine, isDone, 305);
        }
        private void AddOrderRuntimeLabel(string? start, bool isDone, int y)
        {
            DateTime.TryParse(start, out var birth);
            var ts = DateTime.Now - birth;

            var text = isDone
                ? "N/A"
                : $"{ts.Days} days, {ts.Hours} hours, {ts.Minutes} minutes";

            var lbl = new Label
            {
                Text = text,
                AutoSize = true,
                ForeColor = isDone ? Color.Red : (ts.Days > 100 ? Color.Red : Color.White),
                Location = new Point(lbl_x, y)
            };

            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("orderRuntime"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, y)
            };

            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void AddTotalProductionTimeLabel(string? prodLine, bool isDone, int y)
        {
            if (isDone)
            {
                AddLabel("orderProdtime", "N/A", y, true);
                return;
            }

            var minutes = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
            SELECT DATEDIFF(MINUTE, Date_Start, Date_Stop)
            FROM [Order].MainData
            WHERE ProdLine = @prodline
              AND Date_Start IS NOT NULL
              AND Date_Stop IS NOT NULL
              AND DATEDIFF(MINUTE, Date_Start, Date_Stop) > 0
              AND DATEDIFF(HOUR, Date_Start, Date_Stop) < 1500
              AND IsDeleted = 'false'";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@prodline", prodLine);
                ServerStatus.Add_Sql_Counter();
                con.Open();

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    minutes += reader.GetInt32(0);
            }

            var ts = TimeSpan.FromMinutes(minutes);
            var text = $"{ts.Days} days, {ts.Hours} hours, {ts.Minutes} minutes";
            AddLabel("orderProdtime", text, y, false);
        }
        private void Copy_TextClick(object? sender, EventArgs e)
        {
            if (sender is Label lbl)
                Clipboard.SetText(lbl.Text);
        }

       
       


        private void Info_MouseEnter(object sender, EventArgs e)
        {
            panel_Info.Visible = true;
        }
        private void Info_MouseLeave(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var nr = int.Parse(ctrl.Name);
            var prodlinje = productionLines[nr].ProdLine;
            using var black = new BlackBackground("", 80);
            using var stat_Prod = new Statistics_ProdLine(prodlinje);
            black.Show();
            stat_Prod.ShowDialog();
            black.Close();

        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private class ProductionLines
        {
            public string? ProdLine { get; set; }
            public string? PartNr { get; set; }
            public string? OrderNr { get; set; }
            public string? Operation { get; set; }
            public string? Customer { get; set; }
            public string? Description { get; set; }
            public string? Amount { get; set; }
            public string? Pcs { get; set; }
            public string? Start { get; set; }
            public bool IsOrderDone { get; set; }
        }


    }
}
