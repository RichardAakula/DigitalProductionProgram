
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    partial class PC_Skärmning
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ODs_nom = new System.Windows.Forms.TextBox();
            this.tb_OD1_nom = new System.Windows.Forms.TextBox();
            this.tb_Temp_nom = new System.Windows.Forms.TextBox();
            this.tb_ID_nom = new System.Windows.Forms.TextBox();
            this.tb_Verktyg_ID_nom = new System.Windows.Forms.TextBox();
            this.tb_OD1_min = new System.Windows.Forms.TextBox();
            this.tb_OD1_max = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Skärmning_Temp = new System.Windows.Forms.Label();
            this.label_Skärmning_Verktyg_ID = new System.Windows.Forms.Label();
            this.label_Skärmning_Verktyg_ID_enhet = new System.Windows.Forms.Label();
            this.label_Skärmning_Temp_enhet = new System.Windows.Forms.Label();
            this.label_Skärmning_ID = new System.Windows.Forms.Label();
            this.label_Skärmning_ID_enhet = new System.Windows.Forms.Label();
            this.label_Skärmning_MIN = new System.Windows.Forms.Label();
            this.label_Skärmning_NOM = new System.Windows.Forms.Label();
            this.label_Skärmning_MAX = new System.Windows.Forms.Label();
            this.label_Skärmning_OD1 = new System.Windows.Forms.Label();
            this.label_Skärmning_ODs_enhet = new System.Windows.Forms.Label();
            this.label_Skärmning_OD1_enhet = new System.Windows.Forms.Label();
            this.label_Skärmning_ODs = new System.Windows.Forms.Label();
            this.tb_ODs_min = new System.Windows.Forms.TextBox();
            this.tb_ODs_max = new System.Windows.Forms.TextBox();
            this.tb_Temp_min = new System.Windows.Forms.TextBox();
            this.tb_Temp_max = new System.Windows.Forms.TextBox();
            this.tb_ID_min = new System.Windows.Forms.TextBox();
            this.tb_ID_max = new System.Windows.Forms.TextBox();
            this.tb_Verktyg_ID_min = new System.Windows.Forms.TextBox();
            this.tb_Verktyg_ID_max = new System.Windows.Forms.TextBox();
            this.label_Skärmning_Antal_Trådar = new System.Windows.Forms.Label();
            this.label_Skärmning_Pot_Maskin_Hastighet = new System.Windows.Forms.Label();
            this.label_Skärmning_Carrier_Fjäder = new System.Windows.Forms.Label();
            this.label_Skärmning_PPI = new System.Windows.Forms.Label();
            this.tb_Antal_Trådar_nom = new System.Windows.Forms.TextBox();
            this.tb_Pot_Maskin_Hastighet_nom = new System.Windows.Forms.TextBox();
            this.tb_Carrier_fjäder_nom = new System.Windows.Forms.TextBox();
            this.tb_PPI_nom = new System.Windows.Forms.TextBox();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 6;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlp_Main.Controls.Add(this.label3, 0, 1);
            this.tlp_Main.Controls.Add(this.tb_ODs_nom, 5, 5);
            this.tlp_Main.Controls.Add(this.tb_OD1_nom, 4, 5);
            this.tlp_Main.Controls.Add(this.tb_Temp_nom, 2, 5);
            this.tlp_Main.Controls.Add(this.tb_ID_nom, 3, 5);
            this.tlp_Main.Controls.Add(this.tb_Verktyg_ID_nom, 1, 5);
            this.tlp_Main.Controls.Add(this.tb_OD1_min, 4, 4);
            this.tlp_Main.Controls.Add(this.tb_OD1_max, 4, 6);
            this.tlp_Main.Controls.Add(this.label4, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Temp, 2, 1);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Verktyg_ID, 1, 1);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Verktyg_ID_enhet, 1, 3);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Temp_enhet, 2, 3);
            this.tlp_Main.Controls.Add(this.label_Skärmning_ID, 3, 1);
            this.tlp_Main.Controls.Add(this.label_Skärmning_ID_enhet, 3, 3);
            this.tlp_Main.Controls.Add(this.label_Skärmning_MIN, 0, 4);
            this.tlp_Main.Controls.Add(this.label_Skärmning_NOM, 0, 5);
            this.tlp_Main.Controls.Add(this.label_Skärmning_MAX, 0, 6);
            this.tlp_Main.Controls.Add(this.label_Skärmning_OD1, 4, 1);
            this.tlp_Main.Controls.Add(this.label_Skärmning_ODs_enhet, 5, 3);
            this.tlp_Main.Controls.Add(this.label_Skärmning_OD1_enhet, 4, 3);
            this.tlp_Main.Controls.Add(this.label_Skärmning_ODs, 5, 1);
            this.tlp_Main.Controls.Add(this.tb_ODs_min, 5, 4);
            this.tlp_Main.Controls.Add(this.tb_ODs_max, 5, 6);
            this.tlp_Main.Controls.Add(this.tb_Temp_min, 2, 4);
            this.tlp_Main.Controls.Add(this.tb_Temp_max, 2, 6);
            this.tlp_Main.Controls.Add(this.tb_ID_min, 3, 4);
            this.tlp_Main.Controls.Add(this.tb_ID_max, 3, 6);
            this.tlp_Main.Controls.Add(this.tb_Verktyg_ID_min, 1, 4);
            this.tlp_Main.Controls.Add(this.tb_Verktyg_ID_max, 1, 6);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Antal_Trådar, 0, 7);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Pot_Maskin_Hastighet, 0, 8);
            this.tlp_Main.Controls.Add(this.label_Skärmning_Carrier_Fjäder, 0, 9);
            this.tlp_Main.Controls.Add(this.label_Skärmning_PPI, 0, 10);
            this.tlp_Main.Controls.Add(this.tb_Antal_Trådar_nom, 3, 7);
            this.tlp_Main.Controls.Add(this.tb_Pot_Maskin_Hastighet_nom, 3, 8);
            this.tlp_Main.Controls.Add(this.tb_Carrier_fjäder_nom, 3, 9);
            this.tlp_Main.Controls.Add(this.tb_PPI_nom, 3, 10);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 12;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(304, 207);
            this.tlp_Main.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Arial", 8F);
            this.label3.Location = new System.Drawing.Point(1, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label3.Name = "label3";
            this.tlp_Main.SetRowSpan(this.label3, 3);
            this.label3.Size = new System.Drawing.Size(33, 52);
            this.label3.TabIndex = 1029;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_ODs_nom
            // 
            this.tb_ODs_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_ODs_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ODs_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ODs_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_ODs_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_ODs_nom.Location = new System.Drawing.Point(242, 94);
            this.tb_ODs_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tb_ODs_nom.MaxLength = 5;
            this.tb_ODs_nom.Multiline = true;
            this.tb_ODs_nom.Name = "tb_ODs_nom";
            this.tb_ODs_nom.Size = new System.Drawing.Size(61, 17);
            this.tb_ODs_nom.TabIndex = 14;
            this.tb_ODs_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ODs_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_OD1_nom
            // 
            this.tb_OD1_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_OD1_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_OD1_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_OD1_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_OD1_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_OD1_nom.Location = new System.Drawing.Point(192, 94);
            this.tb_OD1_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_OD1_nom.MaxLength = 5;
            this.tb_OD1_nom.Multiline = true;
            this.tb_OD1_nom.Name = "tb_OD1_nom";
            this.tb_OD1_nom.Size = new System.Drawing.Size(49, 17);
            this.tb_OD1_nom.TabIndex = 11;
            this.tb_OD1_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_OD1_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Temp_nom
            // 
            this.tb_Temp_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Temp_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temp_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Temp_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Temp_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Temp_nom.Location = new System.Drawing.Point(97, 94);
            this.tb_Temp_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Temp_nom.MaxLength = 3;
            this.tb_Temp_nom.Multiline = true;
            this.tb_Temp_nom.Name = "tb_Temp_nom";
            this.tb_Temp_nom.Size = new System.Drawing.Size(44, 17);
            this.tb_Temp_nom.TabIndex = 4;
            this.tb_Temp_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Temp_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_ID_nom
            // 
            this.tb_ID_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_ID_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ID_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ID_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_ID_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_ID_nom.Location = new System.Drawing.Point(142, 94);
            this.tb_ID_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_ID_nom.MaxLength = 5;
            this.tb_ID_nom.Multiline = true;
            this.tb_ID_nom.Name = "tb_ID_nom";
            this.tb_ID_nom.Size = new System.Drawing.Size(49, 17);
            this.tb_ID_nom.TabIndex = 8;
            this.tb_ID_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ID_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Verktyg_ID_nom
            // 
            this.tb_Verktyg_ID_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Verktyg_ID_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Verktyg_ID_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Verktyg_ID_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Verktyg_ID_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Verktyg_ID_nom.Location = new System.Drawing.Point(35, 94);
            this.tb_Verktyg_ID_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Verktyg_ID_nom.MaxLength = 5;
            this.tb_Verktyg_ID_nom.Multiline = true;
            this.tb_Verktyg_ID_nom.Name = "tb_Verktyg_ID_nom";
            this.tb_Verktyg_ID_nom.Size = new System.Drawing.Size(61, 17);
            this.tb_Verktyg_ID_nom.TabIndex = 1;
            this.tb_Verktyg_ID_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Verktyg_ID_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_OD1_min
            // 
            this.tb_OD1_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_OD1_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_OD1_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_OD1_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_OD1_min.ForeColor = System.Drawing.Color.Black;
            this.tb_OD1_min.Location = new System.Drawing.Point(192, 76);
            this.tb_OD1_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_OD1_min.MaxLength = 5;
            this.tb_OD1_min.Multiline = true;
            this.tb_OD1_min.Name = "tb_OD1_min";
            this.tb_OD1_min.Size = new System.Drawing.Size(49, 17);
            this.tb_OD1_min.TabIndex = 10;
            this.tb_OD1_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_OD1_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_OD1_max
            // 
            this.tb_OD1_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_OD1_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_OD1_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_OD1_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_OD1_max.ForeColor = System.Drawing.Color.Black;
            this.tb_OD1_max.Location = new System.Drawing.Point(192, 112);
            this.tb_OD1_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_OD1_max.MaxLength = 5;
            this.tb_OD1_max.Multiline = true;
            this.tb_OD1_max.Name = "tb_OD1_max";
            this.tb_OD1_max.Size = new System.Drawing.Size(49, 17);
            this.tb_OD1_max.TabIndex = 12;
            this.tb_OD1_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_OD1_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tlp_Main.SetColumnSpan(this.label4, 6);
            this.label4.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(1, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 20);
            this.label4.TabIndex = 933;
            this.label4.Text = "Maskinparametrar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Skärmning_Temp
            // 
            this.label_Skärmning_Temp.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Temp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Temp.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Temp.Location = new System.Drawing.Point(97, 23);
            this.label_Skärmning_Temp.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Skärmning_Temp.Name = "label_Skärmning_Temp";
            this.tlp_Main.SetRowSpan(this.label_Skärmning_Temp, 2);
            this.label_Skärmning_Temp.Size = new System.Drawing.Size(44, 38);
            this.label_Skärmning_Temp.TabIndex = 937;
            this.label_Skärmning_Temp.Text = "Temp.";
            this.label_Skärmning_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_Verktyg_ID
            // 
            this.label_Skärmning_Verktyg_ID.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_Verktyg_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Verktyg_ID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Verktyg_ID.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Verktyg_ID.Location = new System.Drawing.Point(35, 23);
            this.label_Skärmning_Verktyg_ID.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Skärmning_Verktyg_ID.Name = "label_Skärmning_Verktyg_ID";
            this.tlp_Main.SetRowSpan(this.label_Skärmning_Verktyg_ID, 2);
            this.label_Skärmning_Verktyg_ID.Size = new System.Drawing.Size(61, 38);
            this.label_Skärmning_Verktyg_ID.TabIndex = 936;
            this.label_Skärmning_Verktyg_ID.Text = "Verktyg ID";
            this.label_Skärmning_Verktyg_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_Verktyg_ID_enhet
            // 
            this.label_Skärmning_Verktyg_ID_enhet.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_Verktyg_ID_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Verktyg_ID_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Verktyg_ID_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Verktyg_ID_enhet.Location = new System.Drawing.Point(35, 61);
            this.label_Skärmning_Verktyg_ID_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_Verktyg_ID_enhet.Name = "label_Skärmning_Verktyg_ID_enhet";
            this.label_Skärmning_Verktyg_ID_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Skärmning_Verktyg_ID_enhet.Size = new System.Drawing.Size(61, 14);
            this.label_Skärmning_Verktyg_ID_enhet.TabIndex = 939;
            this.label_Skärmning_Verktyg_ID_enhet.Text = "mm";
            this.label_Skärmning_Verktyg_ID_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_Temp_enhet
            // 
            this.label_Skärmning_Temp_enhet.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_Temp_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Temp_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Temp_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Temp_enhet.Location = new System.Drawing.Point(97, 61);
            this.label_Skärmning_Temp_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_Temp_enhet.Name = "label_Skärmning_Temp_enhet";
            this.label_Skärmning_Temp_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Skärmning_Temp_enhet.Size = new System.Drawing.Size(44, 14);
            this.label_Skärmning_Temp_enhet.TabIndex = 940;
            this.label_Skärmning_Temp_enhet.Text = "ºC";
            this.label_Skärmning_Temp_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_ID
            // 
            this.label_Skärmning_ID.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_ID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_ID.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_ID.Location = new System.Drawing.Point(142, 23);
            this.label_Skärmning_ID.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Skärmning_ID.Name = "label_Skärmning_ID";
            this.tlp_Main.SetRowSpan(this.label_Skärmning_ID, 2);
            this.label_Skärmning_ID.Size = new System.Drawing.Size(49, 38);
            this.label_Skärmning_ID.TabIndex = 938;
            this.label_Skärmning_ID.Text = "ID";
            this.label_Skärmning_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_ID_enhet
            // 
            this.label_Skärmning_ID_enhet.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_ID_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_ID_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_ID_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_ID_enhet.Location = new System.Drawing.Point(142, 61);
            this.label_Skärmning_ID_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_ID_enhet.Name = "label_Skärmning_ID_enhet";
            this.label_Skärmning_ID_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Skärmning_ID_enhet.Size = new System.Drawing.Size(49, 14);
            this.label_Skärmning_ID_enhet.TabIndex = 941;
            this.label_Skärmning_ID_enhet.Text = "mm";
            this.label_Skärmning_ID_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_MIN
            // 
            this.label_Skärmning_MIN.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_MIN.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_Skärmning_MIN.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Skärmning_MIN.Location = new System.Drawing.Point(1, 76);
            this.label_Skärmning_MIN.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_MIN.Name = "label_Skärmning_MIN";
            this.label_Skärmning_MIN.Size = new System.Drawing.Size(33, 17);
            this.label_Skärmning_MIN.TabIndex = 942;
            this.label_Skärmning_MIN.Text = "MIN";
            this.label_Skärmning_MIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_NOM
            // 
            this.label_Skärmning_NOM.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_NOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_NOM.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_Skärmning_NOM.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Skärmning_NOM.Location = new System.Drawing.Point(1, 94);
            this.label_Skärmning_NOM.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_NOM.Name = "label_Skärmning_NOM";
            this.label_Skärmning_NOM.Size = new System.Drawing.Size(33, 17);
            this.label_Skärmning_NOM.TabIndex = 943;
            this.label_Skärmning_NOM.Text = "NOM";
            this.label_Skärmning_NOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_MAX
            // 
            this.label_Skärmning_MAX.AutoSize = true;
            this.label_Skärmning_MAX.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_MAX.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_Skärmning_MAX.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Skärmning_MAX.Location = new System.Drawing.Point(1, 112);
            this.label_Skärmning_MAX.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_MAX.Name = "label_Skärmning_MAX";
            this.label_Skärmning_MAX.Size = new System.Drawing.Size(33, 17);
            this.label_Skärmning_MAX.TabIndex = 944;
            this.label_Skärmning_MAX.Text = "MAX";
            this.label_Skärmning_MAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_OD1
            // 
            this.label_Skärmning_OD1.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_OD1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_OD1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_OD1.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_OD1.Location = new System.Drawing.Point(192, 23);
            this.label_Skärmning_OD1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Skärmning_OD1.Name = "label_Skärmning_OD1";
            this.tlp_Main.SetRowSpan(this.label_Skärmning_OD1, 2);
            this.label_Skärmning_OD1.Size = new System.Drawing.Size(49, 38);
            this.label_Skärmning_OD1.TabIndex = 997;
            this.label_Skärmning_OD1.Text = "OD1";
            this.label_Skärmning_OD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_ODs_enhet
            // 
            this.label_Skärmning_ODs_enhet.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_ODs_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_ODs_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_ODs_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_ODs_enhet.Location = new System.Drawing.Point(242, 61);
            this.label_Skärmning_ODs_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Skärmning_ODs_enhet.Name = "label_Skärmning_ODs_enhet";
            this.label_Skärmning_ODs_enhet.Size = new System.Drawing.Size(61, 14);
            this.label_Skärmning_ODs_enhet.TabIndex = 1000;
            this.label_Skärmning_ODs_enhet.Text = "mm";
            this.label_Skärmning_ODs_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_OD1_enhet
            // 
            this.label_Skärmning_OD1_enhet.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_OD1_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_OD1_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_OD1_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_OD1_enhet.Location = new System.Drawing.Point(192, 61);
            this.label_Skärmning_OD1_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Skärmning_OD1_enhet.Name = "label_Skärmning_OD1_enhet";
            this.label_Skärmning_OD1_enhet.Size = new System.Drawing.Size(49, 14);
            this.label_Skärmning_OD1_enhet.TabIndex = 1001;
            this.label_Skärmning_OD1_enhet.Text = "mm";
            this.label_Skärmning_OD1_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Skärmning_ODs
            // 
            this.label_Skärmning_ODs.BackColor = System.Drawing.Color.White;
            this.label_Skärmning_ODs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_ODs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_ODs.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_ODs.Location = new System.Drawing.Point(242, 23);
            this.label_Skärmning_ODs.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Skärmning_ODs.Name = "label_Skärmning_ODs";
            this.tlp_Main.SetRowSpan(this.label_Skärmning_ODs, 2);
            this.label_Skärmning_ODs.Size = new System.Drawing.Size(61, 38);
            this.label_Skärmning_ODs.TabIndex = 998;
            this.label_Skärmning_ODs.Text = "ODs";
            this.label_Skärmning_ODs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_ODs_min
            // 
            this.tb_ODs_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_ODs_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ODs_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ODs_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_ODs_min.ForeColor = System.Drawing.Color.Black;
            this.tb_ODs_min.Location = new System.Drawing.Point(242, 76);
            this.tb_ODs_min.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tb_ODs_min.MaxLength = 5;
            this.tb_ODs_min.Multiline = true;
            this.tb_ODs_min.Name = "tb_ODs_min";
            this.tb_ODs_min.Size = new System.Drawing.Size(61, 17);
            this.tb_ODs_min.TabIndex = 13;
            this.tb_ODs_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ODs_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_ODs_max
            // 
            this.tb_ODs_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_ODs_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ODs_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ODs_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_ODs_max.ForeColor = System.Drawing.Color.Black;
            this.tb_ODs_max.Location = new System.Drawing.Point(242, 112);
            this.tb_ODs_max.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tb_ODs_max.MaxLength = 5;
            this.tb_ODs_max.Multiline = true;
            this.tb_ODs_max.Name = "tb_ODs_max";
            this.tb_ODs_max.Size = new System.Drawing.Size(61, 17);
            this.tb_ODs_max.TabIndex = 15;
            this.tb_ODs_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ODs_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Temp_min
            // 
            this.tb_Temp_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Temp_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temp_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Temp_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Temp_min.ForeColor = System.Drawing.Color.Black;
            this.tb_Temp_min.Location = new System.Drawing.Point(97, 76);
            this.tb_Temp_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Temp_min.MaxLength = 3;
            this.tb_Temp_min.Multiline = true;
            this.tb_Temp_min.Name = "tb_Temp_min";
            this.tb_Temp_min.Size = new System.Drawing.Size(44, 17);
            this.tb_Temp_min.TabIndex = 3;
            this.tb_Temp_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Temp_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Temp_max
            // 
            this.tb_Temp_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Temp_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temp_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Temp_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Temp_max.ForeColor = System.Drawing.Color.Black;
            this.tb_Temp_max.Location = new System.Drawing.Point(97, 112);
            this.tb_Temp_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Temp_max.MaxLength = 3;
            this.tb_Temp_max.Multiline = true;
            this.tb_Temp_max.Name = "tb_Temp_max";
            this.tb_Temp_max.Size = new System.Drawing.Size(44, 17);
            this.tb_Temp_max.TabIndex = 5;
            this.tb_Temp_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Temp_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_ID_min
            // 
            this.tb_ID_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_ID_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ID_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ID_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_ID_min.ForeColor = System.Drawing.Color.Black;
            this.tb_ID_min.Location = new System.Drawing.Point(142, 76);
            this.tb_ID_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_ID_min.MaxLength = 5;
            this.tb_ID_min.Multiline = true;
            this.tb_ID_min.Name = "tb_ID_min";
            this.tb_ID_min.Size = new System.Drawing.Size(49, 17);
            this.tb_ID_min.TabIndex = 7;
            this.tb_ID_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ID_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_ID_max
            // 
            this.tb_ID_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_ID_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ID_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ID_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_ID_max.ForeColor = System.Drawing.Color.Black;
            this.tb_ID_max.Location = new System.Drawing.Point(142, 112);
            this.tb_ID_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_ID_max.MaxLength = 5;
            this.tb_ID_max.Multiline = true;
            this.tb_ID_max.Name = "tb_ID_max";
            this.tb_ID_max.Size = new System.Drawing.Size(49, 17);
            this.tb_ID_max.TabIndex = 9;
            this.tb_ID_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ID_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Verktyg_ID_min
            // 
            this.tb_Verktyg_ID_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Verktyg_ID_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Verktyg_ID_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Verktyg_ID_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Verktyg_ID_min.ForeColor = System.Drawing.Color.Black;
            this.tb_Verktyg_ID_min.Location = new System.Drawing.Point(35, 76);
            this.tb_Verktyg_ID_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Verktyg_ID_min.MaxLength = 5;
            this.tb_Verktyg_ID_min.Multiline = true;
            this.tb_Verktyg_ID_min.Name = "tb_Verktyg_ID_min";
            this.tb_Verktyg_ID_min.Size = new System.Drawing.Size(61, 17);
            this.tb_Verktyg_ID_min.TabIndex = 0;
            this.tb_Verktyg_ID_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Verktyg_ID_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Verktyg_ID_max
            // 
            this.tb_Verktyg_ID_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Verktyg_ID_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Verktyg_ID_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Verktyg_ID_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Verktyg_ID_max.ForeColor = System.Drawing.Color.Black;
            this.tb_Verktyg_ID_max.Location = new System.Drawing.Point(35, 112);
            this.tb_Verktyg_ID_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Verktyg_ID_max.MaxLength = 5;
            this.tb_Verktyg_ID_max.Multiline = true;
            this.tb_Verktyg_ID_max.Name = "tb_Verktyg_ID_max";
            this.tb_Verktyg_ID_max.Size = new System.Drawing.Size(61, 17);
            this.tb_Verktyg_ID_max.TabIndex = 2;
            this.tb_Verktyg_ID_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Verktyg_ID_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // label_Skärmning_Antal_Trådar
            // 
            this.label_Skärmning_Antal_Trådar.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Skärmning_Antal_Trådar, 3);
            this.label_Skärmning_Antal_Trådar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Antal_Trådar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Antal_Trådar.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Antal_Trådar.Location = new System.Drawing.Point(1, 131);
            this.label_Skärmning_Antal_Trådar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Skärmning_Antal_Trådar.Name = "label_Skärmning_Antal_Trådar";
            this.label_Skärmning_Antal_Trådar.Size = new System.Drawing.Size(140, 17);
            this.label_Skärmning_Antal_Trådar.TabIndex = 936;
            this.label_Skärmning_Antal_Trådar.Text = "Antal Trådar";
            this.label_Skärmning_Antal_Trådar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Skärmning_Pot_Maskin_Hastighet
            // 
            this.label_Skärmning_Pot_Maskin_Hastighet.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Skärmning_Pot_Maskin_Hastighet, 3);
            this.label_Skärmning_Pot_Maskin_Hastighet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Pot_Maskin_Hastighet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Pot_Maskin_Hastighet.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Pot_Maskin_Hastighet.Location = new System.Drawing.Point(1, 149);
            this.label_Skärmning_Pot_Maskin_Hastighet.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Skärmning_Pot_Maskin_Hastighet.Name = "label_Skärmning_Pot_Maskin_Hastighet";
            this.label_Skärmning_Pot_Maskin_Hastighet.Size = new System.Drawing.Size(140, 19);
            this.label_Skärmning_Pot_Maskin_Hastighet.TabIndex = 936;
            this.label_Skärmning_Pot_Maskin_Hastighet.Text = "Pot. Maskin Hastighet";
            this.label_Skärmning_Pot_Maskin_Hastighet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Skärmning_Carrier_Fjäder
            // 
            this.label_Skärmning_Carrier_Fjäder.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Skärmning_Carrier_Fjäder, 3);
            this.label_Skärmning_Carrier_Fjäder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_Carrier_Fjäder.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_Carrier_Fjäder.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_Carrier_Fjäder.Location = new System.Drawing.Point(1, 169);
            this.label_Skärmning_Carrier_Fjäder.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Skärmning_Carrier_Fjäder.Name = "label_Skärmning_Carrier_Fjäder";
            this.label_Skärmning_Carrier_Fjäder.Size = new System.Drawing.Size(140, 19);
            this.label_Skärmning_Carrier_Fjäder.TabIndex = 936;
            this.label_Skärmning_Carrier_Fjäder.Text = "Carrier fjäder";
            this.label_Skärmning_Carrier_Fjäder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Skärmning_PPI
            // 
            this.label_Skärmning_PPI.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Skärmning_PPI, 3);
            this.label_Skärmning_PPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Skärmning_PPI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Skärmning_PPI.ForeColor = System.Drawing.Color.Black;
            this.label_Skärmning_PPI.Location = new System.Drawing.Point(1, 189);
            this.label_Skärmning_PPI.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Skärmning_PPI.Name = "label_Skärmning_PPI";
            this.label_Skärmning_PPI.Size = new System.Drawing.Size(140, 19);
            this.label_Skärmning_PPI.TabIndex = 936;
            this.label_Skärmning_PPI.Text = "PPI";
            this.label_Skärmning_PPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Antal_Trådar_nom
            // 
            this.tb_Antal_Trådar_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Antal_Trådar_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_Main.SetColumnSpan(this.tb_Antal_Trådar_nom, 3);
            this.tb_Antal_Trådar_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Antal_Trådar_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Antal_Trådar_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Antal_Trådar_nom.Location = new System.Drawing.Point(142, 131);
            this.tb_Antal_Trådar_nom.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_Antal_Trådar_nom.MaxLength = 4;
            this.tb_Antal_Trådar_nom.Multiline = true;
            this.tb_Antal_Trådar_nom.Name = "tb_Antal_Trådar_nom";
            this.tb_Antal_Trådar_nom.Size = new System.Drawing.Size(161, 17);
            this.tb_Antal_Trådar_nom.TabIndex = 20;
            this.tb_Antal_Trådar_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Antal_Trådar_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Pot_Maskin_Hastighet_nom
            // 
            this.tb_Pot_Maskin_Hastighet_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Pot_Maskin_Hastighet_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_Main.SetColumnSpan(this.tb_Pot_Maskin_Hastighet_nom, 3);
            this.tb_Pot_Maskin_Hastighet_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Pot_Maskin_Hastighet_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Pot_Maskin_Hastighet_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Pot_Maskin_Hastighet_nom.Location = new System.Drawing.Point(142, 149);
            this.tb_Pot_Maskin_Hastighet_nom.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_Pot_Maskin_Hastighet_nom.MaxLength = 4;
            this.tb_Pot_Maskin_Hastighet_nom.Multiline = true;
            this.tb_Pot_Maskin_Hastighet_nom.Name = "tb_Pot_Maskin_Hastighet_nom";
            this.tb_Pot_Maskin_Hastighet_nom.Size = new System.Drawing.Size(161, 19);
            this.tb_Pot_Maskin_Hastighet_nom.TabIndex = 21;
            this.tb_Pot_Maskin_Hastighet_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Pot_Maskin_Hastighet_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Carrier_fjäder_nom
            // 
            this.tb_Carrier_fjäder_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Carrier_fjäder_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_Main.SetColumnSpan(this.tb_Carrier_fjäder_nom, 3);
            this.tb_Carrier_fjäder_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Carrier_fjäder_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Carrier_fjäder_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Carrier_fjäder_nom.Location = new System.Drawing.Point(142, 169);
            this.tb_Carrier_fjäder_nom.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_Carrier_fjäder_nom.MaxLength = 4;
            this.tb_Carrier_fjäder_nom.Multiline = true;
            this.tb_Carrier_fjäder_nom.Name = "tb_Carrier_fjäder_nom";
            this.tb_Carrier_fjäder_nom.Size = new System.Drawing.Size(161, 19);
            this.tb_Carrier_fjäder_nom.TabIndex = 22;
            this.tb_Carrier_fjäder_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Carrier_fjäder_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_PPI_nom
            // 
            this.tb_PPI_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_PPI_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_Main.SetColumnSpan(this.tb_PPI_nom, 3);
            this.tb_PPI_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_PPI_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_PPI_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_PPI_nom.Location = new System.Drawing.Point(142, 189);
            this.tb_PPI_nom.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_PPI_nom.MaxLength = 4;
            this.tb_PPI_nom.Multiline = true;
            this.tb_PPI_nom.Name = "tb_PPI_nom";
            this.tb_PPI_nom.Size = new System.Drawing.Size(161, 19);
            this.tb_PPI_nom.TabIndex = 23;
            this.tb_PPI_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_PPI_nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // PC_Skärmning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "PC_Skärmning";
            this.Size = new System.Drawing.Size(304, 207);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label3;
        private TextBox tb_ODs_nom;
        private TextBox tb_OD1_nom;
        private TextBox tb_Temp_nom;
        private TextBox tb_ID_nom;
        private TextBox tb_Verktyg_ID_nom;
        private TextBox tb_OD1_min;
        private TextBox tb_OD1_max;
        private Label label4;
        private Label label_Skärmning_Temp;
        private Label label_Skärmning_Verktyg_ID;
        private Label label_Skärmning_Verktyg_ID_enhet;
        private Label label_Skärmning_Temp_enhet;
        private Label label_Skärmning_ID;
        private Label label_Skärmning_ID_enhet;
        private Label label_Skärmning_MIN;
        private Label label_Skärmning_NOM;
        private Label label_Skärmning_MAX;
        private Label label_Skärmning_OD1;
        private Label label_Skärmning_ODs_enhet;
        private Label label_Skärmning_OD1_enhet;
        private Label label_Skärmning_ODs;
        private TextBox tb_ODs_min;
        private TextBox tb_ODs_max;
        private TextBox tb_Temp_min;
        private TextBox tb_Temp_max;
        private TextBox tb_ID_min;
        private TextBox tb_ID_max;
        private TextBox tb_Verktyg_ID_min;
        private TextBox tb_Verktyg_ID_max;
        private Label label_Skärmning_Antal_Trådar;
        private Label label_Skärmning_Pot_Maskin_Hastighet;
        private Label label_Skärmning_Carrier_Fjäder;
        private Label label_Skärmning_PPI;
        private TextBox tb_Antal_Trådar_nom;
        private TextBox tb_Pot_Maskin_Hastighet_nom;
        private TextBox tb_Carrier_fjäder_nom;
        private TextBox tb_PPI_nom;
    }
}
