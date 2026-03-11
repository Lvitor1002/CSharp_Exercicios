

/*
Desafio: 
        Escrever código para inverter cada palavra de uma mensagem
Mensagem: 
        string pangram = "The quick brown fox jumps over the lazy dog";

Escreva o código necessário para inverter as letras de cada palavra e apresentar o resultado.

Por outras palavras, não basta inverter cada letra na variável pangram. 
Em vez disso, você precisa inverter apenas as letras em cada palavra, 
mas imprimir a palavra invertida em sua posição original na mensagem.

Seu código deve produzir a seguinte saída:
                                        ehT kciuq nworb xof spmuj revo eht yzal god
*/

using System;
using System.Linq;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => ManipulandoCaracteres();

        private static void ManipulandoCaracteres()
        {
            string pangram = "The quick brown fox jumps over the lazy dog";

            var palavras = pangram.Split(' ');

            var arrayPalavrasInvertidas = new string[palavras.Length];

            for (int i = 0; i < palavras.Length; i++)
            {
                char[] palavra = palavras[i].ToCharArray(); //Transformando cada palavra em um char de array

                Array.Reverse(palavras); // Invertendo as palavras do char

                arrayPalavrasInvertidas[i] = new string(palavra);
            }
            Console.WriteLine(string.Join(" ", arrayPalavrasInvertidas));
        }
    }
}
