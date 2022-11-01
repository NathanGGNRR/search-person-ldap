using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Diiage.Directory.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
#if DEBUG
                    logging.AddDebug();
#endif
                    logging.AddEventLog(options =>
                    {
                        options.SourceName = "Diiage-Directory";
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
        webBuilder.ConfigureAppConfiguration(config =>
        {
            var settings = config.Build();
            var connectionString = "Endpoint=https://projet4config.azconfig.io;Id=yRnM-lw-s0:SGEu7vSDSg4Nv9K3P++b;Secret=1TNmgn55sjd23nngBJCqUOOQPtRxvIU2YsOwDwHTka4=";



            config.AddAzureAppConfiguration(options =>
            {
                options.Connect(connectionString)
                .ConfigureKeyVault(kv =>
                {
                    kv.SetCredential(new DefaultAzureCredential());
                });
            });
        }).UseStartup<Startup>());
    }
}
