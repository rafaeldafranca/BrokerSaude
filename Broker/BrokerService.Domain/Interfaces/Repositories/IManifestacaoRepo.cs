using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Bases;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Domain.Interfaces.Repositories
{
    public interface IManifestacaoRepo : IRepoBase<Manifestacao>
    {
        Task<List<Manifestacao>> ObterTodosComResposta();
        Task<List<Manifestacao>> ObterTodosComRespostaPorStatus(StatusManifestacao status, DateTime ini, DateTime fim);
        Task<Manifestacao> ObterComResposta(string Codigo);
    }
}