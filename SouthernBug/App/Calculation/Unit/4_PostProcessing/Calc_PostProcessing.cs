using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SouthernBug.App.Calculation.Table;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._4_PostProcessing
{
    class Calc_PostProcessing : BaseCalc
    {
        public override void Perform()
        {
            if (calcBranch.Y || calcBranch.Qm)
            {
                PostProcess_Y_Qm();
            }
            else if (calcBranch.D1 || calcBranch.D2)
            {
                PostProcess_D1_D2();
            }
        }

        private void PostProcess_Y_Qm()
        {
            int firstOrdinal = tables.Result.DataTable.Columns["XB"].Ordinal;

            var lastColumn = "kQP";
            if (userInput[CalculationsForm.Arg_Qp] == QpItemsRepr.Wj)
                lastColumn = "kWSR";

            tables.Result.Column("LSR")
                .PlaceAfter(lastColumn);

            tables.Result.Column("kL")
                .PlaceAfter("LSR");

            if (calcBranch.Y)
            {
                AddCalcColumnsOrdinal(tables.Result, firstOrdinal,
                    "X10", "kB1", "X1",
                    "X20", "kB2", "X2");

                AddCalcColumns(tables.ResultEstimation,
                    "SigmY", "DOPY", "YR", "Ym", "dY", "KRY");
            }
            else if (calcBranch.Qm)
            {
                tables.Result.Column("IntQ1")
                    .PlaceAfter("PQm");

                tables.Result.Column("IntQ2")
                    .PlaceAfter("IntQ1");

                AddCalcColumnsOrdinal(tables.Result, firstOrdinal,
                    "X10", "kB1", "X1");

                AddCalcColumns(tables.ResultEstimation,
                    "SigmQm", "DOPQm", "QRm", "Qm", "dQm", "KRQm",
                    "DOPHm", "HRm", "Hm", "dHm", "KRHm");
            }
        }

        private void PostProcess_D1_D2()
        {
            tables.Result = tables.CreateResultTable();

            if (calcBranch.D1)
            {
                AddCalcColumns(tables.Result,
                    "DSm", "Tkd", "T1Sm", "TB", "DBR", "ZP"
                );

                CopyDBR();
            }
            else if (calcBranch.D2Variant1)
            {
                AddCalcColumns(tables.Result,
                    "DSm", "Tkd", "T1Sm", "TB", "DBR",
                    "Tkdd", "T2B", "TP", "DQmR", "ZP"
                );

                CopyDBR();
            }
            else if (calcBranch.D2Variant2)
            {
                tables.Result.AddColumn(tables.OperInfoHydro.Column("DB"));

                AddCalcColumns(tables.Result,
                    "Tkdd", "T2B", "TP", "DQmR", "ZP"
                );
            }
        }

        private void CopyDBR()
        {
            tables.ResultEstimation
                .Column("DBR")
                .SetDataFrom(tables.CalcsHydro.Column("DBR"));
        }

        private void AddCalcColumns(TableProcessing.Table table, params string[] columns)
        {
            foreach (var columnName in columns)
            {
                table.AddColumnIfNotExist(tables.CalcsHydro.Column(columnName));
            }
        }

        private void AddCalcColumnsOrdinal(TableProcessing.Table table, int firstOrdinal,
            params string[] columns)
        {
            var ordinal = firstOrdinal;

            foreach (var columnName in columns)
            {
                table.AddColumn(tables.CalcsHydro.Column(columnName));

                table.DataTable.Columns[columnName].SetOrdinal(ordinal);

                ordinal++;
            }
        }
    }
}