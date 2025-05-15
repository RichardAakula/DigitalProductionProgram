namespace DigitalProductionProgram.DatabaseManagement
{
    internal static class Queries
    {
       
       


        
        public static string UPDATE_Order_StoppTid => "UPDATE [Order].MainData SET Date_Stop = @stop WHERE OrderID = @orderid AND Date_Stop IS NULL";

        public static string UPDATE_Reset_Processcard_Open => $"UPDATE [Order].MainData SET Processcard_Open = 'False', Processcard_Open_By_User = '', Processcard_Open_By_Computer = '' {WHERE_OrderID}";
        public static string UPDATE_Set_Processcard_Open => $"UPDATE [Order].MainData SET Processcard_Open = 'True', Processcard_Open_By_User = @användare, Processcard_Open_By_Computer = @computer {WHERE_OrderID}";


        public static string SELECT_is_Processcard_Open => "SELECT Processcard_Open FROM [Order].MainData WHERE OrderID = @orderid";
        public static string SELECT_Processcard_Open_By => $"SELECT Processcard_Open_By_User FROM [Order].MainData {WHERE_OrderID}";
        public static string SELECT_Processcard_Open_By_Computer => $"SELECT Processcard_Open_By_Computer FROM [Order].MainData {WHERE_OrderID}";

        public static string UPDATE_Settings_General_OTH_OVF => @"
            IF NOT EXISTS (SELECT * FROM Settings.General WHERE HostName = @hostname)
            BEGIN
                BEGIN TRANSACTION
                    INSERT INTO Settings.General (HostName, Company, Theme, ProdLine_LoadingPlan, MeasureOnly, Load_ZumbachControlLimits, CultureInfo)
                    SELECT @computer, Company, Theme, ProdLine_LoadingPlan, MeasureOnly, Load_ZumbachControlLimits, CultureInfo
                    FROM Settings.General
                    WHERE HostName = 'Standard'

                                    COMMIT TRANSACTION
            END";

        public static string UPDATE_Settings_General_OGO => @"
             IF NOT EXISTS (SELECT * FROM Settings.General WHERE HostName = @hostname)
                        BEGIN
                            BEGIN TRANSACTION
                                INSERT INTO Settings.General (HostName, Company, Theme, ProdLine_LoadingPlan, MeasureOnly, Load_ZumbachControlLimits, CultureInfo)
                                    SELECT @computer, Company, Theme, ProdLine_LoadingPlan, MeasureOnly, Load_ZumbachControlLimits, CultureInfo
                                    FROM Settings.General
                                    WHERE HostName = 'Standard'

                            COMMIT TRANSACTION
                        END";

        public static string WHERE_OrderID => "WHERE OrderID = @id";
       


        public static string ProdLinje(string prodlinje)
        {
            return string.IsNullOrEmpty(prodlinje) ? "ProdLine IS NULL" : "ProdLine = @prodline";
        }
    }
}