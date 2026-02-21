using BackEndPicPay.Models.Requests;
using BackEndPicPay.Services.Transferencias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPicPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciasService _transferenciasService;
        public TransferenciaController(ITransferenciasService transferenciasService) 
        {
            _transferenciasService = transferenciasService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTransferencia(TransferenciaRequest request)
        {
            var resultado = await _transferenciasService.Executar(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }
    }
}
