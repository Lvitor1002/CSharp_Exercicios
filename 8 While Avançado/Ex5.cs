

/*
Desafio de batalha de RPG

Em alguns jogos de RPG, o personagem do jogador luta contra personagens não-jogadores, 
que geralmente são monstros ou os "bandidos". 

Às vezes, uma batalha consiste em cada personagem gerar um valor aleatório
usando dados e esse valor é subtraído da pontuação de saúde do oponente. 

Quando a saúde de qualquer um dos personagens chega a zero, eles perdem o jogo.

Um herói e um monstro começam com os mesmos pontos de vida. 
Durante a vez do herói, eles geram um valor aleatório que é subtraído da saúde do monstro. 
Se a saúde do monstro for maior que zero, eles tomam a sua vez e atacam o herói. 
Enquanto o herói e o monstro tiverem saúde superior a zero, a batalha recomeça.

> Regras para o jogo de batalha que você precisa implementar em seu projeto de código:
                                Você deve usar a do-while instrução ou a while instrução como um loop externo do jogo.
                                
                                O herói e o monstro começam com 10 pontos de saúde.
                                
                                Todos os ataques têm um valor entre 1 e 10.
                                
                                O herói ataca primeiro.
                                
                                Imprima a quantidade de vida que o monstro perdeu e a que lhe resta.
                                
                                Se o monstro tiver vida (superior a zero), poderá atacar o herói.
                                
                                Imprima a quantidade de vida que o herói perdeu e a que lhe resta.
                                
                                Continue esta sequência de ataques até que o monstro ou o herói fiquem sem vida (zero ou menos).
                                
                                Imprima o vencedor.
 */
using System;

namespace Fundamentos
{
    internal class Program
    {
        private static Random _gerarAtaque = new Random(); // Para instanciar apenas uma vez

        static void Main(string[] args)
            => JogarRPG();

        private static int RetornarValoresAtaque()
            => _gerarAtaque.Next(1, 11);

        private static void JogarRPG()
        {
            int saudeAtualHeroi = 10, saudeAtualMonstro = 10;

            do
            {
                int valorAtaqueHeroi = RetornarValoresAtaque();

                saudeAtualMonstro -= valorAtaqueHeroi;
                Console.WriteLine($"Herói atacou o monstro causando {valorAtaqueHeroi} de dano.\nMonstro perdeu {valorAtaqueHeroi} de vida, agora tem {Math.Max(0, saudeAtualMonstro)} de vida.\n"); //(Math.Max) - evitar que a saída mostre valores negativos

                if (saudeAtualMonstro <= 0)
                {
                    Console.WriteLine("O herói venceu a batalha!");
                    break;
                }

                int valorAtaqueMonstro = RetornarValoresAtaque();

                saudeAtualHeroi -= valorAtaqueMonstro;
                Console.WriteLine($"Monstro atacou o herói causando {valorAtaqueMonstro} de dano.\nHerói perdeu {valorAtaqueMonstro} de vida, agora tem {Math.Max(0, saudeAtualHeroi)} de vida.\n");
                
                if (saudeAtualHeroi <= 0)
                {
                    Console.WriteLine("O monstro venceu a batalha!");
                    break;
                }

            } while(saudeAtualHeroi > 0 && saudeAtualMonstro > 0);
        }
    }
}
