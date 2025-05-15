
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Svetsning_TEF
{
    partial class PC_Svetsning_TEF
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
            this.label_Empty_8 = new System.Windows.Forms.Label();
            this.label_Maskinparametrar_Datum = new System.Windows.Forms.Label();
            this.label_Maskinparametrar_Tid = new System.Windows.Forms.Label();
            this.label_Maskinparametrar_AnstNr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Empty_2 = new System.Windows.Forms.Label();
            this.label_Svets = new System.Windows.Forms.Label();
            this.label_Svetsning_Empty_3 = new System.Windows.Forms.Label();
            this.tb_Pinne_OD_PTFE_nom = new System.Windows.Forms.TextBox();
            this.tb_Värmebackar_Bredd_nom = new System.Windows.Forms.TextBox();
            this.tb_Värmebackar_Hål_nom = new System.Windows.Forms.TextBox();
            this.tb_Pinne_OD_Stål_nom = new System.Windows.Forms.TextBox();
            this.tb_Temp_nom = new System.Windows.Forms.TextBox();
            this.tb_Tid_Bindvärme_nom = new System.Windows.Forms.TextBox();
            this.tb_Tid_Kylluft_nom = new System.Windows.Forms.TextBox();
            this.tb_Svetsförflyttning_nom = new System.Windows.Forms.TextBox();
            this.tb_Svetsförflyttning_max = new System.Windows.Forms.TextBox();
            this.tb_Tid_Bindvärme_max = new System.Windows.Forms.TextBox();
            this.tb_Tid_Kylluft_max = new System.Windows.Forms.TextBox();
            this.tb_Tid_Kylluft_min = new System.Windows.Forms.TextBox();
            this.tb_Temp_min = new System.Windows.Forms.TextBox();
            this.tb_Temp_max = new System.Windows.Forms.TextBox();
            this.tb_Tid_Bindvärme_min = new System.Windows.Forms.TextBox();
            this.tb_Svetsförflyttning_min = new System.Windows.Forms.TextBox();
            this.tb_Tid_Förvärme_max = new System.Windows.Forms.TextBox();
            this.tb_Tid_Förvärme_nom = new System.Windows.Forms.TextBox();
            this.tb_Tid_Förvärme_min = new System.Windows.Forms.TextBox();
            this.label_Svetsning_Maskinparametrar = new System.Windows.Forms.Label();
            this.label_Tid_Förvärme = new System.Windows.Forms.Label();
            this.label_Tid_Förvärme_enhet = new System.Windows.Forms.Label();
            this.label_Tid_Bindvärme = new System.Windows.Forms.Label();
            this.label_SvetsFörflyttning = new System.Windows.Forms.Label();
            this.label_Svetsförflyttning_enhet = new System.Windows.Forms.Label();
            this.label_Tid_Bindvärme_enhet = new System.Windows.Forms.Label();
            this.label_Tid_Kylluft = new System.Windows.Forms.Label();
            this.label_Tid_Kylluft_enhet = new System.Windows.Forms.Label();
            this.label_Svetsning_MIN = new System.Windows.Forms.Label();
            this.label_Svetsning_NOM = new System.Windows.Forms.Label();
            this.label_Svetsning_MAX = new System.Windows.Forms.Label();
            this.label_Temp = new System.Windows.Forms.Label();
            this.label_Pinne_OD_PTFE_enhet = new System.Windows.Forms.Label();
            this.label_Temp_enhet = new System.Windows.Forms.Label();
            this.label_Pinne_OD = new System.Windows.Forms.Label();
            this.label_Pinne_OD_Stål = new System.Windows.Forms.Label();
            this.label_Pinne_OD_PTFE = new System.Windows.Forms.Label();
            this.label_Pinne_OD_Stål_enhet = new System.Windows.Forms.Label();
            this.label_Värmebackar = new System.Windows.Forms.Label();
            this.label_Värmebackar_Bredd = new System.Windows.Forms.Label();
            this.label_Värmebackar_Hål = new System.Windows.Forms.Label();
            this.label_Värmebackar_Hål_enhet = new System.Windows.Forms.Label();
            this.label_Värmebackar_Bredd_enhet = new System.Windows.Forms.Label();
            this.label_Svetsning_Empty_1 = new System.Windows.Forms.Label();
            this.label_Svetsning_Empty_2 = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 15;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlp_Main.Controls.Add(this.label_Empty_8, 11, 4);
            this.tlp_Main.Controls.Add(this.label_Maskinparametrar_Datum, 11, 1);
            this.tlp_Main.Controls.Add(this.label_Maskinparametrar_Tid, 12, 1);
            this.tlp_Main.Controls.Add(this.label_Maskinparametrar_AnstNr, 13, 1);
            this.tlp_Main.Controls.Add(this.label3, 14, 1);
            this.tlp_Main.Controls.Add(this.label_Empty_2, 1, 4);
            this.tlp_Main.Controls.Add(this.label_Svets, 1, 1);
            this.tlp_Main.Controls.Add(this.label_Svetsning_Empty_3, 0, 1);
            this.tlp_Main.Controls.Add(this.tb_Pinne_OD_PTFE_nom, 8, 5);
            this.tlp_Main.Controls.Add(this.tb_Värmebackar_Bredd_nom, 9, 5);
            this.tlp_Main.Controls.Add(this.tb_Värmebackar_Hål_nom, 10, 5);
            this.tlp_Main.Controls.Add(this.tb_Pinne_OD_Stål_nom, 7, 5);
            this.tlp_Main.Controls.Add(this.tb_Temp_nom, 6, 5);
            this.tlp_Main.Controls.Add(this.tb_Tid_Bindvärme_nom, 4, 5);
            this.tlp_Main.Controls.Add(this.tb_Tid_Kylluft_nom, 5, 5);
            this.tlp_Main.Controls.Add(this.tb_Svetsförflyttning_nom, 3, 5);
            this.tlp_Main.Controls.Add(this.tb_Svetsförflyttning_max, 3, 6);
            this.tlp_Main.Controls.Add(this.tb_Tid_Bindvärme_max, 4, 6);
            this.tlp_Main.Controls.Add(this.tb_Tid_Kylluft_max, 5, 6);
            this.tlp_Main.Controls.Add(this.tb_Tid_Kylluft_min, 5, 4);
            this.tlp_Main.Controls.Add(this.tb_Temp_min, 6, 4);
            this.tlp_Main.Controls.Add(this.tb_Temp_max, 6, 6);
            this.tlp_Main.Controls.Add(this.tb_Tid_Bindvärme_min, 4, 4);
            this.tlp_Main.Controls.Add(this.tb_Svetsförflyttning_min, 3, 4);
            this.tlp_Main.Controls.Add(this.tb_Tid_Förvärme_max, 2, 6);
            this.tlp_Main.Controls.Add(this.tb_Tid_Förvärme_nom, 2, 5);
            this.tlp_Main.Controls.Add(this.tb_Tid_Förvärme_min, 2, 4);
            this.tlp_Main.Controls.Add(this.label_Svetsning_Maskinparametrar, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Tid_Förvärme, 2, 1);
            this.tlp_Main.Controls.Add(this.label_Tid_Förvärme_enhet, 2, 3);
            this.tlp_Main.Controls.Add(this.label_Tid_Bindvärme, 4, 1);
            this.tlp_Main.Controls.Add(this.label_SvetsFörflyttning, 3, 1);
            this.tlp_Main.Controls.Add(this.label_Svetsförflyttning_enhet, 3, 3);
            this.tlp_Main.Controls.Add(this.label_Tid_Bindvärme_enhet, 4, 3);
            this.tlp_Main.Controls.Add(this.label_Tid_Kylluft, 5, 1);
            this.tlp_Main.Controls.Add(this.label_Tid_Kylluft_enhet, 5, 3);
            this.tlp_Main.Controls.Add(this.label_Svetsning_MIN, 0, 4);
            this.tlp_Main.Controls.Add(this.label_Svetsning_NOM, 0, 5);
            this.tlp_Main.Controls.Add(this.label_Svetsning_MAX, 0, 6);
            this.tlp_Main.Controls.Add(this.label_Temp, 6, 1);
            this.tlp_Main.Controls.Add(this.label_Pinne_OD_PTFE_enhet, 7, 3);
            this.tlp_Main.Controls.Add(this.label_Temp_enhet, 6, 3);
            this.tlp_Main.Controls.Add(this.label_Pinne_OD, 7, 1);
            this.tlp_Main.Controls.Add(this.label_Pinne_OD_Stål, 7, 2);
            this.tlp_Main.Controls.Add(this.label_Pinne_OD_PTFE, 8, 2);
            this.tlp_Main.Controls.Add(this.label_Pinne_OD_Stål_enhet, 8, 3);
            this.tlp_Main.Controls.Add(this.label_Värmebackar, 9, 1);
            this.tlp_Main.Controls.Add(this.label_Värmebackar_Bredd, 9, 2);
            this.tlp_Main.Controls.Add(this.label_Värmebackar_Hål, 10, 2);
            this.tlp_Main.Controls.Add(this.label_Värmebackar_Hål_enhet, 9, 3);
            this.tlp_Main.Controls.Add(this.label_Värmebackar_Bredd_enhet, 10, 3);
            this.tlp_Main.Controls.Add(this.label_Svetsning_Empty_1, 7, 4);
            this.tlp_Main.Controls.Add(this.label_Svetsning_Empty_2, 7, 6);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 8;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(841, 136);
            this.tlp_Main.TabIndex = 945;
            // 
            // label_Empty_8
            // 
            this.label_Empty_8.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Main.SetColumnSpan(this.label_Empty_8, 4);
            this.label_Empty_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_8.Location = new System.Drawing.Point(581, 76);
            this.label_Empty_8.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.label_Empty_8.Name = "label_Empty_8";
            this.tlp_Main.SetRowSpan(this.label_Empty_8, 3);
            this.label_Empty_8.Size = new System.Drawing.Size(259, 59);
            this.label_Empty_8.TabIndex = 1036;
            this.label_Empty_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_Datum
            // 
            this.label_Maskinparametrar_Datum.BackColor = System.Drawing.Color.White;
            this.label_Maskinparametrar_Datum.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Maskinparametrar_Datum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Maskinparametrar_Datum.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Maskinparametrar_Datum.ForeColor = System.Drawing.Color.Black;
            this.label_Maskinparametrar_Datum.Location = new System.Drawing.Point(582, 23);
            this.label_Maskinparametrar_Datum.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Maskinparametrar_Datum.Name = "label_Maskinparametrar_Datum";
            this.tlp_Main.SetRowSpan(this.label_Maskinparametrar_Datum, 3);
            this.label_Maskinparametrar_Datum.Size = new System.Drawing.Size(83, 52);
            this.label_Maskinparametrar_Datum.TabIndex = 1032;
            this.label_Maskinparametrar_Datum.Text = "Datum";
            this.label_Maskinparametrar_Datum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_Tid
            // 
            this.label_Maskinparametrar_Tid.BackColor = System.Drawing.Color.White;
            this.label_Maskinparametrar_Tid.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Maskinparametrar_Tid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Maskinparametrar_Tid.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Maskinparametrar_Tid.ForeColor = System.Drawing.Color.Black;
            this.label_Maskinparametrar_Tid.Location = new System.Drawing.Point(666, 23);
            this.label_Maskinparametrar_Tid.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Maskinparametrar_Tid.Name = "label_Maskinparametrar_Tid";
            this.tlp_Main.SetRowSpan(this.label_Maskinparametrar_Tid, 3);
            this.label_Maskinparametrar_Tid.Size = new System.Drawing.Size(47, 52);
            this.label_Maskinparametrar_Tid.TabIndex = 1033;
            this.label_Maskinparametrar_Tid.Text = "Tid";
            this.label_Maskinparametrar_Tid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_AnstNr
            // 
            this.label_Maskinparametrar_AnstNr.BackColor = System.Drawing.Color.White;
            this.label_Maskinparametrar_AnstNr.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Maskinparametrar_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Maskinparametrar_AnstNr.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Maskinparametrar_AnstNr.ForeColor = System.Drawing.Color.Black;
            this.label_Maskinparametrar_AnstNr.Location = new System.Drawing.Point(714, 23);
            this.label_Maskinparametrar_AnstNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Maskinparametrar_AnstNr.Name = "label_Maskinparametrar_AnstNr";
            this.tlp_Main.SetRowSpan(this.label_Maskinparametrar_AnstNr, 3);
            this.label_Maskinparametrar_AnstNr.Size = new System.Drawing.Size(41, 52);
            this.label_Maskinparametrar_AnstNr.TabIndex = 1034;
            this.label_Maskinparametrar_AnstNr.Text = "Anst Nr";
            this.label_Maskinparametrar_AnstNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(756, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label3.Name = "label3";
            this.tlp_Main.SetRowSpan(this.label3, 3);
            this.label3.Size = new System.Drawing.Size(84, 52);
            this.label3.TabIndex = 1035;
            this.label3.Text = "Sign";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_2
            // 
            this.label_Empty_2.AutoSize = true;
            this.label_Empty_2.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_2.Location = new System.Drawing.Point(38, 76);
            this.label_Empty_2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Empty_2.Name = "label_Empty_2";
            this.tlp_Main.SetRowSpan(this.label_Empty_2, 3);
            this.label_Empty_2.Size = new System.Drawing.Size(62, 59);
            this.label_Empty_2.TabIndex = 1031;
            this.label_Empty_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svets
            // 
            this.label_Svets.BackColor = System.Drawing.Color.White;
            this.label_Svets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svets.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Svets.ForeColor = System.Drawing.Color.Black;
            this.label_Svets.Location = new System.Drawing.Point(38, 23);
            this.label_Svets.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svets.Name = "label_Svets";
            this.tlp_Main.SetRowSpan(this.label_Svets, 3);
            this.label_Svets.Size = new System.Drawing.Size(62, 52);
            this.label_Svets.TabIndex = 1030;
            this.label_Svets.Text = "Svets";
            this.label_Svets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svetsning_Empty_3
            // 
            this.label_Svetsning_Empty_3.BackColor = System.Drawing.Color.DarkGray;
            this.label_Svetsning_Empty_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_Empty_3.Enabled = false;
            this.label_Svetsning_Empty_3.Font = new System.Drawing.Font("Arial", 8F);
            this.label_Svetsning_Empty_3.Location = new System.Drawing.Point(1, 23);
            this.label_Svetsning_Empty_3.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsning_Empty_3.Name = "label_Svetsning_Empty_3";
            this.tlp_Main.SetRowSpan(this.label_Svetsning_Empty_3, 3);
            this.label_Svetsning_Empty_3.Size = new System.Drawing.Size(36, 52);
            this.label_Svetsning_Empty_3.TabIndex = 1029;
            this.label_Svetsning_Empty_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Pinne_OD_PTFE_nom
            // 
            this.tb_Pinne_OD_PTFE_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Pinne_OD_PTFE_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Pinne_OD_PTFE_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Pinne_OD_PTFE_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Pinne_OD_PTFE_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Pinne_OD_PTFE_nom.Location = new System.Drawing.Point(419, 96);
            this.tb_Pinne_OD_PTFE_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Pinne_OD_PTFE_nom.MaxLength = 12;
            this.tb_Pinne_OD_PTFE_nom.Multiline = true;
            this.tb_Pinne_OD_PTFE_nom.Name = "tb_Pinne_OD_PTFE_nom";
            this.tb_Pinne_OD_PTFE_nom.Size = new System.Drawing.Size(77, 19);
            this.tb_Pinne_OD_PTFE_nom.TabIndex = 17;
            this.tb_Pinne_OD_PTFE_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Värmebackar_Bredd_nom
            // 
            this.tb_Värmebackar_Bredd_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Värmebackar_Bredd_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Värmebackar_Bredd_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Värmebackar_Bredd_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Värmebackar_Bredd_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Värmebackar_Bredd_nom.Location = new System.Drawing.Point(497, 96);
            this.tb_Värmebackar_Bredd_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Värmebackar_Bredd_nom.MaxLength = 5;
            this.tb_Värmebackar_Bredd_nom.Multiline = true;
            this.tb_Värmebackar_Bredd_nom.Name = "tb_Värmebackar_Bredd_nom";
            this.tb_Värmebackar_Bredd_nom.Size = new System.Drawing.Size(41, 19);
            this.tb_Värmebackar_Bredd_nom.TabIndex = 18;
            this.tb_Värmebackar_Bredd_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Värmebackar_Hål_nom
            // 
            this.tb_Värmebackar_Hål_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Värmebackar_Hål_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Värmebackar_Hål_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Värmebackar_Hål_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Värmebackar_Hål_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Värmebackar_Hål_nom.Location = new System.Drawing.Point(539, 96);
            this.tb_Värmebackar_Hål_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tb_Värmebackar_Hål_nom.MaxLength = 5;
            this.tb_Värmebackar_Hål_nom.Multiline = true;
            this.tb_Värmebackar_Hål_nom.Name = "tb_Värmebackar_Hål_nom";
            this.tb_Värmebackar_Hål_nom.Size = new System.Drawing.Size(41, 19);
            this.tb_Värmebackar_Hål_nom.TabIndex = 19;
            this.tb_Värmebackar_Hål_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Pinne_OD_Stål_nom
            // 
            this.tb_Pinne_OD_Stål_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Pinne_OD_Stål_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Pinne_OD_Stål_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Pinne_OD_Stål_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Pinne_OD_Stål_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Pinne_OD_Stål_nom.Location = new System.Drawing.Point(375, 96);
            this.tb_Pinne_OD_Stål_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Pinne_OD_Stål_nom.MaxLength = 5;
            this.tb_Pinne_OD_Stål_nom.Multiline = true;
            this.tb_Pinne_OD_Stål_nom.Name = "tb_Pinne_OD_Stål_nom";
            this.tb_Pinne_OD_Stål_nom.Size = new System.Drawing.Size(43, 19);
            this.tb_Pinne_OD_Stål_nom.TabIndex = 16;
            this.tb_Pinne_OD_Stål_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Temp_nom
            // 
            this.tb_Temp_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Temp_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temp_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Temp_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Temp_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Temp_nom.Location = new System.Drawing.Point(336, 96);
            this.tb_Temp_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Temp_nom.MaxLength = 4;
            this.tb_Temp_nom.Multiline = true;
            this.tb_Temp_nom.Name = "tb_Temp_nom";
            this.tb_Temp_nom.Size = new System.Drawing.Size(38, 19);
            this.tb_Temp_nom.TabIndex = 14;
            this.tb_Temp_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Bindvärme_nom
            // 
            this.tb_Tid_Bindvärme_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Tid_Bindvärme_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Bindvärme_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Bindvärme_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Bindvärme_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Tid_Bindvärme_nom.Location = new System.Drawing.Point(224, 96);
            this.tb_Tid_Bindvärme_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Bindvärme_nom.MaxLength = 3;
            this.tb_Tid_Bindvärme_nom.Multiline = true;
            this.tb_Tid_Bindvärme_nom.Name = "tb_Tid_Bindvärme_nom";
            this.tb_Tid_Bindvärme_nom.Size = new System.Drawing.Size(66, 19);
            this.tb_Tid_Bindvärme_nom.TabIndex = 8;
            this.tb_Tid_Bindvärme_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Kylluft_nom
            // 
            this.tb_Tid_Kylluft_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Tid_Kylluft_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Kylluft_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Kylluft_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Kylluft_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Tid_Kylluft_nom.Location = new System.Drawing.Point(291, 96);
            this.tb_Tid_Kylluft_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Kylluft_nom.MaxLength = 3;
            this.tb_Tid_Kylluft_nom.Multiline = true;
            this.tb_Tid_Kylluft_nom.Name = "tb_Tid_Kylluft_nom";
            this.tb_Tid_Kylluft_nom.Size = new System.Drawing.Size(44, 19);
            this.tb_Tid_Kylluft_nom.TabIndex = 11;
            this.tb_Tid_Kylluft_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Svetsförflyttning_nom
            // 
            this.tb_Svetsförflyttning_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Svetsförflyttning_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Svetsförflyttning_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Svetsförflyttning_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Svetsförflyttning_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Svetsförflyttning_nom.Location = new System.Drawing.Point(161, 96);
            this.tb_Svetsförflyttning_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Svetsförflyttning_nom.MaxLength = 4;
            this.tb_Svetsförflyttning_nom.Multiline = true;
            this.tb_Svetsförflyttning_nom.Name = "tb_Svetsförflyttning_nom";
            this.tb_Svetsförflyttning_nom.Size = new System.Drawing.Size(62, 19);
            this.tb_Svetsförflyttning_nom.TabIndex = 5;
            this.tb_Svetsförflyttning_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Svetsförflyttning_max
            // 
            this.tb_Svetsförflyttning_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Svetsförflyttning_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Svetsförflyttning_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Svetsförflyttning_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Svetsförflyttning_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Svetsförflyttning_max.Location = new System.Drawing.Point(161, 116);
            this.tb_Svetsförflyttning_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Svetsförflyttning_max.MaxLength = 4;
            this.tb_Svetsförflyttning_max.Multiline = true;
            this.tb_Svetsförflyttning_max.Name = "tb_Svetsförflyttning_max";
            this.tb_Svetsförflyttning_max.Size = new System.Drawing.Size(62, 19);
            this.tb_Svetsförflyttning_max.TabIndex = 6;
            this.tb_Svetsförflyttning_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Bindvärme_max
            // 
            this.tb_Tid_Bindvärme_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Tid_Bindvärme_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Bindvärme_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Bindvärme_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Bindvärme_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Tid_Bindvärme_max.Location = new System.Drawing.Point(224, 116);
            this.tb_Tid_Bindvärme_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Bindvärme_max.MaxLength = 3;
            this.tb_Tid_Bindvärme_max.Multiline = true;
            this.tb_Tid_Bindvärme_max.Name = "tb_Tid_Bindvärme_max";
            this.tb_Tid_Bindvärme_max.Size = new System.Drawing.Size(66, 19);
            this.tb_Tid_Bindvärme_max.TabIndex = 9;
            this.tb_Tid_Bindvärme_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Kylluft_max
            // 
            this.tb_Tid_Kylluft_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Tid_Kylluft_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Kylluft_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Kylluft_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Kylluft_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Tid_Kylluft_max.Location = new System.Drawing.Point(291, 116);
            this.tb_Tid_Kylluft_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Kylluft_max.MaxLength = 3;
            this.tb_Tid_Kylluft_max.Multiline = true;
            this.tb_Tid_Kylluft_max.Name = "tb_Tid_Kylluft_max";
            this.tb_Tid_Kylluft_max.Size = new System.Drawing.Size(44, 19);
            this.tb_Tid_Kylluft_max.TabIndex = 12;
            this.tb_Tid_Kylluft_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Kylluft_min
            // 
            this.tb_Tid_Kylluft_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Tid_Kylluft_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Kylluft_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Kylluft_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Kylluft_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Tid_Kylluft_min.Location = new System.Drawing.Point(291, 76);
            this.tb_Tid_Kylluft_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Kylluft_min.MaxLength = 3;
            this.tb_Tid_Kylluft_min.Multiline = true;
            this.tb_Tid_Kylluft_min.Name = "tb_Tid_Kylluft_min";
            this.tb_Tid_Kylluft_min.Size = new System.Drawing.Size(44, 19);
            this.tb_Tid_Kylluft_min.TabIndex = 10;
            this.tb_Tid_Kylluft_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Temp_min
            // 
            this.tb_Temp_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Temp_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temp_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Temp_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Temp_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Temp_min.Location = new System.Drawing.Point(336, 76);
            this.tb_Temp_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Temp_min.MaxLength = 4;
            this.tb_Temp_min.Multiline = true;
            this.tb_Temp_min.Name = "tb_Temp_min";
            this.tb_Temp_min.Size = new System.Drawing.Size(38, 19);
            this.tb_Temp_min.TabIndex = 13;
            this.tb_Temp_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Temp_max
            // 
            this.tb_Temp_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Temp_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temp_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Temp_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Temp_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Temp_max.Location = new System.Drawing.Point(336, 116);
            this.tb_Temp_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Temp_max.MaxLength = 4;
            this.tb_Temp_max.Multiline = true;
            this.tb_Temp_max.Name = "tb_Temp_max";
            this.tb_Temp_max.Size = new System.Drawing.Size(38, 19);
            this.tb_Temp_max.TabIndex = 15;
            this.tb_Temp_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Bindvärme_min
            // 
            this.tb_Tid_Bindvärme_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Tid_Bindvärme_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Bindvärme_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Bindvärme_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Bindvärme_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Tid_Bindvärme_min.Location = new System.Drawing.Point(224, 76);
            this.tb_Tid_Bindvärme_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Bindvärme_min.MaxLength = 3;
            this.tb_Tid_Bindvärme_min.Multiline = true;
            this.tb_Tid_Bindvärme_min.Name = "tb_Tid_Bindvärme_min";
            this.tb_Tid_Bindvärme_min.Size = new System.Drawing.Size(66, 19);
            this.tb_Tid_Bindvärme_min.TabIndex = 7;
            this.tb_Tid_Bindvärme_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Svetsförflyttning_min
            // 
            this.tb_Svetsförflyttning_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Svetsförflyttning_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Svetsförflyttning_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Svetsförflyttning_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Svetsförflyttning_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Svetsförflyttning_min.Location = new System.Drawing.Point(161, 76);
            this.tb_Svetsförflyttning_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Svetsförflyttning_min.MaxLength = 4;
            this.tb_Svetsförflyttning_min.Multiline = true;
            this.tb_Svetsförflyttning_min.Name = "tb_Svetsförflyttning_min";
            this.tb_Svetsförflyttning_min.Size = new System.Drawing.Size(62, 19);
            this.tb_Svetsförflyttning_min.TabIndex = 4;
            this.tb_Svetsförflyttning_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Förvärme_max
            // 
            this.tb_Tid_Förvärme_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Tid_Förvärme_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Förvärme_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Förvärme_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Förvärme_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Tid_Förvärme_max.Location = new System.Drawing.Point(101, 116);
            this.tb_Tid_Förvärme_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Förvärme_max.MaxLength = 4;
            this.tb_Tid_Förvärme_max.Multiline = true;
            this.tb_Tid_Förvärme_max.Name = "tb_Tid_Förvärme_max";
            this.tb_Tid_Förvärme_max.Size = new System.Drawing.Size(59, 19);
            this.tb_Tid_Förvärme_max.TabIndex = 3;
            this.tb_Tid_Förvärme_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Förvärme_nom
            // 
            this.tb_Tid_Förvärme_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Tid_Förvärme_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Förvärme_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Förvärme_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Förvärme_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Tid_Förvärme_nom.Location = new System.Drawing.Point(101, 96);
            this.tb_Tid_Förvärme_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Förvärme_nom.MaxLength = 4;
            this.tb_Tid_Förvärme_nom.Multiline = true;
            this.tb_Tid_Förvärme_nom.Name = "tb_Tid_Förvärme_nom";
            this.tb_Tid_Förvärme_nom.Size = new System.Drawing.Size(59, 19);
            this.tb_Tid_Förvärme_nom.TabIndex = 2;
            this.tb_Tid_Förvärme_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Tid_Förvärme_min
            // 
            this.tb_Tid_Förvärme_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Tid_Förvärme_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid_Förvärme_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Tid_Förvärme_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Tid_Förvärme_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_Tid_Förvärme_min.Location = new System.Drawing.Point(101, 76);
            this.tb_Tid_Förvärme_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Tid_Förvärme_min.MaxLength = 4;
            this.tb_Tid_Förvärme_min.Multiline = true;
            this.tb_Tid_Förvärme_min.Name = "tb_Tid_Förvärme_min";
            this.tb_Tid_Förvärme_min.Size = new System.Drawing.Size(59, 19);
            this.tb_Tid_Förvärme_min.TabIndex = 1;
            this.tb_Tid_Förvärme_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Svetsning_Maskinparametrar
            // 
            this.label_Svetsning_Maskinparametrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tlp_Main.SetColumnSpan(this.label_Svetsning_Maskinparametrar, 15);
            this.label_Svetsning_Maskinparametrar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Svetsning_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_Maskinparametrar.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Svetsning_Maskinparametrar.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Svetsning_Maskinparametrar.Location = new System.Drawing.Point(1, 2);
            this.label_Svetsning_Maskinparametrar.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.label_Svetsning_Maskinparametrar.Name = "label_Svetsning_Maskinparametrar";
            this.label_Svetsning_Maskinparametrar.Size = new System.Drawing.Size(839, 20);
            this.label_Svetsning_Maskinparametrar.TabIndex = 933;
            this.label_Svetsning_Maskinparametrar.Text = "Maskinparametrar";
            this.label_Svetsning_Maskinparametrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Tid_Förvärme
            // 
            this.label_Tid_Förvärme.BackColor = System.Drawing.Color.White;
            this.label_Tid_Förvärme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid_Förvärme.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Tid_Förvärme.ForeColor = System.Drawing.Color.Black;
            this.label_Tid_Förvärme.Location = new System.Drawing.Point(101, 23);
            this.label_Tid_Förvärme.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Tid_Förvärme.Name = "label_Tid_Förvärme";
            this.tlp_Main.SetRowSpan(this.label_Tid_Förvärme, 2);
            this.label_Tid_Förvärme.Size = new System.Drawing.Size(59, 38);
            this.label_Tid_Förvärme.TabIndex = 934;
            this.label_Tid_Förvärme.Text = "Tid Förvärme";
            this.label_Tid_Förvärme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tid_Förvärme_enhet
            // 
            this.label_Tid_Förvärme_enhet.BackColor = System.Drawing.Color.White;
            this.label_Tid_Förvärme_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid_Förvärme_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tid_Förvärme_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Tid_Förvärme_enhet.Location = new System.Drawing.Point(101, 61);
            this.label_Tid_Förvärme_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Tid_Förvärme_enhet.Name = "label_Tid_Förvärme_enhet";
            this.label_Tid_Förvärme_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Tid_Förvärme_enhet.Size = new System.Drawing.Size(59, 14);
            this.label_Tid_Förvärme_enhet.TabIndex = 935;
            this.label_Tid_Förvärme_enhet.Text = "sek";
            this.label_Tid_Förvärme_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tid_Bindvärme
            // 
            this.label_Tid_Bindvärme.BackColor = System.Drawing.Color.White;
            this.label_Tid_Bindvärme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid_Bindvärme.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Tid_Bindvärme.ForeColor = System.Drawing.Color.Black;
            this.label_Tid_Bindvärme.Location = new System.Drawing.Point(224, 23);
            this.label_Tid_Bindvärme.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Tid_Bindvärme.Name = "label_Tid_Bindvärme";
            this.tlp_Main.SetRowSpan(this.label_Tid_Bindvärme, 2);
            this.label_Tid_Bindvärme.Size = new System.Drawing.Size(66, 38);
            this.label_Tid_Bindvärme.TabIndex = 937;
            this.label_Tid_Bindvärme.Text = "Tid Bindvärme";
            this.label_Tid_Bindvärme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SvetsFörflyttning
            // 
            this.label_SvetsFörflyttning.BackColor = System.Drawing.Color.White;
            this.label_SvetsFörflyttning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SvetsFörflyttning.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_SvetsFörflyttning.ForeColor = System.Drawing.Color.Black;
            this.label_SvetsFörflyttning.Location = new System.Drawing.Point(161, 23);
            this.label_SvetsFörflyttning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_SvetsFörflyttning.Name = "label_SvetsFörflyttning";
            this.tlp_Main.SetRowSpan(this.label_SvetsFörflyttning, 2);
            this.label_SvetsFörflyttning.Size = new System.Drawing.Size(62, 38);
            this.label_SvetsFörflyttning.TabIndex = 936;
            this.label_SvetsFörflyttning.Text = "Svets- förflyttning";
            this.label_SvetsFörflyttning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svetsförflyttning_enhet
            // 
            this.label_Svetsförflyttning_enhet.BackColor = System.Drawing.Color.White;
            this.label_Svetsförflyttning_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsförflyttning_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Svetsförflyttning_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Svetsförflyttning_enhet.Location = new System.Drawing.Point(161, 61);
            this.label_Svetsförflyttning_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsförflyttning_enhet.Name = "label_Svetsförflyttning_enhet";
            this.label_Svetsförflyttning_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Svetsförflyttning_enhet.Size = new System.Drawing.Size(62, 14);
            this.label_Svetsförflyttning_enhet.TabIndex = 939;
            this.label_Svetsförflyttning_enhet.Text = "mm";
            this.label_Svetsförflyttning_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tid_Bindvärme_enhet
            // 
            this.label_Tid_Bindvärme_enhet.BackColor = System.Drawing.Color.White;
            this.label_Tid_Bindvärme_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid_Bindvärme_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tid_Bindvärme_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Tid_Bindvärme_enhet.Location = new System.Drawing.Point(224, 61);
            this.label_Tid_Bindvärme_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Tid_Bindvärme_enhet.Name = "label_Tid_Bindvärme_enhet";
            this.label_Tid_Bindvärme_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Tid_Bindvärme_enhet.Size = new System.Drawing.Size(66, 14);
            this.label_Tid_Bindvärme_enhet.TabIndex = 940;
            this.label_Tid_Bindvärme_enhet.Text = "sek";
            this.label_Tid_Bindvärme_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tid_Kylluft
            // 
            this.label_Tid_Kylluft.BackColor = System.Drawing.Color.White;
            this.label_Tid_Kylluft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid_Kylluft.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Tid_Kylluft.ForeColor = System.Drawing.Color.Black;
            this.label_Tid_Kylluft.Location = new System.Drawing.Point(291, 23);
            this.label_Tid_Kylluft.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Tid_Kylluft.Name = "label_Tid_Kylluft";
            this.tlp_Main.SetRowSpan(this.label_Tid_Kylluft, 2);
            this.label_Tid_Kylluft.Size = new System.Drawing.Size(44, 38);
            this.label_Tid_Kylluft.TabIndex = 938;
            this.label_Tid_Kylluft.Text = "Tid Kylluft";
            this.label_Tid_Kylluft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tid_Kylluft_enhet
            // 
            this.label_Tid_Kylluft_enhet.BackColor = System.Drawing.Color.White;
            this.label_Tid_Kylluft_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid_Kylluft_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tid_Kylluft_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Tid_Kylluft_enhet.Location = new System.Drawing.Point(291, 61);
            this.label_Tid_Kylluft_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Tid_Kylluft_enhet.Name = "label_Tid_Kylluft_enhet";
            this.label_Tid_Kylluft_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Tid_Kylluft_enhet.Size = new System.Drawing.Size(44, 14);
            this.label_Tid_Kylluft_enhet.TabIndex = 941;
            this.label_Tid_Kylluft_enhet.Text = "sek";
            this.label_Tid_Kylluft_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svetsning_MIN
            // 
            this.label_Svetsning_MIN.BackColor = System.Drawing.Color.White;
            this.label_Svetsning_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_MIN.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.label_Svetsning_MIN.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Svetsning_MIN.Location = new System.Drawing.Point(1, 76);
            this.label_Svetsning_MIN.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsning_MIN.Name = "label_Svetsning_MIN";
            this.label_Svetsning_MIN.Size = new System.Drawing.Size(36, 19);
            this.label_Svetsning_MIN.TabIndex = 942;
            this.label_Svetsning_MIN.Text = "MIN";
            this.label_Svetsning_MIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svetsning_NOM
            // 
            this.label_Svetsning_NOM.BackColor = System.Drawing.Color.White;
            this.label_Svetsning_NOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_NOM.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.label_Svetsning_NOM.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Svetsning_NOM.Location = new System.Drawing.Point(1, 96);
            this.label_Svetsning_NOM.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsning_NOM.Name = "label_Svetsning_NOM";
            this.label_Svetsning_NOM.Size = new System.Drawing.Size(36, 19);
            this.label_Svetsning_NOM.TabIndex = 943;
            this.label_Svetsning_NOM.Text = "NOM";
            this.label_Svetsning_NOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svetsning_MAX
            // 
            this.label_Svetsning_MAX.AutoSize = true;
            this.label_Svetsning_MAX.BackColor = System.Drawing.Color.White;
            this.label_Svetsning_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_MAX.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.label_Svetsning_MAX.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Svetsning_MAX.Location = new System.Drawing.Point(1, 116);
            this.label_Svetsning_MAX.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsning_MAX.Name = "label_Svetsning_MAX";
            this.label_Svetsning_MAX.Size = new System.Drawing.Size(36, 19);
            this.label_Svetsning_MAX.TabIndex = 944;
            this.label_Svetsning_MAX.Text = "MAX";
            this.label_Svetsning_MAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp
            // 
            this.label_Temp.BackColor = System.Drawing.Color.White;
            this.label_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Temp.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Temp.ForeColor = System.Drawing.Color.Black;
            this.label_Temp.Location = new System.Drawing.Point(336, 23);
            this.label_Temp.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Temp.Name = "label_Temp";
            this.tlp_Main.SetRowSpan(this.label_Temp, 2);
            this.label_Temp.Size = new System.Drawing.Size(38, 38);
            this.label_Temp.TabIndex = 997;
            this.label_Temp.Text = "Temp";
            this.label_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Pinne_OD_PTFE_enhet
            // 
            this.label_Pinne_OD_PTFE_enhet.BackColor = System.Drawing.Color.White;
            this.label_Pinne_OD_PTFE_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Pinne_OD_PTFE_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Pinne_OD_PTFE_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Pinne_OD_PTFE_enhet.Location = new System.Drawing.Point(375, 61);
            this.label_Pinne_OD_PTFE_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Pinne_OD_PTFE_enhet.Name = "label_Pinne_OD_PTFE_enhet";
            this.label_Pinne_OD_PTFE_enhet.Size = new System.Drawing.Size(43, 14);
            this.label_Pinne_OD_PTFE_enhet.TabIndex = 1000;
            this.label_Pinne_OD_PTFE_enhet.Text = "mm";
            this.label_Pinne_OD_PTFE_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Temp_enhet
            // 
            this.label_Temp_enhet.BackColor = System.Drawing.Color.White;
            this.label_Temp_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Temp_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Temp_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Temp_enhet.Location = new System.Drawing.Point(336, 61);
            this.label_Temp_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Temp_enhet.Name = "label_Temp_enhet";
            this.label_Temp_enhet.Size = new System.Drawing.Size(38, 14);
            this.label_Temp_enhet.TabIndex = 1001;
            this.label_Temp_enhet.Text = "ºC";
            this.label_Temp_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Pinne_OD
            // 
            this.label_Pinne_OD.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Pinne_OD, 2);
            this.label_Pinne_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Pinne_OD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Pinne_OD.ForeColor = System.Drawing.Color.Black;
            this.label_Pinne_OD.Location = new System.Drawing.Point(375, 23);
            this.label_Pinne_OD.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Pinne_OD.Name = "label_Pinne_OD";
            this.label_Pinne_OD.Size = new System.Drawing.Size(121, 24);
            this.label_Pinne_OD.TabIndex = 998;
            this.label_Pinne_OD.Text = "Pinne OD";
            this.label_Pinne_OD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Pinne_OD_Stål
            // 
            this.label_Pinne_OD_Stål.BackColor = System.Drawing.Color.White;
            this.label_Pinne_OD_Stål.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Pinne_OD_Stål.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Pinne_OD_Stål.ForeColor = System.Drawing.Color.Black;
            this.label_Pinne_OD_Stål.Location = new System.Drawing.Point(375, 47);
            this.label_Pinne_OD_Stål.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Pinne_OD_Stål.Name = "label_Pinne_OD_Stål";
            this.label_Pinne_OD_Stål.Size = new System.Drawing.Size(43, 14);
            this.label_Pinne_OD_Stål.TabIndex = 1002;
            this.label_Pinne_OD_Stål.Text = "Stål";
            this.label_Pinne_OD_Stål.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Pinne_OD_PTFE
            // 
            this.label_Pinne_OD_PTFE.BackColor = System.Drawing.Color.White;
            this.label_Pinne_OD_PTFE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Pinne_OD_PTFE.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Pinne_OD_PTFE.ForeColor = System.Drawing.Color.Black;
            this.label_Pinne_OD_PTFE.Location = new System.Drawing.Point(419, 47);
            this.label_Pinne_OD_PTFE.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Pinne_OD_PTFE.Name = "label_Pinne_OD_PTFE";
            this.label_Pinne_OD_PTFE.Size = new System.Drawing.Size(77, 14);
            this.label_Pinne_OD_PTFE.TabIndex = 1003;
            this.label_Pinne_OD_PTFE.Text = "PTFE";
            this.label_Pinne_OD_PTFE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Pinne_OD_Stål_enhet
            // 
            this.label_Pinne_OD_Stål_enhet.BackColor = System.Drawing.Color.White;
            this.label_Pinne_OD_Stål_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Pinne_OD_Stål_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Pinne_OD_Stål_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Pinne_OD_Stål_enhet.Location = new System.Drawing.Point(419, 61);
            this.label_Pinne_OD_Stål_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Pinne_OD_Stål_enhet.Name = "label_Pinne_OD_Stål_enhet";
            this.label_Pinne_OD_Stål_enhet.Size = new System.Drawing.Size(77, 14);
            this.label_Pinne_OD_Stål_enhet.TabIndex = 999;
            this.label_Pinne_OD_Stål_enhet.Text = "mm";
            this.label_Pinne_OD_Stål_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Värmebackar
            // 
            this.label_Värmebackar.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Värmebackar, 2);
            this.label_Värmebackar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Värmebackar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_Värmebackar.ForeColor = System.Drawing.Color.Black;
            this.label_Värmebackar.Location = new System.Drawing.Point(497, 23);
            this.label_Värmebackar.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Värmebackar.Name = "label_Värmebackar";
            this.label_Värmebackar.Size = new System.Drawing.Size(84, 24);
            this.label_Värmebackar.TabIndex = 1004;
            this.label_Värmebackar.Text = "Värmebackar";
            this.label_Värmebackar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Värmebackar_Bredd
            // 
            this.label_Värmebackar_Bredd.BackColor = System.Drawing.Color.White;
            this.label_Värmebackar_Bredd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Värmebackar_Bredd.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Värmebackar_Bredd.ForeColor = System.Drawing.Color.Black;
            this.label_Värmebackar_Bredd.Location = new System.Drawing.Point(497, 47);
            this.label_Värmebackar_Bredd.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Värmebackar_Bredd.Name = "label_Värmebackar_Bredd";
            this.label_Värmebackar_Bredd.Size = new System.Drawing.Size(41, 14);
            this.label_Värmebackar_Bredd.TabIndex = 1005;
            this.label_Värmebackar_Bredd.Text = "Bredd";
            this.label_Värmebackar_Bredd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Värmebackar_Hål
            // 
            this.label_Värmebackar_Hål.BackColor = System.Drawing.Color.White;
            this.label_Värmebackar_Hål.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Värmebackar_Hål.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Värmebackar_Hål.ForeColor = System.Drawing.Color.Black;
            this.label_Värmebackar_Hål.Location = new System.Drawing.Point(539, 47);
            this.label_Värmebackar_Hål.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Värmebackar_Hål.Name = "label_Värmebackar_Hål";
            this.label_Värmebackar_Hål.Size = new System.Drawing.Size(42, 14);
            this.label_Värmebackar_Hål.TabIndex = 1006;
            this.label_Värmebackar_Hål.Text = "Hål";
            this.label_Värmebackar_Hål.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Värmebackar_Hål_enhet
            // 
            this.label_Värmebackar_Hål_enhet.BackColor = System.Drawing.Color.White;
            this.label_Värmebackar_Hål_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Värmebackar_Hål_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Värmebackar_Hål_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Värmebackar_Hål_enhet.Location = new System.Drawing.Point(497, 61);
            this.label_Värmebackar_Hål_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Värmebackar_Hål_enhet.Name = "label_Värmebackar_Hål_enhet";
            this.label_Värmebackar_Hål_enhet.Size = new System.Drawing.Size(41, 14);
            this.label_Värmebackar_Hål_enhet.TabIndex = 1008;
            this.label_Värmebackar_Hål_enhet.Text = "mm";
            this.label_Värmebackar_Hål_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Värmebackar_Bredd_enhet
            // 
            this.label_Värmebackar_Bredd_enhet.BackColor = System.Drawing.Color.White;
            this.label_Värmebackar_Bredd_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Värmebackar_Bredd_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Värmebackar_Bredd_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Värmebackar_Bredd_enhet.Location = new System.Drawing.Point(539, 61);
            this.label_Värmebackar_Bredd_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Värmebackar_Bredd_enhet.Name = "label_Värmebackar_Bredd_enhet";
            this.label_Värmebackar_Bredd_enhet.Size = new System.Drawing.Size(42, 14);
            this.label_Värmebackar_Bredd_enhet.TabIndex = 1007;
            this.label_Värmebackar_Bredd_enhet.Text = "mm";
            this.label_Värmebackar_Bredd_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Svetsning_Empty_1
            // 
            this.label_Svetsning_Empty_1.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Main.SetColumnSpan(this.label_Svetsning_Empty_1, 4);
            this.label_Svetsning_Empty_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_Empty_1.Enabled = false;
            this.label_Svetsning_Empty_1.Font = new System.Drawing.Font("Arial", 8F);
            this.label_Svetsning_Empty_1.Location = new System.Drawing.Point(375, 76);
            this.label_Svetsning_Empty_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsning_Empty_1.Name = "label_Svetsning_Empty_1";
            this.label_Svetsning_Empty_1.Size = new System.Drawing.Size(206, 19);
            this.label_Svetsning_Empty_1.TabIndex = 1028;
            this.label_Svetsning_Empty_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Svetsning_Empty_2
            // 
            this.label_Svetsning_Empty_2.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Main.SetColumnSpan(this.label_Svetsning_Empty_2, 4);
            this.label_Svetsning_Empty_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Svetsning_Empty_2.Enabled = false;
            this.label_Svetsning_Empty_2.Font = new System.Drawing.Font("Arial", 8F);
            this.label_Svetsning_Empty_2.Location = new System.Drawing.Point(375, 116);
            this.label_Svetsning_Empty_2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Svetsning_Empty_2.Name = "label_Svetsning_Empty_2";
            this.label_Svetsning_Empty_2.Size = new System.Drawing.Size(206, 19);
            this.label_Svetsning_Empty_2.TabIndex = 1028;
            this.label_Svetsning_Empty_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Processkort_Svetsning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "Processkort_Svetsning";
            this.Size = new System.Drawing.Size(841, 136);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Svetsning_Empty_3;
        private TextBox tb_Pinne_OD_PTFE_nom;
        private TextBox tb_Värmebackar_Bredd_nom;
        private TextBox tb_Värmebackar_Hål_nom;
        private TextBox tb_Pinne_OD_Stål_nom;
        private TextBox tb_Temp_nom;
        private TextBox tb_Tid_Bindvärme_nom;
        private TextBox tb_Tid_Kylluft_nom;
        private TextBox tb_Svetsförflyttning_nom;
        private TextBox tb_Svetsförflyttning_max;
        private TextBox tb_Tid_Bindvärme_max;
        private TextBox tb_Tid_Kylluft_max;
        private TextBox tb_Tid_Kylluft_min;
        private TextBox tb_Temp_min;
        private TextBox tb_Temp_max;
        private TextBox tb_Tid_Bindvärme_min;
        private TextBox tb_Svetsförflyttning_min;
        private TextBox tb_Tid_Förvärme_max;
        private TextBox tb_Tid_Förvärme_nom;
        private TextBox tb_Tid_Förvärme_min;
        private Label label_Svetsning_Maskinparametrar;
        private Label label_Tid_Förvärme;
        private Label label_Tid_Förvärme_enhet;
        private Label label_Tid_Bindvärme;
        private Label label_SvetsFörflyttning;
        private Label label_Svetsförflyttning_enhet;
        private Label label_Tid_Bindvärme_enhet;
        private Label label_Tid_Kylluft;
        private Label label_Tid_Kylluft_enhet;
        private Label label_Svetsning_MIN;
        private Label label_Svetsning_NOM;
        private Label label_Svetsning_MAX;
        private Label label_Temp;
        private Label label_Pinne_OD_PTFE_enhet;
        private Label label_Temp_enhet;
        private Label label_Pinne_OD;
        private Label label_Pinne_OD_Stål;
        private Label label_Pinne_OD_PTFE;
        private Label label_Pinne_OD_Stål_enhet;
        private Label label_Värmebackar;
        private Label label_Värmebackar_Bredd;
        private Label label_Värmebackar_Hål;
        private Label label_Värmebackar_Hål_enhet;
        private Label label_Värmebackar_Bredd_enhet;
        private Label label_Svetsning_Empty_1;
        private Label label_Svetsning_Empty_2;
        private Label label_Svets;
        private Label label_Empty_2;
        private Label label_Maskinparametrar_Datum;
        private Label label_Maskinparametrar_Tid;
        private Label label_Maskinparametrar_AnstNr;
        private Label label3;
        private Label label_Empty_8;
    }
}
