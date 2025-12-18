using System.ComponentModel;

namespace DigitalProductionProgram.Templates
{
    partial class PreviewTemplate
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
            tlp_Machines = new TableLayoutPanel();
            panel_LineClearance = new Panel();
            tlp_Main = new TableLayoutPanel();
            tlp_Machines_Compare = new TableLayoutPanel();
            panel_Controls = new Panel();
            cb_RevisionNr = new ComboBox();
            cb_TemplateName = new ComboBox();
            label_RevNr = new Label();
            label_TemplateName = new Label();
            panel_MainInfo = new Panel();
            tlp_Main.SuspendLayout();
            panel_Controls.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Machines
            // 
            tlp_Machines.AutoScroll = true;
            tlp_Machines.BackColor = Color.FromArgb(60, 60, 60);
            tlp_Machines.ColumnCount = 1;
            tlp_Machines.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Machines.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_Machines.Dock = DockStyle.Fill;
            tlp_Machines.Location = new Point(0, 143);
            tlp_Machines.Margin = new Padding(0);
            tlp_Machines.Name = "tlp_Machines";
            tlp_Machines.RowCount = 1;
            tlp_Machines.RowStyles.Add(new RowStyle(SizeType.Absolute, 900F));
            tlp_Machines.RowStyles.Add(new RowStyle(SizeType.Absolute, 900F));
            tlp_Machines.Size = new Size(944, 730);
            tlp_Machines.TabIndex = 0;
            // 
            // panel_LineClearance
            // 
            panel_LineClearance.BackColor = Color.FromArgb(6, 81, 87);
            panel_LineClearance.Dock = DockStyle.Fill;
            panel_LineClearance.Location = new Point(0, 76);
            panel_LineClearance.Margin = new Padding(0, 2, 0, 0);
            panel_LineClearance.Name = "panel_LineClearance";
            panel_LineClearance.Size = new Size(944, 67);
            panel_LineClearance.TabIndex = 1;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Main.Controls.Add(tlp_Machines_Compare, 1, 2);
            tlp_Main.Controls.Add(panel_LineClearance, 0, 1);
            tlp_Main.Controls.Add(tlp_Machines, 0, 2);
            tlp_Main.Controls.Add(panel_Controls, 1, 0);
            tlp_Main.Controls.Add(panel_MainInfo, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1888, 873);
            tlp_Main.TabIndex = 2;
            // 
            // tlp_Machines_Compare
            // 
            tlp_Machines_Compare.AutoScroll = true;
            tlp_Machines_Compare.BackColor = Color.FromArgb(60, 60, 60);
            tlp_Machines_Compare.ColumnCount = 1;
            tlp_Machines_Compare.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Machines_Compare.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_Machines_Compare.Dock = DockStyle.Fill;
            tlp_Machines_Compare.Location = new Point(944, 143);
            tlp_Machines_Compare.Margin = new Padding(0);
            tlp_Machines_Compare.Name = "tlp_Machines_Compare";
            tlp_Machines_Compare.RowCount = 1;
            tlp_Machines_Compare.RowStyles.Add(new RowStyle(SizeType.Absolute, 900F));
            tlp_Machines_Compare.RowStyles.Add(new RowStyle(SizeType.Absolute, 900F));
            tlp_Machines_Compare.Size = new Size(944, 730);
            tlp_Machines_Compare.TabIndex = 3;
            // 
            // panel_Controls
            // 
            panel_Controls.BackColor = Color.FromArgb(6, 81, 87);
            panel_Controls.Controls.Add(cb_RevisionNr);
            panel_Controls.Controls.Add(cb_TemplateName);
            panel_Controls.Controls.Add(label_RevNr);
            panel_Controls.Controls.Add(label_TemplateName);
            panel_Controls.Dock = DockStyle.Fill;
            panel_Controls.Location = new Point(946, 1);
            panel_Controls.Margin = new Padding(2, 1, 0, 0);
            panel_Controls.Name = "panel_Controls";
            panel_Controls.Size = new Size(942, 73);
            panel_Controls.TabIndex = 2;
            // 
            // cb_RevisionNr
            // 
            cb_RevisionNr.Font = new Font("Lucida Sans", 11.25F);
            cb_RevisionNr.FormattingEnabled = true;
            cb_RevisionNr.Location = new Point(414, 37);
            cb_RevisionNr.Margin = new Padding(4, 3, 4, 3);
            cb_RevisionNr.Name = "cb_RevisionNr";
            cb_RevisionNr.Size = new Size(115, 25);
            cb_RevisionNr.TabIndex = 18;
            cb_RevisionNr.SelectedIndexChanged += TemplateName_SelectedIndexChanged;
            // 
            // cb_TemplateName
            // 
            cb_TemplateName.Font = new Font("Lucida Sans", 11.25F);
            cb_TemplateName.FormattingEnabled = true;
            cb_TemplateName.Location = new Point(4, 36);
            cb_TemplateName.Margin = new Padding(4, 3, 4, 3);
            cb_TemplateName.Name = "cb_TemplateName";
            cb_TemplateName.Size = new Size(403, 25);
            cb_TemplateName.TabIndex = 15;
            cb_TemplateName.SelectedIndexChanged += TemplateName_SelectedIndexChanged;
            // 
            // label_RevNr
            // 
            label_RevNr.BackColor = Color.FromArgb(239, 228, 177);
            label_RevNr.Font = new Font("Lucida Sans", 10.25F);
            label_RevNr.ForeColor = Color.FromArgb(57, 108, 121);
            label_RevNr.Location = new Point(414, 7);
            label_RevNr.Margin = new Padding(4, 0, 4, 0);
            label_RevNr.Name = "label_RevNr";
            label_RevNr.Size = new Size(115, 25);
            label_RevNr.TabIndex = 17;
            label_RevNr.Text = "Revisions Nr:";
            // 
            // label_TemplateName
            // 
            label_TemplateName.BackColor = Color.FromArgb(239, 228, 177);
            label_TemplateName.Font = new Font("Lucida Sans", 10.25F);
            label_TemplateName.ForeColor = Color.FromArgb(57, 108, 121);
            label_TemplateName.Location = new Point(4, 7);
            label_TemplateName.Margin = new Padding(4, 0, 4, 0);
            label_TemplateName.Name = "label_TemplateName";
            label_TemplateName.Size = new Size(404, 25);
            label_TemplateName.TabIndex = 16;
            label_TemplateName.Text = "Template Name: ";
            // 
            // panel_MainInfo
            // 
            panel_MainInfo.BackColor = Color.FromArgb(6, 81, 87);
            panel_MainInfo.Dock = DockStyle.Fill;
            panel_MainInfo.Location = new Point(0, 2);
            panel_MainInfo.Margin = new Padding(0, 2, 0, 0);
            panel_MainInfo.Name = "panel_MainInfo";
            panel_MainInfo.Size = new Size(944, 72);
            panel_MainInfo.TabIndex = 1;
            // 
            // PreviewTemplate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1888, 873);
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PreviewTemplate";
            Text = "PreviewTemplate";
            tlp_Main.ResumeLayout(false);
            panel_Controls.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Machines;
        private Panel panel_LineClearance;
        private TableLayoutPanel tlp_Main;
        private Panel panel_Controls;
        private ComboBox cb_TemplateName;
        private Label label_RevNr;
        private Label label_TemplateName;
        private TableLayoutPanel tlp_Machines_Compare;
        private ComboBox cb_RevisionNr;
        private Panel panel_MainInfo;
    }
}