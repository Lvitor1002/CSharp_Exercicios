using Microsoft.Extensions.Options;
using Teste.Exceptions;
using Teste.Models;
using Teste.Services.Interfaces;
using Teste.Utils;

namespace Teste.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IOptions<ApiConfig> _api;
        private readonly IHttpClientFactory _httpClientFactory;
        public PokemonService(IOptions<ApiConfig> api, IHttpClientFactory httpClientFactory)
        {
            _api = api;
            _httpClientFactory = httpClientFactory;
        }


        //Consumindo Api por nome
        public async Task<Pokemon> BuscarPokemonPorNome(string nome)
        {
            var httpCliente = _httpClientFactory.CreateClient();

            var respostaApi = await httpCliente.GetAsync($"{_api.Value.Url}/{nome}");

            if (!respostaApi.IsSuccessStatusCode)
            {
                throw new ApiException($"Pokemon '{nome}' não encontrado!");
            }

            var dadosPokemon = await respostaApi.Content.ReadFromJsonAsync<Pokemon>()
                ?? throw new ApiException("Um erro ocorreu durante a conversão Json"); //[??] "Se pokemon for null, então use esse outro valor"

            return dadosPokemon;
        }
    }
}
