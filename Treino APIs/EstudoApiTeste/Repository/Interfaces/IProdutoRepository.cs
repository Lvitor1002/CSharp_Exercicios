using EstudoApiTeste.Models;

namespace EstudoApiTeste.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<ProdutoModels> AdicionarProduto(ProdutoModels produtoModel);
        Task<ProdutoModels> BuscarProduto(int id);
        Task<List<ProdutoModels>> BuscarTodosProdutos();
        Task<bool> RemoverProduto(int id);
        Task<ProdutoModels> AtualizarProduto(ProdutoModels produtoModel, int id);
    }
}
