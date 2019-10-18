using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDigital.Interfaces;
using SDigital.Models;
using System.Threading.Tasks;

namespace SDigital.Controllers
{
    [Route("api/Clientes/{Documento}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ContasController : BaseController
    {
        public ContasController(IContaService service) : base(service)
        {
        }

        [Authorize(Policy = "DocumentoTokenRotaPolicy")]
        [HttpPost("Transferencia")]
        [ProducesResponseType(typeof(BaseResponse), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Transferir([FromRoute]ClienteRouteRequest route, [FromBody]ClienteBodyRequest body) =>
            await TratarResultadoAsync(async () =>
            {
                var resultado = await _service.Transferir(route, body);

                return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
            });

    }
}