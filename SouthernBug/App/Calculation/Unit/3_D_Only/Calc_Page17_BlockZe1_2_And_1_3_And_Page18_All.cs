using System;
using System.Collections.Generic;
using SouthernBug.App.Model;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._3_D_Only
{
    internal class Calc_Page17_BlockZe1_2_And_1_3_And_Page18_All : BaseDCalc
    {
        private List<Row> meteoRows;

        public override void Perform()
        {
            if (!calcBranch.D2)
                return;

            Init();

            Show_Tkdd();
            Calc_T2B();
            Calc_TP();
            Calc_DQmR();
            Calc_ZP();
        }

        private void Init()
        {
            meteoRows = tables.OperInfoMeteo.GetRows();

            tables.CalcsHydro.AddColumnIfNotExist(
                tables.OperInfoHydro.Column("DB"));
        }

        private void Show_Tkdd()
        {
            var kddVal = userInput[CalculationsForm.Arg_Kdd];

            if (kddVal == DecadeItemsRepr.OptCalc)
            {
                var dbCol = calcBranch.D2Variant1 ? "DBR" : "DB";

                tables.CalcsHydro.IterateRows(row =>
                {
                    var decade = Decade.From(GetDate(row[dbCol]));
                    row.Set("Tkdd", decade.Next().ToString());
                }, "Tkdd");
            }
            else
            {
                tables.CalcsHydro.Column("Tkdd").Fill(kddVal);
            }
        }

        private void Calc_T2B()
        {
            CalcUtils.CalcMeteoAvg(meteoRows, "&Tkdd",
                tables.CalcsHydro, "T2B", CellMapper.Rounder2);
        }

        private void Calc_TP()
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("F"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = 2.76
                          * Math.Log10(row["F"].DoubleValue + 1)
                          + 4.92
                          - 1.5 * row["T2B"].DoubleValue;

                row.Set("TP", res, CellMapper.ZeroOrGreaterInt);
            }, "TP");

            tables.Result.AddColumn(tables.CalcsHydro.Column("TP"));
        }

        private void Calc_DQmR()
        {
            var dbColName = "DBR";
            if (calcBranch.D2Variant2)
                dbColName = "DB";

            tables.CalcsHydro.IterateRows(row =>
            {
                var daysDelta = row["TP"].IntValue;
                var dateStr = row[dbColName].StringValue;

                var dt = dateParser
                    .ParseDayMonth(dateStr)
                    .AddDays(daysDelta);

                var res = dateParser.ToDayMonth(dt);
                row.Set("DQmR", res);
            }, "DQmR");

            tables.ResultEstimation
                .Column("DQmR")
                .SetDataFrom(tables.CalcsHydro.Column("DQmR"));
        }

        private void Calc_ZP()
        {
            if (calcBranch.D2Variant1)
            {
                RowsDateDiff("DQmR", "DSm", "ZP", false, CellMapper.ZeroOrGreaterInt);
            }
            else if (calcBranch.D2Variant2)
            {
                RowsDateDiff("DQmR", "DB", "ZP", false, CellMapper.ZeroOrGreaterInt);
            }
        }
    }
}