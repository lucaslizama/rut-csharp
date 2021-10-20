using System.Collections.Generic;
using System.Linq;
using Rut.Utils;
using Xunit;

namespace Rut.Tests.UtilsTests
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

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2, 4)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 3, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 5)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1, 9)]
        [InlineData(new int[] { 1 }, 5, 1)]
        [InlineData(new int[] { }, 2, 0)]
        public void ListOfNumbersShouldBeSplitInTheCorrectNumberOfChunks(int[] numbers, int size, int chunks)
        {
            var chunkedNumbers = Calculator.Chunk(numbers.ToList(), size);
            Assert.Equal(chunks, chunkedNumbers.Count);
        }

        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2, 4)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 3, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 5)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1, 9)]
        [InlineData(new int[] { 1 }, 5, 1)]
        [InlineData(new int[] { }, 2, 0)]
        public void ListOfNumbersShouldBeSplitInTheCorrectNumberOfChunksOnInverseOrder(int[] numbers, int size, int chunks)
        {
            var chunkedNumbers = Calculator.ChunkLeft(numbers.ToList(), size);
            Assert.Equal(chunks, chunkedNumbers.Count);
        }
    }
}