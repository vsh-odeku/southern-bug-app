using System;
using SouthernBug.App.Calculation.Unit._1_Y_Only;
using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.Calculation.Unit._2_Qm_Only
{
    internal class Calc_Page16 : BaseCalc
    {
        private static readonly object __seeAlso = typeof(Calc_Page11);

        public override void Perform()
        {
            if (!calcBranch.Qm)
                return;

            Calc_DOP();
            Calc_d();
            Calc_KR();
        }

        private void Calc_DOP()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["SigmQm"].DoubleValue * MainCalcConstants.SigmDOP;
                row.Set("DOPQm", res, CellMapper.Rounder2);
            }, "DOPQm");

            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("DOPHm"));
        }

        private void Calc_d()
        {
            tables.CalcsHydro.AddColumn(tables.OperInfoHydro.Column("Qm"));
            tables.CalcsHydro.AddColumn(tables.OperInfoHydro.Column("Hm"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var dQm = row["Qm"].DoubleValue - row["QRm"].DoubleValue;
                row.Set("dQm", dQm, CellMapper.Rounder2);

                var dHm = row["Hm"].DoubleValue - row["HRm"].DoubleValue;
                row.Set("dHm", dHm, CellMapper.Rounder2);
            }, "dQm", "dHm");
        }

        private void Calc_KR()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var KRQm = row["dQm"].DoubleValue / row["DOPQm"].DoubleValue;
                row.Set("KRQm", Math.Abs(KRQm), CellMapper.Rounder2);

                var KRHm = row["dHm"].DoubleValue - row["DOPHm"].DoubleValue;
                row.Set("KRHm", Math.Abs(KRHm), CellMapper.Rounder2);
            }, "KRQm", "KRHm");
        }
    }
}