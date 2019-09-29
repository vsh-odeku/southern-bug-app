using NUnit.Framework;

namespace SB_Test_Cli.Tests
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void BadTest()
        {
            //Assert.IsTrue(false);
        }

        [Test]
        public void GoodTest()
        {
            Assert.IsTrue(true);
        }
    }
}