using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Control = System.Windows.Forms.Control;

namespace DigitalProductionProgram.ToolManagement
{
    public partial class ToolCalculator : Form
    {
        private readonly List<string?> List_DieType;
        private readonly List<string?> List_PinType;
        private bool IsOpening = true;
        private bool IsToManyCalculations(int totalSteps, bool isOkToOverrideCalculation)
        {
            if (totalSteps > 10000 && !isOkToOverrideCalculation)
            {
                label_Warning.Invoke((MethodInvoker)(() => label_Warning.Visible = true));
                label_Warning.Invoke((MethodInvoker)(() => label_Warning.Text =
                    $"Varning! Jag beräknar INTE automatiskt när det finns över 10000 beräkningar.\n" +
                    $"Klicka på Beräkna om du vill beräkna med dessa inställningar."));
                return true;
            }

            return false;
        }




        public ToolCalculator(AutoCompleteStringCollection collection)
        {
            Activity.Start();
            InitializeComponent();
            tb_OrderNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_OrderNr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_OrderNr.AutoCompleteCustomSource = collection;
            Fill_MainOrderInformation();
            Load_RegularSettings();
            List_DieType = Equipment.Equipment.List_Tool_Type("DIES");
            List_PinType = Equipment.Equipment.List_Tool_Type("TIPS");
            IsOpening = false;

        }
        private void ToolCalculator_Load(object sender, EventArgs e)
        {
            // Synkront anrop av async-metoder
            CalculateTools(true, false);
        }

