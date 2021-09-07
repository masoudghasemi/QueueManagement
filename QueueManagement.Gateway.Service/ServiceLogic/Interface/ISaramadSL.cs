using QueueManagement.Gateway.Service.ServiceModel.Saramad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.Service.ServiceLogic.Interface
{
    public interface ISaramadSL
    {

        public GetAccessTokenResultAPIModel GetToken();

        public int SendRule(SavedRequestModel input);
        //public Task<int> SendRuleAsync(RuleServiceRequestAPIModel input);

    }
}
