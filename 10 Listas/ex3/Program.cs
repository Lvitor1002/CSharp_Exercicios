
/*
Crie um programa que gerencie o aproveitamento de um jogador de futebol. 
O programa vai ler o nome do jogador e quantas partidas ele jogou. 
Depois vai ler a quantidade de gols feitos em cada partida. 
No final, tudo isso será guardado em uma lista, incluindo o total de gols feitos durante o campeonato.

Aprimore para que ele funcione com vários jogadores, 
incluindo um sistema de visualização de detalhes do aproveitamento de cada jogador.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using treino.Entities;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();

        private static List<Jogador> LeituraDados()
        {
            string nome;
            int quantidadePartidas, quantidadeJogadores;
            var listaGols = new List<int>();
            var listaDadosJogador = new List<Jogador>();

           
            while (true)
            {
                Console.Write($"Quantos jogadores serão cadastrados? ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out quantidadeJogadores) || quantidadeJogadores <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo!");
                    continue;
                }
                break;
            }

            for(int j = 0; j < quantidadeJogadores; j++)
            {
                Console.Clear();
                Console.WriteLine($"{j+1}ª Jogador");
                while (true)
                {
                    Console.Write("Entre com o nome do jogador: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if(string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c==' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Nome inválido. Tente novamente.");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write($"Quantas partidas {nome} jogou? ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out quantidadePartidas)||quantidadePartidas <=0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo!");
                        continue;
                    }
                    break;
                }
                Jogador jogador = new Jogador(nome, quantidadePartidas);
                for (int p = 0; p < quantidadePartidas; p++)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.Write($"Quantos gols foram feitos na {p + 1}ª Partida? ");
                        string entrada = Console.ReadLine().Trim();
                        if (!int.TryParse(entrada, out int quantidadeGols) || quantidadeGols < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo!");
                            continue;
                        }
                        jogador.AdicionarGols(new Gol(quantidadeGols));
                        break;
                    }
                }
                listaDadosJogador.Add(jogador);
            }
            return listaDadosJogador;
        }

        private static void EscolherJogador(List<Jogador> listaDadosJogador)
        {
            int escolha;
            while (true)
            {
                Console.Write($"Escolha um jogador digitando a sua posição para um detalhamento individual: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out escolha) || escolha <= 0 || escolha > listaDadosJogador.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Escolha uma posição de 1ª à {listaDadosJogador.Count}ª!");
                    continue;
                }
                break;
            }
            DetalhamentoDadosJogador(listaDadosJogador, escolha-1);
        }

        private static void DetalhamentoDadosJogador(List<Jogador> listaDadosJogador, int escolha = -1)
        {
            if (escolha == -1) { 
                Console.WriteLine("----- Dados do Jogador -----\n");
                for (int i = 0; i < listaDadosJogador.Count; i++)
                {
                    Console.WriteLine($"{i +1}ª Jogador\nNome do jogador: {listaDadosJogador[i].NomeJogador}\nQuantidade de Partidas: {listaDadosJogador[i].QuantidadePartidas}\n");
                    Console.WriteLine($"{listaDadosJogador[i].ToString()}\n__________________________");
                }
                Console.WriteLine("----- Fim dos Dados -----\n\n");
                return;
            }
            Console.Clear();
            Console.WriteLine($"----- Dados do Jogador {escolha+1}ª-----\n");
            Console.WriteLine($"Nome do jogador: {listaDadosJogador[escolha].NomeJogador}\nQuantidade de Partidas: {listaDadosJogador[escolha].QuantidadePartidas}\n");
            Console.WriteLine($"{listaDadosJogador[escolha].ToString()}__________________________\n");
            
        }
        private static void Exibir()
        {
            var listaDadosJogador = LeituraDados();
            Console.Clear();
            DetalhamentoDadosJogador(listaDadosJogador);
            EscolherJogador(listaDadosJogador);
        }
    }
}

