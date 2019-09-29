using System.Collections.Generic;
using System.Linq;
using SouthernBug.App.Model;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Util;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._3_D_Only
{
    internal class Calc_Page17_BlockZe1_1 : BaseDCalc
    {
        private List<Row> meteoRows;

        public override void Perform()
        {
            if (calcBranch.D2Variant2)
            {
                Init();
                Calc_DSm();
                return;
            }

            if (!calcBranch.D1 && !calcBranch.D2Variant1)
                return;

            Init();
            Calc_DSm();
            Show_Tkd();
            Calc_T();
            Calc_TB();
            Calc_DBR();
            Calc_ZP();
        }

        private void Init()
        {
            meteoRows = tables.OperInfoMeteo.GetRows();
        }

        private void Calc_DSm()
        {
            var dateAverage = new DateAverage(dateParser);

            var valuesColumnName = "DSm_Values";
            var resultColumnName = "DSm";


            tables.CalcsHydro.IterateRows(row =>
            {
                var intList = row["OI_METEO"].ToIntList();

                var datesQuery = from meteoRow in meteoRows
                    where intList.Contains(meteoRow["OI_Meteo"].IntValue)
                    select meteoRow["DSm"].StringValue;

                var datesArray = datesQuery
                    .Where(item => item != "")
                    .ToArray();

                var values = string.Join(";", datesArray);

                row.Set(valuesColumnName, values);

                Etc.NoThrow(() =>
                {
                    var dayMonthAverage = dateAverage.CalcFor(datesArray);
                    var dayMonthRounded = dateAverage.RoundDayMonth(dayMonthAverage, 5);
                    row.Set(resultColumnName, dayMonthRounded);
                });
            }, valuesColumnName, resultColumnName);
        }

        private void Show_Tkd()
        {
            var kdVal = userInput[CalculationsForm.Arg_Kd];

            if (kdVal == DecadeItemsRepr.OptCalc)
            {
                tables.CalcsHydro.IterateRows(row =>
                {
                    var decade = Decade.From(GetDate(row["DSm"]));
                    row.Set("Tkd", decade.Next().ToString());
                }, "Tkd");
            }
            else
            {
                tables.CalcsHydro.Column("Tkd").Fill(kdVal);
            }
        }

        private void Calc_T()
        {
            CalcUtils.CalcMeteoAvg(meteoRows, "&Tkd",
                tables.CalcsHydro, "T1Sm", CellMapper.Rounder2);
        }

        private void Calc_TB()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var res = 2.144
                          * (row["Hr_D"].DoubleValue - 50)
                          + 6.6
                          - 1.5 * row["T1Sm"].DoubleValue;

                row.Set("TB", res, CellMapper.ZeroOrGreaterInt);
            }, "TB");

            tables.Result.AddColumn(tables.CalcsHydro.Column("TB"));
        }

        private void Calc_DBR()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var daysDelta = row["TB"].IntValue;

                var dt = GetDate(row["DSm"])
                    .AddDays(daysDelta);

                var res = dateParser.ToDayMonth(dt);

                row.Set("DBR", res);
            }, "DBR");

            tables.Result.AddColumn(tables.CalcsHydro.Column("DBR"));
        }

        private void Calc_ZP()
        {
            RowsDateDiff("DBR", "DSm", "ZP", false, CellMapper.ZeroOrGreaterInt);
        }
    }
}