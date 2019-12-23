using Xunit;
using _5_NumberToWords.Numbers;

namespace NumberConverterUnitTests
{
    public class NumbersTest
    {
        NumberConverter Converter = new NumberConverter();

        [Theory]
        [InlineData("negative one hundred", -100)]
        [InlineData("negative one", -1)]
        [InlineData("zero", 0)]
        [InlineData("one", 1)]
        [InlineData("nine", 9)]
        [InlineData("ten", 10)]
        [InlineData("nineteen", 19)]
        [InlineData("twenty", 20)]
        [InlineData("twenty one", 21)]
        [InlineData("ninety nine", 99)]
        [InlineData("one hundred", 100)]
        [InlineData("one hundred one", 101)]
        [InlineData("two hundred forty five", 245)]
        [InlineData("nine hundred ninety nine", 999)]
        [InlineData("one thousand one", 1001)]
        [InlineData("five thousand two hundred forty five", 5245)]
        [InlineData("nine thousand nine hundred ninety nine", 9999)]
        [InlineData("one million", 1000000)]
        [InlineData("one million six hundred fifty four thousand three hundred twenty one",
                1654321)]
        [InlineData("nine million nine hundred ninety nine thousand nine hundred ninety nine", 
                9999999)]
        [InlineData("two billion one hundred forty seven million four hundred eighty three thousand six hundred forty seven",
                int.MaxValue)] //2147483647
        public void NumberConverterTest(string expected, int number)
        {
            Assert.Equal(expected, NumberConverter.GetStringRepresentation(number));
        }
    }
}
