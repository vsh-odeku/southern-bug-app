using SouthernBug.App.Repository;
using SouthernBug.App.Util;

namespace SouthernBug.App.TableProcessing
{
    public class DbTableLoader
    {
        private readonly TableRepository tableRepository;

        public DbTableLoader(TableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public Table LoadTable(string name, Args args = null)
        {
            var conn = tableRepository.GetWritableDataTableConnection(name, args);

            conn.Pull();
            return new Table(conn.LocalDataTable);
        }
    }
}