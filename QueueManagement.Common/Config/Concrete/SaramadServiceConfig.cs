using Microsoft.Extensions.Configuration;
using QueueManagement.Common.Config.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config
{
    public class SaramadServiceConfig :/*AbstractConfig,*/ ISaramadServiceConfig
    {
        //protected readonly IConfigurationSection configurationSection;
        //public SaramadServiceConfig(IConfiguration configuration) : base(configuration)
        //{
        //    configurationSection.GetSection("SaramadServiceConfig");
        //}



        public string AccessTokenUrl { get { return "https://saramad-test.kashef.ir/auth/connect/token"; } }

        public string TokenValidationUrl { get { return "https://saramad-test.kashef.ir/auth/connect/introspect"; } }
        public string RuleServiceUrl { get { return "https://saramad-test.kashef.ir/workflow/api/RayBPMSService/InvokeRuleService"; } }

        public string grant_type { get { return "client_credentials"; } }
        public string client_id { get { return "api1"; } }
        public string client_secret { get { return "secret"; } }
        public string scope { get { return "IDPClients"; } }

    }


}

