namespace BackEndPicPay.Services.Autorizador
{
    public interface IAutorizadorService
    {
        Task<bool> Autorizar();
    }
}
