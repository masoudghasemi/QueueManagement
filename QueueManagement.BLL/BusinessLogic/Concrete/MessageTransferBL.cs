using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.Gateway.MQ;
using QueueManagement.Gateway.MQ.Event.Args;
using QueueManagement.Gateway.Service.ServiceLogic.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

        public MessageTransferBL(IRabbitMQ rabbitMQ , ISaramadSL saramadSL)
        {
            this.rabbitMQ = rabbitMQ;
            this.saramadSL = saramadSL;
            
        }

        // ////////////////////////////////////////////////////////////////////////


        public void TransferMessages()
        {
            this.TransferMessageFromQueueToSaramad();
            this.TransferMessageFromSaramatToQueue();
        }
        // ////////////////////////////////////////////////////////////////////////

        public void TransferMessageFromQueueToSaramad()
        {
            var message = this.ReceiveMessageFromQueue();
            var result = this.SendMessageToSaramad(message);


        }
        // ////////////////////////////////////////////////////////////////////////

        public void TransferMessageFromSaramatToQueue()
        {

        }
        // ////////////////////////////////////////////////////////////////////////

        public void ReceiveMessageFromQueue(string queueName, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            rabbitMQ.MessageReceived(queueName, durable, exclusive, autoDelete, arguments);
            rabbitMQ.MessageReceivedEventHandler += (sender, e) =>
            {
                var args = (MessageReceivedEventArgs)e;

            };
        }
        // ////////////////////////////////////////////////////////////////////////
        public byte[] ReceiveMessageFromSaramad()
        {

            return null;
        }

        // ////////////////////////////////////////////////////////////////////////
        public void SendMessageToQueue(byte[] message)
        {

        }
        // ////////////////////////////////////////////////////////////////////////
        public void SendMessageToSaramad(byte[] message)
        {

        }

        // ////////////////////////////////////////////////////////////////////////






        // ////////////////////////////////////////////////////////////////////////
        //public void PublishMessage(string exchange, string routingKey, bool mandatory = false, IBasicProperties basicProperties = null, ReadOnlyMemory<byte> body = default)
        //{

        //}
        //// ////////////////////////////////////////////////////////////////////////

        //public void ReceiveMessage(string queueName, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        //{



        //}
        // ////////////////////////////////////////////////////////////////////////




    }
}
