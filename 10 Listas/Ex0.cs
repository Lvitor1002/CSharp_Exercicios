

/*
    Faça um programa que leia 10 valores numéricos e guarde-os em uma lista. 
    No final, mostre a lista ordenada e qual foi o maior e o menor valor digitado e as suas respectivas POSIÇÕES na lista. 
*/


using System;
using System.Collections.Generic;
using System.Linq;


namespace Fundamentos
{
    public static class Program
    {
        private static void Main(string[] args)
            => ExibirDados();


        private static List<int> RetornarListaDezValores()
        {
            var listaNumeros = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                while (true)
                {
                    Console.Write($"Digite o {i + 1}º valor: ");
                    string entrada = Console.ReadLine().Trim();

                    if (!int.TryParse(entrada, out int valor) || valor < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Valor inválido. Digite um número inteiro positivo.");
                        continue;
                    }
                    listaNumeros.Add(valor);
                    break;
                }
            }
            Console.Clear();
            return listaNumeros;
        }

        private static void ExibirDados()
        {
            var listaNumeros = RetornarListaDezValores();

            Console.WriteLine($"Todos os valores adicionados em ordem: {string.Join(",", listaNumeros.OrderBy(x => x).ToList())}\n");
            Console.WriteLine($"Todos os valores adicionados na ordem orignal: {string.Join(",", listaNumeros)}");
            Console.WriteLine($"Maior valor: {listaNumeros.Max()} na posição {listaNumeros.IndexOf(listaNumeros.Max()) + 1}ª.\nMenor valor: {listaNumeros.Min()} na posição {listaNumeros.IndexOf(listaNumeros.Min()) + 1}ª");
        }
    }
}
