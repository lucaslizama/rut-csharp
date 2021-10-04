using System.Collections.Generic;
using Xunit;

namespace Rut.Tests
{
    public class RutTests
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
        [InlineData(2, '7')]
        public void IntRutShouldProduceValidDv(int rut, char dv)
        {
            Rut instance = new Rut(rut);
            Assert.Equal(dv, instance.Dv);
        }

        [Theory]
        [InlineData("18464695", '1')]
        [InlineData("18835838", '1')]
        [InlineData("1", '9')]
        [InlineData("2", '7')]
        public void StringRutShouldProduceValidDv(string rut, char dv)
        {
            Rut instance = new Rut(rut);
            Assert.Equal(dv, instance.Dv);
        }
    }
}