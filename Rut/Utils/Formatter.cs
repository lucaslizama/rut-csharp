using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Rut.Utils
{
    public class Formatter
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
            List<char> digits = number.ToString().ToCharArray().ToList();
            int steps = 0, iterations = 1;
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (steps == 3)
                {
                    digits.Insert(i + iterations, '.');
                    iterations++;
                    steps = 0;
                    i++;
                    continue;
                }
                steps++;
            }
            return string.Concat(digits.ToArray(), '-');
        }
    }
}