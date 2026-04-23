

/*
Jogo pedra papel e tesoura
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static Random _escolhaComputador = new Random();
        private static string[] _opcoes = new string[] { "pedra", "papel", "tesoura" };

        private static void Main(string[] args)
            => ExibirDados();


        private static string RetornarEscolhaComputador()
            =>_opcoes[_escolhaComputador.Next(_opcoes.Length)]; // _opcoes[índice] 

        private static string RetornarEscolhaUsuario()
        {
            while (true)
            {
                Console.Write("Escolha entre: pedra, papel ou tesoura - ");
                string entrada = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(entrada) || !_opcoes.Contains(entrada))
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente digitando apenas: pedra, papel ou tesoura.");
                    continue;
                }
                return entrada;
            }
        }

        private static string RetornarVencedorJogo(string escolhaComputador, string escolhaUsuario)
        {
            Console.Clear();
            if (escolhaComputador == escolhaUsuario)
                return $"Empate! Ambos escolheram {escolhaComputador}.";
            else if ((escolhaComputador == "papel" && escolhaUsuario == "pedra") || (escolhaComputador == "pedra" && escolhaUsuario == "tesoura") || (escolhaComputador == "tesoura" && escolhaUsuario == "papel"))
                return $"Computador: {escolhaComputador}\nUsuário: {escolhaUsuario}\n\nComputador venceu!";
            else 
                return $"Computador: {escolhaComputador}\nUsuário: {escolhaUsuario}\n\nUsuário venceu!";
        }

        private static void ExibirDados()
            =>Console.WriteLine(RetornarVencedorJogo(RetornarEscolhaComputador(),RetornarEscolhaUsuario()));
    }
}
