

/*
 Code challenge - implemente as regras do desafio FizzBuzz

Aqui estão as regras do FizzBuzz que você precisa implementar em seu projeto de código:
            Valores de saída de 1 a 100, um número por linha, dentro do bloco de código de uma instrução de iteração.
            Quando o valor atual for divisível por 3, imprima o termo Fizz junto ao número.
            Quando o valor atual for divisível por 5, imprima o termo Buzz junto ao número.
            Quando o valor atual for divisível por 3 e 5, imprima o termo FizzBuzz junto ao número.

O código deverá produzir o seguinte resultado de 1 a 100:
1
2
3 - Fizz
4
5 - Buzz
6 - Fizz
7
8
9 - Fizz
10 - Buzz
11
12 - Fizz
13
14
15 - FizzBuzz
.
.
.
Até 100 - Buzz
 */
using System;


namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            => FizzBuzz();

        private static void FizzBuzz()
        {
            for(int i = 1; i <= 100; i++)
            {
                //Sempre da condição mais específica para a mais geral.
                //A condição mais específica é aquela que cobre menos casos.
                //A condição mais geral é aquela que cobre mais casos.
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine($"{i} - FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine($"{i} - Fizz");
                else if(i % 5 == 0)
                    Console.WriteLine($"{i} - Buzz");
                else 
                    Console.WriteLine(i);

            }
        }
    }
}

