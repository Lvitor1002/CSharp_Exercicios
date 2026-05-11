

/*
Escreva um programa que leia um número N inteiro qualquer e mostre na tela 
os N primeiros elementos de uma Sequência de Fibonacci. 

Ex: 0 - 1 - 1 - 2 - 3 - 5 - 8
*/


using System;
using System.Collections.Generic;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroN()
        {
            while (true)
            {
                Console.Write("Digite um número: ");
                string entrada = Console.ReadLine().Trim();
                if(!int .TryParse(entrada, out int numeroN) || numeroN < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Digite um número inteiro válido e maior ou igual à zero.");
                    continue;
                }
                Console.Clear();
                return numeroN;
            }
        }
        private static List<int> RetornarNElementosFibonacci(int numeroN)
        {
            if(numeroN == 0)
                return new List<int>();
            
            if(numeroN == 1)
                return new List<int>{ 0};

            var listaFibonacci = new List<int>{ 0,1};

            while(listaFibonacci.Count < numeroN)
            {
                int proximoElemento = listaFibonacci[listaFibonacci.Count - 1] + listaFibonacci[listaFibonacci.Count - 2];
                listaFibonacci.Add(proximoElemento);
            }
            return listaFibonacci;
        }

        private static void ExibirDados()
        {
            int numeroN = RetornarNumeroN();
            Console.WriteLine($"\nOs {numeroN} primeiros elementos da Sequência de Fibonacci são: {string.Join(" - ", RetornarNElementosFibonacci(numeroN))}.");
        }
    }
}
