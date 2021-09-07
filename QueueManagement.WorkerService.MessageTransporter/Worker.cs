using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QueueManagement.BLL.BusinessLogic.Interface;
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
        private readonly IMessageTransferBL _messageTransferBL;

        public Worker(ILogger<Worker> logger, IMessageTransferBL messageTransferBL )
        {
            _logger = logger;
            _messageTransferBL = messageTransferBL;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {

                _messageTransferBL.TransferMessageFromQueueToSaramad();
                await Task.Delay(1000, stoppingToken);
            }

        }
    }
}
