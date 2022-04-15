using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidades");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.DataCriacao)
                    .IsRequired();
            builder.Property(c => c.Descricao)
                    .IsRequired();
        }

    }

}