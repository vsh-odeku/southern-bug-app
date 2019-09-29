using System;
using System.Collections.Generic;
using System.Data;

namespace SouthernBug.App.TableProcessing
{
    public class Table
    {
        public Table(DataTable dataTable)
        {
            DataTable = dataTable;
        }

        public Table(string name)
        {
            DataTable = new DataTable(name);
        }

        public DataTable DataTable { get; protected set; }

        public Table Copy()
        {
            return new Table(DataTable.Copy());
        }

        public void RenameTo(string newName)
        {
            DataTable.TableName = newName;
        }

        public Column AddColumn(string name)
        {
            DataTable.Columns.Add(name);

            return Column(name);
        }

        public Column AddColumn(Column otherColumn)
        {
            DataTable.Columns.Add(otherColumn.Name);

            if (DataTable.Columns.Count == 1)
            {
                AddFirstColumn(otherColumn);
                return Column(otherColumn.Name);
            }

            var otherTableRowsCount = otherColumn.Table.DataTable.Rows.Count;
            if (otherTableRowsCount != DataTable.Rows.Count)
                throw new Exception(
                    "Column's height must be equal this table height");

            var thisColumn = Column(otherColumn.Name);

            for (var i = 0; i < otherTableRowsCount; i++) thisColumn.Set(i, otherColumn[i].RawValue);

            return Column(otherColumn.Name);
        }

        public void AddColumnIfNotExist(Column otherColumn)
        {
            if (!DataTable.Columns.Contains(otherColumn.Name)) AddColumn(otherColumn);
        }

        public void AddColumnsIfNotExist(Table otherTable, params string[] otherColumnNames)
        {
            foreach (var otherColumnName in otherColumnNames) AddColumnIfNotExist(otherTable.Column(otherColumnName));
        }

        public void AddColumnIfNotExist(string name)
        {
            if (!DataTable.Columns.Contains(name)) AddColumn(name);
        }

        public void AddColumns(params string[] names)
        {
            foreach (var name in names) AddColumn(name);
        }

        public void AddColumns(params Column[] columns)
        {
            foreach (var column in columns) AddColumn(column);
        }

        public Column Column(string name)
        {
            AddColumnIfNotExist(name);

            return new Column(this, name);
        }

        public void IterateRows(Action<Row> action, string newColumn, params string[] newColumns)
        {
            if (newColumn != null)
                AddColumnIfNotExist(newColumn);

            foreach (var col in newColumns) AddColumnIfNotExist(col);

            for (var i = 0; i < DataTable.Rows.Count; i++)
                try
                {
                    action(new Row(this, i));
                }
                catch (Exception e)
                {
                    if (!(e is FormatException)) throw;
                }
        }

        public List<Row> GetRows()
        {
            var result = new List<Row>();

            for (var i = 0; i < DataTable.Rows.Count; i++) result.Add(new Row(this, i));

            return result;
        }

        public void AddRow(params object[] values)
        {
            DataTable.Rows.Add(values);
        }

        private void AddFirstColumn(Column otherColumn)
        {
            for (var i = 0; i < otherColumn.Table.DataTable.Rows.Count; i++)
                DataTable.Rows.Add(otherColumn[i].RawValue);
        }
    }
}