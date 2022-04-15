using BrokerService.Controllers.Base;
using BrokerService.Domain.helper;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services;
using BrokerService.Services.Configs;
using BrokerService.Services.Interfaces;
using BrokerService.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrokerService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class AuthController : BrokerController
    {
        private readonly IUsuarioService _userSrv;
        private readonly ITokenService _tokenSrv;
        public AuthController(IUsuarioService userService, ITokenService tokenSrv)
        {
            _userSrv = userService;
            _tokenSrv = tokenSrv;
        }
        /// <summary>
        /// Gera o token autenticando o usuário.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="signingConfigurations"></param>
        /// <param name="tokenConfig"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IActionResult), 200)]
        [AllowAnonymous]
        [HttpPost("Token")]
        public IActionResult Token([FromBody] AuthModel data
                                  , [FromServices] SigningConfig signingConfigurations
                                  , [FromServices] TokenConfig tokenConfig)
        {
            return ReturnPackage(() =>
            {

                var currentUser =  _userSrv.Validar(data.Email, data.Password.GetHashDB()).GetAwaiter().GetResult();
                if (currentUser == null)
                    return StatusCode(401, "Usuario Inválido");

                var token = _tokenSrv.Token(currentUser, signingConfigurations, tokenConfig);
                currentUser.Token = token.AccessToken;

                return currentUser;
            });
        }
    }
}
