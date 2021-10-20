using Rut.Utils;
using Xunit;

namespace Rut.Tests.UtilsTests
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
        public void FormatterShouldAddDotsToRutNumber(int number, char dv, string correctRut)
        {
            Assert.Equal(correctRut, Formatter.AddDots(number, dv));
        }

        [Theory]
        [InlineData(3, "3-5")]
        [InlineData(18116416, "18.116.416")]
        [InlineData(18835838, "18.835.838")]
        [InlineData(18464695, "18.464.695")]
        [InlineData(123, "123")]
        [InlineData(1234, "1.234")]
        public void FormatterShouldAddDotsToRutNumberWithoutDvCorrectly(int number, string correctRut)
        {
            Assert.Equal(correctRut, Formatter.AddDotsNoDv(number));
        }
    }
}