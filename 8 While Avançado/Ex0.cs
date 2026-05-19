

/*
Faça um programa que mostre a tabuada de vários números, um de cada vez, para cada valor digitado pelo usuário. 
O programa será interrompido quando a entrada for 'sair'. 
 */ 


using System;
using System.Linq;


namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static int? RetornarNumero()
        {
            while (true)
            {
                Console.Write("Entre com um valor para a tabuada:\nPara encerrar digite 'sair'.\n- ");
                string entrada = Console.ReadLine().Trim().ToLower();

                if(entrada == "sair")    
                    return null;
                
                if (!int .TryParse(entrada, out int numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Digite um número inteiro válido e maior ou igual à zero.");
                    continue;
                }
                Console.Clear();
                return numero;
            }
        }

        private static void ExibirTabuadaNumero()
        {
            while (true)
            {
                int? numero = RetornarNumero();

                if (!numero.HasValue)
                    break;

                Console.WriteLine($"Tabuada do {numero}:");
                for(int i = 0; i <= 10; i++)
                    Console.WriteLine($"{numero} x {i} = {numero * i}");
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("Encerrando o programa...");
        }

        private static void ExibirDados()
            => ExibirTabuadaNumero();
    }
}
