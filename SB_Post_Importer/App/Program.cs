using System;
using SB_Post_Importer.App.Importer;

namespace SB_Post_Importer.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Magic.Believe();

            if (TmpTest.Enabled)
                TmpTest.Execute();
            using (var importer =
                new ExcelImporter(Constants.ExcelBookPath, Constants.ReportPath))
            {
                importer.Main();
            }

            Console.ReadKey(true);
        }
    }
}