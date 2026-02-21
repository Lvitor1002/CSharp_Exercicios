using ApiEcommerce.Data;
using ApiEcommerce.Models;
using ApiEcommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ApiEcommerce.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EcommerceDB _db;

        public ProdutoRepository(EcommerceDB db)
        {
            _db = db;
        }

        public async Task<Produto> AtualizarProduto(Produto produtoModels, int id)
        {
            try
            {
                Produto produto = await BuscarProduto(id);
                if (produto == null)
                {
                    throw new Exception($"Erro ao buscar produto de id[{id}] na base de dados!");
                }
                     
                produto.Id = produtoModels.Id;
                produto.Nome = produtoModels.Nome;
                produto.Fabricante = produtoModels.Fabricante;
                produto.PrecoUnitario = produtoModels.PrecoUnitario;
                produto.Desconto = produtoModels.Desconto;
                produto.Quantidade = produtoModels.Quantidade;
                produto.DataExpiracao = produtoModels.DataExpiracao;

                _db.Produtos.Update( produto );
                await _db.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception($">Erro ao atualizar produto! ->\n{ex.Message}");
            }
        }

        public async Task<Produto> BuscarProduto(int id)
        {
            try
            {
                return await _db.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($">Erro ao buscar produto! ->\n{ex.Message}");
            }
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            try
            {
                return await _db.Produtos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($">Erro ao buscar todos os produtos! ->\n{ex.Message}");
            }
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            try
            {
                await _db.Produtos.AddAsync( produto );
                await _db.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception($">Erro ao criar um produto! ->\n{ex.Message}");
            }
        }

        public async Task<bool> RemoverProduto(int id)
        {
            try
            {
                Produto produto = await BuscarProduto(id);
                if(produto == null)
                {
                    throw new Exception($"Erro ao buscar produto de id[{id}] na base de dados!");
                }

                _db.Produtos.Remove(produto);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($">Erro ao remover um produto! ->\n{ex.Message}");
            }
        }
    }
}
