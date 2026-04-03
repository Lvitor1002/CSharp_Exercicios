

/*
    Faça um programa que leia um número inteiro e diga se ele é ou não um número primo.
*/


using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroInput()
        {
            int numero;
            while (true)
            {
                Console.Write("Entre com um número: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return numero;
        }
        private static bool NumeroEhPrimo(int numero)
        {
            if (numero < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
                if (numero % i == 0)
                    return false;

            return true;
        }

        private static void ExibirDados()
        {
            int numero = RetornarNumeroInput();

            Console.Clear();
            Console.WriteLine(NumeroEhPrimo(numero) ? $"Número {numero} é primo" : $"Número {numero} não é primo");
        }

    }
}
