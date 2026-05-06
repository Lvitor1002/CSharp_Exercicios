

/*
    Faça um programa que leia um número qualquer e mostre o seu fatorial.

    Ex: 5! = 5 x 4 x 3 x 2 x 1 = 120
*/


using System;
using System.Collections.Generic;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumero()
        {
            while (true)
            {
                Console.Write("Digite um número: ");
                string entrada = Console.ReadLine().Trim();
                if(!int .TryParse(entrada, out int numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Digite um número inteiro válido e maior que zero.");
                    continue;
                }
                Console.Clear();
                return numero;
            }
        }
        private static (int, List<int>) RetornarDadosFatorialNumero(int numeroFatorial)
        {
            int resultadoFatorial = 1;
            var listaSequenciaNumeros = new List<int>();

            for (int i = 1; i <= numeroFatorial; i++)
            {
                resultadoFatorial *= i;
                listaSequenciaNumeros.Add(i);
            }

            return (resultadoFatorial, listaSequenciaNumeros);
        }

        private static void ExibirDados()
        {
            int numeroFatorial = RetornarNumero();
            var (resultadoFatorial, listaSequenciaNumeros) = RetornarDadosFatorialNumero(numeroFatorial);

            listaSequenciaNumeros.Reverse();
            
            Console.WriteLine($"{numeroFatorial}! {string.Join(" x ", listaSequenciaNumeros)} = {resultadoFatorial}");
        }
    }
}
