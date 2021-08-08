using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.Service.ServiceModel.Saramad
{
    public class SavedRequestModel
    {
        public int Id { get; set; }
        public int RequestStatusId { get; set; }
        public RequestStatusEnum RequestStatus => (RequestStatusEnum)RequestStatusId;
        public string RequestBody { get; set; }
        public RuleServiceRequestModel RequestBodyObject => JsonSerializer.Deserialize<RuleServiceRequestModel>(RequestBody);
        public DateTime ReceivedDate { get; set; }
        public string TrackingNumber { get; set; }
        public bool IsSentToRuleService { get; set; }
        public string FinalResult { get; set; }
        public string ClientIPAddress { get; set; }
    }
}
