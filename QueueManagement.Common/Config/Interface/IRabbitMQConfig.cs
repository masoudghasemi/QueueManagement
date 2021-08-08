using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config
{
    public interface IRabbitMQConfig
    {
        public string UserName { get; }
        public string Password { get; }
        public int Port { get; }
        public string VirtualHost { get; }
        public string HostName { get; }


        //UserName = "admin",
        //        Password = "admin",
        //        Port = 5672,
        //        VirtualHost = "/",
        //        HostName = "localhost"
    }
}
