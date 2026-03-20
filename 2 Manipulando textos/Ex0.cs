/*
Crie um programa que leia o letra completo de uma pessoa e mostre: 
- O letra com todas as letras maiúsculas e minúsculas.
- Quantas letras ao todo (sem considerar espaços).
- Quantas letras tem o primeiro letra.
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
                Console.Write($"Entre com o seu nome completo: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(nome) || !nome.Any(c=>char.IsLetter(c)))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return nome;
        }

        private static (string, string) RetornarNomeMaiusculoMinusculo(string nome)
            => (nome.ToUpper(), nome.ToLower());

        private static int RetornarQuantidadeLetrasNome(string nome)
            =>nome.Replace(" ", "").Count();

        private static int RetornarQuantidadeLetrasPrimeiroNome(string nomes)
            => nomes.Split(' ')[0].Count();

        private static void ExibirDados()
        {
           
            string nomeCompleto = RetornarNomeInput();
            var (nomeMai, nomeMin) = RetornarNomeMaiusculoMinusculo(nomeCompleto);

            Console.Clear();

            Console.WriteLine($"'{nomeCompleto}' com todas as letras maiúsculas: {nomeMai}\n\n'{nomeCompleto}' com todas as letras minúsculas: {nomeMin}\n");
            Console.WriteLine($"Quantidade total de letras para o nome '{nomeCompleto}': {RetornarQuantidadeLetrasNome(nomeCompleto)} letras\n");
            Console.WriteLine($"Quantidade total de letras para o 'primeiro' nome '{nomeCompleto}': {RetornarQuantidadeLetrasPrimeiroNome(nomeCompleto)} letras\n");
        }
    }
}
