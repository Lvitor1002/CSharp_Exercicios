


/*
    Crie um programa que vai ler vários números e colocar em uma lista. 
    Depois disso, crie duas listas extras que vão conter apenas os valores pares e os valores ímpares digitados, respectivamente. 
    Ao final, mostre o conteúdo das três listas geradas.
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


        private static void PopularListaNumerosInput()
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

        private static (List<int>,List<int>) RetornarListaNumerosParesImpares()
        {
            var numerosPares = new List<int>();
            var numerosImpares = new List<int>();

            foreach(var numero in _listaNumeros)
            {
                if(numero % 2 == 0)
                    numerosPares.Add(numero);
                else
                    numerosImpares.Add(numero);
            }
            return (numerosPares, numerosImpares);
        }


        private static void ExibirDados()
        {
            PopularListaNumerosInput();
            
            var (numerosPares, numerosImpares) = RetornarListaNumerosParesImpares();

            Console.WriteLine($"Números digitados: {string.Join(", ", _listaNumeros)}.");


            if(numerosImpares.Count() == 0)
            {
                Console.WriteLine("Não foram digitados números ímpares.");
                return;
            } 
            else
                Console.WriteLine($"Números ímpares digitados: {string.Join(", ", numerosImpares)}.");
            
            if (numerosPares.Count() == 0)
            {
                Console.WriteLine("Não foram digitados números pares.");
                return;
            }
            else
                Console.WriteLine($"Números pares digitados: {string.Join(", ", numerosPares)}.");
        }        
    }
}
