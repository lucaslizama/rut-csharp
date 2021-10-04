namespace Rut.Utils
{
    public class Validator
    {
        public static bool IsValid(int rut)
        {
            string textRut = rut.ToString();
            if (textRut.Length > 8) return false;
            return true;
        }

        public static bool IsValid(string rut)
        {
            if (rut == null) return false;
            if (rut.Length == 0 || rut.Length > 8) return false;
            if (!int.TryParse(rut, out int result)) return false;
            return true;
        }

        public static bool IsValid(int rut, char dv)
        {
            if (!IsValid(rut)) return false;
            if (Calculator.CalculateDV(rut) != dv) return false;

            return true;
        }

        public static bool IsValid(string rut, char dv)
        {
            if (!IsValid(rut)) return false;
            if (Calculator.CalculateDV(rut) != dv) return false;

            return true;
        }
    }
}