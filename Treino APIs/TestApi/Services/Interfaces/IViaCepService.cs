using TestApi.Entities;

namespace ViaCepApi.Services.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCep> ObterDadosCep(string cep);
    }
}
