using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    partial class Journal_Spolning_PTFE
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Journal = new System.Windows.Forms.DataGridView();
            this.dgv_Journal_Input = new System.Windows.Forms.DataGridView();
            this.panel_ExtraInfoLabels = new System.Windows.Forms.Panel();
            this.flp_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_SaveRow = new System.Windows.Forms.Button();
            this.btn_EditRow = new System.Windows.Forms.Button();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Journal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Journal_Input)).BeginInit();
            this.flp_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.dgv_Journal, 0, 3);
            this.tlp_Main.Controls.Add(this.dgv_Journal_Input, 0, 2);
            this.tlp_Main.Controls.Add(this.panel_ExtraInfoLabels, 0, 1);
            this.tlp_Main.Controls.Add(this.flp_Buttons, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(906, 286);
            this.tlp_Main.TabIndex = 4;
            // 
            // dgv_Journal
            // 
            this.dgv_Journal.AllowUserToAddRows = false;
            this.dgv_Journal.AllowUserToDeleteRows = false;
            this.dgv_Journal.AllowUserToResizeColumns = false;
            this.dgv_Journal.AllowUserToResizeRows = false;
            this.dgv_Journal.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Journal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Journal.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Journal.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Journal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Journal.Location = new System.Drawing.Point(0, 133);
            this.dgv_Journal.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Journal.Name = "dgv_Journal";
            this.dgv_Journal.ReadOnly = true;
            this.dgv_Journal.RowHeadersVisible = false;
            this.dgv_Journal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Journal.Size = new System.Drawing.Size(906, 153);
            this.dgv_Journal.TabIndex = 3;
            this.dgv_Journal.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CopyRow_CellMouseDoubleClick);
            // 
            // dgv_Journal_Input
            // 
            this.dgv_Journal_Input.AllowUserToAddRows = false;
            this.dgv_Journal_Input.AllowUserToDeleteRows = false;
            this.dgv_Journal_Input.AllowUserToResizeColumns = false;
            this.dgv_Journal_Input.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Journal_Input.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Journal_Input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Journal_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Journal_Input.Location = new System.Drawing.Point(0, 53);
            this.dgv_Journal_Input.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Journal_Input.Name = "dgv_Journal_Input";
            this.dgv_Journal_Input.RowHeadersVisible = false;
            this.dgv_Journal_Input.Size = new System.Drawing.Size(906, 80);
            this.dgv_Journal_Input.TabIndex = 2;
            this.dgv_Journal_Input.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Journal_Input_CellClick);
            this.dgv_Journal_Input.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Journal_Input_CellEnter);
            this.dgv_Journal_Input.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Journal_Input_CellValueChanged);
            this.dgv_Journal_Input.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Journal_Input_ColumnHeaderMouseClick);
            this.dgv_Journal_Input.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.EditingControlShowing);
            // 
            // panel_ExtraInfoLabels
            // 
            this.panel_ExtraInfoLabels.BackColor = System.Drawing.Color.White;
            this.panel_ExtraInfoLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ExtraInfoLabels.Location = new System.Drawing.Point(1, 33);
            this.panel_ExtraInfoLabels.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panel_ExtraInfoLabels.Name = "panel_ExtraInfoLabels";
            this.panel_ExtraInfoLabels.Size = new System.Drawing.Size(904, 20);
            this.panel_ExtraInfoLabels.TabIndex = 50;
            // 
            // flp_Buttons
            // 
            this.flp_Buttons.Controls.Add(this.btn_SaveRow);
            this.flp_Buttons.Controls.Add(this.btn_EditRow);
            this.flp_Buttons.Location = new System.Drawing.Point(0, 0);
            this.flp_Buttons.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Buttons.Name = "flp_Buttons";
            this.flp_Buttons.Size = new System.Drawing.Size(845, 31);
            this.flp_Buttons.TabIndex = 52;
            // 
            // btn_SaveRow
            // 
            this.btn_SaveRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_SaveRow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_SaveRow.FlatAppearance.BorderSize = 3;
            this.btn_SaveRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_SaveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveRow.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_SaveRow.ForeColor = System.Drawing.Color.White;
            this.btn_SaveRow.Location = new System.Drawing.Point(5, 1);
            this.btn_SaveRow.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btn_SaveRow.Name = "btn_SaveRow";
            this.btn_SaveRow.Size = new System.Drawing.Size(116, 29);
            this.btn_SaveRow.TabIndex = 49;
            this.btn_SaveRow.Text = "Spara Rad";
            this.btn_SaveRow.UseVisualStyleBackColor = false;
            this.btn_SaveRow.Click += new System.EventHandler(this.SaveRow_Click);
            // 
            // btn_EditRow
            // 
            this.btn_EditRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_EditRow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.btn_EditRow.FlatAppearance.BorderSize = 3;
            this.btn_EditRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.btn_EditRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditRow.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_EditRow.ForeColor = System.Drawing.Color.White;
            this.btn_EditRow.Location = new System.Drawing.Point(151, 1);
            this.btn_EditRow.Margin = new System.Windows.Forms.Padding(25, 1, 5, 1);
            this.btn_EditRow.Name = "btn_EditRow";
            this.btn_EditRow.Size = new System.Drawing.Size(118, 29);
            this.btn_EditRow.TabIndex = 51;
            this.btn_EditRow.Text = "Redigera Rad";
            this.btn_EditRow.UseVisualStyleBackColor = false;
            this.btn_EditRow.Click += new System.EventHandler(this.EditRow_Click);
            // 
            // Journal_Spolning_PTFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "Journal_Spolning_PTFE";
            this.Size = new System.Drawing.Size(906, 286);
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Journal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Journal_Input)).EndInit();
            this.flp_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public Button btn_SaveRow;
        private DataGridView dgv_Journal;
        private Panel panel_ExtraInfoLabels;
        public DataGridView dgv_Journal_Input;
        public Button btn_EditRow;
        private FlowLayoutPanel flp_Buttons;
    }
}
