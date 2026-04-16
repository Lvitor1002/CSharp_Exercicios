

/*
A Confederação Nacional de Natação precisa de um programa que leia o ano de nascimento de um atleta e mostre sua categoria, 
de acordo com a idade:
                    - Até 9 anos: MIRIM
                    - Até 14 anos: INFANTIL
                    - Até 19 anos: JÚNIOR
                    - Até 25 anos: SÊNIOR
                    - Acima de 25 anos: MASTER
*/

using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarIdade()
        {
            int anoNascimento;
            while (true)
            {
                Console.Write($"Entre com o ano de seu nascimento: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out anoNascimento) || anoNascimento < 1900 || anoNascimento > DateTime.Now.Year)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um ano maior que 1900 e menor que {DateTime.Now.Year}");
                    continue;
                }
                break;
            }
            Console.Clear();
            return DateTime.Now.Year - anoNascimento;
        }

        private static string RetornarCategoriaBaseadaIdade(int idade)
            => idade <= 9 ? $"{idade} anos: 'MIRIM'."
            : idade <= 14 ? $"{idade} anos: 'INFANTIL'."
            : idade <= 19 ? $"{idade} anos: 'JÚNIOR'."
            : idade <= 25 ? $"{idade} anos: 'SÊNIOR'."
            : $"{idade} anos: 'MASTER'.";

        private static void ExibirDados()
            => Console.WriteLine(RetornarCategoriaBaseadaIdade(RetornarIdade()));
    }
}
