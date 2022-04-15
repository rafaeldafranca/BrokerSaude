using BrokerService.Services.Interfaces.Base;
using BrokerService.Services.Models;

namespace BrokerService.Domain.Interfaces.Services
{
    public interface IManifestacaoRespostaService : IServiceBase<ManifestacaoRespostaModel>
    {
        Task<bool> Gravar(string codigo, string resposta, Guid idUsuario);
    }
}
