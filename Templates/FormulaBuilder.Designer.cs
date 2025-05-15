namespace DigitalProductionProgram.Protocols.Template_Management
{
    partial class FormulaBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Functions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_SaveFormula = new System.Windows.Forms.Button();
            this.dgv_MeasureValues = new System.Windows.Forms.DataGridView();
            this.col_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Parameter = new System.Windows.Forms.Label();
            this.tb_Formula = new System.Windows.Forms.TextBox();
            this.dgv_Variables = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_FormulaResult = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Functions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MeasureValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Variables)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 4;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tlp_Main.Controls.Add(this.dgv_Functions, 1, 1);
            this.tlp_Main.Controls.Add(this.btn_SaveFormula, 0, 0);
            this.tlp_Main.Controls.Add(this.dgv_MeasureValues, 0, 1);
            this.tlp_Main.Controls.Add(this.label_Parameter, 2, 0);
            this.tlp_Main.Controls.Add(this.tb_Formula, 2, 1);
            this.tlp_Main.Controls.Add(this.dgv_Variables, 2, 2);
            this.tlp_Main.Controls.Add(this.label_FormulaResult, 3, 2);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tlp_Main.Size = new System.Drawing.Size(800, 450);
            this.tlp_Main.TabIndex = 0;
            // 
            // dgv_Functions
            // 
            this.dgv_Functions.AllowUserToAddRows = false;
            this.dgv_Functions.AllowUserToDeleteRows = false;
            this.dgv_Functions.AllowUserToResizeColumns = false;
            this.dgv_Functions.AllowUserToResizeRows = false;
            this.dgv_Functions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Functions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.dgv_Functions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Functions.ColumnHeadersVisible = false;
            this.dgv_Functions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_Functions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Functions.Location = new System.Drawing.Point(143, 64);
            this.dgv_Functions.MultiSelect = false;
            this.dgv_Functions.Name = "dgv_Functions";
            this.dgv_Functions.ReadOnly = true;
            this.dgv_Functions.RowHeadersVisible = false;
            this.tlp_Main.SetRowSpan(this.dgv_Functions, 2);
            this.dgv_Functions.Size = new System.Drawing.Size(134, 383);
            this.dgv_Functions.TabIndex = 30;
            this.dgv_Functions.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Parameters_CellMouseDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ColumnIndex";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 5;
            // 
            // btn_SaveFormula
            // 
            this.btn_SaveFormula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_SaveFormula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveFormula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveFormula.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_SaveFormula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_SaveFormula.Location = new System.Drawing.Point(3, 3);
            this.btn_SaveFormula.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_SaveFormula.Name = "btn_SaveFormula";
            this.btn_SaveFormula.Size = new System.Drawing.Size(134, 30);
            this.btn_SaveFormula.TabIndex = 29;
            this.btn_SaveFormula.Text = "Spara";
            this.btn_SaveFormula.UseVisualStyleBackColor = false;
            this.btn_SaveFormula.Click += new System.EventHandler(this.SaveFormula_Click);
            // 
            // dgv_MeasureValues
            // 
            this.dgv_MeasureValues.AllowUserToAddRows = false;
            this.dgv_MeasureValues.AllowUserToDeleteRows = false;
            this.dgv_MeasureValues.AllowUserToResizeColumns = false;
            this.dgv_MeasureValues.AllowUserToResizeRows = false;
            this.dgv_MeasureValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_MeasureValues.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.dgv_MeasureValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MeasureValues.ColumnHeadersVisible = false;
            this.dgv_MeasureValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Parameter});
            this.dgv_MeasureValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MeasureValues.Location = new System.Drawing.Point(3, 64);
            this.dgv_MeasureValues.MultiSelect = false;
            this.dgv_MeasureValues.Name = "dgv_MeasureValues";
            this.dgv_MeasureValues.ReadOnly = true;
            this.dgv_MeasureValues.RowHeadersVisible = false;
            this.tlp_Main.SetRowSpan(this.dgv_MeasureValues, 2);
            this.dgv_MeasureValues.Size = new System.Drawing.Size(134, 383);
            this.dgv_MeasureValues.TabIndex = 4;
            this.dgv_MeasureValues.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Parameters_CellMouseDown);
            // 
            // col_Parameter
            // 
            this.col_Parameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Parameter.HeaderText = "Parameter";
            this.col_Parameter.Name = "col_Parameter";
            this.col_Parameter.ReadOnly = true;
            // 
            // label_Parameter
            // 
            this.label_Parameter.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.SetColumnSpan(this.label_Parameter, 2);
            this.label_Parameter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Parameter.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Parameter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_Parameter.Location = new System.Drawing.Point(283, 39);
            this.label_Parameter.Name = "label_Parameter";
            this.label_Parameter.Size = new System.Drawing.Size(514, 22);
            this.label_Parameter.TabIndex = 10;
            this.label_Parameter.Text = "Formula";
            // 
            // tb_Formula
            // 
            this.tlp_Main.SetColumnSpan(this.tb_Formula, 2);
            this.tb_Formula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Formula.Location = new System.Drawing.Point(283, 64);
            this.tb_Formula.Multiline = true;
            this.tb_Formula.Name = "tb_Formula";
            this.tb_Formula.Size = new System.Drawing.Size(514, 68);
            this.tb_Formula.TabIndex = 28;
            this.tb_Formula.Text = "=";
            this.tb_Formula.TextChanged += new System.EventHandler(this.Formula_TextChanged);
            // 
            // dgv_Variables
            // 
            this.dgv_Variables.AllowUserToAddRows = false;
            this.dgv_Variables.AllowUserToDeleteRows = false;
            this.dgv_Variables.AllowUserToResizeColumns = false;
            this.dgv_Variables.AllowUserToResizeRows = false;
            this.dgv_Variables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Variables.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.dgv_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Variables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgv_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Variables.Location = new System.Drawing.Point(283, 138);
            this.dgv_Variables.MultiSelect = false;
            this.dgv_Variables.Name = "dgv_Variables";
            this.dgv_Variables.RowHeadersVisible = false;
            this.dgv_Variables.Size = new System.Drawing.Size(172, 309);
            this.dgv_Variables.TabIndex = 30;
            this.dgv_Variables.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Variables_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 59;
            // 
            // label_FormulaResult
            // 
            this.label_FormulaResult.AutoSize = true;
            this.label_FormulaResult.BackColor = System.Drawing.Color.White;
            this.label_FormulaResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_FormulaResult.Font = new System.Drawing.Font("Arial", 12.25F);
            this.label_FormulaResult.Location = new System.Drawing.Point(461, 150);
            this.label_FormulaResult.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label_FormulaResult.Name = "label_FormulaResult";
            this.label_FormulaResult.Size = new System.Drawing.Size(336, 19);
            this.label_FormulaResult.TabIndex = 31;
            // 
            // FormulaBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlp_Main);
            this.Name = "FormulaBuilder";
            this.Text = "Formula_Value";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormulaBuilder_FormClosing);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Functions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MeasureValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Variables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.DataGridView dgv_MeasureValues;
        private System.Windows.Forms.Label label_Parameter;
        private System.Windows.Forms.TextBox tb_Formula;
        private System.Windows.Forms.Button btn_SaveFormula;
        private System.Windows.Forms.DataGridView dgv_Functions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Parameter;
        private System.Windows.Forms.DataGridView dgv_Variables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label_FormulaResult;
    }
}