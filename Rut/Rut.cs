using System;
using Rut.Exceptions;
using Rut.Utils;

namespace Rut
{
    public class Rut
    {
        public int Number { get; set; }
        public char Dv { get; set; }
        public string WithDots => Formatter.AddDots(Number, Dv);
        public string WithDotsNoDv => Formatter.AddDotsNoDv(Number);
        public string Clean => Formatter.Clean(Number, Dv);
        public string CleanNoDash => Formatter.CleanNoDash(Number, Dv);
        public bool IsValid => Validator.IsRutValid(Number, Dv);

        /// <summary>
        /// Creates a rut object from a rut number and 
        /// automatically calculates the DV.
        /// </summary>
        /// <param name="number"></param>
        public Rut(int number)
        {
            if (!Validator.IsRutValid(number)) throw new InvalidRutStringException("The rut is invalid!");
            AssignRutValues(number);
        }

        /// <summary>
        /// Creates a rut object from the rut number and dv
        /// received, even if they are not valid.
        /// </summary>
        /// <param name="number">Rut number</param>
        /// <param name="dv">Rut Dv</param>
        public Rut(int number, char dv) => AssignRutValues(number, dv);

        /// <summary>
        /// Parses rut from a string in a variety of formats into
        /// a Rut object.
        /// 
        /// Supported formats: 
        /// 1. 11.111.111-1
        /// 2. 11111111-1
        /// 3. 11111111
        /// 4. 000011.111.111-1
        /// 5. 000011111111-1
        /// 6. 000011111111
        /// 
        /// </summary>
        /// <param name="rut">Valid rut string</param>
        public Rut(string rut)
        {
            var cleanRut = Cleaner.CleanRutString(rut);
            var invalid = !Validator.IsRutValid(cleanRut);
            if (invalid) throw new InvalidRutStringException("The rut is invalid!");
            AssignRutValues(Parser.ParseCleanRutString(cleanRut));
        }

        private void AssignRutValues(int number, char dv)
        {
            Number = number;
            Dv = dv;
        }

#if NET47_OR_GREATER
        private void AssignRutValues((int number, char dv) rut)
        {
            var (number, dv) = rut;
            AssignRutValues(number, dv);
        }
#else
        private void AssignRutValues(Tuple<int, char> rut)
        {
            var number = rut.Item1; var dv = rut.Item2;
            AssignRutValues(number, dv);
        }
#endif

        private void AssignRutValues(int number) => AssignRutValues(number, Calculator.CalculateDv(number));

        public override string ToString() => $"Status: {(IsValid ? "Valid" : "Invalid")}\nRut:{WithDots}";

        public override bool Equals(object other) => other != null && ((other as Rut).Number == Number && (other as Rut).Dv == Dv);

        public override int GetHashCode() => Number ^ Dv;
    }
}
