using System.Collections.Generic;
using System.Linq;

namespace Rut.Utils
{
    public class Calculator
    {
        public static char CalculateDV(int rut)
        {
            int[] digits = InverseRutDigits(rut);
            int sum = SumInversedRutDigits(digits);
            int remainder = sum % 11;
            int dv = 11 - remainder;

            return dv == 11 ? '0' : dv == 10 ? 'K' : dv.ToString()[0];
        }

        public static char CalculateDV(string rut)
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

        public static List<List<T>> Chunk<T>(IEnumerable<T> numbers, int size)
        {
            if (numbers.Count() == 0) return new List<List<T>>();
            if (size > numbers.Count()) return new List<List<T>> { numbers.ToList() };

            List<T> numbersList = numbers.ToList();
            List<List<T>> chunks = new List<List<T>>();

            int numberCount = numbersList.Count;
            int chunksCount = CountChunks(numberCount, size);

            for (int i = 0; i < chunksCount; i++)
            {
                int index = i * size;
                int take = CalculateTake(numberCount, index, size);
                chunks.Add(numbersList.GetRange(index, take));
            }

            return chunks;
        }

        public static List<List<T>> ChunkLeft<T>(IEnumerable<T> numbers, int size)
        {
            if (numbers.Count() == 0) return new List<List<T>>();
            if (size > numbers.Count()) return new List<List<T>> { numbers.ToList() };

            List<T> numbersList = numbers.ToList();
            List<List<T>> chunks = new List<List<T>>();

            int numberCount = numbersList.Count;
            int chunksCount = CountChunks(numberCount, size);

            for (int i = chunksCount - 1; i >= 0; i--)
            {
                int index = i * size;
                int take = CalculateTake(numberCount, index, size);
                chunks.Add(numbersList.GetRange(index, take));
            }

            return chunks;
        }

        private static int CalculateTake(int numberCount, int index, int size)
        {
            int overflow = index + size;
            bool overflowed = overflow > numberCount;
            int rest = overflow - numberCount;
            int take = overflowed ? rest : size;
            return take;
        }

        private static int CountChunks(int totalElements, int chunkSize)
        {
            return totalElements % chunkSize == 0 ? totalElements / chunkSize : (totalElements / chunkSize) + 1;
        }
    }
}