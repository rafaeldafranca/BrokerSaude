using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Services.Models
{
    public class ManifestacaoModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Codigo { get; set; }
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFechamento { get; set; }
        public StatusManifestacao StatusSolicitacao { get; set; }

        public ManifestacaoModel()
        {

        }
        public ManifestacaoModel(string titulo, string descricao, Guid usuarioId)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            StatusSolicitacao = StatusManifestacao.Aberto;
        }

        public ManifestacaoModel(Guid id, string titulo, string descricao, string codigo,
                                 DateTime? dataFechamento, StatusManifestacao statusSolicitacao, Guid usuarioId)
        {
            Id = id;
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            DataFechamento = dataFechamento;
            Codigo = codigo;
            StatusSolicitacao = statusSolicitacao;
        }
    }
}
