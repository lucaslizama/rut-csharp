using System.Collections.Generic;
using System.Linq;

namespace RutLib.Utils
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
    }
}