using BrokerService.Domain.Entities;
using BrokerService.Services.Models;

namespace BrokerService.Services.Adapters
{
    public static class ManifestacaoAdapter
    {
        public static Manifestacao Adapter(this ManifestacaoModel data)
        {
            if (data == null)
                return null;

            return new Manifestacao()
            {
                DataFechamento = data.DataFechamento,
                Descricao = data.Descricao,
                Id = data.Id,
                StatusSolicitacao = data.StatusSolicitacao,
                Titulo = data.Titulo,
                UsuarioId = data.UsuarioId,
                Codigo = data.Codigo
            };
        }

        public static ManifestacaoModel Adapter(this Manifestacao data)
        {
            if (data == null)
                return null;

            return new ManifestacaoModel(data.Id, data.Titulo, data.Descricao, data.Codigo,
                                         data.DataFechamento, data.StatusSolicitacao, data.UsuarioId);
        }

        public static List<ManifestacaoModel> Adapter(this List<Manifestacao> data)
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
