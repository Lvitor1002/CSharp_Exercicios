
//# Faça um programa que leia um número int e mostre na tela a sua tabuada.


using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroInput()
        {
            int numero;
            while (true)
            {
                Console.Write($"Entre com um número: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numero) || numero <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return numero;
        }

        private static void RetornarTabuada(int numero)
        {
            Console.Clear();
            
            Console.WriteLine($"Tabuada do {numero}:");
            for(int i = 0; i <= 10; i++)
                Console.WriteLine($@"{numero} x {i} = {numero * i}");
            Console.WriteLine();
        }

        private static void ExibirDados()
            => RetornarTabuada(RetornarNumeroInput());

    }
}
