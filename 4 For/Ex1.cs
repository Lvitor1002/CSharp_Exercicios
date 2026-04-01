

/*
Crie um programa que mostre na tela todos os números pares que estão no intervalo entre 1 e 50.
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirIntervaloNumeros();

        private static void ExibirIntervaloNumeros()
            =>Console.Write($"\nNúmeros de 1 à 50: {string.Join(", ", Enumerable.Range(1, 50).Where(x => x % 2 == 0))}.\n\n");
    }
}
