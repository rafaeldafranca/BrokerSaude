namespace BrokerService.Services.Models
{
    public class ManifestacaoRespostaModel
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public Guid ManifestacaoId { get; set; }

        public ManifestacaoRespostaModel()
        {

        }
        public ManifestacaoRespostaModel(string descricao, Guid usuarioId, Guid manifestacaoId)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Descricao = descricao;
            ManifestacaoId = manifestacaoId;
        }

        public ManifestacaoRespostaModel(Guid id, string descricao, Guid usuarioId, Guid manifestacaoId)
        {
            Id = id;
            UsuarioId = usuarioId;
            Descricao = descricao;
            ManifestacaoId = manifestacaoId;

        }
    }
}
