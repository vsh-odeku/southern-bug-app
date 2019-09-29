using System;
using NUnit.Framework;
using SouthernBug.App.Model;

namespace SB_Test_Cli.Tests
{
    [TestFixture]
    public class DateParserTest
    {
        [SetUp]
        public void SetUp()
        {
            dp = new DateParser(2010);
            dt = new DateTime(2010, 5, 8);
        }

        private DateParser dp;
        private DateTime dt;

        private void AssertThrows(params string[] values)
        {
            foreach (var value in values)
                Assert.Throws<FormatException>(() => dp.ParseDayMonth(value));
        }

        [Test]
        public void Test_FromDayOfYear()
        {
            Assert.AreEqual(dt, dp.FromDayOfYear(dt.DayOfYear));
        }

        [Test]
        public void Test_ToDayDotMonth()
        {
            var dayDotMonth = dp.ToDayMonth(dt);

            Assert.AreEqual("08.05", dayDotMonth);
            Assert.AreEqual(dt, dp.ParseDayMonth(dayDotMonth));
            Assert.AreEqual(dayDotMonth, dp.ToDayMonth(dp.ParseDayMonth(dayDotMonth)));
        }

        [Test]
        public void TestDateParser()
        {
            Assert.AreEqual(dt, dp.ParseDayMonth("8.5"));
            Assert.AreEqual(dt, dp.ParseDayMonth("8.05"));
            Assert.AreEqual(dt, dp.ParseDayMonth("08.5"));
            Assert.AreEqual(dt, dp.ParseDayMonth("08.05"));

            Assert.AreEqual(dt, dp.ParseDayMonth("08.05.2045"));
            Assert.AreEqual(dt, dp.ParseDayMonth("08.05.2000"));

            AssertThrows("11", "11.", ".11",
                "0.0", "00", "0", "-11.-11",
                "..", ".", "...", "25.25");
        }
    }
}