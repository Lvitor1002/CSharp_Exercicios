

/*
Faça um programa que leia o comprimento do cateto oposto e do cateto adjacente de um triângulo retângulo. 
Calcule e mostre o comprimento da hipotenusa.
*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static (double, double) RetornarComprimentosCatetos()
        {
            double co,ca;

            while (true)
            {
                Console.Write($"Entre com o comprimento do cateto oposto: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, out co) || co <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' maior ou igual a zero");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write($"Entre com o comprimento do cateto adjacente: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, out ca) || ca <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' maior ou igual a zero");
                    continue;
                }
                break;
            }
            return (co,ca);
        }

        private static double RetornarHipotenusa(double co, double ca)
            => Math.Sqrt(Math.Pow(ca, 2) + Math.Pow(co, 2));
            

        private static void ExibirDados()
        {
            var (catetoOposto, catetoAdjacente) = RetornarComprimentosCatetos();

            Console.Clear();
            Console.WriteLine($"Comprimento da Hipotenusa: {RetornarHipotenusa(catetoOposto,catetoAdjacente):F2}");
        }    
    }
}
