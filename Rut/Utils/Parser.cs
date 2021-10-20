using System;

namespace Rut.Utils
{
    public class Parser
    {
        public static Tuple<int, char> ParseCleanRutString(string rut)
        {
            string[] rutParts = rut.Split('-');
            int rutNumber = int.Parse(rutParts[0]);
            char rutDv = rutParts.Length == 1 ? Calculator.CalculateDV(rutNumber) : rutParts[1][0];
            return new Tuple<int, char>(rutNumber, rutDv);
        }
    }
}