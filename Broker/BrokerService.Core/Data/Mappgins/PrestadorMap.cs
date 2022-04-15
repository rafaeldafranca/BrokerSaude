using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerService.Core.Data.Mappings
{
    public class PrestadorMap : IEntityTypeConfiguration<Prestador>
    {
        public void Configure(EntityTypeBuilder<Prestador> builder)
        {
            builder.ToTable("Prestadores");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.DataCriacao)
                    .IsRequired();


            /*Relacionamentos (1) */

            builder.HasOne(h => h.Usuario)
                    .WithMany(w => w.Prestadores)
                    .HasForeignKey(fk => fk.UsuarioId);

        }

    }

}