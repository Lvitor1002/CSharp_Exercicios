


/*
    Faça um programa que leia o ano de nascimento de um jovem 
    e informe, de acordo com a sua idade, se ele ainda vai se alistar ao serviço militar, 
    se é a hora exata de se alistar ou se já passou do tempo do alistamento. 

    Seu programa também deverá mostrar o tempo que falta ou que passou do prazo.
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

        private static string RetornarResultadoAlistamentoMilitar(int idade)
            => idade == 18 ? $"É hora exata de se alistar, você já está com {idade} anos.\n"
                : idade > 18 ? $"Você já passou do tempo de alistamento em {idade - 18} anos. Deveria ter se alistado no ano de {DateTime.Now.Year - (idade - 18)}.\n"
                : $"Ainda faltam {18 - idade} anos para se alistar. Alistamento será no ano de {DateTime.Now.Year + (18 - idade)}.\n"; 

        private static void ExibirDados()
            => Console.WriteLine(RetornarResultadoAlistamentoMilitar(RetornarIdade()));
    }
}
