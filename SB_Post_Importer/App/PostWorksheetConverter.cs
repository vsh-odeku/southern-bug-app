using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OfficeOpenXml;

namespace SB_Post_Importer.App
{
    public class PostWorksheetConverter
    {
        private static readonly string[] UserInputTableHeader =
        {
            "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        private static readonly string[] DbTableHeader =
        {
            "H", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        private readonly DataTable dataTable;

        private readonly ExcelWorksheet worksheet;

        private bool inTable;

        private bool isConverted;

        public PostWorksheetConverter(ExcelWorksheet worksheet)
        {
            this.worksheet = worksheet;
            dataTable = CreateDataTable();
        }

        public DataTable Convert()
        {
            if (isConverted) throw new Exception("Worksheet is already converted");
            isConverted = true;

            var totalColumns = worksheet.Dimension.End.Column;

            if (totalColumns != dataTable.Columns.Count) return dataTable;

            var totalRows = worksheet.Dimension.End.Row;

            for (var rowNum = 1; rowNum <= totalRows; rowNum++)
            {
                var row = worksheet
                    .Cells[rowNum, 1, rowNum, totalColumns]
                    .Select(c => c.Value == null ? string.Empty : c.Value.ToString().Trim());

                OnRow(row);
            }

            return dataTable;
        }

        private void OnRow(IEnumerable<string> row)
        {
            var enumerable = row.ToList();

            if (!inTable && UserInputTableHeader.SequenceEqual(enumerable))
            {
                inTable = true;
                return;
            }

            if (!inTable) return;

            if (enumerable.All(str => str == "")) return;

            dataTable.Rows.Add(enumerable.ToArray());
        }

        private DataTable CreateDataTable()
        {
            var table = new DataTable(worksheet.Name.Trim());

            DbTableHeader
                .ToList()
                .ForEach(col => table.Columns.Add(col));

            return table;
        }
    }
}