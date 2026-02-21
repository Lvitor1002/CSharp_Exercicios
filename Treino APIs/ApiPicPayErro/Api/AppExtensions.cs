namespace BackEndPicPay.Api
{
    public static class AppExtensions
    {
        public static void ConfigurarAmbiente(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
