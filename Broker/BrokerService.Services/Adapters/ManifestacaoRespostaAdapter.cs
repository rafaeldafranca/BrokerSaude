using BrokerService.Domain.Entities;
using BrokerService.Services.Models;


namespace BrokerService.Services.Adapters
{
    public static class ManifestacaoRespostaAdapter
    {
        public static ManifestacaoResposta Adapter(this ManifestacaoRespostaModel data)
        {
            if (data == null) return null;

            return new ManifestacaoResposta(data.UsuarioId, data.Descricao, data.ManifestacaoId);
        }

        public static ManifestacaoRespostaModel Adapter(this ManifestacaoResposta data)
        {
            if (data == null) return null;

            ManifestacaoRespostaModel user = new ManifestacaoRespostaModel()
            {
                Descricao = data.Descricao,
                Id = data.Id,
                ManifestacaoId = data.ManifestacaoId,
                UsuarioId = data.UsuarioId
            };

            return user;
        }


        public static List<ManifestacaoRespostaModel> Adapter(this List<ManifestacaoResposta> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }

        public static List<ManifestacaoResposta> Adapter(this List<ManifestacaoRespostaModel> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.Adapter()).ToList();

        }
    }
}
