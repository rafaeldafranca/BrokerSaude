using BrokerService.Core.Data.Repositories.Base;
using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Repositories
{
    public class ConveniadoRepo : Repository<Conveniado>, IConveniadoRepo
    {
        public IUsuarioRepo _usuario;
        public ConveniadoRepo(DbContext context, IUsuarioRepo usuario) : base(context)
        {
            _usuario = usuario;
        }

        public override async Task Adicionar(Conveniado entity)
        {

            entity.Usuario.Id = Guid.NewGuid();
            await _usuario.Adicionar(entity.Usuario);

            entity.Id = Guid.NewGuid();
            entity.UsuarioId = entity.Usuario.Id;
            await base.Adicionar(entity);

        }

        public override async Task Atualizar(Conveniado entity)
        {
            var user = await _usuario.ObterPorId(entity.UsuarioId);
            _context.Entry(user).State = EntityState.Detached;

            entity.DataAlteracao = DateTime.Now;
            entity.Usuario.Id = entity.UsuarioId;
            entity.Usuario.Senha = user.Senha;

            _context.Entry(entity.Usuario).State = EntityState.Modified;
            _context.Entry(entity).State = EntityState.Modified;

            await SaveChanges();
        }

        public override async Task<Conveniado> ObterPorId(Guid id)
        {
            return await _dbSet.AsNoTracking().Include(m => m.Usuario)
                                              .Include(m=> m.Plano)
                                              .Where(q => q.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<List<Conveniado>> ObterTodos()
        {
            return await _dbSet.Include(m => m.Usuario).AsNoTracking().ToListAsync();
        }
    }
}