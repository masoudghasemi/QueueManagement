using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueManagement.Gateway.Service.ServiceLogic.Interface;
using QueueManagement.IOC;
using System;
using System.IO;

namespace Test.ManualTest
{
    class Program
    {




        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .Register()
                .BuildServiceProvider();

          

            //do the actual work here
            var saramadSL = serviceProvider.GetService<ISaramadSL>();



            StreamReader sr = new StreamReader(@"E:\M_Ghasemi\json.txt");
            var line = sr.ReadLine();

           // var ss = saramadSL.GetToken();
            var sss=saramadSL.SendRule(new QueueManagement.Gateway.Service.ServiceModel.Saramad.SavedRequestModel
            {
                ClientIPAddress="",
                RequestBody=line
                
                

            });




        }

    }


}
