using ApiEcommerce.Models;

namespace ApiEcommerce.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CriarProduto(Produto produto);
        Task<Produto> BuscarProduto(int id);
        Task<List<Produto>> BuscarTodosProdutos();
        Task<bool> RemoverProduto(int id);
        Task<Produto> AtualizarProduto(Produto produto, int id);
    }
}
