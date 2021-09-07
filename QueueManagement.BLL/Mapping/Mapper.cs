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
        public  SavedRequestModel Map(RecieveMessageModel message)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SavedRequestModel>(Encoding.UTF8.GetString(message.Body.ToArray()));
        }

        public Message Map2(RecieveMessageModel message)
        {
            if (message == null) return null;
            return new Message
            {
                BodyBinary=message.Body.ToArray(),
                BodyJson= Encoding.UTF8.GetString(message.Body.ToArray()),
                CreatedAt=DateTime.Now,
                Identity=Map(message).TrackingNumber,
                ProducerId=1,
                QueueId=1
            };
        }
    }
}
