using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Template_Management
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
            this.tlp_Machines = new System.Windows.Forms.TableLayoutPanel();
            this.panel_LineClearance = new System.Windows.Forms.Panel();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Machines_Compare = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Controls = new System.Windows.Forms.Panel();
            this.cb_RevisionNr = new System.Windows.Forms.ComboBox();
            this.cb_TemplateName = new System.Windows.Forms.ComboBox();
            this.label_RevNr = new System.Windows.Forms.Label();
            this.label_TemplateName = new System.Windows.Forms.Label();
            this.panel_MainInfo = new System.Windows.Forms.Panel();
            this.tlp_Main.SuspendLayout();
            this.panel_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Machines
            // 
            this.tlp_Machines.AutoScroll = true;
            this.tlp_Machines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlp_Machines.ColumnCount = 1;
            this.tlp_Machines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Machines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Machines.Location = new System.Drawing.Point(0, 124);
            this.tlp_Machines.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Machines.Name = "tlp_Machines";
            this.tlp_Machines.RowCount = 1;
            this.tlp_Machines.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 780F));
            this.tlp_Machines.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 780F));
            this.tlp_Machines.Size = new System.Drawing.Size(809, 633);
            this.tlp_Machines.TabIndex = 0;
            // 
            // panel_LineClearance
            // 
            this.panel_LineClearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.panel_LineClearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_LineClearance.Location = new System.Drawing.Point(0, 66);
            this.panel_LineClearance.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel_LineClearance.Name = "panel_LineClearance";
            this.panel_LineClearance.Size = new System.Drawing.Size(809, 58);
            this.panel_LineClearance.TabIndex = 1;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.tlp_Machines_Compare, 1, 2);
            this.tlp_Main.Controls.Add(this.panel_LineClearance, 0, 1);
            this.tlp_Main.Controls.Add(this.tlp_Machines, 0, 2);
            this.tlp_Main.Controls.Add(this.panel_Controls, 1, 0);
            this.tlp_Main.Controls.Add(this.panel_MainInfo, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(1618, 757);
            this.tlp_Main.TabIndex = 2;
            // 
            // tlp_Machines_Compare
            // 
            this.tlp_Machines_Compare.AutoScroll = true;
            this.tlp_Machines_Compare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlp_Machines_Compare.ColumnCount = 1;
            this.tlp_Machines_Compare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machines_Compare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Machines_Compare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Machines_Compare.Location = new System.Drawing.Point(809, 124);
            this.tlp_Machines_Compare.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Machines_Compare.Name = "tlp_Machines_Compare";
            this.tlp_Machines_Compare.RowCount = 1;
            this.tlp_Machines_Compare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 780F));
            this.tlp_Machines_Compare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 780F));
            this.tlp_Machines_Compare.Size = new System.Drawing.Size(809, 633);
            this.tlp_Machines_Compare.TabIndex = 3;
            // 
            // panel_Controls
            // 
            this.panel_Controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.panel_Controls.Controls.Add(this.cb_RevisionNr);
            this.panel_Controls.Controls.Add(this.cb_TemplateName);
            this.panel_Controls.Controls.Add(this.label_RevNr);
            this.panel_Controls.Controls.Add(this.label_TemplateName);
            this.panel_Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Controls.Location = new System.Drawing.Point(811, 1);
            this.panel_Controls.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.panel_Controls.Name = "panel_Controls";
            this.panel_Controls.Size = new System.Drawing.Size(807, 63);
            this.panel_Controls.TabIndex = 2;
            // 
            // cb_RevisionNr
            // 
            this.cb_RevisionNr.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_RevisionNr.FormattingEnabled = true;
            this.cb_RevisionNr.Location = new System.Drawing.Point(355, 32);
            this.cb_RevisionNr.Name = "cb_RevisionNr";
            this.cb_RevisionNr.Size = new System.Drawing.Size(99, 25);
            this.cb_RevisionNr.TabIndex = 18;
            this.cb_RevisionNr.SelectedIndexChanged += new System.EventHandler(this.TemplateName_SelectedIndexChanged);
            // 
            // cb_TemplateName
            // 
            this.cb_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_TemplateName.FormattingEnabled = true;
            this.cb_TemplateName.Location = new System.Drawing.Point(3, 31);
            this.cb_TemplateName.Name = "cb_TemplateName";
            this.cb_TemplateName.Size = new System.Drawing.Size(346, 25);
            this.cb_TemplateName.TabIndex = 15;
            this.cb_TemplateName.SelectedIndexChanged += new System.EventHandler(this.TemplateName_SelectedIndexChanged);
            // 
            // label_RevNr
            // 
            this.label_RevNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_RevNr.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_RevNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_RevNr.Location = new System.Drawing.Point(355, 6);
            this.label_RevNr.Name = "label_RevNr";
            this.label_RevNr.Size = new System.Drawing.Size(99, 22);
            this.label_RevNr.TabIndex = 17;
            this.label_RevNr.Text = "Revisions Nr:";
            // 
            // label_TemplateName
            // 
            this.label_TemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_TemplateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_TemplateName.Location = new System.Drawing.Point(3, 6);
            this.label_TemplateName.Name = "label_TemplateName";
            this.label_TemplateName.Size = new System.Drawing.Size(346, 22);
            this.label_TemplateName.TabIndex = 16;
            this.label_TemplateName.Text = "Template Name: ";
            // 
            // panel_MainInfo
            // 
            this.panel_MainInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.panel_MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MainInfo.Location = new System.Drawing.Point(0, 2);
            this.panel_MainInfo.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel_MainInfo.Name = "panel_MainInfo";
            this.panel_MainInfo.Size = new System.Drawing.Size(809, 62);
            this.panel_MainInfo.TabIndex = 1;
            // 
            // PreviewTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1618, 757);
            this.Controls.Add(this.tlp_Main);
            this.Name = "PreviewTemplate";
            this.Opacity = 0.95D;
            this.Text = "PreviewTemplate";
            this.tlp_Main.ResumeLayout(false);
            this.panel_Controls.ResumeLayout(false);
            this.ResumeLayout(false);

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