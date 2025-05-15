namespace DigitalProductionProgram.Protocols.Protocol
{
    partial class Module
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Module = new System.Windows.Forms.DataGridView();
            this.label_LEFT = new System.Windows.Forms.Label();
            this.col_IsValueCritical = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_IsList_Protocol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_IsList_Processcard = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_IsOkWriteText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ProtocolDescriptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CodeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_StartUp_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Module)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Module
            // 
            this.dgv_Module.AllowUserToAddRows = false;
            this.dgv_Module.AllowUserToDeleteRows = false;
            this.dgv_Module.AllowUserToResizeColumns = false;
            this.dgv_Module.AllowUserToResizeRows = false;
            this.dgv_Module.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Module.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Module.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Module.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Module.ColumnHeadersHeight = 20;
            this.dgv_Module.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Module.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_IsValueCritical,
            this.col_IsList_Protocol,
            this.col_IsList_Processcard,
            this.col_IsOkWriteText,
            this.col_ProtocolDescriptionID,
            this.col_DataType,
            this.col_CodeText,
            this.col_Unit,
            this.col_MIN,
            this.col_NOM,
            this.col_MAX,
            this.col_StartUp_1});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Module.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Module.EnableHeadersVisualStyles = false;
            this.dgv_Module.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgv_Module.Location = new System.Drawing.Point(17, 0);
            this.dgv_Module.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Module.MultiSelect = false;
            this.dgv_Module.Name = "dgv_Module";
            this.dgv_Module.RowHeadersVisible = false;
            this.dgv_Module.RowTemplate.Height = 16;
            this.dgv_Module.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Module.Size = new System.Drawing.Size(659, 412);
            this.dgv_Module.TabIndex = 898;
            this.dgv_Module.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Protocol_CellDoubleClick);
            this.dgv_Module.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Module_CellEnter);
            this.dgv_Module.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Module_CellLeave);
            this.dgv_Module.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Module_ShowSpecialItems_CellRightMouseDown);
            this.dgv_Module.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Module_CellMouseEnter);
            this.dgv_Module.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.EditingControlShowing);
            this.dgv_Module.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Module_RowEnter);
            this.dgv_Module.Leave += new System.EventHandler(this.Module_Leave);
            // 
            // label_LEFT
            // 
            this.label_LEFT.BackColor = System.Drawing.Color.White;
            this.label_LEFT.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_LEFT.Location = new System.Drawing.Point(0, 0);
            this.label_LEFT.Margin = new System.Windows.Forms.Padding(0);
            this.label_LEFT.Name = "label_LEFT";
            this.label_LEFT.Size = new System.Drawing.Size(17, 412);
            this.label_LEFT.TabIndex = 899;
            this.label_LEFT.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_LEFT_Paint);
            // 
            // col_IsValueCritical
            // 
            this.col_IsValueCritical.Frozen = true;
            this.col_IsValueCritical.HeaderText = "IsValueCritical";
            this.col_IsValueCritical.Name = "col_IsValueCritical";
            this.col_IsValueCritical.Visible = false;
            this.col_IsValueCritical.Width = 5;
            // 
            // col_IsList_Protocol
            // 
            this.col_IsList_Protocol.Frozen = true;
            this.col_IsList_Protocol.HeaderText = "IsListProtocol";
            this.col_IsList_Protocol.Name = "col_IsList_Protocol";
            this.col_IsList_Protocol.Visible = false;
            this.col_IsList_Protocol.Width = 5;
            // 
            // col_IsList_Processcard
            // 
            this.col_IsList_Processcard.Frozen = true;
            this.col_IsList_Processcard.HeaderText = "IsListProcesscard";
            this.col_IsList_Processcard.Name = "col_IsList_Processcard";
            this.col_IsList_Processcard.Visible = false;
            // 
            // col_IsOkWriteText
            // 
            this.col_IsOkWriteText.Frozen = true;
            this.col_IsOkWriteText.HeaderText = "IsOkWriteText";
            this.col_IsOkWriteText.Name = "col_IsOkWriteText";
            this.col_IsOkWriteText.Visible = false;
            // 
            // col_ProtocolDescriptionID
            // 
            this.col_ProtocolDescriptionID.Frozen = true;
            this.col_ProtocolDescriptionID.HeaderText = "ProtocolDescriptionID";
            this.col_ProtocolDescriptionID.Name = "col_ProtocolDescriptionID";
            this.col_ProtocolDescriptionID.Visible = false;
            // 
            // col_DataType
            // 
            this.col_DataType.Frozen = true;
            this.col_DataType.HeaderText = "Type";
            this.col_DataType.Name = "col_DataType";
            this.col_DataType.Visible = false;
            // 
            // col_CodeText
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            this.col_CodeText.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_CodeText.Frozen = true;
            this.col_CodeText.HeaderText = "";
            this.col_CodeText.Name = "col_CodeText";
            this.col_CodeText.ReadOnly = true;
            this.col_CodeText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_CodeText.Width = 160;
            // 
            // col_Unit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.col_Unit.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Unit.Frozen = true;
            this.col_Unit.HeaderText = "Unit";
            this.col_Unit.Name = "col_Unit";
            this.col_Unit.ReadOnly = true;
            this.col_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Unit.Width = 48;
            // 
            // col_MIN
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.col_MIN.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_MIN.Frozen = true;
            this.col_MIN.HeaderText = "MIN";
            this.col_MIN.Name = "col_MIN";
            this.col_MIN.ReadOnly = true;
            this.col_MIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_NOM
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_NOM.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_NOM.Frozen = true;
            this.col_NOM.HeaderText = "NOM";
            this.col_NOM.Name = "col_NOM";
            this.col_NOM.ReadOnly = true;
            this.col_NOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_MAX
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.col_MAX.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_MAX.Frozen = true;
            this.col_MAX.HeaderText = "MAX";
            this.col_MAX.Name = "col_MAX";
            this.col_MAX.ReadOnly = true;
            this.col_MAX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_StartUp_1
            // 
            this.col_StartUp_1.HeaderText = "1";
            this.col_StartUp_1.Name = "col_StartUp_1";
            this.col_StartUp_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_StartUp_1.Width = 120;
            // 
            // Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_Module);
            this.Controls.Add(this.label_LEFT);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Module";
            this.Size = new System.Drawing.Size(676, 412);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Module)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dgv_Module;
        public System.Windows.Forms.Label label_LEFT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsValueCritical;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsList_Protocol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsList_Processcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_IsOkWriteText;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ProtocolDescriptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CodeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_StartUp_1;
    }
}
