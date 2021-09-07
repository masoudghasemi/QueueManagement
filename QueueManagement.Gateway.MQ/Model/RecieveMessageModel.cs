using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.MQ.Model
{
    public class RecieveMessageModel
    {

        public ReadOnlyMemory<byte> Body { get; set; }
        public ulong DeliveryTag { get; set; }

    }
}
