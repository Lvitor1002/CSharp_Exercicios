using ApiEcommerce.Data;
using ApiEcommerce.Repository;
using ApiEcommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Api
{
    public static class BuilderExtensions 
    {
        public static void AddConfigApi(this WebApplicationBuilder builder)
        {
            ConfigApi.ConnectionStrings = builder.Configuration.GetConnectionString("AppDbConnectionString") ?? string.Empty;
        }

        public static void AddDocumento(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddBancoDados(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EcommerceDB>(
                x=>x.UseMySql(ConfigApi.ConnectionStrings, ServerVersion.AutoDetect(ConfigApi.ConnectionStrings)));
        }

        public static void AddServicoInjecao(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }
    }
}
