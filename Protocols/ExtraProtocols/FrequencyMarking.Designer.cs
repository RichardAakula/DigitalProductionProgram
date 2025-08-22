using System.ComponentModel;
using DigitalProductionProgram.Protocols.MainInfo;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    partial class FrequencyMarking
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
            this.components = new System.ComponentModel.Container();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Rubrik = new System.Windows.Forms.Label();
            this.dgv_Frekvensmarkering = new System.Windows.Forms.DataGridView();
            this.Spole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_BatchNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_AntalHål = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_AntalMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_AnstNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TempID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlp_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Kassera = new System.Windows.Forms.Label();
            this.lbl_Spara = new System.Windows.Forms.Label();
            this.MainInfo = new MainInfo_A();
            this.cm_LotNr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Frekvensmarkering)).BeginInit();
            this.tlp_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.label_Rubrik, 0, 0);
            this.tlp_Main.Controls.Add(this.dgv_Frekvensmarkering, 0, 2);
            this.tlp_Main.Controls.Add(this.tlp_Buttons, 0, 3);
            this.tlp_Main.Controls.Add(this.MainInfo, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Main.Size = new System.Drawing.Size(639, 511);
            this.tlp_Main.TabIndex = 0;
            // 
            // label_Rubrik
            // 
            this.label_Rubrik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.label_Rubrik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Rubrik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Rubrik.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rubrik.ForeColor = System.Drawing.Color.Black;
            this.label_Rubrik.Location = new System.Drawing.Point(0, 0);
            this.label_Rubrik.Margin = new System.Windows.Forms.Padding(0);
            this.label_Rubrik.Name = "label_Rubrik";
            this.label_Rubrik.Size = new System.Drawing.Size(639, 25);
            this.label_Rubrik.TabIndex = 82;
            this.label_Rubrik.Text = "Frekvensmarkering av hål i slang:";
            // 
            // dgv_Frekvensmarkering
            // 
            this.dgv_Frekvensmarkering.AllowUserToAddRows = false;
            this.dgv_Frekvensmarkering.AllowUserToResizeColumns = false;
            this.dgv_Frekvensmarkering.AllowUserToResizeRows = false;
            this.dgv_Frekvensmarkering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Frekvensmarkering.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Spole,
            this.dgv_BatchNr,
            this.dgv_AntalHål,
            this.dgv_AntalMeter,
            this.dgv_Datum,
            this.dgv_AnstNr,
            this.dgv_Sign,
            this.dgv_TempID});
            this.dgv_Frekvensmarkering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Frekvensmarkering.Location = new System.Drawing.Point(0, 75);
            this.dgv_Frekvensmarkering.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Frekvensmarkering.Name = "dgv_Frekvensmarkering";
            this.dgv_Frekvensmarkering.RowHeadersVisible = false;
            this.dgv_Frekvensmarkering.Size = new System.Drawing.Size(639, 383);
            this.dgv_Frekvensmarkering.TabIndex = 84;
            this.dgv_Frekvensmarkering.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Frekvensmarkering_CellEnter);
            this.dgv_Frekvensmarkering.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Frekvensmarkering_EditingControlShowing);
            // 
            // Spole
            // 
            this.Spole.FillWeight = 81.87135F;
            this.Spole.HeaderText = "Spole Nr:";
            this.Spole.MaxInputLength = 4;
            this.Spole.Name = "Spole";
            this.Spole.Width = 60;
            // 
            // dgv_BatchNr
            // 
            this.dgv_BatchNr.FillWeight = 186.7255F;
            this.dgv_BatchNr.HeaderText = "Material Batch.Nr:";
            this.dgv_BatchNr.Name = "dgv_BatchNr";
            this.dgv_BatchNr.Width = 127;
            // 
            // dgv_AntalHål
            // 
            this.dgv_AntalHål.FillWeight = 65.1892F;
            this.dgv_AntalHål.HeaderText = "Antal Hål:";
            this.dgv_AntalHål.MaxInputLength = 2;
            this.dgv_AntalHål.Name = "dgv_AntalHål";
            this.dgv_AntalHål.Width = 48;
            // 
            // dgv_AntalMeter
            // 
            this.dgv_AntalMeter.FillWeight = 70.40655F;
            this.dgv_AntalMeter.HeaderText = "Antal Meter";
            this.dgv_AntalMeter.MaxInputLength = 4;
            this.dgv_AntalMeter.Name = "dgv_AntalMeter";
            this.dgv_AntalMeter.Width = 51;
            // 
            // dgv_Datum
            // 
            this.dgv_Datum.FillWeight = 180.2769F;
            this.dgv_Datum.HeaderText = "Datum-Tid:";
            this.dgv_Datum.Name = "dgv_Datum";
            this.dgv_Datum.ReadOnly = true;
            this.dgv_Datum.Width = 110;
            // 
            // dgv_AnstNr
            // 
            this.dgv_AnstNr.FillWeight = 55.29247F;
            this.dgv_AnstNr.HeaderText = "Anst Nr:";
            this.dgv_AnstNr.MaxInputLength = 5;
            this.dgv_AnstNr.Name = "dgv_AnstNr";
            this.dgv_AnstNr.ReadOnly = true;
            this.dgv_AnstNr.Width = 51;
            // 
            // dgv_Sign
            // 
            this.dgv_Sign.FillWeight = 60.23802F;
            this.dgv_Sign.HeaderText = "Sign:";
            this.dgv_Sign.MaxInputLength = 5;
            this.dgv_Sign.Name = "dgv_Sign";
            this.dgv_Sign.ReadOnly = true;
            this.dgv_Sign.Width = 44;
            // 
            // dgv_TempID
            // 
            this.dgv_TempID.HeaderText = "TempID";
            this.dgv_TempID.MaxInputLength = 8;
            this.dgv_TempID.Name = "dgv_TempID";
            this.dgv_TempID.ReadOnly = true;
            this.dgv_TempID.Visible = false;
            // 
            // tlp_Buttons
            // 
            this.tlp_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlp_Buttons.ColumnCount = 3;
            this.tlp_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlp_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlp_Buttons.Controls.Add(this.lbl_Kassera, 1, 0);
            this.tlp_Buttons.Controls.Add(this.lbl_Spara, 0, 0);
            this.tlp_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Buttons.Location = new System.Drawing.Point(3, 461);
            this.tlp_Buttons.Name = "tlp_Buttons";
            this.tlp_Buttons.RowCount = 1;
            this.tlp_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Buttons.Size = new System.Drawing.Size(633, 47);
            this.tlp_Buttons.TabIndex = 86;
            // 
            // lbl_Kassera
            // 
            this.lbl_Kassera.AutoSize = true;
            this.lbl_Kassera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Kassera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Kassera.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lbl_Kassera.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_Kassera.Location = new System.Drawing.Point(82, 5);
            this.lbl_Kassera.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Kassera.Name = "lbl_Kassera";
            this.lbl_Kassera.Size = new System.Drawing.Size(65, 37);
            this.lbl_Kassera.TabIndex = 1;
            this.lbl_Kassera.Text = "Kassera Rad";
            this.lbl_Kassera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Kassera.Click += new System.EventHandler(this.Kassera_Click);
            this.lbl_Kassera.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.lbl_Kassera.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // lbl_Spara
            // 
            this.lbl_Spara.AutoSize = true;
            this.lbl_Spara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Spara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Spara.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lbl_Spara.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_Spara.Location = new System.Drawing.Point(5, 5);
            this.lbl_Spara.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Spara.Name = "lbl_Spara";
            this.lbl_Spara.Size = new System.Drawing.Size(67, 37);
            this.lbl_Spara.TabIndex = 0;
            this.lbl_Spara.Text = "Spara Rad";
            this.lbl_Spara.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Spara.Click += new System.EventHandler(this.Spara_Click);
            this.lbl_Spara.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.lbl_Spara.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // MainInfo
            // 
            this.MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfo.Location = new System.Drawing.Point(0, 25);
            this.MainInfo.Margin = new System.Windows.Forms.Padding(0);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(639, 50);
            this.MainInfo.TabIndex = 87;
            // 
            // cm_LotNr
            // 
            this.cm_LotNr.Font = new System.Drawing.Font("Courier New", 8F);
            this.cm_LotNr.Name = "cm_Munstycke";
            this.cm_LotNr.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cm_LotNr.Size = new System.Drawing.Size(61, 4);
            this.cm_LotNr.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LotNr_ItemClicked);
            // 
            // Frekvensmarkering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 511);
            this.Controls.Add(this.tlp_Main);
            this.Name = "Frekvensmarkering";
            this.Text = "Frekvensmarkering";
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Frekvensmarkering)).EndInit();
            this.tlp_Buttons.ResumeLayout(false);
            this.tlp_Buttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Rubrik;
        private DataGridView dgv_Frekvensmarkering;
        private ContextMenuStrip cm_LotNr;
        private TableLayoutPanel tlp_Buttons;
        private Label lbl_Spara;
        private Label lbl_Kassera;
        private MainInfo_A MainInfo;
        private DataGridViewTextBoxColumn Spole;
        private DataGridViewTextBoxColumn dgv_BatchNr;
        private DataGridViewTextBoxColumn dgv_AntalHål;
        private DataGridViewTextBoxColumn dgv_AntalMeter;
        private DataGridViewTextBoxColumn dgv_Datum;
        private DataGridViewTextBoxColumn dgv_AnstNr;
        private DataGridViewTextBoxColumn dgv_Sign;
        private DataGridViewTextBoxColumn dgv_TempID;
    }
}