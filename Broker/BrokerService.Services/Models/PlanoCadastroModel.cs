using BrokerService.Domain.Entities;

namespace BrokerService.Services.Models
{
    public class PlanoCadastroModel
    {
        public int Produto { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string Cns { get; set; }
        public string Cobertura { get; set; }
        public string Acomodacao { get; set; }
        public PlanoCadastroModel()
        {

        }
        public PlanoCadastroModel(int produto, string descricao, string codigo, string cns, string cobertura
            , string acomodacao)
        {
            Produto = produto;
            Descricao = descricao;
            Codigo = codigo;
            Cns = cns;
            Cobertura = cobertura;
            Acomodacao = acomodacao;
        }
    }
}
