using BrokerService.Domain.Entities;
using BrokerService.Domain.helper;
using BrokerService.Services.Models;


namespace BrokerService.Services.Adapters
{
    public static class UsuarioAdapter
    {
        public static Usuario Adapter(this UsuarioModel data)
        {
            if (data == null) return null;

            return new Usuario(
             Guid.Empty,
             data.Nome,
             data.Telefone,
             data.Email,
             data.Senha.GetHashDB()
             );
        }

        public static UsuarioModel Adapter(this Usuario data)
        {
            if (data == null) return null;

            UsuarioModel user = new UsuarioModel()
            {
                Email = data.Email,
                Nome = data.Nome,
                Telefone = data.Telefone
            };

            return user;
        }
    }
}
