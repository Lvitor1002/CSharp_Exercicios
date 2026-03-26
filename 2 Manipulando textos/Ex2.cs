


//Crie um programa que leia o nome de uma cidade diga se ela começa ou não com o nome "SANTO".

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {


        private static void Main(string[] args)
            => ExibirDados();

        private static string RetornarNomeInput()
        {
            string nome;
            while (true)
            {
                Console.Write($"Entre com um nome: ");
                nome = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return nome;
        }

        private static void ValidarNome(string nome)
        {
            Console.Clear();
            if (nome.Split(' ')[0].Contains("SANTO"))
                Console.WriteLine($"Nome '{nome}' contém 'SANTO'");
            else
                Console.WriteLine($"Nome '{nome}' não contém 'SANTO'");
        }

        private static void ExibirDados()
            => ValidarNome(RetornarNomeInput());

    }
}
