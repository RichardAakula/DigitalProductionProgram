using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Processcards
{
    partial class Choose_WorkOperation_BrowseProtocols_ManageProcesscards
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
            this.label_ChoosePC_Header = new System.Windows.Forms.Label();
            this.flp_Left = new System.Windows.Forms.FlowLayoutPanel();
            this.label_Info = new System.Windows.Forms.Label();
            this.tb_PartNr = new System.Windows.Forms.TextBox();
            this.label_Avdelning = new System.Windows.Forms.Label();
            this.flp_ArbetsOperation = new System.Windows.Forms.FlowLayoutPanel();
            this.label_ChoosePC_Info_1 = new System.Windows.Forms.Label();
            this.flp_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ChoosePC_Header
            // 
            this.label_ChoosePC_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.label_ChoosePC_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_ChoosePC_Header.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ChoosePC_Header.ForeColor = System.Drawing.Color.White;
            this.label_ChoosePC_Header.Location = new System.Drawing.Point(0, 0);
            this.label_ChoosePC_Header.Name = "label_ChoosePC_Header";
            this.label_ChoosePC_Header.Size = new System.Drawing.Size(800, 56);
            this.label_ChoosePC_Header.TabIndex = 0;
            this.label_ChoosePC_Header.Text = "Hantering av Proceskort";
            this.label_ChoosePC_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flp_Left
            // 
            this.flp_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.flp_Left.Controls.Add(this.label_Info);
            this.flp_Left.Controls.Add(this.tb_PartNr);
            this.flp_Left.Controls.Add(this.label_Avdelning);
            this.flp_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.flp_Left.Location = new System.Drawing.Point(0, 74);
            this.flp_Left.Name = "flp_Left";
            this.flp_Left.Size = new System.Drawing.Size(210, 382);
            this.flp_Left.TabIndex = 1;
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.BackColor = System.Drawing.Color.Transparent;
            this.label_Info.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(220)))), ((int)(((byte)(231)))));
            this.label_Info.Location = new System.Drawing.Point(3, 10);
            this.label_Info.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(182, 54);
            this.label_Info.TabIndex = 1;
            this.label_Info.Text = "Välj ArtikelNr och programmet väljer Arbetsoperation åt dig.";
            // 
            // tb_PartNr
            // 
            this.tb_PartNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.tb_PartNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PartNr.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.tb_PartNr.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tb_PartNr.Location = new System.Drawing.Point(3, 77);
            this.tb_PartNr.Name = "tb_PartNr";
            this.tb_PartNr.ReadOnly = true;
            this.tb_PartNr.Size = new System.Drawing.Size(182, 24);
            this.tb_PartNr.TabIndex = 1011;
            this.tb_PartNr.Click += new System.EventHandler(this.PartNr_Click);
            // 
            // label_Avdelning
            // 
            this.label_Avdelning.AutoSize = true;
            this.label_Avdelning.Font = new System.Drawing.Font("Mongolian Baiti", 11.75F);
            this.label_Avdelning.Location = new System.Drawing.Point(191, 84);
            this.label_Avdelning.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label_Avdelning.Name = "label_Avdelning";
            this.label_Avdelning.Size = new System.Drawing.Size(0, 16);
            this.label_Avdelning.TabIndex = 1;
            // 
            // flp_ArbetsOperation
            // 
            this.flp_ArbetsOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.flp_ArbetsOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_ArbetsOperation.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_ArbetsOperation.Location = new System.Drawing.Point(210, 74);
            this.flp_ArbetsOperation.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.flp_ArbetsOperation.MaximumSize = new System.Drawing.Size(590, 380);
            this.flp_ArbetsOperation.Name = "flp_ArbetsOperation";
            this.flp_ArbetsOperation.Size = new System.Drawing.Size(590, 380);
            this.flp_ArbetsOperation.TabIndex = 2;
            // 
            // label_ChoosePC_Info_1
            // 
            this.label_ChoosePC_Info_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.label_ChoosePC_Info_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_ChoosePC_Info_1.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F);
            this.label_ChoosePC_Info_1.ForeColor = System.Drawing.Color.White;
            this.label_ChoosePC_Info_1.Location = new System.Drawing.Point(0, 56);
            this.label_ChoosePC_Info_1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.label_ChoosePC_Info_1.Name = "label_ChoosePC_Info_1";
            this.label_ChoosePC_Info_1.Padding = new System.Windows.Forms.Padding(240, 0, 0, 0);
            this.label_ChoosePC_Info_1.Size = new System.Drawing.Size(800, 18);
            this.label_ChoosePC_Info_1.TabIndex = 1;
            this.label_ChoosePC_Info_1.Text = "Här nedan kan du klicka på den arbetsoperation du vill gå till.";
            // 
            // Choose_WorkOperation_BrowseProtocols_ManageProcesscards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.flp_ArbetsOperation);
            this.Controls.Add(this.flp_Left);
            this.Controls.Add(this.label_ChoosePC_Info_1);
            this.Controls.Add(this.label_ChoosePC_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Choose_WorkOperation_BrowseProtocols_ManageProcesscards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Välj_ArbetsOperation_Hantering_Processkort_FormClosed);
            this.flp_Left.ResumeLayout(false);
            this.flp_Left.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_ChoosePC_Header;
        private FlowLayoutPanel flp_Left;
        private Label label_Info;
        private Label label_Avdelning;
        private FlowLayoutPanel flp_ArbetsOperation;
        private Label label_ChoosePC_Info_1;
        public TextBox tb_PartNr;
    }
}