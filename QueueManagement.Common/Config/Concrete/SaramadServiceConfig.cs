using Microsoft.Extensions.Configuration;
using QueueManagement.Common.Config.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config
{
    public class SaramadServiceConfig : ISaramadServiceConfig
    {
        protected readonly IConfiguration configuration;
        public SaramadServiceConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AccessTokenUrl { get { return configuration.GetValue<string>("SaramadService:AccessTokenUrl"); } }

        public string TokenValidationUrl { get { return configuration.GetValue<string>("SaramadService:TokenValidationUrl"); } }
        public string RuleServiceUrl { get { return configuration.GetValue<string>("SaramadService:RuleServiceUrl"); } }
        public string grant_type { get { return configuration.GetValue<string>("SaramadService:Grant_Type"); } }
        public string client_id { get { return configuration.GetValue<string>("SaramadService:Client_Id"); } }
        public string client_secret { get { return configuration.GetValue<string>("SaramadService:Client_Secret"); } }
        public string scope { get { return configuration.GetValue<string>("SaramadService:Scope"); } }

    }


}

