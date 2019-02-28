using NUnit.Framework;
using Interviews.StringCalculator;

namespace Interviews.UnitTests.StringCalculator
{
    public class Tests
    {
        private StringCalc _stringCalc;

        [SetUp]
        public void Setup()
        {
            _stringCalc = new StringCalc();
        }

        [Test]
        public void ShouldFail() {
            Assert.Fail();
        }
    }
}