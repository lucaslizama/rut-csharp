using System;
using System.Collections.Generic;
using System.Linq;

namespace Rut.Utils
{
    public static class Generator
    {
        public static Rut RandomRut()
        {
            var randomRut = GetNumberGenerator()
                .Select(number => new Rut(number))
                .First();
            return randomRut;
        }

        public static Rut RandomRut(char dv)
        {
            var randomRut = GetNumberGenerator()
                .Select(number => new Rut(number))
                .Where(rut => rut.Dv == dv)
                .First();
            return randomRut;
        }

        public static List<Rut> RandomRuts(int ammount, bool noRepeat = false)
        {
            var generator = GetRutGenerator();
            return (
                noRepeat ?
                generator.Distinct().Take(ammount) :
                generator.Take(ammount)
            ).ToList();
        }

        public static List<Rut> RandomRuts(int ammount, char dv, bool noRepeat = false)
        {
            var generator = GetRutGenerator();
            return (
                noRepeat ?
                generator.Distinct().Where(rut => rut.Dv == dv).Take(ammount) :
                generator.Where(rut => rut.Dv == dv).Take(ammount)
            ).ToList();
        }

        public static List<Rut> RutRange(int start, int end)
        {
            return GetNumericRange(start, end).Select(number => new Rut(number)).ToList();
        }

        public static List<int> GetNumericRange(int start, int end)
        {
            if (start == 0 || end == 0) throw new Exception("Rut number cannot be '0'");
            if (start < 0 || end < 0) throw new Exception("Rut number cannot be negative");
            if (start > 99_999_999 || end > 99_999_999) throw new Exception("Rut cannot be grater than 99.999.999");
#if NET47_OR_GREATER
            if (start > end) (start, end) = (end, start);
#else
            if (start > end) InvertNumbers(ref start, ref end);
#endif
            List<int> numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }
            return numbers;
        }

        public static void InvertNumbers(ref int number1, ref int number2)
        {
            number1 = number2 + number1;
            number2 = number1 - number2;
            number1 = number1 - number2;
        }

        private static IEnumerable<int> GetNumberGenerator()
        {
            while (true)
            {
                Random rand = new Random();
                yield return rand.Next(1, 100000000);
            }
        }

        private static IEnumerable<Rut> GetRutGenerator()
        {
            while (true)
            {
                yield return RandomRut();
            }
        }
    }
}