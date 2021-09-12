using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.Common.Config.Concrete;
using QueueManagement.Common.Config.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QueueManagement.WorkerService.MessageTransporter
{
    public class Worker : BackgroundService
    {
        private readonly Serilog.ILogger logger;
        private readonly IWorkerServiceConfig workerServiceConfig;
        private readonly IMessageTransferBL messageTransferBL;

        public Worker(Serilog.ILogger logger, IMessageTransferBL messageTransferBL ,IWorkerServiceConfig workerServiceConfig)
        {
            this.logger = logger;
            this.workerServiceConfig = workerServiceConfig;
            this.messageTransferBL = messageTransferBL;
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                     messageTransferBL.TransferMessage();
                }
                catch (Exception ex)
                {
                    logger.Error(ex,messageTemplate:"execption");
                }
                await Task.Delay(workerServiceConfig.Interval, stoppingToken);
            }
        }
    }
}
