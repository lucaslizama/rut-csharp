using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Rut.Utils
{
    public class Formatter
    {
        public static string FormatClean(int number, char dv)
        {
            return string.Concat(number, "-", dv);
        }

        public static string FormatWithDots(int number, char dv)
        {
            List<char> numeros = number.ToString().ToCharArray().ToList();
            int steps = 0, iterations = 1;
            for (int i = numeros.Count - 1; i >= 0; i--)
            {
                if (steps == 3)
                {
                    numeros.Insert(i + iterations, '.');
                    iterations++;
                    steps = 0;
                    continue;
                }
                steps++;
            }
            return string.Concat(new String(numeros.ToArray()), "-", dv);
        }

        public static string FormatWithDotsNoDv(int number)
        {
            throw new NotImplementedException();
        }
    }
}