using BackEndPicPay.Models;

namespace BackEndPicPay.Repository.Interfaces
{
    public interface ICarteiraRepository
    {
        Task AdicionarCarteira(Carteira carteiraModel);
        Task<Carteira> BuscarCarteira(string cpfcnpj, string email);
        Task<Carteira> BuscarPorId(int id);
        Task AtualizarCarteira(Carteira carteiraModel);
        Task CommitAsync();
    }
}
