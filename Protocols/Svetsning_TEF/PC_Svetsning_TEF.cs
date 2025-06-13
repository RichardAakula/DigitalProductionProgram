using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Svetsning_TEF
{
    public partial class PC_Svetsning_TEF : UserControl
    {
        private Control[] AllControls
        {
            get
            {
                var ctrl = new Control[] { tb_Tid_Förvärme_min,tb_Tid_Förvärme_nom, tb_Tid_Förvärme_max, tb_Svetsförflyttning_min, tb_Svetsförflyttning_nom, tb_Svetsförflyttning_max, tb_Tid_Bindvärme_min,tb_Tid_Bindvärme_nom, tb_Tid_Bindvärme_max,
                    tb_Tid_Kylluft_min, tb_Tid_Kylluft_nom, tb_Tid_Kylluft_max, tb_Temp_min, tb_Temp_nom, tb_Temp_max, tb_Pinne_OD_Stål_nom, tb_Pinne_OD_PTFE_nom, tb_Värmebackar_Bredd_nom, tb_Värmebackar_Hål_nom};
                return ctrl;
            }
        }
       
        public string? MIN_Value(string name)
        {
            switch (name)
            {
                case string a when a.Contains("Förvärme"):
                    return tb_Tid_Förvärme_min.Text;
                case string a when a.Contains("Svetsförflyttning"):
                    return tb_Svetsförflyttning_min.Text;
                case string a when a.Contains("Bindvärme"):
                    return tb_Tid_Bindvärme_min.Text;
                case string a when a.Contains("Kylluft"):
                    return tb_Tid_Kylluft_min.Text;
                case string a when a.Contains("Temp"):
                    return tb_Temp_min.Text;
            }
            return null;
        }
        public string? MAX_Value(string name)
        {

            switch (name)
            {
                case string a when a.Contains("Förvärme"):
                    return tb_Tid_Förvärme_max.Text;
                case string a when a.Contains("Svetsförflyttning"):
                    return tb_Svetsförflyttning_max.Text;
                case string a when a.Contains("Bindvärme"):
                    return tb_Tid_Bindvärme_max.Text;
                case string a when a.Contains("Kylluft"):
                    return tb_Tid_Kylluft_max.Text;
                case string a when a.Contains("Temp"):
                    return tb_Temp_max.Text;
            }
            return null;
        }

        public PC_Svetsning_TEF()
        {
            InitializeComponent();
        }

        public void Lock_Controls()
        {
            foreach (Control control in tlp_Main.Controls)
                if (control is TextBox tb)
                    tb.ReadOnly = true;
        }
        public void Clear_Data()
        {
            foreach (Control control in tlp_Main.Controls)
                if (control is TextBox tb)
                    tb.Clear();
        }

        public void Load_Data()
        {
            if (Order.PartID is null)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                            SELECT Tid_Förvärme_min, Tid_Förvärme_nom, Tid_Förvärme_max, Svetsförflyttning_min, Svetsförflyttning_nom, Svetsförflyttning_max, Tid_Bindvärme_min, Tid_Bindvärme_nom, 
                                Tid_Bindvärme_max, Tid_Kylluft_min, Tid_Kylluft_nom, Tid_Kylluft_max, Temp_min, Temp_nom, Temp_max, Pinne_OD_Stål_nom, Pinne_OD_PTFE_nom, Värmebackar_Bredd_nom, Värmebackar_Hål_nom
                            FROM Processkort_Svetsning WHERE PartID = @partID";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@partID", Order.PartID);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (var i = 0; i < AllControls.Length; i++)
                {
                    if (string.IsNullOrEmpty(reader[i].ToString()))
                        AllControls[i].Text = "N/A";
                    else
                        AllControls[i].Text = reader[i].ToString();
                }
            }
        }
        public void Save_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    BEGIN TRANSACTION
                        INSERT INTO Processkort_Svetsning (PartID, Tid_Förvärme_min, Tid_Förvärme_nom, Tid_Förvärme_max, Svetsförflyttning_min, Svetsförflyttning_nom, Svetsförflyttning_max, Tid_Bindvärme_min, Tid_Bindvärme_nom, 
                            Tid_Bindvärme_max, Tid_Kylluft_min, Tid_Kylluft_nom, Tid_Kylluft_max, Temp_min, Temp_nom, Temp_max, Pinne_OD_Stål_nom, Pinne_OD_PTFE_nom, Värmebackar_Bredd_nom, Värmebackar_Hål_nom)
                        VALUES(@partID, @tid_För_min, @tid_För_nom, @tid_För_max, @svets_min, @svets_nom, @svets_max, @tid_Bind_min, @tid_Bind_nom, @tid_Bind_max, 
                            @tid_Kyl_min, @tid_Kyl_nom, @tid_Kyl_max, @temp_min, @temp_nom, @temp_max, @pinne_OD_Stål_nom,  @pinne_OD_PTFE_nom, @värmeb_bredd_nom, @värmeb_hål_nom)

                        {Manage_Processcards.INSERT_INTO_Processkort_Main}
                    COMMIT TRANSACTION";

            var cmd = new SqlCommand(query, con);
            Add_Parameters(cmd, parameters);
            con.Open();
            Manage_Processcards.Execute_cmd(cmd, ref IsOk);
        }
        public void Update_Data(ref bool IsOk, List<SqlParameter> parameters)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    BEGIN TRANSACTION
                        UPDATE Processkort_Svetsning
                        SET Tid_Förvärme_min = @tid_För_min, Tid_Förvärme_nom = @tid_För_nom, Tid_Förvärme_max = @tid_För_max, 
                            Svetsförflyttning_min = @svets_min, Svetsförflyttning_nom = @svets_nom, Svetsförflyttning_max = @svets_max, 
                            Tid_Bindvärme_min = @tid_Bind_min, Tid_Bindvärme_nom = @tid_Bind_nom, Tid_Bindvärme_max = @tid_Bind_max, 
                            Tid_Kylluft_min = @tid_Kyl_min, Tid_Kylluft_nom = @tid_Kyl_nom, Tid_Kylluft_max = @tid_Kyl_max, 
                            Temp_min = @temp_min, Temp_nom = @temp_nom, Temp_max = @temp_max, 
                            Pinne_OD_Stål_nom = @pinne_OD_Stål_nom, Pinne_OD_PTFE_nom = @pinne_OD_PTFE_nom, Värmebackar_Bredd_nom = @värmeb_bredd_nom, Värmebackar_Hål_nom = @värmeb_hål_nom
                        WHERE PartID = @partID
                    
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

            cmd.Parameters.AddWithValue("@tid_För_min", tb_Tid_Förvärme_min.Text);
            cmd.Parameters.AddWithValue("@tid_För_nom", tb_Tid_Förvärme_nom.Text);
            cmd.Parameters.AddWithValue("@tid_För_max", tb_Tid_Förvärme_max.Text);
            cmd.Parameters.AddWithValue("@svets_min", tb_Svetsförflyttning_min.Text);
            cmd.Parameters.AddWithValue("@svets_nom", tb_Svetsförflyttning_nom.Text);
            cmd.Parameters.AddWithValue("@svets_max", tb_Svetsförflyttning_max.Text);
            cmd.Parameters.AddWithValue("@tid_Bind_min", tb_Tid_Bindvärme_min.Text);
            cmd.Parameters.AddWithValue("@tid_Bind_nom", tb_Tid_Bindvärme_nom.Text);
            cmd.Parameters.AddWithValue("@tid_Bind_max", tb_Tid_Bindvärme_max.Text);
            cmd.Parameters.AddWithValue("@tid_Kyl_min", tb_Tid_Kylluft_min.Text);
            cmd.Parameters.AddWithValue("@tid_Kyl_nom", tb_Tid_Kylluft_nom.Text);
            cmd.Parameters.AddWithValue("@tid_Kyl_max", tb_Tid_Kylluft_max.Text);
            cmd.Parameters.AddWithValue("@temp_min", tb_Temp_min.Text);
            cmd.Parameters.AddWithValue("@temp_nom", tb_Temp_nom.Text);
            cmd.Parameters.AddWithValue("@temp_max", tb_Temp_max.Text);
            cmd.Parameters.AddWithValue("@pinne_OD_Stål_nom", tb_Pinne_OD_Stål_nom.Text);
            cmd.Parameters.AddWithValue("@pinne_OD_PTFE_nom", tb_Pinne_OD_PTFE_nom.Text);
            cmd.Parameters.AddWithValue("@värmeb_bredd_nom", tb_Värmebackar_Bredd_nom.Text);
            cmd.Parameters.AddWithValue("@värmeb_hål_nom", tb_Värmebackar_Hål_nom.Text);
        }
    }
}
