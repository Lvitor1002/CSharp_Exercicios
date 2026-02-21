
/*
Crie um programa que simule o funcionamento de um caixa eletrônico. 
No início, pergunte ao usuário qual será o valor a ser sacado (número inteiro)
e o programa vai informar quantas cédulas de cada valor serão entregues.
OBS: considere que o caixa possui cédulas de R$50, R$20, R$10 e R$1.
 */

using System;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();

        private static int LeituraValor()
        {
            int valorSaque = 0; 
            while (true){
                Console.Write("Digite o valor a ser sacado: R$ ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out valorSaque) || valorSaque <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Por favor, insira um número inteiro ou real positivo.");
                    continue;
                }
                return valorSaque;
            }
        }
        private static (int,int,int,int, int) SimuladorCaixaEletronico()
        {
            int valorSaque = LeituraValor();
            int valorRestante = valorSaque;
            int nota50 = 0, nota20 = 0, nota10 = 0, nota1 = 0;
            
            nota50 = valorRestante / 50;           //São necessárias tantas notas de 50 
            valorRestante = valorRestante % 50;    //Atualiza o valor restante

            nota20 = valorRestante / 20;           //São necessárias tantas notas de 20
            valorRestante = valorRestante % 20;    //Atualiza o valor restante

            nota10 = valorRestante / 10;           //São necessárias tantas notas de 10
            valorRestante = valorRestante % 10;    //Atualiza o valor restante

            nota1 = valorRestante;  

            return (nota50, nota20, nota10, nota1, valorSaque);
        }
        private static void Exibir()
        {
            var (notas50, notas20, notas10, notas1, valorSaque) = SimuladorCaixaEletronico();
            Console.Clear();
            Console.WriteLine("\n=== Distribuição das Cédulas ===\n");
            if (notas50 > 0) Console.WriteLine($"Notas de R$50: {notas50}");
            if (notas20 > 0) Console.WriteLine($"Notas de R$20: {notas20}");
            if (notas10 > 0) Console.WriteLine($"Notas de R$10: {notas10}");
            if (notas1 > 0) Console.WriteLine($"Notas de R$1 : {notas1}");

            Console.WriteLine($"\nTotal sacado: R${valorSaque}");
            Console.WriteLine("=================================");
        }
    }
}

