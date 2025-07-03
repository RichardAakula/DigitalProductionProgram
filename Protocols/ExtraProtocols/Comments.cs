using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Protocol;
using Microsoft.Data.SqlClient;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    public partial class Comments : UserControl
    {
        private Timer? timer_SaveComments;


        public Comments()
        {
            InitializeComponent();
            Translate_Form();
        }
        private void Comments_Load(object sender, EventArgs e)
        {
            timer_SaveComments = new System.Windows.Forms.Timer();
            timer_SaveComments.Interval = 2000; // 1000 ms = 1 sekund
            timer_SaveComments.Tick += CommentSaveTimer_Tick;
            tb_Comments.TextChanged += tb_Comments_TextChanged;
        }
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_Comments });
        }

        private void Save_CommentsToDatabase()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            const string query = @"UPDATE [Order].MainData SET Comments = @comments WHERE OrderID = @orderid";
            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@comments", tb_Comments.Text);
            cmd.ExecuteNonQuery();
        }
        public void Load_Data()
        {
            if (Order.OrderID is null)
                return;

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT Comments FROM [Order].MainData WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            con.Open();
            tb_Comments.Text = cmd.ExecuteScalar().ToString();
        }
        private void CommentSaveTimer_Tick(object? sender, EventArgs e)
        {
            timer_SaveComments.Stop(); // Så det bara sparas en gång per paus
            Save_CommentsToDatabase();
        }
        private void tb_Comments_TextChanged(object? sender, EventArgs e)
        {
            if (!tb_Comments.Enabled || !Module.IsOkToSave)
                return;

            // Starta eller nollställ timern
            timer_SaveComments.Stop();
            timer_SaveComments.Start();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            if (timer_SaveComments?.Enabled == true)
            {
                timer_SaveComments.Stop();
                Save_CommentsToDatabase();
            }
        }
    }
}
