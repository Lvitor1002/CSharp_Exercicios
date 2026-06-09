

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
    public static class Program
    {
        private static int _saudeHeroi = 10;
        private static int _saudeMonstro = 10;
        private static Random _gerarValorAtaque = new Random();

        private static void Main(string[] args)
            => ExibirDados();

        private static int RetornarValorAtaque()
            => _gerarValorAtaque.Next(1, 11);


        private static void ExecutarBatalhaHeroiMonstro()
        {
            do
            {
                int valorAtaqueHeroi = RetornarValorAtaque();
                int valorAtaqueMonstro = RetornarValorAtaque();

                _saudeMonstro -= valorAtaqueHeroi;
                Console.WriteLine($"O herói atacou o monstro e causou {valorAtaqueHeroi} de dano. O monstro tem {Math.Max(0, _saudeMonstro)} de vida.\n"); //(Math.Max) - evitar que a saída mostre valores negativos
                if (_saudeMonstro <= 0)
                {
                    Console.WriteLine($"\nO herói venceu a batalha com {_saudeHeroi} de saúde!\n");
                    return;
                }

                _saudeHeroi -= valorAtaqueMonstro;
                Console.WriteLine($"O monstro atacou o herói e causou {valorAtaqueMonstro} de dano. O herói tem {Math.Max(0, _saudeHeroi)} de vida restante.\n");
                if (_saudeHeroi <= 0)
                {
                    Console.WriteLine($"\nO monstro venceu a batalha com {_saudeMonstro} de saúde!\n");
                    return;
                }

            } 
            while (_saudeMonstro > 0 && _saudeHeroi > 0);
        }
        private static void ExibirDados()
            =>ExecutarBatalhaHeroiMonstro();
    }
}
