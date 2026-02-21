using System.Runtime.ConstrainedExecution;
using BackEndPicPay.Data;
using BackEndPicPay.Repository;
using BackEndPicPay.Repository.Interfaces;
using BackEndPicPay.Services.Autorizador;
using BackEndPicPay.Services.Carteiras;
using BackEndPicPay.Services.Notificacao;
using BackEndPicPay.Services.Transferencias;
using BackEndPicPay.Utils;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace BackEndPicPay.Api
{
    //[static] ->
    //           Classe Não pode ser instanciada
    //           Serve como contêiner para métodos estáticos
    //           Garante que todos os membros sejam estáticos
    //           [Métodos] - Podem ser chamados sem instanciar a classe


    public static class BuilderExtensions
    {
        public static void AddConfiguracaoApi(this WebApplicationBuilder builder) 
        {
            ConfigApi.ConnectionStrings = builder.Configuration.GetConnectionString("AppDbConnectionString") ?? string.Empty;
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
            builder.Services.AddDbContext<PicPayDB>(
                x => x.UseMySql(ConfigApi.ConnectionStrings, ServerVersion.AutoDetect(ConfigApi.ConnectionStrings)));   
        }

        public static void AddServicoInjecaoDependencia(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();
            builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            builder.Services.AddScoped<ICarteiraService, CarteiraService>();
            builder.Services.AddScoped<ITransferenciasService, TransferenciasService>();
            builder.Services.AddScoped<IAutorizadorService, AutorizadorService>();
            builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
        }

    }
}
