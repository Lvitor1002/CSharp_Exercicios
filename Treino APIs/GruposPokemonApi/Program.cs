
using Teste.Api;

namespace Teste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.AddConfigApi();
            builder.AddDocumentacao();
            builder.AddServicoInjecao();
            builder.Services.AddAuthorization();


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.AddConfigAmbiente();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
