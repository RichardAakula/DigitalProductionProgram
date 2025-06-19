using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Övrigt
{
    public partial class RevisionInfo : Form
    {
        public RevisionInfo()
        { 
            InitializeComponent();
            
            Text = "Revisionsinfo för artikelnr: " + Order.PartNumber;
            HämtaInfo_dgv_Revision();
            dgv_Revision.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_Revision.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Revision.Columns[0].Width = 50;
            dgv_Revision.Columns[1].Width = 607;
            dgv_Revision.Columns[2].Width = 90;
        }
        public void HämtaInfo_dgv_Revision()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                const string query = "SELECT RevNr, RevInfo, UpprättatAv_Sign_AnstNr FROM Processcard.MainData WHERE PartGroupID = @partgroupid  ORDER BY RevNr DESC";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.Int(cmd.Parameters, "@partgroupid", Order.PartGroupID);
                
                var reader = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(reader);
                dgv_Revision.DataSource = table;
            }
        }
    }
}