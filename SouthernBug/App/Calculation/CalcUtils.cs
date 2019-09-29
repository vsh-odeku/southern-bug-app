using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Util;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation
{
    public static class CalcUtils
    {
        public static void RestoreColumn(TableProcessing.Table coeffsTable,
            Column xCol, Column yCol,
            ICellMapper resultMapper, string equationName,
            bool needPlusA = true)
        {
            var count = xCol.Height;

            var xDoubles = new List<double>();
            var yDoubles = new List<double>();

            for (var i = 0; i < count; i++)
                if (!xCol[i].IsEmpty && !yCol[i].IsEmpty)
                {
                    xDoubles.Add(xCol[i].DoubleValue);
                    yDoubles.Add(yCol[i].DoubleValue);
                }

            var restoredColumn = yCol.Table.Column(yCol.Name + "_Restored");
            var usedColumn = yCol.Table.Column(yCol.Name + "_Used");

            if (xDoubles.Count < 2)
                return;

            var p = Fit.Line(xDoubles.ToArray(), yDoubles.ToArray());

            // y = a + b*x

            var coeffMapper = new RoundDoubleCellMapper(6);

            var a = 0.0;
            if (needPlusA)
                a = p.Item1;

            var b = p.Item2;

            var aValue = "";
            if (needPlusA)
                aValue = coeffMapper.Map(new Cell(a)).StringValue;

            coeffsTable.DataTable.Rows.Add(equationName,
                aValue,
                coeffMapper.Map(new Cell(b)).StringValue);

            for (var i = 0; i < count; i++)
                if (!xCol[i].IsEmpty)
                {
                    var restoredValue = a + b * xCol[i].DoubleValue;
                    restoredColumn.Set(i, restoredValue, resultMapper);

                    usedColumn.Set(i, yCol[i].IsEmpty ? restoredColumn[i] : yCol[i]);
                }
        }

        public static void CalcMeteoAvg(List<Row> meteoRows, string meteoColumnName,
            TableProcessing.Table calcsHydroTable, string hydroColumnName,
            ICellMapper cellMapper, params TableProcessing.Table[] resultTables)
        {
            var valuesColumnName = meteoColumnName + "_Values";


            calcsHydroTable.IterateRows(hydroRow =>
            {
                var intList = hydroRow["OI_METEO"].ToIntList();

                double number = 0;

                var realMeteoColumnName = meteoColumnName;

                if (meteoColumnName.StartsWith("&"))
                {
                    var hydroPtr = meteoColumnName.Substring(1);
                    realMeteoColumnName = hydroRow[hydroPtr].StringValue;
                }

                Etc.NoThrow(() =>
                {
                    var doubleQuery = from meteoRow in meteoRows
                        where intList.Contains(meteoRow["OI_Meteo"].IntValue)
                              && double.TryParse(
                                  meteoRow[realMeteoColumnName].StringValue, out number)
                        select number;

                    var enumerable = doubleQuery.ToList();

                    var strQuery = from dbl in enumerable
                        select cellMapper.Map(new Cell(dbl)).StringValue;

                    var res = string.Join(";", strQuery.ToArray());

                    hydroRow.Set(valuesColumnName, res);

                    hydroRow.Set(hydroColumnName,
                        enumerable.Average(), cellMapper);
                });
            }, valuesColumnName, hydroColumnName);

            foreach (var table in resultTables) table.AddColumn(calcsHydroTable.Column(hydroColumnName));
        }

        public static void CopyCoeffs(string coeffTypeColumnName,
            TableProcessing.Table bazaHydroTable,
            TableProcessing.Table coeffsTable,
            TableProcessing.Table hydroTable,
            params string[] coeffsArray)
        {
            hydroTable.AddColumnIfNotExist(bazaHydroTable.Column(coeffTypeColumnName));

            var coeffsTableRows = coeffsTable.GetRows();

            hydroTable.IterateRows(calcsRow =>
            {
                var query = from coeffsRow in coeffsTableRows
                    where coeffsRow["OI_RnDF"].StringValue
                          == calcsRow[coeffTypeColumnName].StringValue
                    select coeffsRow;

                var neededRow = query.First();

                foreach (var coeffColumnName in coeffsArray) calcsRow.Set(coeffColumnName, neededRow[coeffColumnName]);
            }, null, coeffsArray);
        }

        public static void BlockE_Calc_kWP(int totalOffset,
            TableProcessing.Table calcsTable,
            Dictionary<string, string> userInput,
            Dictionary<string, object> calcMemory
        )
        {
            var column_kWP = calcsTable.Column("kWP");

            if (userInput[CalculationsForm.Arg_Qp] == QpItemsRepr.Wj)
            {
                column_kWP.SetDataFrom(calcsTable.Column("kWSR"));
                calcMemory["DF_Offset"] = totalOffset + 10;
            }
            else
            {
                column_kWP.SetDataFrom(calcsTable.Column("kQP"));
                calcMemory["DF_Offset"] = totalOffset;
            }
        }

        public static void BlockE_Calc_DF(string coeffTypeColumnName,
            MainCalcTables tables, Dictionary<string, object> calcMemory)
        {
            var coeffNOffset = (int) calcMemory["DF_Offset"];

            BlockE_Calc_DFn(coeffTypeColumnName, tables, 1, coeffNOffset);
            BlockE_Calc_DFn(coeffTypeColumnName, tables, 2, coeffNOffset + 5);
        }

        public static void BlockE_Calc_DFn(string coeffTypeColumnName,
            MainCalcTables tables, int n, int coeffNOffset)
        {
            var resultColumnName = "DF" + n;

            var coeffsArr = Enumerable.Range(0, 5)
                .Select(i => "a" + (i + coeffNOffset))
                .ToArray();

            CopyCoeffs(coeffTypeColumnName,
                tables.BazaInfoHydro, tables.BazaInfoCoeffs, tables.CalcsHydro,
                coeffsArr);

            tables.CalcsHydro.IterateRows(calcsRow =>
            {
                var res = BlockE_Func_Calc_DF(
                    calcsRow[coeffsArr[0]].DoubleValue,
                    calcsRow[coeffsArr[1]].DoubleValue,
                    calcsRow[coeffsArr[2]].DoubleValue,
                    calcsRow[coeffsArr[3]].DoubleValue,
                    calcsRow[coeffsArr[4]].DoubleValue,
                    calcsRow["kXB"].DoubleValue,
                    calcsRow["kWP"].DoubleValue,
                    calcsRow["kL"].DoubleValue,
                    calcsRow["T2"].DoubleValue
                );

                calcsRow.Set(resultColumnName, res, CellMapper.Rounder2);
            }, resultColumnName);

            tables.Result.AddColumn(tables.CalcsHydro.Column(resultColumnName));
        }

        public static double BlockE_Func_Calc_DF(double a0, double a1, double a2, double a3, double a4,
            double kXB, double kWP, double kL, double T2)
        {
            return a0 + a1 * kXB + a2 * kWP + a3 * kL + a4 * T2;
        }

        public static double BlockE_Func_Calc_1_3(double b0, double b1, double b2, double b3, double kXB)
        {
            return b0 + b1 * kXB + b2 * kXB * kXB + b3 * kXB * kXB * kXB;
        }
    }
}