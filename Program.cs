using System;
using System.Collections.Generic;

namespace RomanoADecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conversor de números romanos a decimales");
            Console.Write("Ingrese un número romano: ");
            string romano = Console.ReadLine().ToUpper();

            int decimalNum = RomanoADecimal(romano);

            if (decimalNum != -1)
                Console.WriteLine($"El número romano {romano} equivale a {decimalNum} en decimal.");
            else
                Console.WriteLine("Número romano inválido.");
        }

        static int RomanoADecimal(string romano)
        {
            Dictionary<char, int> valores = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };

            int total = 0;
            int valorAnterior = 0;

            for (int i = romano.Length - 1; i >= 0; i--)
            {
                char letra = romano[i];
                if (!valores.ContainsKey(letra))
                    return -1; 
                int valor = valores[letra];

                if (valor < valorAnterior)
                    total -= valor;
                else
                    total += valor;

                valorAnterior = valor;
            }

            return total;
        }
    }
}