using System;
using Rut.Exceptions;
using Rut.Utils;

namespace Rut
{
    public class Rut
    {
        private int number;
        private char dv;

        public int Number { get => number; set => number = value; }
        public char Dv { get => dv; set => dv = value; }
        public string WithDots { get => Formatter.AddDots(number, dv); }
        public string WithDotsNoDv { get => Formatter.AddDotsNoDv(number); }
        public string CleanRut { get => Formatter.Clean(number, dv); }
        public bool Valid { get => Validator.IsRutValid(number, dv); }

        /// <summary>
        /// Creates a rut object from a rut number and parse
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
        /// <param name="rut">Rut number</param>
        /// <param name="dv">Rut Dv</param>
        public Rut(int number, char dv)
        {
            AssignRutValues(number, dv);
        }

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
            string cleanRut = Cleaner.CleanRutString(rut);
            bool invalid = !Validator.IsRutValid(cleanRut);
            if (invalid) throw new InvalidRutStringException("The rut is invalid!");
            AssignRutValues(Parser.ParseCleanRutString(cleanRut));
        }

        private void AssignRutValues(int number, char dv)
        {
            this.number = number;
            this.dv = dv;
        }

        private void AssignRutValues(Tuple<int, char> rut)
        {
            AssignRutValues(rut.Item1, rut.Item2);
        }

        private void AssignRutValues(int number)
        {
            AssignRutValues(number, Calculator.CalculateDV(number));
        }

        public override string ToString()
        {
            return $"Status: {(Valid ? "Valid" : "Invalid")}\nRut:{WithDots}";
        }
    }
}
