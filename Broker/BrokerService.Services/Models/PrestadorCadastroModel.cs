using BrokerService.Domain.Entities;

namespace BrokerService.Services.Models
{
    public class PrestadorCadastroModel
    {
        public Guid Id { get; set; }
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
        public Guid EspecialidadeId { get; set; }
        public string Conselho { get; set; }

        public PrestadorCadastroModel()
        {

        }
        public PrestadorCadastroModel( string nome, string documento, string logradouro, string numero, string complemento, string bairro, string cidade, string uf, string pais, string cep,string telefone,
            string conselho, string senha, Guid especialidadeId)
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
            Senha = senha;
            Conselho = conselho;
            EspecialidadeId = especialidadeId;
        }
    }
}
