using QueueManagement.BLL.BusinessLogic.Concrete;
using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.WorkerService.MessageTransporter.Operation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.WorkerService.MessageTransporter.Operation.Concrete
{
    public class MainOperation : IMainOperation
    {
        protected readonly IMessageTransferBL messageTransferBL;

        public MainOperation(MessageTransferBL messageTransferBL)
        {
            this.messageTransferBL = messageTransferBL;
        }

        public void DoActions()
        {
            messageTransferBL.TransferMessages();

        }
    }
}
