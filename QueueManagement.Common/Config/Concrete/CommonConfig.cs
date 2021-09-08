using Microsoft.Extensions.Configuration;
using QueueManagement.Common.Config.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config.Concrete
{
    public class CommonConfig :ICommonConfig
    {

        protected readonly IConfiguration configuration;
        public CommonConfig(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }


        public string RuleQueueName { get { return configuration.GetValue<string>("Common:RuleQueueName"); } }

        public string RuleResponseQueueName { get { return configuration.GetValue<string>("Common:RuleResponseQueueName"); } }

    }
}
