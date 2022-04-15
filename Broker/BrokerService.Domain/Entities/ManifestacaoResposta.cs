using BrokerService.Domain.helper;

namespace BrokerService.Domain.Entities
{
    public class ManifestacaoResposta : Entity
    {
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public Guid ManifestacaoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public ManifestacaoResposta()
        {

        }

        public ManifestacaoResposta(Guid usuarioId, string descricao, Guid manifestacaoId)
        {
            UsuarioId = usuarioId;
            Descricao = descricao;
            ManifestacaoId = manifestacaoId;
        }
    }
}
