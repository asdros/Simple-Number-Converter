using NUnit.Framework;
using SimpleNumberConverter;

namespace CoreTest
{
    [TestFixture]
    public class Tests
    {

        [TestCase(125,2,"1111101")]
        [TestCase(125, 8,"175")]
        [TestCase(125, 16,"7D")]
        [TestCase(125, 3,"11122")]
        [TestCase(125, 5,"1000")]
        public void ConversionOfNumbersFromDecimalBase(int valueToConvert, byte destinationBase, string expected)
        {
            var result = Core.ConvertTo(valueToConvert, destinationBase);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("1111101", 2, 125)]
        [TestCase("175", 8, 125)]
        [TestCase("7D", 16, 125)]
        [TestCase("11122", 3, 125)]
        [TestCase("1000", 5, 125)]
        public void ConversionOfNumbersToDecimalBase(string valueToConvert, byte sourceBase, int expected)
        {
            var result = Core.ConvertFrom(valueToConvert, sourceBase);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}