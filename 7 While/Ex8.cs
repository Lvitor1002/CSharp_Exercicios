

/*
Escreva um código que continuará gerando números aleatórios entre 1 e 10 até gerarmos o número 7. 
Pode levar apenas uma iteração para obter um 7, ou pode levar dezenas de iterações.
*/


using System;

namespace Fundamentos
{
    public class Program
    {
        private static Random _gerarNumeroAleatorio = new Random();

        private static void Main(string[] args)
            => ExibirDados();


        private static string RetornarResultadoGerador()
        {
            int vezes = 0;

            do
                vezes++;
            while (_gerarNumeroAleatorio.Next(1, 11) != 7);

            return $"O número 7 foi gerado após {vezes} tentativas.";
        }


        private static void ExibirDados()
            =>Console.WriteLine(RetornarResultadoGerador());
    }
}
