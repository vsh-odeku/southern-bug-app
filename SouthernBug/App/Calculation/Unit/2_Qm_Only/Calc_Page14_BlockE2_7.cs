using System;
using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.Calculation.Unit._2_Qm_Only
{
    internal class Calc_Page14_BlockE2_7 : BaseCalc
    {
        public override void Perform()
        {
            if (!calcBranch.Qm)
                return;

            Main();
        }

        private void Main()
        {
            Calc("Hm0", "kHm", (HRm, input) => HRm / input);
            Calc("HNB", "kHNB", (HRm, input) => HRm - input);
            Calc("HSNB", "kHSNB", (HRm, input) => HRm - input);
            Calc("HZp", "kHZp", (HRm, input) => HRm - input);
            Calc("Hmm", "kHmm", (HRm, input) => HRm - input);
        }

        private void Calc(string hydroInput, string resOutput, Func<double, double, double> calcResult)
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column(hydroInput));

            tables.CalcsHydro.IterateRows(row =>
            {
                row.Set(resOutput,
                    calcResult(row["HRm"].DoubleValue, row[hydroInput].DoubleValue),
                    CellMapper.Rounder2);
            }, resOutput);

            tables.Result.AddColumn(tables.CalcsHydro.Column(resOutput));
        }
    }
}