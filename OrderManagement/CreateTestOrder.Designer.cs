using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.OrderManagement
{
    partial class CreateTestOrder
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
            this.label_ArtikelNr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ArbetsOperation = new System.Windows.Forms.ComboBox();
            this.lbl_StartOrder = new System.Windows.Forms.Label();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.label_Operation = new System.Windows.Forms.Label();
            this.cb_Operation = new System.Windows.Forms.ComboBox();
            this.cb_RevNr = new System.Windows.Forms.ComboBox();
            this.label_RevNr = new System.Windows.Forms.Label();
            this.tb_ArtikelNr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_ArtikelNr
            // 
            this.label_ArtikelNr.AutoSize = true;
            this.label_ArtikelNr.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_ArtikelNr.Location = new System.Drawing.Point(51, 55);
            this.label_ArtikelNr.Name = "label_ArtikelNr";
            this.label_ArtikelNr.Size = new System.Drawing.Size(67, 13);
            this.label_ArtikelNr.TabIndex = 1;
            this.label_ArtikelNr.Text = "Välj ArtikelNr";
            this.label_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Välj ArbetsOperation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cb_ArbetsOperation
            // 
            this.cb_ArbetsOperation.Font = new System.Drawing.Font("Arial", 9F);
            this.cb_ArbetsOperation.FormattingEnabled = true;
            this.cb_ArbetsOperation.Location = new System.Drawing.Point(143, 25);
            this.cb_ArbetsOperation.Name = "cb_ArbetsOperation";
            this.cb_ArbetsOperation.Size = new System.Drawing.Size(220, 23);
            this.cb_ArbetsOperation.TabIndex = 0;
            this.cb_ArbetsOperation.SelectedIndexChanged += new System.EventHandler(this.ArbetsOperation_SelectedIndexChanged);
            // 
            // lbl_StartOrder
            // 
            this.lbl_StartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_StartOrder.AutoSize = true;
            this.lbl_StartOrder.BackColor = System.Drawing.Color.Transparent;
            this.lbl_StartOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_StartOrder.Font = new System.Drawing.Font("Palatino Linotype", 12.5F);
            this.lbl_StartOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_StartOrder.Location = new System.Drawing.Point(12, 227);
            this.lbl_StartOrder.Name = "lbl_StartOrder";
            this.lbl_StartOrder.Size = new System.Drawing.Size(106, 23);
            this.lbl_StartOrder.TabIndex = 842;
            this.lbl_StartOrder.Text = "Starta Order";
            this.lbl_StartOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_StartOrder.Click += new System.EventHandler(this.StartOrder_Click);
            this.lbl_StartOrder.MouseEnter += new System.EventHandler(this.StartOrder_MouseEnter);
            this.lbl_StartOrder.MouseLeave += new System.EventHandler(this.StartOrder_MouseLeave);
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Exit.Font = new System.Drawing.Font("Palatino Linotype", 12.5F);
            this.lbl_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Exit.Location = new System.Drawing.Point(374, 227);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(63, 23);
            this.lbl_Exit.TabIndex = 842;
            this.lbl_Exit.Text = "Avbryt";
            this.lbl_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Exit.Click += new System.EventHandler(this.Exit_Click);
            this.lbl_Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.lbl_Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.AutoSize = true;
            this.label_OrderNr.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_OrderNr.Location = new System.Drawing.Point(74, 122);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(44, 13);
            this.label_OrderNr.TabIndex = 1;
            this.label_OrderNr.Text = "OrderNr";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Arial", 9F);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_OrderNr.Location = new System.Drawing.Point(143, 122);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(51, 15);
            this.lbl_OrderNr.TabIndex = 1;
            this.lbl_OrderNr.Text = "OrderNr";
            this.lbl_OrderNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_Operation
            // 
            this.label_Operation.AutoSize = true;
            this.label_Operation.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_Operation.Location = new System.Drawing.Point(65, 146);
            this.label_Operation.Name = "label_Operation";
            this.label_Operation.Size = new System.Drawing.Size(53, 13);
            this.label_Operation.TabIndex = 1;
            this.label_Operation.Text = "Operation";
            this.label_Operation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cb_Operation
            // 
            this.cb_Operation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cb_Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Operation.Font = new System.Drawing.Font("Arial", 9F);
            this.cb_Operation.ForeColor = System.Drawing.Color.DarkGray;
            this.cb_Operation.FormattingEnabled = true;
            this.cb_Operation.Location = new System.Drawing.Point(143, 146);
            this.cb_Operation.Name = "cb_Operation";
            this.cb_Operation.Size = new System.Drawing.Size(220, 23);
            this.cb_Operation.TabIndex = 3;
            // 
            // cb_RevNr
            // 
            this.cb_RevNr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_RevNr.Font = new System.Drawing.Font("Arial", 9F);
            this.cb_RevNr.FormattingEnabled = true;
            this.cb_RevNr.Location = new System.Drawing.Point(143, 85);
            this.cb_RevNr.Name = "cb_RevNr";
            this.cb_RevNr.Size = new System.Drawing.Size(220, 23);
            this.cb_RevNr.TabIndex = 2;
            // 
            // label_RevNr
            // 
            this.label_RevNr.AutoSize = true;
            this.label_RevNr.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_RevNr.Location = new System.Drawing.Point(51, 85);
            this.label_RevNr.Name = "label_RevNr";
            this.label_RevNr.Size = new System.Drawing.Size(58, 13);
            this.label_RevNr.TabIndex = 1;
            this.label_RevNr.Text = "Välj RevNr";
            this.label_RevNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_ArtikelNr
            // 
            this.tb_ArtikelNr.Font = new System.Drawing.Font("Arial", 9F);
            this.tb_ArtikelNr.Location = new System.Drawing.Point(143, 55);
            this.tb_ArtikelNr.Multiline = true;
            this.tb_ArtikelNr.Name = "tb_ArtikelNr";
            this.tb_ArtikelNr.Size = new System.Drawing.Size(220, 23);
            this.tb_ArtikelNr.TabIndex = 843;
            this.tb_ArtikelNr.Click += new System.EventHandler(this.ArtikelNr_Click);
            this.tb_ArtikelNr.Leave += new System.EventHandler(this.ArtikelNr_Leave);
            // 
            // CreateTestOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(449, 259);
            this.Controls.Add(this.tb_ArtikelNr);
            this.Controls.Add(this.lbl_Exit);
            this.Controls.Add(this.lbl_StartOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Operation);
            this.Controls.Add(this.lbl_OrderNr);
            this.Controls.Add(this.label_OrderNr);
            this.Controls.Add(this.label_RevNr);
            this.Controls.Add(this.label_ArtikelNr);
            this.Controls.Add(this.cb_ArbetsOperation);
            this.Controls.Add(this.cb_Operation);
            this.Controls.Add(this.cb_RevNr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateTestOrder";
            this.Text = "Create_TestOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label_ArtikelNr;
        private Label label1;
        private ComboBox cb_ArbetsOperation;
        private Label lbl_StartOrder;
        private Label lbl_Exit;
        private Label label_OrderNr;
        private Label lbl_OrderNr;
        private Label label_Operation;
        private ComboBox cb_Operation;
        private ComboBox cb_RevNr;
        private Label label_RevNr;
        private TextBox tb_ArtikelNr;
    }
}