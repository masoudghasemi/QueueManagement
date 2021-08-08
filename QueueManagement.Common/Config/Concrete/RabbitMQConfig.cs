using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config
{
    public class RabbitMQConfig : AbstractConfig, IRabbitMQConfig
    {
        protected readonly IConfigurationSection configurationSection;
        public RabbitMQConfig(IConfiguration configuration):base(configuration)
        {
            configurationSection.GetSection("RabbitMQConfig");
        }

        public string UserName { get { return ""; } }

        public string Password { get { return ""; } }

        public int Port { get { return 0; } }

        public string VirtualHost { get { return ""; } }

        public string HostName  { get { return ""; }}


        //UserName = "admin",
        //        Password = "admin",
        //        Port = 5672,
        //        VirtualHost = "/",
        //        HostName = "localhost"

    }
}
