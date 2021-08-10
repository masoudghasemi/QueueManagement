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
        public bool MessageReceived(string queueName, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments);
        public bool PublishMessage(string exchange, string routingKey, bool mandatory = false, IBasicProperties basicProperties = null, ReadOnlyMemory<byte> body = default);

        public event EventHandler MessageReceivedEventHandler;


    }
}
