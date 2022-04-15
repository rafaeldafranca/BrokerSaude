using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;

namespace BrokerService.Services
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepo _PlanoRepo;
        private readonly IConveniadoRepo _conveniadoRepo;

        public PlanoService(IPlanoRepo PlanoRepo, IConveniadoRepo conveniadoRepo)
        {
            _PlanoRepo = PlanoRepo;
            _conveniadoRepo = conveniadoRepo;
        }

        public async Task<PlanoModel> Gravar(PlanoModel dados)
        {
            bool existe = false;
            var Plano = dados.Adapter();

            var result = await _PlanoRepo.ObterPorId(dados.Id);
            existe = result != null;

            if (!existe)
            {
                Plano.Id = Guid.NewGuid();
                await _PlanoRepo.Adicionar(Plano);
            }
            else
            {
                await _PlanoRepo.Atualizar(Plano);
            }

            return Plano.Adapter();
        }

        public async Task<List<PlanoModel>> ObterPorDescricao(string descricao)
        {
            var result = await _PlanoRepo.Buscar(q => q.Descricao.Contains(descricao));
            return result.ToList().Adapter();
        }

        public async Task<PlanoModel> ObterPorId(Guid id)
        {
            var result = await _PlanoRepo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<PlanoModel> ObterPorUsuario(Guid usuario)
        {
            var result = await _conveniadoRepo.ObterPorId(usuario);
            return result.Plano.Adapter();
        }

        public async Task<List<PlanoModel>> ObterTodos()
        {
            var result = await _PlanoRepo.ObterTodos();
            return result.Adapter();
        }
    }
}
