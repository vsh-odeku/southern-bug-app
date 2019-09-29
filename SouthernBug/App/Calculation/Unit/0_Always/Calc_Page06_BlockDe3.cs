using System;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._0_Always
{
    internal class Calc_Page06_BlockDe3 : BaseCalc
    {
        public override void Perform()
        {
            Init_Hr_D();
            Calc_X1();
            Calc_X2();
        }

        private void Init_Hr_D()
        {
            tables.CalcsHydro.AddColumnIfNotExist(
                tables.BazaInfoHydro.Column("Hr_D"));
        }

        private void Calc_X1()
        {
            Calc_X(1, GetCalculator_kB1());
        }

        private void Calc_X2()
        {
            Calc_X(2, GetCalculator_kB2());
        }

        private Func<double, double> GetCalculator_kB1()
        {
            switch (userInput[CalculationsForm.Arg_X1Norm])
            {
                case NormItemsRepr.AboveNorm:
                    return Hr_D => 1.83 - 0.055 * (Hr_D - 50);

                case NormItemsRepr.NearNorm:
                    return Hr_D => 0.84 + 0.09 * (Hr_D - 50);

                case NormItemsRepr.BelowNorm:
                    return Hr_D => 0.29 + 0.029 * (Hr_D - 50);

                default:
                    throw new Exception("Неверно указана норма для X1");
            }
        }

        private Func<double, double> GetCalculator_kB2()
        {
            switch (userInput[CalculationsForm.Arg_X2Norm])
            {
                case NormItemsRepr.AboveNorm:
                    return Hr_D => 1.75 - 0.027 * (Hr_D - 50);

                case NormItemsRepr.NearNorm:
                    return Hr_D => 0.86 + 0.022 * (Hr_D - 50);

                case NormItemsRepr.BelowNorm:
                    return Hr_D => 0.36 + 0.031 * (Hr_D - 50);

                default:
                    throw new Exception("Неверно указана норма для X2");
            }
        }

        private void Calc_X(int n, Func<double, double> kbCalculator)
        {
            var columnName_kB = "kB" + n;
            var columnName_X = "X" + n;
            var columnName_Baza_X = "X" + n * 10;

            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column(columnName_Baza_X));

            tables.CalcsHydro.IterateRows(row =>
            {
                var value_Hr_D = row["Hr_D"].DoubleValue;
                var value_kB = kbCalculator(value_Hr_D);
                row.Set(columnName_kB, value_kB, CellMapper.Rounder2);

                var value_X = value_kB * row[columnName_Baza_X].DoubleValue;
                row.Set(columnName_X, value_X, CellMapper.Rounder2);
            }, columnName_kB, columnName_X);
        }
    }
}