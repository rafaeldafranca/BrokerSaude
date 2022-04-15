using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;

namespace BrokerService.Services
{
    public class ConveniadoService : IConveniadoService
    {
        private readonly IConveniadoRepo _repo;
        private readonly IUsuarioRepo _usuarioRepo;

        public ConveniadoService(IConveniadoRepo repo)
        {
            _repo = repo;
        }

        public async Task<ConveniadoModel> Gravar(ConveniadoModel value)
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
                dados.DataAlteracao = DateTime.Now;
                await _repo.Atualizar(dados);
            }

            return dados.Adapter();
        }

        public async Task<ConveniadoModel> ObterPorId(Guid id)
        {
            var result = await _repo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<ConveniadoModel> ObterPorUsuario(Guid usuario, Guid cliente)
        {
            var result = await _repo.Buscar(q => q.UsuarioId.Equals(usuario) && q.Id.Equals(cliente));
            return result.FirstOrDefault()?.Adapter();
        }

        public async Task<List<ConveniadoModel>> ObterTodos()
        {
            var result = await _repo.ObterTodos();
            return result.Adapter();
        }

        public async Task<List<ConveniadoModel>> ObterTodosPorUsuario(Guid usuario)
        {
            var result = await _repo.Buscar(q => q.UsuarioId.Equals(usuario));
            return result.ToList().Adapter();
        }
    }
}
