using BtgApi.Models;
using static BtgApi.Responses.Response;

namespace BtgApi.Services
{
    public static class ProdutosFinanceirosMappen
    {
        public static DetalhesProdutoFinanceiroDTO MapearDTO (this ProdutoFinanceiro produtoFinanceiro)
        {
            return new DetalhesProdutoFinanceiroDTO(
                produtoFinanceiro.ProdutoFinanceiroID,
                produtoFinanceiro.NomeProdutoFinanceiro,
                produtoFinanceiro.ListaAplicacoes.Select(x => new AplicacaoDTO(x.AplicacaoID, x.Valor, x.DataAplicacao)).ToList(),
                produtoFinanceiro.ListaResgates.Select(x => new ResgateDTO(x.ResgateID, x.ValorResgate, x.DataResgate, x.ImpostoRenda, x.ValorLiquidoIR)).ToList()
                );
        }
    }
}
