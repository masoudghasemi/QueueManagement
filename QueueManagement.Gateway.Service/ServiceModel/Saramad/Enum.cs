using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.Service.ServiceModel.Saramad
{
    public enum RequestStatusEnum
    {
        [Display(Description = "دریافت شده، در انتظار ارسال")]
        Received = 1,
        [Display(Description = "با موفقیت ارسال شده")]
        SentSuccessfully = 2,
        [Display(Description = "فراخوانی API با خطا مواجه شده")]
        SentEncounteredWithError = 3,
        [Display(Description = "خطای ناموفق در انجام عملیات")]
        SentSuccessfullyWithOperationError = 4
    }
}