        private void Fill_MainOrderInformation()
        {
            tb_OrderNr.Text = Order.OrderNumber;
            if (string.IsNullOrEmpty(Order.Operation) == false)
                tb_Operation.Text = $"{Order.Operation} - {Order.ProdLine}";
            tb_PartNumber.Text = Order.PartNumber;
            tb_Customer.Text = Order.Customer;

            if (Order.OrderID != null)
            {
                tb_ID.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "NOM"):F3}";
                tb_OD.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM"):F3}";
                tb_Wall.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "NOM"):F3}";
                tb_Length.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "NOM"):F3}";
            }

            // tb_DieType.Text = Tools.RegularUsedToolType("Munstycke");
            // tb_PinType.Text = Tools.RegularUsedToolType("Kanyler");
            IsOpening = false;
           
        }
        private void Load_RegularSettings()
        {
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                const string query = @"
        WITH MostCommonValues AS (
            SELECT TOP 1 WITH TIES DDR_min AS value, 'Most_Common_DDR_min' AS column_name FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY DDR_min ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES DDR_max, 'Most_Common_DDR_max' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY DDR_max ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Balance_min, 'Most_Common_Balance_min' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Balance_min ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Balance_max, 'Most_Common_Balance_max' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Balance_max ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Die_min, 'Most_Common_Die_min' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Die_min ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Die_max, 'Most_Common_Die_max' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Die_max ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Die_step, 'Most_Common_Die_step' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Die_step ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Pin_min, 'Most_Common_Pin_min' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Pin_min ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Pin_max, 'Most_Common_Pin_max' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Pin_max ORDER BY COUNT(*) DESC
            UNION ALL
            SELECT TOP 1 WITH TIES Pin_step, 'Most_Common_Pin_step' FROM RegularUsedCalculations WHERE UserID = @userid GROUP BY Pin_step ORDER BY COUNT(*) DESC
        )
        SELECT column_name, value FROM MostCommonValues;";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userid", Person.UserID);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var values = new Dictionary<string, decimal>();

                        while (reader.Read())
                        {
                            string columnName = reader.GetString(0);
                            decimal value = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            values[columnName] = value;
                        }

                        num_DDR_min.Value = values.TryGetValue("Most_Common_DDR_min", out var value1) ? value1 : 0;
                        num_DDR_max.Value = values.TryGetValue("Most_Common_DDR_max", out var value2) ? value2 : 0;
                        num_Balance_min.Value = values.TryGetValue("Most_Common_Balance_min", out var value3) ? value3 : 0;
                        num_Balance_max.Value = values.TryGetValue("Most_Common_Balance_max", out var value4) ? value4 : 0;
                        num_Die_min.Value = values.TryGetValue("Most_Common_Die_min", out var value5) ? value5 : 0;
                        num_Die_max.Value = values.TryGetValue("Most_Common_Die_max", out var value6) ? value6 : 0;
                        num_Die_step.Value = values.TryGetValue("Most_Common_Die_step", out var value7) ? value7 : 0;
                        num_Pin_min.Value = values.TryGetValue("Most_Common_Pin_min", out var value8) ? value8 : 0;
                        num_Pin_max.Value = values.TryGetValue("Most_Common_Pin_max", out var value9) ? value9 : 0;
                        num_Pin_step.Value = values.TryGetValue("Most_Common_Pin_step", out var value10) ? value10 : 0;

                    }
                }
            }
        }
        private void timer_OkSaveCalculation_Tick(object sender, EventArgs e)
        {
            timer_OkSaveCalculation.Stop();
        }

        private void OrderNr_Leave(object sender, EventArgs e)
        {
            Monitor.Monitor.Load_Order(tb_OrderNr.Text);
           
        }
        private void Operation_MouseClick(object sender, MouseEventArgs e)
        {
            Control[] controls = { tb_Operation };
            var ops = Monitor.Monitor.List_Operations(tb_OrderNr.Text, null);
            IEnumerable<string?> opsStrings = ops.Select(op => $"{op.Operation} - {op.Description}");
            var chooseOperation = new Choose_Item(opsStrings, controls, false);
            chooseOperation.ShowDialog();

        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            CalculateTools(true, true);
        }
        private void Abort_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel(); // Trigger cancellation
        }
        private void DieType_MouseClick(object sender, MouseEventArgs e)
        {
            var chooseDieType = new Choose_Item(List_DieType, new Control[]{ tb_DieType }, false);
            chooseDieType.ShowDialog();

        }
        private void PinType_MouseClick(object sender, MouseEventArgs e)
        {
            var chooseDieType = new Choose_Item(List_PinType, new Control[] { tb_PinType }, false);
            chooseDieType.ShowDialog();
        }
        private void CalculateWalls_TextChanged(object sender, EventArgs e)
        {
            var ID = Calculation.ParseValue(tb_ID.Text);
            var OD = Calculation.ParseValue(tb_OD.Text);

            var Wall = (OD - ID) / 2;
            tb_Wall.Text = $"{Wall:F3}";
            CalculateTools(false, false);
        }
        private void Calculate_ControlChanged(object sender, EventArgs e)
        {
            CalculateTools(false, true);
        }
        private void DieType_TextChanged(object sender, EventArgs e)
        {
            var tools = new List<Die>();

            var partCodes = Task.Run(() =>
                Utilities.GetFromMonitor<Inventory.PartCodes>($"filter=Description  Eq'DIES'")).Result;
            foreach (var partCode in partCodes)
            {
                var parts = Task.Run(() =>
                    Utilities.GetFromMonitor<Inventory.Parts>($"filter=PartCodeId Eq'{partCode.Id}' AND ExtraDescription eq'{tb_DieType.Text}' AND IsNull(BlockedById)")).Result; 

                foreach (var part in parts)
                {
                    var dimension = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Common.ExtraFields>("select=DecimalValue", $"filter=ParentId Eq'{part.Id}' AND Identifier Eq'T4'")).Result;
                    var landlength = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Common.ExtraFields>("select=DecimalValue", $"filter=ParentId Eq'{part.Id}' AND Identifier Eq'T9'")).Result;

                    tools.Add(new Die(dimension.DecimalValue, landlength.DecimalValue));
                }
            }


            cb_Die.DataSource = null;  //Reset before binding
            cb_Die.DataSource = tools;
            cb_Die.DisplayMember = "Dimension";  //Matches property in `Die`
            cb_Die.ValueMember = "LandLength";   //Matches property in `Die`
            lbl_AntalMunstycken.Text = cb_Die.Items.Count.ToString();
            cb_Die.SelectedIndex = -1;
            if(IsOpening == false)
                Tools.AddRegularUsedToolTypeForUser("Munstycke");

        }
        private void PinType_TextChanged(object sender, EventArgs e)
        {
            var tools = new List<Die>();

            var partCodes = Task.Run(() =>
                Utilities.GetFromMonitor<Inventory.PartCodes>($"filter=Description  Eq'TIPS'")).Result;
            foreach (var partCode in partCodes)
            {
                var parts = Task.Run(() =>
                    Utilities.GetFromMonitor<Inventory.Parts>($"filter=PartCodeId Eq'{partCode.Id}' AND ExtraDescription eq'{tb_PinType.Text}' AND IsNull(BlockedById)")).Result;

                foreach (var part in parts)
                {
                    var dimension = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Common.ExtraFields>("select=DecimalValue", $"filter=ParentId Eq'{part.Id}' AND Identifier Eq'T4'")).Result;
                    var landlength = Task.Run(() =>
                        Utilities.GetOneFromMonitor<Common.ExtraFields>("select=DecimalValue", $"filter=ParentId Eq'{part.Id}' AND Identifier Eq'T9'")).Result;

                    tools.Add(new Die(dimension.DecimalValue, landlength.DecimalValue));
                }
            }

            cb_Pin.DataSource = null;  //Reset before binding
            cb_Pin.DataSource = tools;
            cb_Pin.DisplayMember = "Dimension"; 
            cb_Pin.ValueMember = "LandLength";   
            lbl_AntalKanyl.Text = cb_Pin.Items.Count.ToString();
            cb_Pin.SelectedIndex = -1;
            if (IsOpening == false)
                Tools.AddRegularUsedToolTypeForUser("Kanyl");
        }

        private CancellationTokenSource _cancellationTokenSource = null!;
        private async void CalculateTools(bool isOkToOverrideCalculation, bool isOkStoreCalculation)
        {
            try
            {
                if (IsOpening)
                    return;
                this.Cursor = Cursors.WaitCursor;

                // Disable the button and show the progress bar on the main thread
                btn_StartCalculation.Invoke((MethodInvoker)(() => btn_StartCalculation.Enabled = false));
                //pbar_Calculate.Invoke((MethodInvoker)(() => pbar_Calculate.Visible = true));

                dgv_Combinations.Invoke((MethodInvoker)(() => dgv_Combinations.Rows.Clear()));

                _cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = _cancellationTokenSource.Token;

                // Run the calculation in a background task with cancellation support
                await Task.Run(() => CalculateWithTools(!rb_Register.Checked, isOkToOverrideCalculation, cancellationToken), cancellationToken);

                // Update UI elements after the calculation is done (on the main thread)
                lbl_TotalCombinations.Invoke((MethodInvoker)(() => lbl_TotalCombinations.Text = $"{dgv_Combinations.Rows.Count} verktygskombinationer."));

                // Update DataGridView color on the main thread
                if (dgv_Combinations.InvokeRequired)
                    dgv_Combinations.Invoke((MethodInvoker)SetColor_Combinations);
                else
                    SetColor_Combinations();

                btn_StartCalculation.Invoke((MethodInvoker)(() => btn_StartCalculation.Enabled = true));
                if (isOkStoreCalculation)
                    SaveCalculation();
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                throw; // TODO handle exception
            }
        }
        private void SaveCalculation()
        {
            if (timer_OkSaveCalculation.Enabled)
                return;

            timer_OkSaveCalculation.Start();
            using var con = new SqlConnection(Database.cs_ToolRegister);
            const string query = @"INSERT INTO RegularUsedCalculations (UserID, DDR_min, DDR_max, Balance_min, Balance_max, Die_min, Die_max, Die_step, Pin_min, Pin_max, Pin_step, CreatedDate)
                                    VALUES (@userid, @ddrmin, @ddrmax, @balancemin, @balancemax, @diemin, @diemax, @diestep, @pinmin, @pinmax, @pinstep, @createddate)";

            using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@userid", Person.UserID);
            cmd.Parameters.AddWithValue("@ddrmin", num_DDR_min.Value);
            cmd.Parameters.AddWithValue("@ddrmax", num_DDR_max.Value);
            cmd.Parameters.AddWithValue("@balancemin", num_Balance_min.Value);
            cmd.Parameters.AddWithValue("@balancemax", num_Balance_max.Value);
            cmd.Parameters.AddWithValue("@diemin", num_Die_min.Value);
            cmd.Parameters.AddWithValue("@diemax", num_Die_max.Value);
            cmd.Parameters.AddWithValue("@diestep", num_Die_step.Value);
            cmd.Parameters.AddWithValue("@pinmin", num_Pin_min.Value);
            cmd.Parameters.AddWithValue("@pinmax", num_Pin_max.Value);
            cmd.Parameters.AddWithValue("@pinstep", num_Pin_step.Value);

            cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
        private async void CalculateWithTools(bool useTheoretical, bool isOkToOverrideCalculation, CancellationToken cancellationToken)
        {
            InitializeCalculation();

            var calc = new Calculation(tb_ID.Text, tb_OD.Text, tb_Wall.Text,
                num_DDR_min.Text, num_DDR_max.Text,
                num_Balance_min.Text, num_Balance_max.Text,
                tb_PullerSpeed.Text, tb_Density.Text);

            var (dieValues, pinValues) = GetDieAndPinValues(useTheoretical);

            var totalSteps = dieValues.Count * pinValues.Count;
            pbar_Calculate.Invoke((MethodInvoker)(() => pbar_Calculate.Maximum = totalSteps));

            lbl_TotalCalculations.Invoke((MethodInvoker)(() => lbl_TotalCalculations.Text = $"{totalSteps}"));
            if (IsToManyCalculations(totalSteps, isOkToOverrideCalculation)) 
                return;
            pbar_Calculate.Invoke((MethodInvoker)(() => pbar_Calculate.Visible = true));

            await PerformCalculationAsync(calc, dieValues, pinValues, useTheoretical, cancellationToken);

            FinalizeCalculation();
        }
        private void InitializeCalculation()
        {
            label_Warning.Invoke((MethodInvoker)(() => label_Warning.Visible = false));
            btn_StartCalculation.Invoke((MethodInvoker)(() => btn_StartCalculation.Enabled = false));
        }

        private (List<(double Dimension, double LandLength)>, List<(double Dimension, double LandLength)>) GetDieAndPinValues(bool useTheoretical)
        {
            double selectedDieDim = 0;
            double selectedPinDim = 0;
            cb_Die.Invoke((MethodInvoker)(() => double.TryParse(cb_Die.Text, out selectedDieDim)));
            cb_Pin.Invoke((MethodInvoker)(() => double.TryParse(cb_Pin.Text, out selectedPinDim)));

            var isDieSelected = selectedDieDim > 0;
            var isPinSelected = selectedPinDim > 0;

            List<(double Dimension, double LandLength)> dieValues, pinValues;

            if (useTheoretical)
            {
                var dieMin = double.Parse(num_Die_min.Text);
                var dieMax = double.Parse(num_Die_max.Text);
                var dieStepper = double.Parse(num_Die_step.Text);
                dieValues = Enumerable.Range(0, (int)((dieMax - dieMin) / dieStepper) + 1)
                                      .Select(i => (dieMin + (i * dieStepper), 0.0))
                                      .ToList();

                var pinMin = double.Parse(num_Pin_min.Text);
                var pinMax = double.Parse(num_Pin_max.Text);
                var pinStepper = double.Parse(num_Pin_step.Text);
                pinValues = Enumerable.Range(0, (int)((pinMax - pinMin) / pinStepper) + 1)
                                      .Select(i => (pinMin + (i * pinStepper), 0.0))
                                      .ToList();
            }
            else
            {
                var dieItems = isDieSelected ? new List<object> { cb_Die.SelectedItem } : cb_Die.Items.Cast<object>().ToList();
                var pinItems = isPinSelected ? new List<object> { cb_Pin.SelectedItem } : cb_Pin.Items.Cast<object>().ToList();

                dieValues = dieItems.Select(d => ((d as Die)?.Dimension ?? 0.00, (d as Die)?.LandLength ?? 0.0)).ToList();
                pinValues = pinItems.Select(p => ((p as Pin)?.Dimension ?? 0.00, (p as Pin)?.LandLength ?? 0.0)).ToList();
            }

            return (dieValues, pinValues);
        }

        

        private async Task PerformCalculationAsync(Calculation calc, List<(double Dimension, double LandLength)> dieValues, List<(double Dimension, double LandLength)> pinValues, bool useTheoretical, CancellationToken cancellationToken)
        {
            int progress = 0;
            var newRows = new List<DataGridViewRow>();

            await Task.Run(async () =>
            {
                foreach (var (pin_Dimension, pin_LL) in pinValues)
                {
                    foreach (var (die_Dimension, die_LL) in dieValues)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;

                        bool exists = false;

                        if (dgv_Combinations.IsHandleCreated)
                        {
                            dgv_Combinations.Invoke((MethodInvoker)(() =>
                            {
                                exists = dgv_Combinations.Rows.Cast<DataGridViewRow>().Any(row =>
                                    row.Cells[0].Value != null && row.Cells[2].Value != null &&
                                    double.TryParse(row.Cells[0].Value.ToString(), out var existingDie) &&
                                    double.TryParse(row.Cells[2].Value.ToString(), out var existingPin) &&
                                    existingDie == die_Dimension && existingPin == pin_Dimension);
                            }));
                        }

                        if (exists)
                        {
                            progress++;
                            continue;
                        }

                        calc.Pin = pin_Dimension;
                        calc.Die = die_Dimension;

                        if (calc.IsCombinationOk)
                        {
                            var row = new DataGridViewRow();
                            row.CreateCells(dgv_Combinations,
                                $"{die_Dimension:0.00}",
                                useTheoretical ? "N/A" : $"{die_LL:0.0}",
                                $"{pin_Dimension:0.00}",
                                useTheoretical ? "N/A" : $"{pin_LL:0.0}",
                                $"{calc.ToolGap:0.000}",
                                $"{calc.DDR:0.00}",
                                $"{calc.Balance:0.000}",
                                $"{calc.ShearRate:0}");
                            newRows.Add(row);
                        }

                        progress++;

                        if (pbar_Calculate.IsHandleCreated)
                        {
                            pbar_Calculate.Invoke((MethodInvoker)(() =>
                            {
                                pbar_Calculate.Value = Math.Min(progress, pbar_Calculate.Maximum);
                            }));
                        }

                        if (progress % 500 == 0)
                            await Task.Delay(1, cancellationToken);
                    }
                }
            }, cancellationToken);

            if (dgv_Combinations.IsHandleCreated)
                dgv_Combinations.Invoke((MethodInvoker)(() => dgv_Combinations.Rows.AddRange(newRows.ToArray())));
        }

        private void FinalizeCalculation()
        {
            lbl_TotalCombinations.Invoke((MethodInvoker)(() =>
                lbl_TotalCombinations.Text = $"{dgv_Combinations.Rows.Count} verktygskombinationer."));

            pbar_Calculate.Invoke((MethodInvoker)(() => pbar_Calculate.Visible = false));
            btn_StartCalculation.Invoke((MethodInvoker)(() => btn_StartCalculation.Enabled = true));

            Task.Run(async () =>
            {
                await Task.Delay(500); // Fördröjning för att undvika konflikt
                SetColor_Combinations();
            });
        }
        private void SetColor_Combinations()
        {
            if (!dgv_Combinations.IsHandleCreated)
                return;

            Task.Run(() =>
            {
                dgv_Combinations.Invoke((MethodInvoker)(() =>
                {
                    foreach (DataGridViewRow row in dgv_Combinations.Rows)
                    {
                        if (!double.TryParse(row.Cells["col_DieLL"].Value?.ToString(), out var die_LL))
                            die_LL = 0;
                        if (!double.TryParse(row.Cells["col_PinLL"].Value?.ToString(), out var pin_LL))
                            pin_LL = 0;

                        var isTheoretical = rb_TheoreticalTools.Checked;

                        if ((die_LL > 0 && pin_LL > 0) || isTheoretical)
                        {
                            row.DefaultCellStyle.BackColor = die_LL > pin_LL
                                ? CustomColors.Warning_Back
                                : CustomColors.Ok_Back;

                            row.DefaultCellStyle.ForeColor = die_LL > pin_LL
                                ? CustomColors.Warning_Front
                                : CustomColors.Ok_Front;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                            row.DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                        }
                    }
                }));
            });
        }




        public class Calculation(string id, string od, string wall, string ddr_min, string ddr_max, string balance_min, string balance_max, string pullerspeed, string density)
        {
            private double ID { get; set; } = ParseValue(id);
            private double OD { get; set; } = ParseValue(od);
            public double Wall { get; set; } = ParseValue(wall);
            private double DDR_min { get; set; } = ParseValue(ddr_min);
            private double DDR_max { get; set; } = ParseValue(ddr_max);
            private double PullerSpeed { get; set; } = ParseValue(pullerspeed);
            private double Density { get; set; } = ParseValue(density);
            private double Balance_min { get; set; } = ParseValue(balance_min);
            private double Balance_max { get; set; } = ParseValue(balance_max);
            public double Die { get; set; }
            public double Pin { get; set; }

            public bool IsCombinationOk => DDR < DDR_max & DDR > DDR_min & Balance < Balance_max & Balance > Balance_min & ToolGap > 0;
            public double DDR => Math.Round((Die * Die - Pin * Pin) / (OD * OD - ID * ID), 2);
            public double ToolGap => Math.Round((Die - Pin) / 2, 3);
            public double Balance => Math.Round(Die / OD / (Pin / ID), 4);
            public double ShearRate
            {
                get
                {
                    const double MeltDensity = 1.492;

                    // Calculate radii
                    var outerRadius = OD / 2;
                    var innerRadius = ID / 2;

                    // Calculate channel width (W) and height (H)
                    var channelWidth = Math.PI * ((Die + Pin) / 2);
                    var channelHeight = (Die - Pin) / 2;

                    // Calculate flow area (A)
                    var flowArea = Math.PI * (Math.Pow(outerRadius, 2) - Math.Pow(innerRadius, 2));

                    // Calculate extrusion rate (Q)
                    var extrusionRate = flowArea * PullerSpeed * 60 * Density / 1000;

                    // Compute shear rate (γ̇)
                    var shearRate = extrusionRate / (600 * MeltDensity * (channelWidth * (channelHeight * channelHeight))) * 1_000_000;

                    return Math.Round(shearRate, 0);
                }
            }

            public static double ParseValue(string value)
            {
                return double.TryParse(value, out double result) ? result : 0.0;
            }

        }

        public class Die
        {
            public double Dimension { get; set; }
            public double LandLength { get; set; }

            public Die(string dimension, string landLength)
            {
                Dimension = Calculation.ParseValue(dimension);
                LandLength = Calculation.ParseValue(landLength);
            }

            public override string ToString()
            {
                return Dimension.ToString("F2"); // Show this in the ComboBox
            }
        }
        public class Pin
        {
            public double Dimension { get; set; }
            public double LandLength { get; set; }

            public Pin(string dimension, string landLength)
            {
                Dimension = Calculation.ParseValue(dimension);
                LandLength = Calculation.ParseValue(landLength);
            }

            public override string ToString()
            {
                return Dimension.ToString("F2"); // Show this in the ComboBox
            }
        }

        private void ToolCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ = Activity.Stop($"Beräknat Verktyg.");
        }
    }
}
