


/*
Faça um programa que mostre na tela uma contagem regressiva para o estouro de fogos de artifício, 
indo de 10 até 0, com uma pausa de 1 segundo entre eles
*/

using System;
using System.Threading;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirContagemRegressiva();

        private static int RetornarNumeroContagem()
        {
            int numero;

            while (true)
            {
                Console.Write($"Entre com um número desejado para uma contagem regressiva: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out numero) || numero <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return numero;
        }


        private static void ExibirContagemRegressiva()
        {
            int numero = RetornarNumeroContagem();

            Console.Clear();
            
            for (int c = numero; c >= 0; c--)
            {
                Console.WriteLine(c);
                Thread.Sleep(1000);
            }
        }
    }
}
