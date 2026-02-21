using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace treino.Entities
{
    public class Jogador
    {
        public int QuantidadePartidas { get; set; }
        public string NomeJogador { get; set; }
        public List<Gol> ListaGols { get; set; } = new List<Gol>();

        public Jogador(string nomeJogador, int quantidadePartidas)
        {
            NomeJogador = nomeJogador;
            QuantidadePartidas = quantidadePartidas;
        }

        public void AdicionarGols(Gol gol)
            => ListaGols.Add(gol);
        public int TotalGols()
            => ListaGols.Sum(g => g.QuantidadeGols);

        public override string ToString()
        {
            int soma = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Gols por partida:");

            foreach (var g in ListaGols)
                sb.AppendLine($"{soma += 1}ª Partida: {g.ToString()}");

            sb.AppendLine($"\nTotal de Gols: {TotalGols()} gols.");
            return sb.ToString();
        }
    }
}
