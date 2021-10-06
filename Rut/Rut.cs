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
        public string WithDots { get => Formatter.FormatWithDots(number, dv); }
        public string WithDotsNoDv { get => Formatter.FormatWithDotsNoDv(number); }
        public string CleanRut { get => Formatter.FormatClean(number, dv); }
        public bool Valid { get => Validator.IsValid(number, dv); }

        /// <summary>
        /// Creates a rut object from a rut number and parse
        /// </summary>
        /// <param name="rut"></param>
        public Rut(int rut)
        {
            if (!Validator.IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.number = rut;
            this.dv = Calculator.CalculateDV(rut);
        }

        /// <summary>
        /// Creates a rut object from the rut number and dv
        /// received, even if they are not valid.
        /// </summary>
        /// <param name="rut">Rut number</param>
        /// <param name="dv">Rut Dv</param>
        public Rut(int rut, char dv)
        {
            this.number = rut;
            this.dv = dv;
        }

        /// <summary>
        /// Parses rut from a string in a variety of formats.
        /// 
        /// Supported formats: 
        /// 1. 11.111.111-1
        /// 2. 11111111-1
        /// 3. 11111111
        /// 
        /// </summary>
        /// <param name="rut">Valid rut string</param>
        public Rut(string rut)
        {
            if (!Validator.IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.number = int.Parse(rut);
            this.dv = Calculator.CalculateDV(rut);
        }
    }
}
