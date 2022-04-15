using BrokerService.Controllers.Base;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AssociadoController : BrokerController
    {
        private readonly IAssociadoService _service;
        private readonly IUsuarioService _userSrv;
        private readonly IMessageService _messageSrv;
        public AssociadoController(IAssociadoService service, IUsuarioService userSrv, IMessageService messageSrv)
        {
            _service = service;
            _userSrv = userSrv;
            _messageSrv = messageSrv;
        }

        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Novo([FromBody] AssociadoCadastroModel request)
        {
            return ReturnPackage(() =>
            {
                if (_userSrv.VerificarEmail(request.Email).GetAwaiter().GetResult())
                    return StatusCode(400, "E-mail já existente");

                if (request.Senha.Length > 10)
                    return StatusCode(400, "A senha só pode ser no máximo 10 caracteres");

                Guid usuario = Guid.Empty;
                if (User.Identity.Name != null)
                    usuario = Guid.Parse(User.Identity.Name);

                _service.Gravar(request.Adapter(usuario)).GetAwaiter().GetResult();
                _messageSrv.SendMessage(EnviarEmailCadastro(TipoUsuario.Associado, request.Email));
                return Ok("Dados registrados com sucesso!");

            }
            , TipoUsuario.Todos, System.Net.HttpStatusCode.Created);

        }
        [Authorize("Bearer")]
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] AssociadoModel request)
        {
            return ReturnPackage(() =>
            {
                if (request.Senha.Length > 10)
                    return StatusCode(400, "A senha só pode ser no máximo 10 caracteres");

                _service.Gravar(request).GetAwaiter().GetResult();

                return Ok("Dados registrados com sucesso!");

            }
            , TipoUsuario.Associado, System.Net.HttpStatusCode.NoContent);

        }
        [Authorize("Bearer")]
        [HttpGet("Todos")]
        public IActionResult ObterTodos()
        {
            return ReturnPackage(() =>
            {
                Guid usuario = Guid.Parse(User.Identity.Name);
                return _service.ObterTodos().GetAwaiter().GetResult();
            }, TipoUsuario.Associado);
        }

        [Authorize("Bearer")]
        [HttpGet("{Id}")]
        public IActionResult ObterPorId(Guid Id)
        {
            return ReturnPackage(() =>
            {
                Guid usuario = Guid.Parse(User.Identity.Name);
                return _service.ObterPorId(Id).GetAwaiter().GetResult();
            });
        }
    }
}
