using BrokerService.Core.Data.Contexts;
using BrokerService.Core.Data.Repositories;
using BrokerService.Domain.Interfaces.Repositories;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services;
using BrokerService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrokerService.IoC
{
    public static class Injections
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            string cn = Environment.GetEnvironmentVariable("APP_CONNECTIONSTRING");
            if (string.IsNullOrEmpty(cn))
                cn = configuration.GetSection("APP_CONNECTIONSTRING").Value;
            
            services.AddTransient<ITokenService, TokenService>();

            // services...
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IAssociadoService, AssociadoService>();
            services.AddScoped<IConveniadoService, ConveniadoService>();
            services.AddScoped<IPrestadorService, PrestadorService>();

            services.AddScoped<IManifestacaoService, ManifestacaoService>();
            services.AddScoped<IManifestacaoRespostaService, ManifestacaoRespostaService>();
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IEspecialidadeService, EspecialidadeService>();

            services.AddScoped<IMessageService, MessageService>();

            // repos...
            services.AddTransient<IUsuarioRepo, UsuarioRepo>();
            services.AddTransient<IAssociadoRepo, AssociadoRepo>();
            services.AddTransient<IConveniadoRepo, ConveniadoRepo>();
            services.AddTransient<IPrestadorRepo, PrestadorRepo>();

            services.AddTransient<IPlanoRepo, PlanoRepo>();
            services.AddTransient<IEspecialidadeRepo, EspecialidadeRepo>();
            services.AddTransient<IManifestacaoRepo, ManifestacaoRepo>();
            services.AddTransient<IManifestacaoRespostaRepo, ManifestacaoRespostaRepo>();

            //EF...
            services.AddDbContext<DbContext, AplicacaoContext>(opt => opt
                    .UseSqlServer(cn, options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    }
                    ).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

        }

        public static void ConfigureMessageIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<ConsumerService>();
            services.AddHostedService<TimerHostedService>();
        }

    }
}