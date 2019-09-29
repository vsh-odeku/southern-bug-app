using System.Data;
using System.Data.SQLite;

namespace SB_Post_Importer.App.Storage
{
    public class Repository
    {
        private readonly SQLiteConnection dbConnection;

        public Repository(string dbConnectionString)
        {
            dbConnection = new SQLiteConnection(dbConnectionString);
            dbConnection.Open();
        }

        public DataTable GetTable(string sql)
        {
            var command = new SQLiteCommand(sql, dbConnection);
            var adapter = new SQLiteDataAdapter(command);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void ExecuteSql(string sql)
        {
            var command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
    }
}