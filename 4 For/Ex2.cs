


/*
Faça um programa que calcule a soma entre todos os números que são múltiplos de três e que se encontram no intervalo de 1 até 500.
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirSomaNumerosMultiplosTres();

        private static void ExibirSomaNumerosMultiplosTres()
            => Console.Write($"\nSoma dos números múltiplos de 3 no intervalo de 1 à 500: {string.Join(", ", Enumerable.Range(1, 500).Where(x => x % 3 == 0).Sum())}\n\n");
    }
}
