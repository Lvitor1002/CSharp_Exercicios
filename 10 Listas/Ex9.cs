

/*
    Faça um programa que ajude um jogador da MEGA SENA a criar palpites.
    O programa vai perguntar quantos jogos serão gerados e vai sortear 6 números entre 1 e 60 para cada jogo, 
    cadastrando tudo em uma lista composta.
*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Exibir();
        }
        public static List<HashSet<int>> Leitura()
        {
            var jogos = new List<HashSet<int>>();

            /*Evita a necessidade de verificar manualmente se um número já está presente na coleção antes de adicioná - lo. */
            //Lista temporária contendo os números de 1 à 60 sem repetilos
            Random sorteio = new Random();

            int quantidade = 0;
            while (true)
            {
                Console.Write("Quantos jogos serão gerados? ");
                string qtd = Console.ReadLine().Trim();
                if(!int.TryParse(qtd, out quantidade) || quantidade <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }

            for (int i = 0; i < quantidade; i++)
            {
                HashSet<int> numeros = new HashSet<int>();

                while (numeros.Count < 6)
                {
                    numeros.Add(sorteio.Next(1,61));
                }
                jogos.Add(numeros);
            }
            return jogos;
        }
        public static void Exibir()
        {
            var jogos = Leitura();
            Console.Clear();

            Console.WriteLine($"-=-=-= Sorteio da Mega sena -=-=-=\n\n" +
                        $">Foram ao todo {jogos.Count} jogos: \n");
            for (int i = 0; i<jogos.Count;i++)
            {
                Console.WriteLine($"{i+1}ª Palpite: {string.Join(", ", jogos[i]),4}\n");
            }
        }
    }
}

