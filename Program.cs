using System;
using System.Collections.Generic;

namespace RomanoADecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conversor de numeros romanos a decimales");
            Console.Write("Ingrese un numero romano: ");
            string romano = Console.ReadLine().ToUpper();

            int decimalNum = ConvertirRomanos(romano);

            if (decimalNum != -1)
                Console.WriteLine($"El numero romano {romano} equivale a {decimalNum} en decimal.");
            else
                Console.WriteLine("Numero romano invalido.");
        }

        static int ConvertirRomanos(string romano)
        {
            Dictionary<char, int> valores = new Dictionary<char, int>()
            {
                {'I', 1 }, {'V', 5 }, {'X', 10 }, {'L', 50 }, {'C', 100 }, {'D', 500 }, {'M', 1000 }
            };

            int total = 0;
            int valorAnterior = 0;
            int repeticiones = 1;
            char simboloAnterior = '\0';

            for (int i = romano.Length - 1; i >= 0; i--)
            {
                char letra = romano[i];
                if (!valores.ContainsKey(letra))
                    return -1;

                int valor = valores[letra];

                if (letra == simboloAnterior)
                {
                    repeticiones++;
                    if ((letra == 'V' || letra == 'L' || letra == 'D') && repeticiones > 1)
                        return -1;
                    if (repeticiones > 3)
                        return -1;
                }
                else
                {
                    repeticiones = 1;
                }

                if (valor < valorAnterior)
                {
                    if (!EsSustraccionValidas(letra, simboloAnterior))
                        return -1;
                    total -= valor;
                }
                else
                {
                    total += valor;
                }

                simboloAnterior = letra;
                valorAnterior = valor;
            }

            return total;


            static bool EsSustraccionValidas(char menor, char mayor)
            {
                return (menor == 'I' && (mayor == 'V' || mayor == 'X')) || (menor == 'X' && (mayor == 'L' || mayor == 'C')) || (menor == 'C' && (mayor == 'D' || mayor == 'M'));
            }

        }
    }
}