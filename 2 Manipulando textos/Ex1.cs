


//Faça um programa que leia um número de 0 a 9999 e mostre na tela cada um dos dígitos separados: unidade, centena, dezena, milhar.

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
                Console.Write($"Entre com um número de 0 à 9999: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out numero) || numero < 0 || numero > 9999)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número válido.");
                    continue;
                }
                break;
            }
            return numero;
        }

        private static (int, int, int, int) RetornarUnidades(int numero)
            =>  (numero % 10, 
                (numero / 10) % 10, 
                (numero / 100) % 10, 
                (numero / 1000) % 10);

        private static void ExibirDados()
        {
            int numero = RetornarNumeroInput();
            var (unidade, dezena, centena, milhar) = RetornarUnidades(numero);

            Console.Clear();
            Console.WriteLine($"Unidade: {unidade}\nDezena: {dezena}\nCentena: {centena}\nMilhar: {milhar}");
        }
    }
}
