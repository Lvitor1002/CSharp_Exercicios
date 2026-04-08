

/*
    Faça um programa que leia três números e mostre qual é o maior e qual é o menor.
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarArrayNumeros()
        {
            var numeros = new int[3];

            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    Console.Write($"Entre com o {i+1}ª número: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out int numero) || numero < 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. ");
                        continue;
                    }
                    numeros[i] = numero;
                    break;
                }
            }
            return numeros;
        }

        private static void ExibirDados()
        {
            var numeros = RetornarArrayNumeros();

            Console.Clear();
            Console.WriteLine($"Números: {string.Join(", ", numeros)}.\nMaior número: {numeros.Max()}\nMenor número: {numeros.Min()}");
        }
    }
}
