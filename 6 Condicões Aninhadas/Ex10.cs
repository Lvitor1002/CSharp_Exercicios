
/*
 Você usará o método Random.Next() para simular a rolagem de três dados de seis lados cada. Você avaliará os valores para calcular a pontuação. 
Se a pontuação for superior a um total arbitrário, você exibirá uma mensagem de vitória para o usuário. 
Se a pontuação estiver abaixo do corte, você exibirá uma mensagem de derrota para o usuário.

Se quaisquer dois dados rolados resultarem no mesmo valor, você receberá dois pontos de bônus pelo resultado duplicado.
Se os três dados rolados resultarem no mesmo valor, você receberá seis pontos de bônus pelo resultado triplicado.
Se a somaLados dos três dados rolados, mais quaisquer pontos de bônus, for igual ou maior que 15, você vencerá o jogo. Caso contrário, você perderá.
 */
using System;
using System.Linq;

namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            =>ProcessarSorteio();

        private static void ProcessarSorteio()
        {
            var ladoSorteado = new Random();
            var lados = new int[3];
            double totalArbitrario = 25, bonus = 0;
            double somaLados = lados.Length > 0 ? lados.Sum() : 0;

            for (int i = 0; i < 3; i++)
                lados[i] = ladoSorteado.Next(1, 7);

            //Se a pontuação for superior a um total arbitrário, você exibirá uma mensagem de vitória para o usuário
            //Se a pontuação estiver abaixo do corte, você exibirá uma mensagem de derrota para o usuário.
            Console.WriteLine(somaLados < totalArbitrario 
                ? $"Derrota para o usuário!" 
                : "Vitória para o usuário!");

            //Se quaisquer dois dados rolados resultarem no mesmo valor, você receberá dois pontos de bônus pelo resultado duplicado.
            if ((lados[0] == lados[1]) || ((lados[1] == lados[2]) || ((lados[2] == lados[0]))))
            {
                bonus += 2;
                Console.WriteLine("Você recebeu 2 pontos bonus pois ");
            }

            //Se os três dados rolados resultarem no mesmo valor, você receberá seis pontos de bônus pelo resultado triplicado.
            if ((lados[0] == lados[1]) && (lados[1] == lados[2]) && (lados[2] == lados[0]))
            {
                bonus += 6;
                Console.WriteLine("Você recebeu 6 pontos bonus pois ");
            }

            //Se a somaLados dos três dados rolados, mais quaisquer pontos de bônus, for igual ou maior que 15, você vencerá o jogo. Caso contrário, você perderá.
            Console.WriteLine(somaLados + bonus >= 15 
                ? "Você venceu o jogo!"
                : "Você perdeu o jogo!");


        }
    }
}
