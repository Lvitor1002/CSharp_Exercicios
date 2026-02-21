

/*
Faça um programa que leia a largura e a altura de uma parede em metros, 
calcule a sua área e a quantidade de tinta necessária para pinta-lá, 
sabendo que cada litro de tinta, pinta uma área de 2m^2.
*/
using System;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        private static (decimal, decimal) Calcular()
        {
            decimal altura, largura;

            while (true)
            {
                Console.Write("Entre com um valor para altura: ");
                string entradaAltura = Console.ReadLine().Trim();
                if(!decimal.TryParse(entradaAltura, out altura) || altura < 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida para altura.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Entre com um valor para largura: ");
                string entradaLargura = Console.ReadLine().Trim();
                if (!decimal.TryParse(entradaLargura, out largura) || largura < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida para largura.");
                    continue;
                }
                break;
            }
            decimal area = AreaReatangulo(altura, largura);
            decimal quantidade = QuantidadeLitrosNecessarioParede(altura, largura);
            return (area, quantidade);
        }

        private static decimal AreaReatangulo(decimal altura, decimal largura)
            => altura * largura;

        private static decimal QuantidadeLitrosNecessarioParede(decimal altura, decimal largura)
            => AreaReatangulo(altura, largura) / 2;

        private static void Exibir()
        {
            var (area, quantidade) = Calcular();
            Console.Clear();
            Console.WriteLine($"\nÁrea da parede: {area}m²");
            Console.WriteLine($"Quantidade de tinta necessária: {quantidade} litros");
        }
    }
}

