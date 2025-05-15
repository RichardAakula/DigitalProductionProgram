using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.Protocols;

namespace DigitalProductionProgram.Equipment
{
    public partial class Choose_Item : Form
    {
        private readonly bool IsDataGridView;
        private readonly DataTable DT;
        private readonly Control[] controls;
        private readonly DataGridViewCell[] Cells;
        private readonly bool IsHideFilter;
        private readonly bool IsOkReturnOwnText;          //Används om användare får skriva i egen text
        private readonly bool IsReturnMultipleValues;   //Används vid skapande av Processkort om användare vill ha t.ex. 2 st torkar med i Processkortet
        private readonly bool IsLastColumnVisible;      //Döljer den sista kolumnen i dgv'n vid behov
        private readonly string DividerChar;            //Anger vilket tecken som skall vara emellan två värden om IsReturnMultipleValues används. (t.ex. ',' '/' '-')
        private readonly bool IsMultipleColumns;        //Används när programmet skall visa t.ex. typ av Tork i en kolumn bredvid Idnumret, programmet returnerar enbart den första kolumnens värde
        private readonly string DataBaseColumnName;     //Används när Senaste 10 körningar skall visas
        private readonly int Maskin;
        private readonly int Uppstart;

        public Choose_Item(DataTable dt, Control[] ctrl, bool isMultipleColumns, bool isReturnMultipleValues = false)
        {
            IsDataGridView = false;
            InitializeComponent();
            dgv_Items.CellClick += Items_MultipleColumns_Controls_CellClick;

            Location = new Point(MousePosition.X, MousePosition.Y);
            DT = dt;
            //Detta tar bort tomma rader
            if (dt.Rows.Count > 1)
                dt = dt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrWhiteSpace(field as string))).CopyToDataTable();

