using BrokerService.Domain.Entities;

namespace BrokerService.Services.Models
{
    public class ConveniadoModel
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
        public Guid UsuarioId { get; set; }
        public bool Ativo { get; set; }
        public Guid PlanoId { get; set; }

        public Guid UsuarioDoConveniado { get; set; }

        public ConveniadoModel()
        {

        }
        public ConveniadoModel(Guid? id, string nome, string documento, string logradouro, string numero, string complemento, string bairro, string cidade, string uf, string pais
            , string cep, bool ativo, string telefone, string senha, string email, Guid planoId, Guid usuarioId, Guid usuarioDoConveniado)
        {
            this.Id = id.GetValueOrDefault();
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
            Ativo = ativo;
            Telefone = telefone;
            PlanoId = planoId;
            Senha = senha;
            Email = email;
            UsuarioDoConveniado = usuarioDoConveniado;
            UsuarioId = usuarioId;
        }
    }
}
