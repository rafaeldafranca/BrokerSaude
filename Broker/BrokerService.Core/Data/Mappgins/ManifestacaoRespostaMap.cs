using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class ManifestacaoRespostaMap : IEntityTypeConfiguration<ManifestacaoResposta>
    {
        public void Configure(EntityTypeBuilder<ManifestacaoResposta> builder)
        {
            builder.ToTable("ManifestacaoResposta");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                .IsRequired();

            builder.Property(c => c.DataAlteracao);

            builder.Property(c => c.DataCriacao)
              .IsRequired();

            builder.Property(c => c.ManifestacaoId)
             .IsRequired();
        }

    }

}