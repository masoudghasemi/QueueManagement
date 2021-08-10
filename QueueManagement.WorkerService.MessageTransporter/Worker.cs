using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QueueManagement.WorkerService.MessageTransporter.Operation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QueueManagement.WorkerService.MessageTransporter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        protected readonly IMainOperation mainOperation;

        public Worker(ILogger<Worker> logger, IMainOperation mainOperation)
        {
            _logger = logger;
            this.mainOperation = mainOperation;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                mainOperation.DoActions();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
