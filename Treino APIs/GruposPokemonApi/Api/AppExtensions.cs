namespace Teste.Api
{

    //[static] - A classe nunca será instanciada — ela serve apenas para "estender" funcionalidades de outras classes.
    public static class AppExtensions
    {
        public static void AddConfigAmbiente(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
