using System;
using System.Data;
using System.Text;

namespace SB_Post_Importer.App
{
    public static class Utils
    {
        public static void NullSafeDispose(this IDisposable disposable)
        {
            if (disposable != null) disposable.Dispose();
        }

        public static string DumpDataTable(DataTable table)
        {
            var data = string.Empty;
            var sb = new StringBuilder();

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        sb.Append(item);
                        sb.Append(',');
                    }

                    sb.AppendLine();
                }

                data = sb.ToString();
            }

            return data;
        }
    }
}