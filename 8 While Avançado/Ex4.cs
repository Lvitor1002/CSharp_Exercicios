

/*
Crie um programa que simule o funcionamento de um caixa eletrônico. 
No início, pergunte ao usuário qual será o valor a ser sacado (número inteiro)
e o programa vai informar quantas cédulas de cada valor serão entregues.
OBS: considere que o caixa possui cédulas de R$50, R$20, R$10 e R$1.
*/


using System;


namespace Fundamentos
{
    public static class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroSaque()
        {
            while (true)
            {
                Console.Write($"Digite um valor de saque desejado: R$ ");
                string entradaPreco = Console.ReadLine().Trim().ToLower();
                if (!int.TryParse(entradaPreco, out int valorSaque) || valorSaque <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número inteiro, maior que zero!");
                    continue;
                }
                return valorSaque;
            }
        }

        private static (int, int, int, int) RetornarCedulasReferenteValorSaque(int valorSaque)
        {
            int valorRestante = valorSaque;

            int nota50 = 0, nota20 = 0, nota10 = 0, nota1 = 0;

            nota50 = valorRestante / 50;        //São necessárias tantas notas de 50 
            valorRestante %= 50;                //Atualiza o valor restante

            nota20 = valorRestante / 20;
            valorRestante %= 20;

            nota10 = valorRestante / 10;
            valorRestante %= 10;

            nota1 = valorRestante;

            return (nota50, nota20, nota10, nota1);
        }


        private static void ExibirDados()
        {
            int valorSaque = RetornarNumeroSaque();
            var (notas50, notas20, notas10, notas1) = RetornarCedulasReferenteValorSaque(valorSaque);

            Console.Clear();
            Console.WriteLine("\n=== Distribuição das Cédulas ===\n");
            if (notas50 > 0) Console.WriteLine($"{notas50} Notas de R$50");
            if (notas20 > 0) Console.WriteLine($"{notas20} Notas de R$20");
            if (notas10 > 0) Console.WriteLine($"{notas10} Notas de R$10");
            if (notas1 > 0) Console.WriteLine($"{notas1} Notas de R$1");

            Console.WriteLine($"\nTotal sacado: R${valorSaque}");
            Console.WriteLine("=================================");
        }
    }
}
