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
    public interface IMapper
    {

        public Message Map(MessageModel message);
        public RuleServiceRequest Map2(MessageModel message);


        public Message Map(RuleServiceResponse response);
    }
}
