using System;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._0_Always
{
    internal class Calc_Page04_05_BlockDe1_1 : BaseCalc
    {
        public override void Perform()
        {
            if (calcBranch.DSm)
            {
                var column_SR = tables.CalcsHydro.Column("SR");
                column_SR.SetDataFrom(tables.CalcsHydro.Column("SSRL"));

                tables.Result.AddColumn(column_SR);
            }
            else
            {
                if (userInput[CalculationsForm.Arg_ds] == DsItemsRepr.TakeDs)
                {
                    tables.CalcsHydro.AddColumn(tables.OperInfoHydro.Column("dS"));
                }
                else
                {
                    Calc_TR();
                    Calc_dS();
                }

                Calc_SR();
            }
        }

        private void Calc_TR()
        {
            var DP = userInput[CalculationsForm.Arg_DayAndMonth];
            var clauseNumber = Discover_DP_ClauseNumber(DP);

            var col_TR = tables.CalcsHydro.Column("TR");
            var col_TR0 = tables.CalcsHydro.Column("TR0");

            if (clauseNumber >= 1 && clauseNumber <= 3)
            {
                col_TR.SetDataFrom(tables.CalcsHydro.Column("T" + clauseNumber));
                col_TR0.SetDataFrom(tables.CalcsHydro.Column("T" + clauseNumber * 10));
            }
        }

        private void Calc_dS()
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("Hr_D"));

            var value_D = DayAndMonthItemsRepr.DD_MM_to_D(
                userInput[CalculationsForm.Arg_DayAndMonth]);

            tables.CalcsHydro.Column("D").Fill(value_D);

            tables.CalcsHydro.IterateRows(row =>
            {
                var calculate_dS = GetCalculator_dS(row["TR"].DoubleValue,
                    row["TR0"].DoubleValue, out var dS_Formula);

                row.Set("Формула dS", dS_Formula);

                if (calculate_dS == null)
                    return;

                var res = calculate_dS(value_D, row["Hr_D"].DoubleValue);
                row.Set("dS", res, CellMapper.ZeroOrGreaterRounded2);
            }, "Формула dS", "dS");

            tables.Result.AddColumn(tables.CalcsHydro.Column("dS"));
        }

        private Func<int, double, double> GetCalculator_dS(double TR,
            double TR0, out string dS_Formula)
        {
            if (TR <= TR0 - 1)
            {
                dS_Formula = "Ниже нормы";
                return (D, Hr_D) => 26.8 - 0.55 * D + (3.27 - 0.086 * D) * (Hr_D - 50);
            }

            if (TR0 + 1 > TR && TR > TR0 - 1)
            {
                dS_Formula = "Около нормы";
                return (D, Hr_D) => 20.4 - 0.61 * D + (3.38 - 0.109 * D) * (Hr_D - 50);
            }

            if (TR >= TR0 + 1)
            {
                dS_Formula = "Выше нормы";
                return (D, Hr_D) => 7.47 - 0.25 * D + (2.14 - 0.0741 * D) * (Hr_D - 50);
            }

            dS_Formula = "Неизвестно";
            return null;
        }

        private void Calc_SR()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["SSRL"].DoubleValue + row["dS"].DoubleValue;
                row.Set("SR", res, CellMapper.RounderInt);
            }, "SR");

            tables.Result.AddColumn(tables.CalcsHydro.Column("SR"));
        }

        private int Discover_DP_ClauseNumber(string DP)
        {
            var clausesValues = Get_DP_Clauses_Values();

            for (var i = 0; i < clausesValues.Length; i++)
                foreach (var item in clausesValues[i])
                    if (item == DP)
                        return i + 1;

            return -1;
        }

        private string[][] Get_DP_Clauses_Values()
        {
            string[][] DP_Clauses_Values =
            {
                new[]
                {
                    DayAndMonthItemsRepr.CreateDayMonth(5, 1),
                    DayAndMonthItemsRepr.CreateDayMonth(10, 1),
                    DayAndMonthItemsRepr.CreateDayMonth(15, 1),
                    DayAndMonthItemsRepr.CreateDayMonth(20, 1)
                },

                new[]
                {
                    DayAndMonthItemsRepr.CreateDayMonth(25, 1),
                    DayAndMonthItemsRepr.CreateDayMonth(31, 1),
                    DayAndMonthItemsRepr.CreateDayMonth(5, 2),
                    DayAndMonthItemsRepr.CreateDayMonth(10, 2),
                    DayAndMonthItemsRepr.CreateDayMonth(15, 2),
                    DayAndMonthItemsRepr.CreateDayMonth(20, 2)
                },

                new[]
                {
                    DayAndMonthItemsRepr.CreateDayMonth(25, 2),
                    DayAndMonthItemsRepr.CreateDayMonth(28, 2),
                    DayAndMonthItemsRepr.CreateDayMonth(5, 3),
                    DayAndMonthItemsRepr.CreateDayMonth(10, 3),
                    DayAndMonthItemsRepr.CreateDayMonth(15, 3),
                    DayAndMonthItemsRepr.CreateDayMonth(20, 3),
                    DayAndMonthItemsRepr.CreateDayMonth(25, 3),
                    DayAndMonthItemsRepr.CreateDayMonth(31, 3),
                    DayAndMonthItemsRepr.CreateDayMonth(5, 4),
                    DayAndMonthItemsRepr.CreateDayMonth(10, 4)
                }
            };

            return DP_Clauses_Values;
        }
    }
}