using DigitalProductionProgram.DatabaseManagement;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Zumbach;

namespace DigitalProductionProgram.Measure
{
    public partial class AddMeasurePointsManually : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        

        public AddMeasurePointsManually()
        {
            InitializeComponent();
            tb_LSL.KeyPress += Public_Events.Only_Decimal_KeyPress;
            tb_LCL.KeyPress += Public_Events.Only_Decimal_KeyPress;
            tb_UCL.KeyPress += Public_Events.Only_Decimal_KeyPress;
            tb_USL.KeyPress += Public_Events.Only_Decimal_KeyPress;
        }


        private void Load_CodeNames()
        {
            //using (var con = new SqlConnection(Database.cs_Protocol))
            //{
            //    const string query = @"
            //        SELECT CodeText FROM MeasureProtocol.Template
            //        WHERE FormTemplateID = (SELECT ID FROM MeasureProtocol.FormTemplate WHERE WorkoperationID = @workoperationid) 
            //            AND Revision = (SELECT MeasureprotocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid)
            //        ORDER BY ColumnIndex";
            //    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            //    cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
            //    cmd.Parameters.AddWithValue("@orderid", Order.ID);
            //    cmd.CommandTimeout = 1800;
            //    con.Open();
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        dgv_Measurepoints.Rows.Add();
            //        dgv_Measurepoints.Rows[dgv_Measurepoints.Rows.Count - 1].Cells[0].Value = reader.GetString(0);
            //    }
               
            //}
        }

        private void AddMeasurePointsManually_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void AddMeasurePointsManually_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void AddMeasurePointsManually_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                var deltaX = e.X - lastLocation.X;
                var deltaY = e.Y - lastLocation.Y;

                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
        }

        private void SaveAndExit_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tb_LSL.Text, out var lsl))
                MeasureWithZumbach.ExpOD_LSL = lsl;
            if (double.TryParse(tb_LCL.Text, out var lcl))
                MeasureWithZumbach.ExpOD_LCL = lcl;
            if (double.TryParse(tb_UCL.Text, out var ucl))
                MeasureWithZumbach.ExpOD_UCL = ucl;
            if (double.TryParse(tb_USL.Text, out var usl))
                MeasureWithZumbach.ExpOD_USL = usl;

            _ = Activity.Stop($"Användare sparade mätpunkter. LSL = {lsl}, LCL = {lcl}, UCL = {ucl}, USL = {usl}");
            this.Close();
        }

    }
}
