

/*
Desafio para produzir operações matemáticas como tipos de números específicos

Considere os dados:
                int value1 = 11;
                decimal value2 = 6.2m;
                float value3 = 4.3f;

Agora:
        Divida value1 por value2, exiba o resultado como um int
        Divida value2 por value3, exiba o resultado como um decimal
        Divida value3 por value1, exiba o resultado como um float
        
*/
using System;
using System.Globalization;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => ConverterValores();

        private static void ConverterValores()
        {
            int value1 = 11;
            decimal value2 = 6.2m;
            float value3 = 4.3f;


            int result1 = Convert.ToInt32(value1 / value2);
            Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");


            decimal result2 = value2 / (decimal)value3;
            Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");


            float result3 = value3 / (float)value1;
            Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
        }
    }
}
