
using BtgApi.Api;

namespace BtgApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.AddConfigApi();
            builder.AddDocumentacao();
            builder.AddBancoDados();
            builder.AddServicoInjecaoDependencia();
            builder.Services.AddAuthorization();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.ConfigAmbiente();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
