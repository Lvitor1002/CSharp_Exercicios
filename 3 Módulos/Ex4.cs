

/*
O mesmo professor do desafio 019 quer sortear a ordem de apresentação de trabalhos dos alunos. 
Faça um programa que leia o nome dos quatro alunos e mostre a ordem sorteada.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static Random _sortearIndiceAluno = new Random();

        private static void Main(string[] args)
            => ExibirDados();

        private static string[] RetornarAlunos()
        {
            var arrayAlunos = new string[4];
            string nome;

            for(int i = 0; i < arrayAlunos.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Entre com o nome do {i+1}ª aluno: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida.");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    arrayAlunos[i] = nome;
                    break;
                }
            }
            return arrayAlunos;
        }

        // Método para embaralhar um arrayAlunos (algoritmo Fisher-Yates)
        private static void EmbaralharArrayAlunos(string[] arrayAlunos)
        {
            for (int i = arrayAlunos.Length - 1; i > 0; i--)
            {
                int indiceSorteado = _sortearIndiceAluno.Next(i + 1);

                string troca = arrayAlunos[i];

                arrayAlunos[i] = arrayAlunos[indiceSorteado];
                arrayAlunos[indiceSorteado] = troca;
            }
        }


        private static void ExibirDados()
        {
            var alunos = RetornarAlunos();

            Console.Clear();
            
            Console.WriteLine($"4 alunos foram cadastrados: {string.Join(", ", alunos)}.\n");
            
            EmbaralharArrayAlunos(alunos);

            for (int i = 0; i < alunos.Length; i++)
                Console.WriteLine($"{i + 1}º aluno: {alunos[i]}");

        }
    }
}
