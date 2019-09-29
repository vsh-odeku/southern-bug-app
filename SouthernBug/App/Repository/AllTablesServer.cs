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
            tablesInfo.AddGroup("Оперативные", Tables.Names.OperTables);
            tablesInfo.AddGroup("Базовые", Tables.Names.BasicTables);
            tablesInfo.AddGroup("Посты", Tables.Names.PostTablesDic.Keys);
        }
    }
}