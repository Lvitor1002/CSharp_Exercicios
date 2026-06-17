

/* 
Desenvolva um programa que leia quatro _arrayValores pelo teclado e guarde-os em uma tupla. No final, mostre:

A) Quantas vezes apareceu o valor 9.
B) Em que posição foi digitado o primeiro valor 3.
C) Quais foram os números pares.
d) Tupla Ordenada
*/


using System;
using System.Collections.Generic;
using System.Linq;



namespace Fundamentos
{
    public static class Program
    {
        private static int [] _arrayValores = new int[4];

        private static void Main(string[] args)
            => ExibirDados();

        private static void PopularArrayComQuatroNumeros()
        {            
            for(int i = 0; i < _arrayValores.Length; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"Digite o {i+1}ª valor: ");
                    string entrada = Console.ReadLine().Trim();
                    if(!int.TryParse(entrada, out int valor))
                    {
                        Console.Clear();
                        Console.WriteLine("Valor inválido. Por favor, digite um número inteiro.");
                        continue;
                    }
                    _arrayValores[i] = valor;
                    break;
                }
            }
            Console.Clear();
        }

        private static int RetornarQuantidadeValorNove()
            => _arrayValores.Count(v=>v == 9);


        private static int RetornarPrimeriaPosicaoTres()
            => Array.IndexOf(_arrayValores, 3) + 1;


        private static List<int> RetornarListaNumerosPares()
            => _arrayValores.Where(v=>v % 2 == 0).ToList();


        private static void ExibirDados()
        {
            PopularArrayComQuatroNumeros();
            int quantidadeNove = RetornarQuantidadeValorNove();
            int posicaoTres = RetornarPrimeriaPosicaoTres();
            var numerosPares = RetornarListaNumerosPares();

            Console.WriteLine($"\nTodos os valores: {string.Join(", ", _arrayValores)}.\n");

            //A) Quantas vezes apareceu o valor 9.
            Console.WriteLine(quantidadeNove > 0 ? $"O valor 9 apareceu {quantidadeNove}x\n" : "");

            //B) Em que posição foi digitado o primeiro valor 3.
            Console.WriteLine(posicaoTres > 0 ? $"O valor 3 foi digitado na posição {posicaoTres}ª\n" : "");

            //C) Quais foram os números pares.
            Console.WriteLine(numerosPares.Any() ? $"Números pares: {string.Join(", ", numerosPares)}.\n" : "");

            //d) Tupla Ordenada
            Console.WriteLine($"Tupla ordenada: {string.Join(", ", _arrayValores.OrderBy(v => v))}.\n");
        }
    }
}
