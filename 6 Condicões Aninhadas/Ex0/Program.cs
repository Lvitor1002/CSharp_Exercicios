

/*
    Escreva um programa para aprovar o empréstimo bancário para a compra de uma casa. 
    Pergunte o valor da casa, o salário do comprador e em quantos anos ele vai pagar. 
    A prestação mensal não pode exceder 30% do salário ou então o empréstimo será negado.
*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static Emprestimo _emprestimo;

        private static void Main(string[] args)
            => ExibirDados();

        private static void PopularEmprestimo()
        {
            decimal valorCasa, salarioComprador; 
            int anosPagamento;

            while (true)
            {
                Console.Write($"Entre com o valor da casa: ");
                string entrada = Console.ReadLine().Trim();
                if (!decimal.TryParse(entrada, out valorCasa) || valorCasa <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write($"Entre com o salario do comprador: ");
                string entrada = Console.ReadLine().Trim();
                if (!decimal.TryParse(entrada, out salarioComprador) || salarioComprador <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write($"Quantos anos deseja parcelar: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out anosPagamento) || anosPagamento <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um número inteiro maior que zero.");
                    continue;
                }
                break;
            }
            _emprestimo = new Emprestimo(valorCasa, salarioComprador, anosPagamento);
        }

        private static void ExibirDados()
        {
            PopularEmprestimo();

            Console.Clear();
            Console.WriteLine(_emprestimo);
        }
    }
}
