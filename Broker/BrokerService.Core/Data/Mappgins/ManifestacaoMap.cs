using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class ManifestacaoMap : IEntityTypeConfiguration<Manifestacao>
    {
        public void Configure(EntityTypeBuilder<Manifestacao> builder)
        {
            builder.ToTable("Manifestacoes");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                .IsRequired();

            builder.Property(c => c.StatusSolicitacao)
                .IsRequired();

            builder.Property(c => c.Codigo)
                .IsRequired();

            builder.Property(c => c.DataAlteracao);

            builder.Property(c => c.DataCriacao)
              .IsRequired();
        }

    }

}