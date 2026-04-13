

/*
    Escreva um programa em c# que leia um número inteiro qualquer e peça para o usuário escolher qual será a base de conversão: 
    1 para binário, 2 para octal e 3 para hexadecimal.
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroInput()
        {
            int numero;

            while (true)
            {
                Console.Write($"Entre com um número inteiro: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida.");
                    continue;
                }
                return numero;
            }
        }

        private static string RetornarStringDeNumeroConvertidoBaseDesejada(int numero)
        {
            string entrada;
            var opcoesValidas = new[] { "binario", "octal", "hexadecimal" };

            while (true)
            {
                Console.Write($"Escolha uma base de conversão: Binario | Octal | Hexadecimal - ");
                entrada = Console.ReadLine().Trim().ToLower();
                if(string.IsNullOrWhiteSpace(entrada) || entrada.Any(c => char.IsDigit(c)) || !opcoesValidas.Contains(entrada))
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com uma das opções: Binario | Octal | Hexadecimal");
                    continue;
                }
                Console.Clear();
                return entrada == "binario" ? $"Número {numero} foi convertido para binário: {Convert.ToString(numero, 2)}" :
                    entrada == "octal" ? $"Número {numero} foi convertido para Octal: {Convert.ToString(numero, 8)}" : 
                    $"Número {numero} foi convertido para Hexadecimal: {Convert.ToString(numero, 16).ToUpper()}";
            }
        }
        private static void ExibirDados()
            => Console.WriteLine(RetornarStringDeNumeroConvertidoBaseDesejada(RetornarNumeroInput()));
    }
}
