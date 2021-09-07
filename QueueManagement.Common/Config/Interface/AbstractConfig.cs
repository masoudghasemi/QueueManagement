using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config
{
    public abstract class AbstractConfig
    {
        protected IConfiguration configuration;
        public AbstractConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
