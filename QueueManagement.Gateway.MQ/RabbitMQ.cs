using QueueManagement.Common.Config;
using QueueManagement.Gateway.MQ.Event.Args;
using QueueManagement.Gateway.MQ.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.MQ
{
    public class RabbitMQ: IRabbitMQ
    {
        protected readonly IRabbitMQConfig rabbitMQConfig;
        protected IModel model;
        protected IConnection connection;
        protected IBasicProperties basicProperties;



        // /////////////////////////////////////////////////////////////////////////////

        public RabbitMQ(IRabbitMQConfig rabbitMQConfig)
        {
            this.rabbitMQConfig = rabbitMQConfig;
            this.model = CreateModel();

            this.basicProperties = model.CreateBasicProperties();
            this.basicProperties.Persistent = true;
        }

        // /////////////////////////////////////////////////////////////////////////////

        protected IModel Model { get { return model; } }


        // /////////////////////////////////////////////////////////////////////////////

        private IConnectionFactory CreateConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory
            {
                UserName = this.rabbitMQConfig.UserName,
                Password = this.rabbitMQConfig.Password,
                Port = this.rabbitMQConfig.Port,
                VirtualHost = this.rabbitMQConfig.VirtualHost,
                HostName = this.rabbitMQConfig.HostName
            };
            connectionFactory.DispatchConsumersAsync = true;
            return connectionFactory;
        }
        // /////////////////////////////////////////////////////////////////////////////

        private IConnection CreateConnection()
        {
            var connectionFactory = CreateConnectionFactory();
            var connection = connectionFactory.CreateConnection();
            this.connection = connection;
            return connection;

        }
        // /////////////////////////////////////////////////////////////////////////////

        private IModel CreateModel()
        {
            var connection = CreateConnection();
            var model = connection.CreateModel();
            return model;
        }


        // /////////////////////////////////////////////////////////////////////////////



        public bool QueueDeclare(string queueName)
        {
            try { 
                var result=model.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //// /////////////////////////////////////////////////////////////////////////////

        public void SendMessage(string queue,ReadOnlyMemory<byte> body)
        {
           // this.QueueDeclare(queue);
                model.BasicPublish(
                   exchange: "",
                   routingKey: queue,
                   basicProperties: basicProperties,
                   body: body);

        }
        //// /////////////////////////////////////////////////////////////////////////////


        public MessageModel RecieveMessage(string queue)
        {
           // this.QueueDeclare(queue);
            var basicGetResult = model.BasicGet(queue,false);
            if (basicGetResult == null) return null;
            return new MessageModel
            {
                Body = basicGetResult.Body,
                DeliveryTag = basicGetResult.DeliveryTag
            };
        }

        //// /////////////////////////////////////////////////////////////////////////////

        public void BasicAcc(ulong deliveryTag)
        {
            model.BasicAck(deliveryTag,false);
        }

        //// /////////////////////////////////////////////////////////////////////////////
        public void Dispose()
        {
            if (model.IsOpen)
                model.Close();
            if (connection.IsOpen)
                connection.Close();
        }


        //public bool MessageReceived(string queueName,bool durable,bool exclusive,bool autoDelete,IDictionary<string,object> arguments)
        //{
        //    try
        //    {
        //        model.QueueDeclare(
        //            queue: queueName,
        //            durable: durable,
        //            exclusive: exclusive,
        //            autoDelete: autoDelete,
        //            arguments: arguments);

        //        var eventHandler = new EventingBasicConsumer(model);
        //        eventHandler.Received += (sender, e) => {
        //            var eventArgs = new MessageReceivedEventArgs
        //            {
        //                Message = e.Body.ToArray()
        //             };
        //            this.OnMessageReceived(eventArgs);
        //        };
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public event EventHandler MessageReceivedEventHandler;
        //protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        //{
        //    EventHandler handler = MessageReceivedEventHandler;
        //    handler?.Invoke(this, e);
        //}
    }


}
