

/*
    Faça um programa que leia um ângulo qualquer e mostre na tela o valor do seno, cosseno e tangente desse ângulo.
*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static double RetornarAnguloInput()
        {
            double angulo;

            while (true)
            {
                Console.Write($"Entre com um valor para o ângulo: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, out angulo) || angulo <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' maior ou igual a zero");
                    continue;
                }
                break;
            }
            
            return (Math.PI * angulo) / 180;
        }

        private static void ExibirDados()
        {
            var angulo = RetornarAnguloInput();

            Console.Clear();
            Console.WriteLine($"\t  Ângulo de {angulo:F0}° Graus\n\nSeno: {Math.Sin(angulo):F2}\nCosseno: {Math.Cos(angulo):F2}\nTangente: {Math.Tan(angulo):F2}\n");
        }    
    }
}
