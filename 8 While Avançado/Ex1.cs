

/*
Faça um programa que jogue par ou ímpar com o computador. 
O jogo só será interrompido quando o jogador não quiser mais continuar, 
mostrando o total de vitórias consecutivas que ele conquistou no final do jogo. 

O jogo deve determinar o vencedor com base na soma dos números (se é par ou ímpar), 
não na comparação direta entre as escolhas de "par" ou "impar"
 
 */

using System;

namespace TREINO
{
    class Program
    {
        static void Main() => ParOuImpar();

       
        private static int retornarNumeroEscolhidoUsuario()
        {
            int numeroEscolhidoUsuario = 0;
            while (true)
            {
                Console.Write("Digite um número de 0 à 5: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numeroEscolhidoUsuario) || numeroEscolhidoUsuario < 0 || numeroEscolhidoUsuario > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' de 0 à 5");
                    continue;
                }
                break;
            }
            return numeroEscolhidoUsuario;
        }

        private static int SorteiaNumeroPc()
        {
            Random sorteioNumero = new Random();
            return sorteioNumero.Next(0,6);
        }
        private static void ParOuImpar()
        {
            int tentativas = 0;
            while (true)
            {
                var numeroSorteadoPc = SorteiaNumeroPc();
                var numeroEscolhidoUsuario = retornarNumeroEscolhidoUsuario();
                string escolhaParImparUsuario;
                Console.WriteLine("\n-=-=-=-=-= Jogo - Ímpar | Par -=-=-=-=-=\n");
                Console.Write("Par ou Impar? ");
                escolhaParImparUsuario = Console.ReadLine().Trim().ToLower();
                if(escolhaParImparUsuario == "sair")
                {
                    Console.Clear();
                    Console.WriteLine("Jogo encerrado pelo usuário.");
                    return;
                }
                if (string.IsNullOrEmpty(escolhaParImparUsuario) || (escolhaParImparUsuario != "par" && escolhaParImparUsuario != "impar"))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite apenas 'par' ou 'impar'");
                    continue;
                }
                Console.Clear();
                var escolhaParImparPC = escolhaParImparUsuario == "par" ? "impar" : "par";
                var soma = numeroSorteadoPc + numeroEscolhidoUsuario;

                if ((soma % 2 == 0 && escolhaParImparUsuario == "par") || (soma % 2 != 0 && escolhaParImparUsuario == "impar"))
                {
                    tentativas++;
                    Console.WriteLine($"Parabéns, você ganhou com {tentativas} tentativa(as)!\nSua escolha: [{numeroEscolhidoUsuario}][{escolhaParImparUsuario}]\nEscolha do PC: [{numeroSorteadoPc}][{escolhaParImparPC}]\n");
                }
                else
                {
                    Console.WriteLine($"Que pena, você perdeu!\nSua escolha: [{numeroEscolhidoUsuario}][{escolhaParImparUsuario}]\nEscolha do PC: [{numeroSorteadoPc}][{escolhaParImparPC}]\n");
                    tentativas = 0;
                }
                
                Console.Write("Deseja jogar novamente? s/n ");
                string op = Console.ReadLine().Trim().ToLower();
                if(op == "n")
                    return;

                Console.Clear();
                continue;
            }
        }
    }
}

