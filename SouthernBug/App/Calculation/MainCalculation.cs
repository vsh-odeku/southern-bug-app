using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Ninject.Parameters;
using SouthernBug.App.Entity.Dump;
using SouthernBug.App.Util;

namespace SouthernBug.App.Calculation
{
    public class MainCalculation
    {
        public const string ArgUserInput = "userInput";
        private readonly Dictionary<string, object> calcMemory;

        private readonly Dictionary<string, string> userInput;
        private MainCalcTables tables;

        public MainCalculation(Dictionary<string, string> userInput)
        {
            this.userInput = userInput;
            calcMemory = new Dictionary<string, object>();
        }

        [Inject] public Context AppContext { get; set; }

        public TablesDump Perform()
        {
            PrepareTables();

            foreach (var calc in MainCalcUnits.LoadAllCalcs())
            {
                calc.Initialize(tables, userInput, calcMemory);
                try
                {
                    calc.Perform();
                }
                catch (CalcDebugInterruptException e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show("Interrupted: " + e.Message);
                    break;
                }
            }

            return tables.GetAllOutputDataTables();
        }

        public void Perform(BackgroundWorker worker, DoWorkEventArgs e)
        {
            PrepareTables();

            var resultHolder = (Holder<object>) e.Argument;

            var calcs = MainCalcUnits.LoadAllCalcs();
            var calcPerc = 100d / calcs.Count;
            var totalPerc = 0d;

            foreach (var calc in calcs)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                calc.Initialize(tables, userInput, calcMemory);
                try
                {
                    calc.Perform();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);

                    MessageBox.Show($"Вычисления были прерваны из-за ошибки: \n\n{exc.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                totalPerc += calcPerc;
                worker.ReportProgress(Convert.ToInt32(totalPerc));
            }

            resultHolder.Value = tables.GetAllOutputDataTables();
        }

        private void PrepareTables()
        {
            var calcTablesArg = new ConstructorArgument(ArgUserInput, userInput);
            tables = AppContext.Kernel.Get<MainCalcTables>(calcTablesArg);
        }
    }
}