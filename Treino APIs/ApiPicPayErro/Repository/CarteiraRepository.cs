using BackEndPicPay.Data;
using BackEndPicPay.Models;
using BackEndPicPay.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEndPicPay.Repository
{
    public class CarteiraRepository : ICarteiraRepository
    {

        private readonly PicPayDB _db; //Usando modificador de acesso para garantir imutabilidade

        public CarteiraRepository(PicPayDB db)
        {
            _db = db;
        }

        public async Task AdicionarCarteira(Carteira carteiraModel)
        {
            await _db.Carteiras.AddAsync(carteiraModel);
        }

        public async Task AtualizarCarteira(Carteira carteiraModel)
        {
            _db.Carteiras.Update(carteiraModel);
        }

        public async Task<Carteira?> BuscarCarteira(string cpfcnpj, string email)
        {
            //Busca com base nos parâmetros cpf [ou] email:
            return await _db.Carteiras.FirstOrDefaultAsync(carteira =>
                carteira.CPFcnpj.Equals(cpfcnpj) ||
                carteira.Email.Equals(email));
        }

        public async Task<Carteira?> BuscarPorId(int id)
        {
            return await _db.Carteiras.FindAsync(id);
        }


        //Salvar alterações no banco por este método
        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
