using BrokerService.Controllers.Base;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Configs;
using BrokerService.Services.Models;
using Cadastro.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UsuarioController : BrokerController
    {
        //private readonly IUsuarioService _userSrv;
        //public UsuarioController(IUsuarioService userService) => _userSrv = userService;

        ///// <summary>
        ///// Cria um usuário novo
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="signingConfigurations"></param>
        ///// <param name="tokenConfig"></param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Novo([FromBody] UsuarioModel data
        //                          , [FromServices] SigningConfig signingConfigurations
        //                          , [FromServices] TokenConfig tokenConfig)
        //{
        //    return ReturnPackage(() =>
        //    {
        //        if (_userSrv.VerificarEmail(data.Email).GetAwaiter().GetResult())
        //            return StatusCode(400, "E-mail já existente");

        //        if (data.Senha.Length > 10)
        //            return StatusCode(400, "A senha só pode ser no máximo 10 caracteres");

        //        var currentUser = _userSrv.Gravar(data.Adapter()).GetAwaiter().GetResult();

        //        var currentLogin = new LoginModel(
        //            currentUser.Id, currentUser.Nome, currentUser.Telefone, currentUser.Email,
        //            currentUser.DataCriacao, currentUser.DataAlteracao, currentUser.DataUltimoAcesso);

        //        return null;
        //        //var token = new _tokenSrv.Token(currentLogin, signingConfigurations, tokenConfig);
        //        //currentLogin.Token = token.AccessToken;

        //        //return currentLogin;
        //    }
        //    , TipoUsuario.Todos, System.Net.HttpStatusCode.Created);

        //}

        ///// <summary>
        ///// Buscar todos os dados do banco.
        ///// </summary>
        ///// <returns></returns>
        //[Authorize("Bearer")]
        //[HttpGet("Todos")]
        //public IActionResult ObterTodos()
        //{
        //    return ReturnPackage(() => _userSrv.ObterTodos().GetAwaiter().GetResult());
        //}
    }
}
