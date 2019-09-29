using System;
using System.Globalization;
using SouthernBug.App.TableProcessing;

namespace SouthernBug.App.Calculation.Converter
{
    public static class CvYColumnConverter
    {
        public static double ValueFromName(string name)
        {
            var strVal = name.Replace("CvY_", "");
            var doubleVal = new Cell(strVal).DoubleValue;

            return doubleVal;
        }

        public static string NameFromValue(double value)
        {
            if (value < 0.1)
                value = 0.1;
            else if (value > 2) value = 2;

            value = Math.Round(value, 2, MidpointRounding.AwayFromZero);

            var strVal = value.ToString(
                CultureInfo.InvariantCulture);

            if (strVal.Length == 1) strVal += ".0";

            var name = "CvY_" + strVal;

            return name;
        }
    }
}