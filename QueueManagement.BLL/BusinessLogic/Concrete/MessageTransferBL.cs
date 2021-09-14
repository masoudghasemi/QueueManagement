using Newtonsoft.Json;
using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.BLL.Mapping;
using QueueManagement.Common.Config.Interface;
using QueueManagement.Common.Const;
using QueueManagement.Common.Enum;
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
        private readonly Serilog.ILogger logger;

        protected readonly int dadgostariProducerId;
        protected readonly int saramadProducerId;
        protected readonly int ruleQueueId;
        protected readonly int ruleResponseQueueId;
        // ////////////////////////////////////////////////////////////////////////

        public MessageTransferBL(
            IRabbitMQ rabbitMQ ,
            ISaramadSL saramadSL,
            IMapper mapper ,
            IQueueManagementUnitOfWork queueManagementUnitOfWork,
            ICommonConfig commonConfig,
            Serilog.ILogger logger)
        {
            this.rabbitMQ = rabbitMQ;   
            this.saramadSL = saramadSL;
            this.mapper = mapper;
            this.queueManagementUnitOfWork = queueManagementUnitOfWork;
            this.commonConfig = commonConfig;
            this.logger = logger;

            this.dadgostariProducerId = (int)ProducerEnum.Dadgostari;
            this.saramadProducerId = (int)ProducerEnum.Saramad;
            this.ruleQueueId = (int)QueueEnum.Rule;
            this.ruleResponseQueueId = (int)QueueEnum.RuleResponse;

        }

        // ////////////////////////////////////////////////////////////////////////

        public void TransferMessage(Guid intervalId)
        {
            var message = rabbitMQ.RecieveMessage(commonConfig.RuleQueueName);
            if (message == null) return;

            var messageRequest = mapper.Map(message);
            logger.Information(LogInformation.Step1,intervalId, messageRequest.Identity,messageRequest.BodyJson );
            messageRequest.ProducerId = this.dadgostariProducerId;
            messageRequest.QueueId = this.ruleQueueId;
            queueManagementUnitOfWork.MessageRepository.Add(messageRequest);
            queueManagementUnitOfWork.Save();
            logger.Information(LogInformation.Step2, intervalId, messageRequest.Identity, messageRequest.BodyJson);

            var ruleServiceRequest = mapper.Map2(message);
            logger.Information(LogInformation.Step3, intervalId, ruleServiceRequest.trackingCode,JsonConvert.SerializeObject(ruleServiceRequest));
            var ruleServiceResponse = saramadSL.SendRule(ruleServiceRequest);
            ruleServiceResponse.trackingCode = ruleServiceRequest.trackingCode;
            logger.Information(LogInformation.Step4, intervalId, ruleServiceResponse.trackingCode, JsonConvert.SerializeObject(ruleServiceResponse));

            var messageResponse = mapper.Map(ruleServiceResponse);
            messageResponse.ProducerId = this.saramadProducerId;
            messageResponse.QueueId = this.ruleResponseQueueId;
            messageResponse.RelatedMessageId = messageRequest.Id;
            queueManagementUnitOfWork.MessageRepository.Add(messageResponse);
            queueManagementUnitOfWork.Save();
            logger.Information(LogInformation.Step5, intervalId, messageResponse.Identity, messageResponse.BodyJson);


            rabbitMQ.SendMessage(commonConfig.RuleResponseQueueName, messageResponse.BodyBinary);
            logger.Information(LogInformation.Step6, intervalId, messageResponse.Identity, messageResponse.BodyJson);

            rabbitMQ.BasicAcc(message.DeliveryTag);
            logger.Information(LogInformation.Step7, intervalId, messageRequest.Identity, messageRequest.BodyJson);

        }
        // ////////////////////////////////////////////////////////////////////////

    }
}
