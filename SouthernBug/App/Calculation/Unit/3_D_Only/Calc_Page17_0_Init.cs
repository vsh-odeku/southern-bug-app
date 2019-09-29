using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SouthernBug.App.Calculation.Table;
using SouthernBug.App.Repository;

namespace SouthernBug.App.Calculation.Unit._3_D_Only
{
    class Calc_Page17_0_Init : BaseCalc
    {
        public override void Perform()
        {
            if (!calcBranch.D1 && !calcBranch.D2)
                return;

            tables.ResultEstimation = tables.ConsultSp.Copy();
            tables.ResultEstimation.DataTable.TableName = tables.GetEstimationTableName();
            tables.ResultEstimation.Column("rowid").Delete();

            tables.ResultEstimation
                .Column("DQm")
                .SetDataFrom(tables.OperInfoHydro.Column("DQm"));

            tables.ResultEstimation
                .Column("DB")
                .SetDataFrom(tables.OperInfoHydro.Column("DB"));
        }
    }
}