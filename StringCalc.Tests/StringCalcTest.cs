using NUnit.Framework;
using Interviews.StringCalculator;
using System;
using System.Linq;

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

        [TestCase(0, "0")]
        [TestCase(3, "3")]
        public void ShouldReturnSingleNumber(int expected, string given)
        {
            var observed = _stringCalc.add(given);
            Assert.AreEqual(expected, observed);
        }

        [TestCase(4, "1,3")]
        [TestCase(15, "0,15")]
        public void ShouldAddTwoNumbers(int expected, string given) {
            var observed = _stringCalc.add(given);
            Assert.AreEqual(expected, observed);
        }

        [Test]
        public void ShouldAddNNumbers() {
            Random random = new Random();

            var expected = random.Next(3, 10);

            var given = (new int[expected-1])
                .Aggregate("1", (acc, _) => acc + ",1");

            var observed = _stringCalc.add(given);
            Assert.AreEqual(expected, observed);
        }

        [TestCase(4, "1\n3")]
        [TestCase(9, "1\n3,5")]
        public void ShouldAllowNewlineDelimeter(int expected, string given)
        {
            var observed = _stringCalc.add(given);
            Assert.AreEqual(expected, observed);
        }

        [TestCase(4, "//;\n1;3")]
        [TestCase(4, "//|\n1|3")]
        public void ShouldSupportArbitraryDelimeters(int expected, string given)
        {
            var observed = _stringCalc.add(given);
            Assert.AreEqual(expected, observed);
        }

        [TestCase("1;3")]
        [TestCase("1|3")]
        public void ShouldNotSupportAllDelimetersWhenNotSpecified(string given)
        {
            Assert.Throws<FormatException>(() => _stringCalc.add(given));
        }

        [TestCase("-1")]
        [TestCase("1,-3")]
        public void shouldThrowWhenGivenNegativeNumbers(string given)
        {
            Assert.Throws<ArgumentException>(() => _stringCalc.add(given));
        }
    }
}