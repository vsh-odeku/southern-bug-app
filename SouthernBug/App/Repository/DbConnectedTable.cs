using System.Data;
using System.Data.SQLite;
using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Repository.TableContract;

namespace SouthernBug.App.Repository
{
    public class DbConnectedTable : IDataTableConnection
    {
        private readonly BaseTableContract tableContract;

        private readonly SQLiteDataAdapter _adapter;

        public DbConnectedTable(SQLiteDataAdapter adapter, BaseTableContract tableContract)
        {
            _adapter = adapter;
            this.tableContract = tableContract;
        }

        public string TableName => tableContract.TableName;

        public string[] IgnoredColumns => tableContract.HiddenColumns;

        public DataTable LocalDataTable { get; private set; }

        public bool IsPushAvailable => true;

        public void Pull()
        {
            LocalDataTable = new DataTable(TableName);
            _adapter.Fill(LocalDataTable);
        }

        public void Push()
        {
            var builder = new SQLiteCommandBuilder(_adapter);
            _adapter.UpdateCommand = builder.GetUpdateCommand();
            _adapter.InsertCommand = builder.GetInsertCommand();
            _adapter.DeleteCommand = builder.GetDeleteCommand();

            _adapter.Update(LocalDataTable);
        }

        public object GetMeta(string key)
        {
            return tableContract.GetMeta(key);
        }
    }
}