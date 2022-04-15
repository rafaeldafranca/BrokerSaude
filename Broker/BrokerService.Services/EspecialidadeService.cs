using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;

namespace BrokerService.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepo _EspecialidadeRepo;
        private readonly IUsuarioRepo _UsuarioRepo;

        public EspecialidadeService(IEspecialidadeRepo EspecialidadeRepo)
        {
            _EspecialidadeRepo = EspecialidadeRepo;
        }

        public async Task<EspecialidadeModel> Gravar(EspecialidadeModel dados)
        {
            bool existe = false;
            var Especialidade = dados.Adapter();

            var result = await _EspecialidadeRepo.ObterPorId(dados.Id);
            existe = result != null;

            if (!existe)
            {
                Especialidade.Id = Guid.NewGuid();
                await _EspecialidadeRepo.Adicionar(Especialidade);
            }
            else
            {
                await _EspecialidadeRepo.Atualizar(Especialidade);
            }

            return Especialidade.Adapter();
        }

        public async Task<List<EspecialidadeModel>> ObterPorDescricao(string descricao)
        {
            var result = await _EspecialidadeRepo.Buscar(q => q.Descricao.Contains(descricao));
            return result.ToList().Adapter();
        }

        public async Task<EspecialidadeModel> ObterPorId(Guid id)
        {
            var result = await _EspecialidadeRepo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<List<EspecialidadeModel>> ObterTodos()
        {
            var result = await _EspecialidadeRepo.ObterTodos();
            return result.Adapter();
        }
    }
}
