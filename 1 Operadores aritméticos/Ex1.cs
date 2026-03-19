
// Faça um programa que leia um número e mostre na tela o seu sucessor e seu antecessor.

using System;

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
                Console.Write("Entre com um número: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numero) || numero <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return numero;
        }

        private static int[] RetornarNumeros(int numero)
            => new int[] { numero - 1, numero + 1 };

        private static void ExibirDados()
        {
            int numero = RetornarNumeroInput();
            var numeros = RetornarNumeros(numero);

            Console.Clear();
            Console.WriteLine($@"
Sucessor do número {numero} é {numeros[1]}
Antecessor do número {numero} é {numeros[0]}
");
        }

    }
}
