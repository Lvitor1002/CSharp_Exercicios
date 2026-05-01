


/*
Melhore o jogo do DESAFIO 028 onde o computador vai "pensar" em um número entre 0 e 10. 
Só que agora o jogador vai tentar adivinhar até acertar, 
mostrando no final quantos palpites foram necessários para vencer.
*/


using System;

namespace Fundamentos
{
    public class Program
    {
        private static Random pensamentoComputador = new Random();
        private static int _quantidadePalpites = 0;

        private static void Main(string[] args)
            => AdivinharPensamentoComputador();

        private static int RetornarNumeroPensadoComputador()
            => pensamentoComputador.Next(0, 11);

        private static void AdivinharPensamentoComputador()
        {
            while (true)
            {
                int pensamentoComputador = RetornarNumeroPensadoComputador();

                Console.Write("Tente adivinhar qual número o computador escolheu de 0 à 10: ");
                string entrada = Console.ReadLine().Trim();

                if (!int.TryParse(entrada, out int escolhaUsuario))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite apenas números.");
                    continue;
                }

                if (escolhaUsuario < 0 || escolhaUsuario > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Digite um número entre 0 e 10.");
                    continue;
                }

                if (escolhaUsuario != pensamentoComputador)
                {
                    Console.Clear();
                    Console.WriteLine($"Você Errou!\nComputador pensou em: {pensamentoComputador}\nVocê escolheu: {escolhaUsuario}\n\nTente novamente..");
                    _quantidadePalpites++;
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Você Acertou!\nComputador pensou em: {pensamentoComputador}\nVocê escolheu: {escolhaUsuario}\n\nForam necessárias {_quantidadePalpites}x até o acerto.\n");
                return;
            }
        }
    }
}
