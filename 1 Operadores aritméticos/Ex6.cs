
// Faça um algoritmo que leia o preço de um produto e mostre seu novo preço, com 5% de desconto.



using System;

namespace Fundamentos
{
    public class Program
    {
        private const decimal _desconto = 0.95m;

        private static void Main(string[] args)
            => ExibirDados();

        private static decimal RetornarNumeroInput()
        {
            decimal preco;
            while (true)
            {
                Console.Write($"Entre com um valor: ");
                string entrada = Console.ReadLine().Trim();
                if(!decimal.TryParse(entrada, out preco) || preco <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return preco;
        }

        private static decimal RetornarPrecoComReajuste(decimal preco)
            => preco * _desconto;

        private static void ExibirDados()
        {
           
            decimal precoProduto = RetornarNumeroInput();

            Console.Clear();
            Console.WriteLine($"Preco {precoProduto:C2} com 5% de desconto: {RetornarPrecoComReajuste(precoProduto):C2}");
        }
    }
}
