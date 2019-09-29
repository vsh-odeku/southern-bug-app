using System;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.Calculation.Unit._3_D_Only
{
    internal abstract class BaseDCalc : BaseCalc
    {
        protected void RowsDateDiff(string aName, string bName, string resultName,
            bool addToEstimationTable = true, ICellMapper resultMapper = null)
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                row.Set(resultName, DateDiff(row, aName, bName), resultMapper);
            }, resultName);

            if(!addToEstimationTable) return;
            
            tables.ResultEstimation.Column(resultName)
                .SetDataFrom(tables.CalcsHydro.Column(resultName));
        }

        protected string DateDiff(Row row, string aName, string bName)
        {
            var diff = GetDate(row[aName]) - GetDate(row[bName]);
            return diff.Days.ToString();
        }
    }
}