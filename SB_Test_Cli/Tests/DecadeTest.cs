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
    public class DecadeTest
    {
        [Test]
        public void TestTable()
        {
            var dt = new DateTime(2010, 1, 1);
            Console.WriteLine($"{"<Date>", -10} {"<Decade>", -10} {"<Decade+1>",-10}");

            for (int i = 0; i < 365; i++)
            {
                var dateTxt = dt.ToString("dd.MM", CultureInfo.InvariantCulture);
                var decade = Decade.From(dt);
                var nextDecade = decade.Next();

                Console.WriteLine($"{dateTxt,-10} {decade,-10} {nextDecade,-10}");

                dt = dt.AddDays(1);
            }

            Assert.Fail();
        }
    }
}
