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
                ruts.Add(Generator.GenerateRandomRut());
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
                ruts.Add(Generator.GenerateRandomRut(dv));
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
            var ruts = Generator.GenerateRandomRuts(length);
            Assert.Equal(length, ruts.Count);
        }
    }
}