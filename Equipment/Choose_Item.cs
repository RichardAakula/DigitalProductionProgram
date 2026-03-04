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
        private readonly Control _anchor;
        private readonly DataGridViewCell?[]? Cells;
        private readonly bool _clampRightToAnchorRight;
        private readonly bool IsOkReturnOwnText;        //Används om användare får skriva i egen text
        private readonly bool IsReturnMultipleValues;   //Används vid skapande av Processkort om användare vill ha t.ex. 2 st torkar med i Processkortet
        private readonly bool IsListFromMonitor;
        private readonly string? DividerChar;           //Anger vilket tecken som skall vara emellan två värden om IsReturnMultipleValues används. (t.ex. ',' '/' '-')
        private readonly string? DataBaseColumnName;    //Används när Senaste 10 körningar skall visas
        private readonly int Maskin;                    //Används som Information när Senaste 10 körningar skall visas
        private readonly int Uppstart;                  //Används som Information när Senaste 10 körningar skall visas
        private int TotalColumns;
        private bool[]? VisibleColumns;



        
        public Choose_Item(IEnumerable<string?>? items, Control?[]? ctrls = null, DataGridViewCell?[]? cells = null, int totalColumns = 1, bool[]? visibleColumns = null, bool isOkReturnOwnText = false, string? dataBaseColumnName = null, int maskin = 0, int uppstart = 0, bool isReturnMultipleValues = false, bool isListFromMonitor = false, string dividerChar = "/", List<string?>? headers = null, bool clampRightToAnchorRight = false)
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
            TotalColumns = totalColumns;
            VisibleColumns = visibleColumns;

            _anchor = ctrls?.FirstOrDefault(c => c is not null);
            
            if (_anchor is null && cells?.FirstOrDefault() is DataGridViewCell cell && cell.DataGridView is not null)
                _anchor = cell.DataGridView; // ankra mot grid:en

            _clampRightToAnchorRight = clampRightToAnchorRight;
            if (_clampRightToAnchorRight)
            {
                StartPosition = FormStartPosition.Manual;
            }
            DataTable = new DataTable();
            if (items != null)
                AddItems(items, headers);

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
            
            if (VisibleColumns != null)
            {
                for (int i = 0; i < DataTable.Columns.Count; i++)
                {
                    bool visible = (i >= VisibleColumns.Length) || VisibleColumns[i];
                    dgv_Items.Columns[i].Visible = visible;
                }
            }

            if (headers is not null)
                dgv_Items.ColumnHeadersVisible = true;
            
            dgv_Items.CellClick += Items_Generic_CellClick;

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
        
        
        
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_clampRightToAnchorRight)
            {
                if (_anchor is not null)
                    PositionNearAnchor();
            }
        }

        
       
        private void PositionNearAnchor()
        {
            // 1) Kontrollens rect i SKÄRMKOORDINATER
            var anchorTopLeft = _anchor.PointToScreen(Point.Empty);
            var a = new Rectangle(anchorTopLeft, _anchor.Size);

            // 2) Utgå från samma skärm som ankaret
            var screen = Screen.FromControl(_anchor);
            var wa = screen.WorkingArea;

            // 3) Önskat läge: under kontrollen, vänsterkant = kontrollens vänsterkant
            var desiredX = a.Left;
            var desiredY = a.Bottom + 5;

            // 4) Om vi ska clamp:a högerkanten: dialog.Right <= anchor.Right
            if (_clampRightToAnchorRight)
            {
                // Flytta så att dialogens högra kant inte överskrider kontollens högra kant
                var maxRight = a.Right;
                desiredX = Math.Min(desiredX, maxRight - this.Width);
            }

            // 5) Om inte plats under – försök ovanför
            if (desiredY + this.Height > wa.Bottom)
            {
                desiredY = a.Top - this.Height - 5;
            }

            // 6) Slutlig clamp inom WorkingArea
            var finalX = Math.Min(Math.Max(desiredX, wa.Left), wa.Right - this.Width);
            var finalY = Math.Min(Math.Max(desiredY, wa.Top),  wa.Bottom - this.Height);

            this.Location = new Point(finalX, finalY);
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

        //private void AddItems(IEnumerable<string?> items, bool isMultipleColumns, IList<string?>? headers = null)
        //{
        //    // Säkerställ lista
        //    var itemList = items?.ToList() ?? new List<string?>();
        //    var headerList = headers?.ToList() ?? new List<string?>();

        //    // MULTIPLE COLUMNS ---------------------------------------------
        //    if (isMultipleColumns)
        //    {
        //        var h1 = headerList.Count > 0 && !string.IsNullOrWhiteSpace(headerList[0]) ? headerList[0] : "Primär";

        //        var h2 = headerList.Count > 1 && !string.IsNullOrWhiteSpace(headerList[1]) ? headerList[1] : "Sekundär";

        //        DataTable.Columns.Add(h1);
        //        DataTable.Columns.Add(h2);

        //        foreach (var text in itemList)
        //        {
        //            if (string.IsNullOrWhiteSpace(text))
        //            {
        //                DataTable.Rows.Add("", "");
        //                continue;
        //            }

        //            if (text.Contains('|'))
        //            {
        //                var parts = text.Split('|');
        //                var p1 = parts.Length > 0 ? parts[0].Trim() : "";
        //                var p2 = parts.Length > 1 ? parts[1].Trim() : "";
        //                DataTable.Rows.Add(p1, p2);
        //            }
        //            else
        //            {
        //                DataTable.Rows.Add(text.Trim(), "");
        //            }
        //        }
        //    }

        //    // SINGLE COLUMN -------------------------------------------------
        //    else
        //    {
        //        var h = headerList.Count > 0 && !string.IsNullOrWhiteSpace(headerList[0]) ? headerList[0] : "List";

        //        DataTable.Columns.Add(h);

        //        foreach (var text in itemList)
        //            DataTable.Rows.Add(text?.Trim() ?? "");
        //    }
        //}
        
        private void AddItems(IEnumerable<string?> items, IList<string?>? headers = null)
        {
            var itemList = items?.ToList() ?? new List<string?>();
            var headerList = headers?.ToList() ?? new List<string?>();

            // --- Skapa kolumner dynamiskt ---
            for (int i = 0; i < TotalColumns; i++)
            {
                string header = (i < headerList.Count && !string.IsNullOrWhiteSpace(headerList[i]))
                    ? headerList[i]!
                    : $"Col {i + 1}";

                DataTable.Columns.Add(header);
            }

            // --- Fyll rader ---
            foreach (var raw in itemList)
            {
                if (string.IsNullOrWhiteSpace(raw))
                {
                    DataTable.Rows.Add(Enumerable.Repeat("", TotalColumns).ToArray());
                    continue;
                }

                var parts = raw.Split('|');
                var row = new string[TotalColumns];

                for (int i = 0; i < TotalColumns; i++)
                    row[i] = (i < parts.Length ? parts[i].Trim() : "");

                DataTable.Rows.Add(row);
            }
        }




        private void Translate_Form()
        {
            label_ChooseItemInfo_1.Text = Properties.Resources.label_ChooseItemInfo_1;
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
        private void Items_Generic_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Hämta alla kolumnvärden i raden
            var row = dgv_Items.Rows[e.RowIndex];

            // Special-case: "Kolla 10 senaste körningar..."
            var text0 = row.Cells[0].Value?.ToString();
            if (text0 == "Kolla 10 senaste körningar..." ||
                text0 == Properties.Resources.checkLastOperations)
            {
                using var senaste = new Latest10Values(DataBaseColumnName, Maskin, Uppstart);
                senaste.ShowDialog();
                Close();
                return;
            }

            // MULTI-ADD (t.ex. högerlista av flera val)
            if (IsReturnMultipleValues)
            {
                dgv_AddedItems.Rows.Add(text0);
                return;
            }

            // UTAN KONTROLLER OCH CELLS — bara stäng
            if (Ctrls == null && Cells == null)
            {
                Close();
                return;
            }

            // SKRIV TILL CELLS (DataGridViewCell[])
            if (Cells != null)
            {
                for (int col = 0; col < Cells.Length && col < row.Cells.Count; col++)
                {
                    Cells[col].Selected = true;   // Din Körprotokoll-grej
                    Cells[col].Value = row.Cells[col].Value?.ToString();
                }
            }

            // SKRIV TILL TEXTBOX/CONTROL-LISTA
            if (Ctrls != null)
            {
                for (int col = 0; col < Ctrls.Length && col < row.Cells.Count; col++)
                {
                    Ctrls[col].Text = row.Cells[col].Value?.ToString();
                }
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
            if (DataTable == null || DataTable.Columns.Count == 0)
                return;

            var dv = DataTable.DefaultView;
            string text = tb_Filter.Text.Replace("'", "''"); // SQL-like escape

            // Bygg filter för alla kolumner
            var parts = new List<string>();
            for (int i = 0; i < DataTable.Columns.Count; i++)
            {
                string col = DataTable.Columns[i].ColumnName;
                parts.Add($"[{col}] LIKE '%{text}%'");
            }

            dv.RowFilter = string.Join(" OR ", parts);
            dgv_Items.DataSource = dv;

            // Auto-selecta en enda rad
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
