using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.User
{
    public partial class AuthorizationManager : Form
    {
        public enum Scenario
        {
            Roles,
            Email,
            Workoperation,
            Factory

        }
        public Scenario scenario;


        public AuthorizationManager(Scenario scenario)
        {
            InitializeComponent();
            this.scenario = scenario;
            switch (scenario)
            {
                case Scenario.Roles:
                    UpdateGUI_Roles();
                    Load_TemplateAuthorities();
                    if (CheckAuthority.IsOkManageAuthorization)
                        return;
                    break;
                case Scenario.Email:
                    UpdateGUI_Email();
                    if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ConfigureCustomMail))
                        return;
                    break;
                case Scenario.Workoperation:
                    UpdateGUI_Workoperation();
                    if (CheckAuthority.IsOkManageAuthorization)
                        return;
                    break;
                case Scenario.Factory:
                    UpdateGUI_Factory();
                    if (CheckAuthority.IsOkManageAuthorization)
                        return;
                    break;
            }

            dgv_Details.Enabled = false;
            btn_Remove.Visible = false;
            btn_Add.Visible = false;
        }

        private void UpdateGUI_Roles()
        {
            dgv_Template.Columns[0].HeaderText = LanguageManager.GetString("Menu_User_Authorities");
            dgv_Details.Columns[0].HeaderText = LanguageManager.GetString("role");
            btn_Remove.Text = LanguageManager.GetString("btn_AuthoritiesRemoveRole");
            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddRole");
            
        }
        private void UpdateGUI_Users()
        {
            dgv_Details.Columns[0].HeaderText = LanguageManager.GetString("Menu_User");
            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddUser");
            Load_Users();
        }
        private void UpdateGUI_Email()
        {
            dgv_Template.Columns[0].HeaderText = LanguageManager.GetString("customMail");
            dgv_Details.Columns[0].HeaderText = "E-Mail";
            btn_Remove.Text = LanguageManager.GetString("btn_AuthoritiesRemoveMail");
            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddEmail");
            Load_TemplateCustomMail();
        }
        private void UpdateGUI_Workoperation()
        {
            dgv_Template.Columns[0].HeaderText = LanguageManager.GetString("customWorkoperation");
            dgv_Details.Columns[0].HeaderText = LanguageManager.GetString("label_Workoperation");
            btn_Remove.Text = LanguageManager.GetString("btn_AuthoritiesRemoveWorkoperation");
            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddWorkoperation");
            Load_TemplateWorkoperations();
        }
        private void UpdateGUI_Factory()
        {
            dgv_Template.Columns[0].HeaderText = LanguageManager.GetString("customFactory");
            dgv_Details.Columns[0].HeaderText = LanguageManager.GetString("label_Factory");
            btn_Remove.Text = LanguageManager.GetString("btn_AuthoritiesRemoveFactory");
            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddFactory");
            Load_TemplateFactory();
        }

        private void Load_TemplateAuthorities()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT CodeText, IsUserNameOnly, Info FROM Authorities.TemplateAuthorities ORDER BY CodeText";
            var cmd = new SqlCommand(query, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                dgv_Template.Rows.Add(reader["CodeText"].ToString(), reader["IsUserNameOnly"].ToString(), reader["Info"]);
        }
        private void Load_TemplateCustomMail()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT CodeText, Info FROM Authorities.TemplateMail ORDER BY ID";
            var cmd = new SqlCommand(query, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                dgv_Template.Rows.Add(reader["CodeText"].ToString(), null, reader["Info"].ToString());
        }
        private void Load_TemplateWorkoperations()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT CodeText, Info FROM Authorities.TemplateWorkoperation ORDER BY ID";
            var cmd = new SqlCommand(query, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                dgv_Template.Rows.Add(reader["CodeText"].ToString(), null, reader["Info"].ToString());
        }
        private void Load_TemplateFactory()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT CodeText, Info FROM Authorities.TemplateFactory ORDER BY ID";
                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgv_Template.Rows.Add(reader["CodeText"].ToString(), null, reader["Info"].ToString());
            }
        }

        private void Load_Users()
        {
            if (dgv_Template.CurrentCell is null)
                return;
            dgv_Details.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Name 
                    FROM Authorities.CustomNames
                    WHERE TemplateID = (SELECT ID FROM Authorities.TemplateAuthorities WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgv_Details.Rows.Add(reader[0].ToString());
            }

            dgv_Details.ClearSelection();
        }
        private void Load_Roles()
        {
            if (dgv_Template.CurrentCell is null)
                return;
            dgv_Details.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Role 
                    FROM Authorities.CustomRoles
                    WHERE TemplateID = (SELECT ID FROM Authorities.TemplateAuthorities WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgv_Details.Rows.Add(reader[0].ToString());
            }
            dgv_Details.ClearSelection();
        }
        private void Load_Emails()
        {
            if (dgv_Template.CurrentCell is null)
                return;
            dgv_Details.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT Mail 
                    FROM Authorities.CustomMail
                    WHERE TemplateID = (SELECT ID FROM Authorities.TemplateMail WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgv_Details.Rows.Add(reader[0].ToString());
            }
            dgv_Details.ClearSelection();
        }
        private void Load_WorkOperation()
        {
            if (dgv_Template.CurrentCell is null)
                return;
            dgv_Details.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT Workoperation 
                    FROM Authorities.CustomWorkoperation
                    WHERE TemplateID = (SELECT ID FROM Authorities.TemplateWorkoperation WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgv_Details.Rows.Add(reader[0].ToString());
            }
            dgv_Details.ClearSelection();
        }
        private void Load_Factory()
        {
            if (dgv_Template.CurrentCell is null)
                return;
            dgv_Details.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT Factory 
                    FROM Authorities.CustomFactory
                    WHERE TemplateID = (SELECT ID FROM Authorities.TemplateFactory WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgv_Details.Rows.Add(reader[0].ToString());
            }
            dgv_Details.ClearSelection();
        }
        private void Template_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            switch (scenario)
            {
                case Scenario.Roles:
                    bool.TryParse(dgv_Template.Rows[e.RowIndex].Cells[1].Value.ToString(), out var IsNameOnly);
                    if (IsNameOnly)
                        UpdateGUI_Users();
                    else
                    {
                        UpdateGUI_Roles();
                        Load_Roles();
                    }
                    break;
                case Scenario.Email:
                    Load_Emails();
                    break;
                case Scenario.Workoperation:
                    Load_WorkOperation();
                    break;
                case Scenario.Factory:
                    Load_Factory();
                    break;
            }
            label_Info.Text = dgv_Template.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
       

        private void Add_Click(object sender, EventArgs e)
        {
            switch (scenario)
            {
                case Scenario.Roles:
                    Insert_Role();
                    break;
                case Scenario.Email:
                    Insert_Mail();
                    break;
                case Scenario.Workoperation:
                    Insert_Workoperation();
                    break;
                case Scenario.Factory:
                    Insert_Factory();
                    break;
            }
        }

        private void Insert_Role()
        {
            if (btn_Add.Text == LanguageManager.GetString("btn_AuthoritiesAddUser"))
            {
                var choose_Item = new Choose_Item(Person.List_Users(false), new Control[] { btn_Add }, false);
                choose_Item.ShowDialog();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    INSERT INTO Authorities.CustomNames (TemplateID, Name)
                    VALUES ((SELECT ID FROM Authorities.TemplateAuthorities WHERE CodeText = @codetext), @name)";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                    cmd.Parameters.AddWithValue("@name", btn_Add.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddUser");
                Load_Users();
            }
            else
            {
                var roles = Person.List_Roles.Select(x => x.ToString()).ToList();

                var choose_Item = new Choose_Item(roles, new Control[] { btn_Add }, false);
                choose_Item.ShowDialog();
                if (btn_Add.Text == LanguageManager.GetString("btn_AuthoritiesAddRole"))
                    return;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    INSERT INTO Authorities.CustomRoles (TemplateID, Role)
                    VALUES ((SELECT ID FROM Authorities.TemplateAuthorities WHERE CodeText = @codetext), @role)";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                    cmd.Parameters.AddWithValue("@role", btn_Add.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddRole");
                Load_Roles();
            }
        }
        private void Insert_Mail()
        {
            var emails = Person.List_MailAddress.Select(x => x.ToString()).ToList();
            var choose_Item = new Choose_Item(emails, new Control[] { btn_Add }, false, true);
            choose_Item.ShowDialog();
            if (btn_Add.Text == LanguageManager.GetString("btn_AuthoritiesAddEmail"))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    INSERT INTO Authorities.CustomMail (TemplateID, Mail)
                    VALUES ((SELECT ID FROM Authorities.TemplateMail WHERE CodeText = @codetext), @mail)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                cmd.Parameters.AddWithValue("@mail", btn_Add.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddEmail");
            Load_Emails();
        }
        private void Insert_Workoperation()
        {
            var workoperations = Manage_WorkOperation.List_Workoperations.Select(x => x.ToString()).ToList();

            var choose_Item = new Choose_Item(workoperations, new Control[] { btn_Add }, false);
            choose_Item.ShowDialog();
            if (btn_Add.Text == LanguageManager.GetString("btn_AuthoritiesAddWorkoperation"))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    INSERT INTO Authorities.CustomWorkoperation (TemplateID, Workoperation)
                    VALUES ((SELECT ID FROM Authorities.TemplateWorkoperation WHERE CodeText = @codetext),  @workoperation)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                cmd.Parameters.AddWithValue("@workoperation", btn_Add.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddWorkoperation");
            Load_WorkOperation();
        }
        private void Insert_Factory()
        {
            var factories = new List<string> { "Godby", "Thailand", "Holding"};

            var choose_Item = new Choose_Item(factories, new Control[] { btn_Add }, false);
            choose_Item.ShowDialog();
            if (btn_Add.Text == LanguageManager.GetString("btn_AuthoritiesAddFactory"))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    INSERT INTO Authorities.CustomFactory (TemplateID, Factory)
                    VALUES ((SELECT ID FROM Authorities.TemplateFactory WHERE CodeText = @codetext),  @factory)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                cmd.Parameters.AddWithValue("@factory", btn_Add.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            btn_Add.Text = LanguageManager.GetString("btn_AuthoritiesAddFactory");
            Load_Factory();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (dgv_Details.SelectedCells.Count < 1)
                return;
            switch (scenario)
            {
                case Scenario.Roles:
                    Delete_Role();
                    break;
                case Scenario.Email:
                    Delete_Mail();
                    break;
                case Scenario.Workoperation:
                    Delete_Workoperation();
                    break;
                case Scenario.Factory:
                    Delete_Factory();
                    break;
            }
        }

        private void Delete_Role()
        {

            if (btn_Add.Text == LanguageManager.GetString("btn_AuthoritiesAddUser"))
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    DELETE FROM Authorities.CustomNames
                    WHERE Name = @name AND TemplateID = (SELECT ID FROM Authorities.TemplateAuthorities WHERE CodeText = @codetext)";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                    cmd.Parameters.AddWithValue("@name", dgv_Details.CurrentCell.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                Load_Users();
               
            }
            else
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    DELETE FROM Authorities.CustomRoles
                    WHERE Role = @role AND TemplateID = (SELECT ID FROM Authorities.TemplateAuthorities WHERE CodeText = @codetext)";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                    cmd.Parameters.AddWithValue("@role", dgv_Details.CurrentCell.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Load_Roles();
            }
        }
        private void Delete_Mail()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    DELETE FROM Authorities.CustomMail
                    WHERE Mail = @mail AND TemplateID = (SELECT ID FROM Authorities.TemplateMail WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                cmd.Parameters.AddWithValue("@mail", dgv_Details.CurrentCell.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            Load_Emails();

        }
        private void Delete_Workoperation()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    DELETE FROM Authorities.CustomWorkoperation
                    WHERE Workoperation = @workoperation AND TemplateID = (SELECT ID FROM Authorities.TemplateWorkoperation WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                cmd.Parameters.AddWithValue("@workoperation", dgv_Details.CurrentCell.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Load_WorkOperation();
        }
        private void Delete_Factory()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    DELETE FROM Authorities.CustomFactory
                    WHERE Factory = @factory AND TemplateID = (SELECT ID FROM Authorities.TemplateFactory WHERE CodeText = @codetext)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", dgv_Template.CurrentCell.Value.ToString());
                cmd.Parameters.AddWithValue("@factory", dgv_Details.CurrentCell.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Load_Factory();
        }
    }
}
