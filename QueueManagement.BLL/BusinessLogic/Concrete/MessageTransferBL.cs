using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.BLL.Mapping;
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

        public MessageTransferBL(IRabbitMQ rabbitMQ , ISaramadSL saramadSL,IMapper mapper , IQueueManagementUnitOfWork queueManagementUnitOfWork)
        {
            this.rabbitMQ = rabbitMQ;   
            this.saramadSL = saramadSL; // saramad service logic => saramad service api
           // this.MessageReceived("SendRule", true, true, false, null);  //SendRule   SendRuleStatus   SendRuleResponse
            this.mapper = mapper;
            this.queueManagementUnitOfWork = queueManagementUnitOfWork;
        }

        // ////////////////////////////////////////////////////////////////////////

        public void TransferMessageFromQueueToSaramad()
        {
            try
            {
                var message = rabbitMQ.RecieveMessage("Rule");
                var rule = mapper.Map(message);
                var resultSendRule = saramadSL.SendRule(rule);
                if (resultSendRule <= 0) return;
                var messageEntity = mapper.Map2(message);
                queueManagementUnitOfWork.MessageRepository.Add(messageEntity);// implement db layer
                queueManagementUnitOfWork.Save();
                rabbitMQ.BasicAcc(message.DeliveryTag);

            }
            catch (Exception ex)
            {

            }

           
            

        }
        // ////////////////////////////////////////////////////////////////////////

        public void TransferMessageFromSaramatToQueue()
        {

            // get response status    and responser full from temp db  or saramad service

            // send to queue

        }


        // ////////////////////////////////////////////////////////////////////////

        //public void MessageReceived(string queueName, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        //{
        //    rabbitMQ.MessageReceived(queueName, durable, exclusive, autoDelete, arguments);
        //    rabbitMQ.MessageReceivedEventHandler += (sender, e) =>
        //    {
        //        var args = (MessageReceivedEventArgs)e;

        //        // first insert message to database

        //        // second - send message to saramad



        //    };
        //}


    }
}
