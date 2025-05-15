using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    partial class RevisionInfo
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
            this.dgv_Revision = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Revision)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Revision
            // 
            this.dgv_Revision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Revision.Location = new System.Drawing.Point(34, 32);
            this.dgv_Revision.MultiSelect = false;
            this.dgv_Revision.Name = "dgv_Revision";
            this.dgv_Revision.ReadOnly = true;
            this.dgv_Revision.RowHeadersVisible = false;
            this.dgv_Revision.Size = new System.Drawing.Size(820, 436);
            this.dgv_Revision.TabIndex = 0;
            // 
            // RevisionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(888, 500);
            this.Controls.Add(this.dgv_Revision);
            this.Name = "RevisionInfo";
            this.Text = "RevisionInfo";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Revision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_Revision;
    }
}