using BackEndPicPay.Models.Requests;
using BackEndPicPay.Models.Responses;

namespace BackEndPicPay.Services.Carteiras
{
    public interface ICarteiraService
    {
        Task<Result<bool>> Executar(CarteiraRequest request);
    }
}
