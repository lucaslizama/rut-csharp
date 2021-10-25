using System.Linq;

namespace Rut.Utils
{
    public static class Validator
    {
        private static readonly char[] ValidDvValues = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'K' };

        public static bool IsRutValid(int rut)
        {
            string textRut = rut.ToString();
            if (textRut.Length > 8) return false;
            return true;
        }

        public static bool IsRutValid(string rut)
        {
            if (rut == null) return false;
            string cleanRut = Cleaner.CleanRutString(rut);
            return cleanRut.Contains('-') ? ValidateCleanRut(cleanRut) : ValidateCleanRutNoDv(cleanRut);
        }

        private static bool ValidateCleanRut(string rut)
        {
            string[] rutParts = rut.Split('-');
            if (rutParts.Length != 2) return false;
            if (rutParts[0].Length > 8) return false;
            if (rutParts[1].Length != 1) return false;
            if (IsInvalidDv(rutParts[1][0])) return false;
            return true;
        }

        private static bool ValidateCleanRutNoDv(string rut)
        {
            if (!int.TryParse(rut, out int number)) return false;
            return IsRutValid(number);
        }

        public static bool IsRutValid(int rut, char dv)
        {
            if (!IsRutValid(rut)) return false;
            if (Calculator.CalculateDv(rut) != dv) return false;

            return true;
        }

        public static bool IsRutValid(string rut, char dv)
        {
            if (!IsRutValid(rut)) return false;
            if (Calculator.CalculateDv(rut) != dv) return false;

            return true;
        }

        public static bool IsValidDv(char dv)
        {
            return ValidDvValues.Any(valid =>
            {
                bool equal = dv == valid;
                return equal;
            });
        }

        public static bool IsInvalidDv(char dv)
        {
            return !IsValidDv(dv);
        }
    }
}