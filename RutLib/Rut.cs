using RutLib.Exceptions;
using RutLib.Utils;

namespace RutLib
{
    public class Rut
    {
        private int rut;
        private char dv;

        public int RUT { get => rut; set => rut = value; }
        public char DV { get => dv; set => dv = value; }
        public bool Valid { get => Validator.IsValid(rut, dv); }

        public Rut(int rut)
        {
            if (!Validator.IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = rut;
            this.dv = Calculator.CalculateDV(rut);
        }

        public Rut(int rut, char dv)
        {
            if (!Validator.IsValid(rut, dv)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = rut;
            this.dv = dv;
        }

        public Rut(string rut)
        {
            if (!Validator.IsValid(rut)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = int.Parse(rut);
            this.dv = Calculator.CalculateDV(rut);
        }

        public Rut(string rut, char dv)
        {
            if (!Validator.IsValid(rut, dv)) throw new InvalidRutInputException("The rut is invalid!");
            this.rut = int.Parse(rut);
            this.dv = dv;
        }
    }
}
