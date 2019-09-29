namespace SouthernBug.App.TableProcessing.Mapper
{
    internal class EmptyCellMapper : ICellMapper
    {
        public Cell Map(Cell cell)
        {
            return cell;
        }
    }
}