

/* 
Crie um programa que tenha uma tupla totalmente preenchida com uma contagem por extenso, de zero até vinte. 
Seu programa deverá ler um número pelo teclado (entre 0 e 20) e mostrá-lo por extenso.
*/


using System;
using System.Globalization;



namespace Fundamentos
{
    public static class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroInput()
        {
            while (true)
            {
                Console.Write("Entre com um número de 0 à 20: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out int numero) || numero < 0 || numero > 20)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. O número deve ser inteiro de 0 à 20.\n");
                    continue;
                }
                Console.Clear();
                return numero;
            }
        }

        private static string RetornarNumeroPorExtenso(int numero)
        {
            string[] tupla = {"zero", "um", "dois", "três", "quatro",
                            "cinco", "seis", "sete", "oito", "nove",
                            "dez", "onze", "doze", "treze", "quatorze",
                            "quinze", "dezesseis", "dezessete", "dezoito",
                            "dezenove", "vinte"};
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tupla[numero].ToLower());
        }

        private static void ExibirDados()
        {
            int numero = RetornarNumeroInput();
            Console.WriteLine($"O número digitado foi '{numero}', sendo seu nome por extenso '{RetornarNumeroPorExtenso(numero)}'.\n");
        } 
    }
}
