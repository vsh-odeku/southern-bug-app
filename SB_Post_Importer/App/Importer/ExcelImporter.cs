using System;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using SB_Post_Importer.App.Storage;

namespace SB_Post_Importer.App.Importer
{
    public class ExcelImporter : IDisposable
    {
        public static readonly string[] IgnoredTables =
        {
            "Koef_B0_B11_Y",
            "Koef_B12_B22_Qm",
            "Koef_A0_A19_Y",
            "Koef_A20_A39_Qm",
            "ORDIN_KTGR",
            "KONSULT_SP",
            "BAZA_INFO_METEO",
            "BAZA_INFO_HYDRO"
        };

        private static readonly Repository repo = (Repository) GlobalStorage.Get("repo");

        private readonly StreamWriter writer;
        private readonly ExcelPackage xlPackage;

        public ExcelImporter(string excelPath, string reportPath)
        {
            writer = new StreamWriter(reportPath, false, Encoding.UTF8);
            xlPackage = new ExcelPackage(new FileInfo(excelPath));
        }


        public void Dispose()
        {
            writer.NullSafeDispose();
            xlPackage.NullSafeDispose();
        }

        public void Main()
        {
            var postsImporter = new PostsImporter();
            var worksheets = xlPackage.Workbook.Worksheets;

            foreach (var sheet in worksheets)
            {
                var converter = new PostWorksheetConverter(sheet);
                var dt = converter.Convert();

                Console.Write("Processing sheet: \"{0}\" ", dt.TableName);

                if (!IgnoredTables.Contains(dt.TableName))
                {
                    postsImporter.AddDataTable(dt);
                    Console.WriteLine(" - Added");
                }
                else
                {
                    Console.WriteLine(" - Ignored");
                }
            }

            var resultDt = postsImporter.GetResultTable();
            var statements = new DbImporter().GetSqlImportStatements(resultDt);
            var sql = string.Join("\n", statements.ToArray());

            writer.WriteLine(sql);

            if (true) repo.ExecuteSql(sql);

            Console.WriteLine("\n----> Done. Check report file <----");
        }
    }
}