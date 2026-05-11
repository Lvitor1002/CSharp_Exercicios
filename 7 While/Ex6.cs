

/*
    Crie um programa que leia vários números inteiros pelo teclado. 
    No final da execução, mostre a média entre todos os valores e qual foi o maior e o menor valores lidos. 
    O programa deve perguntar ao usuário se ele quer ou não continuar a digitar valores.
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static List<int> RetornarListaValores()
        {
            var listaValores = new List<int>();
            var entradasValidas = new List<string> { "s", "n" };

            while (true)
            {
                Console.Clear();
                Console.Write("Entre com um valor: ");
                string entrada = Console.ReadLine().Trim();
                if(!int .TryParse(entrada, out int numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Digite um número inteiro válido e maior ou igual à zero.");
                    continue;
                }
                
                listaValores.Add(numero);

                while (true)
                {
                    Console.Write("Deseja continuar a digitar valores? [s/n] - ");
                    string entradaSN = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(entradaSN) || !entradasValidas.Contains(entradaSN))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas 's' ou 'n'");
                        continue;
                    }
                    if(entradaSN != "n")
                        break;
                    return listaValores;
                }
            }
        }
        private static void ExibirDados()
        {
            var listaValores = RetornarListaValores();
            Console.Clear();
            Console.WriteLine(listaValores.Any() 
                ? $"Valores {string.Join(", ",listaValores)}.\nMédia de valores: {listaValores.Average():F2}.\nMaior valor: {listaValores.Max()}\nMenor valor: {listaValores.Min()}\n"
                : "Não há valores.\n");

        }
    }
}
