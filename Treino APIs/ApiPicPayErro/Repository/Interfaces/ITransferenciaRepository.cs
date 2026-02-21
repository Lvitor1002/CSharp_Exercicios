using System.Runtime.Intrinsics.X86;
using BackEndPicPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackEndPicPay.Repository.Interfaces
{
    public interface ITransferenciaRepository
    {
        Task AdicionarTransferencia(Transferencia transferenciaModel);

        Task CommitAsync();

        Task<IDbContextTransaction> IniciarTransacao();
        /*
        [IDbContextTransaction] ->
                                    interface do EF Core que representa uma transação no banco de dados.
        É permitido:
                    Iniciar uma transação.
                    Commitar (confirmar).
                    Rollback (reverter) se ocorrer erro.
                    Verificar o estado da transação.
        */
    }
}
