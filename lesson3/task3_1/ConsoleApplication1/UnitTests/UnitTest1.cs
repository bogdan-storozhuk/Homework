using System;
using ConsoleApplication1;
using NUnit.Framework;
namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
       
        [Test]
        public void TestGetZodiacSign()
        {
            var sign = Program.GetZodiacSign(13, Month.September);
            Assert.AreEqual(ZodiacSign.Virgo, sign);

        }

        [Test]
        public void Test()
        {
           int days = Program.GetDaysOfMonth(Month.July);
            Assert.AreEqual(31, days);
        }

        [Test]
        public void TestValidate()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Program.DateValidation(new string[] { "32", "07", "2010" }));
        }

        [Test]
        public void TestValidateSuccess()
        {
            Program.DateValidation(new string[] {"31", "07", "2010"});
        }

    }
}
