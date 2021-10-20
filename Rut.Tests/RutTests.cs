using Xunit;
using Rut.Exceptions;

namespace Rut.Tests
{
    public class RutTests
    {
        [Theory]
        [InlineData(18464695, '1')]
        [InlineData(18835838, '1')]
        [InlineData(1, '9')]
        [InlineData(2, '7')]
        public void ValidIntRutShouldProduceValidDv(int rut, char dv)
        {
            var instance = new Rut(rut);
            Assert.Equal(dv, instance.Dv);
        }

        [Theory]
        [InlineData("18464695-1", '1')]
        [InlineData("18835838-1", '1')]
        [InlineData("18.464.695-1", '1')]
        [InlineData("18.835.838-1", '1')]
        [InlineData("000018464695-1", '1')]
        [InlineData("000018835838-1", '1')]
        [InlineData("000018.464.695-1", '1')]
        [InlineData("000018.835.838-1", '1')]
        [InlineData("    000018.464.695-1    ", '1')]
        [InlineData("    000018.835.838-1    ", '1')]
        [InlineData("18464695", '1')]
        [InlineData("18835838", '1')]
        [InlineData("1", '9')]
        [InlineData("2", '7')]
        public void ValidStringRutShouldProduceValidDv(string rut, char dv)
        {
            var instance = new Rut(rut);
            Assert.Equal(dv, instance.Dv);
        }

        [Theory]
        [InlineData("18464695")]
        [InlineData("18464695-1")]
        [InlineData("18.464.695-1")]
        [InlineData("1-9")]
        [InlineData("1.234-3")]
        public void ValidStringRutWithDashAndDvShouldInitializeCorrectly(string rut)
        {
            var instance = new Rut(rut);

        }

        [Theory]
        [InlineData("asioduhfasidfjdsñaio")]
        [InlineData("-18.464.695-1")]
        [InlineData("")]
        public void InvalidStringRutShouldThrowExceptionOnInitialize(string rut)
        {
            Assert.ThrowsAny<InvalidRutStringException>(() => new Rut(rut));
        }
    }
}