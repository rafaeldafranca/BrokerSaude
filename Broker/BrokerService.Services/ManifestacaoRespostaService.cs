using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Services
{
    public class ManifestacaoRespostaService : IManifestacaoRespostaService
    {
        private readonly IManifestacaoRespostaRepo _manifestacaoRespostaRepo;
        private readonly IManifestacaoRepo _manifestacaoRepo;

        public ManifestacaoRespostaService(IManifestacaoRespostaRepo manifestacaoRespostaRepo,
            IManifestacaoRepo manifestacaoRepo)
        {
            _manifestacaoRespostaRepo = manifestacaoRespostaRepo;
            _manifestacaoRepo = manifestacaoRepo;
        }
        public async Task<bool> Gravar(string codigo, string resposta, Guid idUsuario)
        {
            var maniResult = await _manifestacaoRepo.Buscar(q => q.Codigo == codigo
                                                              && q.StatusSolicitacao != Domain.Emuns.EntityEnums.StatusManifestacao.Fechado);
            var manifestacao = maniResult.FirstOrDefault();
            if (manifestacao != null)
            {
                var obj = new ManifestacaoResposta()
                {
                    ManifestacaoId = manifestacao.Id,
                    Descricao = resposta,
                    UsuarioId = idUsuario
                };
                await _manifestacaoRespostaRepo.Adicionar(obj);

                if (manifestacao.StatusSolicitacao != StatusManifestacao.Andamento)
                {
                    manifestacao.StatusSolicitacao = StatusManifestacao.Andamento;
                    await _manifestacaoRepo.Atualizar(manifestacao);
                }

                return true;
            }
            return false;
        }
        public async Task<ManifestacaoRespostaModel> Gravar(ManifestacaoRespostaModel dados)
        {
            var result = dados.Adapter();
            await _manifestacaoRespostaRepo.Adicionar(result);
            return result.Adapter();
        }

        public async Task<ManifestacaoRespostaModel> ObterPorId(Guid id)
        {
            var result = await _manifestacaoRespostaRepo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<List<ManifestacaoRespostaModel>> ObterTodos()
        {
            var result = await _manifestacaoRespostaRepo.ObterTodos();
            return result.Adapter();
        }
    }
}
