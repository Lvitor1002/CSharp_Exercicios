
/*
    Faça um programa que ajude um jogador da MEGA SENA a criar palpites.
    O programa vai perguntar quantos jogos serão gerados e vai sortear 6 números entre 1 e 60 para cada jogo, 
    cadastrando tudo em uma lista composta.
*/


using System;
using System.Collections.Generic;

namespace Fundamentos
{
    public static class Program
    {
        private static readonly Random sorteioNumeros = new Random();

        private static void Main(string[] args)
            => ExibirDados();


        private static List<HashSet<int>> RetornarListaPalpites()
        {
            int quantidadeJogos = 0;
            var listaSorteios = new List<HashSet<int>>(); /*Evita a necessidade de verificar manualmente se um número já está presente na coleção antes de adicioná - lo. */


            while (true)
            {
                Console.Write("Quantos jogos você quer gerar? ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out quantidadeJogos) || quantidadeJogos <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro positivo.");
                    continue;
                }
                break;
            }

            for(int i = 0; i < quantidadeJogos; i++)
            {
                HashSet<int> numeros = new HashSet<int>();

                while(numeros.Count < 6) 
                    numeros.Add(sorteioNumeros.Next(1, 61));

                listaSorteios.Add(numeros);
            }

            Console.Clear();
            return listaSorteios;
        }

      

        private static void ExibirDados()
        {
            var listaSorteios = RetornarListaPalpites();
            int soma = 1;

            foreach(var jogo in listaSorteios)
                Console.WriteLine($"{soma++}ª Jogo: {string.Join(", ", jogo)}.");
        }
    }
}
