
using EstudoApiTeste.Api;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudoApiTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.AddConfiguracao();
            builder.AddDoc();
            builder.AddBancoDados();
            builder.AddDependencia();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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

