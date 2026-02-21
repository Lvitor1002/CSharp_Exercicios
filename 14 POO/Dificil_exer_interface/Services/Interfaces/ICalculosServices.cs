

using treino.Entities;

namespace treino.Services.Interfaces
{
    internal interface ICalculosServices
    {
        decimal RetornaValorLocacao(Locacao locacao);
        decimal RetornaValorImposto(decimal valorLocacao);
        decimal RetornaTotalPagamento(Locacao locacao);
    }
}
