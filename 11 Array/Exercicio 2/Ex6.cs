

/*
Crie um programa que leia vários números inteiros pelo teclado. 
No final da execução, mostre a média entre todos os valores e qual foi o maior e o menor valores lidos. 
O programa deve perguntar ao usuário se ele quer ou não continuar a digitar valores.
 */


using System;




namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Leitura();
        }
        public static void Leitura()
        {
            int numero = 0, qtd = 0;
            double soma = 0, media = 0;

            int maiorValor = int.MinValue;
            int menorValor = int.MaxValue;


            while (true)
            {
                Console.Clear();
                Console.Write("Digite alguns números inteiros abaixo: ");
                string n = Console.ReadLine().Trim();
                if(!int.TryParse(n, out numero) || numero < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }

                qtd += 1;
                soma += numero;

                maiorValor = Math.Max(maiorValor, numero);
                menorValor = Math.Min(menorValor, numero);

               
                Console.Write("Deseja continuar? [S/N] ");
                while (true)
                {
                    string op = Console.ReadLine().Trim().ToLower();
                    if (op == "s")
                    {
                        Console.WriteLine("Continue..");
                        break; 
                    }
                    else if (op == "n")
                    {
                        
                        media = soma / qtd;

                        Console.Clear();
                        Console.WriteLine($"Quantidade de números: {qtd}\n" +
                            $"Maior número: {maiorValor}\n" +
                            $"Menor número: {menorValor}\n" +
                            $"Media dos números: {media:F2}\n\n");
                        
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas 's' ou 'n'");
                    }
                }
            }
        }
    }
}

