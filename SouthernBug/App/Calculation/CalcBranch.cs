using System.Collections.Generic;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation
{
    public class CalcBranch
    {
        private readonly Dictionary<string, string> userInput;

        public CalcBranch(Dictionary<string, string> userInput)
        {
            this.userInput = userInput;
        }

        public bool Y => userInput[CalculationsForm.Arg_ForecastType] == ForecastTypes.Y;
        public bool Qm => userInput[CalculationsForm.Arg_ForecastType] == ForecastTypes.Qm;
        public bool D1 => userInput[CalculationsForm.Arg_ForecastType] == ForecastTypes.D1;
        public bool D2 => userInput[CalculationsForm.Arg_ForecastType] == ForecastTypes.D2;
        public bool D2Variant1 => D2 && userInput[CalculationsForm.Arg_D2Variant] == D2VariantItemsRepr.Var1DateSm;
        public bool D2Variant2 => D2 && userInput[CalculationsForm.Arg_D2Variant] == D2VariantItemsRepr.Var2DateDb;
        public bool DSm => userInput[CalculationsForm.Arg_DayAndMonth] == DayAndMonthItemsRepr.Sm;
    }
}