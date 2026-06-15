

/* 
Crie um programa que vai gerar cinco números aleatórios de 1 à 10 e colocar em uma tupla. 
Depois disso, mostre a listagem de números gerados e também indique o menor e o maior valor que estão na tupla, 
por fim, a tupla ordenada:.
*/


using System;
using System.Linq;



namespace Fundamentos
{
    public static class Program
    {
        private static Random sortearNumero = new Random();

        private static void Main(string[] args)
            => ExibirDados();

        private static int[] RetornarArrayCincoNumerosAleatorios()
            => Enumerable.Range(0, 5).Select(i => sortearNumero.Next(1, 11)).ToArray();

        private static void ExibirDados()
        {
            var numerosAleatorios = RetornarArrayCincoNumerosAleatorios();
            Console.WriteLine($"Números Gerados: {string.Join(", ", numerosAleatorios)}.");
            Console.WriteLine($"Maior número gerado: {numerosAleatorios.Max()}.\nMenor número gerado: {numerosAleatorios.Min()}.");
            Console.WriteLine($"Números Ordenados: {string.Join(", ", numerosAleatorios.OrderBy(n => n).ToArray())}.");
        }
    }
}
