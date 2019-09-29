using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SouthernBug.App.Entity.Dump
{
    public class TablesInfo
    {
        protected OrderedDictionary tablesDict = new OrderedDictionary();

        public List<string> GetTableGroups()
        {
            var list = new List<string>();

            foreach (var key in tablesDict.Keys) list.Add((string) key);

            return list;
        }

        public List<string> GetGroupTableNames(string groupName)
        {
            var tableNames = (List<string>) tablesDict[groupName];
            return tableNames;
        }

        public void AddTable(string groupName, string tableName)
        {
            AddGroupIfNotExists(groupName);

            var tables = (List<string>) tablesDict[groupName];
            tables.Add(tableName);
        }

        public void AddGroup(string groupName, IEnumerable<string> tableNames)
        {
            tablesDict.Add(groupName, tableNames.ToList());
        }

        public void AddGroup(string groupName)
        {
            AddGroup(groupName, new string[] { });
        }

        public void AddGroupIfNotExists(string groupName)
        {
            if (!tablesDict.Contains(groupName)) AddGroup(groupName);
        }
    }
}