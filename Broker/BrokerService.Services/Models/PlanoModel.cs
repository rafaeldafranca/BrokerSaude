using BrokerService.Domain.Entities;

namespace BrokerService.Services.Models
{
    public class PlanoModel
    {
        public Guid Id { get; set; }
        public int Produto { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string Cns { get; set; }
        public string Cobertura { get; set; }
        public string Acomodacao { get; set; }
        public PlanoModel()
        {

        }
        public PlanoModel(int produto, string descricao, string codigo, string cns, string cobertura
            , string acomodacao)
        {
            Id = Guid.NewGuid();
            Produto = produto;
            Descricao = descricao;
            Codigo = codigo;
            Cns = cns;
            Cobertura = cobertura;
            Acomodacao = acomodacao;
        }
    }
}
