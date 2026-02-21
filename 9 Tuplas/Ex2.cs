

/* 
Crie um programa que vai gerar cinco números aleatórios de 1 à 10 e colocar em uma tupla. 
Depois disso, mostre a listagem de números gerados e também indique o menor e o maior valor que estão na tupla, 
por fim, a tupla ordenada:.
*/

using System;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();



        static int[] GerarCincoNumeros()
        {
            int[] numeros = new int[5];
            Random gerar = new Random();
            for (int i = 0; i < 5; i++)
                numeros[i] = gerar.Next(1, 11); 
            return numeros;
        }

        private static void Exibir()
        {
            var numeros = GerarCincoNumeros();
            var ordenados = numeros.OrderBy(x => x);
            Console.Clear();
            Console.WriteLine($"Números gerados: {string.Join(", ", numeros)}\nMaior valor: {numeros.Max(x=>x)}\nMenor valor: {numeros.Min(x => x)}\nNúmeros ordenados: {string.Join(", ", ordenados)}\n");
        }
    }
}

