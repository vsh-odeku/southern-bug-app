using System;
using System.Linq;

namespace SouthernBug.App.Model
{
    public class DateAverage
    {
        private readonly DateParser dateParser;

        public DateAverage(DateParser dateParser)
        {
            this.dateParser = dateParser;
        }

        public string CalcFor(params string[] dayDotMonthItems)
        {
            if (!dayDotMonthItems.Any()) return "";

            if (dayDotMonthItems.Length == 1) return dayDotMonthItems[0];

            var daysOfYearAvg = dayDotMonthItems.Select(item =>
                {
                    try
                    {
                        return dateParser.ParseDayMonth(item).DayOfYear;
                    }
                    catch (FormatException)
                    {
                        return -1;
                    }
                })
                .Where(item => item != -1)
                .Average();

            var avgDateTime = dateParser
                .FromDayOfYear((int) Math.Round(daysOfYearAvg, MidpointRounding.AwayFromZero));

            return dateParser.ToDayMonth(avgDateTime);
        }

        public string RoundDayMonth(string dayMonth, int n)
        {
            var dt = dateParser.ParseDayMonth(dayMonth);

            return dateParser.ToDayMonth(RoundDateTime(dt, n));
        }

        public DateTime RoundDateTime(DateTime dt, int n)
        {
            var lastDay = DateTime.DaysInMonth(dt.Year, dt.Month);

            lastDay = lastDay < 30 ? 25 : 30;

            int roundedDay = 1;
            if (dt.Day <= 5) roundedDay = 5;
            else if(dt.Day >= lastDay) roundedDay = lastDay;
            else
            {
                var roundedDoubleDay = Math.Round(dt.Day / 5.0) * 5;
                roundedDay = (int)Math.Round(roundedDoubleDay, MidpointRounding.AwayFromZero);
            }
            return new DateTime(dt.Year, dt.Month, roundedDay);
        }
    }
}