using treino.Entities.Enums;

namespace treino.Entities
{
    public class Retangulo : Figura
    {
        public decimal Largura { get; set; }
        public decimal Altura{ get; set; }

        public Retangulo(decimal largura, decimal altura, Cor cor) : base(cor)
        {
            Largura = largura;
            Altura = altura;
        }

        public override decimal AreaFigura() => Largura * Altura;

        public override string ToString()
        {
            return $"Cor do Retangulo: {Cor}\n" +
                $"Largura: {Largura}\n" +
                $"Altura: {Altura}\n" +
                $"Área do Retangulo: {AreaFigura():F2}\n" +
                $"-=-=-=-=-=-=-=-=-=-=-=-=\n";
        }
    }
}
