
/*
Faça um programa que leia a largura e a altura de uma parede em metros, 
calcule a sua área e a quantidade de tinta necessária para pinta-lá, 
sabendo que cada litro de tinta, pinta uma área de 2m^2.
*/


using System;

namespace Fundamentos
{
    public class Program
    {
        private const decimal _dolarAtual = 5.22m;

        private static void Main(string[] args)
            => ExibirDados();

        private static (double,double) RetornarNumerosInput()
        {
            double largura, altura;
            while (true)
            {
                Console.Write($"Entre com a largura da parede: ");
                string entrada = Console.ReadLine().Trim();
                if(!double.TryParse(entrada, out largura) || largura <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write($"Entre com a altura da parede: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, out altura) || altura <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return (largura, altura);
        }

        private static double RetornarAreaParede(double largura, double altura)
            => largura * altura;

        private static double RetornarQuantidadeTinta(double area)
            => area / 2;

        private static void ExibirDados()
        {
            var (largura, altura) = RetornarNumerosInput();
            double areaParede = RetornarAreaParede(largura, altura);

            Console.Clear();
            Console.WriteLine($"\nÁrea da parede: {areaParede}m²");
            Console.WriteLine($"Quantidade de tinta necessária: {RetornarQuantidadeTinta(areaParede)} litros");
        }
    }
}
