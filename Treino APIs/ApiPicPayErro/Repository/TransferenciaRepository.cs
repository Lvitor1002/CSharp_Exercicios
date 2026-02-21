using BackEndPicPay.Data;
using BackEndPicPay.Models;
using BackEndPicPay.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackEndPicPay.Repository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly PicPayDB _db;
        public TransferenciaRepository(PicPayDB db)
        {
            _db = db;
        }
        public async Task AdicionarTransferencia(Transferencia transferenciaModel)
        {
            await _db.Transferencias.AddAsync(transferenciaModel);
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> IniciarTransacao()
        {
            //Trabalhando com transação
            return await _db.Database.BeginTransactionAsync();
        }
    }
}
