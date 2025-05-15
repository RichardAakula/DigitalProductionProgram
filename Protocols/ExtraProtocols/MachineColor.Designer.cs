using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols
{
    sealed partial class MachineColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineColor));
            this.dgv_MachineNames = new System.Windows.Forms.DataGridView();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Red = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Green = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsColorInverted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.btn_HS_Machine_Exit = new System.Windows.Forms.Button();
            this.btn_HS_Machine_Close = new System.Windows.Forms.Button();
            this.chb_HS_Machine_InvertForeColor = new System.Windows.Forms.CheckBox();
            this.btn_HS_Machine_NewColor = new System.Windows.Forms.Button();
            this.label_HS_Machine = new System.Windows.Forms.Label();
            this.label_HS_Color_Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MachineNames)).BeginInit();
            this.panel_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_MachineNames
            // 
            this.dgv_MachineNames.AllowUserToAddRows = false;
            this.dgv_MachineNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MachineNames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_MachineNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MachineNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineName,
            this.Red,
            this.Green,
            this.Blue,
            this.IsColorInverted});
            this.dgv_MachineNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MachineNames.Location = new System.Drawing.Point(0, 123);
            this.dgv_MachineNames.Name = "dgv_MachineNames";
            this.dgv_MachineNames.RowHeadersVisible = false;
            this.dgv_MachineNames.Size = new System.Drawing.Size(281, 569);
            this.dgv_MachineNames.TabIndex = 0;
            this.dgv_MachineNames.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MachineNames_CellEnter);
            // 
            // MachineName
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MachineName.DefaultCellStyle = dataGridViewCellStyle2;
            this.MachineName.HeaderText = "MachineName";
            this.MachineName.Name = "MachineName";
            // 
            // Red
            // 
            this.Red.HeaderText = "Red";
            this.Red.Name = "Red";
            this.Red.Visible = false;
            // 
            // Green
            // 
            this.Green.HeaderText = "Green";
            this.Green.Name = "Green";
            this.Green.Visible = false;
            // 
            // Blue
            // 
            this.Blue.HeaderText = "Blue";
            this.Blue.Name = "Blue";
            this.Blue.Visible = false;
            // 
            // IsColorInverted
            // 
            this.IsColorInverted.HeaderText = "IsColorInverted";
            this.IsColorInverted.Name = "IsColorInverted";
            this.IsColorInverted.Visible = false;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // panel_Left
            // 
            this.panel_Left.Controls.Add(this.dgv_MachineNames);
            this.panel_Left.Controls.Add(this.btn_HS_Machine_Exit);
            this.panel_Left.Controls.Add(this.btn_HS_Machine_Close);
            this.panel_Left.Controls.Add(this.chb_HS_Machine_InvertForeColor);
            this.panel_Left.Controls.Add(this.btn_HS_Machine_NewColor);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 97);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(281, 692);
            this.panel_Left.TabIndex = 1;
            // 
            // btn_HS_Machine_Exit
            // 
            this.btn_HS_Machine_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_HS_Machine_Exit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_HS_Machine_Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_HS_Machine_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HS_Machine_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_HS_Machine_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_HS_Machine_Exit.Location = new System.Drawing.Point(0, 90);
            this.btn_HS_Machine_Exit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_HS_Machine_Exit.Name = "btn_HS_Machine_Exit";
            this.btn_HS_Machine_Exit.Size = new System.Drawing.Size(281, 33);
            this.btn_HS_Machine_Exit.TabIndex = 977;
            this.btn_HS_Machine_Exit.Text = "Avsluta";
            this.btn_HS_Machine_Exit.UseVisualStyleBackColor = false;
            this.btn_HS_Machine_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btn_HS_Machine_Close
            // 
            this.btn_HS_Machine_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_HS_Machine_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_HS_Machine_Close.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_HS_Machine_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HS_Machine_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_HS_Machine_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_HS_Machine_Close.Location = new System.Drawing.Point(0, 57);
            this.btn_HS_Machine_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_HS_Machine_Close.Name = "btn_HS_Machine_Close";
            this.btn_HS_Machine_Close.Size = new System.Drawing.Size(281, 33);
            this.btn_HS_Machine_Close.TabIndex = 972;
            this.btn_HS_Machine_Close.Text = "Spara && Avsluta";
            this.btn_HS_Machine_Close.UseVisualStyleBackColor = false;
            this.btn_HS_Machine_Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // chb_HS_Machine_InvertForeColor
            // 
            this.chb_HS_Machine_InvertForeColor.AutoSize = true;
            this.chb_HS_Machine_InvertForeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.chb_HS_Machine_InvertForeColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_HS_Machine_InvertForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chb_HS_Machine_InvertForeColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.chb_HS_Machine_InvertForeColor.Location = new System.Drawing.Point(0, 33);
            this.chb_HS_Machine_InvertForeColor.Name = "chb_HS_Machine_InvertForeColor";
            this.chb_HS_Machine_InvertForeColor.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.chb_HS_Machine_InvertForeColor.Size = new System.Drawing.Size(281, 24);
            this.chb_HS_Machine_InvertForeColor.TabIndex = 976;
            this.chb_HS_Machine_InvertForeColor.Text = "Invertera färgen på texten";
            this.chb_HS_Machine_InvertForeColor.UseVisualStyleBackColor = false;
            this.chb_HS_Machine_InvertForeColor.CheckedChanged += new System.EventHandler(this.InvertForeColor_CheckedChanged);
            // 
            // btn_HS_Machine_NewColor
            // 
            this.btn_HS_Machine_NewColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_HS_Machine_NewColor.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_HS_Machine_NewColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_HS_Machine_NewColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HS_Machine_NewColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btn_HS_Machine_NewColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_HS_Machine_NewColor.Location = new System.Drawing.Point(0, 0);
            this.btn_HS_Machine_NewColor.Margin = new System.Windows.Forms.Padding(0);
            this.btn_HS_Machine_NewColor.Name = "btn_HS_Machine_NewColor";
            this.btn_HS_Machine_NewColor.Size = new System.Drawing.Size(281, 33);
            this.btn_HS_Machine_NewColor.TabIndex = 971;
            this.btn_HS_Machine_NewColor.Text = "Ny Färg";
            this.btn_HS_Machine_NewColor.UseVisualStyleBackColor = false;
            this.btn_HS_Machine_NewColor.Click += new System.EventHandler(this.NewColor_Click);
            // 
            // label_HS_Machine
            // 
            this.label_HS_Machine.BackColor = System.Drawing.Color.Transparent;
            this.label_HS_Machine.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_HS_Machine.Font = new System.Drawing.Font("Microsoft Sans Serif", 37.75F);
            this.label_HS_Machine.Location = new System.Drawing.Point(281, 97);
            this.label_HS_Machine.Name = "label_HS_Machine";
            this.label_HS_Machine.Size = new System.Drawing.Size(815, 158);
            this.label_HS_Machine.TabIndex = 0;
            this.label_HS_Machine.Text = "HS Machine";
            this.label_HS_Machine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HS_Color_Info
            // 
            this.label_HS_Color_Info.BackColor = System.Drawing.SystemColors.Info;
            this.label_HS_Color_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_HS_Color_Info.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HS_Color_Info.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label_HS_Color_Info.Location = new System.Drawing.Point(0, 0);
            this.label_HS_Color_Info.Name = "label_HS_Color_Info";
            this.label_HS_Color_Info.Size = new System.Drawing.Size(1096, 97);
            this.label_HS_Color_Info.TabIndex = 979;
            // 
            // MachineColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1096, 789);
            this.Controls.Add(this.label_HS_Machine);
            this.Controls.Add(this.panel_Left);
            this.Controls.Add(this.label_HS_Color_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MachineColor";
            this.Text = "MachineColor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MachineColor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MachineNames)).EndInit();
            this.panel_Left.ResumeLayout(false);
            this.panel_Left.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_MachineNames;
        private ColorDialog colorDialog;
        private Panel panel_Left;
        public Button btn_HS_Machine_NewColor;
        public Button btn_HS_Machine_Close;
        private Label label_HS_Machine;
        private DataGridViewTextBoxColumn MachineName;
        private DataGridViewTextBoxColumn Red;
        private DataGridViewTextBoxColumn Green;
        private DataGridViewTextBoxColumn Blue;
        private DataGridViewCheckBoxColumn IsColorInverted;
        private CheckBox chb_HS_Machine_InvertForeColor;
        private Label label_HS_Color_Info;
        public Button btn_HS_Machine_Exit;
    }
}