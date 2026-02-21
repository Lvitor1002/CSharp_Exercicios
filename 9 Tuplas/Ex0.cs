
/* 
Crie um programa que tenha uma tupla totalmente preenchida com uma contagem por extenso, de zero até vinte. 
Seu programa deverá ler um número pelo teclado (entre 0 e 20) e mostrá-lo por extenso.
*/

using System;

namespace TREINO
{
    class Program
    {
        static void Main() => VerificaTupla();

        private static void VerificaTupla()
        {
            string[] tupla = {"zero", "um", "dois", "três", "quatro",
            "cinco", "seis", "sete", "oito", "nove",
            "dez", "onze", "doze", "treze", "quatorze",
            "quinze", "dezesseis", "dezessete", "dezoito",
            "dezenove", "vinte"};
            int numero;
            while (true)
            {
                Console.Write("Digite um número entre 0 e 20: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numero) || numero < 0 || numero > 20){
                    Console.Clear();
                    Console.WriteLine("Número inválido. Tente novamente digitando um número de 0 à 20.");
                    continue;
                }
                break;
            }

            Console.WriteLine($"Número {numero} em extenso: {tupla[numero].ToUpper()}");
        }
    }
}

