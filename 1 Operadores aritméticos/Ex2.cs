
//# Faça um programa que calcule a média entre 4 números usando FOR.


using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarNumerosInput()
        {

            var numeros = new int[4];

            for(int i = 0; i < numeros.Length; i++)
            {
                int numero;
                while (true)
                {
                    Console.Write($"Entre com o {i+1}ª número: ");
                    string entrada = Console.ReadLine().Trim();
                    if(!int.TryParse(entrada, out numero) || numero <= 0){
                        Console.Clear();
                        Console.WriteLine("Entrada inválida.");
                        continue;
                    }
                    break;
                }
                numeros[i] = numero;
            }
            return numeros;
        }

        private static double RetornarMediaNumeros(int[] numeros)
            => numeros.Average();

        private static void ExibirDados()
        {
            var numeros = RetornarNumerosInput();

            Console.Clear();
            Console.WriteLine($"Média dos números [{string.Join(", ", numeros)}]: {RetornarMediaNumeros(numeros):F2}");
        }

    }
}
