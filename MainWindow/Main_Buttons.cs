using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Measure;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.LineClearance;
using DigitalProductionProgram.Statistics;
using DigitalProductionProgram.User;
using DigitalProductionProgram.Zumbach;
using Pictures = DigitalProductionProgram.OrderHantering.Pictures;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_Buttons : UserControl
    {
        private Color color_FButton;
        private bool IsArtikelCompound;


        public Main_Buttons()
        {
            InitializeComponent();

            if (Monitor.Monitor.factory == Monitor.Monitor.Factory.Thailand)
                Statistics.Visible = BrowseOldMeasureprotocol.Visible = false;
        }

       
        public void Translate_Form()
        {
            var controls = new Control[flp_Buttons.Controls.Count];
            var index = 0;
            foreach (Control control in flp_Buttons.Controls)
            {
                controls[index] = control;
                index++;
            }

            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        public void Change_Theme()
        {
           // BackColor = Teman.backColor_Buttons;

            foreach (var button in flp_Buttons.Controls.OfType<Button>())
            {
                button.BackColor = Teman.backColor_Buttons;
                button.ForeColor = Teman.foreColor_Buttons;
            }
            panel_Pictures.BackColor = Teman.backColor_Buttons;
        }
        public void Change_GUI_OrderFinished()
        {
            pb_UploadPicture.Visible = false;
            panel_Pictures.Visible = false;
            panel_Pictures.BackColor = Color.Transparent;

            flp_Buttons.BackColor = Color.FromArgb(100, 20, 44, 20);
            foreach (Control ctrl in flp_Buttons.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.BackColor = Color.FromArgb(120, Color.Black);
                    ctrl.ForeColor = Color.White;
                }
            }
        }
        public void Change_GUI_OrderNotFinished()
        {
            panel_Pictures.Visible = true;
            pb_UploadPicture.Visible = true;
        }
        public void Change_GUI_Show_Compund()
        {
            Compound.Visible = true;
            Measureprotocol.Visible = false;

        }

        public void Change_GUI_Buttons()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Change_GUI_Buttons);
            }
            else
            {
                Measureprotocol.Visible = false;
                BrowseOldMeasureprotocol.Visible = false;
                Protocol.Visible = false;
                Compound.Visible = false;
                Zumbach.Visible = false;
                Statistics.Visible = false;
                Frequency_Marking.Visible = false;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT Name, ControlText
                    FROM Workoperation.ControlVisibiltySettings as visibility
                        JOIN Workoperation.ApplicationControls as controls
                            ON visibility.ControlID = controls.ID
                    WHERE WorkOperationID = @workoperationid
                        AND ColumnIndex IS NOT NULL
                    ORDER BY ColumnIndex";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = reader[0].ToString();
                        var text = reader[1].ToString();

                        foreach (var btn in flp_Buttons.Controls.OfType<Button>())
                        {
                            if (btn.Name == name)
                            {
                                btn.Text = text;
                                btn.Visible = true;
                            }
                        }
                    }
                }

                Frequency_Marking.Visible = FrequencyMarking.IsLäcksökning;
                IsArtikelCompound = Part.IsPartNrSpecial("Kompoundering");
                if (IsArtikelCompound)
                    Change_GUI_Show_Compund();
            }
        }
        
        public void Change_GUI_Mätdator()
        {
            Control[] control = { Protocol, BrowseOldMeasureprotocol, BrowseOldOrders, Zumbach, OverviewProdlines, Statistics, Frequency_Marking, panel_Pictures };
            foreach (var ctrl in control)
                ctrl.Visible = false;

            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.UsingZumbach))
                Zumbach.Visible = true;
        }


        public static void Open_MeasureProtocol()
        {
            var fc = Application.OpenForms;
            if (fc.Cast<Form>().Any(frm => frm.Name.Contains("Sökning")))
            {
                InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_1"), CustomColors.InfoText_Color.Warning, null);
                return;
            }

            if (Order.IsOrderDone == false && Order.WorkOperation == Manage_WorkOperation.WorkOperations.Krympslangsblåsning && string.IsNullOrEmpty(Equipment.Equipment.HS_Machine))
            {
                InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_2"), CustomColors.InfoText_Color.Warning, null);
                return;
            }
            

            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
                case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
                case Manage_WorkOperation.WorkOperations.Synergy_PTFE:
                    if (LineClearance.IsLineClearanceApproved == false)
                    {
                        InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_3"), CustomColors.InfoText_Color.Bad, null);
                        return;
                    }
                    break;
                default:
                    if (Order.IsOrderDone == false && LineClearance.IsLineClearanceDone == false)
                    {
                        InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_4"), CustomColors.InfoText_Color.Bad, null);
                        return;
                    }
                    break;
            }

            var screen = Screen.FromPoint(Cursor.Position);
            if (Order.OrderNumber != null)
            {
                var form = Application.OpenForms["Measurement_Protocol"];

                if (form != null)
                {
                    form.Show();
                    form.Activate();
                }
                else
                {
                    var mp = new Measurement_Protocol
                    {
                        StartPosition = FormStartPosition.Manual,
                        Location = screen.Bounds.Location
                    };
                    mp.Show();
                    MeasureInformation.IsOpening = false;
                }
            }
            else
                InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_5"), CustomColors.InfoText_Color.Warning, null);
        }
        
        public void F1_MeasureProtocol_Click(object sender, EventArgs e)
        {
            Open_MeasureProtocol();
        }
        public void F2_Protocol_Click(object sender, EventArgs e)
        {
            Open_Protocol.Choose_Protocol(Form.ActiveForm);
        }
        public void F3_SearchOldMeasureProtocols_Click(object sender, EventArgs e)
        {
            if (BrowseOldMeasureprotocol.Visible == false)
                return;
            // Stoppa MainTimer eventuellt om det blir problem
            var screen = Screen.FromPoint(Cursor.Position);
            var sök = new BrowseMeasureProtocols
            {
                StartPosition = FormStartPosition.Manual,
                Location = screen.Bounds.Location
            };
            sök.ShowDialog();
        }
        public void F4_SearchOldProtocols(object sender, EventArgs e)
        {
            Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols = true;
            if (BrowseOldOrders.Visible == false)
                return;

            // Stoppa MainTimer eventuellt om det blir problem

            var fc = Application.OpenForms;
            if (fc.Cast<Form>().Any(frm => frm.Name.Contains("Korprotokoll") || frm.Name.Contains("Protocol") || frm.Name.Contains("Measurement")))
            {
                InfoText.Show(LanguageManager.GetString("closeProtocols"), CustomColors.InfoText_Color.Warning, null);
                return;
            }

            Order.ProdGroup = string.Empty;
            Order.Save_TempOrderInfo();
            if (string.IsNullOrEmpty(Order.OrderNumber))
                Order.WorkOperation = Manage_WorkOperation.WorkOperations.Nothing;

            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                case Manage_WorkOperation.WorkOperations.Extrudering_Grov_PTFE:
                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                case Manage_WorkOperation.WorkOperations.Hackning_PTFE:
                case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                case Manage_WorkOperation.WorkOperations.HeatShrink:
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
                case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
                case Manage_WorkOperation.WorkOperations.Skärmning:
                case Manage_WorkOperation.WorkOperations.Slipning:
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                case Manage_WorkOperation.WorkOperations.Svetsning:
                case Manage_WorkOperation.WorkOperations.Synergy_PTFE:
                   
                    var bp = new Browse_Protocols.Browse_Protocols(Order.PartNumber);
                    var cs = Screen.FromControl(this);
                    bp.Location = cs.WorkingArea.Location;
                    bp.ShowDialog();
                    break;
                
                case Manage_WorkOperation.WorkOperations.Nothing:
                    var välj = new Choose_WorkOperation_BrowseProtocols_ManageProcesscards( false, false, true,LanguageManager.GetString("browseProtocols"));
                    välj.ShowDialog();
                    break;

                default:
                    return;

            }

            Order.Restore_TempOrderInfo();
            //Laddar toleranser på nytt ifall dom ändrats i Bläddra Körprotokoll
           // Main_Form.Timer_UpdateChart_Start();
        }
        public void F5_Compund_Click(object sender, EventArgs e)
        {
            if (Order.OrderID == 0 || Order.OrderID is null ||Compound.Visible == false)
                return;
            var compound = new Protocol_Compund();
            compound.ShowDialog();
        }
        public void F6_Zumbach_Click(object sender, EventArgs e)
        {
            if (Zumbach.Visible == false)
                return;

            if ((string.IsNullOrEmpty(Order.HS_Pipe_1) || string.IsNullOrEmpty(Order.HS_Pipe_2) || string.IsNullOrEmpty(Order.HS_Pipe_3)) && !Order.IsOrderDone && CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink))
            {
                InfoText.Show(LanguageManager.GetString("zumbach_Info_1"), CustomColors.InfoText_Color.Warning, null);
                return;
            }

            if (Order.OrderNumber != null)
            {
                Main_Form.IsZumbachÖppet = true;
                var zk = new MeasureWithZumbach(Screen.FromPoint(Cursor.Position));
                zk.Show();
            }
        }
        public async void F7_OverviewProdLines_Click(object sender, EventArgs e)
        {
            // Stoppa MainTimer eventuellt om det blir problem
            Log.Activity.Start();

            Points.Add_Points(1, "Överblick Produktionslinjer");
            var öp = new Overview_ProductionLines();
            öp.ShowDialog();

            await Log.Activity.Stop("Överblick ProdLinjer");
            Cursor = Cursors.Default;
           // Main_Form.Timer_UpdateChart_Start();
        }
        public void F8_Statistics_Click(object sender, EventArgs e)
        {
            Points.Add_Points(3, "Statistik");

            var stats = new Statistik_Övrigt();
            var black = new BlackBackground("", 70);
            black.Show();
            stats.ShowDialog();
            black.Close();
        }
        public void F9_FrequencyMarking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Person.Name))
            {
                InfoText.Show("Du måste vara inloggad för att öppna frekvensmarkering.", CustomColors.InfoText_Color.Bad, null);
                return;
            }

            var frekvensmarkering = new FrequencyMarking();
            frekvensmarkering.Show();
        }


        private void UploadPicture_Click(object sender, EventArgs e)
        {
            if (Order.OrderNumber == string.Empty)
            {
                InfoText.Show(LanguageManager.GetString("uploadPicture_1"), CustomColors.InfoText_Color.Warning, null);
                return;
            }

            var dlg = new OpenFileDialog
            {
                Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*",
                Title = LanguageManager.GetString("uploadPicture_2")
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var picLocation = dlg.FileName;

                var fs = new FileStream(picLocation, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                var img = br.ReadBytes((int)fs.Length);

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"INSERT INTO [Order].Pictures
                                   VALUES (@orderid, @picture, @index)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@picture", img);
                    cmd.Parameters.AddWithValue("@index", Pictures.Total_Pictures);

                    cmd.ExecuteNonQuery();
                }

                InfoText.Show(LanguageManager.GetString("uploadPicture_3"), CustomColors.InfoText_Color.Info, null);

                if (Pictures.Total_Pictures > 0)
                {
                    panel_Pictures.Visible = true;
                    pb_LoadPicture.Visible = true;
                }
                else
                    pb_LoadPicture.Visible = false;
            }
        }
        private void TittaPåBilder_Click(object sender, EventArgs e)
        {
            var frmPic = new Pictures();
            var backGround = new BlackBackground(string.Empty, 70)
            {
                Size = new Size(Program.ScreenWidth, Height)
            };
            backGround.Show();
            frmPic.ShowDialog();
            backGround.Close();
        }

        private void Buttons_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Control)sender;
            color_FButton = lbl.BackColor;
            lbl.BackColor = Color.FromArgb(140, Color.DodgerBlue);
        }
        private void Buttons_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Control)sender;
            lbl.BackColor = color_FButton;
        }


    }
}
