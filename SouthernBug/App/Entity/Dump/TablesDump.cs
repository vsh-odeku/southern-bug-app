using System;
using System.Collections.Generic;
using System.Data;

namespace SouthernBug.App.Entity.Dump
{
    public class TablesDump
    {
        private readonly Dictionary<string, DataTable> tableNameDict = new Dictionary<string, DataTable>();

        public TablesDump()
        {
            Schema = new TablesInfo();
        }

        public TablesInfo Schema { get; }

        public void AddTable(string groupName, DataTable dataTable)
        {
            var tableName = dataTable.TableName;

            if (tableName == "") throw new Exception("DataTable must have not empty name");

            if (tableNameDict.ContainsKey(tableName))
            {
                var message = $"DataTable's name (currently is \"{tableName}\") must be unique";

                throw new Exception(message);
            }

            Schema.AddTable(groupName, dataTable.TableName);
            tableNameDict.Add(tableName, dataTable);
        }

        public DataTable GetDataTable(string name)
        {
            return tableNameDict[name];
        }
    }
}