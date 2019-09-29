namespace SouthernBug.App.TableProcessing.Mapper
{
    public class CombinedCellMapper : ICellMapper
    {
        private readonly ICellMapper[] mappers;

        public CombinedCellMapper(params ICellMapper[] mappers)
        {
            this.mappers = mappers;
        }

        public Cell Map(Cell cell)
        {
            foreach (var mapper in mappers) cell = mapper.Map(cell);

            return cell;
        }
    }
}