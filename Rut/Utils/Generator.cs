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
            var generator = GetRutGenerator();
            return (
                noRepeat ?
                generator.Take(ammount).Distinct() :
                generator.Take(ammount)
            ).ToList();
        }

        public static List<Rut> GenerateRandomRuts(int ammount, char dv, bool noRepeat = false)
        {
            var generator = GetRutGenerator();
            return (
                noRepeat ?
                generator.Take(ammount).Where(rut => rut.Dv == dv).Distinct() :
                generator.Take(ammount).Where(rut => rut.Dv == dv)
            ).ToList();
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
                yield return GenerateRandomRut();
            }
        }
    }
}