using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._0_Always
{
    internal class Calc_Page02_Block1Be : BaseCalc
    {
        public override void Perform()
        {
            Calc_SSR();
            Calc_SSRL();
        }

        private string Calc_SSR_GetColumnName_S()
        {
            var Arg_DayAndMonth = userInput[CalculationsForm.Arg_DayAndMonth];

            if (Arg_DayAndMonth == DayAndMonthItemsRepr.Sm)
                return Arg_DayAndMonth;

            return "S" + Arg_DayAndMonth;
        }

        private void Calc_SSR()
        {
            tables.CalcsHydro.AddColumnIfNotExist(
                tables.BazaInfoHydro.Column("OI_METEO"));

            var meteoRows = tables.OperInfoMeteo.GetRows();
            var columnName_S = Calc_SSR_GetColumnName_S();

            CalcUtils.CalcMeteoAvg(meteoRows, columnName_S,
                tables.CalcsHydro, "SSR", CellMapper.RounderInt, tables.Result);
        }

        private void Calc_SSRL()
        {
            tables.CalcsHydro.AddColumn(
                tables.BazaInfoHydro.Column("fl"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var SSR = row["SSR"].DoubleValue;
                var fl = row["fl"].DoubleValue;

                var res = SSR * (1 + fl / 100d * (1.12 - 1));
                row.Set("SSRL", res, CellMapper.RounderInt);
            }, "SSRL");

            tables.Result.AddColumn(tables.CalcsHydro.Column("SSRL"));
        }
    }
}