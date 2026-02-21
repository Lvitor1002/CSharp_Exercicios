//# Faça um programa que calcule a média entre 4 números usando FOR.

using System;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        private static int[] Calculo()
        {
            int[] numeros = new int[4];
            
            Console.WriteLine("Digite abaixo 4 notas: ");
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}ª Nota: ");
                    string entrada = Console.ReadLine().Trim();
                    if(!int.TryParse(entrada, out int numero) || numero < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Valor inválido, tente novamente.");
                        continue;
                    }
                    numeros[i] = numero;
                    break;
                }
            }
            return numeros;
        }
        private static void Exibir()
        {
            var numeros = Calculo();
            Console.Clear();
            Console.WriteLine($"\n\nA média entre {string.Join(", ", numeros)} é: {numeros.Average()}");
        }
    }
}

