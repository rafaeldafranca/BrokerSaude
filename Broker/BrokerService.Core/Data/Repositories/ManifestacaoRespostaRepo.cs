using BrokerService.Core.Data.Repositories.Base;
using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Repositories
{
    public class ManifestacaoRespostaRepo : Repository<ManifestacaoResposta>, IManifestacaoRespostaRepo
    {
        public IManifestacaoRepo _manifestacaoRepo;
        public ManifestacaoRespostaRepo(DbContext context, IManifestacaoRepo manifestacaoRepo) : base(context)
        {
            _manifestacaoRepo = manifestacaoRepo;
        }

        public async Task<bool> GravarRespostaPorCodigo(string codigo, ManifestacaoResposta resposta)
        {
            var manifestacao = await _manifestacaoRepo.ObterComResposta(codigo);
            manifestacao.StatusSolicitacao = Domain.Emuns.EntityEnums.StatusManifestacao.Andamento;
            _context.Entry(manifestacao).State = EntityState.Modified;
            _dbSet.Add(resposta);
            await SaveChanges();

            return true;
        }
    }
}
