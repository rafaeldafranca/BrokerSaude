using BrokerService.Domain.Entities;
using BrokerService.Services.Models;


namespace BrokerService.Services.Adapters
{
    public static class ManifestacaoRelatorioAdapter
    {

        public static ManifestacaoRelatorioModel AdapterRelatorio(this Manifestacao data)
        {
            if (data == null) return null;

            var result = new ManifestacaoRelatorioModel()
            {
                Descricao = data.Descricao,
                Codigo = data.Codigo,
                DataFechamento = data.DataFechamento,
                StatusSolicitacao = data.StatusSolicitacao,
                Titulo = data.Titulo
            };

            if (data.ManifestacaoRespostas != null && data.ManifestacaoRespostas.Count() > 0)
            {
                result.Respostas = new List<ManifestacaoRespostaRelatorioModel>();
                data.ManifestacaoRespostas.ToList().ForEach(
                    q =>
                    {
                        var resp = new ManifestacaoRespostaRelatorioModel()
                        {
                            Autor = q.Usuario.Nome,
                            Data = q.DataCriacao,
                            Descricao = q.Descricao
                        };
                        result.Respostas.Add(resp);
                    });
            }

            return result;
        }

        public static List<ManifestacaoRelatorioModel> AdapterRelatorio(this List<Manifestacao> data)
        {
            if (data == null)
                return null;

            return data.Select(q => q.AdapterRelatorio()).ToList();

        }
    }
}
