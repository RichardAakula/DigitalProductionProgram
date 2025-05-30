using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;

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
        private readonly ProgressBar pbar;




        public Overview_ProductionLines()
        {
            InitializeComponent();
            Translate_Form();

            pbar = new ProgressBar();
            pbar.Show();
            panel_Main.HorizontalScroll.Visible = false;
            screenWidth = Screen.FromControl(this).Bounds.Size.Width;
            Order.Save_TempOrderInfo();


            Load_ProdLines();
            PrintInfo();
            timer_UpdateInfo.Start();
            ProgressBar.close();

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
                var query = @"
                        SELECT * 
                        FROM (SELECT ProdLine, PartNr, Customer, OrderNr, 
                                Operation, Description, Amount,  
                                Unit, Date_Start, IsOrderDone, 
                                ROW_NUMBER() OVER(PARTITION BY ProdLine ORDER BY Date_Start DESC) rowNumber
                              FROM [Order].MainData
                              WHERE ProdLine > '' AND (IsDeleted = 'False' OR IsDeleted IS NULL)) a
                        WHERE rowNumber = 1
                    ORDER BY IsOrderDone, Date_Start";

                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pbar.Set_ValueProgressBar(ctr_pBar, LanguageManager.GetString("loadingProductionlines_1"));
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
                    ctr++;
                }
            }
            ctr_pBar = 30;
        }

        private void PrintInfo()
        {
            var x = 20;
            var y = 60;
            var add = (100 - ctr_pBar) / productionLines.Count;
            for (var i = 1; i < productionLines.Count + 1; i++)
            {
                ctr = i - 1;
                Order.OrderNumber = productionLines[ctr].OrderNr;
                Order.Operation = productionLines[ctr].Operation;
                pbar.Set_ValueProgressBar(ctr_pBar, LanguageManager.GetString("loadingProductionlines_2"));

                Print_Panel(x, y);
                Print_Name();
                Print_OrderNr();
                Print_Customer();
                Print_Description();
                Print_Amount();

                Print_DateStart();
                Print_OrderRuntime();
                Print_TotalProductionTime(productionLines[ctr].ProdLine);

                x = x + panelWidth + 20;
                if (i % ctrPictures == 0)
                {
                    x = 20;
                    y = y + panelHeight + 20;
                }
                ctr_pBar += add;
            }
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
        private void Print_Name()
        {
            var lbl = new Label
            {
                Text = productionLines[ctr].ProdLine,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true
            };
            if (productionLines[ctr].IsOrderDone)
                lbl.ForeColor = Color.FromArgb(156, 0, 6);
            else
                lbl.ForeColor = Color.FromArgb(0, 97, 0);

            lbl.Location = new Point((panelWidth / 2) - TextRenderer.MeasureText(lbl.Text, lbl.Font).Width / 2, 10);
            panels[ctr].Controls.Add(lbl);
        }
        private void Print_OrderNr()
        {
            var lbl = new Label
            {
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(lbl_x, 50)
            };
            if (productionLines[ctr].IsOrderDone == false)
                lbl.Text = productionLines[ctr].OrderNr;
            else
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Red;
            }
            var lbl2 = new Label
            {
                Text = "OrderNr:",
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 50)
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void Print_Customer()
        {
            var lbl = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(lbl_x, 85),
                MaximumSize = new Size(215, 30)
            };
            if (productionLines[ctr].IsOrderDone == false)
                lbl.Text = productionLines[ctr].Customer;
            else
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Red;
            }

            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("label_Customer"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 85)
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void Print_Description()
        {
            var lbl = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(lbl_x, 120),
                MaximumSize = new Size(215, 30)
            };
            if (productionLines[ctr].IsOrderDone == false)
                lbl.Text = productionLines[ctr].Description;
            else
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Red;
            }

            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("label_Description"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 120)
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void Print_Amount()
        {
            var lbl = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(lbl_x, 155)
            };
            if (productionLines[ctr].IsOrderDone == false)
                lbl.Text = productionLines[ctr].Amount + " " + productionLines[ctr].Pcs;
            else
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Red;
            }

            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("label_Amount"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 155)
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void Print_DateStart()
        {
            var lbl = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(lbl_x, 225)
            };
            if (productionLines[ctr].IsOrderDone == false)
                lbl.Text = productionLines[ctr].Start;
            else
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Red;
            }

            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("dateStart"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 225)
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void Print_OrderRuntime()
        {
            DateTime.TryParse(productionLines[ctr].Start, out var birth);
            var now = DateTime.Now;

            var lbl = new Label();
            var ts = now - birth;
            if (ts.Days > 100)
                lbl.ForeColor = Color.Red;
            else
                lbl.ForeColor = Color.White;

            if (productionLines[ctr].IsOrderDone == false)
                lbl.Text = $"{ts.Days} days, {ts.Hours} hours, {ts.Minutes} minutes";
            else
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Red;
            }

            lbl.AutoSize = true;
            lbl.Location = new Point(lbl_x, 260);

            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("orderRuntime"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 260)
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
        }
        private void Print_TotalProductionTime(string? prodLinje)
        {
            Order.ProdLine = prodLinje;
            Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation(false);
            var minutes = 0;
           
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                SELECT DATEDIFF(MINUTE, Date_Start, Date_Stop), DATEDIFF(HH, Date_Start, Date_Stop)
                FROM [Order].MainData 
                   
                WHERE ProdLine = @prodline
                    AND Date_Start IS NOT NULL
                    AND Date_Stop IS NOT NULL
                    AND DATEDIFF(MINUTE, Date_Start, Date_Stop) > 0 AND DATEDIFF(HH, Date_Start, Date_Stop) < 1500
                    AND IsDeleted = 'false'";
                

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@prodline", productionLines[ctr].ProdLine);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[0].ToString(), out var value);
                        minutes += value;
                }
            }
            var ts = TimeSpan.FromMinutes(double.Parse(minutes.ToString()));
            var lbl = new Label
            {
                Text = $"{ts.Days} days, {ts.Hours} hours, {ts.Minutes} minutes",
                ForeColor = Color.White,
                Location = new Point(lbl_x, 307),
                AutoSize = true
            };
            var lbl2 = new Label
            {
                Text = LanguageManager.GetString("orderProdtime"),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 295),
                Height = 30
            };
            panels[ctr].Controls.Add(lbl);
            panels[ctr].Controls.Add(lbl2);
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
            var black = new BlackBackground("", 80);
            var stat_Prod = new Statistics_ProdLine(prodlinje);
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
            public string PartNr { get; set; }
            public string? OrderNr { get; set; }
            public string? Operation { get; set; }
            public string Customer { get; set; }
            public string Description { get; set; }
            public string Amount { get; set; }
            public string Pcs { get; set; }
            public string Start { get; set; }
            public bool IsOrderDone { get; set; }
        }


    }
}
