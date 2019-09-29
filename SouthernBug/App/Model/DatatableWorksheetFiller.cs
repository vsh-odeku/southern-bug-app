using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using SouthernBug.App.TableProcessing;

namespace SouthernBug.App.Model
{
    public static class DatatableWorksheetFiller
    {
        public static void Fill(IXLWorksheet ws, DataTable dt)
        {
            FillTitle(ws, dt);
            FillBody(ws, dt);

            StyleAll(ws);
            StyleHeader(ws);
        }

        private static void FillTitle(IXLWorksheet ws, DataTable dt)
        {
            var cell = ws.FirstRow().FirstCell();

            foreach (DataColumn column in dt.Columns)
            {
                cell.Value = column.ColumnName;
                cell = cell.CellRight();
            }
        }

        private static void FillBody(IXLWorksheet ws, DataTable dt)
        {
            var typeFinder = XlColumnTypes.GetInstance();

            for (int colI = 0; colI < dt.Columns.Count; colI++)
            {
                var colName = dt.Columns[colI].ColumnName;
                var colType = typeFinder.GetTypeFor(colName);

                for (int rowI = 0; rowI < dt.Rows.Count; rowI++)
                {
                    var cell = ws.Cell(rowI + 2, colI + 1);
                    var dataCell = new Cell(dt.Rows[rowI][colI]);
                    if (colType == XLCellValues.Number)
                    {
                        try
                        {
                            cell.SetValue(dataCell.DoubleValue);
                        }
                        catch
                        {
                            cell.SetValue(dataCell.StringValue);
                        }

                    }
                    else
                    {
                        cell.SetValue(dataCell.StringValue);
                    }
                }
            }
        }

        private static void StyleAll(IXLWorksheet ws)
        {
            var style = ws.RangeUsed().Style;

            style
                .Border.SetInsideBorder(XLBorderStyleValues.Thin)
                .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            ws.Columns().AdjustToContents();
        }

        private static void StyleHeader(IXLWorksheet ws)
        {
            var headerRange = ws.Range(
                ws.FirstRow().FirstCell(),
                ws.FirstRow().LastCellUsed());

            headerRange.Style.Font.Bold = true;
        }
    }
}