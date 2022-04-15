using Cadastro.Domain.Models;
using BrokerService.Services.Configs;
using BrokerService.Services.Models;

namespace BrokerService.Services.Interfaces
{
    public interface ITokenService
    {
        TokenModel Token(LoginModel user, SigningConfig signingConfigurations
                                  , TokenConfig tokenConfigurations);
    }
}
