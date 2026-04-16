

/*
Desenvolva um programa que leia o comprimento de três retas e diga ao usuário se elas podem ou não formar um triângulo.
Mostre que tipo de triângulo será formado:
                                        - EQUILÁTERO: todos os lados iguais
                                        - ISÓSCELES: dois lados iguais, um diferente
                                        - ESCALENO: todos os lados diferentes
*/

using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarArrayRetasTriangulo()
        {
            var retas = new int[3];
            for(int i = 0; i < retas.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Entre com a {i+1}ª reta: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out int reta) || reta < 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. Entre com um valor inteiro e maior que 0.");
                        continue;
                    }
                    retas[i] = reta;
                    break;
                }
            }
            Console.Clear();
            return retas;
        }

        private static string RetornarTipoTrianguloFormado(int[] retas)
            => retas[0] + retas[1] <= retas[2] || retas[0] + retas[2] <= retas[1] || retas[1] + retas[2] <= retas[0] ? "Essas retas não formam um triângulo.\n" 
                : retas[0] == retas[1] && retas[1] == retas[2] ? "Triângulo EQUILÁTERO\n"
                : retas[0] == retas[1] || retas[0] == retas[2] || retas[1] == retas[2] ? "Triângulo ISÓSCELES\n"
                : "Triângulo ESCALENO\n";


        private static void ExibirDados()
            => Console.WriteLine(RetornarTipoTrianguloFormado(RetornarArrayRetasTriangulo()));
    }
}
