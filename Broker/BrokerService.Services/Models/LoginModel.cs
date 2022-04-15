
using BrokerService.Services.Models;

namespace Cadastro.Domain.Models
{
    public class LoginModel : UsuarioModel
    {
        public Guid Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public string Token { get; set; }

        public LoginModel(Guid id, string nome, string telefone, string email, DateTime? dataCriacao,
            DateTime? dataAlteracao, DateTime? dataUltimoLogin)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = null;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            DataUltimoLogin = dataUltimoLogin;
            Telefone = telefone;
        }
    }
}