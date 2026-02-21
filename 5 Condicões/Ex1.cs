

/*
 Escreva um programa que leia a velocidade de um carro. 
Se ele ultrapassar 80Km/h, mostre uma mensagem dizendo que ele foi multado. 
A multa vai custar R$7,00 por cada Km acima do limite.
 */
using System;
using System.Globalization;

namespace TREINO
{
    class Program
    {
        static void Main() => AplicarMulta();

        private static int Leitura()
        {
            int velocidadeAtual = 0;
            while (true)
            {
                Console.Write("Radar a frente... Qual sua valocidade atual? ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out velocidadeAtual) || velocidadeAtual < 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' maior que 0");
                    continue;
                }
                break;
            }
            return velocidadeAtual;
        }

        private static void AplicarMulta()
        {
            Console.Clear();
            var velocidadeAtual = Leitura();
            double multa = 7 * (velocidadeAtual - 80);

            if (velocidadeAtual < 80)
            {
                Console.WriteLine($"Velocidade atual: {velocidadeAtual}KM/h\nSiga viagem..\n");
                return;
            }
            Console.WriteLine($"Velocidade atual: {velocidadeAtual}KM/h\nMultado em {multa.ToString("C", new CultureInfo("pt-BR"))}\n");
        }
    }
}

