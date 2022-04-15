using BrokerService.Services.Interfaces.Base;
using BrokerService.Services.Models;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Domain.Interfaces.Services
{
    public interface IManifestacaoService : IServiceBase<ManifestacaoModel>
    {
        Task<List<ManifestacaoRelatorioModel>> ObterTodosPorUsuario(Guid usuario);
        Task<bool> Fechar(Guid usuario, string codigo);
        Task<ManifestacaoModel> ObterPorCodigo(string codigo);
        Task<ManifestacaoRelatorioModel> ObterPorCodigoRelatorio(string codigo);
        Task<List<ManifestacaoRelatorioModel>> ObterTodosPorStatus(StatusManifestacao tipo, DateTime ini, DateTime fim);
        Task<List<ManifestacaoRelatorioModel>> ObterTodosComResposta();
    }
}
