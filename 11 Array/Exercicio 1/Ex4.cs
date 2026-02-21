

/*
 O mesmo professor do desafio 019 quer sortear a ordem de apresentação de trabalhos dos alunos. 
Faça um programa que leia o nome dos quatro alunos e mostre a ordem sorteada.
*/

using System;
using System.Globalization;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Exibir();
        }
        public static string[] Leitura()
        {
            var alunos = new string[4];
            string nome;

            Console.WriteLine("Digite abaixo 4 nomes para os aluos:\n");
            for(int i = 0; i < alunos.Length; i++)
            {
                
                Console.Write($"{i + 1}ª Aluno\n\n");
                while (true)
                {
                    Console.Write("Nome: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c==' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um nome válido!");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                Console.Clear();
                alunos[i] = nome;
            }
            return alunos;
        }
        
        public static void EmbaralharAlunos (string[] alunos) 
        {
            Random sorteio = new Random();

            for (int i = alunos.Length - 1; i > 0; i--)
            {
                int x = sorteio.Next(i + 1);
                (alunos[i], alunos[x]) = (alunos[x],alunos[i]);
            }
        }
        public static void Exibir()
        {
            var alunos = Leitura();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========================================\n" +
                    "\t\tAlunos Cadastrados\n\n");
                foreach (var aluno in alunos)
                {
                    Console.WriteLine(aluno.ToString());
                }

                string[] alunosEmbaralhados = alunos.ToArray();
                EmbaralharAlunos(alunosEmbaralhados);

                Console.WriteLine("==========================================\n" +
                    "\t\tAlunos Sorteados\n\n");
                for (int i = 0; i < alunosEmbaralhados.Length; i++)
                {
                    Console.WriteLine($"{i + 1}ª - {alunosEmbaralhados[i]}");
                }

                Console.WriteLine("==========================================\n");
                while (true)
                {
                    Console.Write("\n>Deseja uma nova ordem do sorteio? [s/n]: ");
                    string op = Console.ReadLine().ToLower().Trim();
                    if (op == "s")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (op == "n")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite apenas 's' ou 'n'!\n");
                    }
                }
            }
        }
    }
}

