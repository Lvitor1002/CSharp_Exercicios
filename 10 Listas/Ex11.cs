
/*
    Crie um programa que leia nome e duas notas de vários alunos e guarde tudo em uma lista composta. 
    No final, mostre um boletim contendo a média de cada um
    e permita que o usuário possa mostrar as notas de cada aluno individualmente.
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
        private static void Main(string[] args)
            => ExibirDados();

        private static List<Aluno> RetornarListaAlunos()
        {
            var listaAlunos = new List<Aluno>();
            

            int quantidadeAlunos;
            double nota;
            string nome;

            while (true)
            {
                Console.Write("Quantos alunos serão cadastrados? ");
                string entrada = Console.ReadLine().Trim();

                if(!int.TryParse(entrada, out quantidadeAlunos) || quantidadeAlunos <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro positivo.");
                    continue;
                }
                break;
            }

            for (int i = 0; i < quantidadeAlunos; i++)
            {
                Console.Clear();
                Console.WriteLine($"\t      {i + 1}ª Aluno\n");


                while (true)
                {
                    Console.Write("Nome: ");
                    nome = Console.ReadLine().Trim();

                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, insira um nome válido.");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }

                Nota[] notas = new Nota[2];

                for (int n = 0; n < notas.Length; n++)
                {
                    while (true)
                    {
                        Console.Write($"{n + 1}ª Nota: ");
                        string entrada = Console.ReadLine().Trim();

                        if (!double.TryParse(entrada, out nota) || nota <= 0 || nota > 10)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro ou real positivo de 1 à 10.");
                            continue;
                        }
                        notas[n] = new Nota(nota);
                        break;
                    }
                }
                listaAlunos.Add(new Aluno(nome, notas));
            }
            Console.Clear();
            return listaAlunos;
        }

        private static void ProcessarEscolhaAluno(List<Aluno> listaAlunos)
        {
            while (true)
            {
                Console.WriteLine("Lista de Alunos:");
                for (int i = 0; i < listaAlunos.Count(); i++)
                    Console.WriteLine($"{i + 1} - {listaAlunos[i].Nome}");


                Console.Write("\nEscolha um aluno para exibir os seus dados digitando a sua respectiva posição.\n(ou digite 'sair' para encerrar):\n- ");
                string entrada = Console.ReadLine().Trim().ToLower();
                if (entrada == "sair")
                    return;

                if (!int.TryParse(entrada, out int escolha) || escolha <= 0 || escolha > listaAlunos.Count())
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Por favor, insira um número inteiro positivo de 1 à {listaAlunos.Count()} correspondente a um aluno ou digite 'sair' para encerrar.\n\n");
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"{listaAlunos[escolha - 1]}");
            }
        }
        private static void ExibirDados()
            => ProcessarEscolhaAluno(RetornarListaAlunos());
    }

    public class Aluno
    {
        public string Nome { get; set; }
        public Nota[] Notas { get; set; } = new Nota[2];

        public Aluno(string nome, Nota[] notas)
        {
            Nome = nome;
            Notas = notas;
        }

        private double RetornarMedia()
            => Notas.Average(n => n.ValorNota);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int soma = 1;

            sb.Append($@"Nome: {Nome}
");
            foreach (var nota in Notas)
                sb.AppendLine($"{soma++}ª Nota: {nota.ValorNota}");

            sb.AppendLine($"Média: {RetornarMedia():F2}");
            sb.AppendLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            return sb.ToString();
        }
    }
    public class Nota
    {
        public double ValorNota { get; set; }

        public Nota(double nota)
            => ValorNota = nota;

        public string ToString()
            => $"{ValorNota}";
    }

}
