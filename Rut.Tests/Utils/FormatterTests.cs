using Rut.Utils;
using Xunit;

namespace Rut.Tests.Utils
{
    public class FormatterTests
    {
        [Theory]
        [InlineData(3, '5', "3-5")]
        [InlineData(18116416, '6', "18.116.416-6")]
        [InlineData(18835838, '1', "18.835.838-1")]
        [InlineData(18464695, '1', "18.464.695-1")]
        [InlineData(123, '6', "123-6")]
        [InlineData(1234, '3', "1.234-3")]
        [InlineData(1234567890, '3', "1.234-3")]
        public void FormatterShouldAddDotsToRutNumberCorrectly(int number, char dv, string correctRut)
        {
            Assert.Equal(correctRut, Formatter.FormatWithDots(number, dv));
        }
    }
}