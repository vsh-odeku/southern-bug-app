using System;

namespace SouthernBug.App.TableProcessing.Mapper
{
    public class RoundDoubleCellMapper : ICellMapper
    {
        private readonly int digits;

        public RoundDoubleCellMapper(int digits)
        {
            this.digits = digits;
        }

        public Cell Map(Cell cell)
        {
            if (cell.IsEmpty)
                return cell;

            var newValue = Math.Round(cell.DoubleValue, digits,
                MidpointRounding.AwayFromZero);

            return new Cell(newValue);
        }
    }
}