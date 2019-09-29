using SouthernBug.App.Repository;

namespace SouthernBug.App.Calculation.Table
{
    public class CalcMeteoTable : TableProcessing.Table
    {
        public CalcMeteoTable(string name,
            TableProcessing.Table operInfoMeteoTable) : base(name)
        {
            AddColumns(
                operInfoMeteoTable.Column(Tables.OperInfoMeteo.Index),
                operInfoMeteoTable.Column(Tables.OperInfoMeteo.OI_Meteo),
                operInfoMeteoTable.Column(Tables.OperInfoMeteo.Meteo));
        }
    }
}