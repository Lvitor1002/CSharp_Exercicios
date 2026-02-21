using EstudoApiTeste.Data;
using EstudoApiTeste.Models;
using EstudoApiTeste.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstudoApiTeste.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EstudoDB _db;
        public ProdutoRepository(EstudoDB db)
        {
            _db = db;
        }

        public async Task<ProdutoModels> AdicionarProduto(ProdutoModels produtoModel)
        {
            try
            {
                await _db.AddAsync(produtoModel);
                await _db.SaveChangesAsync();
                return produtoModel;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao adicionar um produto! - {ex.Message}");
            }
        }
        public async Task<ProdutoModels> AtualizarProduto(ProdutoModels produtoModel, int id)
        {
            try
            {
                ProdutoModels produto = await BuscarProduto(id);
                if (produto == null)
                {
                    throw new Exception($"Erro ao buscar um produto de id: {id}! O mesmo não existe!");
                }

                produto.Id = produtoModel.Id;
                produto.Nome = produtoModel.Nome;
                produto.Preco = produtoModel.Preco;
                produto.DataVenda = produtoModel.DataVenda;

                _db.Produtos.Update(produto);
                await _db.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar produto de id: {id}! - {ex.Message}");
            }
        }
        public async Task<bool> RemoverProduto(int id)
        {
            try
            {
                ProdutoModels produto = await BuscarProduto(id);  
                if(produto == null)
                {
                    throw new Exception($"Erro ao buscar um produto de id: {id}! O mesmo não existe!");
                }
                _db.Produtos.Remove(produto);
                _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover produto de id: {id}! - {ex.Message}");
            }
        }
        public async Task<ProdutoModels> BuscarProduto(int id)
        {
            try
            {
                var produto = await _db.Produtos.FirstOrDefaultAsync(x=>x.Id == id);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar um produto de id: {id}! - {ex.Message}");
            }
        }
        public async Task<List<ProdutoModels>> BuscarTodosProdutos()
        {
            try
            {
                var listaProdutos = await _db.Produtos.ToListAsync();
                return listaProdutos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os produtos! - {ex.Message}");
            }
        }

    }
}
