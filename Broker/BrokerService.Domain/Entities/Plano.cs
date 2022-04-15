using BrokerService.Domain.helper;

namespace BrokerService.Domain.Entities
{
    public class Plano : Entity
    {
        public int Produto { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string Cns { get; set; }
        public string Cobertura { get; set; }
        public string Acomodacao { get; set; }
        public virtual ICollection<Conveniado> Conveniados { get; set; }

        public Plano()
        {

        }

        public Plano(Guid id, int produto, string descricao, string codigo, string cns, string cobertura, string acomodacao)
        {
            Id = id;
            Produto = produto;
            Descricao = descricao;
            Codigo = codigo;
            Cns = cns;
            Cobertura = cobertura;
            Acomodacao = acomodacao;
        }
    }
}
