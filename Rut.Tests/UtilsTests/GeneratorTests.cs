using System.Collections.Generic;
using System.Linq;
using Rut.Utils;
using Xunit;

namespace Rut.Tests.UtilsTests
{
    public class GeneratorTests
    {
        [Fact]
        public void ShouldGenerateValidRandomRut()
        {
            var ruts = new List<Rut>();
            for (int i = 0; i < 100; i++)
            {
                ruts.Add(Generator.RandomRut());
            }
            Assert.True(ruts.All(rut => rut.IsValid));
        }

        [Theory]
        [InlineData('0')]
        [InlineData('1')]
        [InlineData('2')]
        [InlineData('3')]
        [InlineData('4')]
        [InlineData('5')]
        [InlineData('6')]
        [InlineData('7')]
        [InlineData('8')]
        [InlineData('9')]
        [InlineData('K')]
        public void ShouldGenerateValidRandomRutWithSpecifiedDv(char dv)
        {
            var ruts = new List<Rut>();
            for (int i = 0; i < 100; i++)
            {
                ruts.Add(Generator.RandomRut(dv));
            }
            Assert.True(ruts.All(rut => rut.Dv == dv));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(1000)]
        public void ShouldGenerateAListOfRandomRutsOfACertainLength(int length)
        {
            var ruts = Generator.RandomRuts(length);
            Assert.Equal(length, ruts.Count);
        }

        [Fact]
        public void GeneratedRutsShouldNotRepeatIfSpecified()
        {
            var length = 100000;
            var ruts = Generator.RandomRuts(length, true).Distinct().ToList();
            Assert.Equal(ruts.Count, length);
        }

        [Theory]
        [InlineData(100, '0')]
        [InlineData(100, '1')]
        [InlineData(100, '2')]
        [InlineData(100, '3')]
        [InlineData(100, '4')]
        [InlineData(100, '5')]
        [InlineData(100, '6')]
        [InlineData(100, '7')]
        [InlineData(100, '8')]
        [InlineData(100, '9')]
        [InlineData(100, 'K')]
        public void ShouldGenerateAListOfRandomRutsWithSpecificDvOfACertainLength(int length, char dv)
        {
            var ruts = Generator.RandomRuts(length, dv);
            Assert.Equal(length, ruts.Count);
        }

        [Theory]
        [InlineData('0')]
        [InlineData('1')]
        [InlineData('2')]
        [InlineData('3')]
        [InlineData('4')]
        [InlineData('5')]
        [InlineData('6')]
        [InlineData('7')]
        [InlineData('8')]
        [InlineData('9')]
        [InlineData('K')]
        public void GeneratedRutsOfSpecificDvShouldNotRepeatIfSpecified(char dv)
        {
            var length = 100000;
            var ruts = Generator.RandomRuts(length, dv, true).Distinct().ToList();
            Assert.Equal(ruts.Count, length);
        }

        [Theory]
        [InlineData(1, 100, 100)]
        [InlineData(1000000, 2000000, 1000001)]
        [InlineData(120, 130, 11)]
        [InlineData(200, 200, 1)]
        public void RutRangeShouldGenerateCorrectly(int start, int end, int count)
        {
            var ruts = Generator.RutRange(start, end);
            Assert.Equal(count, ruts.Count);
        }

        [Theory]
        [InlineData(1, 100, 100)]
        [InlineData(1000000, 2000000, 1000001)]
        [InlineData(120, 130, 11)]
        [InlineData(200, 200, 1)]
        public void NumericRangeShouldGenerateCorrectly(int start, int end, int count)
        {
            var numbers = Generator.GetNumericRange(start, end);
            Assert.Equal(count, numbers.Count);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(51, -8)]
        [InlineData(5, 24)]
        [InlineData(18, 2)]
        [InlineData(11, 10)]
        [InlineData(420, 69)]
        public void NumbersShouldInvertCorrectly(int number1, int number2)
        {
            var (number3, number4) = Generator.InvertNumbers(number1, number2);
            Assert.Equal(number1, number4);
            Assert.Equal(number2, number3);
        }
    }
}