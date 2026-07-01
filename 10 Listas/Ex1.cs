

/*
Crie um programa onde o usuário possa digitar vários valores numéricos e cadastre-os em uma lista. 
Caso o número já exista lá dentro, ele não será adicionado. 
No final, serão exibidos todos os valores únicos digitados, em ordem crescente. 
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


        private static List<int> RetornarListaValoresInput()
        {
            var listaNumeros = new List<int>();
            
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

                if(listaNumeros.Contains(valor))
                {
                    Console.WriteLine($"Valor {valor} já existe na lista. Digite outro número.");
                    continue;
                }
                listaNumeros.Add(valor);
            }
            Console.Clear();
            return listaNumeros;
        }

        private static void ExibirDados()
            => Console.Write($"\nValores únicos digitados em ordem crescente: {string.Join(", ", RetornarListaValoresInput().OrderBy(v=>v))}.\n\n");
        
    }
}
