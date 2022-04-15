using BrokerService.Core.Data.Repositories.Base;
using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Repositories
{
    public class PrestadorRepo : Repository<Prestador>, IPrestadorRepo
    {
        public IUsuarioRepo _usuario;
        public PrestadorRepo(DbContext context, IUsuarioRepo usuario) : base(context)
        {
            _usuario = usuario;
        }

        public override async Task Adicionar(Prestador entity)
        {
            await _usuario.Adicionar(entity.Usuario);
            entity.UsuarioId = entity.Usuario.UsuarioId;
            await base.Adicionar(entity);
        }

        public override async Task<Prestador> ObterPorId(Guid id)
        {
            return await _dbSet.Include(m => m.Usuario).Where(q=>q.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<List<Prestador>> ObterTodos()
        {
            return await _dbSet.Include(m => m.Usuario).AsNoTracking().ToListAsync();
        }
    }
}