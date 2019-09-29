using System;
using SouthernBug.App.Calculation.Unit._2_Qm_Only;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._1_Y_Only
{
    internal class Calc_Page10 : BaseCalc
    {
        private static readonly object __seeAlso = typeof(Calc_Page15);

        public override void Perform()
        {
            if (!calcBranch.Y)
                return;

            Calc_DOP();
            Calc_Ints();
        }

        private void Calc_DOP()
        {
            switch (userInput[CalculationsForm.Arg_AllowedRange])
            {
                case AllowedRangeItemsRepr.Standard:
                    Calc_DOP_standard();
                    break;
                case AllowedRangeItemsRepr.Percent10:
                    Calc_DOP_with_k(0.1);
                    break;
                case AllowedRangeItemsRepr.Percent20:
                    Calc_DOP_with_k(0.2);
                    break;
                default:
                    throw new InvalidOperationException("Unknown Allowed Range");
            }
        }

        private void Calc_DOP_standard()
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("SigmY"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["SigmY"].DoubleValue * MainCalcConstants.SigmDOP;

                row.Set("DOPYR", res, CellMapper.Rounder2);
                row.Set("DOPWR", res, CellMapper.Rounder2);
            }, "DOPYR", "DOPWR");
        }

        private void Calc_DOP_with_k(double k)
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                row.Set("DOPYR", row["YR"].DoubleValue * k, CellMapper.Rounder2);
                row.Set("DOPWR", row["WR"].DoubleValue * k, CellMapper.Rounder2);
            }, "DOPYR", "DOPWR");
        }

        private void Calc_Ints()
        {
            Calc_Int("YR", "DOPYR", "IntY");
            Calc_Int("WR", "DOPWR", "IntW");
        }

        private void Calc_Int(string aColumn, string bColumn, string resColumnName)
        {
            var resMinusColumnName = resColumnName + 1;
            var resPlusColumnName = resColumnName + 2;

            tables.CalcsHydro.IterateRows(row =>
            {
                var a = row[aColumn].DoubleValue;
                var b = row[bColumn].DoubleValue;

                row.Set(resMinusColumnName, a - b, CellMapper.ZeroOrGreaterRounded2);
                row.Set(resPlusColumnName, a + b, CellMapper.ZeroOrGreaterRounded2);
            }, resMinusColumnName, resPlusColumnName);

            tables.Result.AddColumn(tables.CalcsHydro.Column(resMinusColumnName));
            tables.Result.AddColumn(tables.CalcsHydro.Column(resPlusColumnName));
        }
    }
}