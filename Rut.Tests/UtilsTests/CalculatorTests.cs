using System.Collections.Generic;
using System.Linq;
using Rut.Utils;
using Xunit;

namespace Rut.Tests.UtilsTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(new[] {5, 9, 6, 4, 6, 4, 8, 1}, 164)]
        [InlineData(new[] {8, 3, 8, 5, 3, 8, 8, 1}, 175)]
        [InlineData(new[] {1}, 2)]
        public void InversedRutDigitsShouldSumCorrectly(IEnumerable<int> digits, int sum)
        {
            Rut instance = new Rut(1);
            Assert.Equal(sum, Calculator.SumInversedRutDigits(digits));
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 2, 4)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 5)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 3, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 1, 9)]
        [InlineData(new[] {1}, 5, 1)]
        [InlineData(new int[] { }, 2, 0)]
        public void ListOfNumbersShouldBeSplitInTheCorrectNumberOfChunks(int[] numbers, int size, int chunks)
        {
            var chunkedNumbers = Calculator.Chunk(numbers.ToList(), size);
            Assert.Equal(chunks, chunkedNumbers.Count);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3, 2)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 5, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 4, 1)]
        public void LastChunkOfUnevenSplitListShouldHaveCorrectLength(int[] numbers, int size, int lastChunkLength)
        {
            var chunkedNumbers = Calculator.Chunk(numbers, size);
            Assert.Equal(lastChunkLength, chunkedNumbers.Last().Count);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3, 2)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 5, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 4, 1)]
        public void FirstChunkOfInversedUnevenSplitListShouldHaveCorrectSize(int[] numbers, int size, int lastChunkSize)
        {
            var chunkedNumbers = Calculator.ChunkInversed(numbers, size);
            Assert.Equal(lastChunkSize, chunkedNumbers.First().Count);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 2, 4)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 5)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 3, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 1, 9)]
        [InlineData(new[] {1}, 5, 1)]
        [InlineData(new int[] { }, 2, 0)]
        public void ListOfNumbersShouldBeSplitInTheCorrectNumberOfChunksOnInverseOrder(int[] numbers, int size,
            int chunks)
        {
            var chunkedNumbers = Calculator.ChunkInversed(numbers.ToList(), size);
            Assert.Equal(chunks, chunkedNumbers.Count);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 2)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, 2)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, 3)]
        [InlineData(new[] {1}, 1)]
        [InlineData(new[] {1}, 2)]
        [InlineData(new[] {1}, 3)]
        [InlineData(new int[] { }, 1)]
        [InlineData(new int[] { }, 2)]
        [InlineData(new int[] { }, 3)]
        public void ElementsOfChunkedListShouldBeInTheirOriginalOrder(int[] numbers, int chunkSize)
        {
            var chunks = Calculator.Chunk(numbers, chunkSize);
            var joinedChunks = Calculator.Flatten(chunks);
            var equal = Calculator.CompareList(numbers.ToList(), joinedChunks);
            Assert.True(equal);
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 2)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 3)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, 2)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, 3)]
        [InlineData(new[] {1}, 1)]
        [InlineData(new[] {1}, 2)]
        [InlineData(new[] {1}, 3)]
        [InlineData(new int[] { }, 1)]
        [InlineData(new int[] { }, 2)]
        [InlineData(new int[] { }, 3)]
        public void ElementsOfInversedChunkedListShouldBeInTheirOriginalOrder(int[] numbers, int chunkSize)
        {   
            var chunks = Calculator.ChunkInversed(numbers, chunkSize);
            var joinedChunks = Calculator.Flatten(chunks);
            var equal = Calculator.CompareList(numbers.ToList(), joinedChunks);
            Assert.True(equal);
        }

        [Fact]
        public void ChunkedIntegerListShouldFlattenCorrectly()
        {
            var original = new List<List<int>>
            {
                new List<int> {1, 2, 3},
                new List<int> {4, 5, 6},
                new List<int> {7, 8, 9}
            };
            var flattened = Calculator.Flatten(original);
            var expected = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var equal = Calculator.CompareList(flattened, expected);

            Assert.True(equal);
        }

        [Fact]
        public void TwoIntegerListsWithTheSameElementsShouldBeEqual()
        {
            var list1 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var list2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var equal = Calculator.CompareList(list1, list2);
            Assert.True(equal);
        }

        [Fact]
        public void TwoIntegerListsWithDifferentElementsShouldNotBeEqual()
        {
            var list1 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var list2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
            var equal = Calculator.CompareList(list1, list2);
            Assert.False(equal);
        }
    }
}