

/*
Faça um programa que jogue par ou ímpar com o computador. 
O jogo só será interrompido quando o jogador não quiser mais continuar, 
mostrando o total de vitórias consecutivas que ele conquistou no final do jogo. 

O jogo deve determinar o vencedor com base na soma dos números (se é par ou ímpar), 
não na comparação direta entre as escolhas de "par" ou "impar"
 
*/


using System;
using System.Linq;


namespace Fundamentos
{
    public class Program
    {
        private static Random _sorteioNumeroComputador = new Random();
        private static string _escolhaComputador;
        private static int _vitoriasConsecutivas = 0;

        private static void Main(string[] args)
            => ExibirDados();

        private static string RetornarEscolhaUsuario()
        {
            var entradasValidas = new string[] { "par", "impar","sair" };

            while (true)
            {
                Console.Write("Par ou Impar?\nPara finalizar digite 'sair'\n- ");
                string escolha = Console.ReadLine().Trim().ToLower();
                
                if (string.IsNullOrWhiteSpace(escolha) || !entradasValidas.Contains(escolha))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite apenas 'par', 'impar' ou 'sair'!\n");
                    continue;
                }
                if(escolha == "sair")
                {
                    Console.Clear();
                    Console.WriteLine($"Encerrando o jogo. Obrigado por jogar!");
                    Console.WriteLine(_vitoriasConsecutivas > 0 ? $"Vitórias consecutivas: {_vitoriasConsecutivas}\n" : "");
                    return string.Empty;
                }
                if(escolha == "par")
                    _escolhaComputador = "impar";
                else
                    _escolhaComputador = "par";

                Console.Clear();
                return escolha;
            }
        }

        private static int RetornarNumeroJogador()
        {
            while (true)
            {
                Console.Write("Digite um número de 1 à 10: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int numero) || numero <= 0 || numero > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número inteiro de 1 à 10!\n");
                    continue;
                }
                Console.Clear();
                return numero;
            }
        }

        private static int RetornarNumeroComputador()
            => _sorteioNumeroComputador.Next(1, 11);


        private static void ProcessarJogoImparPar()
        {
            while (true)
            {
                string escolhaUsuário = RetornarEscolhaUsuario();

                if (string.IsNullOrEmpty(escolhaUsuário))
                    return;

                double soma = RetornarNumeroJogador() + RetornarNumeroComputador();
                string resultadoParImpar = soma % 2 == 0 ? "par" : "impar";

                if (resultadoParImpar == "par" && escolhaUsuário == "par" || resultadoParImpar=="impar" && escolhaUsuário=="impar")
                {
                    _vitoriasConsecutivas++;
                    Console.WriteLine($"Você venceu!\nEscolheu '{escolhaUsuário}', computador escolheu '{_escolhaComputador}'\n{soma} é {resultadoParImpar}.\n");
                } else
                    Console.WriteLine($"Você perdeu!\nEscolheu '{escolhaUsuário}', computador escolheu '{_escolhaComputador}'\n{soma} é {resultadoParImpar}.\n");
            }
        }

        private static void ExibirDados()
            => ProcessarJogoImparPar();
    }
}
