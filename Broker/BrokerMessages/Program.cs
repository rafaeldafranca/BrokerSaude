using BrokerService.IoC;
using Serilog;

namespace BrokerMessages
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
            //Log.Logger = new LoggerConfiguration()
            //                   .WriteTo.Console()
            //                   .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ConfigureMessageIoC(builder.Configuration);
            builder.Services.AddHealthChecks();
            //builder.Host.UseSerilog((ctx, lc) => lc
            //    .WriteTo.Console());

            var app = builder.Build();

            app.UseHealthChecks("/hc");
            app.Run();
        }
    }
}