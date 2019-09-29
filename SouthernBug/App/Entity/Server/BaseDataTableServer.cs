using System.Collections.Generic;
using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Entity.Dump;
using SouthernBug.App.Util;

namespace SouthernBug.App.Entity.Server
{
    public abstract class BaseDataTableServer : IDataTableServer
    {
        protected TablesInfo tablesInfo = new TablesInfo();

        public abstract IDataTableConnection GetByName(string name, Args args = null);

        public List<string> GetGroupTableNames(string groupName)
        {
            return tablesInfo.GetGroupTableNames(groupName);
        }

        public List<string> GetTableGroups()
        {
            return tablesInfo.GetTableGroups();
        }
    }
}