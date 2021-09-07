using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.BLL.BusinessLogic.Interface
{
    public  interface IMessageTransferBL:IBL
    {

        public void TransferMessageFromQueueToSaramad();

        public void TransferMessageFromSaramatToQueue();
    }
}
