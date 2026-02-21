using BtgApi.Requests;
using static BtgApi.Responses.Response;

namespace BtgApi.Services.Interfaces
{
    public interface IAligotaServices
    {
        Task<AplicacaoDTO> Aplicar(Request request);
        Task<ResgateDTO> Resgate(Request request);
        Task<List<DetalhesProdutoFinanceiroDTO>> Listar();

    }
}


