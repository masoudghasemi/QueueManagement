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

        public TokenResponse GetToken();
        public Task<TokenResponse> GetTokenAsync();

        public RuleServiceResponse SendRule(RuleServiceRequest input);
        public  Task<RuleServiceResponse> SendRuleAsync(RuleServiceRequest input);

    }
}
