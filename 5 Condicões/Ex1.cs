
/*
    Escreva um programa que leia a velocidade de um carro. 
    Se ele ultrapassar 80Km/h, mostre uma mensagem dizendo que ele foi multado. 
    A multa vai custar R$7,00 por cada Km acima do limite.
*/


using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarVelocidadeCarro()
        {
            while (true)
            {
                Console.Write($"Digite a velocidade do carro: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int velocidadeCarro) || velocidadeCarro <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um valor inteiro e maior que zero.");
                    continue;
                }
                return velocidadeCarro;
            }
        }

        private static double RetornarValorMulta(int velocidadeCarro)
            => velocidadeCarro > 80 ? (velocidadeCarro - 80) * 7.0 : 0.0;


        private static void ExibirDados()
        {
            int velocidadeCarro = RetornarVelocidadeCarro();
            double valorMulta = RetornarValorMulta(velocidadeCarro);

            Console.Clear();
            Console.WriteLine(valorMulta > 0 
                ? $"O carro estava a {velocidadeCarro}Km/h, ultrapassando o limite de 80Km/h.\nValor da multa: {valorMulta:C2}" 
                : $"O carro estava a {velocidadeCarro}Km/h, dentro do limite permitido. Sem multa.");

        }
    }
}
