using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.User
{
    internal class CheckAuthority
    {
        public enum TemplateAuthorities
        {
            ApproveLineClearancePTFE_Kragning = 1,
            ManageProcesscards = 2,
            DeleteProcessCards = 3,
            ApproveProcessCard = 4,
            ChangeDatabaseSettings = 5,
            ChangeComputerForMeasurementOnly = 6,
            AddUser = 7,
            DeleteOrder = 8,
            EditOrder = 9,
            FinishIncompleteOrder = 10,
            ReportToProductionSupport = 11,
            CreateTestOrder = 12,
            ChangePartLists = 13,
            ManageMeasurementInstrumentTemplates = 14,
            StartOrderWithoutQA_sign = 15,
            StartOrderNr_5_WithoutProcesscard = 16,
            StartOrderNr_7_WithoutProcesscard = 17,
            EditUser = 18,
            DeleteUser = 19,
            ConfigureCustomMail = 20,
            ChangeColorHS_Machine = 21,
            Edit_QC_Feedback = 22,
            ChooseFreelyFromListsProtocol = 23,
            ChangeSettingsZumbach = 24,
            DeleteSelectedDataZumbach = 25,
            ManageWorkoperations = 26,
            ExceedToleranceProcesscard = 27,
            ManageTemplates = 28,
            StartOrderNr_6_WithoutProcesscard = 29,
            ManageOrderCounter = 30
        }
        public enum TemplateWorkoperation
        {
            SetPointsForMaterial = 1,
            SaveMeasurepointsWithPrefab = 2,
            LoadPrefabWithoutOperation = 3,
            UsingExtraLineClearance = 4,
            UsingZumbach = 5,
            ManufacturesHeatShrink = 6,
            UsingCandleFilter_Screenpackage = 7,
            IsUsingAQL_Module = 8,
            SortMeasurementsDESC = 9,
            ExtruderRegister = 10,
            TipsAndTrix = 12,
            CleanedCyliner = 13,
        }
        public enum TemplateFactory
        {
            AutoTestJira  = 1,
            MyAnalysis = 2
        }

        private static Dictionary<int, string> Authorities_Template
        {
            get
            {
                var dict = new Dictionary<int, string>();
                
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT ID, CodeText FROM Authorities.TemplateAuthorities ORDER BY ID";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int.TryParse(reader[0].ToString(), out var id);
                        var codetext = reader[1].ToString();
                        dict.Add(id, codetext);
                    }
                }
                return dict;
            }
        }

        public static bool IsRoleAuthorized(Enum templateAuthority, bool IsOkWarnUser = true)
        {
            bool isAuthorized;
            var val = Convert.ChangeType(templateAuthority, templateAuthority.GetTypeCode());
            using ( var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT * FROM Authorities.CustomRoles WHERE TemplateID = @id AND Role = @role";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", (int)val);
                    SQL_Parameter.String(cmd.Parameters, "@role", Person.Role);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        isAuthorized = reader.HasRows;
                    }
                }
            }


            if (isAuthorized == false && IsOkWarnUser)
            {
                try
                {
                    InfoText.Show($"{LanguageManager.GetString("authority_Check_1")}:\n" +
                                  $"{Authorities_Template[(int)val]}\n" +
                                  $"{LanguageManager.GetString("authority_Check_2")}", CustomColors.InfoText_Color.Warning, null);
                }
                catch (Exception e)
                {
                    return false;
                }
               
            }
                
            return isAuthorized;
        }
        public static bool IsWorkoperationAuthorized(Enum templateWorkoperation)
        {
            var val = Convert.ChangeType(templateWorkoperation, templateWorkoperation.GetTypeCode());
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT * FROM Authorities.CustomWorkoperation WHERE TemplateID = @id AND Workoperation = @workoperation";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (int)val);
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }

            return false;
        }
        public static bool IsFactoryAuthorized(Enum templateFactory)
        {
            var val = Convert.ChangeType(templateFactory, templateFactory.GetTypeCode());
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT * FROM Authorities.CustomFactory WHERE TemplateID = @id AND Factory = @factory";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (int)val);
                cmd.Parameters.AddWithValue("@factory", Monitor.Monitor.factory.ToString());
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            return false;
        }

        public static bool IsOkManageAuthorization
        {
            get
            {
                switch (Person.Role)
                {
                    case "SuperAdmin":
                    case "ProcessEngineer":
                    case "ProcessIngenjör":
                    case "Arbetsledare":
                    case "Kvalitetsdirektör":
                    case "QualityDirector":
                    case "Quality Engineer":
                        break;
                    default:
                        InfoText.Show(LanguageManager.GetString("authority_Check_3"), CustomColors.InfoText_Color.Info, null);
                        return false;
                }

                return true;
            }
        }
        public static bool IsOkReadMyAnalysis
        {
            get
            {
                if (Person.IsOperatorReadMyAnalysis == false && Person.Role !="QA" && Person.Role != "SuperAdmin" & !string.IsNullOrEmpty(Person.EmployeeNr) && Monitor.Monitor.factory == Monitor.Monitor.Factory.Godby)
                    return true;
                return false;
            }

        }
        public static bool Is_OkToShowObject
        {
            get
            {
                switch (Monitor.Monitor.factory)
                {
                    case Monitor.Monitor.Factory.Godby:
                    case Monitor.Monitor.Factory.Holding:
                        return true;
                    case Monitor.Monitor.Factory.Thailand:
                    default:
                        return false;
                }
                
            }
            
        }
        public static bool IsOkShowDeveloperMenu => Person.Role == "SuperAdmin";
       
    }
}