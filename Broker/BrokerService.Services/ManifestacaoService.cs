using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Adapters;
using BrokerService.Services.Models;
using static BrokerService.Domain.Emuns.EntityEnums;

namespace BrokerService.Services
{
    public class ManifestacaoService : IManifestacaoService
    {
        private readonly IManifestacaoRepo _ManifestacaoRepo;
        private readonly IUsuarioRepo _UsuarioRepo;

        public ManifestacaoService(IManifestacaoRepo ManifestacaoRepo)
        {
            _ManifestacaoRepo = ManifestacaoRepo;
        }

        public async Task<bool> Fechar(Guid usuario, string codigo)
        {
            var result = await ObterPorCodigo(codigo);
            result.DataFechamento = DateTime.Now;
            result.StatusSolicitacao = Domain.Emuns.EntityEnums.StatusManifestacao.Fechado;
            result.UsuarioId = usuario;

            await _ManifestacaoRepo.Atualizar(result.Adapter());
            return true;
        }

        public async Task<ManifestacaoModel> Gravar(ManifestacaoModel dados)
        {
            bool existe = false;
            var Manifestacao = dados.Adapter();

            var result = await _ManifestacaoRepo.ObterPorId(dados.Id);
            existe = result != null;

            if (!existe)
            {
                Manifestacao.Id = Guid.NewGuid();
                Manifestacao.Codigo = Domain.helper.Stuffs.alfanumericoAleatorio(6);
                await _ManifestacaoRepo.Adicionar(Manifestacao);
            }
            else
            {
                Manifestacao.DataAlteracao = DateTime.Now;
                await _ManifestacaoRepo.Atualizar(Manifestacao);
            }

            return Manifestacao.Adapter();
        }

        public async Task<ManifestacaoRelatorioModel> ObterPorCodigoRelatorio(string codigo)
        {
            var result = await _ManifestacaoRepo.ObterComResposta(codigo);
            return result.AdapterRelatorio();

        }
        public async Task<ManifestacaoModel> ObterPorCodigo(string codigo)
        {
            var result = await _ManifestacaoRepo.ObterComResposta(codigo);
            return result.Adapter();
        }

        public async Task<ManifestacaoModel> ObterPorId(Guid id)
        {
            var result = await _ManifestacaoRepo.ObterPorId(id);
            return result.Adapter();
        }

        public async Task<ManifestacaoRelatorioModel> ObterPorUsuario(Guid usuario, Guid Manifestacao)
        {
            var result = await _ManifestacaoRepo.Buscar(q => q.UsuarioId.Equals(usuario) && q.Id.Equals(Manifestacao));
            return result.FirstOrDefault().AdapterRelatorio();
        }

        public async Task<List<ManifestacaoRelatorioModel>> ObterTodosComResposta()
        {
            var result = await _ManifestacaoRepo.ObterTodosComResposta();
            return result.AdapterRelatorio();
        }

        public async Task<List<ManifestacaoRelatorioModel>> ObterTodosPorUsuario(Guid usuario)
        {
            var result = await _ManifestacaoRepo.Buscar(q => q.UsuarioId.Equals(usuario));
            return result.ToList().AdapterRelatorio();
        }

        public async Task<List<ManifestacaoRelatorioModel>> ObterTodosPorStatus(StatusManifestacao tipo, DateTime ini, DateTime fim)
        {
            var result = await _ManifestacaoRepo.ObterTodosComRespostaPorStatus(tipo, ini, fim);
            return result.ToList().AdapterRelatorio();
        }

        public async Task<List<ManifestacaoModel>> ObterTodos()
        {
            var result = await _ManifestacaoRepo.ObterTodos();
            return result.Adapter();
        }
    }
}
