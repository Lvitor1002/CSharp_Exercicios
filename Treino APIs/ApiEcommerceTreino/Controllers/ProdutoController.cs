using ApiEcommerce.Models;
using ApiEcommerce.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
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
        public async Task<ActionResult<Produto>> Criar([FromBody] Produto produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = await _produtoRepository.CriarProduto(produtoModel);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Buscar()
        {
            List<Produto> produtos = await _produtoRepository.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarUnico(int id)
        {
            Produto produto = await _produtoRepository.BuscarProduto(id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Remover(Produto produto, int id)
        {
            bool apagado = (bool) await _produtoRepository.RemoverProduto(id);
            return Ok(apagado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produtoModels, int id)
        {
            produtoModels.Id = id;
            Produto produto = await _produtoRepository.AtualizarProduto(produtoModels, id);
            return Ok(produto);
        }
    }
}
