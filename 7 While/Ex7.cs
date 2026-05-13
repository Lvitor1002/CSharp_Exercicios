

/*
    Contagem de quantidade Par e ímpar usando while. '999' para finalizar.:
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

        private static List<int> RetornarListaNumeros()
        {
            var listaValores = new List<int>();

            while (true)
            {
                Console.Clear();
                Console.Write("Entre com um valor:\nPara finalizar digite '999'\n- ");
                string entrada = Console.ReadLine().Trim();
                if(!int .TryParse(entrada, out int numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Digite um número inteiro válido e maior ou igual à zero.");
                    continue;
                }
                if(numero == 999)
                    break;
                listaValores.Add(numero);
            }
            Console.Clear();
            return listaValores;
        }

        private static (int, int) RetornarQuantidadeParImpar(List<int> listaNumeros)
            => (listaNumeros.Where(x => x % 2 != 0).Count(), listaNumeros.Where(x => x % 2 == 0).Count());

        private static void ExibirDados()
        {
            var listaValores = RetornarListaNumeros();
            var (quantidadeImpar, quantidadePar) = RetornarQuantidadeParImpar(listaValores);

            Console.WriteLine($"Lista dos números: {string.Join(", ",listaValores)}.\n{quantidadeImpar} números ímpares adicionados\n{quantidadePar} números pares adicionados\n");
        }
    }
}
