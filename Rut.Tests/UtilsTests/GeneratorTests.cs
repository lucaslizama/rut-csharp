using Xunit;
using Rut.Utils;

namespace Rut.Tests.UtilsTests
{
    public class GeneratorTests
    {
        [Fact]
        public void ShouldGenerateValidRandomRut()
        {
            Rut rut = Generator.GenerateRandomRut();
            Assert.True(rut.Valid);
        }
    }
}