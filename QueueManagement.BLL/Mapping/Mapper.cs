using QueueManagement.DAL.QueueManagementDb.Entity;
using QueueManagement.Gateway.MQ.Model;
using QueueManagement.Gateway.Service.ServiceModel.Saramad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.BLL.Mapping
{
    public  class Mapper: IMapper
    {

        public Message Map(MessageModel message)
        {
            if (message == null) return null;
            return new Message
            {
                BodyBinary = message.Body.ToArray(),
                BodyJson = Encoding.UTF8.GetString(message.Body.ToArray()),
                InsertedAt = DateTime.Now,
            };
        }



        public RuleServiceRequest Map2(MessageModel message)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RuleServiceRequest>(Encoding.UTF8.GetString(message.Body.ToArray()));
        }



        public Message Map(RuleServiceResponse response)
        {
            if (response == null) return null;
            return new Message
            {
                Identity=response.trackingCode,
                BodyBinary =Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(response)),
                BodyJson = Newtonsoft.Json.JsonConvert.SerializeObject(response),
                InsertedAt = DateTime.Now,
            };
        }



        
    }
}
