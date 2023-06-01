using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DT.Infra.ExternalServices.DummyService.Contracts;

namespace DT.Infra.ExternalServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IDummyService _dummyService;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime applicationLifetime, IDummyService dummyService)
        {
            _logger = logger;
            _applicationLifetime = applicationLifetime;
            _dummyService = dummyService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("worker running at: {time}", DateTimeOffset.UtcNow);
            var test = await _dummyService.GetUsersAsync();

            _logger.LogInformation(test.desc[5].cardType);
            // await Task.Delay(1000, stoppingToken);
            _applicationLifetime.StopApplication();
        }
    }
}