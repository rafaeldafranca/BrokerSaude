using BrokerService.Domain.Entities;

namespace BrokerService.Services.Models
{
    public class ManifestacaoCadastroModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid Usuario { get; set; }
    }
}
