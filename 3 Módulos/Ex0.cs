

/*
Crie um programa que leia um número Real qualquer pelo teclado e mostre na tela a sua porção Inteira.
Ex: Digite um número: 6.127
O número 6.127 tem a parte Inteira 6.
*/

using System;
using System.Globalization;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static double RetornarNumeroInput()
        {
            double numero = 0;

            while (true)
            {
                Console.Write($"Entre com um número real: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out numero) || numero <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return numero;
        }

        private static int RetornarNumeroInteiro(double numero)
            => (int)numero;

        private static void ExibirDados()
        {
            double numero = RetornarNumeroInput();

            Console.Clear();
            Console.WriteLine($"Número real '{numero}' convertido em inteiro: {RetornarNumeroInteiro(numero)}");
        }    
    }
}
