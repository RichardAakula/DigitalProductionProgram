namespace DigitalProductionProgram.Protocols.MainInfo
{
    partial class Room_TempMoisture
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Fukt_enhet = new System.Windows.Forms.Label();
            this.Rum_Fukt = new System.Windows.Forms.TextBox();
            this.label_Temp_enhet = new System.Windows.Forms.Label();
            this.Rum_Temp = new System.Windows.Forms.TextBox();
            this.label_RoomTempMoist = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 5;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlp_Main.Controls.Add(this.label_Fukt_enhet, 4, 0);
            this.tlp_Main.Controls.Add(this.Rum_Fukt, 3, 0);
            this.tlp_Main.Controls.Add(this.label_Temp_enhet, 2, 0);
            this.tlp_Main.Controls.Add(this.Rum_Temp, 1, 0);
            this.tlp_Main.Controls.Add(this.label_RoomTempMoist, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp_Main.Size = new System.Drawing.Size(326, 27);
            this.tlp_Main.TabIndex = 0;
            // 
            // label_Fukt_enhet
            // 
            this.label_Fukt_enhet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_Fukt_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Fukt_enhet.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Fukt_enhet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Fukt_enhet.Location = new System.Drawing.Point(246, 0);
            this.label_Fukt_enhet.Margin = new System.Windows.Forms.Padding(0);
            this.label_Fukt_enhet.Name = "label_Fukt_enhet";
            this.label_Fukt_enhet.Size = new System.Drawing.Size(81, 27);
            this.label_Fukt_enhet.TabIndex = 950;
            this.label_Fukt_enhet.Text = "%Re";
            // 
            // Rum_Fukt
            // 
            this.Rum_Fukt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.Rum_Fukt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rum_Fukt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rum_Fukt.Font = new System.Drawing.Font("Courier New", 10.25F);
            this.Rum_Fukt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.Rum_Fukt.Location = new System.Drawing.Point(206, 0);
            this.Rum_Fukt.Margin = new System.Windows.Forms.Padding(0);
            this.Rum_Fukt.MaxLength = 5;
            this.Rum_Fukt.Multiline = true;
            this.Rum_Fukt.Name = "Rum_Fukt";
            this.Rum_Fukt.Size = new System.Drawing.Size(40, 27);
            this.Rum_Fukt.TabIndex = 949;
            this.Rum_Fukt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Rum_Fukt.WordWrap = false;
            this.Rum_Fukt.Leave += new System.EventHandler(this.ValidateData_Leave);
            // 
            // label_Temp_enhet
            // 
            this.label_Temp_enhet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_Temp_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Temp_enhet.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Temp_enhet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Temp_enhet.Location = new System.Drawing.Point(175, 0);
            this.label_Temp_enhet.Margin = new System.Windows.Forms.Padding(0);
            this.label_Temp_enhet.Name = "label_Temp_enhet";
            this.label_Temp_enhet.Size = new System.Drawing.Size(31, 27);
            this.label_Temp_enhet.TabIndex = 948;
            this.label_Temp_enhet.Text = "C°";
            // 
            // Rum_Temp
            // 
            this.Rum_Temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.Rum_Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rum_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rum_Temp.Font = new System.Drawing.Font("Courier New", 10.25F);
            this.Rum_Temp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.Rum_Temp.Location = new System.Drawing.Point(115, 0);
            this.Rum_Temp.Margin = new System.Windows.Forms.Padding(0);
            this.Rum_Temp.MaxLength = 4;
            this.Rum_Temp.Multiline = true;
            this.Rum_Temp.Name = "Rum_Temp";
            this.Rum_Temp.Size = new System.Drawing.Size(60, 27);
            this.Rum_Temp.TabIndex = 947;
            this.Rum_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Rum_Temp.Leave += new System.EventHandler(this.ValidateData_Leave);
            // 
            // label_RoomTempMoist
            // 
            this.label_RoomTempMoist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_RoomTempMoist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_RoomTempMoist.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_RoomTempMoist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_RoomTempMoist.Location = new System.Drawing.Point(0, 0);
            this.label_RoomTempMoist.Margin = new System.Windows.Forms.Padding(0);
            this.label_RoomTempMoist.Name = "label_RoomTempMoist";
            this.label_RoomTempMoist.Size = new System.Drawing.Size(115, 27);
            this.label_RoomTempMoist.TabIndex = 946;
            this.label_RoomTempMoist.Text = "Rums-temp/fukt:";
            // 
            // Room_TempMoisture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "Room_TempMoisture";
            this.Size = new System.Drawing.Size(326, 27);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Label label_RoomTempMoist;
        public System.Windows.Forms.TextBox Rum_Temp;
        private System.Windows.Forms.Label label_Temp_enhet;
        public System.Windows.Forms.TextBox Rum_Fukt;
        private System.Windows.Forms.Label label_Fukt_enhet;
    }
}
