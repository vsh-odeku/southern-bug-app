using SB_Post_Importer.App.Storage;
using SB_Post_Importer.App.Table;

namespace SB_Post_Importer.App
{
    internal class Magic
    {
        public static void Believe()
        {
            GlobalStorage.Set("repo", new Repository(Constants.DbConnectionString));

            GetHydroTable();
        }

        private static void GetHydroTable()
        {
            var repo = (Repository) GlobalStorage.Get("repo");
            var dt = repo.GetTable(new HydroTable().GetSqlSelectStatement());
            GlobalStorage.Set("hydro", dt);
        }
    }
}