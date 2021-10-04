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
        public string RutWithDots { get => Formatter.FormatWithDots(number, dv); }
        public string RutWithDotsNoDv { get => Formatter.FormatWithDotsNoDv(number); }
        public bool Valid { get => Validator.IsValid(number, dv); }

        public Rut(int rut)
        {
            if (!Validator.IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.number = rut;
            this.dv = Calculator.CalculateDV(rut);
        }

        public Rut(int rut, char dv)
        {
            if (!Validator.IsValid(rut, dv)) throw new InvalidRutInputException("The rut is invalid!");
            this.number = rut;
            this.dv = dv;
        }

        public Rut(string rut)
        {
            if (!Validator.IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.number = int.Parse(rut);
            this.dv = Calculator.CalculateDV(rut);
        }

        public Rut(string rut, char dv)
        {
            if (!Validator.IsValid(rut, dv)) throw new InvalidRutInputException("The rut is invalid!");
            this.number = int.Parse(rut);
            this.dv = dv;
        }
    }
}
