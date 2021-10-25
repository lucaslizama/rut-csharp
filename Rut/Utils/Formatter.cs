using System.Linq;
using System.Collections.Generic;

namespace Rut.Utils
{
    public static class Formatter
    {
        public static string Clean(int number, char dv)
        {
            return string.Concat(number, "-", dv);
        }

        public static string AddDots(int number, char dv)
        {
            return $"{AddDotsNoDv(number)}-{dv}";
        }

        public static string AddDotsNoDv(int number)
        {
            var digits = number.ToString().ToCharArray();
            var chunks = Calculator.ChunkInversed(digits, 3);
            var chunksWithDots = chunks.Aggregate(new List<string>(), (prev, curr) =>
            {
                prev.Add(string.Concat(curr));
                return prev;
            });
            return string.Join(".", chunksWithDots);
        }
    }
}