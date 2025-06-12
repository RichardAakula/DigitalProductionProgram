using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;

using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.ControlsManagement
{
    internal class ControlManager
    {
        public class ControlType
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
        public static readonly List<ControlType> ControlTypes = new List<ControlType>
        {
            new ControlType { Name = "TextBox", ID = 0 },
            new ControlType { Name = "NumericUpDown", ID = 1 },
            new ControlType { Name = "CheckBox", ID = 2 },
    };

        public static void Lock_Controls(Control[] control, bool is_Change_Color = false)
        {
            foreach (var ctrl in control)
            {
                ctrl.Enabled = false;
                if (is_Change_Color)
                    ctrl.BackColor = Color.Gray;
            }
        }
        public static void Unlock_Controls(Control[] control, bool is_Change_Color = false)
        {
            foreach (var ctrl in control)
            {
                ctrl.Enabled = true;
                if (is_Change_Color)
                    ctrl.BackColor = Color.White;
            }
        }
        public static void Clear_TextBoxes(Control[] control)
        {
            foreach (var ctrl in control)
            {
                ctrl.Text = string.Empty;
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.DarkSlateGray;
                if (ctrl is CheckBox chb)
                {
                    chb.Checked = false;
                }
            }
        }
        public static void Set_Control_NA(Control[] control)
        {
            foreach (var ctrl in control)
            {
                if (string.IsNullOrEmpty(ctrl.Text))
                    CustomFonts.change_To_NA(ctrl);
            }
        }
        public static void Close_All_Körprotokoll()
        {
            Form[] forms_Processkort = {
                Application.OpenForms["Blandning_PTFE"],
                Application.OpenForms["Bump_PTFE"],
                Application.OpenForms["Extrudering_FEP"],
                Application.OpenForms["Extrudering_Grov_PTFE"],
                Application.OpenForms["Extrudering_PTFE"],
                Application.OpenForms["Extrudering_TEF"],
                Application.OpenForms["Hackning_PTFE"],
                Application.OpenForms["Hackning_TEF"],
                Application.OpenForms["Heatshrink"],
                Application.OpenForms["Kragning_PTFE"],
                Application.OpenForms["Kragning_TEF"],
                Application.OpenForms["Skärmning_TEF"],
                Application.OpenForms["Slipning_TEF"],
                Application.OpenForms["Slittning_PTFE"],
                Application.OpenForms["Spolning_PTFE"],
                Application.OpenForms["Svetsning_TEF"],
                Application.OpenForms["Synergy_PTFE"],
                Application.OpenForms["Extrusion_HS"],
                Application.OpenForms["HeatShrink_Thailand"]
            };
            foreach (var form in forms_Processkort)
            {
                if (form != null)
                {
                    form.Close();
                }
            }
        }
        public static void Write_NA_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { if (Module.IsOkToSave == false)
                return;
            var dgv = (DataGridView)sender;
            var cell = dgv.CurrentCell;
            if (cell.ReadOnly)
                return;
            cell.Value = "N/A";
            cell.Style.ForeColor = Color.Red;
            cell.Style.BackColor = Color.White;
        }
        public static string FormatOrdinal(int number)
        {
            if (number % 100 >= 11 && number % 100 <= 13)
                return number + "th";

            return number + (number % 10) switch
            {
                1 => "ˢᵗ",
                2 => "ⁿᵈ",
                3 => "ʳᵈ",
                _ => "ᵗʰ"
            };
        }




        public class Save
        {
            public static void Protocol_Main(object sender, EventArgs e)
            {
                if (Module.IsOkToSave)
                {
                    var ctrl = (Control)sender;
                    var is_Flag = false;
                    if (ctrl is RadioButton rb)
                        is_Flag = rb.Checked;
                    if (ctrl is CheckBox cb)
                        is_Flag = cb.Checked;

                    var kolumn = ctrl.Name;
                    var dataType = Database.DataType(kolumn, "[Order].MainData");

                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query =
                        $"UPDATE [Order].MainData SET {kolumn} = @kolumn {Queries.WHERE_OrderID}";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    switch (Type.GetTypeCode(dataType))
                    {
                        case TypeCode.Boolean:
                            cmd.Parameters.AddWithValue("@kolumn", is_Flag);
                            break;
                        case TypeCode.Decimal:
                            SQL_Parameter.Double(cmd.Parameters, "@kolumn", ctrl.Text);
                            break;
                        case TypeCode.String:
                        case TypeCode.DateTime:
                            cmd.Parameters.AddWithValue("@kolumn", ctrl.Text);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }



      
    }
}

