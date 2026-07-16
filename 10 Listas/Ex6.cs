



/*
    Crie um programa onde o usuário possa digitar sete valores numéricos e
    cadastre-os em uma lista única e que mantenha também nesta lista separados os valores pares e ímpares. 
    No final, mostre os valores pares e ímpares em ordem crescente.
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


        private static List<List<int>> RetornarListaPessoas()
        {
            var listaNumeros = new List<List<int>>{ new List<int>(), new List<int>()};

            for (int i = 0; i < 7; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"Digite o {i + 1}ª Número: ");
                    string entrada = Console.ReadLine().Trim();
                    if(!int.TryParse(entrada, out int numero) || numero < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' positivo.");
                        continue;
                    }

                    if(numero % 2 == 0)
                        listaNumeros[0].Add(numero);
                    else
                        listaNumeros[1].Add(numero);

                    break;
                }
            }
            Console.Clear();
            return listaNumeros;
        }
      

        private static void ExibirDados()
        {
            var listaPessoas = RetornarListaPessoas();
            Console.WriteLine($"Lista de todos os Números : {string.Join(",", listaPessoas.SelectMany(n=>n).OrderBy(n => n))}.\n");
            Console.WriteLine($"Lista de Números Pares: {string.Join(",", listaPessoas[0].OrderBy(n => n))}.\n");
            Console.WriteLine($"Lista de Números Ímpares: {string.Join(",", listaPessoas[1].OrderBy(n => n))}.\n");
        }
    }
}
