using Framework.Util.Concrete;
using Framework.Util.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueManagement.BLL.BusinessLogic.Concrete;
using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.BLL.Mapping;
using QueueManagement.Common.Config;
using QueueManagement.Common.Config.Concrete;
using QueueManagement.Common.Config.Interface;
using QueueManagement.DAL.QueueManagementDb.Entity;
using QueueManagement.DAL.QueueManagementDb.Repository.Concrete;
using QueueManagement.DAL.QueueManagementDb.Repository.Interface;
using QueueManagement.DAL.QueueManagementDb.UnitOfWork;
using QueueManagement.Gateway.MQ;
using QueueManagement.Gateway.Service.ServiceLogic.Concrete;
using QueueManagement.Gateway.Service.ServiceLogic.Interface;
using Serilog;
using System;

namespace QueueManagement.IOC
{
    public static class DependencyInjection
    {




        // ///////////////////////////////////////////////////////////////////////////////////////////

        public static IServiceCollection Register(this IServiceCollection services)
        {
            // config service
            var builder = new ConfigurationBuilder() .AddJsonFile("appsettings.json"); 
            IConfiguration configuration = builder.Build();
            services.AddSingleton<IConfiguration>(_ => configuration);

            // serilog service
            services.AddSingleton<Serilog.ILogger>(x =>
            {
                return new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    configuration["Serilog:ConnectionString"], 
                    configuration["Serilog:TableName"], 
                    autoCreateSqlTable: true)
                .CreateLogger();
            });


            // dbContext service
            services.AddDbContext<QueueManagementContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("QueueManagementDb")),
                ServiceLifetime.Singleton
                 );



            services.AddHttpClient();
            services.RegisterBLL();
            services.RegisterDAL();
            services.RegisterCommon();
            services.RegisterFramework();
            services.RegisterOthers();
            return services;
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////

        private static IServiceCollection RegisterBLL(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
            services.AddSingleton<IMessageTransferBL, MessageTransferBL>();
            return services;
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////

        private static IServiceCollection RegisterDAL(this IServiceCollection services)
        {
           // services.AddSingleton<QueueManagementContext, QueueManagementContext>();
            services.AddSingleton<IQueueManagementUnitOfWork, QueueManagementUnitOfWork>();
            services.AddSingleton<IMessageRepository, MessageRepository>();

            return services;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////


        private static IServiceCollection RegisterCommon(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQConfig, RabbitMQConfig>();
            services.AddSingleton<ISaramadServiceConfig, SaramadServiceConfig>();
            services.AddSingleton<IWorkerServiceConfig, WorkerServiceConfig>();


            return services;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////

        private static IServiceCollection RegisterFramework(this IServiceCollection services)
        {
            services.AddSingleton<IDateUtil, DateUtil>();

            return services;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////


        private static IServiceCollection RegisterOthers(this IServiceCollection services)
        {
            services.AddSingleton<ISaramadSL, SaramadSL>();
            services.AddSingleton<IRabbitMQ, QueueManagement.Gateway.MQ.RabbitMQ>();
            services.AddSingleton<ICommonConfig, CommonConfig>();

            return services;
        }

    }
}
