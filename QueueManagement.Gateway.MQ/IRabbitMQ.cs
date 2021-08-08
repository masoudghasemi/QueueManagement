using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.MQ
{
    public interface IRabbitMQ
    {
        public IModel Model { get; }

    }
}
