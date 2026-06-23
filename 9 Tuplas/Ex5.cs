

/* 
    Crie um programa que tenha uma tupla com várias palavras (não usar acentos). 
    Depois disso, você deve mostrar, para cada palavra, quais são as suas vogais.
*/


using System;
using System.Linq;



namespace Fundamentos
{
    public static class Program
    {
        private static readonly string[] _palavras = {"pastel", "sabonete", "panela", "piada", "pernambuco","cachorro", "tabuada", "paraguai", "esquecido"};
        private static readonly char[] _vogais = {'a', 'e', 'i', 'o', 'u'};

        private static void Main(string[] args)
            => ExibirDados();


        private static void ExibirDados()
        {
            foreach (var palavra in _palavras)
            {
                var vogaisPalavra = palavra.Where(x => _vogais.Contains(x)).Distinct().OrderBy(x => x).ToArray();

                Console.WriteLine($"{palavra.PadRight(10).ToUpper()} |{string.Join(", ", vogaisPalavra).PadRight(12).ToUpper()}|");
            }
        }
    }
}
