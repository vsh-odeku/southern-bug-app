namespace SouthernBug.App.TableProcessing.Mapper
{
    public static class CellMapper
    {
        public static readonly ICellMapper Empty = new EmptyCellMapper();
        public static readonly ICellMapper Rounder2 = new RoundDoubleCellMapper(2);
        public static readonly ICellMapper RounderInt = new RoundDoubleCellMapper(0);
        public static readonly ICellMapper ZeroOrGreater = new ZeroOrGreaterCellMapper();

        public static readonly ICellMapper ZeroOrGreaterInt = Combine(
            ZeroOrGreater, RounderInt);

        public static readonly ICellMapper ZeroOrGreaterRounded2 = Combine(
            ZeroOrGreater, Rounder2);

        public static ICellMapper Combine(params ICellMapper[] mappers)
        {
            return new CombinedCellMapper(mappers);
        }
    }
}