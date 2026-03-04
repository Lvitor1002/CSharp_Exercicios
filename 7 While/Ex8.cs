

/*
Escreva um código que continuará gerando números aleatórios entre 1 e 10 até gerarmos o número 7. 
Pode levar apenas uma iteração para obter um 7, ou pode levar dezenas de iterações.
 */
using System;


namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            => GerarNumeros();

        private static void GerarNumeros()
        {
            var geradorNumeros = new Random();
            int tentativas = 0;

            do
                tentativas++;
            while (geradorNumeros.Next(1, 11) != 7);

            Console.WriteLine($"Numero 7 foi gerado depois de {tentativas} tentativas.");
        }
    }
}

