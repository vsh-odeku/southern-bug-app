using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Entity.Server;
using SouthernBug.App.Util;

namespace SouthernBug.App.Repository
{
    public class AllTablesServer : BaseDataTableServer
    {
        private readonly TableRepository tableRepository;

        public AllTablesServer(TableRepository tableRepository)
        {
            this.tableRepository = tableRepository;

            InitTables();
        }

        public override IDataTableConnection GetByName(string name, Args args = null)
        {
            return tableRepository.GetWritableDataTableConnection(name, args);
        }

        private void InitTables()
        {
            tablesInfo.AddGroup("Оперативні", Tables.Names.OperTables);
            tablesInfo.AddGroup("Базові", Tables.Names.BasicTables);
            tablesInfo.AddGroup("Криві витрат води", Tables.Names.PostTablesDic.Keys);
        }
    }
}