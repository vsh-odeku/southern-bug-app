using System.Data.SQLite;
using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Repository.TableContract;
using SouthernBug.App.Util;

namespace SouthernBug.App.Repository
{
    public class TableRepository
    {
        private readonly SQLiteConnection conn;

        public TableRepository()
        {
            conn = new SQLiteConnection(Constants.DbConnectionString);
            conn.Open();
        }

        public IDataTableConnection GetWritableDataTableConnection(string tableName, Args args = null)
        {
            var contract = TableContractFactory.Create(tableName, args);

            var command = new SQLiteCommand(contract.CreateSql(), conn);

            var adapter = new SQLiteDataAdapter(command);

            return new DbConnectedTable(adapter, contract);
        }
    }
}