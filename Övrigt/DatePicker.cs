using System;
using System.Globalization;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    public partial class DatePicker : Form
    {
        public string InComingDate;
        public string OutGoingDate;

        public DatePicker(string inComingDate, bool IsOnlyDate = false)
        {
            ControlBox = false;
            InitializeComponent();
            

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            if (IsOnlyDate)
            {
                dateTimePicker1.CustomFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                dateTimePicker1.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            }
            else
            {
                dateTimePicker1.CustomFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;
                dateTimePicker1.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);
            }
            
            dateTimePicker1.MaxDate = DateTime.Now;
            InComingDate = inComingDate;
        }

        public void Ok_Click(object sender, EventArgs e)
        {
            OutGoingDate = dateTimePicker1.Text;
            Close();
        }

        public void DateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                OutGoingDate = dateTimePicker1.Text;
                Close();
            }
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            OutGoingDate = InComingDate; //Får tillbaks samma datum som tidigare
            Close();
        }
    }
}