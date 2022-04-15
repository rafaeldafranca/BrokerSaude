using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class ConveniadoMap : IEntityTypeConfiguration<Conveniado>
    {
        public void Configure(EntityTypeBuilder<Conveniado> builder)
        {
            builder.ToTable("Conveniados");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.DataCriacao)
                    .IsRequired();


            /*Relacionamentos (1) */

            builder.HasOne(h => h.Usuario)
                    .WithMany(w => w.Conveniados)
                    .HasForeignKey(fk => fk.UsuarioId);

            builder.HasOne(h => h.Plano)
                    .WithMany(w => w.Conveniados)
                    .HasForeignKey(fk => fk.PlanoId);

        }

    }

}