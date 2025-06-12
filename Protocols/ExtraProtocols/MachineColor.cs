using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.Protocols
{
    public sealed partial class MachineColor : Form
    {
        private bool IsOkClose;
        public static Color Theme_ForeColor;
        public static Color Theme_BackColor;
        public static void Set_HeatShrink_Color()
        {
            if (string.IsNullOrEmpty(Equipment.Equipment.HS_Machine))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query =
                    "SELECT * FROM Settings.HS_Color WHERE MachineName = @machineName";
                con.Open();

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@machineName", Equipment.Equipment.HS_Machine);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["Red"].ToString(), out var red);
                    int.TryParse(reader["Green"].ToString(), out var green);
                    int.TryParse(reader["Blue"].ToString(), out var blue);
                    bool.TryParse(reader["InvertForeColor"].ToString(), out var isForeColorInverted);
                    Theme_ForeColor = isForeColorInverted ? Color.White : Color.Black;
                    Theme_BackColor = Color.FromArgb(red, green, blue);
                    return;
                }
                var colorForm = new MachineColor();
                colorForm.ShowDialog();
            }
        }

        public MachineColor()
        {
            InitializeComponent();
            Load_MachineNames();

            label_HS_Machine.Text = string.IsNullOrEmpty(Equipment.Equipment.HS_Machine) ? "HS Machine" : Equipment.Equipment.HS_Machine;
            IsOkClose = false;
            Translate_Form();
        }

        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_HS_Color_Info, btn_HS_Machine_NewColor, chb_HS_Machine_InvertForeColor, btn_HS_Machine_Close, btn_HS_Machine_Exit });
        }
        private void Load_MachineNames()
        {
            bool IsActiveMachineHaveColor = false;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT * FROM Settings.HS_Color ORDER BY MachineName";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["Red"].ToString(), out var red);
                    int.TryParse(reader["Green"].ToString(), out var green);
                    int.TryParse(reader["Blue"].ToString(), out var blue);
                    bool.TryParse(reader["InvertForeColor"].ToString(), out var isInverted);
                    dgv_MachineNames.Rows.Add(reader[0].ToString(), red, green, blue, isInverted);
                    if (reader[0].ToString() == Equipment.Equipment.HS_Machine)
                        IsActiveMachineHaveColor = true;
                }
            }
          

            if (IsActiveMachineHaveColor == false)
                dgv_MachineNames.Rows.Add(Equipment.Equipment.HS_Machine, 255, 255, 255, false);
        }

        private void NewColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            label_HS_Machine.BackColor = Theme_BackColor = colorDialog.Color;
            Theme_ForeColor = label_HS_Machine.ForeColor;
        }
        private void SaveColor()
        {
            var red = label_HS_Machine.BackColor.R;
            var green = label_HS_Machine.BackColor.G;
            var blue = label_HS_Machine.BackColor.B;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query =
                    @"
                    IF NOT EXISTS (SELECT * FROM Settings.HS_Color WHERE MachineName = @machineName)
                        INSERT INTO Settings.HS_Color (MachineName,  Red, Green, Blue, InvertForeColor)
                        VALUES (@machineName, @red, @green, @blue, @isInvertForeColor)
                    ELSE
                        UPDATE Settings.HS_Color
                            SET Red = @red, Green = @green, Blue = @blue, InvertForeColor = @isInvertForeColor
                        WHERE MachineName = @machineName";
                con.Open();

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@machineName", label_HS_Machine.Text);
                cmd.Parameters.AddWithValue("@red", red);
                cmd.Parameters.AddWithValue("@green", green);
                cmd.Parameters.AddWithValue("@blue", blue);
                cmd.Parameters.AddWithValue("@isInvertForeColor", chb_HS_Machine_InvertForeColor.Checked);
                cmd.ExecuteNonQuery();
            }
        }
        private void MachineNames_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int.TryParse(dgv_MachineNames.Rows[e.RowIndex].Cells[1].Value.ToString(), out var red);
            int.TryParse(dgv_MachineNames.Rows[e.RowIndex].Cells[2].Value.ToString(), out var green);
            int.TryParse(dgv_MachineNames.Rows[e.RowIndex].Cells[3].Value.ToString(), out var blue);
            bool.TryParse(dgv_MachineNames.Rows[e.RowIndex].Cells[4].Value.ToString(), out var isInverted);
            label_HS_Machine.BackColor = Color.FromArgb(red, green, blue);
            label_HS_Machine.ForeColor = isInverted ? Color.White : Color.Black;
        }
        private void InvertForeColor_CheckedChanged(object sender, EventArgs e)
        {
            label_HS_Machine.ForeColor = Theme_ForeColor = chb_HS_Machine_InvertForeColor.Checked ? Color.White : Color.Black;
        }


        private void Close_Click(object sender, EventArgs e)
        {
            SaveColor();
            IsOkClose = true;
            Close();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            IsOkClose = true;
            Close();
        }

        private void MachineColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsOkClose == false)
                e.Cancel = true;
        }


    }
}
