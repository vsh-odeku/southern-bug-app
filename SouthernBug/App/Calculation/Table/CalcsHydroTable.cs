using SouthernBug.App.Repository;

namespace SouthernBug.App.Calculation.Table
{
    public class CalcsHydroTable : TableProcessing.Table
    {
        public CalcsHydroTable(string name,
            TableProcessing.Table operInfoHydroTable) : base(name)
        {
            AddColumns(
                operInfoHydroTable.Column(Tables.OperInfoHydro.Index),
                operInfoHydroTable.Column(Tables.OperInfoHydro.OI_Hydro),
                operInfoHydroTable.Column(Tables.OperInfoHydro.Hydro));
        }
    }
}