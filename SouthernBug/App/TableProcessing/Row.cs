using System.Data;
using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.TableProcessing
{
    public class Row
    {
        public readonly int Index;

        public Row(Table table, int rowIndex)
        {
            Table = table;
            this.Index = rowIndex;
        }

        public Table Table { get; }

        public Cell this[string columnName] => new Cell(GetDataRow()[columnName]);

        public void Set(string columnName, object value, ICellMapper cellMapper = null)
        {
            if (cellMapper != null)
                value = cellMapper.Map(new Cell(value)).RawValue;

            GetDataRow()[columnName] = value;
        }

        public void Set(string columnName, Cell cell)
        {
            Set(columnName, cell.RawValue);
        }

        public DataRow GetDataRow()
        {
            return Table.DataTable.Rows[Index];
        }
    }
}