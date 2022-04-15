using BrokerService.Services.Interfaces.Base;
using BrokerService.Services.Models;

namespace BrokerService.Domain.Interfaces.Services
{
    public interface IPlanoService : IServiceBase<PlanoModel>
    {
        Task<PlanoModel> ObterPorUsuario(Guid usuario);
        Task<List<PlanoModel>> ObterPorDescricao(string descricao);
    }
}
