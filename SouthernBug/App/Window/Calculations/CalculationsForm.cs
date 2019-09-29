using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Ninject;
using Ninject.Parameters;
using SouthernBug.App.Calculation;
using SouthernBug.App.Entity.Dump;
using SouthernBug.App.Entity.Server;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.Window.TablesEdior;

namespace SouthernBug.App.Window.Calculations
{
    public partial class CalculationsForm : Form
    {
        public const string Arg_DayAndMonth = "Arg_DayAndMonth";
        public const string Arg_Year = "Arg_Year";
        public const string Arg_Qp = "Arg_Qp";
        public const string Arg_ds = "Arg_ds";
        public const string Arg_AllowedRange = "Arg_AllowedRange";
        public const string Arg_X1Norm = "Arg_X1Norm";
        public const string Arg_X2Norm = "Arg_X2Norm";
        public const string Arg_ForecastType = "Arg_ForecastType";
        public const string Arg_Kd = "Arg_Kd";
        public const string Arg_Kdd = "Arg_Kdd";
        public const string Arg_D2Variant = "Arg_D2Variant";

        private AllowedRangeItemsRepr allowedRangeItemsRepr;

        private DayAndMonthItemsRepr dayAndMonthItemsRepr;
        private DsItemsRepr dsItemsRepr;
        private QpItemsRepr qpItemsRepr;
        private NormItemsRepr x1NormItemsRepr;
        private NormItemsRepr x2NormItemsRepr;
        private YearItemsRepr yearItemsRepr;

        public CalculationsForm()
        {
            InitializeComponent();

            InitComboBoxes();
            InitButtons();

            FillTestInput();

            UpdateButtons();
        }

        [Inject] public Context Context { get; set; }

        private void FillTestInput()
        {
            dayAndMonthComboBox.SelectedIndex = 9;
            QPComboBox.SelectedIndex = 3;
        }

        private void InitComboBoxes()
        {
            dayAndMonthItemsRepr = new DayAndMonthItemsRepr(dayAndMonthComboBox);
            yearItemsRepr = new YearItemsRepr(yearComboBox);
            qpItemsRepr = new QpItemsRepr(QPComboBox);
            dsItemsRepr = new DsItemsRepr(dSComboBox);
            allowedRangeItemsRepr = new AllowedRangeItemsRepr(allowedRangeComboBox);
            x1NormItemsRepr = new NormItemsRepr(X1ComboBox);
            x2NormItemsRepr = new NormItemsRepr(X2ComboBox);

            dayAndMonthItemsRepr.SelectedItemChanged += DayAndMonthItemsRepr_SelectedItemChanged;
        }

        private void DayAndMonthItemsRepr_SelectedItemChanged(ItemsRepr obj)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            var areDButtonsEnabled = dayAndMonthItemsRepr.SelectedValue == DayAndMonthItemsRepr.Sm;
            D1Button.Enabled = D2Button.Enabled = areDButtonsEnabled;
        }

        private void InitButtons()
        {
            foreach (Control control in Controls)
                if (control is Button button)
                    button.Click += AnyButtonClick;
        }

        private Dictionary<string, string> getUserInput()
        {
            var userInput = new Dictionary<string, string>
            {
                [Arg_DayAndMonth] = dayAndMonthItemsRepr.SelectedValue,
                [Arg_Year] = yearItemsRepr.SelectedValue,
                [Arg_Qp] = qpItemsRepr.SelectedValue,
                [Arg_ds] = dsItemsRepr.SelectedValue,
                [Arg_AllowedRange] = allowedRangeItemsRepr.SelectedValue,
                [Arg_X1Norm] = x1NormItemsRepr.SelectedValue,
                [Arg_X2Norm] = x2NormItemsRepr.SelectedValue
            };


            return userInput;
        }

        private void AnyButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (Constants.IsDeveloperMode)
                    FgCalcs(sender);
                else
                    BgCalcs(sender);
            }
            catch (OperationCanceledException)
            {
                // pass
            }
        }

        private void FgCalcs(object sender)
        {
            var calc = CreateCalculation(sender);
            ShowCalculationResult(calc.Perform());
        }

        private void BgCalcs(object sender)
        {
            var calc = CreateCalculation(sender);

            var worker = new BackgroundWorker();
            worker.DoWork += (ss, ee) => calc.Perform(worker, ee);

            var pdForm = new WorkerForm(worker);
            pdForm.ShowDialog();

            if (pdForm.Result is TablesDump res) ShowCalculationResult(res);
            pdForm.Dispose();
        }

        private MainCalculation CreateCalculation(object sender)
        {
            var userInput = getUserInput();
            userInput[Arg_ForecastType] = ((Button) sender).Text;

            GetExtraData(userInput);

            var calcArg = new ConstructorArgument(MainCalculation.ArgUserInput, userInput);
            return Context.Kernel.Get<MainCalculation>(calcArg);
        }

        private void GetExtraData(Dictionary<string, string> userInput)
        {
            var forecastType = userInput[Arg_ForecastType];
            CalculationExtraArgsForm.Mode? mode = null;

            if (forecastType == "D1") mode = CalculationExtraArgsForm.Mode.D1;

            if (forecastType == "D2") mode = CalculationExtraArgsForm.Mode.D2;

            if (!mode.HasValue)
                return;

            using (var form = new CalculationExtraArgsForm(mode.Value))
            {
                form.ShowDialog();
                if (!form.ResultUserPressedOk) throw new OperationCanceledException();

                userInput[Arg_Kd] = form.ResultKd;
                userInput[Arg_Kdd] = form.ResultKdd;
                userInput[Arg_D2Variant] = form.ResultD2Variant;
            }
        }

        private void ShowCalculationResult(TablesDump tablesDump)
        {
            var tablesServer = new LocalDataTableServer(tablesDump);

            var arg = new ConstructorArgument(TablesEditorForm.ArgDataTableServer, tablesServer);
            var resultDisplayForm = Context.Kernel.Get<TablesEditorForm>(arg);

            resultDisplayForm.Show();
        }
    }
}