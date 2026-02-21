using BackEndPicPay.Models;
using BackEndPicPay.Models.DTOs;
using BackEndPicPay.Models.Requests;
using BackEndPicPay.Models.Responses;

namespace BackEndPicPay.Services.Transferencias
{
    public interface ITransferenciasService
    {
        Task<Result<TransferenciaDto>> Executar(TransferenciaRequest request);
    }
}
