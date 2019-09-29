using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using ClosedXML.Excel;
using Ninject;
using SouthernBug.App.DI;
using SouthernBug.App.Util;
using SouthernBug.App.Window.Main;
using Extensions = System.Xml.Linq.Extensions;

namespace SouthernBug.App
{
    internal class MyApp
    {
        private readonly IKernel kernel;

        public MyApp()
        {
            kernel = KernelTools.CreateKernel();
            KernelTools.PreloadLibsInBackground(kernel);
            PreloadExternalLibs();
            CleanupLastStart();
        }

        public void Run()
        {
            Form mainForm = kernel.Get<MainForm>();
            Application.Run(mainForm);
        }

        private void CleanupLastStart()
        {
            ThreadPool.QueueUserWorkItem(state => { ExcelExporter.DeleteTmpFiles(); });
        }

        private void PreloadExternalLibs()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                var wb = new XLWorkbook();
                var dt = new DataTable();
                dt.Columns.Add("Col1");
                dt.Rows.Add("Hello, world");
                wb.Worksheets.Add(dt, "WorksheetName");

                GC.KeepAlive(typeof(Extensions));
                GC.KeepAlive(typeof(Microsoft.Office.Interop.Excel.Application));
            });
        }
    }
}