using System.Data;
using SB_Post_Importer.App.Storage;

namespace SB_Post_Importer.App.Importer
{
    internal class PostsImporter
    {
        private DataTable resultDt;


        public void AddDataTable(DataTable dt)
        {
            AddEmptyRow(dt);
            AddExtraColumns(dt);
            CopyToResultTable(dt);
        }

        public DataTable GetResultTable()
        {
            return resultDt;
        }

        private void AddEmptyRow(DataTable dt)
        {
            if (dt.Rows.Count == 0) dt.Rows.Add();
        }

        private void AddExtraColumns(DataTable dt)
        {
            dt.Columns.Add("OI_Hydro");
            dt.Columns.Add("Hydro");

            foreach (DataRow row in dt.Rows)
            {
                row["OI_Hydro"] = FindOI(dt.TableName);
                row["Hydro"] = dt.TableName;
            }
        }

        private void CopyToResultTable(DataTable dt)
        {
            if (resultDt == null)
            {
                resultDt = dt.Copy();
                resultDt.TableName = "resultDt";
                return;
            }

            foreach (DataRow dr in dt.Rows) resultDt.Rows.Add(dr.ItemArray);
        }

        private string FindOI(string hydro)
        {
            var hydroDt = (DataTable) GlobalStorage.Get("hydro");

            foreach (DataRow row in hydroDt.Rows)
                if ((string) row["Hydro"] == hydro)
                    return (string) row["OI_Hydro"];

            return "???";
        }
    }
}