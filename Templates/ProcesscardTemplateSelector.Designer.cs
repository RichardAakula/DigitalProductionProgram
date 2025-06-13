using System.ComponentModel;

namespace DigitalProductionProgram.Templates
{
    partial class ProcesscardTemplateSelector
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
            label_Header = new Label();
            flp_Buttons = new FlowLayoutPanel();
            label_Green = new Label();
            label_Orange = new Label();
            label_Brown = new Label();
            label_Red = new Label();
            tlp_InfoLabels = new TableLayoutPanel();
            tlp_InfoLabels.SuspendLayout();
            SuspendLayout();
            // 
            // label_Header
            // 
            label_Header.BackColor = Color.FromArgb(45, 113, 122);
            label_Header.Dock = DockStyle.Top;
            label_Header.Font = new Font("Lucida Sans", 11.25F);
            label_Header.ForeColor = Color.FromArgb(239, 228, 177);
            label_Header.Location = new Point(0, 0);
            label_Header.Margin = new Padding(4, 0, 4, 0);
            label_Header.Name = "label_Header";
            label_Header.Size = new Size(784, 60);
            label_Header.TabIndex = 2;
            label_Header.Text = "Header:";
            // 
            // flp_Buttons
            // 
            flp_Buttons.BackColor = Color.FromArgb(45, 113, 122);
            flp_Buttons.Dock = DockStyle.Fill;
            flp_Buttons.FlowDirection = FlowDirection.TopDown;
            flp_Buttons.Location = new Point(0, 162);
            flp_Buttons.Margin = new Padding(4, 3, 4, 3);
            flp_Buttons.Name = "flp_Buttons";
            flp_Buttons.Padding = new Padding(0, 6, 0, 0);
            flp_Buttons.Size = new Size(784, 139);
            flp_Buttons.TabIndex = 16;
            // 
            // label_Green
            // 
            label_Green.AutoSize = true;
            label_Green.BackColor = Color.FromArgb(198, 239, 206);
            label_Green.Dock = DockStyle.Fill;
            label_Green.Font = new Font("Segoe UI", 10.25F);
            label_Green.ForeColor = Color.FromArgb(0, 97, 0);
            label_Green.Location = new Point(4, 0);
            label_Green.Margin = new Padding(4, 0, 4, 0);
            label_Green.Name = "label_Green";
            label_Green.Size = new Size(776, 25);
            label_Green.TabIndex = 2;
            label_Green.Text = "Order Ok att starta";
            // 
            // label_Orange
            // 
            label_Orange.AutoSize = true;
            label_Orange.BackColor = Color.DarkOrange;
            label_Orange.Dock = DockStyle.Fill;
            label_Orange.Font = new Font("Segoe UI", 10.25F);
            label_Orange.ForeColor = Color.Brown;
            label_Orange.Location = new Point(4, 25);
            label_Orange.Margin = new Padding(4, 0, 4, 0);
            label_Orange.Name = "label_Orange";
            label_Orange.Size = new Size(776, 25);
            label_Orange.TabIndex = 14;
            label_Orange.Text = "ArtikelNr utan processkort körd fler än 3 ggr - Processkort behövs - Kontakta arbetsledare";
            // 
            // label_Brown
            // 
            label_Brown.AutoSize = true;
            label_Brown.BackColor = Color.Brown;
            label_Brown.Dock = DockStyle.Fill;
            label_Brown.Font = new Font("Segoe UI", 10.25F);
            label_Brown.ForeColor = Color.DarkOrange;
            label_Brown.Location = new Point(4, 50);
            label_Brown.Margin = new Padding(4, 0, 4, 0);
            label_Brown.Name = "label_Brown";
            label_Brown.Size = new Size(776, 25);
            label_Brown.TabIndex = 13;
            label_Brown.Text = "Processkort under framarbetning och körd fler än 3 gånger - Kontakta arbetsledare";
            // 
            // label_Red
            // 
            label_Red.AutoSize = true;
            label_Red.BackColor = Color.FromArgb(255, 199, 206);
            label_Red.Dock = DockStyle.Fill;
            label_Red.Font = new Font("Segoe UI", 10.25F);
            label_Red.ForeColor = Color.FromArgb(156, 0, 6);
            label_Red.Location = new Point(4, 75);
            label_Red.Margin = new Padding(4, 0, 4, 0);
            label_Red.Name = "label_Red";
            label_Red.Size = new Size(776, 27);
            label_Red.TabIndex = 2;
            label_Red.Text = "Ej godkänd av QA";
            // 
            // tlp_InfoLabels
            // 
            tlp_InfoLabels.ColumnCount = 1;
            tlp_InfoLabels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_InfoLabels.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_InfoLabels.Controls.Add(label_Red, 0, 3);
            tlp_InfoLabels.Controls.Add(label_Brown, 0, 2);
            tlp_InfoLabels.Controls.Add(label_Orange, 0, 1);
            tlp_InfoLabels.Controls.Add(label_Green, 0, 0);
            tlp_InfoLabels.Dock = DockStyle.Top;
            tlp_InfoLabels.Location = new Point(0, 60);
            tlp_InfoLabels.Margin = new Padding(4, 3, 4, 3);
            tlp_InfoLabels.Name = "tlp_InfoLabels";
            tlp_InfoLabels.RowCount = 4;
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_InfoLabels.Size = new Size(784, 102);
            tlp_InfoLabels.TabIndex = 0;
            // 
            // ProcesscardTemplateSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(45, 113, 122);
            ClientSize = new Size(784, 301);
            Controls.Add(flp_Buttons);
            Controls.Add(tlp_InfoLabels);
            Controls.Add(label_Header);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProcesscardTemplateSelector";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ChooseProcesscard_FormClosing;
            Load += ProcesscardTemplateSelector_Load;
            Shown += ProcesscardTemplateSelector_Shown;
            tlp_InfoLabels.ResumeLayout(false);
            tlp_InfoLabels.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private Label label_Header;
        private FlowLayoutPanel flp_Buttons;
        private Label label_Green;
        private Label label_Orange;
        private Label label_Brown;
        private Label label_Red;
        private TableLayoutPanel tlp_InfoLabels;
    }
}