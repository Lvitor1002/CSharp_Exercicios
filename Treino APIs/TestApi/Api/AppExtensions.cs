namespace TestApi.Api
{
    public static class AppExtensions
    {
        public static void ConfiguracaoEnv(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
