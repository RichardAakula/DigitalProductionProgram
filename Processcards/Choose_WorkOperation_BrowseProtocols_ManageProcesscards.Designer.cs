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
            label_ChoosePC_Header = new Label();
            flp_Left = new FlowLayoutPanel();
            label_Info = new Label();
            tb_PartNr = new TextBox();
            label_Avdelning = new Label();
            flp_ArbetsOperation = new FlowLayoutPanel();
            label_ChoosePC_Info_1 = new Label();
            flp_Left.SuspendLayout();
            SuspendLayout();
            // 
            // label_ChoosePC_Header
            // 
            label_ChoosePC_Header.BackColor = Color.FromArgb(45, 113, 122);
            label_ChoosePC_Header.Dock = DockStyle.Top;
            label_ChoosePC_Header.Font = new Font("Mongolian Baiti", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ChoosePC_Header.ForeColor = Color.White;
            label_ChoosePC_Header.Location = new Point(0, 0);
            label_ChoosePC_Header.Name = "label_ChoosePC_Header";
            label_ChoosePC_Header.Size = new Size(800, 56);
            label_ChoosePC_Header.TabIndex = 0;
            label_ChoosePC_Header.Text = "Hantering av Proceskort";
            label_ChoosePC_Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flp_Left
            // 
            flp_Left.BackColor = Color.FromArgb(6, 81, 87);
            flp_Left.Controls.Add(label_Info);
            flp_Left.Controls.Add(tb_PartNr);
            flp_Left.Controls.Add(label_Avdelning);
            flp_Left.Dock = DockStyle.Left;
            flp_Left.Location = new Point(0, 74);
            flp_Left.Name = "flp_Left";
            flp_Left.Size = new Size(210, 382);
            flp_Left.TabIndex = 1;
            // 
            // label_Info
            // 
            label_Info.AutoSize = true;
            label_Info.BackColor = Color.Transparent;
            label_Info.Font = new Font("Lucida Sans", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Info.ForeColor = Color.FromArgb(184, 220, 231);
            label_Info.Location = new Point(3, 10);
            label_Info.Margin = new Padding(3, 10, 3, 10);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(182, 54);
            label_Info.TabIndex = 1;
            label_Info.Text = "Välj ArtikelNr och programmet väljer Arbetsoperation åt dig.";
            // 
            // tb_PartNr
            // 
            tb_PartNr.BackColor = Color.FromArgb(185, 188, 189);
            tb_PartNr.BorderStyle = BorderStyle.FixedSingle;
            tb_PartNr.Font = new Font("Palatino Linotype", 9.25F);
            tb_PartNr.ForeColor = Color.WhiteSmoke;
            tb_PartNr.Location = new Point(3, 77);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.ReadOnly = true;
            tb_PartNr.Size = new Size(182, 24);
            tb_PartNr.TabIndex = 1011;
            tb_PartNr.Click += PartNr_Click;
            // 
            // label_Avdelning
            // 
            label_Avdelning.AutoSize = true;
            label_Avdelning.Font = new Font("Mongolian Baiti", 11.75F);
            label_Avdelning.Location = new Point(191, 84);
            label_Avdelning.Margin = new Padding(3, 10, 3, 10);
            label_Avdelning.Name = "label_Avdelning";
            label_Avdelning.Size = new Size(0, 16);
            label_Avdelning.TabIndex = 1;
            // 
            // flp_ArbetsOperation
            // 
            flp_ArbetsOperation.BackColor = Color.FromArgb(81, 85, 92);
            flp_ArbetsOperation.Dock = DockStyle.Fill;
            flp_ArbetsOperation.FlowDirection = FlowDirection.TopDown;
            flp_ArbetsOperation.Location = new Point(210, 74);
            flp_ArbetsOperation.Margin = new Padding(15, 3, 3, 3);
            flp_ArbetsOperation.MaximumSize = new Size(590, 380);
            flp_ArbetsOperation.Name = "flp_ArbetsOperation";
            flp_ArbetsOperation.Size = new Size(590, 380);
            flp_ArbetsOperation.TabIndex = 2;
            // 
            // label_ChoosePC_Info_1
            // 
            label_ChoosePC_Info_1.BackColor = Color.FromArgb(45, 113, 122);
            label_ChoosePC_Info_1.Dock = DockStyle.Top;
            label_ChoosePC_Info_1.Font = new Font("Mongolian Baiti", 12.75F);
            label_ChoosePC_Info_1.ForeColor = Color.White;
            label_ChoosePC_Info_1.Location = new Point(0, 56);
            label_ChoosePC_Info_1.Margin = new Padding(3, 10, 3, 5);
            label_ChoosePC_Info_1.Name = "label_ChoosePC_Info_1";
            label_ChoosePC_Info_1.Padding = new Padding(240, 0, 0, 0);
            label_ChoosePC_Info_1.Size = new Size(800, 18);
            label_ChoosePC_Info_1.TabIndex = 1;
            label_ChoosePC_Info_1.Text = "Här nedan kan du klicka på den arbetsoperation du vill gå till.";
            // 
            // Choose_WorkOperation_BrowseProtocols_ManageProcesscards
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 113, 122);
            ClientSize = new Size(800, 456);
            Controls.Add(flp_ArbetsOperation);
            Controls.Add(flp_Left);
            Controls.Add(label_ChoosePC_Info_1);
            Controls.Add(label_ChoosePC_Header);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Choose_WorkOperation_BrowseProtocols_ManageProcesscards";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += Välj_ArbetsOperation_Hantering_Processkort_FormClosed;
            flp_Left.ResumeLayout(false);
            flp_Left.PerformLayout();
            ResumeLayout(false);

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