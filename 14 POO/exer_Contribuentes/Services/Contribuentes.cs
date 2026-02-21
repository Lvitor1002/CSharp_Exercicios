
using treino.Services.Interfaces;

namespace treino.Entities
{
    public abstract class Contribuentes : IContribuentes
    {
        public string Nome{ get; set; }
        public decimal RendaMensal{ get; set; }

        public Contribuentes(string nome, decimal rendaMensal)
        {
            Nome = nome;
            RendaMensal = rendaMensal;
        }

        public abstract decimal CalculoImposto();
    }
}
