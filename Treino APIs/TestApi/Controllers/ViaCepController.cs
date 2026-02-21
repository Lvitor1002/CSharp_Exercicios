using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Entities;
using ViaCepApi.Services.Interfaces;

namespace ViaCepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        private readonly IViaCepService _viaCepService;
        public ViaCepController(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

        [HttpGet]
        public async Task<ActionResult<ViaCep>> Buscar(string cep)
        {
            var resposta = await _viaCepService.ObterDadosCep(cep);

            if (resposta == null)
            {
                return BadRequest("Cep não encontrado");
            }
            return Ok(resposta);
        }
    }
}
