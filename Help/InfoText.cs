using System;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using static DigitalProductionProgram.MainWindow.Main_RollingInformation;
using Timer = System.Timers.Timer;

namespace DigitalProductionProgram.Help
{

    public partial class InfoText : Form
    {
       


        private TextBox? tb_Return_Text;
        private NumericUpDown? num_Return_Value;

        private static InfoText? infoText;
        private static Timer? timer_close;
        private static Color clr_Fore;
        private static Image? img_Line;

        private static readonly Image[]? image;
        private static readonly string url = null!;
        private static Timer? timer_Second_ctr;
        public static Answer answer;
        public static string? return_Text;
        public static int return_Value;
        private static bool IsQuestion;
        private static List<string>? InputTextList;
       // public static Control? form { get; set; } = null!;

        public InfoText()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            timer_Second_ctr = new Timer();
            timer_close = new Timer();

            lbl_Message.ForeColor = clr_Fore;
            pb_Line_Top.Image = pb_Line_Bottom.Image = img_Line;
        }



        public static void Show(string? message, CustomColors.InfoText_Color färg, string? header, Control? Form = null, bool IsSpecialText = false)
        {
            Change_GUI_BackColor(färg);
            IsQuestion = false;
           // form = Form;
            IsQuestion = false;
            infoText = new InfoText
            {
                TopMost = true,
            };
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, infoText.lbl_Message, new object[] { true });

            Change_GUI_Header(header);
            infoText.tlp_Main.RowStyles[2].Height = 10;
            infoText.tlp_Main.RowStyles[3].Height = 0;
            infoText.btn_Yes.Visible = infoText.btn_No.Visible = false;
            infoText.lbl_Message.MaximumSize = new Size(infoText.tlp_Main.Width - 40, 0); // radbryt
            Translate_Form();

            Change_GUI_Size(message);

            if (IsSpecialText)
                SpecialText(infoText.lbl_Message, message);
            else
                infoText.lbl_Message.Text = message;


