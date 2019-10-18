using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDigital.Interfaces;
using System;
using System.Threading.Tasks;

namespace SDigital.Controllers
{
    public class BaseController : ControllerBase
    {
        public IContaService _service;
        public BaseController(IContaService service)
        {
            _service = service;
        }

        protected async Task<IActionResult> TratarResultadoAsync(Func<Task<IActionResult>> servico)
        {
            try
            {
                return await servico();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = "Falha! Favor entrar em contato com a TI." });
            }
        }
    }
}