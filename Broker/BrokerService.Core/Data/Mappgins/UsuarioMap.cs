using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Senha)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.DataCriacao)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .IsRequired();

            builder.Property(c => c.Senha)
                   .HasMaxLength(250);

            builder.Property(c => c.Telefone)
                   .HasMaxLength(30)
                   .IsRequired();


            builder.Property(c => c.Ativo)
                 .IsRequired();

            builder.Property(c => c.Bairro)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Cidade)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Documento)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(c => c.Logradouro)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Numero)
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(c => c.Complemento)
                   .IsRequired(false);

            builder.Property(c => c.Cep)
                   .HasMaxLength(8)
                   .IsRequired();

            /*Relacionamentos (1)*/
            builder.HasMany(h => h.Associados)
                   .WithOne(w => w.Usuario);

            //builder.HasMany(h => h.Manifestacoes)
            //        .WithOne(w => w.UsuarioId);

            builder.HasMany(h => h.Conveniados)
                    .WithOne(w => w.Usuario);

            builder.HasMany(h => h.Prestadores)
                   .WithOne(w => w.Usuario);


        }
    }
}