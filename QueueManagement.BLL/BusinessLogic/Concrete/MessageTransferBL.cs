using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.BLL.Mapping;
using QueueManagement.Common.Config.Interface;
using QueueManagement.DAL.QueueManagementDb.Entity;
using QueueManagement.DAL.QueueManagementDb.UnitOfWork;
using QueueManagement.Gateway.MQ;
using QueueManagement.Gateway.MQ.Event.Args;
using QueueManagement.Gateway.MQ.Model;
using QueueManagement.Gateway.Service.ServiceLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.BLL.BusinessLogic.Concrete
{
    public class MessageTransferBL: IMessageTransferBL
    {
        protected readonly IRabbitMQ rabbitMQ;
        protected readonly ISaramadSL  saramadSL;
        protected readonly IMapper mapper;
        protected readonly IQueueManagementUnitOfWork queueManagementUnitOfWork;
        protected readonly ICommonConfig commonConfig;


        // ////////////////////////////////////////////////////////////////////////

        public MessageTransferBL(
            IRabbitMQ rabbitMQ ,
            ISaramadSL saramadSL,
            IMapper mapper ,
            IQueueManagementUnitOfWork queueManagementUnitOfWork,
            ICommonConfig commonConfig)
        {
            this.rabbitMQ = rabbitMQ;   
            this.saramadSL = saramadSL;
            this.mapper = mapper;
            this.queueManagementUnitOfWork = queueManagementUnitOfWork;
            this.commonConfig = commonConfig;
            }

        // ////////////////////////////////////////////////////////////////////////

        public void TransferMessage()
        {
            int dadgostaryProducerId = 1;
            int saramadProducerId = 2;
            int ruleQueueId = 1;
            int ruleResponseQueueId = 2;

            var message = rabbitMQ.RecieveMessage(commonConfig.RuleQueueName);
            var messageRequest = mapper.Map(message);
            messageRequest.ProducerId = dadgostaryProducerId;
            messageRequest.QueueId = ruleQueueId;
            queueManagementUnitOfWork.MessageRepository.Add(messageRequest);
            queueManagementUnitOfWork.Save();


            var ruleServiceRequest = mapper.Map2(message);
            var ruleServiceResponse = saramadSL.SendRule(ruleServiceRequest);
            var messageResponse = mapper.Map(ruleServiceResponse);
            messageResponse.ProducerId = saramadProducerId;
            messageResponse.QueueId = ruleResponseQueueId;
            messageResponse.RelatedMessageId = messageRequest.Id;
            queueManagementUnitOfWork.MessageRepository.Add(messageResponse);
            queueManagementUnitOfWork.Save();


            rabbitMQ.SendMessage(commonConfig.RuleResponseQueueName, messageResponse.BodyBinary); 
            rabbitMQ.BasicAcc(message.DeliveryTag); 

        }
        // ////////////////////////////////////////////////////////////////////////

    }
}
