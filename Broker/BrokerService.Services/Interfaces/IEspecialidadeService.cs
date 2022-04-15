using BrokerService.Services.Interfaces.Base;
using BrokerService.Services.Models;

namespace BrokerService.Domain.Interfaces.Services
{
    public interface IEspecialidadeService : IServiceBase<EspecialidadeModel>
    {
        Task<List<EspecialidadeModel>> ObterPorDescricao(string descricao);
    }
}
