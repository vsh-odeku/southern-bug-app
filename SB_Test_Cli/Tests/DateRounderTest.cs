using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SouthernBug.App.Model;

namespace SB_Test_Cli.Tests
{
    [TestFixture]
    public class DateRounderTest
    {
        private DateAverage dateAverage = new DateAverage(new DateParser(2010));

        [Test]
        public void TestTable()
        {
            Assert.Pass();

            var dt = new DateTime(2010, 1, 1);
            Console.WriteLine($"{"<Date>", -10} {"<Rounded5Date>", -10}");
            for (int i = 0; i < 100; i++)
            {
                var dateTxt = dt.ToString("dd.MM", CultureInfo.InvariantCulture);
                var roundedDt = dateAverage.RoundDateTime(dt, 5);
                var roundedTxt = roundedDt.ToString("dd.MM", CultureInfo.InvariantCulture);

                Console.WriteLine($"{dateTxt,-10} {roundedTxt,-10}");
                dt = dt.AddDays(1);
            }
        }
    }
}
