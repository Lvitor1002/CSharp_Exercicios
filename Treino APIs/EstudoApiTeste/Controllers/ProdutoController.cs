using EstudoApiTeste.Models;
using EstudoApiTeste.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoApiTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModels>> Adicionar([FromBody] ProdutoModels produtoModel)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            ProdutoModels produto = await _produtoRepository.AdicionarProduto(produtoModel);
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModels>> BuscarUm(int id)
        {
            ProdutoModels produto = await _produtoRepository.BuscarProduto(id);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModels>>> BuscarTodos()
        {
            List<ProdutoModels> produtos = await _produtoRepository.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModels>> Atualizar([FromBody] ProdutoModels produtoModel,int id)
        {
            produtoModel.Id = id;

            ProdutoModels produto = await _produtoRepository.AtualizarProduto(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {

            bool apagado = (bool)await _produtoRepository.RemoverProduto(id);
            return Ok(apagado);
        }
    }
}
