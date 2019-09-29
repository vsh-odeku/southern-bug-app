using System.Linq;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.TableProcessing.Mapper;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation.Unit._0_Always
{
    public class Calc_Page01_BlockA : BaseCalc
    {
        private string Arg_Qp;

        public override void Perform()
        {
            Arg_Qp = userInput[CalculationsForm.Arg_Qp];

            if (Arg_Qp == QpItemsRepr.Wj)
            {
                Calc_kW();
                Calc_kWSr();
            }
            else
            {
                Calc_MM();
                Calc_QP();
                Restore_QP();
                Calc_QQSR();
                Calc_kQp();
            }
        }

        private void Calc_kW()
        {
            var column_W = tables.CalcsMeteo.Column("W");
            column_W.SetDataFrom(tables.OperInfoMeteo.Column("W100_B"));

            tables.CalcsMeteo.AddColumn(
                tables.BazaInfoMeteo.Column("WHB"));

            tables.CalcsMeteo.IterateRows(row =>
            {
                var value_kW = row["W"].DoubleValue / row["WHB"].DoubleValue;
                row.Set("kW", value_kW, CellMapper.Rounder2);
            }, "kW");
        }

        private void Calc_kWSr()
        {
            tables.CalcsHydro.AddColumnIfNotExist(
                tables.BazaInfoHydro.Column("OI_METEO"));

            CalcUtils.CalcMeteoAvg(tables.CalcsMeteo.GetRows(), "kW",
                tables.CalcsHydro, "kWSR",
                CellMapper.Rounder2, tables.Result);
        }

        private void Calc_MM()
        {
            string MM;

            if (Arg_Qp == QpItemsRepr.QPB)
            {
                var cells = tables.OperInfoHydro.Column("MQP").GetCells();
                var values_MM = from cell in cells
                    where !cell.IsEmpty
                    select cell.IntValue;

                MM = values_MM.First().ToString();
                if (MM.Length == 1) MM = "0" + MM;
            }
            else //Q12..Q03
            {
                MM = DayAndMonthItemsRepr.QMM_to_MM(Arg_Qp);
            }

            tables.CalcsHydro.Column("MM").Fill(MM);
            calcMemory["MM"] = MM;
        }

        private void Calc_QP()
        {
            var MM = calcMemory["MM"].ToString();

            var column_QP = tables.CalcsHydro.Column("QP");
            column_QP.SetDataFrom(tables.OperInfoHydro.Column("Q" + MM));
        }

        private void Restore_QP()
        {
            var column_F = tables.BazaInfoHydro.Column("F");
            var column_QP = tables.CalcsHydro.Column("QP");

            var equationName = "QP = b * F";

            var cellMapper = CellMapper.Combine(new ZeroOrGreaterCellMapper(),
                new RoundDoubleCellMapper(5));

            CalcUtils.RestoreColumn(tables.CoeffsTable,
                column_F, column_QP,
                cellMapper, equationName,
                false);

            tables.Result.Column("QP").SetDataFrom(
                tables.CalcsHydro.Column("QP_Used"));
        }

        private void Calc_QQSR()
        {
            var MM = calcMemory["MM"].ToString();

            var columnName_QQSR = $"Q{MM}SR";
            var column_QQSR = tables.BazaInfoHydro.Column(columnName_QQSR);

            tables.CalcsHydro.Column("QQSR").SetDataFrom(column_QQSR);
        }

        private void Calc_kQp()
        {
            tables.CalcsHydro.IterateRows(row =>
            {
                var value_kQP = row["QP_Used"].DoubleValue / row["QQSR"].DoubleValue;

                row.Set("kQP", value_kQP, CellMapper.Rounder2);
            }, "kQP");

            tables.Result.AddColumn(tables.CalcsHydro.Column("kQP"));
        }
    }
}