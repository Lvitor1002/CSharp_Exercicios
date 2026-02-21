

//# Faça um programa que leia um número int e mostre na tela a sua tabuada.

using System;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        private static int Tabuada()
        {
            int numero;
            while (true)
            {
                Console.Write("Entre com um número e veja a tabuada correspondente: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }
                break;
            }
            return numero;
        }
        private static void Exibir()
        {
            var numero = Tabuada();
            for (int i = 0; i <= 10; i++)
                Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }
}

