using Refit;
using TestApi.Services;
using ViaCepApi.Refit;
using ViaCepApi.Services.Interfaces;

namespace TestApi.Api
{
    public static class BuilderExtensions
    {
        public static void AddDocumentacao(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n=>n.FullName);
            });
        }

        public static void AddServicos(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IViaCepService, ViaCepService>();
       
        }


        public static void AddRefit(this WebApplicationBuilder builder)
        {
            builder.Services.AddRefitClient<IViaCepRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });
        }
    }
}
