using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.ManualTest.WinForm
{
    public partial class MainTest : Form
    {
        public MainTest()
        {
            InitializeComponent();
        }

        private void button_Test_RecieveMessageFromRuleQueue_Click(object sender, EventArgs e)
        {
            Test.Test_RecieveMessageFromRuleQueue();
        }

        private void button_Test_TransferMessage_Click(object sender, EventArgs e)
        {
            Test.Test_TransferMessage();
        }

        private void button_Test_SendMessageToRuleQueue_Click(object sender, EventArgs e)
        {
            Test.Test_SendMessageToRuleQueue();
        }

        private void button_Test_TokenService_Click(object sender, EventArgs e)
        {
            Test.Test_TokenService();
        }

        private void button_Test_RuleService_Click(object sender, EventArgs e)
        {
            Test.Test_RuleService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             var str0 = "{\"resNo\":\"1\",\"resDesc\":\"OK\",\"resSubOrderTrackingCodes\":\"[\\\"SJU0400062327457969\\\",\\\"SJU0400062307860047\\\"]\"}";
            var str = "\"{\\\"resNo\\\":\\\"1\\\",\\\"resDesc\\\":\\\"OK\\\",\\\"resSubOrderTrackingCodes\\\":\\\"[\\\\\\\"SJU0400062359014211\\\\\\\",\\\\\\\"SJU0400062349519301\\\\\\\"]\\\"}\"";
            str = str.Substring(1, str.Length - 2).Replace("\\\"", "\"").Replace("\\\\\"", "\\\"");
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<objtest>(str);
            var obj2= Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(obj.resSubOrderTrackingCodes);
        }



    }

    public class objtest
    {
        public string trackingCode { get; set; }

        public string resNO { get; set; }
        public string resDesc { get; set; }

        public string resSubOrderTrackingCodes { get; set; }

    }

    
}
