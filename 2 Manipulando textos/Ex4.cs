


/*
Faça um programa que leia uma frase pelo teclado e mostre quantas vezes aparece a letra "a", 
em que posição ela aparece a primeira vez e em que posição ela aparece a última vez.
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static string RetornarFraseInput()
        {
            string frase;
            while (true)
            {
                Console.Write($"Entre com uma frase: ");
                frase = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(frase))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return frase;
        }

        private static void ValidarFrase(string frase)
        {
            Console.Clear();

            int primeiraPosicaoA = frase.IndexOf('a') + 1;
            Console.WriteLine($"Primeira posição de 'a' na frase '{frase}': {primeiraPosicaoA}ª\n");

            int quantidadeVezesA = frase.Where(x=>x == 'a').Count();
            Console.WriteLine($"'a' apareceu na frase '{frase}' {quantidadeVezesA}x\n");

            int ultimaPosicaoA = frase.Replace(" ","").LastIndexOf('a') + 1;
            Console.WriteLine($"Última posição de 'a' na frase '{frase}': {ultimaPosicaoA}ª\n");
        }

        private static void ExibirDados()
            => ValidarFrase(RetornarFraseInput());

    }
}
