using Framework.Util.Concrete;
using Framework.Util.Interface;
using Microsoft.Extensions.DependencyInjection;
using QueueManagement.BLL.BusinessLogic.Concrete;
using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.BLL.Mapping;
using QueueManagement.Common.Config;
using QueueManagement.Common.Config.Interface;
using QueueManagement.DAL.QueueManagementDb.Entity;
using QueueManagement.DAL.QueueManagementDb.Repository.Concrete;
using QueueManagement.DAL.QueueManagementDb.Repository.Interface;
using QueueManagement.DAL.QueueManagementDb.UnitOfWork;
using QueueManagement.Gateway.MQ;
using QueueManagement.Gateway.Service.ServiceLogic.Concrete;
using QueueManagement.Gateway.Service.ServiceLogic.Interface;
using System;

namespace QueueManagement.IOC
{
    public static class DependencyInjection
    {


        public static IServiceCollection Register(this IServiceCollection services)
        {
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
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IMessageTransferBL, MessageTransferBL>();
            return services;
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////

        private static IServiceCollection RegisterDAL(this IServiceCollection services)
        {
            services.AddScoped<QueueManagementContext, QueueManagementContext>();
            services.AddScoped<IQueueManagementUnitOfWork, QueueManagementUnitOfWork>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////


        private static IServiceCollection RegisterCommon(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQConfig, RabbitMQConfig>();
            services.AddScoped<ISaramadServiceConfig, SaramadServiceConfig>();
            return services;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////

        private static IServiceCollection RegisterFramework(this IServiceCollection services)
        {
            services.AddScoped<IDateUtil, DateUtil>();
            return services;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////


        private static IServiceCollection RegisterOthers(this IServiceCollection services)
        {
            services.AddScoped<ISaramadSL, SaramadSL>();
            services.AddScoped<IRabbitMQ, QueueManagement.Gateway.MQ.RabbitMQ>();

            return services;
        }

    }
}
