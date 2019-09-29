namespace SouthernBug.App.TableProcessing.Mapper
{
    internal class ZeroOrGreaterCellMapper : ICellMapper
    {
        public Cell Map(Cell cell)
        {
            if (cell.IsEmpty || cell.DoubleValue > 0)
                return cell;

            return new Cell(0);
        }
    }
}