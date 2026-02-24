using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols;

namespace DigitalProductionProgram.Equipment
{
    public partial class Choose_Item : Form
    {
        private readonly DataTable DataTable;
        private readonly Control?[]? Ctrls;
        private readonly DataGridViewCell?[]? Cells;
        private readonly bool IsOkReturnOwnText;        //Används om användare får skriva i egen text
        private readonly bool IsReturnMultipleValues;   //Används vid skapande av Processkort om användare vill ha t.ex. 2 st torkar med i Processkortet
        private readonly bool IsListFromMonitor;
        private readonly string? DividerChar;           //Anger vilket tecken som skall vara emellan två värden om IsReturnMultipleValues används. (t.ex. ',' '/' '-')
        private readonly string? DataBaseColumnName;    //Används när Senaste 10 körningar skall visas
        private readonly int Maskin;                    //Används som Information när Senaste 10 körningar skall visas
        private readonly int Uppstart;                  //Används som Information när Senaste 10 körningar skall visas



        public Choose_Item(IEnumerable<string?>? items, Control?[]? ctrls = null, DataGridViewCell?[]? cells = null, bool isMultipleColumns = false, bool isOkReturnOwnText = false, bool isExtraColumnVisible = true, string? dataBaseColumnName = null, int maskin = 0, int uppstart = 0, bool isReturnMultipleValues = false, bool isListFromMonitor = false, string dividerChar = "/", List<string?>? headers = null)
        {
            InitializeComponent();
            Location = new Point(MousePosition.X, MousePosition.Y);

            IsOkReturnOwnText = isOkReturnOwnText;
            IsReturnMultipleValues = isReturnMultipleValues;
            IsListFromMonitor = isListFromMonitor;
            DividerChar = dividerChar;
            DataBaseColumnName = dataBaseColumnName;
            Maskin = maskin;
            Uppstart = uppstart;
            Ctrls = ctrls;
            Cells = cells;


            DataTable = new DataTable();
            if (items != null)
                AddItems(items, isMultipleColumns, headers);

            // Remove empty rows
            if (DataTable.Rows.Count > 1)
            {
                DataTable = DataTable.Rows.Cast<DataRow>()
                    .Where(r => !r.ItemArray.All(field =>
                        field is DBNull || string.IsNullOrWhiteSpace(field?.ToString()))).CopyToDataTable();
            }

            dgv_Items.DataSource = DataTable;
            dgv_Items.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Items.Columns[0].ReadOnly = true;

            if (!isExtraColumnVisible && dgv_Items.Columns.Count > 1)
                dgv_Items.Columns[1].Visible = false;

            // ------------------------------
            // EVENT WIRING
            // ------------------------------
            if (isMultipleColumns)
                dgv_Items.CellClick += Items_MultipleColumns_Controls_CellClick;
            else
                dgv_Items.CellClick += Items_CellClick;

            if (!isOkReturnOwnText)
                label_ChooseItemInfo_2.Visible = false;

            SetBackgroundColor();
            tb_Filter.Focus();
        }



        private void Choose_Item_Load(object sender, EventArgs e)
        {
            ChangeGUI();
            dgv_Items.Focus();
            Translate_Form();
        }
        private void Choose_Item_Shown(object sender, EventArgs e)
        {
            tb_Filter.Focus();
        }


        private void SetBackgroundColor()
        {
            if (IsListFromMonitor)
            {
                dgv_Items.DefaultCellStyle.BackColor = CustomColors.Blue_Font;
                dgv_Items.DefaultCellStyle.ForeColor = CustomColors.Blue;
                this.Text = @"Items From Monitor";
            }
            else
            {
                dgv_Items.DefaultCellStyle.BackColor = CustomColors.Parmesan;
                dgv_Items.DefaultCellStyle.ForeColor = CustomColors.CoolGrey;
                this.Text = @"Internal Items from DPP";
            }
                
        }

        private void AddItems(IEnumerable<string?> items, bool isMultipleColumns, IList<string?>? headers = null)
        {
            // Säkerställ lista
            var itemList = items?.ToList() ?? new List<string?>();
            var headerList = headers?.ToList() ?? new List<string?>();

            // MULTIPLE COLUMNS ---------------------------------------------
            if (isMultipleColumns)
            {
                var h1 = headerList.Count > 0 && !string.IsNullOrWhiteSpace(headerList[0]) ? headerList[0] : "Primär";

                var h2 = headerList.Count > 1 && !string.IsNullOrWhiteSpace(headerList[1]) ? headerList[1] : "Sekundär";

                DataTable.Columns.Add(h1);
                DataTable.Columns.Add(h2);

                foreach (var text in itemList)
                {
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        DataTable.Rows.Add("", "");
                        continue;
                    }

                    if (text.Contains('|'))
                    {
                        var parts = text.Split('|');
                        var p1 = parts.Length > 0 ? parts[0].Trim() : "";
                        var p2 = parts.Length > 1 ? parts[1].Trim() : "";
                        DataTable.Rows.Add(p1, p2);
                    }
                    else
                    {
                        DataTable.Rows.Add(text.Trim(), "");
                    }
                }
            }

            // SINGLE COLUMN -------------------------------------------------
            else
            {
                var h = headerList.Count > 0 && !string.IsNullOrWhiteSpace(headerList[0]) ? headerList[0] : "List";

                DataTable.Columns.Add(h);

                foreach (var text in itemList)
                    DataTable.Rows.Add(text?.Trim() ?? "");
            }
        }




