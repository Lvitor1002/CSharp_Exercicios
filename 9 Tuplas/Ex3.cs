


/* 
Desenvolva um programa que leia quatro valores pelo teclado e guarde-os em uma tupla. No final, mostre:

A) Quantas vezes apareceu o valor 9.
B) Em que posição foi digitado o primeiro valor 3.
C) Quais foram os números pares.
d) Tupla Ordenada
*/

using System;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();

        private static int[] LeituraDados()
        {
            var tupla = new int[4];
            Console.WriteLine("Digite 4 valores: ");
            for (int i = 0; i < tupla.Length; i++)
            {
                while (true)
                {
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out int numero) || numero < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número inteiro e positivo.");
                        continue;
                    }
                    tupla[i] = numero;
                    break;
                }
            }
            return tupla;
        }
        private static void Exibir()
        {
            var tupla = LeituraDados();
            Console.Clear();
            int quantidadeVezesNove = tupla.Count(x => x.Equals(9));
            int posicaoValorTres = Array.IndexOf(tupla, 3) + 1;
            var numerosPares = tupla.Where(x => x % 2 == 0);
            Console.WriteLine(quantidadeVezesNove > 0 ? $"Valor 9 apareceu {quantidadeVezesNove} veze(s)." : "Valor 9 não foi inserido");
            Console.WriteLine(posicaoValorTres > 0 ? $"Posição do valor 3: {posicaoValorTres}ª" : "Valor 3 não foi inserido");
            Console.WriteLine(numerosPares.Count() > 0 ? $"Números pares: {string.Join(", ",numerosPares)}" : "Não há valores pares!");
            Console.WriteLine($"Valores Ordenados: {string.Join(", ", tupla.OrderBy(x => x))}");
        }
    }
}

