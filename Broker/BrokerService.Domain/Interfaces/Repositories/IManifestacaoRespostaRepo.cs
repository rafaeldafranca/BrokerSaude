using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Bases;

namespace BrokerService.Domain.Interfaces.Repositories
{
    public interface IManifestacaoRespostaRepo : IRepoBase<ManifestacaoResposta>
    {
        Task<bool> GravarRespostaPorCodigo(string codigo, ManifestacaoResposta resposta);
    }
}