        private void Translate_Form()
        {
            label_ChooseItemInfo_1.Text = LanguageManager.GetString(label_ChooseItemInfo_1.Name);
        }
        private void ChangeGUI()
        {
          
            var width = 0;
            for (var i = 0; i < dgv_Items.Columns.Count; i++)
                width += dgv_Items.Columns[i].Width;
            tlp_Main.ColumnStyles[2].Width = width + 30;
            Width = (int)tlp_Main.ColumnStyles[0].Width + (int)tlp_Main.ColumnStyles[1].Width + (int)tlp_Main.ColumnStyles[2].Width;
            if (IsReturnMultipleValues)
                Width += (int)tlp_Main.ColumnStyles[2].Width;

            Height = dgv_Items.Rows.Count * 20 + 100;

            if (IsReturnMultipleValues)
            {
                dgv_AddedItems.Visible = true;
                label_ChooseItemInfo_1.Text += "Klicka i en eller flera typer från listan och stäng ner fönstret när du e klar.";
            }

            
        }
        private void Items_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            var TextValue = dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (IsReturnMultipleValues)
            {
                dgv_AddedItems.Rows.Add(TextValue);
                return;
            }
            if (Cells == null && Ctrls == null)
            {
                Close();
                return;
            }

            if (TextValue == LanguageManager.GetString("checkLastOperations"))
            { 
                using var senaste = new Latest10Values(DataBaseColumnName, Maskin, Uppstart);
                senaste.ShowDialog();
                Close();
                return;
            }

            if (Ctrls is null)//Kolla om denna gör nåt nytta? den ändras aldrig så kontrollen kan tas bort kasnke
                foreach (var cell in Cells)
                    cell.Value = TextValue;
            else
            {
                if (Cells == null)
                    Ctrls[0].Text = TextValue;
                else
                    for (var i = 0; i < dgv_Items.Columns.Count; i++)
                        Ctrls[i].Text = dgv_Items.Rows[e.RowIndex].Cells[i].Value.ToString();

            }

            Close();
        }
        private void Items_MultipleColumns_Controls_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var TextValue = dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (TextValue == "Kolla 10 senaste körningar...")
            {
                using var senaste = new Latest10Values(DataBaseColumnName, Maskin, Uppstart);
                senaste.ShowDialog();
                Close();
                return;
            }
            if (IsReturnMultipleValues)
            {
                dgv_AddedItems.Rows.Add(dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString());
                return;
            }

            if (Ctrls is null)
            {
                for (var col = 0; col < Cells.Length; col++)
                {
                    Cells[col].Selected = true;//Denna behövs så att bägge celler skall sparas i Körprotkollet
                    Cells[col].Value = dgv_Items.Rows[e.RowIndex].Cells[col].Value.ToString();
                }

            }
            else
            {
                for (var col = 0; col < Ctrls.Length; col++)
                    Ctrls[col].Text = dgv_Items.Rows[e.RowIndex].Cells[col].Value.ToString();
            }

            Close();
        }
        private void Items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv_Items.CurrentCell == null)
                {
                    Close();
                    return;
                }

                var row = dgv_Items.CurrentCell.RowIndex;
                //if (IsDataGridView)
                if (Ctrls is null)
                    for (var col = 0; col < Cells.Length; col++)
                        Cells[col].Value = dgv_Items.Rows[row].Cells[col].Value.ToString();
                //foreach (DataGridViewCell cell in cells)
                //        cell.Value = dgv_Items.Rows[row].Cells[0].Value.ToString();
                else
                {
                    for (var i = 0; i < dgv_Items.Columns.Count; i++)
                        Ctrls[i].Text = dgv_Items.Rows[row].Cells[i].Value.ToString();
                }

                Close();
            }
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        private void Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv_Items.Rows.Count < 1)
                    return;
                switch (IsOkReturnOwnText)
                {
                    case false:
                        if (dgv_Items.Rows.Count > 0)
                            tb_Filter.Text = dgv_Items.SelectedCells[0].Value.ToString();
                        Close();
                        break;
                    case true when tb_Filter.Focus():
                        {
                            if (Cells is null)
                            {
                                foreach (var ctrl in Ctrls)
                                    ctrl.Text = tb_Filter.Text;
                                Close();
                                return;
                            }
                            //foreach (var cell in Cells)
                            Cells[0].Value = tb_Filter.Text;
                            Close();
                            return;
                        }
                }

                for (var i = 0; i < dgv_Items.Columns.Count; i++)
                    if (Ctrls != null)
                        Ctrls[i].Text = dgv_Items.Rows[0].Cells[i].Value.ToString();

                Close();
            }
            if (e.KeyCode == Keys.Escape)
                Close();

        }
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            var dv = DataTable.DefaultView;
            var col1 = DataTable.Columns[0].ColumnName;
            var col2 = DataTable.Columns.Count > 1 ? DataTable.Columns[1].ColumnName : null;

            var filter = $"[{col1}] LIKE '%{tb_Filter.Text}%'";

            if (col2 != null)
                filter += $" OR [{col2}] LIKE '%{tb_Filter.Text}%'";

            dv.RowFilter = filter;
            dgv_Items.DataSource = dv;

            if (dgv_Items.Rows.Count == 1)
                dgv_Items.Rows[0].Selected = true;
        }


        private void Choose_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsReturnMultipleValues == false)
                return;
            string returnvalue = null;

            for (var i = 0; i < dgv_AddedItems.Rows.Count; i++)
                returnvalue += dgv_AddedItems.Rows[i].Cells[0].Value + DividerChar;

            if (returnvalue == null)
                return;
            returnvalue = returnvalue.Remove(returnvalue.Length - 1, 1);
            if (Cells is null == false)
            {
                foreach (var cell in Cells)
                    cell.Value = returnvalue;
            }
            if (Ctrls is null == false)
            {
                foreach (var ctrl in Ctrls)
                    ctrl.Text = returnvalue;
            }
        }

        
    }
}
