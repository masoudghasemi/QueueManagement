using QueueManagement.Gateway.MQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.BLL.BusinessLogic.Concrete
{
    public class QueueBL
    {
        protected readonly IRabbitMQ rabbitMQ;

        public QueueBL(IRabbitMQ rabbitMQ)
        {
            this.rabbitMQ = rabbitMQ;
            
        }


        public void PublishMessage(string message)
        {
           
        }


        public void ReceiveMessage(string rutingKey,string Message)
        {
            var recieved = new EventingBasicConsumer(this.rabbitMQ.Model);
            recieved.Received += Recieved_Received;
        }

        private void Recieved_Received(object sender, BasicDeliverEventArgs e)
        {
           
        }




    }
}
