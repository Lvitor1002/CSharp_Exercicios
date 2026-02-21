using BtgApi.Requests;
using BtgApi.Services;
using BtgApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AligotaController : ControllerBase
    {
        private readonly IAligotaServices _aligotaService;

        public AligotaController(IAligotaServices aligotaService)
        {
            _aligotaService  = aligotaService;
        }

        [HttpPost("Aplicacao")]
        public async Task<ActionResult> Aplicar(int id, [FromBody] Request request)
        {
            try
            {
                request.CodeProdutoFinanceiro = id;

                var aplicacao = await _aligotaService.Aplicar(request);

                return CreatedAtAction(nameof(Aplicar),
                    new
                    {
                        data = new {id = aplicacao.ID, valor = aplicacao.Valor, dataAplicacao=aplicacao.DataAplicacao},
                    });
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    data = new {error = ex.Message},
                });
            }
        }



        [HttpPost("Resgate")]
        public async Task<ActionResult> Resgatar(int id, [FromBody] Request request)
        {
            try
            {
                request.CodeProdutoFinanceiro = id;

                var resgate = await _aligotaService.Resgate(request);

                return CreatedAtAction(nameof(Resgatar),
                    new
                    {
                        data = new
                        {
                            id = resgate.ID,valor = resgate.Valor,dataAplicacao = resgate.DataResgate},
                    });

            }catch(Exception erro)
            {
                return NotFound(new
                {
                    error = erro.Message,
                });
            }
        }


        [HttpGet("Listar")]
        public async Task<ActionResult> Listar()
        {
            var produtoFinanceiroAplicacao = await _aligotaService.Listar();

            return Ok(new {data = produtoFinanceiroAplicacao });
        }
    }
}
