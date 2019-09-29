using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SB_Post_Importer.App.Table
{
    public class PostsTable
    {
        private readonly string tableName;

        public PostsTable(string name)
        {
            tableName = name;
        }

        public string GetSqlCreateStatement()
        {
            return "CREATE TABLE " + tableName + @" (
                    [H] TEXT,
                    [0] TEXT,
                    [1] TEXT,
                    [2] TEXT,
                    [3] TEXT,
                    [4] TEXT,
                    [5] TEXT,
                    [6] TEXT,
                    [7] TEXT,
                    [8] TEXT,
                    [9] TEXT,
                    [OI_Hydro] TEXT,
                    [Hydro] TEXT);";
        }

        public List<string> GetSqlInsertStatements(DataTable dataTable)
        {
            var result = new List<string>();

            foreach (DataRow row in dataTable.Rows)
            {
                var values = row.ItemArray
                    .Select(o => "\"" + o.ToString() + "\"");

                var valuesStr = string.Join(", ", values.ToArray());

                var sql = $"INSERT INTO {tableName} VALUES ({valuesStr});";

                result.Add(sql);
            }

            return result;
        }
    }
}