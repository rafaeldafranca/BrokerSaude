using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;

namespace BrokerService.Services
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IPrestadorRepo _repo;
        public PrestadorService(IPrestadorRepo repo)
        {
            _repo = repo;
        }

        public async Task Excluir(Guid id)
        {

            var data = await _repo.ObterPorId(id);
            if (data != null)
                await _repo.Remover(id);
        }

        public async Task<bool> ExcluirPorUsuario(Guid usuario, Guid cliente)
        {
            var result = _repo.Buscar(q => q.Id.Equals(cliente) && q.UsuarioId.Equals(usuario))
                          .GetAwaiter()
                          .GetResult()
                          .FirstOrDefault();

            if (result == null) return false;

            _repo.Remover(cliente);

            return true;
        }

        public async Task<PrestadorModel> Gravar(PrestadorModel dados)
        {
            bool existe = false;

            var result = await _repo.ObterPorId(dados.Id);
            existe = result != null;
            var value = dados.Adapter();
            if (!existe)
            {
                value.Id = Guid.NewGuid();
                await _repo.Adicionar(value);
            }
            else
            {
                value.DataCriacao = result.DataCriacao;
                await _repo.Atualizar(value);
            }

            return value.Adapter();
        }

        public async Task<PrestadorModel> ObterPorId(Guid id)
        {
            var result = await _repo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<PrestadorModel> ObterPorUsuario(Guid usuario, Guid cliente)
        {
            var result = await _repo.Buscar(q => q.UsuarioId.Equals(usuario) && q.Id.Equals(cliente));
            
            return result.FirstOrDefault()?.Adapter();
        }

        public async Task<List<PrestadorModel>> ObterTodos()
        {
            var result = await _repo.ObterTodos();
            return result.Adapter();
        }

        public async Task<List<PrestadorModel>> ObterTodosPorUsuario(Guid usuario)
        {
            var result = await _repo.Buscar(q => q.UsuarioId.Equals(usuario));
            return result.ToList().Adapter();
        }
    }
}
