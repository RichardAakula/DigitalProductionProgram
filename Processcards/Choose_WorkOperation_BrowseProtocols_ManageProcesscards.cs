using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Processcards
{
    public partial class Choose_WorkOperation_BrowseProtocols_ManageProcesscards : Form
    {
     
        private readonly bool IsProcesscard;
        private readonly bool IsOperatorStartingOrder;
        private bool IsAutoSelectTemplate;


        //private List<Manage_WorkOperation.WorkOperations> WorkOperations
        //{
        //    get
        //    {
        //        var list = new List<Manage_WorkOperation.WorkOperations>();
        //        using (var con = new SqlConnection(Database.cs_Protocol))
        //        {
        //            con.Open();
        //            var query = @"
        //            SELECT Name FROM Workoperation.Names";
        //            var cmd = new SqlCommand(query, con);
        //            var reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            { 
        //               var operation = (Manage_WorkOperation.WorkOperations)Enum.Parse(typeof(Manage_WorkOperation.WorkOperations), reader[0].ToString());
        //               list.Add(operation);
        //            }
        //        }
        //        return list;
        //    }
        //}
        private List<string> WorkOperations
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    const string query = @"
                    SELECT Name FROM Workoperation.Names";
                    var cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var operation = reader[0].ToString();
                        list.Add(operation);
                    }
                }
                return list;
            }
        }

        public Choose_WorkOperation_BrowseProtocols_ManageProcesscards(bool isProcesscard, bool isOperatorStartingOrder, bool isAutoSelectTemplate, string? headerText)
        {
            InitializeComponent();
            Translate_Form();

            Order.Save_TempOrderInfo();
            
            IsProcesscard = isProcesscard;
            IsOperatorStartingOrder = isOperatorStartingOrder;
            IsAutoSelectTemplate = isAutoSelectTemplate;
            
            label_ChoosePC_Header.Text = headerText;

            //cb_Workoperation.Text = Person.UserPreferredWorkOperation;
            //if (!string.IsNullOrEmpty(cb_Workoperation.Text) && cb_Workoperation.Text != "Ingenting" && cb_Workoperation.Text != "Nothing")
            //    chb_ChoosePC_AutoChoose.Checked = true;
            
            //Fill_cb_Workoperation();
            Fill_flp_Arbetsoperationer();
            //Order.Save_TempOrderInfo();

            //Dessa måste göras tomma så inte fel kort laddas vid tex multipla processkort
            Order.PartID = null;
            Order.ProdLine = string.Empty;
            Order.ProdType = string.Empty;
            Order.RevNr = string.Empty;

            tb_PartNr.Select();
        }


        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{ label_ChoosePC_Header, label_ChoosePC_Info_1, label_Info});
        }
       
       
        private void Fill_flp_Arbetsoperationer()
        {
            //foreach(Manage_WorkOperation.WorkOperations WorkOperation in WorkOperations)
            foreach (string WorkOperation in WorkOperations)
            {
                if (WorkOperation != "Nothing")
                {
                    var lbl = new Label
                    {
                        Text = WorkOperation.ToString(),
                        ForeColor = Color.FromArgb(112,198,176),
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        AutoSize = true,
                        Margin = new Padding(20, 5, 50, 0),
                        Cursor = Cursors.Hand,
                        
                    };
                    lbl.Click += WorkOperation_Click;
                    flp_ArbetsOperation.Controls.Add(lbl);
                }
            }
        }
        private void WorkOperation_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            Order.WorkOperation = (Manage_WorkOperation.WorkOperations)Enum.Parse(typeof(Manage_WorkOperation.WorkOperations), lbl.Text);
            Load_NewForm();
        }

      
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Load_NewForm()
        {
            if (IsProcesscard)
            {
                Manage_Processcards.IsProcesscardUnderManagement = true;
                var skapa_Uppdatera_Processkort = new Manage_Processcards(tb_PartNr.Text)
                { Location = Location };
                if (skapa_Uppdatera_Processkort.IsDisposed == false)
                    skapa_Uppdatera_Processkort.ShowDialog();
            }
            else
            {
                var bp = new Browse_Protocols.Browse_Protocols(Order.PartNumber)
                { Location = Location };
                bp.ShowDialog();
            }
        }
       

       

        private void Välj_ArbetsOperation_Hantering_Processkort_FormClosed(object sender, FormClosedEventArgs e)
        {
            Order.Restore_TempOrderInfo();
            Manage_Processcards.IsProcesscardUnderManagement = false;
        }

        private void PartNr_Click(object sender, EventArgs e)
        {
            var list = new List<string?>();
            if (IsProcesscard)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                const string query = @"
                    SELECT DISTINCT PartNr FROM Processcard.MainData                       
                    ORDER BY PartNr DESC";
                var cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() == "1234567") continue;
                    if (!list.Contains(reader[0].ToString()))
                        list.Add(reader[0].ToString());
                }
            }
            else
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                const string query = @"SELECT DISTINCT PartNr FROM [Order].MainData  
                                    ORDER BY PartNr DESC";
                var cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() == "1234567") continue; //PartNr 1234567 används när man förhandsgranskar ett tomt processkort och bör inte visas i listan
                    if (!list.Contains(reader[0].ToString()))
                        list.Add(reader[0].ToString());
                }
                reader.Close();
            }

            var choose_Item = new Choose_Item(list, new Control[] { tb_PartNr }, false);
            choose_Item.ShowDialog();

            Order.PartNumber = tb_PartNr.Text;
            Order.ProdLine = string.Empty;

            Part.Load_PartID(Order.PartNumber, IsOperatorStartingOrder, IsProcesscard, IsAutoSelectTemplate);
            //if (Order.PartID is null)
            {//Vad gör denna? Varför stoppar den här? Det kan vara till för om användare inte väljer någon operation/processkort/mall så skall programmet inte gå vidare.
                //    this.Close();
                //    return;
            }

            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Nothing)
                Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation();

            Load_NewForm();
            Close();
        }
    }
}
