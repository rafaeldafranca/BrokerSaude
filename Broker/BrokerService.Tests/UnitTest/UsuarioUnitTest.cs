using BrokerService.Domain.helper;
using Cadastro.Tests.Builders;
using System;
using Xunit;

namespace Cadastro.Tests.Extensions
{
    public class UsuarioUnitTest
    {

        [Theory]
        [InlineData("70ce7378-bfe1-4564-9a71-db45552131f3")]
        [InlineData(null)]
        public void CriandoUsuario(string value)
        {
            Guid UserId = string.IsNullOrEmpty(value) ? Guid.Empty : Guid.Parse(value);
            var esperado = UsuarioBuilder.Init().WithId(UserId).Build();
            Assert.NotNull(esperado);
        }

        [Fact]
        public void CriarComNameNulo()
        {
            Assert.Throws<DomainException>(() => UsuarioBuilder.Init().WithName(null).Build())
                                          .CheckIfMessage("O nome não pode ser em branco");
        }

        [Fact]
        public void CriarComEmailNulo()
        {
            Assert.Throws<DomainException>(() => UsuarioBuilder.Init().WithEmail(null).Build())
                                           .CheckIfMessage("O email não pode ser em branco");
        }

        [Fact]
        public void CriarComPasswordNulo()
        {
            Assert.Throws<DomainException>(() => UsuarioBuilder.Init().WithPassword(null).Build())
                                           .CheckIfMessage("A senha não pode ser em branco");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("email@")]
        [InlineData("emaildominio.com")]
        public void CriarComEmailErrado(string value)
        {
            Assert.Throws<DomainException>(() => UsuarioBuilder.Init().WithEmail(value).Build())
                                           .CheckIfMessage("O email deve ser preenchido corretamente");
        }
    }
}
