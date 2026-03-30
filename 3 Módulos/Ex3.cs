

/* 
Um professor quer sortear um dos seus quatro alunos para apagar o quadro. 
Faça um programa que ajude ele, lendo o nome dos alunos e escrevendo na tela o nome do escolhido.
*/

using System;
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

        private static string SortearAlunos(string[] alunos)
            =>alunos[_sortearIndiceAluno.Next(0, alunos.Length)];
            

        private static void ExibirDados()
        {
            var alunos = RetornarAlunos();
            Console.Clear();
            Console.WriteLine($"4 alunos foram cadastrados: {string.Join(", ",alunos)}.\n\nAluno sorteado foi: {SortearAlunos(alunos)}");

        }    
    }
}
