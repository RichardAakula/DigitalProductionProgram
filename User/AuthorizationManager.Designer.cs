using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.User
{
    partial class AuthorizationManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Template = new System.Windows.Forms.DataGridView();
            this.col_CodeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Details = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_UserDetails = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label_Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Template)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Details)).BeginInit();
            this.flp_Main.SuspendLayout();
            this.panel_UserDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Template
            // 
            this.dgv_Template.AllowUserToAddRows = false;
            this.dgv_Template.AllowUserToDeleteRows = false;
            this.dgv_Template.AllowUserToResizeColumns = false;
            this.dgv_Template.AllowUserToResizeRows = false;
            this.dgv_Template.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            this.dgv_Template.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(146)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Template.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Template.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_CodeText,
            this.col_IsName,
            this.col_Info});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Template.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Template.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_Template.EnableHeadersVisualStyles = false;
            this.dgv_Template.Location = new System.Drawing.Point(10, 10);
            this.dgv_Template.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.dgv_Template.Name = "dgv_Template";
            this.dgv_Template.RowHeadersVisible = false;
            this.dgv_Template.Size = new System.Drawing.Size(380, 495);
            this.dgv_Template.TabIndex = 0;
            this.dgv_Template.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Template_CellEnter);
            // 
            // col_CodeText
            // 
            this.col_CodeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_CodeText.HeaderText = "CodeText";
            this.col_CodeText.Name = "col_CodeText";
            this.col_CodeText.ReadOnly = true;
            // 
            // col_IsName
            // 
            this.col_IsName.HeaderText = "Is_NameOnly";
            this.col_IsName.Name = "col_IsName";
            this.col_IsName.ReadOnly = true;
            this.col_IsName.Visible = false;
            // 
            // col_Info
            // 
            this.col_Info.HeaderText = "Info";
            this.col_Info.Name = "col_Info";
            this.col_Info.Visible = false;
            // 
            // dgv_Details
            // 
            this.dgv_Details.AllowUserToAddRows = false;
            this.dgv_Details.AllowUserToDeleteRows = false;
            this.dgv_Details.AllowUserToResizeColumns = false;
            this.dgv_Details.AllowUserToResizeRows = false;
            this.dgv_Details.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            this.dgv_Details.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(146)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Details.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Details.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Details.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Details.EnableHeadersVisualStyles = false;
            this.dgv_Details.Location = new System.Drawing.Point(0, 50);
            this.dgv_Details.Name = "dgv_Details";
            this.dgv_Details.RowHeadersVisible = false;
            this.dgv_Details.Size = new System.Drawing.Size(374, 445);
            this.dgv_Details.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Namn";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_Remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Remove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Remove.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.btn_Remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Remove.Location = new System.Drawing.Point(0, 0);
            this.btn_Remove.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(374, 25);
            this.btn_Remove.TabIndex = 903;
            this.btn_Remove.Text = "Ta bort användare";
            this.btn_Remove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // flp_Main
            // 
            this.flp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.flp_Main.Controls.Add(this.dgv_Template);
            this.flp_Main.Controls.Add(this.panel_UserDetails);
            this.flp_Main.Controls.Add(this.label_Info);
            this.flp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Main.Location = new System.Drawing.Point(0, 0);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(786, 764);
            this.flp_Main.TabIndex = 1015;
            // 
            // panel_UserDetails
            // 
            this.panel_UserDetails.Controls.Add(this.dgv_Details);
            this.panel_UserDetails.Controls.Add(this.btn_Add);
            this.panel_UserDetails.Controls.Add(this.btn_Remove);
            this.panel_UserDetails.Location = new System.Drawing.Point(396, 10);
            this.panel_UserDetails.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.panel_UserDetails.Name = "panel_UserDetails";
            this.panel_UserDetails.Size = new System.Drawing.Size(374, 495);
            this.panel_UserDetails.TabIndex = 1018;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.btn_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Add.Location = new System.Drawing.Point(0, 25);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(374, 25);
            this.btn_Add.TabIndex = 904;
            this.btn_Add.Text = "Lägg till";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label_Info
            // 
            this.label_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(198)))), ((int)(((byte)(176)))));
            this.label_Info.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(91)))));
            this.label_Info.Location = new System.Drawing.Point(10, 518);
            this.label_Info.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(760, 227);
            this.label_Info.TabIndex = 1019;
            this.label_Info.Text = "Info";
            // 
            // AuthorizationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(786, 764);
            this.Controls.Add(this.flp_Main);
            this.Name = "AuthorizationManager";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Template)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Details)).EndInit();
            this.flp_Main.ResumeLayout(false);
            this.panel_UserDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_Template;
        private DataGridView dgv_Details;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Button btn_Remove;
        private FlowLayoutPanel flp_Main;
        private Panel panel_UserDetails;
        private Button btn_Add;
        private Label label_Info;
        private DataGridViewTextBoxColumn col_CodeText;
        private DataGridViewTextBoxColumn col_IsName;
        private DataGridViewTextBoxColumn col_Info;
    }
}