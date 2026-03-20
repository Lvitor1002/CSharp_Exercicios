
//Escreva um programa que converta uma temperatura digitando em graus Celsius e converta para graus Fahrenheit.



using System;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static double RetornarNumeroInput()
        {
            double Celsius;
            while (true)
            {
                Console.Write($"Entre com um valor de graus celsius: °");
                string entrada = Console.ReadLine().Trim();
                if(!double.TryParse(entrada, out Celsius)){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return Celsius;
        }

        private static double RetornarFahrenheit(double valorCelsius)
            => (valorCelsius * 1.8) + 32;

        private static void ExibirDados()
        {
           
            double valorCelsius = RetornarNumeroInput();

            Console.Clear();
            Console.WriteLine($"Temperatura de {valorCelsius}º Graus Celsius convertida para {RetornarFahrenheit(valorCelsius)}º fahrenheit");
        }
    }
}
