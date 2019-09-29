using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Entity.Dump;
using SouthernBug.App.Util;

namespace SouthernBug.App.Entity.Server
{
    internal class LocalDataTableServer : BaseDataTableServer
    {
        private readonly TablesDump tablesDump;

        public LocalDataTableServer(TablesDump tablesDump)
        {
            this.tablesDump = tablesDump;

            tablesInfo = tablesDump.Schema;
        }

        public override IDataTableConnection GetByName(string name, Args args = null)
        {
            var dt = tablesDump.GetDataTable(name);
            return new LocalDataTableConnection(dt);
        }
    }
}