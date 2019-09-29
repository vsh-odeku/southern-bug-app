using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.Calculation.Unit._0_Always
{
    internal class Calc_Page03_BlockGe : BaseCalc
    {
        public override void Perform()
        {
            Calc_T_Meteo();
            Calc_T_Hydro();
            Calc_TT();
        }

        private void Calc_T_Meteo()
        {
            for (var n = 1; n <= 3; n++) Calc_Tn_Meteo(n);
        }

        private void Calc_Tn_Meteo(int n)
        {
            var columnName_T = "T" + n;

            for (var i = 1; i <= 3; i++)
            {
                var columnName = string.Format(columnName_T + i);

                tables.CalcsMeteo.AddColumn(
                    tables.OperInfoMeteo.Column(columnName));
            }


            tables.CalcsMeteo.IterateRows(row =>
            {
                var avg = (row[columnName_T + 1].DoubleValue
                           + row[columnName_T + 2].DoubleValue
                           + row[columnName_T + 3].DoubleValue) / 3d;

                row.Set(columnName_T, avg, CellMapper.Rounder2);
            }, columnName_T);
        }

        private void Calc_T_Hydro()
        {
            for (var n = 1; n <= 3; n++) Calc_Tn_Hydro(n);
        }

        private void Calc_Tn_Hydro(int n)
        {
            tables.CalcsHydro.AddColumnIfNotExist(
                tables.BazaInfoHydro.Column("OI_METEO"));

            var columnName_T = "T" + n;

            CalcUtils.CalcMeteoAvg(tables.CalcsMeteo.GetRows(), columnName_T,
                tables.CalcsHydro, columnName_T, CellMapper.Rounder2);
        }

        private void Calc_TT()
        {
            for (var n = 10; n <= 30; n += 10) Calc_TTn(n);
        }

        private void Calc_TTn(int n)
        {
            tables.CalcsHydro.AddColumnIfNotExist(
                tables.BazaInfoHydro.Column("OI_METEO"));

            var columnName_T = "T" + n;

            tables.CalcsMeteo.AddColumn(
                tables.BazaInfoMeteo.Column(columnName_T));

            CalcUtils.CalcMeteoAvg(tables.CalcsMeteo.GetRows(), columnName_T,
                tables.CalcsHydro, columnName_T, CellMapper.Rounder2);
        }
    }
}