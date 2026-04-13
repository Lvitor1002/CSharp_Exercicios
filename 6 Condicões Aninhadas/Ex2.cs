

/*
Escreva um programa que leia dois números inteiros e compare-os. 
mostrando na tela uma mensagem:
- O primeiro valor é maior
- O segundo valor é maior
- Não existe valor maior, os dois são iguais
*/

using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarArrayNumeros()
        {
            var numeros = new int[2];

            for(int i = 0; i < numeros.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Entre com o {i + 1}ª número inteiro: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out int numero) || numero < 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida.");
                        continue;
                    }
                    numeros[i] = numero;
                    break;
                }
            }
            Console.Clear();
            return numeros;
        }

        private static string RetornarStringStatusDeComparacaoNumeros(int[] numeros)
            => numeros[0] > numeros[1] ? $"O primerio valor {numeros[0]} é maior do que o segundo valor {numeros[1]}." : 
                numeros[0] < numeros[1] ? $"O segundo valor {numeros[1]} é maior do que o primeiro valor {numeros[0]}." :
                $"Não existe valor maior, os dois são iguais; {numeros[0]} e {numeros[1]}.";

        private static void ExibirDados()
            => Console.WriteLine(RetornarStringStatusDeComparacaoNumeros(RetornarArrayNumeros()));
    }
}
