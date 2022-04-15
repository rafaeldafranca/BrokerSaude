using BrokerService.Domain.helper;
using BrokerService.Domain.Interfaces.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrokerService.Core.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepoBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            try
            {
                var result = await _dbSet.AsNoTracking().FirstAsync(q => q.Id == id);
                return result;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            var result = await _dbSet.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            entity.DataAlteracao = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            _context.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}