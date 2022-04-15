using Cadastro.Domain.Models;
using BrokerService.Services.Configs;
using BrokerService.Services.Interfaces;
using BrokerService.Services.Models;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using BrokerService.Domain.Interfaces.Repositories;

namespace BrokerService.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUsuarioRepo _usuarioRepo;

        public TokenService(IUsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public TokenModel Token(LoginModel user, SigningConfig signingConfigurations
                                 , TokenConfig tokenConfigurations)
        {
            try
            {
                var usuario = _usuarioRepo.ObterPorId(user.Id).GetAwaiter().GetResult();
                if (usuario == null)
                    return new TokenModel { Authenticated = false };

                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                        new Claim("TypeUser", usuario.Tipo.ToString()),
                    }
                );

                DateTime CreatedDate = DateTime.Now;
                DateTime ExpiredDate = CreatedDate + TimeSpan.FromMinutes(tokenConfigurations.Minutes);
                IdentityModelEventSource.ShowPII = true;
                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = CreatedDate,
                    Expires = ExpiredDate
                });
                var token = handler.WriteToken(securityToken);

                return new TokenModel()
                {
                    Authenticated = true,
                    Created = CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    Expiration = ExpiredDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    AccessToken = token
                };

            }
            catch
            {
                return new TokenModel { Authenticated = false };
            }
        }

    }
}
