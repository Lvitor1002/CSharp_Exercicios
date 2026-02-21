using EstudoApiTeste.Data;
using EstudoApiTeste.Repository;
using EstudoApiTeste.Repository.Interfaces;
using EstudoApiTeste.Utils;
using Microsoft.EntityFrameworkCore;

namespace EstudoApiTeste.Api
{
    public static class BuilderExtensions
    {
        public static void AddConfiguracao(this WebApplicationBuilder builder)
        {
            ConfigConexao.ConnectionString = builder.Configuration.GetConnectionString("AppDbConnectionString") ?? string.Empty;
        }
        public static void AddDoc(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n=>n.FullName);
            });
        }
        public static void AddBancoDados(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EstudoDB>(
                x => x.UseMySql(ConfigConexao.ConnectionString, ServerVersion.AutoDetect(ConfigConexao.ConnectionString)));
        }


        public static void AddDependencia(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }


    }
}
