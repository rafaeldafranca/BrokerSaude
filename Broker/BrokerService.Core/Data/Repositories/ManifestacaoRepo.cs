using BrokerService.Core.Data.Repositories.Base;
using BrokerService.Domain.Emuns;
using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Repositories
{
    public class ManifestacaoRepo : Repository<Manifestacao>, IManifestacaoRepo
    {
        public ManifestacaoRepo(DbContext context) : base(context)
        {
        }

        public async Task<Manifestacao> ObterComResposta(Guid id)
        {
            return await _dbSet.Include(m => m.ManifestacaoRespostas)
                               .ThenInclude(x => x.Usuario)
                               .Where(q => q.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Manifestacao> ObterComResposta(string codigo)
        {
            return await _dbSet.Include(m => m.ManifestacaoRespostas)
                               .ThenInclude(x => x.Usuario)
                               .Where(q => q.Codigo == codigo).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<List<Manifestacao>> ObterTodosComResposta()
        {
            return _dbSet.Include(m => m.ManifestacaoRespostas)
                         .ThenInclude(x => x.Usuario).AsNoTracking().ToListAsync();
        }

        public Task<List<Manifestacao>> ObterTodosComRespostaPorStatus(EntityEnums.StatusManifestacao status, DateTime ini, DateTime fim)
        {
            var qini = DateTime.Parse(ini.ToString("yyyy/MM/dd"));
            var qfim = DateTime.Parse(fim.ToString("yyyy/MM/dd")).AddDays(1).AddMilliseconds(-1);
            
            return _dbSet.Include(m => m.ManifestacaoRespostas)
                         .ThenInclude(x => x.Usuario)
                         .Where(q => q.StatusSolicitacao == status && (q.DataCriacao >= qini && q.DataCriacao <= qfim))
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}
