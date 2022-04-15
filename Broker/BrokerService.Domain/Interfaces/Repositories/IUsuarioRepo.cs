using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Bases;

namespace BrokerService.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepo : IRepoBase<Usuario>
    {
        Task<Usuario> Validar(string email, string password);
        Task<bool> VerificarEmail(string email);
    }
}