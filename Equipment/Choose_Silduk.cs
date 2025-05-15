using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalProductionProgram.Equipment
{
    public partial class Choose_Silduk : Form
    {
        private readonly DataGridViewCell cell;

        public Choose_Silduk(DataGridViewCell cell)
        {
            InitializeComponent();
            Location = new Point(MousePosition.X, MousePosition.Y);
            Translate_Form();
            this.cell = cell;
            if (cell.Value != null)
                tb_Silduk.Text = cell.Value.ToString();
        }

        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_Info_ScreenPackage, btn_Select, btn_Exit});
        }
        private void Add_Silduk_Click(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var Silduk = btn.Text;

            if (string.IsNullOrEmpty(tb_Silduk.Text))
                tb_Silduk.Text = Silduk;
            else
                tb_Silduk.Text += $"+{Silduk}";
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            tb_Silduk.Text = string.Empty;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            cell.Value = tb_Silduk.Text;
            Close();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
