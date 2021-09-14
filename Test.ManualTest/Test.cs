using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using QueueManagement.BLL.BusinessLogic.Interface;
using QueueManagement.Gateway.MQ;
using QueueManagement.Gateway.Service.ServiceLogic.Concrete;
using QueueManagement.Gateway.Service.ServiceLogic.Interface;
using QueueManagement.Gateway.Service.ServiceModel.Saramad;
using QueueManagement.IOC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.ManualTest
{
    public class Test
    {
        public static ServiceProvider serviceProvider = new ServiceCollection()
                .Register()
                .BuildServiceProvider();

        public Test()
        {
            
        }


        public static void Test_TransferMessage()
        {
            var bl = serviceProvider.GetService<IMessageTransferBL>();
            bl.TransferMessage(Guid.NewGuid());

        }

        // /////////////////////////////////////////////////////////////////////////////////////


        public static void Test_SendMessageToRuleQueue()
        {
            var rule = GetRuleServiceRequest();
            var outputMode = Newtonsoft.Json.JsonConvert.SerializeObject(rule);
            //var outputModel111 = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(outputMode);
            var rabbitMq = serviceProvider.GetService<IRabbitMQ>();
            rabbitMq.SendMessage("Rule", Encoding.UTF8.GetBytes(outputMode));
            //rabbitMq.Dispose();

        }

        // /////////////////////////////////////////////////////////////////////////////////////

        public static void Test_RecieveMessageFromRuleQueue()
        {
        
            var rabbitMq = serviceProvider.GetService<IRabbitMQ>();
            var message= rabbitMq.RecieveMessage("Rule");
            var buffer = message.Body.ToArray();
            var json = Encoding.UTF8.GetString(buffer);
            var outputModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RuleServiceResponse>(json);
            rabbitMq.BasicAcc(message.DeliveryTag);
            rabbitMq.Dispose();

        }


        // /////////////////////////////////////////////////////////////////////////////////////

        public static void Test_TokenService()
        {

            var saramadSL = serviceProvider.GetService<ISaramadSL>();
            var result = saramadSL.GetToken();
        }

        // /////////////////////////////////////////////////////////////////////////////////////

        public static void Test_RuleService()
        {
            var saramadSL = serviceProvider.GetService<ISaramadSL>();
            //  StreamReader sr = new StreamReader(@"E:\M_Ghasemi\json.txt");
            // var line = sr.ReadToEnd();
            var result = saramadSL.SendRule(GetRuleServiceRequest());
        }
        // /////////////////////////////////////////////////////////////////////////////////////

        public static RuleServiceRequest GetRuleServiceRequest()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("Title", "تست ایجاد دستور با وب سرویس"); // عنوان دستور
            DomainObjectInfos objInfos = new DomainObjectInfos();
            var listtemp = new List<Info>();
            foreach (var item in dic)
            {
                listtemp.Add(new Info() { Property = item.Key, Value = item.Value });
            }
            objInfos.Infos = listtemp.ToArray();



            var MasterFKList = new List<Dictionary<string, string>>();
            var masterFKs = new Dictionary<string, string>();
            masterFKs.Add("JCtrackingCode", "CJU0000033183936269");
            masterFKs.Add("judgeUserCode", "04550");
            masterFKs.Add("judgeStaffCode", "3542");
            masterFKs.Add("judgeExportName", "تست");
            masterFKs.Add("judgeExportStaff", "تستیان");
            masterFKs.Add("subOrderCode", "040403");
            MasterFKList.Add(masterFKs);

            //detail -second
            var PersonList = new List<Dictionary<string, string>>();
            var person1 = new Dictionary<string, string>();
            var person2 = new Dictionary<string, string>();
            person1.Add("NationalCode", "1001001001"); //کد ملی
            person2.Add("NationalCode", "2002002002"); //کد ملی
            PersonList.Add(person1);
            PersonList.Add(person2);
            List<string> list = new List<string>();
            list.Add(JsonConvert.SerializeObject(MasterFKList));
            list.Add(JsonConvert.SerializeObject(PersonList));

            var request = new RuleServiceRequest
            {
                code = "989",
                trackingCode = "2021090697000936",
                domainObjectInfos = objInfos,
                parameters = list.ToArray()
            };

            return request;

        }


    }


}
