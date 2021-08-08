using QueueManagement.Common.Config;
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

        // /////////////////////////////////////////////////////////////////////////////

        public RabbitMQ(IRabbitMQConfig rabbitMQConfig)
        {
            this.rabbitMQConfig = rabbitMQConfig;
            this.model = CreateModel();
        }

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


        public IModel Model { get { return model; } }

        public bool QueueDeclare(string queueName, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            try
            {
                model.QueueDeclare(
                queue: queueName,
                 durable: durable,
                 exclusive: exclusive,
                 autoDelete: autoDelete,
                 arguments: arguments);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //// /////////////////////////////////////////////////////////////////////////////

        public bool BasicPublish(string exchange, string routingKey, IBasicProperties basicProperties, ReadOnlyMemory<byte> body)
        {
            try
            {
                model.BasicPublish(
                   exchange: exchange,
                   routingKey: routingKey,
                   basicProperties: basicProperties,
                   body: body);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool PublishMessage(string exchange, string routingKey, bool mandatory = false, IBasicProperties basicProperties = null, ReadOnlyMemory<byte> body = default)
        {
            try
            {
                model.BasicPublish(
                   exchange: exchange,
                   routingKey: routingKey,
                   mandatory:mandatory,
                   basicProperties: basicProperties,
                   body: body);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public bool ReceivedMessage(string queueName,bool durable,bool exclusive,bool autoDelete,IDictionary<string,object> arguments)
        {
            try
            {
                model.QueueDeclare(
                    queue: queueName,
                    durable: durable,
                    exclusive: exclusive,
                    autoDelete: autoDelete,
                    arguments: arguments);

                var eventHandler = new EventingBasicConsumer(model);
                eventHandler.Received += EventHandler_Received;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void EventHandler_Received(object sender, BasicDeliverEventArgs e)
        {
            
        }
    }

}
