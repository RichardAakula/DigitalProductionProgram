using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Protocol;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    public partial class Comments : UserControl
    {

        public Comments()
        {
            InitializeComponent();
            Translate_Form();
        }

        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_Comments});
        }
        public void Save_Comments(object sender, EventArgs e)
        {
            if (tb_Comments.Enabled == false || Module.IsOkToSave == false)
                return;

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            var query =
                @"UPDATE [Order].MainData SET Comments = @comments WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@comments", tb_Comments.Text);

            cmd.ExecuteNonQuery();
        }
        public void Load_Data(int? orderID = null)
        {
            if (orderID is null)
                orderID = Order.OrderID;
           
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Comments FROM [Order].MainData WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderID);
                con.Open();
                tb_Comments.Text = cmd.ExecuteScalar().ToString();
            }
            tb_Comments.TextChanged += Save_Comments;
        }
        
    }
}
