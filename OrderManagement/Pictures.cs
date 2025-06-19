using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.OrderHantering
{
    public partial class Pictures : Form
    {
        public int imgHeight;
        private int antalBilder;
        public static int Total_Pictures
        {
            get
            {
                if (Order.OrderNumber == null)
                    return 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT COUNT(*) FROM [Order].Pictures
                        WHERE OrderID = @orderid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                    con.Open();
                    int.TryParse(cmd.ExecuteScalar().ToString(), out var antal);
                    return antal;
                }
            }
        }

        public Pictures(byte[] img = null)
        {
            InitializeComponent();
            
            if (img == null)
                LoadPicturesFromProtocol();
            else
                LoadPicture(img);
        }

        public void InitializeGUI()
        {
            var frmWidth = 0;

            foreach (PictureBox pb in flp_Main.Controls)
                frmWidth += pb.Width;
            Width = frmWidth;
        }

        private void LoadPicturesFromProtocol()
        {
            Clear_Pictures();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Picture, Picture_Index FROM [Order].Pictures WHERE OrderID = @orderid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var img = (byte[])reader[0];
                    
                    var ms = new MemoryStream(img);
                    double org_height = Image.FromStream(ms).Height;
                    double org_width = Image.FromStream(ms).Width;
                    var ratio = org_height / org_width;
                    var height = Math.Round(flp_Main.Height / ratio, 0);
                    var pb = new PictureBox
                    {
                        Image = Image.FromStream(ms),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,
                        Height = flp_Main.Height,
                        Width = (int)height,
                        Name = reader[1].ToString()
                    };
                    pb.MouseClick += pictureBox_Click;
                    pb.MouseWheel += mouseWheel_Scroll;
                    if (pb.Height > imgHeight)
                        imgHeight = pb.Height;
                    antalBilder++;
                    flp_Main.Controls.Add(pb);
                    InitializeGUI();
                }
            }

            if (antalBilder > 0)
                InitializeGUI();
        }
        private void LoadPicture(byte[] img)
        {
            Clear_Pictures();
                   
            var ms = new MemoryStream(img);
            double org_height = Image.FromStream(ms).Height;
            double org_width = Image.FromStream(ms).Width;
            var ratio = org_height / org_width;
            var height = Math.Round(flp_Main.Height / ratio, 0);
            var pb = new PictureBox
            {
                Image = Image.FromStream(ms),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Height = flp_Main.Height,
                Width = (int)height,
            };
            pb.MouseClick += pictureBox_Click;
            pb.MouseWheel += mouseWheel_Scroll;
            if (pb.Height > imgHeight)
                imgHeight = pb.Height;
           
            flp_Main.Controls.Add(pb);
            InitializeGUI();
        }
        private void Clear_Pictures()
        {
            foreach (PictureBox pb in flp_Main.Controls)
                pb.Dispose();
        }


        private string selected_Picture;
        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            selected_Picture = ctrl.Name;
            if (e.Button == MouseButtons.Right)
            {
                var strip = new ContextMenuStrip();
                strip.Items.Add("Radera Bild");
                strip.ItemClicked += cm_Item_Clicked;
                strip.Show(MousePosition.X, MousePosition.Y);
            }
        }
        private void mouseWheel_Scroll(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (flp_Main.VerticalScroll.Value > 1)
                    flp_Main.VerticalScroll.Value--;
            }
            else
                flp_Main.VerticalScroll.Value++;
        }
        private void cm_Item_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "DELETE FROM [Order].Pictures WHERE OrderID = @orderid AND Picture_Index = @index";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@index", selected_Picture);
                cmd.ExecuteNonQuery();
            }
            Close();
            var pictures = new Pictures();
            pictures.Show();
        }
        private void lbl_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

       

    }
}