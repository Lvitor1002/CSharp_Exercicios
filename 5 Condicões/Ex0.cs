

/*
 Escreva um programa que faça o computador "pensar" em um número inteiro entre 0 e 5
e peça para o usuário tentar descobrir qual foi o número escolhido pelo computador. 
O programa deverá escrever na tela se o usuário venceu ou perdeu.
 */
using System;

namespace TREINO
{
    class Program
    {
        static void Main() => LeituraUsuario();

        public static int PensarNumero()
        {
            Random pensar = new Random();
            return pensar.Next(0, 6); ;
        }
        
        public static void LeituraUsuario()
        {
            var numeroPensado = PensarNumero();
            while (true)
            {
                Console.Write($"Digite o número de 0 à 5 pensado pelo comptador: ");
                string numeroP = Console.ReadLine().Trim();
                if(!int.TryParse(numeroP, out int numeroEscolhido) || numeroEscolhido < 0 || numeroEscolhido > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' de 0 à 5.");
                    continue;
                }
                
                if(numeroEscolhido != numeroPensado)
                {
                    Console.Clear();
                    Console.WriteLine("Errou. Tente novamente.");
                    continue;
                }
                Console.Clear();
                Console.Write($"\n>Parabéns, você acertou!\n>Sua escolha: {numeroEscolhido}\n>Número sorteado: {numeroPensado}\n");
                break;
            }
        }
    }
}

