using System;
using System.Collections.Generic;
using System.Linq;

namespace Rut.Utils
{
    public static class Calculator
    {
        public static char CalculateDv(int rut)
        {
            int[] digits = InverseRutDigits(rut);
            int sum = SumInversedRutDigits(digits);
            int remainder = sum % 11;
            int dv = 11 - remainder;

            return dv == 11 ? '0' : dv == 10 ? 'K' : dv.ToString()[0];
        }

        public static char CalculateDv(string rut)
        {
            int[] digits = InverseRutDigits(rut);
            int sum = SumInversedRutDigits(digits);
            int remainder = sum % 11;
            int dv = 11 - remainder;

            return dv == 11 ? '0' : dv == 10 ? 'K' : dv.ToString()[0];
        }

        public static int[] InverseRutDigits(int rut)
        {
            return rut.ToString().ToCharArray()
                .Select(digit => int.Parse(digit.ToString()))
                .Reverse()
                .ToArray();
        }

        public static int[] InverseRutDigits(string rut)
        {
            return rut.ToCharArray()
                .Select(digit => int.Parse(digit.ToString()))
                .Reverse()
                .ToArray();
        }

        public static int SumInversedRutDigits(IEnumerable<int> digits)
        {
            int factor = 2;

            return digits.Aggregate(0, (acc, curr) =>
            {
                int result = acc + curr * factor;
                factor = factor == 7 ? 2 : factor + 1;
                return result;
            });
        }

        public static List<List<T>> Chunk<T>(IEnumerable<T> elements, int size)
        {
            var elementsList = elements.ToList();

            if (!elementsList.Any() || size <= 0) return new List<List<T>>();
            if (size > elementsList.Count()) return new List<List<T>> {elementsList};
            if (size == 1) return SplitIntoChunksOfOne(elementsList);

            return SplitIntoChunks(elementsList, size);
        }

        public static List<List<T>> ChunkInversed<T>(IEnumerable<T> elements, int size)
        {
            var elementsList = elements.ToList();

            if (!elementsList.Any() || size <= 0) return new List<List<T>>();
            if (size > elementsList.Count()) return new List<List<T>> {elementsList};
            if (size == 1) return SplitIntoChunksOfOneInversed(elementsList);

            return SplitIntoChunksInversed(elementsList, size).ToList();
        }

        private static List<List<T>> SplitIntoChunks<T>(List<T> list, int size)
        {
            var numberOfElements = list.Count;
            var numberOfChunks = CountChunks(numberOfElements, size);
            var chunks = new List<List<T>>();

            for (var i = 0; i < numberOfChunks; i++)
            {
                var index = i * size;
                var take = CalculateTake(numberOfElements, index, size);
                chunks.Add(list.GetRange(index, take));
            }

            return chunks;
        }

        private static List<List<T>> SplitIntoChunksInversed<T>(List<T> list, int size)
        {
            var iterations = 0;
            var chunks = new Stack<List<T>>();
            var chunk = new Stack<T>();
            
            for (var i = list.Count - 1; i >= 0 ; --i)
            {
                chunk.Push(list[i]);
                iterations++;

                if (iterations != size && i > 0) continue;
                
                chunks.Push(chunk.ToList());
                iterations = 0;
                chunk = new Stack<T>();
            }
            
            return chunks.ToList();
        }

        private static List<List<T>> SplitIntoChunksOfOne<T>(IEnumerable<T> list)
        {
            return list.Aggregate(new List<List<T>>(), (prev, curr) =>
            {
                prev.Add(new List<T>() {curr});
                return prev;
            });
        }
        
        private static List<List<T>> SplitIntoChunksOfOneInversed<T>(IEnumerable<T> list)
        {
            var chunks = list.Aggregate(new List<List<T>>(), (prev, curr) =>
            {
                prev.Add(new List<T>() {curr});
                return prev;
            });
            return chunks;
        }

        private static int CalculateTake(int numberOfElements, int startIndex, int chunkSize)
        {
            var finalIndex = numberOfElements - 1;
            var nextIndex = startIndex + chunkSize;
            var rest = numberOfElements % chunkSize;
            var take = nextIndex > finalIndex && rest > 0 ? rest : chunkSize;
            return take;
        }

        private static int CountChunks(int totalElements, int chunkSize)
        {
            return totalElements % chunkSize == 0 ? totalElements / chunkSize : (totalElements / chunkSize) + 1;
        }

        public static List<T> Flatten<T>(IEnumerable<IEnumerable<T>> chunks)
        {
            return chunks.Aggregate(new List<T>(), (prev, curr) =>
            {
                prev.AddRange(curr);
                return prev;
            });
        }

        public static bool CompareList<T>(List<T> list1, List<T> list2)
        {
            if (list1 == null || list2 == null) throw new Exception("Error: null value received instead of list");
            if (list1.Count != list2.Count) return false;
            var equal = list1.Select((element, index) => element.Equals(list2[index])).All(result => result);
            return equal;
        }
    }
}