            controls = ctrl;
            IsMultipleColumns = isMultipleColumns;
            IsReturnMultipleValues = isReturnMultipleValues;
            dgv_Items.DataSource = dt;
            dgv_Items.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv_Items.Columns[0].ReadOnly = true;
        }
        public Choose_Item(DataTable dt, DataGridViewCell[] cells, bool isMultipleColumns, bool isReturnMultipleValues = false, bool isReturnOwnText = false)
        {
            IsDataGridView = true;
            InitializeComponent();
            Location = new Point(MousePosition.X, MousePosition.Y);
            
            dgv_Items.CellClick += Items_MultipleColumns_Controls_CellClick;

            DT = dt;
            Cells = cells;
            IsMultipleColumns = isMultipleColumns;
            IsReturnMultipleValues = isReturnMultipleValues;
            IsOkReturnOwnText = isReturnOwnText;

            //Detta tar bort tomma rader
            if (dt.Rows.Count > 1)
                dt = dt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrWhiteSpace(field as string))).CopyToDataTable();
            if (IsOkReturnOwnText == false)
                label_ChooseItemInfo_2.Visible = false;
            else
                label_ChooseItemInfo_2.Text = LanguageManager.GetString("infotext_Info_1");

            dgv_Items.DataSource = dt;
            dgv_Items.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv_Items.Columns[0].ReadOnly = true;
            tb_Filter.Focus();
        }

        public Choose_Item(IEnumerable<string> items, Control[] ctrl, bool isMultipleColumns, bool isOkReturnOwnText = false, bool isLastColumnVisible = true)
        {
            IsDataGridView = false;
            InitializeComponent();
            Location = new Point(MousePosition.X, MousePosition.Y);

            IsMultipleColumns = isMultipleColumns;
            IsOkReturnOwnText = isOkReturnOwnText;
            IsLastColumnVisible = isLastColumnVisible;

            controls = ctrl;
            if (IsMultipleColumns == false)
                dgv_Items.CellClick += Items_CellClick;
            else
                dgv_Items.CellClick += Items_MultipleColumns_Controls_CellClick;

            if (items != null)
            {
                DT = new DataTable();
                AddItems(items);
            }

            //Detta tar bort tomma rader
            if (DT.Rows.Count > 1)
                DT = DT.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrWhiteSpace(field as string))).CopyToDataTable();

            controls = ctrl;

            dgv_Items.DataSource = DT;
            dgv_Items.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Items.Columns[0].ReadOnly = true;
            if (IsLastColumnVisible == false)
                dgv_Items.Columns[1].Visible = false;

            if (dgv_Items.Rows.Count > 10)
                return;
            if (IsOkReturnOwnText == false)
                label_ChooseItemInfo_2.Visible = false;
            else
                label_ChooseItemInfo_2.Text = LanguageManager.GetString("infotext_Info_1");

            tb_Filter.Focus();

        }
        public Choose_Item(IEnumerable<string> items, DataGridViewCell[] cells, string dataBaseColumnName = null, int maskin = 0, int uppstart = 0, bool isReturnOwnText = false, bool isReturnMultipleValues = false, bool isMultipleColumns = false, string dividerChar = "/")
        {
            IsDataGridView = true;
            InitializeComponent();

            Cells = cells;
            DT = new DataTable();
            IsMultipleColumns = isMultipleColumns;
            IsOkReturnOwnText = isReturnOwnText;
            IsReturnMultipleValues = isReturnMultipleValues;
            DividerChar = dividerChar;

            if (IsOkReturnOwnText == false)
                label_ChooseItemInfo_2.Visible = false;

            if (IsMultipleColumns == false)
                dgv_Items.CellClick += Items_CellClick;
            else
                dgv_Items.CellClick += Items_MultipleColumns_Controls_CellClick;

            DataBaseColumnName = dataBaseColumnName;
            Maskin = maskin;
            Uppstart = uppstart;
            Location = new Point(MousePosition.X, MousePosition.Y);
            
            AddItems(items);

            dgv_Items.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_Items.Columns[0].ReadOnly = true;
            if (IsOkReturnOwnText)
                label_ChooseItemInfo_2.Text = LanguageManager.GetString("infotext_Info_1");
            if (dgv_Items.Rows.Count < 10 && dgv_Items.Rows.Count > 0)
                dgv_Items.CurrentCell = dgv_Items.Rows[0].Cells[0];
            tb_Filter.Focus();
        }

        public void AddItems(IEnumerable<string> items)
        {
            DT.Columns.Add("Item");
            if (IsMultipleColumns)
            {
                DT.Columns.Add("Item2");
                foreach (var text in items)
                {
                    if (text.Contains(":"))
                    {
                        var parts = text.Split(':');
                        DT.Rows.Add(parts[0], parts[1]);
                    }
                    else
                        DT.Rows.Add(text, "");
                }
            }
            else
            {
                foreach (var text in items)
                    DT.Rows.Add(text);
            }
            dgv_Items.DataSource = DT;
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
        private void Items_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var TextValue = dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (IsReturnMultipleValues)
            {
                dgv_AddedItems.Rows.Add(TextValue);
                return;
            }
            if (Cells == null && controls == null)
            {
                Close();
                return;
            }

            if (TextValue == LanguageManager.GetString("checkLastOperations"))
            {
                var senaste = new Latest10Values(DataBaseColumnName, Maskin, Uppstart);
                senaste.ShowDialog();
                Close();
                return;
            }

            if (IsDataGridView)
                foreach (var cell in Cells)
                    cell.Value = TextValue;
            else
            {
                if (Cells == null)
                    controls[0].Text = TextValue;
                else
                    for (var i = 0; i < dgv_Items.Columns.Count; i++)
                        controls[i].Text = dgv_Items.Rows[e.RowIndex].Cells[i].Value.ToString();

            }

            Close();
        }
        private void Items_MultipleColumns_Controls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var TextValue = dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (TextValue == "Kolla 10 senaste körningar...")
            {
                var senaste = new Latest10Values(DataBaseColumnName, Maskin, Uppstart);
                senaste.ShowDialog();
                Close();
                return;
            }
            if (IsReturnMultipleValues)
            {
                dgv_AddedItems.Rows.Add(dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString());
                return;
            }

            if (controls is null)
            {
                for (var col = 0; col < Cells.Length; col++)
                {
                    Cells[col].Selected = true;//Denna behövs så att bägge celler skall sparas i Körprotkollet
                    Cells[col].Value = dgv_Items.Rows[e.RowIndex].Cells[col].Value.ToString();
                }

            }
            else
            {
                for (var col = 0; col < controls.Length; col++)
                    controls[col].Text = dgv_Items.Rows[e.RowIndex].Cells[col].Value.ToString();
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
                if (IsDataGridView)
                    for (var col = 0; col < Cells.Length; col++)
                        Cells[col].Value = dgv_Items.Rows[row].Cells[col].Value.ToString();
                //foreach (DataGridViewCell cell in cells)
                //        cell.Value = dgv_Items.Rows[row].Cells[0].Value.ToString();
                else
                {
                    for (var i = 0; i < dgv_Items.Columns.Count; i++)
                        controls[i].Text = dgv_Items.Rows[row].Cells[i].Value.ToString();
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
                                foreach (var ctrl in controls)
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
                    if (controls != null)
                        controls[i].Text = dgv_Items.Rows[0].Cells[i].Value.ToString();

                Close();
            }
            if (e.KeyCode == Keys.Escape)
                Close();

        }
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            var dv = DT.DefaultView;
            dv.RowFilter = $"{DT.Columns[0].ColumnName} LIKE '%{tb_Filter.Text}%' ";
            if (DT.Columns.Count > 1)
                dv.RowFilter += $"OR {DT.Columns[1].ColumnName} LIKE '%{tb_Filter.Text}%'";
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
            if (controls is null == false)
            {
                foreach (var ctrl in controls)
                    ctrl.Text = returnvalue;
            }
        }

        
    }
}
