
/*
Escreva um programa que pergunte a quantidade de Km percorridos por um carro alugado e a quantidade de dias 
pelos quais ele foi alugado. 
Calcule o preço a pagar, sabendo que o carro custa R$60 por dia e R$0,15 por Km rodado.
*/


using System;

namespace Fundamentos
{
    public class Program
    {
        private static double _custoPorDia = 60;
        private static double _custoPorKm = 0.15;

        private static void Main(string[] args)
            => ExibirDados();

        private static (int,int) RetornarDadosInput()
        {
            int quantidadeDiasAlugado, kmsRodados;

            while (true)
            {
                Console.Write($"Entre com a quantidade de dias que o automóvel ficou alugado: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out quantidadeDiasAlugado) || quantidadeDiasAlugado <=0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write($"Entre com o total de quilometros rodados pelo automóvel: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out kmsRodados) || kmsRodados <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return (kmsRodados, quantidadeDiasAlugado);
        }

        private static double RetornarPrecoCobradoAluguel(int quantidadeDiasAlugado, int kmsRodados)
            => (quantidadeDiasAlugado * _custoPorDia) + (kmsRodados * _custoPorKm);

        private static void ExibirDados()
        {
           
            var (kmsRodados, quantidadeDiasAlugado) = RetornarDadosInput();

            Console.Clear();
            Console.WriteLine($"O automóvel rodou {kmsRodados}km alugado por {quantidadeDiasAlugado} dias, portanto o valor cobrado será: {RetornarPrecoCobradoAluguel(kmsRodados,quantidadeDiasAlugado):C2}");
        }
    }
}
