using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Browse_Protocols
{
    public partial class OrderList : Form
    {

        //------------------------------------------------------------------------------------

       




        public OrderList()
        {
            InitializeComponent();
            
            dt_Orderlist = new DataTable();
            dt_Orderlist.Columns.Add("ArtikelNr", typeof(string));
            dt_Orderlist.Columns.Add("PartID", typeof(int));
            dt_Orderlist.Columns.Add("OrderNr", typeof(string));
            dt_Orderlist.Columns.Add("OP", typeof(string));
            dt_Orderlist.Columns.Add("OrderID", typeof(int));
            dt_Orderlist.Columns.Add("RevNr", typeof(string));
            dt_Orderlist.Columns.Add("Datum", typeof(string));
            dt_Orderlist.Columns.Add("key", typeof(string));
            
            DataColumn[] keyColumn = new DataColumn[1];
            keyColumn[0] = dt_Orderlist.Columns["key"];
            dt_Orderlist.PrimaryKey = keyColumn;
            
        }

        private DataGridView dgv;
        public DataTable dt_Orderlist;
        public void Add_OrderNr_To_List(Manage_WorkOperation.WorkOperations arbetsOperation, string artikelnr, int? artikelID, string orderNr,  int? orderID, string revNr, string datum, DataGridView dgv)
        {
            this.dgv = dgv;

            var row = dt_Orderlist.NewRow();
            row["PartNr"] = artikelnr;
            row["PartID"] = artikelID;
            row["OrderNr"] = orderNr;
            row["OrderID"] = orderID;
            row["RevNr"] = revNr;
            row["Datum"] = datum;
            row["key"] = artikelnr + artikelID + orderNr +  orderID + revNr + datum;

            try
            {
                dt_Orderlist.Rows.Add(row);
            }
            catch { return; }

            dgv_List_Orders.DataSource = dt_Orderlist;
            dgv_List_Orders.Columns["key"].Visible = false;
            dgv_List_Orders.Columns["PartID"].Visible = false;
            dgv_List_Orders.Columns["OrderID"].Visible = false;

            Width = dgv_List_Orders.Columns[0].Width + dgv_List_Orders.Columns[2].Width + dgv_List_Orders.Columns[3].Width + dgv_List_Orders.Columns[5].Width + dgv_List_Orders.Columns[6].Width + dgv_List_Orders.Columns[7].Width + 240;
            dgv_List_Orders.Width = Width - 270;
        }

        private Color lbl_orgColor;
        private void Labels_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl_orgColor = lbl.ForeColor;
            lbl.ForeColor = Color.DodgerBlue;
        }
        private void Labels_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = lbl_orgColor;
        }


        private void Remove_FromList_Click(object sender, EventArgs e)
        {
            dt_Orderlist.Rows[dgv_List_Orders.CurrentCell.RowIndex].Delete();
            dgv_List_Orders.DataSource = dt_Orderlist;
        }
        private void Avbryt_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            dt_Orderlist = null;
            Dispose();
            Close();
        }
    }
}
