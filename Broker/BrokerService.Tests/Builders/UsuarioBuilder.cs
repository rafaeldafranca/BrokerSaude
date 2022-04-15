using Bogus;
using BrokerService.Domain.Entities;

namespace Cadastro.Tests.Builders
{
    public class UsuarioBuilder
    {
        protected Guid Id;
        protected string Nome;
        protected string Email;
        protected string Senha;
        protected DateTime DataCriacao;
        protected DateTime? DataAlteracao;
        protected DateTime DataUltimoLogin;
        protected string Telefone;

        public static UsuarioBuilder Init()
        {
            var fake = new Faker();
            return new UsuarioBuilder
            {
                Id = Guid.NewGuid(),
                Nome = fake.Person.FullName,
                Email = fake.Person.Email,
                Senha = fake.Random.AlphaNumeric(5),
                DataCriacao = DateTime.Now,
                Telefone = fake.Random.Int(9, 9).ToString()
            };
        }

        public UsuarioBuilder WithName(string value)
        {
            Nome = value;
            return this;
        }

        public UsuarioBuilder WithEmail(string value)
        {
            Email = value;
            return this;
        }

        public UsuarioBuilder WithPassword(string value)
        {
            Senha = value;
            return this;
        }

        public UsuarioBuilder WithId(Guid value)
        {
            Id = value;
            return this;
        }

        public Usuario Build()
        {
            //var fake = new Usuario(Guid.Empty, Nome, Telefone, Email, Senha);
            var fake = new Usuario();
            if (Id != Guid.Empty) return fake;

            var propertyInfo = fake.GetType().GetProperty("Id");
            propertyInfo.SetValue(fake, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return fake;
        }
    }
}
