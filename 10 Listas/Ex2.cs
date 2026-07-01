


/*
Crie um programa que vai ler vários números e colocar em uma lista. Depois disso, mostre:
A) Quantos números foram digitados.
B) A lista de valores, ordenada de forma decrescente.
C) Se o valor 5 foi digitado e está ou não na lista.
*/


using System;
using System.Collections.Generic;
using System.Linq;


namespace Fundamentos
{
    public static class Program
    {
        private static List<int> _listaNumeros = new List<int>();
        private static void Main(string[] args)
            => ExibirDados();


        private static void PopularListaValoresInput()
        {
            Console.Write($"Digite um valor:\nPara finalizar digite 'sair'.\n\n>");
            while (true)
            {
                string entrada = Console.ReadLine().Trim().ToLower();

                if(entrada == "sair")
                    break;

                if (!int.TryParse(entrada, out int valor) || valor < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Digite um número inteiro positivo.");
                    continue;
                }

                _listaNumeros.Add(valor);
            }
            Console.Clear();
        }

        private static int RetornarQuantidadeValoresNaLista()
            => _listaNumeros.Count() > 0 ? _listaNumeros.Count() : 0;

        private static bool ValorCincoEhDigitado()
            => _listaNumeros.Contains(5);


        private static void ExibirDados()
        {
            PopularListaValoresInput();

            //A) Quantos números foram digitados.
            Console.WriteLine($"Quantidade de números digitados: {RetornarQuantidadeValoresNaLista()}.");

            //B) A lista de valores, ordenada de forma decrescente.
            Console.Write($"\nLista de valores, ordenada de forma decrescente: {string.Join(", ", _listaNumeros.OrderByDescending(v=>v))}.\n");

            //C) Se o valor 5 foi digitado e está ou não na lista.
            Console.WriteLine($"\nO valor 5 {(ValorCincoEhDigitado() ? "foi digitado." : "não foi digitado.")}\n\n");
        }        
    }
}
