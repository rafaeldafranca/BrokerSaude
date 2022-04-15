using BrokerService.Domain.Entities;
using BrokerService.Services.Models;
using Cadastro.Domain.Models;

namespace BrokerService.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> Gravar(Usuario user);
        Task<bool> VerificarEmail(string email);
        Task<Usuario> ObterPorId(Guid Id);
        Task<List<Usuario>> ObterTodos();
        Task<LoginModel> Validar(string email, string password);
    }
}
