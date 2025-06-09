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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgv_Module = new DataGridView();
            col_IsValueCritical = new DataGridViewCheckBoxColumn();
            col_IsList_Protocol = new DataGridViewCheckBoxColumn();
            col_IsList_Processcard = new DataGridViewCheckBoxColumn();
            col_IsOkWriteText = new DataGridViewTextBoxColumn();
            col_ProtocolDescriptionID = new DataGridViewTextBoxColumn();
            col_DataType = new DataGridViewTextBoxColumn();
            col_CodeText = new DataGridViewTextBoxColumn();
            col_Unit = new DataGridViewTextBoxColumn();
            col_MIN = new DataGridViewTextBoxColumn();
            col_NOM = new DataGridViewTextBoxColumn();
            col_MAX = new DataGridViewTextBoxColumn();
            col_StartUp_1 = new DataGridViewTextBoxColumn();
            label_LEFT = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_Module).BeginInit();
            SuspendLayout();
            // 
            // dgv_Module
            // 
            dgv_Module.AllowUserToAddRows = false;
            dgv_Module.AllowUserToDeleteRows = false;
            dgv_Module.AllowUserToResizeColumns = false;
            dgv_Module.AllowUserToResizeRows = false;
            dgv_Module.BackgroundColor = Color.FromArgb(65, 65, 65);
            dgv_Module.BorderStyle = BorderStyle.None;
            dgv_Module.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Bisque;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.ForestGreen;
            dataGridViewCellStyle1.SelectionBackColor = Color.Bisque;
            dataGridViewCellStyle1.SelectionForeColor = Color.ForestGreen;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Module.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Module.ColumnHeadersHeight = 20;
            dgv_Module.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Module.Columns.AddRange(new DataGridViewColumn[] { col_IsValueCritical, col_IsList_Protocol, col_IsList_Processcard, col_IsOkWriteText, col_ProtocolDescriptionID, col_DataType, col_CodeText, col_Unit, col_MIN, col_NOM, col_MAX, col_StartUp_1 });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgv_Module.DefaultCellStyle = dataGridViewCellStyle7;
            dgv_Module.Dock = DockStyle.Fill;
            dgv_Module.EnableHeadersVisualStyles = false;
            dgv_Module.GridColor = Color.FromArgb(30, 30, 30);
            dgv_Module.Location = new Point(20, 0);
            dgv_Module.Margin = new Padding(0);
            dgv_Module.MultiSelect = false;
            dgv_Module.Name = "dgv_Module";
            dgv_Module.RowHeadersVisible = false;
            dgv_Module.RowTemplate.Height = 16;
            dgv_Module.ScrollBars = ScrollBars.None;
            dgv_Module.Size = new Size(769, 475);
            dgv_Module.TabIndex = 898;
            dgv_Module.CellDoubleClick += Protocol_CellDoubleClick;
            dgv_Module.CellEnter += Module_CellEnter;
            dgv_Module.CellLeave += Module_CellLeave;
            dgv_Module.CellMouseDown += Module_ShowSpecialItems_CellRightMouseDown;
            dgv_Module.CellMouseEnter += Module_CellMouseEnter;
            dgv_Module.EditingControlShowing += EditingControlShowing;
            dgv_Module.RowEnter += Module_RowEnter;
            dgv_Module.Leave += Module_Leave;
            // 
            // col_IsValueCritical
            // 
            col_IsValueCritical.Frozen = true;
            col_IsValueCritical.HeaderText = "IsValueCritical";
            col_IsValueCritical.Name = "col_IsValueCritical";
            col_IsValueCritical.Visible = false;
            col_IsValueCritical.Width = 5;
            // 
            // col_IsList_Protocol
            // 
            col_IsList_Protocol.Frozen = true;
            col_IsList_Protocol.HeaderText = "IsListProtocol";
            col_IsList_Protocol.Name = "col_IsList_Protocol";
            col_IsList_Protocol.Visible = false;
            col_IsList_Protocol.Width = 5;
            // 
            // col_IsList_Processcard
            // 
            col_IsList_Processcard.Frozen = true;
            col_IsList_Processcard.HeaderText = "IsListProcesscard";
            col_IsList_Processcard.Name = "col_IsList_Processcard";
            col_IsList_Processcard.Visible = false;
            // 
            // col_IsOkWriteText
            // 
            col_IsOkWriteText.Frozen = true;
            col_IsOkWriteText.HeaderText = "IsOkWriteText";
            col_IsOkWriteText.Name = "col_IsOkWriteText";
            col_IsOkWriteText.Visible = false;
            // 
            // col_ProtocolDescriptionID
            // 
            col_ProtocolDescriptionID.Frozen = true;
            col_ProtocolDescriptionID.HeaderText = "ProtocolDescriptionID";
            col_ProtocolDescriptionID.Name = "col_ProtocolDescriptionID";
            col_ProtocolDescriptionID.Visible = false;
            // 
            // col_DataType
            // 
            col_DataType.Frozen = true;
            col_DataType.HeaderText = "Type";
            col_DataType.Name = "col_DataType";
            col_DataType.Visible = false;
            // 
            // col_CodeText
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Arial", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.DodgerBlue;
            col_CodeText.DefaultCellStyle = dataGridViewCellStyle2;
            col_CodeText.Frozen = true;
            col_CodeText.HeaderText = "";
            col_CodeText.Name = "col_CodeText";
            col_CodeText.ReadOnly = true;
            col_CodeText.SortMode = DataGridViewColumnSortMode.NotSortable;
            col_CodeText.Width = 160;
            // 
            // col_Unit
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Bisque;
            dataGridViewCellStyle3.Font = new Font("Arial", 7F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            col_Unit.DefaultCellStyle = dataGridViewCellStyle3;
            col_Unit.Frozen = true;
            col_Unit.HeaderText = "Unit";
            col_Unit.Name = "col_Unit";
            col_Unit.ReadOnly = true;
            col_Unit.SortMode = DataGridViewColumnSortMode.NotSortable;
            col_Unit.Width = 48;
            // 
            // col_MIN
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle4.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.DodgerBlue;
            col_MIN.DefaultCellStyle = dataGridViewCellStyle4;
            col_MIN.Frozen = true;
            col_MIN.HeaderText = "MIN";
            col_MIN.Name = "col_MIN";
            col_MIN.ReadOnly = true;
            col_MIN.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // col_NOM
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle5.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.ForestGreen;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            col_NOM.DefaultCellStyle = dataGridViewCellStyle5;
            col_NOM.Frozen = true;
            col_NOM.HeaderText = "NOM";
            col_NOM.Name = "col_NOM";
            col_NOM.ReadOnly = true;
            col_NOM.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // col_MAX
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle6.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.DodgerBlue;
            col_MAX.DefaultCellStyle = dataGridViewCellStyle6;
            col_MAX.Frozen = true;
            col_MAX.HeaderText = "MAX";
            col_MAX.Name = "col_MAX";
            col_MAX.ReadOnly = true;
            col_MAX.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // col_StartUp_1
            // 
            col_StartUp_1.HeaderText = "1";
            col_StartUp_1.Name = "col_StartUp_1";
            col_StartUp_1.SortMode = DataGridViewColumnSortMode.NotSortable;
            col_StartUp_1.Width = 120;
            // 
            // label_LEFT
            // 
            label_LEFT.BackColor = Color.White;
            label_LEFT.Dock = DockStyle.Left;
            label_LEFT.Location = new Point(0, 0);
            label_LEFT.Margin = new Padding(0);
            label_LEFT.Name = "label_LEFT";
            label_LEFT.Size = new Size(20, 475);
            label_LEFT.TabIndex = 899;
            label_LEFT.Paint += Label_LEFT_Paint;
            // 
            // Module
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgv_Module);
            Controls.Add(label_LEFT);
            Margin = new Padding(0);
            Name = "Module";
            Size = new Size(789, 475);
            Load += Module_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Module).EndInit();
            ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dgv_Module;
        public System.Windows.Forms.Label label_LEFT;
        private DataGridViewCheckBoxColumn col_IsValueCritical;
        private DataGridViewCheckBoxColumn col_IsList_Protocol;
        private DataGridViewCheckBoxColumn col_IsList_Processcard;
        private DataGridViewTextBoxColumn col_IsOkWriteText;
        private DataGridViewTextBoxColumn col_ProtocolDescriptionID;
        private DataGridViewTextBoxColumn col_DataType;
        private DataGridViewTextBoxColumn col_CodeText;
        private DataGridViewTextBoxColumn col_Unit;
        private DataGridViewTextBoxColumn col_MIN;
        private DataGridViewTextBoxColumn col_NOM;
        private DataGridViewTextBoxColumn col_MAX;
        private DataGridViewTextBoxColumn col_StartUp_1;
    }
}
