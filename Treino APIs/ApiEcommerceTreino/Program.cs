
using ApiEcommerce.Api;

namespace ApiEcommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddConfigApi();
            builder.Services.AddControllers();
            builder.AddDocumento();
            builder.AddBancoDados();
            builder.AddServicoInjecao();
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
