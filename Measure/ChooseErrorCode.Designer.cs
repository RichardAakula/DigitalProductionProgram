using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class ChooseErrorCode
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
            this.label_ErrorCodeHeader_1 = new System.Windows.Forms.Label();
            this.cb_ErrorCode = new System.Windows.Forms.ComboBox();
            this.label_ErrorDiscard = new System.Windows.Forms.Label();
            this.tb_Comments = new System.Windows.Forms.TextBox();
            this.label_ErrorCodeHeader_2 = new System.Windows.Forms.Label();
            this.label_ErrorExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ErrorCodeHeader_1
            // 
            this.label_ErrorCodeHeader_1.AutoSize = true;
            this.label_ErrorCodeHeader_1.ForeColor = System.Drawing.Color.White;
            this.label_ErrorCodeHeader_1.Location = new System.Drawing.Point(9, 6);
            this.label_ErrorCodeHeader_1.Name = "label_ErrorCodeHeader_1";
            this.label_ErrorCodeHeader_1.Size = new System.Drawing.Size(236, 13);
            this.label_ErrorCodeHeader_1.TabIndex = 0;
            this.label_ErrorCodeHeader_1.Text = "Välj felkod ur listan nedan och klicka på Kassera";
            // 
            // cb_ErrorCode
            // 
            this.cb_ErrorCode.FormattingEnabled = true;
            this.cb_ErrorCode.Location = new System.Drawing.Point(12, 33);
            this.cb_ErrorCode.Name = "cb_ErrorCode";
            this.cb_ErrorCode.Size = new System.Drawing.Size(209, 21);
            this.cb_ErrorCode.TabIndex = 1;
            this.cb_ErrorCode.SelectedIndexChanged += new System.EventHandler(this.ErrorCode_SelectedIndexChanged);
            // 
            // label_ErrorDiscard
            // 
            this.label_ErrorDiscard.BackColor = System.Drawing.Color.Transparent;
            this.label_ErrorDiscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ErrorDiscard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_ErrorDiscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.label_ErrorDiscard.Location = new System.Drawing.Point(0, 120);
            this.label_ErrorDiscard.Name = "label_ErrorDiscard";
            this.label_ErrorDiscard.Size = new System.Drawing.Size(80, 34);
            this.label_ErrorDiscard.TabIndex = 14;
            this.label_ErrorDiscard.Text = "Kassera";
            this.label_ErrorDiscard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_ErrorDiscard.Click += new System.EventHandler(this.Discard_Click);
            // 
            // tb_Comments
            // 
            this.tb_Comments.Location = new System.Drawing.Point(13, 90);
            this.tb_Comments.MaxLength = 38;
            this.tb_Comments.Name = "tb_Comments";
            this.tb_Comments.Size = new System.Drawing.Size(208, 20);
            this.tb_Comments.TabIndex = 15;
            // 
            // label_ErrorCodeHeader_2
            // 
            this.label_ErrorCodeHeader_2.AutoSize = true;
            this.label_ErrorCodeHeader_2.ForeColor = System.Drawing.Color.White;
            this.label_ErrorCodeHeader_2.Location = new System.Drawing.Point(9, 67);
            this.label_ErrorCodeHeader_2.Name = "label_ErrorCodeHeader_2";
            this.label_ErrorCodeHeader_2.Size = new System.Drawing.Size(237, 13);
            this.label_ErrorCodeHeader_2.TabIndex = 0;
            this.label_ErrorCodeHeader_2.Text = "Fyll i en kommentar varför du kasserat mätningen";
            // 
            // label_ErrorExit
            // 
            this.label_ErrorExit.BackColor = System.Drawing.Color.Transparent;
            this.label_ErrorExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ErrorExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_ErrorExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_ErrorExit.Location = new System.Drawing.Point(239, 120);
            this.label_ErrorExit.Name = "label_ErrorExit";
            this.label_ErrorExit.Size = new System.Drawing.Size(67, 34);
            this.label_ErrorExit.TabIndex = 14;
            this.label_ErrorExit.Text = "Avbryt";
            this.label_ErrorExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_ErrorExit.Click += new System.EventHandler(this.Abort_Click);
            // 
            // ChooseErrorCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(310, 155);
            this.Controls.Add(this.tb_Comments);
            this.Controls.Add(this.label_ErrorExit);
            this.Controls.Add(this.label_ErrorDiscard);
            this.Controls.Add(this.cb_ErrorCode);
            this.Controls.Add(this.label_ErrorCodeHeader_2);
            this.Controls.Add(this.label_ErrorCodeHeader_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChooseErrorCode";
            this.Text = "Välj_Felkod";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_ErrorCodeHeader_1;
        private ComboBox cb_ErrorCode;
        private Label label_ErrorDiscard;
        private TextBox tb_Comments;
        private Label label_ErrorCodeHeader_2;
        private Label label_ErrorExit;
    }
}