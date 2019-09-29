using System.Collections.Generic;
using System.Data;
using SB_Post_Importer.App.Table;

namespace SB_Post_Importer.App.Importer
{
    internal class DbImporter
    {
        public List<string> GetSqlImportStatements(DataTable dt)
        {
            var postsTable = new PostsTable("Posts_Import");

            var statements = new List<string>();

            statements.Add("BEGIN TRANSACTION;");
            statements.Add(postsTable.GetSqlCreateStatement());
            statements.AddRange(postsTable.GetSqlInsertStatements(dt));
            statements.Add("END TRANSACTION;");

            return statements;
        }
    }
}