using BrokerService.Domain.Entities;

namespace BrokerService.Services.Models
{
    public class ConveniadoCadastroModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string Senha { get; set; }
        public Guid PlanoId { get; set; }

        public ConveniadoCadastroModel()
        {

        }
        public ConveniadoCadastroModel(string nome, string documento, string logradouro, string numero, string complemento, string bairro, string cidade, string uf, string pais
            , string cep, string telefone, string senha, Guid planoId, Guid usuarioId)
        {
            Nome = nome;
            Documento = documento;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Pais = pais;
            Cep = cep;
            Telefone = telefone;
            PlanoId = planoId;
            Senha = senha;
        }
    }
}
