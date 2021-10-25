using System;

namespace Rut.Utils
{
    public static class Parser
    {
        public static (int number, char dv) ParseCleanRutString(string rut)
        {
            var rutParts = rut.Split('-');
            var rutNumber = int.Parse(rutParts[0]);
            var rutDv = rutParts.Length == 1 ? Calculator.CalculateDv(rutNumber) : rutParts[1][0];
            return (number: rutNumber, dv: rutDv);
        }
    }
}