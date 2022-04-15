using BrokerService.Domain.helper;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Domain.Entities
{
    public class Manifestacao : Entity
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Codigo { get; set; }
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFechamento { get; set; }
        public StatusManifestacao StatusSolicitacao { get; set; }
       
        public virtual ICollection<ManifestacaoResposta> ManifestacaoRespostas { get; set; }
    }
}
