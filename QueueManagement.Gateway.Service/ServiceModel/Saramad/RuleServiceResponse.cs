﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.Service.ServiceModel.Saramad
{
    public class RuleServiceResponse
    {

        public string trackingCode { get; set; }
        public string resNo { get; set; }
        public string resDesc { get; set; }


        public string resSubOrderTrackingCodes { get; set; }

    }
}
