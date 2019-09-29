using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Interpolation;
using SouthernBug.App.Calculation.Converter;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Util;

namespace SouthernBug.App.Calculation.Unit._2_Qm_Only
{
    internal class Calc_Page12_13_BlockE2 : BaseCalc
    {
        public override void Perform()
        {
            if (!calcBranch.Qm)
                return;

            Calc_XB();
            Calc_kXB();
            Calc_kWP();
            Calc_DF();
            Calc_kqm();
            Calc_QRm();
            Calc_CvY_Column();
            Calc_PY();
            Rename_PY_To_PQm();
        }

        private void Calc_XB()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["SR"].DoubleValue + row["X1"].DoubleValue;

                row.Set("XB", res, CellMapper.RounderInt);
            }, "XB");

            tables.Result.AddColumn(tables.CalcsHydro.Column("XB"));
        }

        private void Calc_kXB()
        {
            tables.CalcsHydro.AddColumnsIfNotExist(tables.BazaInfoHydro,
                "S0", "X10");

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["XB"].DoubleValue / (
                              row["S0"].DoubleValue + row["X10"].DoubleValue);

                row.Set("kXB", res, CellMapper.Rounder2);
            }, "kXB");

            tables.Result.AddColumn(tables.CalcsHydro.Column("kXB"));
        }

        private void Calc_kWP()
        {
            CalcUtils.BlockE_Calc_kWP(20, tables.CalcsHydro, userInput, calcMemory);
        }

        private void Calc_DF()
        {
            CalcUtils.BlockE_Calc_DF("OI_RnDFQm", tables, calcMemory);
        }

        private void Calc_kqm()
        {
            var coeffsArr = Enumerable.Range(12, 12)
                .Select(i => "b" + i)
                .ToArray();

            CalcUtils.CopyCoeffs("OI_RnQm",
                tables.BazaInfoHydro, tables.BazaInfoCoeffs, tables.CalcsHydro,
                coeffsArr);

            tables.CalcsHydro.IterateRows(row =>
            {
                int offset;

                if (row["DF1"].DoubleValue > 0.5)
                    offset = 0;
                else if (row["DF1"].DoubleValue <= 0.5 && row["DF2"].DoubleValue >= 0.5)
                    offset = 4;
                else if (row["DF1"].DoubleValue < 0.5 && row["DF2"].DoubleValue < 0.5)
                    offset = 8;
                else
                    throw new Exception(
                        "Страница 13: Ни одно из условий не соблюдается");

                var res = CalcUtils.BlockE_Func_Calc_1_3(
                    row[coeffsArr[0 + offset]].DoubleValue,
                    row[coeffsArr[1 + offset]].DoubleValue,
                    row[coeffsArr[2 + offset]].DoubleValue,
                    row[coeffsArr[3 + offset]].DoubleValue,
                    row["kXB"].DoubleValue);

                row.Set("kqm", res, CellMapper.Rounder2);
            }, "kqm");

            tables.Result.AddColumn(tables.CalcsHydro.Column("kqm"));
        }

        private void Calc_QRm()
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("BigQ_0"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var res = row["kqm"].DoubleValue * row["BigQ_0"].DoubleValue;
                row.Set("QRm", res, CellMapper.Rounder2);
            }, "QRm");

            tables.Result.AddColumn(tables.CalcsHydro.Column("QRm"));
        }

        private void Calc_CvY_Column()
        {
            tables.CalcsHydro.AddColumn(tables.BazaInfoHydro.Column("CvY"));

            tables.CalcsHydro.IterateRows(row =>
            {
                var value_CvY = row["CvY"].DoubleValue;
                var name = CvYColumnConverter.NameFromValue(value_CvY);

                row.Set("CvY_Column", name);
            }, "CvY_Column");
        }

        private void Calc_PY()
        {
            var interpTable = new TableProcessing.Table("Interpolate PY");
            calcMemory["interpTable"] = interpTable;

            tables.AddCustomTable(interpTable);

            interpTable.AddColumn("PY");
            interpTable.AddRow("0,001");
            interpTable.AddRow("0,01");
            interpTable.AddRow("0,03");
            interpTable.AddRow("0,05");
            interpTable.AddRow("0,1");
            interpTable.AddRow("0,3");
            interpTable.AddRow("0,5");

            for (var i = 1; i <= 99; i++) interpTable.AddRow(i);

            tables.CalcsHydro.IterateRows(row =>
            {
                var kqm = row["kqm"].DoubleValue;
                var CvY_columnName = row["CvY_Column"].StringValue;

                if (CvY_columnName.IndexOf("CvY_", StringComparison.Ordinal) != 0)
                    return;

                if (!tables.OrdinKtgr.DataTable.Columns.Contains(CvY_columnName))
                {
                    var value_CvY = CvYColumnConverter.ValueFromName(CvY_columnName);
                    InterpolateCvY(value_CvY);
                }

                var PY_cells = tables.OrdinKtgr.Column("PY").GetCells();
                var CvY_cells = tables.OrdinKtgr.Column(CvY_columnName).GetCells();

                var x = new List<double>();
                var y = new List<double>();

                for (var i = 0; i < PY_cells.Count; i++)
                    Etc.NoThrow(() =>
                    {
                        var xValue = PY_cells[i].DoubleValue;
                        var yValue = CvY_cells[i].DoubleValue;

                        x.Add(xValue);
                        y.Add(yValue);
                    });

                Etc.NoThrow(() =>
                {
                    var spline = LinearSpline.Interpolate(x, y);

                    interpTable.IterateRows(row2 =>
                    {
                        row2.Set(CvY_columnName,
                            spline.Interpolate(row2["PY"].DoubleValue));
                    }, CvY_columnName);
                });

                var PY = Find_PY(interpTable, kqm, CvY_columnName);
                row.Set("PY", PY);
            }, "PY");

            tables.Result.AddColumn(tables.CalcsHydro.Column("PY"));
        }

        private int Find_PY(TableProcessing.Table interpTable, double kqm, string CvY_columnName)
        {
            var PY_cells = interpTable.Column("PY").GetCells();
            var CvY_cells = interpTable.Column(CvY_columnName).GetCells();

            var rowsCount = PY_cells.Count;


            var minDiff = double.MaxValue;
            var minDiffIndex = -1;

            for (var i = 0; i < rowsCount; ++i)
            {
                var diff = Math.Abs(CvY_cells[i].DoubleValue - kqm);

                if (diff < minDiff)
                {
                    minDiff = diff;
                    minDiffIndex = i;
                }
            }

            var PY = PY_cells[minDiffIndex].IntValue;

            return PY;
        }

        private void InterpolateCvY(double value)
        {
            var interpColumnName = CvYColumnConverter.NameFromValue(value);

            var interpTable = new TableProcessing.Table("Interpolate " + interpColumnName);

            interpTable.AddColumn(tables.OrdinKtgr.Column("PY"));

            var floorValue = double.NegativeInfinity;
            var ceilValue = double.PositiveInfinity;

            for (var i = 0; i < tables.OrdinKtgr.DataTable.Columns.Count; i++)
            {
                var column = tables.OrdinKtgr.DataTable.Columns[i];

                if (column.ColumnName.IndexOf("CvY_", StringComparison.Ordinal) != 0)
                    continue;

                var CV_value = CvYColumnConverter.ValueFromName(column.ColumnName);

                if (CV_value < value)
                {
                    floorValue = CV_value;
                }
                else if (CV_value > value)
                {
                    ceilValue = CV_value;
                    break;
                }
            }

            var floorStr = CvYColumnConverter.NameFromValue(floorValue);

            var ceilStr = CvYColumnConverter.NameFromValue(ceilValue);

            interpTable.AddColumn(tables.OrdinKtgr.Column(floorStr));
            var column_res = interpTable.Column(interpColumnName);
            interpTable.AddColumn(tables.OrdinKtgr.Column(ceilStr));

            interpTable.IterateRows(row =>
            {
                double[] x = {floorValue, ceilValue};
                double[] y =
                {
                    row[floorStr].DoubleValue,
                    row[ceilStr].DoubleValue
                };

                var res = LinearSpline.Interpolate(x, y).Interpolate(value);
                row.Set(column_res.Name, res);
            }, column_res.Name);

            tables.OrdinKtgr.AddColumn(interpTable.Column(interpColumnName));
        }

        private void Rename_PY_To_PQm()
        {
            var interpTable = (TableProcessing.Table) calcMemory["interpTable"];
            interpTable.RenameTo("Interpolate PQm");

            interpTable.Column("PY").RenameTo("PQm");

            tables.CalcsHydro.Column("PY").RenameTo("PQm");
            tables.Result.Column("PY").RenameTo("PQm");

            tables.CalcsHydro.Column("CvY_Column").RenameTo("CvQm_Column");
            tables.CalcsHydro.Column("CvY").RenameTo("CvQm");
        }
    }
}