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
            Assert.Equal("", Converter.GetWord(0));
            Assert.Equal("one", Converter.GetWord(1));
            Assert.Equal("nine", Converter.GetWord(9));
        }

        [Fact]
        public void SecondDozenTest()
        {
            Assert.Equal("ten", Converter.GetWord(10));
            Assert.Equal("nineteen", Converter.GetWord(19));
            Assert.Equal("twenty", Converter.GetWord(20));
        }

        [Fact]
        public void UpToHundredTest()
        {
            Assert.Equal("twenty one", Converter.GetWord(21));
            Assert.Equal("ninety nine", Converter.GetWord(99));
            Assert.Equal("one hundred", Converter.GetWord(100));
        }

        [Fact]
        public void UpToThousandTest()
        {
            Assert.Equal("one hundred one", Converter.GetWord(101));
            Assert.Equal("two hundred fourty five", Converter.GetWord(245));
            Assert.Equal("nine hundred ninety nine", Converter.GetWord(999));
        }

        [Fact]
        public void UpToMillionTest()
        {
            Assert.Equal("one thousand one", Converter.GetWord(1001));
            Assert.Equal("five thousand two hundred fourty five", Converter.GetWord(5245));
            Assert.Equal("nine thousand nine hundred ninety nine", Converter.GetWord(9999));
        }
    }
}
