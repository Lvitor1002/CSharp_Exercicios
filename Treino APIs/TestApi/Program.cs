
using TestApi.Api;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.AddDocumentacao();
            builder.AddServicos();
            builder.AddRefit();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.ConfiguracaoEnv();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
