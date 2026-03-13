

/*
Desafio de mini-jogo de dados

O jogo deve selecionar um número alvo que seja um número aleatório entre um e cinco (inclusive). 
O jogador deve lançar um dado de seis lados. 

Para ganhar, o jogador deve jogar o dado com um número maior do que o número alvo. 
No final de cada rodada, deve ser perguntado para o jogador se gostaria de jogar novamente, 
e o jogo deve continuar ou terminar de acordo.


*/

using System;

namespace Fundamentos
{
    public class Program
    {
        private static Random sorteio = new Random();

        private static void Main(string[] args)
            => Exbir();

        private static int RetornarNumeroAlvo()
            => sorteio.Next(1,6);

        private static int RetornarNumeroDado()
            => sorteio.Next(1,7);

        private static void Exbir()
        {
            while (true)
            {
                Console.Clear();
                var numeroAlvoAleatorio = RetornarNumeroAlvo();
                var numeroDado = RetornarNumeroDado();
                string entrada;

                Console.WriteLine($"Número alvo: {numeroAlvoAleatorio}");
                Console.WriteLine($"Número dado: {numeroDado}");

                if (numeroDado == numeroAlvoAleatorio)
                    Console.WriteLine("Empate de valores");
                else if(numeroDado > numeroAlvoAleatorio)
                    Console.WriteLine("Jogador ganhou");
                else
                    Console.WriteLine("Jogador Perdeu");

                while (true)
                {
                    Console.Write("\nDeseja continuar? [S/N]: ");
                    entrada = Console.ReadLine().ToLower().Trim();
                    if(string.IsNullOrWhiteSpace(entrada) || entrada != "s" && entrada != "n")
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas 's' ou 'n'");
                        continue;
                    }
                    break;
                }

                if (entrada.StartsWith("s"))
                    continue;
                else
                    return;
            }
        }
    }
}
