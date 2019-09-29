using System;
using System.Windows.Forms;
using SouthernBug.App;

namespace SouthernBug
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var app = new MyApp();
            app.Run();
        }
    }
}