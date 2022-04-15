using BrokerService.Controllers.Base;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;
using Cadastro.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class ManifestacaoController : BrokerController
    {
        private readonly IManifestacaoService _service;
        private readonly IUsuarioService _usuarioService;
        private readonly IMessageService _messageSrv;
        private readonly IManifestacaoRespostaService _respostaService;
        private readonly IMessageService _emailsrv;
        public ManifestacaoController(IManifestacaoService service, IUsuarioService usuarioService
            , IMessageService emailsrv, IManifestacaoRespostaService respostaService,IMessageService messageSrv)
        {
            _emailsrv = emailsrv;
            _service = service;
            _usuarioService = usuarioService;
            _respostaService = respostaService;
            _messageSrv = messageSrv;
        }


        [Authorize("Bearer")]
        [HttpPost()]
        public IActionResult Gravar([FromBody] ManifestacaoCadastroModel request)
        {
            return ReturnPackage(() =>
            {
                var data = new ManifestacaoModel(request.Titulo
                    , request.Descricao
                    , request.Usuario);

                var m = _service.Gravar(data).GetAwaiter().GetResult();
                var u = _usuarioService.ObterPorId(m.UsuarioId).GetAwaiter().GetResult();

                _messageSrv.SendMessage(EnviarEmailManifestacao(m.Codigo, u.Email));

                return Ok($"Registro gravado com sucesso {m.Codigo}!");

            });
        }

        [Authorize("Bearer")]
        [HttpGet()]
        public IActionResult ObterTodos()
        {
            return ReturnPackage(() =>
            {
                return _service.ObterTodosComResposta().GetAwaiter().GetResult();
            }, Domain.Emuns.EntityEnums.TipoUsuario.Associado);
        }

        [Authorize("Bearer")]
        [HttpGet("{value}/usuario")]
        public IActionResult ObterTodosPorUsuario(Guid value)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterTodosPorUsuario(value).GetAwaiter().GetResult();
            }, Domain.Emuns.EntityEnums.TipoUsuario.Associado);
        }

        [Authorize("Bearer")]
        [HttpGet("{value}/codigo")]
        public IActionResult ObterTodosPorCodigo(string value)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterPorCodigoRelatorio(value).GetAwaiter().GetResult();
            }, Domain.Emuns.EntityEnums.TipoUsuario.Associado);
        }

        [Authorize("Bearer")]
        [HttpGet("{ini}/{fim}/Andamento")]
        public IActionResult ObterTodosEmAndamento(DateTime ini, DateTime fim)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterTodosPorStatus(StatusManifestacao.Andamento, ini, fim).GetAwaiter().GetResult();
            }, Domain.Emuns.EntityEnums.TipoUsuario.Associado);
        }

        [Authorize("Bearer")]
        [HttpGet("{ini}/{fim}/fechado")]
        public IActionResult ObterTodosFechados(DateTime ini, DateTime fim)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterTodosPorStatus(StatusManifestacao.Fechado, ini, fim).GetAwaiter().GetResult();
            }, Domain.Emuns.EntityEnums.TipoUsuario.Associado);
        }

        [Authorize("Bearer")]
        [HttpGet("{ini}/{fim}/aberto")]
        public IActionResult ObterTodosAbertos(DateTime ini, DateTime fim)
        {
            return ReturnPackage(() =>
            {
                return _service.ObterTodosPorStatus(StatusManifestacao.Aberto, ini, fim).GetAwaiter().GetResult();
            }, Domain.Emuns.EntityEnums.TipoUsuario.Associado);
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



        [Authorize("Bearer")]
        [HttpPost("Resposta")]
        public IActionResult GravarResposta([FromBody] RespostaCadastroModel request)
        {
            return ReturnPackage(() =>
            {
                _respostaService.Gravar(request.Codigo, request.Descricao, request.UsuarioId).GetAwaiter().GetResult();
                var user = _usuarioService.ObterPorId(request.UsuarioId).GetAwaiter().GetResult(); ;
                _messageSrv.SendMessage(EnviarEmailResposta(request.Codigo, user.Email));
                return Ok("Registro gravado com sucesso!");

            });
        }

        [Authorize("Bearer")]
        [HttpPost("Resposta/Fechar/{codigo}")]
        public IActionResult Fechar(string codigo)
        {
            return ReturnPackage(() =>
            {
                Guid usuario = Guid.Parse(User.Identity.Name);
                _service.Fechar(usuario, codigo).GetAwaiter().GetResult();

                return Ok("Registro gravado com sucesso!");

            });
        }
    }
}
