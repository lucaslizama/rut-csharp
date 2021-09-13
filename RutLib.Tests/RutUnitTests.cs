using System.Collections.Generic;
using Xunit;

namespace RutLib.Tests
{
    public class RutUnitTests
    {
        [Theory]
        [InlineData(18464695)]
        [InlineData(18835838)]
        [InlineData(1)]
        public void InputRutNumberShouldBeValid(int rut)
        {
            Rut instance = new Rut(rut);
            Assert.True(instance.Valid);
        }

        [Theory]
        [InlineData("18464695")]
        [InlineData("18835838")]
        [InlineData("1")]
        public void InputRutStringShouldBeValid(string rut)
        {
            Rut instance = new Rut(rut);
            Assert.True(instance.Valid);
        }

        [Theory]
        [InlineData(18464695, '1')]
        [InlineData(18835838, '1')]
        [InlineData(1, '9')]
        public void ValidIntRutShouldProduceValidDv(int rut, char dv)
        {
            Rut instance = new Rut(rut);
            Assert.Equal(dv, instance.DV);
        }

        [Theory]
        [InlineData(new int[] { 5, 9, 6, 4, 6, 4, 8, 1 }, 164)] // 18464695
        [InlineData(new int[] { 8, 3, 8, 5, 3, 8, 8, 1 }, 175)] // 18835838
        [InlineData(new int[] { 1 }, 2)]
        public void InversedRutDigitsShouldSumCorrectly(IEnumerable<int> digits, int sum)
        {
            Rut instance = new Rut(1);
            Assert.Equal(sum, instance.SumInversedRutDigits(digits));
        }
    }
}