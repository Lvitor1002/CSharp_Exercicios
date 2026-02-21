using Refit;
using TestApi.Entities;

namespace ViaCepApi.Refit
{
    public interface IViaCepRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ViaCep>> ObterDadosViaCep(string cep);
    }
}
