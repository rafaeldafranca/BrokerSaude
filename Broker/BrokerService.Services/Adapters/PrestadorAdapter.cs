using BrokerService.Domain.Entities;
using BrokerService.Domain.helper;
using BrokerService.Services.Models;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Services.Adapters
{
    public static class PrestadorAdapter
    {
        public static Prestador Adapter(this PrestadorModel data)
        {
            if (data == null)
                return null;

            var result = new Prestador(data.Id, data.UsuarioId, data.Conselho, data.EspecialidadeId);

            result.Usuario = new Usuario(data.Id, data.Nome, data.Telefone, data.Email, data.Senha.GetHashDB(),
                data.Documento, data.Logradouro, data.Numero, data.Complemento, data.Bairro, data.Cidade, data.UF,
               data.Pais, data.Cep, data.Ativo, TipoUsuario.Prestador);

            return result;
        }

        public static PrestadorModel Adapter(this Prestador data)
        {
            if (data == null)
                return null;

            var usuario = data.Usuario;

            return new PrestadorModel(data.Id, usuario.Nome, usuario.Documento, usuario.Logradouro, usuario.Numero, usuario.Complemento,
                                      usuario.Bairro, usuario.Cidade, usuario.UF, usuario.Pais, usuario.Cep, usuario.Ativo, usuario.Telefone,
                                        data.Conselho, string.Empty, data.EspecialidadeId, data.UsuarioId, data.Usuario.Id); ;
        }

        public static PrestadorModel Adapter(this PrestadorCadastroModel data, Guid usuarioId)
        {
            if (data == null)
                return null;

            return new PrestadorModel(null, data.Nome, data.Documento, data.Logradouro, data.Numero, data.Complemento,
                                      data.Bairro, data.Cidade, data.UF, data.Pais, data.Cep, true, data.Telefone,
                                        data.Conselho, data.Senha, data.EspecialidadeId, usuarioId, Guid.Empty);

        }
        public static List<PrestadorModel> Adapter(this List<Prestador> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }

        public static List<Prestador> Adapter(this List<PrestadorModel> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }
    }
}
