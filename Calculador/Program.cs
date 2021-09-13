using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // CalcularDV("18464695");
        // CalcularDV("18835838");
        // CalcularDV("97004000");
        CalcularDV(args[0]);
        Console.WriteLine(args[0]);
    }

    private static void CalcularDV(string rut)
    {
        Dictionary<int, int> multiplos = new Dictionary<int, int>
        {
            { 7, 2 }, { 6, 3 },
            { 5, 4 }, { 4, 5 },
            { 3, 6 }, { 2, 7 },
            { 1, 2 }, { 0, 3 }
        };

        var digitos = rut.ToCharArray().Select((digito, index) =>
            new
            {
                digit = int.Parse(digito.ToString()),
                index
            }
        ).ToList();

        int suma = digitos.Aggregate(0, (acc, curr) => acc + (curr.digit * multiplos[curr.index]));
        int resto = suma % 11;
        int digito = 11 - resto;
        string digitoChar = digito == 11 ? "0" : digito == 10 ? "K" : digito.ToString();

        Console.WriteLine("El DV de " + rut + " es: " + digitoChar);
    }
}