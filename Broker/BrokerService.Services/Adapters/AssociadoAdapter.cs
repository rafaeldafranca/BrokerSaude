using BrokerService.Domain.Entities;
using BrokerService.Domain.helper;
using BrokerService.Services.Models;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Services.Adapters
{
    public static class AssociadoAdapter
    {
        public static Associado Adapter(this AssociadoModel data)
        {
            if (data == null)
                return null;

            var result = new Associado(data.Id, data.UsuarioId, data.Matricula);

            result.Usuario = new Usuario(data.Id, data.Nome, data.Telefone, data.Email, data.Senha.GetHashDB(),
                data.Documento, data.Logradouro, data.Numero, data.Complemento, data.Bairro, data.Cidade, data.UF,
               data.Pais, data.Cep, data.Ativo, TipoUsuario.Associado);

            return result;
        }

        public static AssociadoModel Adapter(this Associado data)
        {
            if (data == null)
                return null;

            var usuario = data.Usuario;

            return new AssociadoModel(data.Id, usuario.Nome, usuario.Documento, usuario.Email, usuario.Logradouro, usuario.Numero, usuario.Complemento,
                                      usuario.Bairro, usuario.Cidade, usuario.UF, usuario.Pais, usuario.Cep, usuario.Ativo, usuario.Telefone,
                                        string.Empty, data.Matricula, data.UsuarioId, data.Usuario.Id);
        }

        public static AssociadoModel Adapter(this AssociadoCadastroModel data, Guid usuarioId)
        {
            if (data == null)
                return null;

            return new AssociadoModel(Guid.NewGuid(), data.Nome, data.Documento, data.Email, data.Logradouro, data.Numero, data.Complemento,
                                      data.Bairro, data.Cidade, data.UF, data.Pais, data.Cep, true, data.Telefone,
                                        data.Senha, data.Matricula, usuarioId, Guid.Empty);
        }

        public static List<AssociadoModel> Adapter(this List<Associado> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }

        public static List<Associado> Adapter(this List<AssociadoModel> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }
    }
}
