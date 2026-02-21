using TestApi.Entities;
using ViaCepApi.Refit;
using ViaCepApi.Services.Interfaces;

namespace TestApi.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly IViaCepRefit _viaCepRefit;
        public ViaCepService(IViaCepRefit viaCepRefit)
        {
            _viaCepRefit = viaCepRefit;
        }

        public async Task<ViaCep> ObterDadosCep(string cep)
        {
            var resposta = await _viaCepRefit.ObterDadosViaCep(cep);

            if(resposta == null || !resposta.IsSuccessStatusCode)
            {
                return null;
            }
            return resposta.Content;
        }
    }
}
