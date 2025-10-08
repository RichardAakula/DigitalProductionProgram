using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Templates;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using static DigitalProductionProgram.Protocols.Protocol.Module;

namespace DigitalProductionProgram.Protocols.Protocol
{
    public partial class Machine : UserControl
    {
        public static bool Is_MultipleMachines
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT MachineIndex 
                        FROM Protocol.FormTemplate
                        WHERE MainTemplateID = @maintemplateid";


                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@maintemplateid", Templates_Protocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.TryParse(reader["MachineIndex"].ToString(), out var machineIndex))
                        if (machineIndex > 1)
                            return true;
                }

                return false;
            }
        }
        public static int TotalMachines
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT MAX (MachineIndex) as MachineIndex
                        FROM Protocol.FormTemplate
                        WHERE MainTemplateID = @maintemplateid";


                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@maintemplateid", Templates_Protocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.TryParse(reader["MachineIndex"].ToString(), out var machineIndex))
                        return machineIndex;
                }

                return 0;
            }
        }
        public int TotalWidth
        {
            get
            {
                var MaxWidth = 0;
                foreach (Module module in tlp_Machine.Controls)
                {
                    var ModuleWidth = module.label_LEFT.Width + (from DataGridViewColumn column in module.dgv_Module.Columns let test = column.Name where column.Visible select column.Width).Sum();
                    if (ModuleWidth > MaxWidth)
                        MaxWidth = ModuleWidth;
                }

                return MaxWidth;
            }
        }

        public Machine(int machineIndex, ref bool isAutheticationNeeded, ref int height, bool isOkChangeProcessdata)
        {
            InitializeComponent();
            Load_Templates(machineIndex, ref isAutheticationNeeded, ref height, isOkChangeProcessdata);
            if (MainProtocol.IsUsingMultipleColumnsStartUp)
                Divide_Startups(false);

            Add_Events();
        }

        private void Add_Events()
        {
            foreach (var dgv in modules.Select(module => module.Controls.OfType<DataGridView>().FirstOrDefault()).Where(dgv => dgv != null))
                dgv.KeyDown += dgv_KeyDown;
        }



        public void Load_Templates(int machineIndex, ref bool isAutheticationNeeded, ref int height, bool isOkChangeProcessdata)
        {
            if (Templates_Protocol.MainTemplate.ID is 0)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT FormTemplateID, ModuleName, IsHeaderVisible, Processcard_MinWidth, Processcard_ColWidth, Processcard_MaxWidth, RunProtocol_ColWidth, IsUsingPreFab, IsAuthenticationNeeded
                    FROM Protocol.FormTemplate as formtemplate
                    JOIN Protocol.MainTemplate as template
                        ON formtemplate.MainTemplateID = template.ID
                    WHERE formtemplate.MainTemplateID = @maintemplateID 
                        AND TemplateOrder IS NOT NULL
                        AND MachineIndex = @machineindex
                    ORDER BY TemplateOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@maintemplateID", Templates_Protocol.MainTemplate.ID);
            cmd.Parameters.AddWithValue("@machineindex", machineIndex);
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int.TryParse(reader["FormTemplateID"].ToString(), out var formtemplateid);
                int.TryParse(reader["Processcard_ColWidth"].ToString(), out var processcardNomWidth);

                if (int.TryParse(reader["Processcard_MinWidth"].ToString(), out var processcardMinWidth) == false)
                    processcardMinWidth = processcardNomWidth;
                if (int.TryParse(reader["Processcard_MaxWidth"].ToString(), out var processcardMaxWidth) == false)
                    processcardMaxWidth = processcardNomWidth;
                int.TryParse(reader["RunProtocol_ColWidth"].ToString(), out var runprotocolColWidth);
                bool.TryParse(reader["IsHeaderVisible"].ToString(), out var isHeaderVisible);
                if (isAutheticationNeeded != true)
                    bool.TryParse(reader["IsAuthenticationNeeded"].ToString(), out isAutheticationNeeded);

                var leftHeader = reader["ModuleName"].ToString();
                var module = new Module
                {
                    LeftHeader = leftHeader,
                    Margin = new Padding(0, 0, 0, 0),
                    FormTemplateID = formtemplateid,
                    RunprotocolWidth = runprotocolColWidth,

                    Dock = DockStyle.Fill,
                    MachineIndex = machineIndex
                };

                module.LoadTemplate(isHeaderVisible, processcardMinWidth, processcardNomWidth, processcardMaxWidth, runprotocolColWidth, isOkChangeProcessdata);
                module.load_processcard.Load_ProcessData(formtemplateid);
                height += module.TotalModuleHeight;// + 1; // +1 for the row height in the TableLayoutPanel

                if (Order.OrderID is null == false)
                    module.Load_Data(formtemplateid);

                tlp_Machine.RowCount++;
                tlp_Machine.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
                tlp_Machine.Controls.Add(module);
                tlp_Machine.SetCellPosition(module, new TableLayoutPanelCellPosition(0, tlp_Machine.RowCount - 2));
                tlp_Machine.RowStyles[tlp_Machine.RowCount - 2].Height = module.TotalModuleHeight;
                modules.Add(module);
                module.dgv_Module.MouseWheel += Korprotokoll_MouseWheel;

            }
        }

        public void Add_StartUp(int NextStartup)
        {
            foreach (Module module in tlp_Machine.Controls)
            {
                if (IsOkAddStartUp(StartUp(module.dgv_Module.Columns[^1].HeaderText)))
                {
                    if (module.IsModuleUsedWithMultipleColumnsStartup)
                        module.AddStartup(NextStartup, 1);
                    else
                        module.AddStartup(NextStartup);

                    if (module.IsModuleUsingStartUpDates)
                        Production.AddDates(module.dgv_Module, module.FormTemplateID);
                }
                else
                    InfoText.Show(LanguageManager.GetString("addStartUp"), CustomColors.InfoText_Color.Bad, "Warning!", this);
            }


        }
        public void Remove_StartUp()
        {
            foreach (Module module in tlp_Machine.Controls)
                module.RemoveStartup();
        }

        public void Remove_AllStartups()
        {
            foreach (Module module in tlp_Machine.Controls)
                module.Remove_AllStartups();
        }
        public void Divide_Startups(bool IsOkAddExtraColumn)
        {
            foreach (Module module in tlp_Machine.Controls)
                module.Divide_StartUp(IsOkAddExtraColumn);
        }

        private readonly List<UserControl> modules = new List<UserControl>();
        private void Korprotokoll_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ScrollLeft();
            else
                ScrollRight();
        }
        private void dgv_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                ScrollRight();
                e.Handled = true;  // Förhindra standardbeteende om det behövs
            }
            else if (e.KeyCode == Keys.Left)
            {
                ScrollLeft();
                e.Handled = true;
            }
        }

        private void ScrollRight()
        {
            foreach (var module in modules)
            {
                var dgv = module.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv == null || dgv.Columns.Count == 0) continue;

                int currentIndex = dgv.FirstDisplayedScrollingColumnIndex;
                int lastFrozenIndex = -1;

                // Hitta sista frysta kolumn
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Frozen && dgv.Columns[i].Visible)
                        lastFrozenIndex = i;
                }

                int nextIndex = -1;

                // Hitta nästa kolumn som är scrollbar (inte fryst och synlig)
                for (int i = currentIndex + 1; i < dgv.Columns.Count; i++)
                {
                    var col = dgv.Columns[i];
                    if (col.Visible && !col.Frozen)
                    {
                        nextIndex = i;
                        break;
                    }
                }

                // Scrolla om vi hittat en giltig kolumn som går att scrolla till
                if (nextIndex > lastFrozenIndex)
                {
                    try
                    {
                        dgv.FirstDisplayedScrollingColumnIndex = nextIndex;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Debug.WriteLine($"Scrollning misslyckades: {ex.Message}");
                    }
                }
            }
        }
        private void ScrollLeft()
        {
            foreach (var module in modules)
            {
                var dgv = module.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv == null) continue;

                var currentIndex = dgv.FirstDisplayedScrollingColumnIndex;

                // col_MAX används som stopp, annars 0
                var stopIndex = dgv.Columns.Contains("col_MAX")
                    ? dgv.Columns["col_MAX"].Index + 1
                    : 0;

                var prevIndex = -1;

                for (var i = currentIndex - 1; i >= stopIndex; i--)
                {
                    var col = dgv.Columns[i];
                    if (col.Visible && !col.Frozen)
                    {
                        prevIndex = i;
                        break;
                    }
                }

                if (prevIndex != -1)
                {
                    dgv.FirstDisplayedScrollingColumnIndex = prevIndex;
                }
            }
        }

    }
}
