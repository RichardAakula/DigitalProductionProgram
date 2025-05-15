using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.OrderManagement
{
    partial class Manage_WorkOperation
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
            this.label_Workoperation_Header = new System.Windows.Forms.Label();
            this.cb_Workoperations = new System.Windows.Forms.ComboBox();
            this.btn_Workoperation_Choose = new System.Windows.Forms.Button();
            this.btn_Workoperation_Abort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Workoperation_Header
            // 
            this.label_Workoperation_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Workoperation_Header.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Workoperation_Header.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Workoperation_Header.Location = new System.Drawing.Point(0, 0);
            this.label_Workoperation_Header.Name = "label_Workoperation_Header";
            this.label_Workoperation_Header.Size = new System.Drawing.Size(400, 30);
            this.label_Workoperation_Header.TabIndex = 0;
            this.label_Workoperation_Header.Text = "Välj Arbetsoperation";
            this.label_Workoperation_Header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_Workoperations
            // 
            this.cb_Workoperations.FormattingEnabled = true;
            this.cb_Workoperations.Location = new System.Drawing.Point(87, 44);
            this.cb_Workoperations.Name = "cb_Workoperations";
            this.cb_Workoperations.Size = new System.Drawing.Size(222, 21);
            this.cb_Workoperations.TabIndex = 1;
            // 
            // btn_Workoperation_Choose
            // 
            this.btn_Workoperation_Choose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Workoperation_Choose.ForeColor = System.Drawing.Color.White;
            this.btn_Workoperation_Choose.Location = new System.Drawing.Point(87, 86);
            this.btn_Workoperation_Choose.Name = "btn_Workoperation_Choose";
            this.btn_Workoperation_Choose.Size = new System.Drawing.Size(75, 23);
            this.btn_Workoperation_Choose.TabIndex = 2;
            this.btn_Workoperation_Choose.Text = "Välj";
            this.btn_Workoperation_Choose.UseVisualStyleBackColor = true;
            this.btn_Workoperation_Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // btn_Workoperation_Abort
            // 
            this.btn_Workoperation_Abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Workoperation_Abort.ForeColor = System.Drawing.Color.White;
            this.btn_Workoperation_Abort.Location = new System.Drawing.Point(234, 86);
            this.btn_Workoperation_Abort.Name = "btn_Workoperation_Abort";
            this.btn_Workoperation_Abort.Size = new System.Drawing.Size(75, 23);
            this.btn_Workoperation_Abort.TabIndex = 2;
            this.btn_Workoperation_Abort.Text = "Avbryt";
            this.btn_Workoperation_Abort.UseVisualStyleBackColor = true;
            this.btn_Workoperation_Abort.Click += new System.EventHandler(this.Abort_Click);
            // 
            // Manage_WorkOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(400, 121);
            this.Controls.Add(this.btn_Workoperation_Abort);
            this.Controls.Add(this.btn_Workoperation_Choose);
            this.Controls.Add(this.cb_Workoperations);
            this.Controls.Add(this.label_Workoperation_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manage_WorkOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Arbetsoperation";
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_Workoperation_Header;
        private ComboBox cb_Workoperations;
        private Button btn_Workoperation_Choose;
        private Button btn_Workoperation_Abort;
    }
}