using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Common.Const
{
    public static class LogInformation
    {
        public const string ServiceStared = "Service Started";
        public const string Step1 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 1:RequestMessage Received From MQ      |    Content:{0}";
        public const string Step2 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 2:RequestMessage Saved To Database    |   Content:{0}";
        public const string Step3 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 3:Before Send RequestMessage To  Saramad RuleService   |    Content:{0}";
        public const string Step4 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 4:After Send RequestMessage To  Saramad RuleService and Get ResponseMessage    |    Content:{0}";
        public const string Step5 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 5:ResponseMessage Saved To Database     |      Content:{0}";
        public const string Step6 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 6:ResponseMessage Send To MQ    |      Content:{0}";
        public const string Step7 = "IntervalId:{IntervalId} |   Identity:{Identity}   |    Step 7:RequestMessage Removed From MQ    |     Content:{0}";

    }
}
