

/*
Faça um programa que leia o sexo de uma pessoa, mas só aceite os valores 'M' ou 'F'. 
Caso esteja errado, peça a digitação novamente até ter um valor correto.
*/


using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();
        
        private static string RetornarSexoPessoa()
        {
            while (true)
            {
                var sexosValidos = new string[] { "M", "F" };

                Console.Write("Digite o sexo da pessoa (M/F):");
                string sexo = Console.ReadLine().ToUpper();
                if(string.IsNullOrWhiteSpace(sexo) || !sexosValidos.Contains(sexo))
                {
                    Console.Clear();
                    Console.WriteLine("Sexo inválido, digite novamente. Tente apenas 'M' ou 'F'.");
                    continue;
                }
                Console.Clear();
                return sexo;
            }
        }

        private static void ExibirDados()
            => Console.WriteLine($"Sexo digitado: {RetornarSexoPessoa()}");
    }
}
