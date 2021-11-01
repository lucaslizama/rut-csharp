using System;
using System.Collections.Generic;
using System.Linq;

namespace Rut.Utils
{
    public static class Generator
    {
        public static Rut GenerateRandomRut()
        {
            var randomRut = GetNumberGenerator()
                .Select(number => new Rut(number))
                .First();
            return randomRut;
        }

        public static Rut GenerateRandomRut(char dv)
        {
            var randomRut = GetNumberGenerator()
                .Select(number => new Rut(number))
                .Where(rut => rut.Dv == dv)
                .First();
            return randomRut;
        }

        public static List<Rut> GenerateRandomRuts(int ammount, bool noRepeat = false)
        {
            Rut[] ruts = new Rut[ammount];

            for (int i = 0; i < ammount; i++)
            {
                Rut newRut = GenerateRandomRut();
                if (ruts.Any(rut => rut.Number == newRut.Number) && noRepeat)
                {
                    --i;
                    continue;
                }
                ruts[i] = newRut;
            }

            return ruts.ToList();
        }

        public static List<Rut> GenerateRandomRuts(int ammount, char dv, bool noRepeat = true)
        {
            Rut[] ruts = new Rut[ammount];

            for (int i = 0; i < ammount; i++)
            {
                Rut newRut = GenerateRandomRut(dv);
                if (ruts.Any(rut => rut.Number == newRut.Number) && noRepeat)
                {
                    --i;
                    continue;
                }
                ruts[i] = newRut;
            }

            return ruts.ToList();
        }

        private static IEnumerable<int> GetNumberGenerator()
        {
            while (true)
            {
                Random rand = new Random();
                yield return rand.Next(1, 100000000);
            }
        }
    }
}