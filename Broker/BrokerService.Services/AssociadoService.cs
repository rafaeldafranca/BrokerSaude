using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;

namespace BrokerService.Services
{
    public class AssociadoService : IAssociadoService
    {
        private readonly IAssociadoRepo _repo;
        private readonly IUsuarioRepo _usuarioRepo;

        public AssociadoService(IAssociadoRepo repo)
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

        public async Task<AssociadoModel> Gravar(AssociadoModel value)
        {
            bool existe = false;
            var dados = value.Adapter();

            var result = await _repo.ObterPorId(dados.Id);
            existe = result != null;

            if (!existe)
            {
                dados.Id = Guid.NewGuid();
                await _repo.Adicionar(dados);
            }
            else
            {
                await _repo.Atualizar(dados);
            }

            return dados.Adapter();
        }

        public async Task<AssociadoModel> ObterPorId(Guid id)
        {
            var result = await _repo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<AssociadoModel> ObterPorUsuario(Guid usuario, Guid cliente)
        {
            var result = await _repo.Buscar(q => q.UsuarioId.Equals(usuario) && q.Id.Equals(cliente));
            return result.FirstOrDefault()?.Adapter();
        }

        public async Task<List<AssociadoModel>> ObterTodos()
        {
            var result = await _repo.ObterTodos();
            return result.Adapter();
        }

        public async Task<List<AssociadoModel>> ObterTodosPorUsuario(Guid usuario)
        {
            var result = await _repo.Buscar(q => q.UsuarioId.Equals(usuario));
            return result.ToList().Adapter();
        }
    }
}
