using System;
using System.Collections.Generic;
using SouthernBug.App.TableProcessing.Mapper;

namespace SouthernBug.App.TableProcessing
{
    public class Column
    {
        public Column(Table table, string name)
        {
            Table = table;
            Name = name;
        }

        public string Name { get; private set; }

        public Table Table { get; }

        public int Height => Table.DataTable.Rows.Count;

        public Cell this[int index] => new Cell(Table.DataTable.Rows[index][Name]);

        public void RenameTo(string newName)
        {
            Table.DataTable.Columns[Name].ColumnName = newName;
            Name = newName;
        }

        public void Set(int index, object value, ICellMapper cellMapper)
        {
            value = cellMapper.Map(new Cell(value)).RawValue;

            Table.DataTable.Rows[index][Name] = value;
        }

        public void Set(int index, object value)
        {
            Set(index, value, CellMapper.Empty);
        }

        public void Set(int index, Cell cell)
        {
            Set(index, cell.RawValue);
        }

        public void SetDataFrom(Column column)
        {
            if (Height != column.Height) throw new Exception("Columns heights must be equal");

            for (var i = 0; i < Height; i++) Set(i, column[i].RawValue);
        }

        public void Fill(object value)
        {
            for (var i = 0; i < Height; i++) Set(i, value);
        }

        public List<Cell> GetCells()
        {
            var result = new List<Cell>();

            for (var i = 0; i < Height; i++) result.Add(this[i]);

            return result;
        }

        public void PlaceAfter(string columnName)
        {
            var ordinal = Table.DataTable.Columns[columnName].Ordinal;
            Table.DataTable.Columns[Name].SetOrdinal(ordinal + 1);
        }

        public void Delete()
        {
            Table.DataTable.Columns.Remove(Name);
        }
    }
}