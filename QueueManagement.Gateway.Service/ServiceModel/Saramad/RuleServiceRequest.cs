using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.Service.ServiceModel.Saramad
{
    public class RuleServiceRequest
    {

        //public string receivedDate { get; set; }
        //public string ipAddress { get; set; }
        public string trackingCode { get; set; }
        public string code { get; set; }
        public DomainObjectInfos domainObjectInfos { get; set; }
        public string token { get; set; }
        public string[] parameters { get; set; }

    }
}
