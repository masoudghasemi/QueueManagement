using Microsoft.Extensions.Configuration;
using QueueManagement.Common.Config.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config.Concrete
{
    public  class ConnectionStringConfig : IConnectionStringConfig
    {
        protected readonly IConfiguration configuration;
        public ConnectionStringConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public string QueueManagmenetDb { get { return configuration.GetValue<string>("ConnectionStrings:QueueManagmenetDb"); } }
    }
}
