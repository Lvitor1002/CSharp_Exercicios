

namespace treino.Entities
{
    public class Gol
    {
        public int QuantidadeGols { get; set; }

        public Gol(int quantidadeGols)
            =>QuantidadeGols = quantidadeGols;
        public override string ToString()
            => $"{QuantidadeGols} gols.";
    }
}
