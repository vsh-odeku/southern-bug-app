using NUnit.Framework;
using SouthernBug.App.Model;

namespace SB_Test_Cli.Tests
{
    [TestFixture]
    public class DateAverageTest
    {
        [SetUp]
        public void SetUp()
        {
            dateAverage = new DateAverage(new DateParser(2010));
        }

        private DateAverage dateAverage;

        [Test]
        public void Main()
        {
            Assert.AreEqual("", dateAverage.CalcFor());
            Assert.AreEqual("11.05", dateAverage.CalcFor("11.05"));

            Assert.AreEqual("11.05", dateAverage.CalcFor("10.05", "12.05"));
            Assert.AreEqual("13.05", dateAverage.CalcFor("10.05", "16.05"));

            Assert.AreEqual("10.05", dateAverage.CalcFor("09.05", "10.05", "11.05"));

            Assert.AreEqual("31.01", dateAverage.CalcFor("01.01", "01.02", "01.03"));

            Assert.AreEqual("15.01", dateAverage.CalcFor("10.01", "", "20.01"));
        }
    }
}