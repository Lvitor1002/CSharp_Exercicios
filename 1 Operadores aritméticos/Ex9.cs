

/*
Escreva um programa que pergunte a quantidade de Km percorridos por um carro alugado e a quantidade de dias 
pelos quais ele foi alugado. 
Calcule o preço a pagar, sabendo que o carro custa R$60 por dia e R$0,15 por Km rodado.
*/
using System;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        private static (int,int,decimal) CalcularValorTotal()
        {
            const decimal VALOR_DIA = 60m, VALOR_KM = 0.15m;
            int diasAlugado, quantidadeKm;

            while (true)
            {
                Console.Write("Entre com a quantidade de Km's rodados: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out quantidadeKm) || quantidadeKm < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Entre com a quantidade total de dias de aluguel do carro: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out diasAlugado) || diasAlugado < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }
                break;
            }
            decimal valorTotal = VALOR_DIA * diasAlugado + VALOR_KM * quantidadeKm;
            return (diasAlugado, quantidadeKm, valorTotal);
        }

        private static void Exibir()
        {
            
            var (diasAlugado, quantidadeKm, valorTotal) = CalcularValorTotal();

            Console.Clear();
            Console.WriteLine($"Valor total a pagar pelo aluguel de {diasAlugado} dias e {quantidadeKm}KM rodados: {valorTotal:F2}\n");
        }
    }
}

