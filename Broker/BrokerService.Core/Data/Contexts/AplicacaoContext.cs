using BrokerService.Core.Data.Mappings;
using BrokerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Contexts
{
    public class AplicacaoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Conveniado> Conveniado { get; set; }
        public DbSet<Prestador> Prestador { get; set; }
        public DbSet<Associado> Associado { get; set; }
        public DbSet<Manifestacao> Manifestacao { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<ManifestacaoResposta> ManifestacaoResposta { get; set; }
        public DbSet<Plano> Plano { get; set; }

        //Comandos para criar versoes de atualizacao e atualizar o banco de dados.
        //dotnet ef migrations add "changes" --project BrokerService.Core --startup-project BrokerService
        //dotnet ef database update --project BrokerService.Core --startup-project BrokerService
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetProperties()
                    .ToList()
                    .ForEach(p =>
                    {
                        p.SetIsUnicode(false);
                        if (p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))
                            p.SetColumnType("DateTime");

                        if (p.ClrType == typeof(string))
                            p.SetMaxLength(100);

                        if (p.ClrType == typeof(decimal))
                        {
                            p.SetPrecision(12);
                            p.SetScale(2);
                        }
                    });

                // equivalente para o modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            Maps(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        private static void Maps(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AssociadoMap());
            modelBuilder.ApplyConfiguration(new PrestadorMap());
            modelBuilder.ApplyConfiguration(new ConveniadoMap());
            modelBuilder.ApplyConfiguration(new PlanoMap());
            modelBuilder.ApplyConfiguration(new EspecialidadeMap());

            modelBuilder.ApplyConfiguration(new ManifestacaoMap());
            modelBuilder.ApplyConfiguration(new ManifestacaoRespostaMap());

        }
    }
}
