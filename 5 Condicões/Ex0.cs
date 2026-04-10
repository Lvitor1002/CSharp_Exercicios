
/*
    Escreva um programa que faça o computador "pensar" em um número inteiro entre 0 e 5
    e peça para o usuário tentar descobrir qual foi o número escolhido pelo computador. 
    O programa deverá escrever na tela se o usuário venceu ou perdeu.
*/


using System;

namespace Fundamentos
{
    public class Program
    {
        private static Random _computadorPensando = new Random();

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarNumeroDeTentativaUsuario()
        {
            while (true)
            {
                Console.Write($"Tente adivinhar digitando qual número o computador pensou: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int escolhaUsuario))
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida.");
                    continue;
                }
                return escolhaUsuario;
            }
        }

       

        private static void ExibirDados()
        {
            int numeroPensadoComputador = _computadorPensando.Next(0, 6);
            var numeroEscolhaUsuario = RetornarNumeroDeTentativaUsuario();

            Console.Clear();

            Console.WriteLine(numeroEscolhaUsuario == numeroPensadoComputador 
                    ? $"Parabéns! Você acertou o número que o computador pensou.\nSeu número: {numeroEscolhaUsuario}\nNúmero do Computador: {numeroPensadoComputador}"
                    : $"Que pena! Você errou.\nSeu número: {numeroEscolhaUsuario}\nNúmero do Computador: {numeroPensadoComputador}");
        }
    }
}
