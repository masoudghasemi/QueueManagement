using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config.Interface
{
    public    interface ISaramadServiceConfig
    {



        public string AccessTokenUrl { get; }

        public string TokenValidationUrl { get; }
        public string RuleServiceUrl { get; }
        public string grant_type { get; }
        public string client_id { get; }
        public string client_secret { get; }
        public string scope { get; }

    }
}
