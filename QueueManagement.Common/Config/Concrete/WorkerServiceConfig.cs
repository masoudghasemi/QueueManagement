using Microsoft.Extensions.Configuration;
using QueueManagement.Common.Config.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config.Concrete
{
    public class WorkerServiceConfig : IWorkerServiceConfig
    {
        protected readonly IConfiguration configuration;
        public WorkerServiceConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public int Interval { get { return 60*1000*(configuration.GetValue<int>("WorkerService:Interval")); } }
    }
}
