using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Services.Models
{
    public class ManifestacaoRelatorioModel
    {
        public string Titulo { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFechamento { get; set; }
        public StatusManifestacao StatusSolicitacao { get; set; }
        public List<ManifestacaoRespostaRelatorioModel> Respostas { get; set; }
        public ManifestacaoRelatorioModel()
        {

        }


        public ManifestacaoRelatorioModel(Guid id, string titulo, string descricao, string codigo,
                                 DateTime? dataFechamento, StatusManifestacao statusSolicitacao
                                , List<ManifestacaoRespostaRelatorioModel> respostas)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataFechamento = dataFechamento;
            Codigo = codigo;
            StatusSolicitacao = statusSolicitacao;
            Respostas = respostas;
        }
    }
}
