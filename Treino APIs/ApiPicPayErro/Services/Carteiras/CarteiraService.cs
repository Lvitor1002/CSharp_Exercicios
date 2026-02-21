using BackEndPicPay.Models;
using BackEndPicPay.Models.Requests;
using BackEndPicPay.Models.Responses;
using BackEndPicPay.Repository.Interfaces;

namespace BackEndPicPay.Services.Carteiras
{
    public class CarteiraService : ICarteiraService
    {


        private readonly ICarteiraRepository _repository;
        public CarteiraService(ICarteiraRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<bool>> Executar(CarteiraRequest request)
        {
            var carteirasExistentes = await _repository.BuscarCarteira(request.CPFcnpj, request.Email);

            if (carteirasExistentes is not null) 
            {
                return Result<bool>.FalhaResult("Carteira já existe");
            }
            
            var carteira = new Carteira(
                request.Tipo,
                request.NomeCompleto,
                request.CPFcnpj,
                request.Email,
                request.Senha,
                request.SaldoConta
            );

            await _repository.AdicionarCarteira(carteira);
            await _repository.CommitAsync();

            return Result<bool>.SucessoResult(true);
        }
    }
}
