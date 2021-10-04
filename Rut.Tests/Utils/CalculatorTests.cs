using System.Collections.Generic;
using Rut.Utils;
using Xunit;

namespace Rut.Tests.Utils
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(new int[] { 5, 9, 6, 4, 6, 4, 8, 1 }, 164)] // 18464695
        [InlineData(new int[] { 8, 3, 8, 5, 3, 8, 8, 1 }, 175)] // 18835838
        [InlineData(new int[] { 1 }, 2)]
        public void InversedRutDigitsShouldSumCorrectly(IEnumerable<int> digits, int sum)
        {
            Rut instance = new Rut(1);
            Assert.Equal(sum, Calculator.SumInversedRutDigits(digits));
        }
    }
}