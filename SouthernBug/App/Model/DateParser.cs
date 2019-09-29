using System;
using System.Globalization;

namespace SouthernBug.App.Model
{
    public class DateParser
    {
        private readonly int year;

        public DateParser(int year)
        {
            this.year = year;
        }

        public DateTime ParseDayMonth(string dayMonth, char delimiter = '.')
        {
            try
            {
                var values = dayMonth.Split(delimiter);

                var day = int.Parse(values[0]);
                var month = int.Parse(values[1]);

                return new DateTime(year, month, day);
            }
            catch (Exception e)
            {
                throw new FormatException("Invalid format string", e);
            }
        }

        public DateTime FromDayOfYear(int dayOfYear)
        {
            var dt = new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
            return dt;
        }


        public string ToDayMonth(DateTime dateTime, string delimiter = ".",
            string prefix = "", string postfix = "")
        {
            var dayStr = dateTime.ToString("dd", CultureInfo.InvariantCulture);
            var monthStr = dateTime.ToString("MM", CultureInfo.InvariantCulture);

            return $"{prefix}{dayStr}{delimiter}{monthStr}{postfix}";
        }
    }
}