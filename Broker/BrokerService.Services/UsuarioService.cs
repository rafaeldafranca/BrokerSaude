using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using Cadastro.Domain.Models;

namespace BrokerService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepo _usuarioRepo;

        public UsuarioService(IUsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<Usuario> Gravar(Usuario user)
        {
            user.RegistrarAcesso();
            await _usuarioRepo.Adicionar(user);
            return user;
        }

        public async Task<bool> VerificarEmail(string email)
        {
            return await _usuarioRepo.VerificarEmail(email);
        }

        public async Task<Usuario> ObterPorId(Guid Id)
        {
            return await _usuarioRepo.ObterPorId(Id);
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            return await _usuarioRepo.ObterTodos();
        }

        public async Task Excluir(Guid id)
        {
           await _usuarioRepo.Remover(id);
        }

        public async Task<LoginModel> Validar(string email, string password)
        {
            var data = await _usuarioRepo.Validar(email, password);
            if (data == null) return null;

            return new LoginModel(data.Id, data.Nome, data.Telefone, data.Email, data.DataCriacao
                                , data.DataAlteracao, data.DataUltimoAcesso);
        }

    }
}
