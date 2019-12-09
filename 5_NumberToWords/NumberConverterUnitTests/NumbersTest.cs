using Xunit;
using _5_NumberToWords.Numbers;

namespace NumberConverterUnitTests
{
    public class NumbersTest
    {
        NumberConverter Converter = new NumberConverter();

        [Fact]
        public void FirstDozenTest()
        {
            Assert.Equal("", Converter.GetStringRepresentation(0));
            Assert.Equal("one", Converter.GetStringRepresentation(1));
            Assert.Equal("nine", Converter.GetStringRepresentation(9));
        }

        [Fact]
        public void SecondDozenTest()
        {
            Assert.Equal("ten", Converter.GetStringRepresentation(10));
            Assert.Equal("nineteen", Converter.GetStringRepresentation(19));
            Assert.Equal("twenty", Converter.GetStringRepresentation(20));
        }

        [Fact]
        public void UpToHundredTest()
        {
            Assert.Equal("twenty one", Converter.GetStringRepresentation(21));
            Assert.Equal("ninety nine", Converter.GetStringRepresentation(99));
            Assert.Equal("one hundred", Converter.GetStringRepresentation(100));
        }

        [Fact]
        public void UpToThousandTest()
        {
            Assert.Equal("one hundred one", Converter.GetStringRepresentation(101));
            Assert.Equal("two hundred fourty five", Converter.GetStringRepresentation(245));
            Assert.Equal("nine hundred ninety nine", Converter.GetStringRepresentation(999));
        }

        [Fact]
        public void UpToMillionTest()
        {
            Assert.Equal("one thousand one", Converter.GetStringRepresentation(1001));
            Assert.Equal("five thousand two hundred fourty five", Converter.GetStringRepresentation(5245));
            Assert.Equal("nine thousand nine hundred ninety nine", Converter.GetStringRepresentation(9999));
        }

        [Fact]
        public void UpToBillionTest()
        {
            Assert.Equal("one million", Converter.GetStringRepresentation(1000000));
            Assert.Equal("one million six hundred fifty four thousand three hundred twenty one",
                Converter.GetStringRepresentation(1654321));
            Assert.Equal("nine million nine hundred ninety nine thousand nine hundred ninety nine", Converter.GetStringRepresentation(9999999));
        }
    }
}
