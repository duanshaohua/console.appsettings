using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ConsoleConfiguration
{
    public class HostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ITestService _testService;

        public HostedService(
            IHostApplicationLifetime hostApplicationLifetime,
            ITestService testService
            )
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _testService = testService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _testService.PrintMessage();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
