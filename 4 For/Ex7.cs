

/*
Crie um programa que leia uma frase qualquer e diga se ela é um palíndromo, desconsiderando os espaços.
Exemplos de palíndromos: 
                        APOS A SOPA, 
                        A SACADA DA CASA, 
                        A TORRE DA DERROTA, 
                        O LOBO AMA O BOLO, 
                        ANOTARAM A DATA DA MARATONA.
*/


using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static string RetornarFraseInput()
        {
            string frase;
            while (true)
            {
                Console.Write("Entre com um número: ");
                frase = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(frase) || frase.Any(char.IsDigit))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite uma frase válida.");
                    continue;
                }
                break;
            }
            return frase;
        }
        private static bool FraseEhPalindromo(string frase)
        {
            string fraseSemEspacos = frase.Replace(" ", "");
            return fraseSemEspacos.Equals(new string(fraseSemEspacos.Reverse().ToArray()));
        }

        private static void ExibirDados()
        {
            string frase = RetornarFraseInput();

            Console.Clear();
            Console.WriteLine(FraseEhPalindromo(frase) ? $"Frase '{frase}' é palíndromo" : $"Frase '{frase}' não é palíndromo");
        }
    }
}
