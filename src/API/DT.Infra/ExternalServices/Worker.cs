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
            _logger.LogInformation("Initializing Dummy API requests");

            _logger.LogInformation("getting users...");
            var users = await _dummyService.GetUsersAsync();

            _logger.LogInformation("getting posts...");
            var posts = await _dummyService.GetPostsAsync();

            _logger.LogInformation("getting todos...");
            var todos = await _dummyService.GetTodosAsync();

            _logger.LogInformation("filling database ...");

            _logger.LogInformation("creating users ...");
            _logger.LogInformation(users.desc[0].firstName);
            // _userRepository.CreateRangeAsync();

            // await Task.Delay(1000, stoppingToken);
            _applicationLifetime.StopApplication();
        }
    }
}