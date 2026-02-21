


/* 
Crie um programa que tenha uma tupla com várias palavras (não usar acentos). 
Depois disso, você deve mostrar, para cada palavra, quais são as suas vogais.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
       
        private static void Exibir()
        {
            string[] palavras = {"pastel", "sabonete", "panela", "piada", "pernambuco",
                            "cachorro", "tabuada", "paraguai", "esquecido"};

            char[] vogais = { 'a', 'e', 'i', 'o', 'u' };

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"Palavras   | Vogais");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
            foreach (var palavra in palavras)
            {
                var vogais_palavra = palavra.Where(x => vogais.Contains(x))
                    .Distinct()
                    .OrderBy(x => x)
                    .ToArray();

                Console.WriteLine($"{palavra,-10} | {string.Join(", ", vogais_palavra)}");
            }
            Console.WriteLine("-=-=");
        }
    }
}

