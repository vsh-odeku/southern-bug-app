using System;
using SouthernBug.App.Calculation.Unit._2_Qm_Only;
using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.Calculation.Unit._1_Y_Only
{
    internal class Calc_Page11 : BaseCalc
    {
        private static readonly object __seeAlso = typeof(Calc_Page16);

        public override void Perform()
        {
            if (!calcBranch.Y)
                return;

            Calc_DOPY();
            Calc_dY();
            Calc_KRY();
        }

        private void Calc_DOPY()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["SigmY"].DoubleValue * MainCalcConstants.SigmDOP;
                row.Set("DOPY", res, CellMapper.Rounder2);
            }, "DOPY");
        }

        private void Calc_dY()
        {
            tables.CalcsHydro.AddColumn(tables.OperInfoHydro.Column("Ym"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["Ym"].DoubleValue - row["YR"].DoubleValue;
                row.Set("dY", res, CellMapper.Rounder2);
            }, "dY");
        }

        private void Calc_KRY()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["dY"].DoubleValue / row["DOPYR"].DoubleValue;
                row.Set("KRY", Math.Abs(res), CellMapper.Rounder2);
            }, "KRY");
        }
    }
}