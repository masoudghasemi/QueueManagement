using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueManagement.IOC;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueueManagement.WorkerService.MessageTransporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .UseSerilog()
            .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.Register();

                });
    }
}
