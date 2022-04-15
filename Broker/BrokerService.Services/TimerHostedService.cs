using Microsoft.Extensions.Hosting;
using Serilog;

namespace BrokerService.Services
{
    public class TimerHostedService : IHostedService
    {
        private DateTime UltimoAcesso = DateTime.Now;

        public TimerHostedService()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromHours(3));
            return Task.CompletedTask;
        }

        private void ExecuteProcess(object state)
        {
            Log.Information($"### Proccess executing ###");
            Log.Information($"{UltimoAcesso}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            UltimoAcesso = DateTime.Now;
            Log.Information("### Proccess stoping ###");
            Log.Information($"{UltimoAcesso}");
            return Task.CompletedTask;
        }
    }
}
