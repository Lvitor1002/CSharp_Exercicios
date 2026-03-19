
/* Crie um programa que leia quanto dinheiro uma pessoa tem na carteira e (mostre quantos dólares ela pode comprar).
Não é converção.
Dolar atual 19/2025: 5,22
valor/5.22
*/


using System;

namespace Fundamentos
{
    public class Program
    {
        private const decimal _dolarAtual = 5.22m;

        private static void Main(string[] args)
            => ExibirDados();

        private static decimal RetornarNumeroInput()
        {
            decimal reais;
            while (true)
            {
                Console.Write($"Quantos reais você possuí na carteira? R$ ");
                string entrada = Console.ReadLine().Trim();
                if(!decimal.TryParse(entrada, out reais) || reais <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return reais;
        }

        private static decimal RetornarCalculo(decimal reais)
            => reais / _dolarAtual;

        private static void ExibirDados()
        {
            decimal reais = RetornarNumeroInput();
            Console.Clear();
            Console.WriteLine($"Com o valor informado, você pode comprar US${RetornarCalculo(reais):F2}\n");
        }
    }
}
