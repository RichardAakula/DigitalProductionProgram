using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    partial class Skärmning_TEF
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
            tlp_Main = new TableLayoutPanel();
            ProcesskortBaserat_På = new ProcesscardBasedOn();
            MainProtocol = new MainProtocol_Skärmning_TEF();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1294F));
            tlp_Main.Controls.Add(ProcesskortBaserat_På, 0, 1);
            tlp_Main.Controls.Add(MainProtocol, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(1);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 916F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlp_Main.Size = new Size(1294, 1029);
            tlp_Main.TabIndex = 0;
            // 
            // ProcesskortBaserat_På
            // 
            ProcesskortBaserat_På.BackColor = Color.Black;
            ProcesskortBaserat_På.Dock = DockStyle.Fill;
            ProcesskortBaserat_På.Location = new Point(0, 917);
            ProcesskortBaserat_På.Margin = new Padding(0, 1, 0, 0);
            ProcesskortBaserat_På.Name = "ProcesskortBaserat_På";
            ProcesskortBaserat_På.Size = new Size(1294, 112);
            ProcesskortBaserat_På.TabIndex = 1033;
            // 
            // MainProtocol
            // 
            MainProtocol.Location = new Point(0, 0);
            MainProtocol.Margin = new Padding(0);
            MainProtocol.Name = "MainProtocol";
            MainProtocol.Size = new Size(1294, 916);
            MainProtocol.TabIndex = 1034;
            // 
            // Skärmning_TEF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateBlue;
            ClientSize = new Size(1294, 1029);
            Controls.Add(tlp_Main);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Skärmning_TEF";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Processkort/Körprotokoll Skärmning TEF";
            FormClosing += Skärmning_FormClosing;
            tlp_Main.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public MainProtocol_Skärmning_TEF MainProtocol;
        private ProcesscardBasedOn ProcesskortBaserat_På;
    }
}