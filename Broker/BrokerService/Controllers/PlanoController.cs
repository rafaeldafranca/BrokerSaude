using BrokerService.Controllers.Base;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrokerService.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PlanoController : BrokerController
    {
        private readonly IPlanoService _service;
        public PlanoController(IPlanoService service) => _service = service;

        /// <summary>
        /// Gravar o Cliente do usuário logado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpPost()]
        public IActionResult Novo([FromBody] PlanoCadastroModel request)
        {
            return ReturnPackage(() =>
            {
                _service.Gravar(request.Adapter()).GetAwaiter().GetResult();

                return Ok("Registro gravado com sucesso!");

            });
        }

        [Authorize("Bearer")]
        [HttpPut()]
        public IActionResult Gravar([FromBody] PlanoModel request)
        {
            return ReturnPackage(() =>
            {
                _service.Gravar(request).GetAwaiter().GetResult();

                return Ok("Registro gravado com sucesso!");

            });
        }

        [Authorize("Bearer")]
        [HttpGet("Todos")]
        public IActionResult ObterTodos()
        {
            return ReturnPackage(() =>
            {
                Guid usuario = Guid.Parse(User.Identity.Name);
                return _service.ObterTodos().GetAwaiter().GetResult();
            });
        }

        [Authorize("Bearer")]
        [HttpGet("{usuario:Guid}/usuario")]
        public IActionResult ObterPorUsuario(Guid usuario)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterPorUsuario(usuario).GetAwaiter().GetResult();
            });
        }

        [Authorize("Bearer")]
        [HttpGet("{Id}")]
        public IActionResult ObterPorId(Guid Id)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterPorId(Id).GetAwaiter().GetResult();
            });
        }
    }
}
