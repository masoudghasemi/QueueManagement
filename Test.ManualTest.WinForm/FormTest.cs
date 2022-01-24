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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test.Test_SendMessageToRuleQueue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test.Test_RecieveMessageFromRuleResponseQueue();
        }
    }
}
