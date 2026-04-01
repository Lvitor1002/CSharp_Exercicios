


/*
    Desenvolva um programa que leia seis números inteiros e mostre a soma apenas daqueles que forem pares. 
    Se o valor digitado for ímpar, desconsidere-o.
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarNumeros()
        {
            var numeros = new int[6];

            for (int i = 0; i < 6; i++)
                while (true)
                {
                    Console.Write($"Entre com o {i+1}ª número: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out int numero) || numero < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida.");
                        continue;
                    }
                    numeros[i] = numero % 2 == 0 ? numero : 0;
                    break;
                }

            Console.Clear();
            return numeros;
        }


        private static void ExibirDados()
            =>Console.WriteLine($"\nSoma dos números pares digitados: {RetornarNumeros().Sum()}");
    }
}
