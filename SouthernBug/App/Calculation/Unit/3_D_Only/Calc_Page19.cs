namespace SouthernBug.App.Calculation.Unit._3_D_Only
{
    internal class Calc_Page19 : BaseDCalc
    {
        public override void Perform()
        {
            if (calcBranch.D1) CalcD1();

            if (calcBranch.D2Variant1) CalcD2Variant1();

            if (calcBranch.D2Variant2) CalcD2Variant2();
        }

        private void CalcD1()
        {
            ImportColumns(tables.ConsultSp, "SRDB");
            ImportColumns(tables.OperInfoHydro, "DB");

            RowsDateDiff("DBR", "_SRDB", "dDBSR");
            RowsDateDiff("_DB", "DBR", "dDB");
        }

        private void CalcD2Variant1()
        {
            ImportColumns(tables.ConsultSp, "SRDB", "SRDQm");
            ImportColumns(tables.OperInfoHydro, "DB", "DQm");

            RowsDateDiff("DBR", "_SRDB", "dDBSR");
            RowsDateDiff("DQmR", "_SRDQm", "dDQmSR");


            RowsDateDiff("_DB", "DBR", "dDB");
            RowsDateDiff("_DQm", "DQmR", "dDQm");
        }

        private void CalcD2Variant2()
        {
            ImportColumns(tables.ConsultSp, "SRDQm");
            ImportColumns(tables.OperInfoHydro, "DQm");

            tables.ResultEstimation.Column("DQm").SetDataFrom(
                tables.OperInfoHydro.Column("DQm"));

            RowsDateDiff("DQmR", "_SRDQm", "dDQmSR");
            RowsDateDiff("_DQm", "DQmR", "dDQm");
        }

        private void ImportColumns(TableProcessing.Table table,
            params string[] columns)
        {
            foreach (var column in columns)
            {
                var col = tables.CalcsHydro.AddColumn("_" + column);
                col.SetDataFrom(table.Column(column));
            }
        }
    }
}