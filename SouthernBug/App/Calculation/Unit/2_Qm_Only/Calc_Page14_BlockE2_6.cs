using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Util;

namespace SouthernBug.App.Calculation.Unit._2_Qm_Only
{
    internal class Calc_Page14_BlockE2_6 : BaseCalc
    {
        private static readonly string[] NumberColumns =
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        private readonly Dictionary<string, DataTable> postGroups 
            = new Dictionary<string, DataTable>();

        public override void Perform()
        {
            if (!calcBranch.Qm)
                return;

            Group_Posts();
            Find_HRm();
        }

        private void Group_Posts()
        {
            tables.Posts.IterateRows(row =>
            {
                var key = row["OI_Hydro"].StringValue;

                if (!postGroups.ContainsKey(key))
                {
                    var newDt = new DataTable();
                    postGroups[key] = newDt;

                    foreach (DataColumn col in tables.Posts.DataTable.Columns) newDt.Columns.Add(col.ColumnName);
                }

                var dt = postGroups[key];
                dt.Rows.Add(row.GetDataRow().ItemArray);
            }, null);
        }

        private void Find_HRm()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                HRm_Finder(row["OI_Hydro"].StringValue, row["QRm"].DoubleValue);
                row.Set("QRm_Posts", calcMemory["QRm_Posts"], CellMapper.Rounder2);
                row.Set("HRm", calcMemory["HRm"]);
            }, "QRm_Posts", "HRm");

            tables.Result.AddColumn(tables.CalcsHydro.Column("HRm"));
        }

        private void HRm_Finder(string val_OI_Hydro, double val_QRm)
        {
            var dt = postGroups[val_OI_Hydro];

            var closestRowN = 0;
            var closestColN = 0;
            var closestValue = 0.0;
            var closestDiff = double.PositiveInfinity;

            for (var colN = 0; colN < dt.Columns.Count; colN++)
            {
                if (!NumberColumns.Contains(dt.Columns[colN].ColumnName))
                    continue;

                for (var rowN = 0; rowN < dt.Rows.Count; rowN++)
                    Etc.NoThrow(() =>
                    {
                        var value = new Cell(dt.Rows[rowN][colN]).DoubleValue;
                        var diff = Math.Abs(value - val_QRm);

                        if (diff < closestDiff)
                        {
                            closestRowN = rowN;
                            closestColN = colN;
                            closestValue = value;
                            closestDiff = diff;
                        }
                    });
            }

            var colNumber = new Cell(dt.Rows[closestRowN]["H"]).IntValue;
            var rowNumber = new Cell(dt.Columns[closestColN].ColumnName).IntValue;

            calcMemory["HRm"] = colNumber + rowNumber;
            calcMemory["QRm_Posts"] = closestValue;
        }
    }
}