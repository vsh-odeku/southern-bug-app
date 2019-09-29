using System;
using System.Collections.Generic;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Util;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._0_Always
{
    internal class Calc_Page02_Block2Ve : BaseCalc
    {
        public override void Perform()
        {
            Calc_LR();
            Restore_LR();
            Calc_LSR();
            Calc_kL();
        }

        private void Calc_LR()
        {
            if (calcBranch.DSm)
            {
                tables.CalcsMeteo.AddColumn(
                    tables.OperInfoMeteo.Column("Lm"));

                tables.CalcsMeteo.IterateRows(row =>
                {
                    var dt = GetDate(row["Lm"]);
                    var dayMonth = dateParser.ToDayMonth(dt, "_");

                    Etc.NoThrow(() =>
                    {
                        var columnName_L = DayAndMonthItemsRepr
                            .DD_MM_to_LDD_MM(dayMonth);

                        row.Set("L_Column", columnName_L);
                    });

                }, "L_Column");

                var operRows = tables.OperInfoMeteo.GetRows();

                tables.CalcsMeteo.IterateRows(calcRow =>
                {
                    Etc.NoThrow(() =>
                    {
                        var colName = calcRow["L_Column"].StringValue;
                        var operRow = operRows[calcRow.Index];
                        calcRow.Set("LR", operRow[colName]);
                    });
                }, "LR");
            }
            else
            {
                var DD_MM = userInput[CalculationsForm.Arg_DayAndMonth];

                Etc.NoThrow(() =>
                {
                    var columnName_L = DayAndMonthItemsRepr.DD_MM_to_LDD_MM(DD_MM);

                    var column_oper_L = tables.OperInfoMeteo.Column(columnName_L);

                    tables.CalcsMeteo.Column("LR").SetDataFrom(column_oper_L);
                });
            }

        }

        private void Restore_LR()
        {
            tables.CalcsMeteo.AddColumn(tables.BazaInfoMeteo.Column("Hr1"));

            tables.CalcsMeteo.IterateRows(
                row => { row.Set("Hr1-50", row["Hr1"].DoubleValue - 50, CellMapper.Rounder2); }, "Hr1-50");

            var column_Hr1_minus_50 = tables.CalcsMeteo.Column("Hr1-50");
            var column_LR = tables.CalcsMeteo.Column("LR");

            var equationName = "LR = a + b * (Hr1 - 50)";

            CalcUtils.RestoreColumn(tables.CoeffsTable,
                column_Hr1_minus_50, column_LR,
                new RoundDoubleCellMapper(5), equationName);
        }

        private void Calc_LSR()
        {
            tables.CalcsHydro.AddColumnIfNotExist(
                tables.BazaInfoHydro.Column("OI_METEO"));

            CalcUtils.CalcMeteoAvg(tables.CalcsMeteo.GetRows(), "LR_Used",
                tables.CalcsHydro, "LSR", CellMapper.ZeroOrGreaterInt, tables.Result);
        }

        private void Calc_kL()
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("L0"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["LSR"].DoubleValue / row["L0"].DoubleValue;
                row.Set("kL", res, CellMapper.Rounder2);
            }, "kL");

            tables.Result.AddColumn(tables.CalcsHydro.Column("kL"));
        }
    }
}