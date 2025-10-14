using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using static DigitalProductionProgram.OrderManagement.Manage_WorkOperation;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_FilterQuickOpen : Form
    {
        public static DataTable? DataTable_SnabbÖppna { get; set; }
        private readonly DataGridView dgv_QuickOpen;
        public static Dictionary<int, (Color BackColor, Color ForeColor)> LoadQuickStartColors()
        {
            var result = new Dictionary<int, (Color, Color)>();

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT c.WorkOperationID, 
                    c.Back_Red, c.Back_Green, c.Back_Blue, 
                    c.Fore_Red, c.Fore_Green, c.Fore_Blue
                FROM [Settings].QuickStart_Color c";

            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            con.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(reader.GetOrdinal("WorkOperationID")))
                    continue;

                int id = reader.GetInt32(reader.GetOrdinal("WorkOperationID"));
                var back = Color.FromArgb((int)reader["Back_Red"], (int)reader["Back_Green"], (int)reader["Back_Blue"]);
                var fore = Color.FromArgb((int)reader["Fore_Red"], (int)reader["Fore_Green"], (int)reader["Fore_Blue"]);
                result[id] = (back, fore);
            }

            return result;
        }


        public Main_FilterQuickOpen(DataGridView dgv)
        {
            InitializeComponent();
            dgv_QuickOpen = dgv;
        }

        public string WorkOperation = string.Empty;

        private static bool IsWorkoperationSelected(int workoperationID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $"SELECT WorkoperationID FROM Workoperation.QuickStartList WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname) AND WorkoperationID = @workoperationid";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
            cmd.Parameters.AddWithValue("@workoperationid", workoperationID);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;

            return false;
        }
        public void AddWorkoperationCheckBoxes()
        {
            var total_height = 0;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"SELECT ID, Name, Description FROM Workoperation.Names ORDER BY Description";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                {
                    InfoText.Show("This factory has no workoperations yet, pleaste contact Admin.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return;
                }
                while (reader.Read())
                {
                    var workoperationID = int.Parse(reader["ID"].ToString());
                    var name = reader["Name"].ToString();
                    var description = reader["Description"].ToString();
                    Add_CheckBox(name, workoperationID, description, ref total_height);

                }
            }
            
            tlp_BackGround.RowStyles[1].Height = total_height;
            Height = total_height + 66;
        }

        private void Add_CheckBox(string name, int workoperationid, string description, ref int total_height)
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
                Checked = IsWorkoperationSelected(workoperationid),
                Margin = new Padding(0, 0, 0, 2)
            };
            chb.CheckedChanged += WorkOperation_CheckBoxChangedAsync;
            total_height += chb.Height + 2;
            flp_Labels.Controls.Add(chb);
        }
        public static async Task Load_ListAsync(DataGridView dgv)
        {
            Load_QuickStart();

            var dv = DataTable_SnabbÖppna?.DefaultView;
            if (dv.Count > 0)
                dv.Sort = "Datum DESC";
            DataTable_SnabbÖppna = dv.ToTable();

            await Task.Run(() => dgv.Invoke(new Action(() => dgv.DataSource = DataTable_SnabbÖppna)));
            var colorsByOpId = LoadQuickStartColors();

            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                int workOpId = (int)dgv.Rows[i].Cells["WorkOperationID"].Value;

                if (colorsByOpId.TryGetValue(workOpId, out var colorPair))
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = colorPair.BackColor;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = colorPair.ForeColor;
                }
            }

            if (dgv.Rows.Count > 0)
            {
                await Task.Run(() =>
                {
                    dgv.Invoke(new Action(() => dgv.Columns[0].Visible = false)); // OrderID
                    dgv.Invoke(new Action(() => dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)); // OrderNr
                    dgv.Invoke(new Action(() => dgv.Columns[1].ReadOnly = true));
                    dgv.Invoke(new Action(() => dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)); // PartNr
                    dgv.Invoke(new Action(() => dgv.Columns[3].Visible = false)); // PartID
                    dgv.Invoke(new Action(() => dgv.Columns[4].Width = 85)); // Customer
                    dgv.Invoke(new Action(() => dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill)); // PartNr
                    dgv.Invoke(new Action(() => dgv.Columns[5].Width = 100)); // Date
                    dgv.Invoke(new Action(() => dgv.Columns[6].Visible = false)); // ProdLine
                    dgv.Invoke(new Action(() => dgv.Columns[7].Visible = false)); // ProdTyp
                    dgv.Invoke(new Action(() => dgv.Columns["WorkoperationID"].Visible = false)); // WorkoperationID
                    dgv.Invoke(new Action(() => dgv.Height = dgv.Rows.Count * 22 + 15));
                    dgv.Invoke(new Action(() => dgv.Width = 290));
                });
            }
            dgv.ClearSelection();
        }


        public static void Load_QuickStart()
        {
            var antal_arbetsOp = 0;
            DataTable_SnabbÖppna = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT COUNT(*) FROM Workoperation.QuickStartList WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                object value = cmd.ExecuteScalar();
                antal_arbetsOp = (int)value;
            }

            var ctr = (int)Math.Floor(10 / (double)antal_arbetsOp);

            if (ctr < 0)
                return;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT WorkoperationID FROM Workoperation.QuickStartList WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["WorkoperationID"].ToString(), out var workoperationID);
                    Fill_QuickStart(workoperationID, ctr);
                }
            }
        }
        private static void Fill_QuickStart(int workOperationID, int ctr)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"SELECT TOP({ctr}) OrderID, OrderNr, PartNr, PartID, Customer, Date_Start AS Datum, ProdLine, ProdType, WorkOperationID
                                FROM [Order].MainData   
                                WHERE WorkoperationID = @workoperationid 
                                    AND IsOrderDone = 'False' 
                                    AND OrderNr != 'Q12345' 
                                    AND Date_Start IS NOT NULL 
                                ORDER BY Datum DESC";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@workoperationid", workOperationID);
            con.Open();
            DataTable_SnabbÖppna?.Load(cmd.ExecuteReader());
            con.Close();
        }

        private void WorkOperation_CheckBoxChangedAsync(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;
            WorkOperation = chb.Name;

            // Enum.TryParse(WorkOperation, out WorkOperations arbetsOperation);
            Settings.Settings.SaveData.Quickstart_WorkOperation(WorkOperation);
            var task = Load_ListAsync(dgv_QuickOpen);
            //Load_List(dgv_QuickOpen, null);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
