using QueueManagement.Gateway.MQ.Model;
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
        public void SendMessage(string queue, ReadOnlyMemory<byte> body);

        public RecieveMessageModel RecieveMessage(string queue);

        public void BasicAcc(ulong deliveryTag);


    }
}
