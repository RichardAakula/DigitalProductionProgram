using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Browse_Protocols
{
    partial class OrderList
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Avbryt = new System.Windows.Forms.Label();
            this.label_Rubrik = new System.Windows.Forms.Label();
            this.dgv_List_Orders = new System.Windows.Forms.DataGridView();
            this.lbl_Remove_FromList = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 436F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tlp_Main.Controls.Add(this.lbl_Close, 1, 0);
            this.tlp_Main.Controls.Add(this.lbl_Avbryt, 0, 2);
            this.tlp_Main.Controls.Add(this.label_Rubrik, 0, 0);
            this.tlp_Main.Controls.Add(this.dgv_List_Orders, 0, 1);
            this.tlp_Main.Controls.Add(this.lbl_Remove_FromList, 1, 1);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.838041F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.16196F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(601, 531);
            this.tlp_Main.TabIndex = 0;
            // 
            // lbl_Avbryt
            // 
            this.lbl_Avbryt.AutoSize = true;
            this.lbl_Avbryt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Avbryt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Avbryt.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.lbl_Avbryt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_Avbryt.Location = new System.Drawing.Point(439, 49);
            this.lbl_Avbryt.Name = "lbl_Avbryt";
            this.lbl_Avbryt.Size = new System.Drawing.Size(159, 20);
            this.lbl_Avbryt.TabIndex = 3;
            this.lbl_Avbryt.Text = "Fyll Orderlistan";
            this.lbl_Avbryt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Avbryt.Click += new System.EventHandler(this.Avbryt_Click);
            this.lbl_Avbryt.MouseEnter += new System.EventHandler(this.Labels_MouseEnter);
            this.lbl_Avbryt.MouseLeave += new System.EventHandler(this.Labels_MouseLeave);
            // 
            // label_Rubrik
            // 
            this.label_Rubrik.AutoSize = true;
            this.label_Rubrik.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Rubrik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Rubrik.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rubrik.ForeColor = System.Drawing.Color.LightYellow;
            this.label_Rubrik.Location = new System.Drawing.Point(3, 0);
            this.label_Rubrik.Name = "label_Rubrik";
            this.label_Rubrik.Size = new System.Drawing.Size(430, 29);
            this.label_Rubrik.TabIndex = 0;
            this.label_Rubrik.Text = "Lista med Ordrar";
            this.label_Rubrik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_List_Orders
            // 
            this.dgv_List_Orders.AllowUserToResizeColumns = false;
            this.dgv_List_Orders.AllowUserToResizeRows = false;
            this.dgv_List_Orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_List_Orders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_List_Orders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_List_Orders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_List_Orders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_List_Orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_List_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List_Orders.Cursor = System.Windows.Forms.Cursors.SizeAll;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_List_Orders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_List_Orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_List_Orders.Location = new System.Drawing.Point(3, 32);
            this.dgv_List_Orders.Name = "dgv_List_Orders";
            this.dgv_List_Orders.ReadOnly = true;
            this.dgv_List_Orders.RowHeadersVisible = false;
            this.tlp_Main.SetRowSpan(this.dgv_List_Orders, 2);
            this.dgv_List_Orders.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgv_List_Orders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_List_Orders.Size = new System.Drawing.Size(430, 496);
            this.dgv_List_Orders.TabIndex = 1;
            // 
            // lbl_Remove_FromList
            // 
            this.lbl_Remove_FromList.AutoSize = true;
            this.lbl_Remove_FromList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Remove_FromList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Remove_FromList.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.lbl_Remove_FromList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Remove_FromList.Location = new System.Drawing.Point(439, 29);
            this.lbl_Remove_FromList.Name = "lbl_Remove_FromList";
            this.lbl_Remove_FromList.Size = new System.Drawing.Size(159, 20);
            this.lbl_Remove_FromList.TabIndex = 2;
            this.lbl_Remove_FromList.Text = "Ta bort OrderNr";
            this.lbl_Remove_FromList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Remove_FromList.Click += new System.EventHandler(this.Remove_FromList_Click);
            this.lbl_Remove_FromList.MouseEnter += new System.EventHandler(this.Labels_MouseEnter);
            this.lbl_Remove_FromList.MouseLeave += new System.EventHandler(this.Labels_MouseLeave);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Close.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Close.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_Close.Location = new System.Drawing.Point(565, 0);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(33, 29);
            this.lbl_Close.TabIndex = 4;
            this.lbl_Close.Text = "X";
            this.lbl_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Close.Click += new System.EventHandler(this.Close_Click);
            this.lbl_Close.MouseEnter += new System.EventHandler(this.Labels_MouseEnter);
            this.lbl_Close.MouseLeave += new System.EventHandler(this.Labels_MouseLeave);
            // 
            // Sökning_OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(601, 531);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sökning_OrderList";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sökning_OrderList";
            this.TopMost = true;
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List_Orders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Rubrik;
        private DataGridView dgv_List_Orders;
        private Label lbl_Remove_FromList;
        private Label lbl_Avbryt;
        private Label lbl_Close;
    }
}