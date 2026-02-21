using Teste.Services;
using Teste.Services.Interfaces;
using Teste.Utils;

namespace Teste.Api
{
    public static class BuildExtensions
    {
        public static void AddConfigApi(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("PokemonApiConfig"));
        }
        public static void AddDocumentacao(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
                x.CustomSchemaIds(n=>n.FullName)
            );
        }

        public static void AddServicoInjecao(this WebApplicationBuilder builder) 
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IPokemonService, PokemonService>();
            builder.Services.AddSingleton<ITimeService, TimeService>();
        }
    }
}
