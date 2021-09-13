using System.Collections.Generic;
using System.Linq;
using System;
using RutLib.Exceptions;

namespace RutLib
{
    public class Rut
    {
        private int rut;
        private char dv;

        public int RUT { get => rut; set => rut = value; }
        public char DV { get => dv; set => dv = value; }
        public bool Valid { get => IsValid(rut, dv); }

        public Rut(int rut)
        {
            if (!IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = rut;
            this.dv = CalculateDV(rut);
        }

        public Rut(int rut, char dv)
        {
            if (!IsValid(rut, dv)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = rut;
            this.dv = dv;
        }

        public Rut(string rut)
        {
            if (!IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = int.Parse(rut);
            this.dv = CalculateDV(rut);
        }

        public Rut(string rut, char dv)
        {
            if (!IsValid(rut, dv)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = int.Parse(rut);
            this.dv = dv;
        }

        public bool IsValid(int rut)
        {
            string textRut = rut.ToString();

            if (textRut.Length > 8) return false;

            return true;
        }

        public bool IsValid(string rut)
        {
            if (rut == null) return false;
            if (rut.Length == 0 || rut.Length > 8) return false;
            if (!int.TryParse(rut, out int result)) return false;
            return true;
        }

        public bool IsValid(int rut, char dv)
        {
            if (!IsValid(rut)) return false;
            if (CalculateDV(rut) != dv) return false;

            return true;
        }

        public bool IsValid(string rut, char dv)
        {
            if (!IsValid(rut)) return false;
            if (CalculateDV(rut) != dv) return false;

            return true;
        }

        public char CalculateDV(int rut)
        {
            int[] digits = InverseRutDigits(rut);
            int sum = SumInversedRutDigits(digits);
            int remainder = sum % 11;
            int dv = 11 - remainder;

            return dv == 11 ? '0' : dv == 10 ? 'K' : dv.ToString()[0];
        }

        public char CalculateDV(string rut)
        {
            int[] digits = InverseRutDigits(rut);
            int sum = SumInversedRutDigits(digits);
            int remainder = sum % 11;
            int dv = 11 - remainder;

            return dv == 11 ? '0' : dv == 10 ? 'K' : dv.ToString()[0];
        }

        public int[] InverseRutDigits(int rut)
        {
            return rut.ToString().ToCharArray()
                .Select(digit => int.Parse(digit.ToString()))
                .Reverse()
                .ToArray();
        }

        public int[] InverseRutDigits(string rut)
        {
            return rut.ToCharArray()
                .Select(digit => int.Parse(digit.ToString()))
                .Reverse()
                .ToArray();
        }

        public int SumInversedRutDigits(IEnumerable<int> digits)
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
