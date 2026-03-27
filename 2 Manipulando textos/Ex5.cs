
/*
    Faça um programa que leia o nome completo de uma pessoa, 
    mostrando em seguida o primeiro e o último nome separadamente.
*/

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
                if (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return nome;
        }

        private static void ExibirDados()
        {
            var nomes = RetornarNomeInput().Split(' ');

            Console.Clear();
            Console.WriteLine($"Primeiro Nome: {nomes.First()}\nÚltimo Nome: {nomes.Last()}");
        }    
    }
}
