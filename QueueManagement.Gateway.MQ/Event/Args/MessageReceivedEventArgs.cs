using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.MQ.Event.Args
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public byte[] Message { get; set; }
    }
}
