using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config
{
    public class RabbitMQConfig :  IRabbitMQConfig
    {

        protected readonly IConfiguration configuration;
        public RabbitMQConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public string UserName { get { return configuration.GetValue<string>("RabbitMQ:UserName"); } }

        public string Password { get { return configuration.GetValue<string>("RabbitMQ:Password"); } }

        public int Port { get { return int.Parse( configuration.GetValue<string>("RabbitMQ:Port")); } }

        public string VirtualHost { get { return configuration.GetValue<string>("RabbitMQ:VirtualHost"); } }

        public string HostName { get { return configuration.GetValue<string>("RabbitMQ:HostName"); } }


        //UserName = "admin",
        //        Password = "admin",
        //        Port = 5672,
        //        VirtualHost = "/",
        //        HostName = "localhost"

    }
}
