

/*
    Desenvolva um programa que leia o comprimento de três retas e diga ao usuário se elas podem ou não formar um triângulo.
*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static double[] RetornarRetasTriangulo()
        {
            var retas = new double[3];

            for(int i = 0; i < retas.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Entre com o comprimento da {i+1}ª reta: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!double.TryParse(entrada, out double reta) || reta <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                        continue;
                    }
                    retas[i] = reta;
                    break;
                }
            }
            return retas;
        }

        private static bool VerificarEhTriangulo(double[] retas)
            => retas[0] + retas[1] > retas[2] && retas[1] + retas[2] > retas[0] && retas[0] + retas[2] > retas[1];

        private static void ExibirDados()
        {
            var retas = RetornarRetasTriangulo();

            Console.Clear();
            Console.WriteLine(VerificarEhTriangulo(retas) 
                ? $"As retas {string.Join(", ",retas)}. Formam um triângulo.\n" 
                : $"As retas {string.Join(", ", retas)}. Não formam um triângulo.\n");
        }
    }
}
