using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleConfiguration
{
    class Program
    {
        private static IConfiguration _appConfiguration;
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
            Console.ReadKey();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    var hostingEnvironment = hostContext.HostingEnvironment;
                    _appConfiguration = AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //注入IConfiguration到DI容器
                    services.AddSingleton(_appConfiguration);
                    //注入MyService到DI容器
                    services.AddSingleton<ITestService, TestService>();
                    services.AddHostedService<HostedService>();
                });

    }
}
