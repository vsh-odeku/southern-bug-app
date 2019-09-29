using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClosedXML.Excel;

namespace SouthernBug.App.Model
{
    class XlColumnTypes
    {
        private static readonly Lazy<XlColumnTypes> lazy =
            new Lazy<XlColumnTypes>(() => new XlColumnTypes());

        private Dictionary<XLCellValues, HashSet<string>> dict;

        private XlColumnTypes()
        {
            InitDict();
        }

        public XLCellValues GetTypeFor(string columnName)
        {
            if (columnName.Contains("_Column")
                || columnName.Contains("Уравнение")
                || columnName.Contains("Формула"))
            {
                return XLCellValues.Text;
            }


            foreach (var entry in dict)
            {
                if (entry.Value.Contains(columnName))
                {
                    return entry.Key;
                }
            }

            return XLCellValues.Number;
        }

        private void InitDict()
        {
            dict = new Dictionary<XLCellValues, HashSet<string>>
            {
                {
                    XLCellValues.Text, new HashSet<string>
                    {
                        "Hydro", "Meteo", "OBL", "Key", "Value", "Tkd", "Tkdd", "DSm",
                        "DBR", "RDB", "SRDB", "PDB", "DB", "DQmR", "RDQm", "SRDQm", "PDQm", "DQM"
                    }
                },
            };

        }

        public static XlColumnTypes GetInstance()
        {
            return lazy.Value;
        }
    }
}
