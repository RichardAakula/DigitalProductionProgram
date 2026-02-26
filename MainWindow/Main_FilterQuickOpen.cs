using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using Microsoft.Data.SqlClient;
using System.Data;
using DigitalProductionProgram.ControlsManagement;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_FilterQuickOpen : Form
    {
        private static DataTable? DataTable_SnabbÖppna { get; set; }
        private readonly DataGridView dgv_QuickOpen;
        private static bool IsNoWorkoperationChecked = true;
        private static Dictionary<int, (Color BackColor, Color ForeColor)> LoadQuickStartColors()
        {
            var result = new Dictionary<int, (Color BackColor, Color ForeColor)>();

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                SELECT 
                    c.WorkOperationID, 
                    c.Back_Red, c.Back_Green, c.Back_Blue, 
                    c.Fore_Red, c.Fore_Green, c.Fore_Blue
                FROM [Settings].QuickStart_Color c";

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var ordId = reader.GetOrdinal("WorkOperationID");
                var ordBR = reader.GetOrdinal("Back_Red");
                var ordBG = reader.GetOrdinal("Back_Green");
                var ordBB = reader.GetOrdinal("Back_Blue");
                var ordFR = reader.GetOrdinal("Fore_Red");
                var ordFG = reader.GetOrdinal("Fore_Green");
                var ordFB = reader.GetOrdinal("Fore_Blue");

                while (reader.Read())
                {
                    if (reader.IsDBNull(ordId))
                        continue;
                    var id = reader.GetInt32(ordId);
                    var back = Color.FromArgb(reader.GetInt32(ordBR), reader.GetInt32(ordBG), reader.GetInt32(ordBB));
                    var fore = Color.FromArgb(reader.GetInt32(ordFR), reader.GetInt32(ordFG), reader.GetInt32(ordFB));
                    result[id] = (back, fore);
                }
            });

            return result;
        }



        public Main_FilterQuickOpen(DataGridView dgv)
        {
            InitializeComponent();
            dgv_QuickOpen = dgv;
        }

        private string WorkOperation = string.Empty;

        private static bool IsWorkoperationSelected(int workoperationID)
        {
            bool isSelected = false;

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT WorkoperationID
                    FROM Workoperation.QuickStartList
                    WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname)
                        AND WorkoperationID = @workoperationid";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@hostname", SqlDbType.NVarChar).Value = Environment.MachineName;
                cmd.Parameters.Add("@workoperationid", SqlDbType.Int).Value = workoperationID;
                using var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    IsNoWorkoperationChecked = false;
                    isSelected = true;
                }
            });

            return isSelected;
        }

        public void AddWorkoperationCheckBoxes()
        {
            var total_height = 0;
            IsNoWorkoperationChecked = true;

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                SELECT ID, Name, Description 
                FROM Workoperation.Names 
                ORDER BY Description";
                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    InfoText.Show("This factory has no workoperations yet, please contact Admin.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return;
                }
                while (reader.Read())
                {
                    var workoperationID = reader["ID"] is DBNull ? 0 : Convert.ToInt32(reader["ID"]);
                    var name = reader["Name"]?.ToString() ?? string.Empty;
                    var description = reader["Description"]?.ToString() ?? string.Empty;

                    bool isChecked = IsWorkoperationSelected(workoperationID);
                    Add_CheckBox(name, description, isChecked, ref total_height);
                }
            });

            // Lägg till sista "Top10 latest orders"-checkbox
            Add_CheckBox(
                null,
                Properties.Resources.top10LatestOrders,
                IsNoWorkoperationChecked,
                ref total_height);

            tlp_BackGround.RowStyles[1].Height = total_height;
            Height = total_height + 66;
        }


        private void Add_CheckBox(string? name, string? description, bool isChecked, ref int total_height)
        {
           
            var chb = new CheckBox
            {
                Name = name,
                BackColor = CustomColors.Load_BackColor_WorkOperation(name),
                ForeColor = CustomColors.Load_ForeColor_Workoperation(name),
                Text = description,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Width = 228,
                Cursor = Cursors.Hand,
                Checked = isChecked,
                Margin = new Padding(0, 0, 0, 2)
            };
            chb.CheckedChanged += WorkOperation_CheckBoxChanged;
            total_height += chb.Height + 2;
            flp_Labels.Controls.Add(chb);
        }
        public static async Task Load_ListAsync(DataGridView dgv)
        {
            // 1) TUNG LADDNING → på bakgrundstråd
            await Task.Run(Load_QuickStart);

            // 2) Sortering i minnet
            var dv = DataTable_SnabbÖppna?.DefaultView;
            if (dv != null && dv.Count > 0)
            {
                dv.Sort = "Datum DESC";
                DataTable_SnabbÖppna = dv.ToTable();
            }

            // 3) Tillbaka på UI-tråden (vi är i OnShown) → INGEN Invoke behövs
            dgv.DataSource = DataTable_SnabbÖppna;

            var colorsByOpId = LoadQuickStartColors();
            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                var workOpId = (int)dgv.Rows[i].Cells["WorkOperationID"].Value;
                if (colorsByOpId.TryGetValue(workOpId, out var colorPair))
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = colorPair.BackColor;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = colorPair.ForeColor;
                }
            }

            if (dgv.Rows.Count > 0)
            {
                dgv.Columns[0].Visible = false; // OrderID
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // OrderNr
                dgv.Columns[1].ReadOnly = true;
                dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // PartNr
                dgv.Columns[3].Visible = false; // PartID
                dgv.Columns[4].Width = 85; // Customer
                dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // PartNr
                dgv.Columns[5].Width = 100; // Date
                dgv.Columns[6].Visible = false; // ProdLine
                dgv.Columns[7].Visible = false; // ProdTyp
                dgv.Columns["WorkoperationID"].Visible = false; // WorkoperationID
                dgv.Height = dgv.Rows.Count * 22 + 15;
                dgv.Width = 290;
            }

            dgv.ClearSelection();
        }


        private static void Load_QuickStart()
        {
            DataTable_SnabbÖppna = new DataTable();
            var workoperationIDs = new List<int>();
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT WorkoperationID 
                    FROM Workoperation.QuickStartList 
                    WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname)";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@hostname", SqlDbType.NVarChar).Value = Environment.MachineName;

                using var reader = cmd.ExecuteReader();
                int ordId = reader.GetOrdinal("WorkoperationID");

                while (reader.Read())
                {
                    if (!reader.IsDBNull(ordId))
                        workoperationIDs.Add(reader.GetInt32(ordId));
                }
            });

            var totalWorkoperations = workoperationIDs.Count;
            var ctr = totalWorkoperations > 0 ? (int)Math.Floor(10 / (double)totalWorkoperations) : 0;

            if (ctr <= 0)
            {
                Fill_QuickStart();
                return;
            }

            // Fyll QuickStart för varje WorkoperationID
            foreach (var workoperationID in workoperationIDs)
                Fill_QuickStart(workoperationID, ctr);
        }



        private static void Fill_QuickStart()
        {
            Database.ExecuteSafe(con =>
            {
                var query = $@"SELECT TOP(10) OrderID, OrderNr, PartNr, PartID, Customer, Date_Start AS Datum, ProdLine, ProdType, WorkOperationID
                                FROM [Order].MainData   
                                WHERE IsOrderDone = 'False' 
                                    AND OrderNr != 'Q12345' 
                                    AND Date_Start IS NOT NULL 
                                ORDER BY Datum DESC";
                var cmd = new SqlCommand(query, con);
                DataTable_SnabbÖppna?.Load(cmd.ExecuteReader());
            });
        }
        private static void Fill_QuickStart(int workOperationID, int ctr)
        {
            Database.ExecuteSafe(con =>
            {
                var query = $@"SELECT TOP({ctr}) OrderID, OrderNr, PartNr, PartID, Customer, Date_Start AS Datum, ProdLine, ProdType, WorkOperationID
                                FROM [Order].MainData   
                                WHERE WorkoperationID = @workoperationid 
                                    AND IsOrderDone = 'False' 
                                    AND OrderNr != 'Q12345' 
                                    AND Date_Start IS NOT NULL 
                                ORDER BY Datum DESC";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@workoperationid", workOperationID);
                DataTable_SnabbÖppna?.Load(cmd.ExecuteReader());
            });
        }

        private void WorkOperation_CheckBoxChanged(object? sender, EventArgs e)
        {
            var chb = (CheckBox)sender;
            WorkOperation = chb.Name;

            Settings.Settings.SaveData.Quickstart_WorkOperation(WorkOperation);
            var task = Load_ListAsync(dgv_QuickOpen);
            //Checkar ur "Tio senaste startade orders" om någon workoperation är ikryssad
            if (!string.IsNullOrEmpty(chb.Name))
            {
                foreach (CheckBox checkBox in flp_Labels.Controls)
                {

                    if (string.IsNullOrEmpty(checkBox.Name) && checkBox.Checked)
                    {
                        checkBox.CheckedChanged -= WorkOperation_CheckBoxChanged;
                        checkBox.Checked = false;
                        checkBox.CheckedChanged += WorkOperation_CheckBoxChanged;

                    }
                }
            }

            
            if (string.IsNullOrEmpty(WorkOperation) && chb.Checked)
            {
                this.Close();
            }
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
