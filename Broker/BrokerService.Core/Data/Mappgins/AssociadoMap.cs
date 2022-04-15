using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class AssociadoMap : IEntityTypeConfiguration<Associado>
    {
        public void Configure(EntityTypeBuilder<Associado> builder)
        {
            builder.ToTable("Associados");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.DataCriacao)
                    .IsRequired();


            /*Relacionamentos (1) */

            builder.HasOne(h => h.Usuario)
                    .WithMany(w => w.Associados)
                    .HasForeignKey(fk => fk.UsuarioId);

        }

    }

}