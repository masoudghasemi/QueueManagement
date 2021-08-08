using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.DependencyInjection
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddHttpClient();

            return services;
        }

    }
}
