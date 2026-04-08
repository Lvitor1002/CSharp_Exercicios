

//Crie um programa que leia um número inteiro e mostre na tela se ele é PAR ou ÍMPAR.


using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroInput()
        {
            while (true)
            {
                Console.Write($"Digite um número: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int numero) || numero <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um valor inteiro.");
                    continue;
                }

                return numero;
            }
        }

        private static void ExibirDados()
        {
            int numero = RetornarNumeroInput();
            Console.Clear();
            Console.WriteLine(numero % 2 == 0 ? $"Número {numero} é Par." : $"Número {numero} é ímpar.");
        }
    }
}
