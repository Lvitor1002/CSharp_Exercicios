


/*
    Desenvolva um programa que leia o primeiro termo e a razão de uma PA. No final, mostre os 10 primeiros termos dessa progressão.
*/


using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDezPrimeirosTermosDados();

        private static (int, int) RetornarPrimerioTermoPA()
        {
            int numero, razao;
            while (true)
            {
                Console.Write("Entre com o primeiro termo de uma Progressão Aritmética: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out numero) || numero <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Entre com a razão de uma Progressão Aritmética: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out razao) || razao <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return (numero, razao);
        }

        private static int[] RetornarDezPrimeirosTermosPA()
        {
            var (primeiroTermo, razao) = RetornarPrimerioTermoPA();

            var termos = new int[10];
            
            for (int i = 0; i < termos.Length; i++)
                termos[i] = primeiroTermo + (razao * i);

            Console.Clear();
            return termos;
        }

        private static void ExibirDezPrimeirosTermosDados()
            => Console.WriteLine($"Os 10 primeiros termos da PA são: {string.Join(", ", RetornarDezPrimeirosTermosPA())}.");
    }
}
