namespace BackEndPicPay.Services.Notificacao
{
    public class NotificacaoService : INotificacaoService
    {
        public async Task EnviarNotificacao()
        {
            await Task.Delay(1000);
            Console.WriteLine("Cliente notificado");
        }
    }
}
