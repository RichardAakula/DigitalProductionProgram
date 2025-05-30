using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
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


                var cmd = new SqlCommand(query, con);
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


                var cmd = new SqlCommand(query, con);
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

        public Machine(int machineIndex, ref bool isAutheticationNeeded, ref int width,  bool isOkChangeProcessdata)
        {
            InitializeComponent();
            Load_Templates(machineIndex,  ref isAutheticationNeeded, ref width, isOkChangeProcessdata);
            if (MainProtocol.IsUsingMultipleColumnsStartUp)
                Divide_Startups(false);
        }
        

        

        public void Load_Templates(int machineIndex, ref bool isAutheticationNeeded, ref int width, bool isOkChangeProcessdata)
        {
            if (Templates_Protocol.MainTemplate.ID is 0)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT FormTemplateID, ModuleName, IsHeaderVisible, Processcard_ColWidth, RunProtocol_ColWidth, IsUsingPreFab, IsAuthenticationNeeded
                    FROM Protocol.FormTemplate as formtemplate
                    JOIN Protocol.MainTemplate as template
                        ON formtemplate.MainTemplateID = template.ID
                    WHERE formtemplate.MainTemplateID = @maintemplateID 
                        AND TemplateOrder IS NOT NULL
                        AND MachineIndex = @machineindex
                    ORDER BY TemplateOrder";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@maintemplateID", Templates_Protocol.MainTemplate.ID);
            cmd.Parameters.AddWithValue("@machineindex", machineIndex);
            con.Open();
            var reader = cmd.ExecuteReader();
            var ctr = 0;
            while (reader.Read())
            {
                int.TryParse(reader["FormTemplateID"].ToString(), out var formtemplateid);
                int.TryParse(reader["Processcard_ColWidth"].ToString(), out var processcardColWidth);
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
                    
                module.LoadTemplate(isHeaderVisible, processcardColWidth, runprotocolColWidth, isOkChangeProcessdata);
                module.load_processcard.Load_ProcessData(formtemplateid);
                if (Order.OrderID is null == false)
                    module.Load_Data(formtemplateid);

                tlp_Machine.RowCount++;
                tlp_Machine.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
                tlp_Machine.Controls.Add(module);
                tlp_Machine.SetCellPosition(module, new TableLayoutPanelCellPosition(0, tlp_Machine.RowCount - 2));
                tlp_Machine.RowStyles[tlp_Machine.RowCount - 2].Height = module.TotalModuleHeight;
                modules.Add(module);
                module.dgv_Module.MouseWheel += Korprotokoll_MouseWheel;
                if (ctr == 0)
                    //width += (int)module.tlp_Module.ColumnStyles[0].Width;
                    width += 18;

                if (ctr == 0)
                    width += 208 + processcardColWidth * 3;
                        
                ctr++;
            }
        }

        public void Add_StartUp(int NextStartup)
        {
            foreach (Module module in tlp_Machine.Controls)
            {
                if (IsOkAddStartUp(StartUp(module.dgv_Module.Columns[module.dgv_Module.Columns.Count -1].HeaderText)))
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
        private void ScrollRight()
        {
            foreach (var module in modules)
            {
                var dgv = module.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv == null) continue;

                int currentIndex = dgv.FirstDisplayedScrollingColumnIndex;

                int nextIndex = -1;
                for (int i = currentIndex + 1; i < dgv.Columns.Count; i++)
                {
                    var col = dgv.Columns[i];
                    if (col.Visible && !col.Frozen)
                    {
                        nextIndex = i;
                        break;
                    }
                }

                if (nextIndex != -1)
                {
                    dgv.FirstDisplayedScrollingColumnIndex = nextIndex;
                }
            }
        }


        private void ScrollLeft()
        {
            foreach (var module in modules)
            {
                var dgv = module.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv == null) continue;

                int currentIndex = dgv.FirstDisplayedScrollingColumnIndex;

                // col_MAX används som stopp, annars 0
                int stopIndex = dgv.Columns.Contains("col_MAX")
                    ? dgv.Columns["col_MAX"].Index + 1
                    : 0;

                int prevIndex = -1;

                for (int i = currentIndex - 1; i >= stopIndex; i--)
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
