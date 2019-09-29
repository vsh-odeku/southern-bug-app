using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Model;
using DataTable = System.Data.DataTable;

namespace SouthernBug.App.Util
{
    public class ExcelExporter
    {
        private const string TmpFilesPattern = "SouthernBug_*.xlsx";

        private readonly IDataTableConnection dataTableConnection;

        public ExcelExporter(IDataTableConnection dataTableConnection)
        {
            this.dataTableConnection = dataTableConnection;
        }

        public static void DeleteTmpFiles()
        {
            try
            {
                var files = Directory.GetFiles(GetTmpFilesDir(), TmpFilesPattern);

                foreach (var path in files)
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Export(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var resultHolder = (Holder<object>) e.Argument;
            try
            {
                var exportDt = CreateExportableDataTable();
                worker.ReportProgress(33);

                var fileName = MakeExcelFile(exportDt);
                worker.ReportProgress(67);

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    OpenExcelFile(fileName);
                    worker.ReportProgress(100);

                    resultHolder.Value = true;
                }
            }
            catch (Exception exc)
            {
                resultHolder.Value = exc;
            }
        }

        private static string GetTmpFilesDir()
        {
            return Path.GetTempPath();
        }

        private DataTable CreateExportableDataTable()
        {
            var originalDt = dataTableConnection.LocalDataTable.Copy();
            var exportDt = originalDt.Copy();

            for (var i = 0; i < originalDt.Columns.Count; i++)
            {
                var columnName = originalDt.Columns[i].ColumnName;
                if (dataTableConnection.IgnoredColumns.Contains(columnName)) exportDt.Columns.Remove(columnName);
            }

            return exportDt;
        }

        private string MakeExcelFile(DataTable dt)
        {
            var workbook = new XLWorkbook();


            var ws = workbook.Worksheets.Add(dt.TableName);
            DatatableWorksheetFiller.Fill(ws, dt);
            
            var fileName = $"{GetTmpFilesDir()}SouthernBug_[{Guid.NewGuid()}].xlsx";

            workbook.SaveAs(fileName);

            return fileName;
        }

        private void OpenExcelFile(string fileName)
        {
            var excelApp = new Application {Visible = true};

            var workbooks = excelApp.Workbooks;
            var workbook = workbooks.Open(fileName);

            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(workbook);

            workbook = null;
            workbooks = null;
            excelApp = null;

            GC.Collect();
        }
    }
}