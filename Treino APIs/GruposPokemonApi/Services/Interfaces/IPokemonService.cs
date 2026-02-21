using Teste.Models;

namespace Teste.Services.Interfaces
{
    public interface IPokemonService
    {
        public Task<Pokemon> BuscarPokemonPorNome(string nome);
    }
}
