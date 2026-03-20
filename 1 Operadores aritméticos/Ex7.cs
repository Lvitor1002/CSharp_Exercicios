
//# Faça um algoritmo que leia o salário de uma pessoa e mostre seu novo salário com 15% de aumento.



using System;

namespace Fundamentos
{
    public class Program
    {
        private const decimal _aumento = 1.15m;

        private static void Main(string[] args)
            => ExibirDados();

        private static decimal RetornarNumeroInput()
        {
            decimal valorSalario;
            while (true)
            {
                Console.Write($"Entre com o valor do salário: ");
                string entrada = Console.ReadLine().Trim();
                if(!decimal.TryParse(entrada, out valorSalario) || valorSalario <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return valorSalario;
        }

        private static decimal RetornarSalarioComReajustePositivo(decimal valorSalario)
            => valorSalario * _aumento;

        private static void ExibirDados()
        {
           
            decimal valorSalario = RetornarNumeroInput();

            Console.Clear();
            Console.WriteLine($"Salário de {valorSalario:C2} com 15% de aumento: {RetornarSalarioComReajustePositivo(valorSalario):C2}");
        }
    }
}
