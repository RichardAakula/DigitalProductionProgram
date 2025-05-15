using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class MeasureInstrument
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasureInstrument));
            this.dgv_Mätdon = new System.Windows.Forms.DataGridView();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Info = new System.Windows.Forms.PictureBox();
            this.btn_Add_Startup = new System.Windows.Forms.Button();
            this.btn_Discard_Startup = new System.Windows.Forms.Button();
            this.label_MeasureInstrument_Header = new System.Windows.Forms.Label();
            this.col_MätDonNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mätdon)).BeginInit();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Mätdon
            // 
            this.dgv_Mätdon.AllowUserToAddRows = false;
            this.dgv_Mätdon.AllowUserToDeleteRows = false;
            this.dgv_Mätdon.AllowUserToResizeColumns = false;
            this.dgv_Mätdon.AllowUserToResizeRows = false;
            this.dgv_Mätdon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dgv_Mätdon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Mätdon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Mätdon.ColumnHeadersVisible = false;
            this.dgv_Mätdon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MätDonNr,
            this.col_Row});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Mätdon.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Mätdon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Mätdon.Location = new System.Drawing.Point(33, 20);
            this.dgv_Mätdon.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Mätdon.MultiSelect = false;
            this.dgv_Mätdon.Name = "dgv_Mätdon";
            this.dgv_Mätdon.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mätdon.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Mätdon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_Mätdon.RowTemplate.Height = 18;
            this.dgv_Mätdon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Mätdon.ShowCellErrors = false;
            this.dgv_Mätdon.ShowCellToolTips = false;
            this.dgv_Mätdon.ShowEditingIcon = false;
            this.dgv_Mätdon.ShowRowErrors = false;
            this.dgv_Mätdon.Size = new System.Drawing.Size(279, 112);
            this.dgv_Mätdon.TabIndex = 960;
            this.dgv_Mätdon.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Mätdon_CellMouseDoubleClick);
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_Main.Controls.Add(this.pb_Info, 0, 0);
            this.tlp_Main.Controls.Add(this.btn_Add_Startup, 0, 1);
            this.tlp_Main.Controls.Add(this.btn_Discard_Startup, 0, 2);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlp_Main.Location = new System.Drawing.Point(0, 20);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(33, 112);
            this.tlp_Main.TabIndex = 961;
            // 
            // pb_Info
            // 
            this.pb_Info.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info.BackgroundImage")));
            this.pb_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_Info.Location = new System.Drawing.Point(3, 3);
            this.pb_Info.Name = "pb_Info";
            this.pb_Info.Size = new System.Drawing.Size(27, 30);
            this.pb_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info.TabIndex = 1075;
            this.pb_Info.TabStop = false;
            this.pb_Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // btn_Add_Startup
            // 
            this.btn_Add_Startup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_Add_Startup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add_Startup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add_Startup.FlatAppearance.BorderSize = 0;
            this.btn_Add_Startup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(189)))), ((int)(((byte)(156)))));
            this.btn_Add_Startup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Startup.Font = new System.Drawing.Font("Segoe UI", 11.75F, System.Drawing.FontStyle.Bold);
            this.btn_Add_Startup.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_Add_Startup.Location = new System.Drawing.Point(1, 37);
            this.btn_Add_Startup.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.btn_Add_Startup.Name = "btn_Add_Startup";
            this.btn_Add_Startup.Size = new System.Drawing.Size(31, 29);
            this.btn_Add_Startup.TabIndex = 1073;
            this.btn_Add_Startup.Text = "+";
            this.btn_Add_Startup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Add_Startup.UseCompatibleTextRendering = true;
            this.btn_Add_Startup.UseVisualStyleBackColor = false;
            this.btn_Add_Startup.Click += new System.EventHandler(this.Add_Startup_Click);
            // 
            // btn_Discard_Startup
            // 
            this.btn_Discard_Startup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_Discard_Startup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Discard_Startup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Discard_Startup.FlatAppearance.BorderSize = 0;
            this.btn_Discard_Startup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(149)))), ((int)(((byte)(156)))));
            this.btn_Discard_Startup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Discard_Startup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Discard_Startup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Discard_Startup.Location = new System.Drawing.Point(1, 67);
            this.btn_Discard_Startup.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.btn_Discard_Startup.Name = "btn_Discard_Startup";
            this.btn_Discard_Startup.Size = new System.Drawing.Size(31, 29);
            this.btn_Discard_Startup.TabIndex = 1074;
            this.btn_Discard_Startup.Text = "-";
            this.btn_Discard_Startup.UseCompatibleTextRendering = true;
            this.btn_Discard_Startup.UseVisualStyleBackColor = false;
            this.btn_Discard_Startup.Click += new System.EventHandler(this.Discard_Startup_Click);
            // 
            // label_MeasureInstrument_Header
            // 
            this.label_MeasureInstrument_Header.BackColor = System.Drawing.Color.Transparent;
            this.label_MeasureInstrument_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_MeasureInstrument_Header.Font = new System.Drawing.Font("Lucida Sans", 12.25F);
            this.label_MeasureInstrument_Header.ForeColor = System.Drawing.SystemColors.Info;
            this.label_MeasureInstrument_Header.Location = new System.Drawing.Point(0, 0);
            this.label_MeasureInstrument_Header.Name = "label_MeasureInstrument_Header";
            this.label_MeasureInstrument_Header.Size = new System.Drawing.Size(312, 20);
            this.label_MeasureInstrument_Header.TabIndex = 962;
            this.label_MeasureInstrument_Header.Text = "Mätdon";
            this.label_MeasureInstrument_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // col_MätDonNr
            // 
            this.col_MätDonNr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_MätDonNr.HeaderText = "Nr";
            this.col_MätDonNr.MinimumWidth = 70;
            this.col_MätDonNr.Name = "col_MätDonNr";
            this.col_MätDonNr.Width = 70;
            // 
            // col_Row
            // 
            this.col_Row.HeaderText = "Row";
            this.col_Row.Name = "col_Row";
            this.col_Row.Visible = false;
            this.col_Row.Width = 5;
            // 
            // MeasureInstrument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.dgv_Mätdon);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.label_MeasureInstrument_Header);
            this.Name = "MeasureInstrument";
            this.Size = new System.Drawing.Size(312, 132);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mätdon)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_Main;
        private Button btn_Add_Startup;
        private Label label_MeasureInstrument_Header;
        private Button btn_Discard_Startup;
        private PictureBox pb_Info;
        public DataGridView dgv_Mätdon;
        private DataGridViewTextBoxColumn col_MätDonNr;
        private DataGridViewTextBoxColumn col_Row;
    }
}
