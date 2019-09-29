using System;
using SouthernBug.App.Calculation.Unit._1_Y_Only;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._2_Qm_Only
{
    internal class Calc_Page15 : BaseCalc
    {
        private static readonly object __seeAlso = typeof(Calc_Page10);

        public override void Perform()
        {
            if (!calcBranch.Qm)
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
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("SigmQm"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["SigmQm"].DoubleValue * MainCalcConstants.SigmDOP;

                row.Set("DOPQRm", res, CellMapper.Rounder2);
                row.Set("DOPHRm", res, CellMapper.Rounder2);
            }, "DOPQRm", "DOPHRm");
        }

        private void Calc_DOP_with_k(double k)
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                row.Set("DOPQRm", row["QRm"].DoubleValue * k, CellMapper.Rounder2);
                row.Set("DOPHRm", row["HRm"].DoubleValue * k, CellMapper.Rounder2);
            }, "DOPQRm", "DOPHRm");
        }

        private void Calc_Ints()
        {
            Calc_Int("QRm", "DOPQRm", "IntQ");
            Calc_Int("HRm", "DOPHRm", "IntH");
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