using BrokerService.Domain.helper;
using System.Text.RegularExpressions;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Validado { get; set; }
        public string Senha { get; set; }
        public string Documento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public bool Ativo { get; set; }
        public TipoUsuario Tipo { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }

        private readonly Regex _emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public virtual ICollection<Conveniado> Conveniados { get; set; }
        public virtual ICollection<Prestador> Prestadores { get; set; }
        public virtual ICollection<Associado> Associados { get; set; }

        public virtual ICollection<Manifestacao> Manifestacoes { get; set; }

        public Usuario()
        {

        }

        public Usuario(Guid? id, string nome, string telefone, string email, string senha,
                        DateTime? dataUltimoAcesso = null,
                        DateTime? dataCriacao = null,
                        DateTime? dataAlteracao = null)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();
            else
                DataAlteracao = DateTime.Now;

            DomainValidate.Init()
                .When(string.IsNullOrEmpty(nome), "O nome não pode ser em branco")
                .When(string.IsNullOrEmpty(telefone), "O Telefone não pode ser em branco")
                .When(string.IsNullOrEmpty(email), "O email não pode ser em branco")
                .When(string.IsNullOrEmpty(senha), "A senha não pode ser em branco")
                .When(senha.Length > 50, "A senha não pode passar de 50 caracteres")
                .When(string.IsNullOrEmpty(email) || !_emailRegex.Match(email).Success, "O email deve ser preenchido corretamente")
                .ThrowExceptionIfExist();

            Id = id.GetValueOrDefault();
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Senha = senha;

            Tipo = TipoUsuario.Todos;
            if (dataCriacao != null)
                DataCriacao = dataCriacao.GetValueOrDefault();
            DataAlteracao = dataAlteracao;
            DataUltimoAcesso = dataUltimoAcesso;
        }

        public Usuario(Guid? id, string nome, string telefone, string email, string senha,
            string documento, string logradouro, string numero, string complemento,
         string bairro, string cidade, string uf, string pais, string cep,
         bool ativo,
            TipoUsuario tipo = TipoUsuario.Todos,
            DateTime? dataUltimoAcesso = null,
            DateTime? dataCriacao = null,
            DateTime? dataAlteracao = null)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();
            else
                DataAlteracao = DateTime.Now;

            DomainValidate.Init()
                .When(string.IsNullOrEmpty(nome), "O nome não pode ser em branco")
                .When(string.IsNullOrEmpty(telefone), "O Telefone não pode ser em branco")
                .When(string.IsNullOrEmpty(email), "O email não pode ser em branco")
                .When(string.IsNullOrEmpty(senha), "A senha não pode ser em branco")
                .When(senha.Length > 50, "A senha não pode passar de 50 caracteres")
                .When(string.IsNullOrEmpty(email) || !_emailRegex.Match(email).Success, "O email deve ser preenchido corretamente")
                .ThrowExceptionIfExist();

            Id = id.GetValueOrDefault();
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Senha = senha;

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
            Tipo = tipo;
            if (dataCriacao != null)
                DataCriacao = dataCriacao.GetValueOrDefault();
            DataAlteracao = dataAlteracao;
            DataUltimoAcesso = dataUltimoAcesso;
        }

        public void RegistrarAcesso()
        {
            this.DataUltimoAcesso = DateTime.Now;
        }
    }
}