using QueueManagement.Common.Config.Interface;
using QueueManagement.Gateway.Service.ServiceModel.Saramad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.Gateway.Service.ServiceLogic.Concrete
{
    public class SaramadSL
    {
        protected readonly ISaramadServiceConfig config;
        protected readonly IHttpClientFactory httpClientFactory;
        protected readonly HttpClient Client;
        private static GetAccessTokenResultAPIModel Token { get; set; }

        public SaramadSL
            (
            ISaramadServiceConfig saramadServiceConfig,
            IHttpClientFactory httpClientFactory
            )
        {
            this.config = saramadServiceConfig;
            this.httpClientFactory = httpClientFactory;
            this.Client = httpClientFactory.CreateClient();
            
        }




        // //////////////////////////////////////////////////////////////////////////////////////////////
        private GetAccessTokenResultAPIModel GetToken()
        {
            var url = config.AccessTokenUrl;
           // var username = config.client_id;
           //var password = config.client_secret;
           //var basicAuth = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{username}:{password}"));
           // Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuth);
            var KeyValues = new List<KeyValuePair<string, string>>();
            KeyValues.Add(new KeyValuePair<string, string>( nameof(config.client_id), config.client_id));
            KeyValues.Add(new KeyValuePair<string, string>(nameof(config.client_secret), config.client_secret));
            KeyValues.Add(new KeyValuePair<string, string>(nameof(config.grant_type), config.grant_type));
            KeyValues.Add(new KeyValuePair<string, string>(nameof(config.scope), config.scope));
            var request = new FormUrlEncodedContent(KeyValues);
            var response = Client.PostAsync(url, request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            var outputModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAccessTokenResultAPIModel>(responseContent);
            return outputModel;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////

        public int SendTask(RuleServiceRequestAPIModel input)
        {
            var url = config.RuleServiceUrl;
            input.token = Token.access_token;
            var request =  new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
            var response = Client.PostAsync(url, request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            var outputModel = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(responseContent);
            return outputModel;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////


    }
}
