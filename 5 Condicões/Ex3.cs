

/*
    Desenvolva um programa que pergunte a distância de uma viagem em Km. 
    Calcule o preço da passagem, cobrando R$0,50 por Km para viagens de até 200Km e R$0,45 parta viagens mais longas.
*/

using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarDistanciaViagem()
        {
            while (true)
            {
                Console.Write($"Digite a distância de sua viagem em KM: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int distancia) || distancia <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um valor inteiro e maior que zero.");
                    continue;
                }
                return distancia;
            }
        }

        private static double RetornarPrecoPassagem(int distancia)
            => distancia <= 200 ? distancia * 0.50 : distancia * 0.45;


        private static void ExibirDados()
        {
            int distanciaViagem = RetornarDistanciaViagem();

            Console.Clear();
            Console.WriteLine($"Preço cobrado pela viagem de {distanciaViagem}KM rodados: {RetornarPrecoPassagem(distanciaViagem):C2}\n");
        }
    }
}
