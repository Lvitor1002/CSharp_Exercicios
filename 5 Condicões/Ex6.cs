

/*
    Escreva um programa que pergunte o salário de um funcionário e calcule o valor do seu aumento. 
    Para salários superiores a R$1250,00, calcule um aumento de 10%. Para os inferiores ou iguais, o aumento é de 15%.
*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static decimal RetornarSalario()
        {
            while (true)
            {
                Console.Write("Entre com o salário: ");
                string entrada = Console.ReadLine().Trim();
                if (!decimal.TryParse(entrada, out decimal salario) || salario <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                    continue;
                }
                return salario;
            }
        }

        private static string RetornarDadosSalarioReajustado(decimal salario)
            => salario > 1250 ? $"Salário reajustado com 10% de aumento: {salario * 1.1m:C2}" 
                            : $"Salário reajustado com 15% de aumento: {salario * 1.15m:C2}";

        private static void ExibirDados()
        {
            var salario = RetornarSalario();

            Console.Clear();
            Console.WriteLine($"Salário original: {salario:C2}\n{RetornarDadosSalarioReajustado(salario)}\n");
        }
    }
}
