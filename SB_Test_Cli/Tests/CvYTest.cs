using NUnit.Framework;
using SouthernBug.App.Calculation.Converter;

namespace SB_Test_Cli.Tests
{
    [TestFixture]
    public class CvYTest
    {
        private void TestConverter(string name, double value)
        {
            TestConvertToName(value, name);
            TestConvertToValue(name, value);
        }


        private void TestConvertToName(double value, string name)
        {
            Assert.AreEqual(name, CvYColumnConverter.NameFromValue(value), "value({0}) -> name({1})", value, name);
        }

        private void TestConvertToValue(string name, double value)
        {
            Assert.AreEqual(value, CvYColumnConverter.ValueFromName(name), "name({0}) -> value({1})", name, value);
        }

        [Test]
        public void Main()
        {
            TestConverter("CvY_0.1", 0.1);

            TestConvertToName(0.0, "CvY_0.1");
            TestConvertToName(-5, "CvY_0.1");

            TestConvertToName(2, "CvY_2.0");
            TestConvertToName(5, "CvY_2.0");

            TestConverter("CvY_0.11", 0.11);

            TestConverter("CvY_0.9", 0.9);

            TestConverter("CvY_1.0", 1);
            TestConverter("CvY_2.0", 2);
        }
    }
}