using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Models;
using Teste.Services.Interfaces;
using Teste.Utils;

namespace Teste.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;
        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPost]
        public async Task<ActionResult<Time>> Criar(TimeRecord timeR)
        {
            return await _timeService.CriarTime(timeR);
        }

        [HttpGet("{id:regex(^\\d+$)}")]
        public ActionResult<Time> BuscarTime(string id)
        {
            return _timeService.BuscarTimePorID(id);
        }

        [HttpGet]
        public ActionResult<Dictionary<string, Time>> BuscarTimes()
        {
            return _timeService.ProcuarTodosTimes();
        }
    }
}
