using BrokerService.Domain.Entities;
using BrokerService.Domain.helper;
using BrokerService.Services.Models;

namespace BrokerService.Services.Adapters
{
    public static class ConveniadoAdapter
    {
        public static Conveniado Adapter(this ConveniadoModel data)
        {
            if (data == null)
                return null;

            var result = new Conveniado(data.Id, data.UsuarioId, data.PlanoId);

            result.Usuario = new Usuario(data.Id, data.Nome, data.Telefone, data.Email, data.Senha.GetHashDB(), data.Documento
               , data.Logradouro, data.Numero, data.Complemento, data.Bairro, data.Cidade, data.UF,
               data.Pais, data.Cep, data.Ativo, Domain.Emuns.EntityEnums.TipoUsuario.Conveniado);

            return result;
        }

        public static ConveniadoModel Adapter(this Conveniado data)
        {
            if (data == null)
                return null;

            var usuario = data.Usuario;

            return new ConveniadoModel(data.Id, usuario.Nome, usuario.Documento, usuario.Logradouro, usuario.Numero, usuario.Complemento,
                                      usuario.Bairro, usuario.Cidade, usuario.UF, usuario.Pais, usuario.Cep, usuario.Ativo, usuario.Telefone,
                                       string.Empty, usuario.Email, data.PlanoId, data.UsuarioId, data.Usuario.Id);
        }

        public static ConveniadoModel Adapter(this ConveniadoCadastroModel data, Guid usuarioId)
        {
            if (data == null)
                return null;

            return new ConveniadoModel(Guid.NewGuid(), data.Nome, data.Documento, data.Logradouro, data.Numero, data.Complemento,
                                      data.Bairro, data.Cidade, data.UF, data.Pais, data.Cep, true, data.Telefone,
                                       data.Senha, data.Email, data.PlanoId, usuarioId, Guid.Empty);
        }
        public static List<ConveniadoModel> Adapter(this List<Conveniado> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }

        public static List<Conveniado> Adapter(this List<ConveniadoModel> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }
    }
}
