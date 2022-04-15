using BrokerService.Controllers.Base;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrokerService.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class EspecialidadeController : BrokerController
    {
        private readonly IEspecialidadeService _service;
        public EspecialidadeController(IEspecialidadeService service) => _service = service;

        /// <summary>
        /// Gravar o Cliente do usuário logado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpPost()]
        public IActionResult Novo([FromBody] EspecialidadeCadastroModel request)
        {
            return ReturnPackage(() =>
            {
                var data = new EspecialidadeModel(request.Descricao);

                _service.Gravar(data).GetAwaiter().GetResult();

                return Ok("Registro gravado com sucesso!");

            });
        }

        [Authorize("Bearer")]
        [HttpPut()]
        public IActionResult Gravar([FromBody] EspecialidadeModel request)
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
