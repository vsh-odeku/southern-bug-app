using System.Collections.Generic;
using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Util;

namespace SouthernBug.App.Entity.Server
{
    public interface IDataTableServer
    {
        List<string> GetTableGroups();
        List<string> GetGroupTableNames(string groupName);

        IDataTableConnection GetByName(string name, Args args = null);
    }
}