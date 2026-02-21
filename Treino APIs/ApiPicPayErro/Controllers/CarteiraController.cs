using BackEndPicPay.Models.Requests;
using BackEndPicPay.Services.Carteiras;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPicPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraService _carteiraService;

        public CarteiraController(ICarteiraService carteiraService)
        {
            _carteiraService = carteiraService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCarteira(CarteiraRequest request)
        {
            var resultado = await _carteiraService.Executar(request);

            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Created();
        }

    }
}
