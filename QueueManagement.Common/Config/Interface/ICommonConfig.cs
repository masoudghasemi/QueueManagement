﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Config.Interface
{
    public interface ICommonConfig
    {

        public string RuleQueueName { get; }

        public string RuleResponseQueueName { get; }


    }
}
