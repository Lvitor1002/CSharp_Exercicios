
/*
    Crie um programa que gerencie o aproveitamento de um jogador de futebol. 

    O programa vai ler o nome do jogador e quantas partidas ele jogou. 

    Depois vai ler a quantidade de gols feitos em cada partida. 

    No final, tudo isso será guardado em uma lista, incluindo o total de gols feitos durante o campeonato.

    Aprimore para que ele funcione com vários jogadores, 
    incluindo um sistema de visualização de detalhes do aproveitamento de cada jogador escolhido.
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Fundamentos
{
    public static class Program
    {
        private static Jogador _jogador;
        private static Partida _partida;

        private static void Main(string[] args)
            => ExibirDados();

        private static List<Jogador> RetornarListaInfoJogadores()
        {
            var listaJogadores = new List<Jogador>();

            string nome;
            int quantidadeJogadores, quantidadePartidas = 0;

            while (true)
            {
                Console.Write("Digite a quantidade de jogadores a ser cadastrados: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out quantidadeJogadores) || quantidadeJogadores <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro positivo.");
                    continue;
                }
                break;
            }

            for(int i = 0; i < quantidadeJogadores; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"Digite o nome do {i + 1}ª jogador: ");
                    nome = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, digite um nome válido.");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write($"Digite a quantidade de partidas jogadas por {nome}: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out quantidadePartidas) || quantidadePartidas < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro igual ou maior que zero, positivo.");
                        continue;
                    }
                    break;
                }

                _jogador = new Jogador(nome, quantidadePartidas);

                for (int p = 0; p < quantidadePartidas; p++)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.Write($"Digite a quantidade de gols feitos na {p + 1}ª Partida: ");
                        string entrada = Console.ReadLine().Trim();
                        if (!int.TryParse(entrada, out int gol) || gol < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro igual ou maior que zero, positivo.");
                            continue;
                        }
                        _partida = new Partida(gol);
                        break;
                    }
                    _jogador.AdicionarPartida(_partida);
                }
                listaJogadores.Add(_jogador);
            }

            Console.Clear();
            return listaJogadores;
        }

        private static void ProcessarEscolhaJogador(List<Jogador> listaJogadores)
        {
            int numeroEscolhido, soma = 1;

            while (true)
            {
                Console.Clear();
                soma = 1;

                foreach (var jogador in listaJogadores)
                    Console.WriteLine($"{soma++}ª Jogador Cadastrado{jogador.ToString()}");

                while (true)
                {
                    Console.Write("Escolha um jogador digitando o seu número(ª) correspondente, e assim vizualizar os seus dados: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out numeroEscolhido) || numeroEscolhido <= 0 || numeroEscolhido > listaJogadores.Count)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. Por favor, digite um número inteiro positivo válido de 1 à {listaJogadores.Count()}.");
                        continue;
                    }
                    break;
                }


                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{listaJogadores[numeroEscolhido - 1].ToString()}");

                    var opcoes = new List<string> { "s", "n" };
                    Console.Write($"Deseja escolher outro jogador? [s/n] - ");
                    string entrada = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(entrada) || !opcoes.Contains(entrada))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, apenas 's' ou 'n'.");
                        continue;
                    }
                    if (entrada == "n")
                    {
                        Console.Clear();
                        Console.WriteLine("Programa finalizado.");
                        return;
                    }
                    break;
                }
            }
        }

        private static void ExibirDados()
            =>ProcessarEscolhaJogador(RetornarListaInfoJogadores());
    }

    public class Jogador
    {
        public string Nome { get; set; }
        public int QuantidadePartidas { get; set; }
        public List<Partida> ListaPartidas { get; set; } = new List<Partida>();

        public Jogador(string nome, int quantidadePartidas)
        {
            Nome = nome;
            QuantidadePartidas = quantidadePartidas;
        }
        public void AdicionarPartida(Partida partida)
            => ListaPartidas.Add(partida);

        private int TotalGols()
            => ListaPartidas.Sum(p => p.Gols);
                
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int soma = 1;

            sb.Append($@"
Nome: {Nome}
Quantidade de Partidas: {QuantidadePartidas}
Total de Gols: {TotalGols()}

");
            foreach (var partida in ListaPartidas)
                sb.AppendLine($"\t\tGols na {soma++}ª Partida: {partida.Gols.ToString()}");

            sb.AppendLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            return sb.ToString();
        }
    }
    public class Partida
    {
        public int Gols { get; set; }

        public Partida(int gols)
            => Gols = gols;

        public override string ToString()
            => $"{Gols}";
    }
}
