

/*
    Faça um programa que leia um ano qualquer e mostre se ele é bissexto.
*/

using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarAno()
        {
            while (true)
            {
                Console.Write($"Entre com um ano para saber se ele é bissexto: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int ano) || ano <= 1900 || ano > DateTime.Now.Year)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um valor inteiro e menor ou igual há {DateTime.Now.Year}.");
                    continue;
                }
                return ano;
            }
        }

        private static bool AnoEhBissexto(int ano)
            => (ano % 4 == 0 && ano % 100 != 0) || ano % 400 == 0 ? true : false;


        private static void ExibirDados()
        {
            int ano = RetornarAno();

            Console.Clear();
            Console.WriteLine(AnoEhBissexto(ano) ? $"Ano {ano} é bissexto\n" : $"Ano {ano} não é bissexto\n");
        }
    }
}
