

// Crie um programa que leia quanto dinheiro uma pessoa tem na carteira e (mostre quantos dólares ela pode comprar).
// Não é converção.
//dolar atual 01/2025: 6,17
// valor/6.17
using System;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        private static decimal RetornaDolares()
        {
            decimal valor;
            while (true)
            {
                Console.Write("Quantos reais possui na carteria? R$ ");
                string entrada = Console.ReadLine().Trim();
                if(!decimal.TryParse(entrada, out valor) || valor < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }
                break;
            }
            return valor / 6.17m;
        }
        private static void Exibir()
        {
            decimal valor = RetornaDolares();
            Console.Clear();
            Console.WriteLine($"Com o valor informado, você pode comprar US${valor:F2}\n");
        }
    }
}

