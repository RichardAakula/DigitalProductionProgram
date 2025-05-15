using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Equipment
{
    partial class Inventera_Verktyg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_tb_Dimension = new System.Windows.Forms.Panel();
            this.tb_Dimension = new System.Windows.Forms.TextBox();
            this.lbl_Dim_max = new System.Windows.Forms.Label();
            this.label_Dim_max = new System.Windows.Forms.Label();
            this.label_Dim_min = new System.Windows.Forms.Label();
            this.lbl_ID_Nummer = new System.Windows.Forms.Label();
            this.label_ID_Nummer = new System.Windows.Forms.Label();
            this.label_Typ = new System.Windows.Forms.Label();
            this.dgv_Inventering = new System.Windows.Forms.DataGridView();
            this.label_Rubrik = new System.Windows.Forms.Label();
            this.label_Info = new System.Windows.Forms.Label();
            this.label_Dimension = new System.Windows.Forms.Label();
            this.lbl_Klar = new System.Windows.Forms.Label();
            this.lbl_Dim_min = new System.Windows.Forms.Label();
            this.panel_Empty_1 = new System.Windows.Forms.Panel();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.label_Empty_1 = new System.Windows.Forms.Label();
            this.label_Empty_0 = new System.Windows.Forms.Label();
            this.panel_Empty_2 = new System.Windows.Forms.Panel();
            this.panel_tb_Dimension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inventering)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_tb_Dimension
            // 
            this.panel_tb_Dimension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_tb_Dimension.Controls.Add(this.tb_Dimension);
            this.panel_tb_Dimension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tb_Dimension.Location = new System.Drawing.Point(335, 159);
            this.panel_tb_Dimension.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.panel_tb_Dimension.Name = "panel_tb_Dimension";
            this.panel_tb_Dimension.Size = new System.Drawing.Size(95, 29);
            this.panel_tb_Dimension.TabIndex = 883;
            // 
            // tb_Dimension
            // 
            this.tb_Dimension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_Dimension.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Dimension.Font = new System.Drawing.Font("Consolas", 11F);
            this.tb_Dimension.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_Dimension.Location = new System.Drawing.Point(7, 7);
            this.tb_Dimension.Name = "tb_Dimension";
            this.tb_Dimension.Size = new System.Drawing.Size(103, 18);
            this.tb_Dimension.TabIndex = 875;
            this.tb_Dimension.Text = "Skriv här...";
            this.tb_Dimension.Click += new System.EventHandler(this.Mått_SelectText_Click);
            this.tb_Dimension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numbers_Only_KeyPress);
            this.tb_Dimension.Leave += new System.EventHandler(this.Dimension_Leave);
            // 
            // lbl_Dim_max
            // 
            this.lbl_Dim_max.AutoSize = true;
            this.lbl_Dim_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Dim_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Dim_max.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_Dim_max.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Dim_max.Location = new System.Drawing.Point(550, 159);
            this.lbl_Dim_max.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.lbl_Dim_max.Name = "lbl_Dim_max";
            this.lbl_Dim_max.Size = new System.Drawing.Size(64, 29);
            this.lbl_Dim_max.TabIndex = 882;
            this.lbl_Dim_max.Text = "xx.xx";
            this.lbl_Dim_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Dim_max
            // 
            this.label_Dim_max.AutoSize = true;
            this.label_Dim_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_Dim_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Dim_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dim_max.ForeColor = System.Drawing.Color.IndianRed;
            this.label_Dim_max.Location = new System.Drawing.Point(516, 159);
            this.label_Dim_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Dim_max.Name = "label_Dim_max";
            this.label_Dim_max.Size = new System.Drawing.Size(34, 29);
            this.label_Dim_max.TabIndex = 879;
            this.label_Dim_max.Text = "Max";
            this.label_Dim_max.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Dim_min
            // 
            this.label_Dim_min.AutoSize = true;
            this.label_Dim_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_Dim_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Dim_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dim_min.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_Dim_min.Location = new System.Drawing.Point(431, 159);
            this.label_Dim_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Dim_min.Name = "label_Dim_min";
            this.label_Dim_min.Size = new System.Drawing.Size(34, 29);
            this.label_Dim_min.TabIndex = 878;
            this.label_Dim_min.Text = "Min";
            this.label_Dim_min.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ID_Nummer
            // 
            this.lbl_ID_Nummer.AutoSize = true;
            this.lbl_ID_Nummer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.SetColumnSpan(this.lbl_ID_Nummer, 5);
            this.lbl_ID_Nummer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ID_Nummer.Font = new System.Drawing.Font("Consolas", 12.25F);
            this.lbl_ID_Nummer.ForeColor = System.Drawing.Color.Gray;
            this.lbl_ID_Nummer.Location = new System.Drawing.Point(334, 64);
            this.lbl_ID_Nummer.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.lbl_ID_Nummer.Name = "lbl_ID_Nummer";
            this.lbl_ID_Nummer.Size = new System.Drawing.Size(280, 39);
            this.lbl_ID_Nummer.TabIndex = 1;
            this.lbl_ID_Nummer.Text = "A X,XX";
            this.lbl_ID_Nummer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ID_Nummer
            // 
            this.label_ID_Nummer.AutoSize = true;
            this.label_ID_Nummer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_ID_Nummer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ID_Nummer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID_Nummer.ForeColor = System.Drawing.Color.Silver;
            this.label_ID_Nummer.Location = new System.Drawing.Point(234, 64);
            this.label_ID_Nummer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_ID_Nummer.Name = "label_ID_Nummer";
            this.label_ID_Nummer.Size = new System.Drawing.Size(100, 39);
            this.label_ID_Nummer.TabIndex = 1;
            this.label_ID_Nummer.Text = "ID Nummer";
            this.label_ID_Nummer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Typ
            // 
            this.label_Typ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.SetColumnSpan(this.label_Typ, 6);
            this.label_Typ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Typ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Typ.ForeColor = System.Drawing.Color.Silver;
            this.label_Typ.Location = new System.Drawing.Point(234, 38);
            this.label_Typ.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label_Typ.Name = "label_Typ";
            this.label_Typ.Size = new System.Drawing.Size(380, 26);
            this.label_Typ.TabIndex = 1;
            this.label_Typ.Text = "Typ";
            this.label_Typ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_Inventering
            // 
            this.dgv_Inventering.AllowUserToAddRows = false;
            this.dgv_Inventering.AllowUserToResizeColumns = false;
            this.dgv_Inventering.AllowUserToResizeRows = false;
            this.dgv_Inventering.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Inventering.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Inventering.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Inventering.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Inventering.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Inventering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Inventering.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Inventering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Inventering.Location = new System.Drawing.Point(1, 104);
            this.dgv_Inventering.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.dgv_Inventering.Name = "dgv_Inventering";
            this.dgv_Inventering.ReadOnly = true;
            this.dgv_Inventering.RowHeadersVisible = false;
            this.dgv_Inventering.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tlp_Main.SetRowSpan(this.dgv_Inventering, 5);
            this.dgv_Inventering.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Inventering.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Inventering.Size = new System.Drawing.Size(233, 233);
            this.dgv_Inventering.TabIndex = 871;
            // 
            // label_Rubrik
            // 
            this.label_Rubrik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.SetColumnSpan(this.label_Rubrik, 7);
            this.label_Rubrik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Rubrik.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rubrik.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Rubrik.Location = new System.Drawing.Point(1, 1);
            this.label_Rubrik.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.label_Rubrik.Name = "label_Rubrik";
            this.label_Rubrik.Size = new System.Drawing.Size(613, 37);
            this.label_Rubrik.TabIndex = 2;
            this.label_Rubrik.Text = "Inventering av verktyg";
            this.label_Rubrik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.SetColumnSpan(this.label_Info, 6);
            this.label_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info.Location = new System.Drawing.Point(235, 104);
            this.label_Info.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(379, 54);
            this.label_Info.TabIndex = 872;
            this.label_Info.Text = "Mät upp verktyget med skjutmått och fyll i dom nya måtten nedan och klicka sedan " +
    "på knappen \'Klar\'";
            this.label_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Dimension
            // 
            this.label_Dimension.AutoSize = true;
            this.label_Dimension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_Dimension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Dimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Dimension.ForeColor = System.Drawing.Color.Silver;
            this.label_Dimension.Location = new System.Drawing.Point(235, 159);
            this.label_Dimension.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Dimension.Name = "label_Dimension";
            this.label_Dimension.Size = new System.Drawing.Size(99, 29);
            this.label_Dimension.TabIndex = 873;
            this.label_Dimension.Text = "Dimension:";
            this.label_Dimension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Klar
            // 
            this.lbl_Klar.AutoSize = true;
            this.lbl_Klar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_Klar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Klar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Klar.Font = new System.Drawing.Font("Arial", 13.75F);
            this.lbl_Klar.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Klar.Location = new System.Drawing.Point(235, 189);
            this.lbl_Klar.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Klar.Name = "lbl_Klar";
            this.lbl_Klar.Size = new System.Drawing.Size(99, 52);
            this.lbl_Klar.TabIndex = 877;
            this.lbl_Klar.Text = "Klar";
            this.lbl_Klar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Klar.Click += new System.EventHandler(this.Klar_Click);
            // 
            // lbl_Dim_min
            // 
            this.lbl_Dim_min.AutoSize = true;
            this.lbl_Dim_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Dim_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Dim_min.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_Dim_min.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Dim_min.Location = new System.Drawing.Point(465, 159);
            this.lbl_Dim_min.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_Dim_min.Name = "lbl_Dim_min";
            this.lbl_Dim_min.Size = new System.Drawing.Size(50, 29);
            this.lbl_Dim_min.TabIndex = 882;
            this.lbl_Dim_min.Text = "xx.xx";
            this.lbl_Dim_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Empty_1
            // 
            this.panel_Empty_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.SetColumnSpan(this.panel_Empty_1, 5);
            this.panel_Empty_1.Location = new System.Drawing.Point(334, 189);
            this.panel_Empty_1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.panel_Empty_1.Name = "panel_Empty_1";
            this.tlp_Main.SetRowSpan(this.panel_Empty_1, 3);
            this.panel_Empty_1.Size = new System.Drawing.Size(280, 148);
            this.panel_Empty_1.TabIndex = 884;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.DimGray;
            this.tlp_Main.ColumnCount = 7;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlp_Main.Controls.Add(this.lbl_Exit, 1, 7);
            this.tlp_Main.Controls.Add(this.label_Empty_1, 0, 2);
            this.tlp_Main.Controls.Add(this.label_Empty_0, 0, 1);
            this.tlp_Main.Controls.Add(this.panel_Empty_1, 2, 5);
            this.tlp_Main.Controls.Add(this.lbl_Dim_min, 4, 4);
            this.tlp_Main.Controls.Add(this.lbl_Klar, 1, 5);
            this.tlp_Main.Controls.Add(this.label_Dimension, 1, 4);
            this.tlp_Main.Controls.Add(this.label_Info, 1, 3);
            this.tlp_Main.Controls.Add(this.label_Rubrik, 0, 0);
            this.tlp_Main.Controls.Add(this.dgv_Inventering, 0, 3);
            this.tlp_Main.Controls.Add(this.label_Typ, 1, 1);
            this.tlp_Main.Controls.Add(this.label_ID_Nummer, 1, 2);
            this.tlp_Main.Controls.Add(this.lbl_ID_Nummer, 2, 2);
            this.tlp_Main.Controls.Add(this.label_Dim_min, 3, 4);
            this.tlp_Main.Controls.Add(this.label_Dim_max, 5, 4);
            this.tlp_Main.Controls.Add(this.lbl_Dim_max, 6, 4);
            this.tlp_Main.Controls.Add(this.panel_tb_Dimension, 2, 4);
            this.tlp_Main.Controls.Add(this.panel_Empty_2, 1, 6);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 8;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlp_Main.Size = new System.Drawing.Size(615, 338);
            this.tlp_Main.TabIndex = 872;
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Exit.Enabled = false;
            this.lbl_Exit.Font = new System.Drawing.Font("Arial", 13.75F);
            this.lbl_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Exit.Location = new System.Drawing.Point(235, 289);
            this.lbl_Exit.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(99, 49);
            this.lbl_Exit.TabIndex = 889;
            this.lbl_Exit.Text = "Avbryt";
            this.lbl_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label_Empty_1
            // 
            this.label_Empty_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_Empty_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label_Empty_1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Empty_1.Location = new System.Drawing.Point(1, 64);
            this.label_Empty_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Empty_1.Name = "label_Empty_1";
            this.label_Empty_1.Size = new System.Drawing.Size(233, 40);
            this.label_Empty_1.TabIndex = 888;
            this.label_Empty_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_0
            // 
            this.label_Empty_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_Empty_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label_Empty_0.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Empty_0.Location = new System.Drawing.Point(1, 38);
            this.label_Empty_0.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Empty_0.Name = "label_Empty_0";
            this.label_Empty_0.Size = new System.Drawing.Size(233, 26);
            this.label_Empty_0.TabIndex = 887;
            this.label_Empty_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Empty_2
            // 
            this.panel_Empty_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_Empty_2.Location = new System.Drawing.Point(234, 241);
            this.panel_Empty_2.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.panel_Empty_2.Name = "panel_Empty_2";
            this.panel_Empty_2.Size = new System.Drawing.Size(99, 47);
            this.panel_Empty_2.TabIndex = 884;
            // 
            // Inventera_Verktyg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(615, 338);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventera_Verktyg";
            this.Text = "Inventera_Verktyg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventera_Verktyg_FormClosing);
            this.panel_tb_Dimension.ResumeLayout(false);
            this.panel_tb_Dimension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inventering)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel_tb_Dimension;
        private TextBox tb_Dimension;
        private Label lbl_Dim_max;
        private Label label_Dim_max;
        private Label label_Dim_min;
        private Label lbl_ID_Nummer;
        private TableLayoutPanel tlp_Main;
        private Panel panel_Empty_1;
        private Label lbl_Dim_min;
        private Label lbl_Klar;
        private Label label_Dimension;
        private Label label_Info;
        private Label label_Rubrik;
        private DataGridView dgv_Inventering;
        private Label label_Typ;
        private Label label_ID_Nummer;
        private Label label_Empty_1;
        private Label label_Empty_0;
        private Label lbl_Exit;
        private Panel panel_Empty_2;
    }
}