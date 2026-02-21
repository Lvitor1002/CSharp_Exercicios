using BtgApi.Data;
using BtgApi.Services;
using BtgApi.Services.Interfaces;
using BtgApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace BtgApi.Api
{
    public static class BuildExtensions
    {
        public static void AddConfigApi(this  WebApplicationBuilder builder)
        {
            ConfigConexao.ConnectionStrings = builder.Configuration.GetConnectionString("AppDbConnectionString") 
                ?? string.Empty;
        }
        public static void AddDocumentacao(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(x =>
                {
                    x.CustomSchemaIds(n => n.FullName);
                });
        }
        public static void AddBancoDados(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BTGDB>(
                x => x.UseMySql(ConfigConexao.ConnectionStrings, ServerVersion.AutoDetect(ConfigConexao.ConnectionStrings)));
        }

        public static void AddServicoInjecaoDependencia(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAligotaServices, AligotaServices>();
        }
    }
}
