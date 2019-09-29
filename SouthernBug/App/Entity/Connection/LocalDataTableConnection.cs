using System;
using System.Data;

namespace SouthernBug.App.Entity.Connection
{
    public class LocalDataTableConnection : IDataTableConnection
    {
        public LocalDataTableConnection(DataTable dataTable)
        {
            LocalDataTable = dataTable;
        }

        public bool IsPushAvailable => false;

        public string[] IgnoredColumns => new string[] { };

        public DataTable LocalDataTable { get; }

        public string TableName => LocalDataTable.TableName;

        public object GetMeta(string key)
        {
            return null;
        }

        public void Pull()
        {
            // NOP
        }

        public void Push()
        {
            throw new NotImplementedException();
        }
    }
}