
using treino.Entities.Enums;

namespace treino.Entities
{
    public abstract class Figura : IFiguras
    {
        public Cor Cor { get; set; }
        public Figura(Cor cor)
        {
            Cor = cor;
        }

        public abstract decimal AreaFigura();
    }
}
