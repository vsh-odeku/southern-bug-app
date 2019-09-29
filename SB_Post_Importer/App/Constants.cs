namespace SB_Post_Importer.App
{
    public class Constants
    {
        public const string DbPath = @"C:\0_Shared\PostImporter\dbCopy.db";
        public const string ExcelBookPath = @"C:\0_Shared\PostImporter\source.xlsx";
        public const string ReportPath = @"C:\0_Shared\PostImporter\report.txt";

        public const string DbConnectionString = "Data Source=" + DbPath + "; Version=3;";
    }
}