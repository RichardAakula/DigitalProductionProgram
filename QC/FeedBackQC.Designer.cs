namespace DigitalProductionProgram.QC
{
    partial class FeedBackQC
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
            this.tlp_QC_Feedback = new System.Windows.Forms.TableLayoutPanel();
            this.label_Header_QC_Feeedback = new System.Windows.Forms.Label();
            this.label_Text = new System.Windows.Forms.Label();
            this.tlp_QC_Feedback.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_QC_Feedback
            // 
            this.tlp_QC_Feedback.BackColor = System.Drawing.Color.Transparent;
            this.tlp_QC_Feedback.ColumnCount = 2;
            this.tlp_QC_Feedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_QC_Feedback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_QC_Feedback.Controls.Add(this.label_Header_QC_Feeedback, 0, 0);
            this.tlp_QC_Feedback.Controls.Add(this.label_Text, 0, 1);
            this.tlp_QC_Feedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_QC_Feedback.Location = new System.Drawing.Point(0, 0);
            this.tlp_QC_Feedback.Name = "tlp_QC_Feedback";
            this.tlp_QC_Feedback.RowCount = 2;
            this.tlp_QC_Feedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.70886F));
            this.tlp_QC_Feedback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.29114F));
            this.tlp_QC_Feedback.Size = new System.Drawing.Size(449, 276);
            this.tlp_QC_Feedback.TabIndex = 914;
            // 
            // label_Header_QC_Feeedback
            // 
            this.label_Header_QC_Feeedback.AutoSize = true;
            this.label_Header_QC_Feeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))));
            this.tlp_QC_Feedback.SetColumnSpan(this.label_Header_QC_Feeedback, 2);
            this.label_Header_QC_Feeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Header_QC_Feeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Header_QC_Feeedback.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.label_Header_QC_Feeedback.ForeColor = System.Drawing.Color.Moccasin;
            this.label_Header_QC_Feeedback.Location = new System.Drawing.Point(0, 0);
            this.label_Header_QC_Feeedback.Margin = new System.Windows.Forms.Padding(0);
            this.label_Header_QC_Feeedback.Name = "label_Header_QC_Feeedback";
            this.label_Header_QC_Feeedback.Size = new System.Drawing.Size(449, 32);
            this.label_Header_QC_Feeedback.TabIndex = 873;
            this.label_Header_QC_Feeedback.Text = "Feedback från QC";
            this.label_Header_QC_Feeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Header_QC_Feeedback.UseMnemonic = false;
            // 
            // label_Text
            // 
            this.label_Text.AutoSize = true;
            this.label_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Text.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Text.Location = new System.Drawing.Point(3, 32);
            this.label_Text.Name = "label_Text";
            this.label_Text.Size = new System.Drawing.Size(218, 244);
            this.label_Text.TabIndex = 874;
            this.label_Text.Click += new System.EventHandler(this.Text_Click);
            // 
            // FeedBackQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.tlp_QC_Feedback);
            this.Name = "FeedBackQC";
            this.Size = new System.Drawing.Size(449, 276);
            this.tlp_QC_Feedback.ResumeLayout(false);
            this.tlp_QC_Feedback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_QC_Feedback;
        private System.Windows.Forms.Label label_Header_QC_Feeedback;
        private System.Windows.Forms.Label label_Text;
    }
}
