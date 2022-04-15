using BrokerService.Core.Data.Repositories.Base;
using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Repositories
{
    public class UsuarioRepo : Repository<Usuario>, IUsuarioRepo
    {
        public UsuarioRepo(DbContext context) : base(context)
        {
        }

        public async Task<Usuario> Validar(string email, string password)
        {
            var result = await Buscar(q => q.Email == email && q.Senha == password);
            return result.FirstOrDefault();
        }

        public async override Task Atualizar(Usuario entity)
        {
            var user = await base.ObterPorId(entity.Id);
            if (user != null)
            {
                entity.Senha = user.Senha;
                entity.DataCriacao = user.DataCriacao;
                entity.DataAlteracao = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;
                await SaveChanges();
            }
            else
                new Exception("Usuario Inválido");
        }

        public async Task<bool> VerificarEmail(string email)
        {
            var result = await Buscar(q => q.Email == email);
            return result.FirstOrDefault() != null;
        }
    }
}
