using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    public partial class PC_Slipning_TEF : UserControl
    {
        private Control[] AllControls
        {
            get
            {
                var ctrl = new Control[]
                {
                    tb_Matarhjul_Hastighet_nom, tb_Matarhjul_Vinkel_min, tb_Matarhjul_Vinkel_nom, tb_Matarhjul_Vinkel_max, tb_Helix_Vinkel_nom, tb_Bladhöjd_min, tb_Bladhöjd_nom, tb_Bladhöjd_max,
                    tb_Arbetsblad_min, tb_Arbetsblad_nom, tb_Arbetsblad_max, tb_Chimshöjd_nom, cb_Dragprov_Enhet
                };
                return ctrl;
            }
        }


        public PC_Slipning_TEF()
        {
            InitializeComponent();
        }

        public void Clear_Data()
        {
            cb_Dragprov_Enhet.SelectedIndex = -1;

            foreach (Control control in tlp_Main.Controls)
                if (control is TextBox tb)
                    tb.Clear();
        }

        public void Load_Data()
        {
            if (Order.PartID is null)
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                            SELECT Matarhjul_Hastighet_nom, Matarhjul_Vinkel_min, Matarhjul_Vinkel_nom, Matarhjul_Vinkel_max, Helix_Vinkel_nom, Bladhöjd_min, Bladhöjd_nom, Bladhöjd_max, 
                                Arbetsblad_min, Arbetsblad_nom, Arbetsblad_max, Chimshöjd_nom, Dragprov_enhet
                            FROM Processkort_Slipning WHERE PartID = @partID ";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partID", Order.PartID);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    for (var i = 0; i < AllControls.Length; i++)
                        AllControls[i].Text = reader[i].ToString();
            }
        }
        public void Save_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    BEGIN TRANSACTION
                        INSERT INTO Processkort_Slipning (PartID, Matarhjul_Hastighet_nom, Matarhjul_Vinkel_min, Matarhjul_Vinkel_nom, Matarhjul_Vinkel_max, Helix_Vinkel_nom, Bladhöjd_min, Bladhöjd_nom, Bladhöjd_max, Arbetsblad_min, 
                            Arbetsblad_nom, Arbetsblad_max, Chimshöjd_nom, Dragprov_enhet)

                        VALUES (@partid, @mathjul_hast_nom, @mathjul_Vinkel_min, @mathjul_Vinkel_nom, @mathjul_Vinkel_max, @helix_vinkel_nom,
                            @blad_min, @blad_nom, @blad_max, @arbetsblad_min, @arbetsblad_nom, @arbetsblad_max, @chims_nom, @dragprov_enhet)
                        {Manage_Processcards.INSERT_INTO_Processkort_Main}

                    COMMIT TRANSACTION";

                var cmd = new SqlCommand(query, con);
                Add_Parameters(cmd, parameters);
                con.Open();
                Manage_Processcards.Execute_cmd(cmd, ref IsOk);
            }
        }
        public void Update_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    BEGIN TRANSACTION
                        UPDATE Processkort_Slipning
                        SET Matarhjul_Hastighet_nom = @mathjul_hast_nom, 
                            Matarhjul_Vinkel_min = @mathjul_Vinkel_min, Matarhjul_Vinkel_nom = @mathjul_Vinkel_nom, Matarhjul_Vinkel_max = @mathjul_Vinkel_max, 
                            Helix_Vinkel_nom = @helix_vinkel_nom, Bladhöjd_min = @blad_min, Bladhöjd_nom = @blad_nom, Bladhöjd_max = @blad_max, 
                            Arbetsblad_min = @arbetsblad_min, Arbetsblad_nom = @arbetsblad_nom, Arbetsblad_max = @arbetsblad_max, Chimshöjd_nom = @chims_nom, Dragprov_enhet = @dragprov_enhet
                        WHERE PartID = @partid
                    
                        {Manage_Processcards.UPDATE_Processkort_Main}
                     
                    COMMIT TRANSACTION";
                var cmd = new SqlCommand(query, con);
                Add_Parameters(cmd, parameters);
                con.Open();
                Manage_Processcards.Execute_cmd(cmd, ref IsOk);
            }
        }
        private void Add_Parameters(SqlCommand cmd, List<SqlParameter> parameters)
        {
            cmd.Parameters.AddRange(parameters.ToArray());

            SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
            cmd.Parameters.AddWithValue("@partgroupid", Order.PartGroupID);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtype", Order.ProdType);

            cmd.Parameters.AddWithValue("@mathjul_hast_nom", tb_Matarhjul_Hastighet_nom.Text);
            cmd.Parameters.AddWithValue("@mathjul_Vinkel_min", tb_Matarhjul_Vinkel_min.Text);
            cmd.Parameters.AddWithValue("@mathjul_Vinkel_nom", tb_Matarhjul_Vinkel_nom.Text);
            cmd.Parameters.AddWithValue("@mathjul_Vinkel_max", tb_Matarhjul_Vinkel_max.Text);
            cmd.Parameters.AddWithValue("@helix_vinkel_nom", tb_Helix_Vinkel_nom.Text);
            cmd.Parameters.AddWithValue("@blad_min", tb_Bladhöjd_min.Text);
            cmd.Parameters.AddWithValue("@blad_nom", tb_Bladhöjd_nom.Text);
            cmd.Parameters.AddWithValue("@blad_max", tb_Bladhöjd_max.Text);
            cmd.Parameters.AddWithValue("@arbetsblad_min", tb_Arbetsblad_min.Text);
            cmd.Parameters.AddWithValue("@arbetsblad_nom", tb_Arbetsblad_nom.Text);
            cmd.Parameters.AddWithValue("@arbetsblad_max", tb_Arbetsblad_max.Text);
            cmd.Parameters.AddWithValue("@chims_nom", tb_Chimshöjd_nom.Text);
            cmd.Parameters.AddWithValue("@dragprov_enhet", cb_Dragprov_Enhet.Text);
        }
    }
}