            // Vänta på att användaren stänger rutan
            infoText.ShowDialog();
        }

        public static void Question(string? Question, CustomColors.InfoText_Color color, string? header, Control? Form = null, bool IsSpecialText = false)
        {
            Change_GUI_BackColor(color);
           // form = Form;
            infoText = new InfoText();
            infoText.TopMost = true;
            if (IsSpecialText) 
                SpecialText(infoText.lbl_Message, Question);
            else
                infoText.lbl_Message.Text = Question;
            infoText.tlp_Main.RowStyles[2].Height = 10;
            infoText.tlp_Main.RowStyles[3].Height = 0;

            Translate_Form();
            Change_GUI_Header(header);
            Change_GUI_Question(true);
            Change_GUI_QuestionText(null);
            Change_GUI_Size(Question);
            infoText.ShowDialog();
        }


        private static void SpecialText(Control ctrl, string? text)
        {
            int i = 0;
            ctrl.Text = string.Empty;

            // Inaktivera redraw

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer { Interval = 30 }; // snäppet snabbare
            t.Tick += (s, e) =>
            {
                if (i < text.Length)
                    ctrl.Text += text[i++];
                else
                {
                    t.Stop();
                    // Aktivera redraw och tvinga omritning
                    ctrl.Invalidate();
                }
            };
            t.Start();
        }

        public static void PromptForText(string Question, CustomColors.InfoText_Color color, string? header, Control? Form, List<string?> list_Items)
        {
            Change_GUI_BackColor(color);
         
            infoText = new InfoText
            {
                TopMost = true
            };
            infoText.lbl_Message.Text = Question;
            InputTextList = list_Items;

            Translate_Form();
            Change_GUI_Header(header);
            Change_GUI_Return_Text();
            Change_GUI_Size(Question);
            infoText.ShowDialog();
        }
        public static void PromptForValue(string Question, CustomColors.InfoText_Color color, string? header, Control? Form, Image img)
        {
            Change_GUI_BackColor(color);
          //  form = Form;
            infoText = new InfoText
            {
                TopMost = true
            };
            infoText.lbl_Message.Text = Question;

            Translate_Form();
            Change_GUI_Header(header);
            
            if (img != null)
            {
                infoText.pb_Tube.Visible = true;
                infoText.pb_Tube.BackgroundImage = img;
            }
            
            Change_GUI_Return_Value();
            Change_GUI_Size(Question);
            infoText.ShowDialog();
        }


        public static void Translate_Form()
        {
            var controls = new Control[] {infoText.btn_Yes, infoText.btn_No };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        private static void Change_GUI_BackColor(CustomColors.InfoText_Color färg)
        {
            switch (färg)
            {
                case CustomColors.InfoText_Color.Bad:
                    clr_Fore = CustomColors.Bad_Back;
                    img_Line = Properties.Resources.Line_Bad;
                    break;
                case CustomColors.InfoText_Color.Info:
                    clr_Fore = CustomColors.Info_Back;
                    img_Line = Properties.Resources.Line_Info;
                    break;
                case CustomColors.InfoText_Color.Neutral:
                    clr_Fore = CustomColors.Neutral_Back;
                    img_Line = Properties.Resources.Line_Neutral;
                    break;
                case CustomColors.InfoText_Color.Ok:
                    clr_Fore = CustomColors.Ok_Back;
                    img_Line = Properties.Resources.Line_Ok;
                    break;
                case CustomColors.InfoText_Color.Warning:
                    clr_Fore = CustomColors.Warning_Back;
                    img_Line = Properties.Resources.Line_Warning;
                    break;
            }
        }
        private static void Change_GUI_Header(string? rubrik)
        {
            if (!string.IsNullOrEmpty(rubrik))
            {
                infoText.lbl_Rubrik.Visible = true;
                infoText.lbl_Rubrik.Text = rubrik;
                infoText.tlp_Main.RowStyles[0].Height = 20;
            }
            else
            {
                infoText.lbl_Rubrik.Visible = false;
                infoText.tlp_Main.RowStyles[1].Height = 0;
            }
        }
        private static void Change_GUI_Question(bool isQuestion)
        {
            if (isQuestion == false)
            {
                IsQuestion = false;
                infoText.btn_Yes.Visible = false;
                infoText.btn_No.Visible = false;
            }
            else
            {
                infoText.tlp_Buttons.Visible = true;
                infoText.btn_Ok.Visible = false;
            }
        }
        private static void Change_GUI_Return_Text()
        {
             infoText.tlp_Buttons.Visible = true;
             infoText.tb_Return_Text = new TextBox
             {
                 Dock = DockStyle.Left,
                 Multiline = true,
                 Width = 400,
             };
             if (InputTextList is null == false)
                 infoText.tb_Return_Text.Click += Items_Click;
             infoText.tb_Return_Text.TextChanged += (sender, e) =>
             {
                return_Text = infoText.tb_Return_Text.Text;
             };
            infoText.tlp_Main.Controls.Add(infoText.tb_Return_Text, 1, 2);
               
             infoText.btn_Yes.Visible = false;
             infoText.btn_No.Visible = true;
             infoText.btn_Ok.Visible = true;
             infoText.btn_No.Text = "Avbryt";
             infoText.tlp_Main.RowStyles[2].Height = 80;
             infoText.tlp_Main.RowStyles[3].Height = 20;
           
        }
        private static void Change_GUI_Return_Value()
        {
            return_Value = 1;
            Order.NumberOfLayers = 1;
            infoText.tlp_Buttons.Visible = true;
            infoText.num_Return_Value = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 3,
                Dock = DockStyle.Left,
                Font = new Font("Courier New", 15),
                ForeColor = Color.DarkSlateGray,
                Value = 1
            };

            infoText.num_Return_Value.ValueChanged += NumberOfLayersChanged;
            infoText.tlp_Main.Controls.Add(infoText.num_Return_Value, 1, 3);

            infoText.btn_Yes.Visible = false;
            infoText.btn_Ok.Visible = true;
            infoText.btn_No.Visible = true;

            infoText.btn_No.Text = "Avbryt";
            infoText.tlp_Main.RowStyles[2].Height = 40;
            infoText.tlp_Main.RowStyles[3].Height = 30;
            infoText.tlp_Main.RowStyles[4].Height = 40;
            
        }
        private static void Change_GUI_Bilder(Image[] img, string url_Video)
        {
            if (img != null)
            {   //Om Bilder skall visas
                try
                {
                    if (img[0] != null)
                        infoText.lbl_img_1.Visible = true;
                    if (img[1] != null)
                        infoText.lbl_img_2.Visible = true;
                    if (img[2] != null)
                        infoText.lbl_img_3.Visible = true;
                    if (img[3] != null)
                        infoText.lbl_img_4.Visible = true;
                    if (img[4] != null)
                        infoText.lbl_img_5.Visible = true;
                }
                catch { }
            }

            if (url_Video != null)
            {
                infoText.tlp_Main.RowStyles[3].Height = 50;
                infoText.lbl_Video.Visible = true;
                infoText.lbl_Video.Name = url;
            }

            if (img == null && url_Video == null)
                infoText.tlp_Main.ColumnStyles[2].Width = 0;
        }
        private static void Change_GUI_Size(string? text)
        {
            var maxWidth = infoText.tlp_Main.Width - 40; // Lite padding
            var size = TextRenderer.MeasureText(text, infoText.lbl_Message.Font, new Size(maxWidth, 0), TextFormatFlags.WordBreak);

            infoText.lbl_Message.MaximumSize = new Size(maxWidth, 0); // så den faktiskt radbryts
            infoText.lbl_Message.Height = size.Height;

            // Om rad 1 är autosize – tvinga den till rätt höjd
            infoText.tlp_Main.RowStyles[1].Height = size.Height;

           // infoText.tlp_Main.PerformLayout();

            int height = infoText.tlp_Main.PreferredSize.Height;

            if (height > 800)
                height = 800;

            infoText.Height = height + 50;
            Screen screen = Screen.FromPoint(Cursor.Position);
            infoText.Width = screen.Bounds.Width;


            //infoText.Width = form is null
            //    ? Screen.PrimaryScreen.Bounds.Width
            //    : Screen.FromControl(form).Bounds.Width;




            //var height = (int)infoText.tlp_Main.RowStyles[0].Height + (int)infoText.tlp_Main.RowStyles[1].Height + infoText.lbl_Message.Height + (int)infoText.tlp_Main.RowStyles[3].Height + (int)infoText.tlp_Main.RowStyles[4].Height + (int)infoText.tlp_Main.RowStyles[5].Height;

            //if (height > 800)
            //    height = 800;
            //infoText.Height = height + 50;

            //infoText.Width = form is null ? Screen.PrimaryScreen.Bounds.Width : Screen.FromControl(form).Bounds.Width;
        }
        
        private static void Change_GUI_QuestionText(string?[] text)
        {
            if (text is null)
                text = new[] {LanguageManager.GetString("yes"), LanguageManager.GetString("no") };
            infoText.btn_Yes.Text = text[0];
            infoText.btn_No.Text = text[1];
        }


        private static void Items_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(InputTextList, new[] { ctrl }, false);
            choose_Item.ShowDialog();
        }

       
        private static void NumberOfLayersChanged(object? sender, EventArgs e)
        {
            return_Value = (int)infoText.num_Return_Value.Value;
            switch (infoText.num_Return_Value.Value)
            {
                case 1:

                    try
                    {
                        infoText.pb_Tube.BackgroundImage = Image.FromStream(Pictures.Tubes.Neutral_1Layer);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    break;
                case 2:
                    try
                    {
                        infoText.pb_Tube.BackgroundImage = Image.FromStream(Pictures.Tubes.Neutral_2Layer);
                    }
                    catch
                    {
                        // ignored
                    }

                    break;
                case 3:
                    try
                    {
                        infoText.pb_Tube.BackgroundImage = Image.FromStream(Pictures.Tubes.Neutral_3Layer);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    break;
            }
        }
        
        private void Img_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            var int_img = int.Parse(lbl.Text.Substring(lbl.Text.Length - 1)) - 1;
            var black = new BlackBackground("", 70);
            var img = new InfoText_Image(image[int_img], null);
            black.Show();
            img.ShowDialog();
            black.Close();
        }
        private void Video_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            // var url = lbl.Name;
            var black = new BlackBackground("", 70);
            var img = new InfoText_Image(null, url);
            black.Show();
            img.ShowDialog();
            black.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.Return)
            {
                if (IsQuestion )// || IsInputText) == false)
                    Close();
            }

            if(keyData == Keys.J)
            {
                if (IsQuestion)
                {
                    answer = Answer.Yes;
                    timer_Second_ctr?.Stop();
                    Close();
                }
            }
            if (keyData == Keys.N)
            {
                if (IsQuestion)
                {
                    answer = Answer.No;
                    timer_Second_ctr?.Stop();
                    Close();
                }
            }
            
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            answer = Answer.Yes;
            timer_Second_ctr?.Stop();
            Close();
        }
        private void No_Click(object sender, EventArgs e)
        {
            answer = Answer.No;
            timer_Second_ctr?.Stop();
            return_Text = string.Empty;
           

            Close();
        }
        private void Ok_Click(object sender, EventArgs e)
        {
           // return_Text = tb_Return_Text.Text;
            Close();
        }
        private void InfoText_Close_Click(object sender, EventArgs e)
        {
            //if (IsQuestion || IsInputText || IsInputValue)
            //    return;
            //timer_Second_ctr.Stop();
            //Close();
        }

        

        private void InfoText_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (answer != Answer.No)
            {
               // if (tb_Return_Text is null == false)
                //  return_Text = tb_Return_Text.Text;
                //if (IsInputValue)
                //    return_Text = num_Return_Value.Value.ToString(CultureInfo.InvariantCulture);
            }

            Dispose();
            timer_close?.Dispose();
            timer_Second_ctr?.Dispose();
        }

      
        public enum Answer
        {
            Yes,
            No
        }

        
    }
}
