


/*
Crie um programa onde o usuário digite uma expressão qualquer que use parênteses. 
Seu aplicativo deverá analisar se a expressão passada está com os parênteses abertos e 
fechados na ordem e quantidade correta.
*/


using System;

namespace Fundamentos
{
    public static class Program
    {

        private static void Main(string[] args)
            => ExibirDados();


        private static string RetornarExpressaoInput()
        {
            Console.Write($"Digite uma expressão entre parênteses: ");
            while (true)
            {
                string expressao = Console.ReadLine().Trim().ToLower();
              

                if (string.IsNullOrWhiteSpace(expressao))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. É necessário digitar a expressão.");
                    continue;
                }
                if(!ValidarExpressao(expressao))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. A expressão deve começar com '(' e terminar com ')'.");
                    continue;
                }
                Console.Clear();
                return expressao;
            }
        }

        private static bool ValidarExpressao(string expressao)
        {
            int contadorParenteses = 0;
            
            foreach (char caractere in expressao)
            {
                if (caractere == '(')
                    contadorParenteses++;

                else if (caractere == ')')
                    contadorParenteses--;

                if (contadorParenteses < 0)
                    return false; // fechamento sem abertura
            }
            return contadorParenteses == 0;
        }

        private static void ExibirDados()
            =>Console.WriteLine(RetornarExpressaoInput());

    }
}
