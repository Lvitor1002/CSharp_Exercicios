

/*
Crie um programa que leia o ano de nascimento de sete pessoas. No final, 
mostre quantas pessoas ainda não atingiram a maioridade e quantas já são maiores.
*/


using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarArrayIdades()
        {
            var idades = new int[7];

            for(int i = 0; i < idades.Length; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"Entre com o ano de nascimento da {i+1}ª Pessoa: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out int ano) || ano < 1900 || ano > DateTime.Today.Year)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. Digite um ano válido entre 1900 e {DateTime.Today.Year}");
                        continue;
                    }
                    int idade = DateTime.Today.Year - ano;
                    idades[i] += idade;
                    break;
                }
            }
            return idades;
        }

        private static void ExibirDados()
        {
            var idades = RetornarArrayIdades();

            int quantidadeIdadesMaioresDezoito = idades.Where(idade => idade > 18).Count();
            int quantidadeIdadesMenoresDezoito = idades.Where(idade => idade < 18).Count();

            Console.Clear();
            Console.WriteLine($"{quantidadeIdadesMenoresDezoito} Pessoas não atingiram a maioridade.\n{quantidadeIdadesMaioresDezoito} Pessoas são maiores de idade.\n");
        }
    }
}
