
namespace Test.ManualTest.WinForm
{
    partial class MainTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Test_RecieveMessageFromRuleQueue = new System.Windows.Forms.Button();
            this.button_Test_TransferMessage = new System.Windows.Forms.Button();
            this.button_Test_SendMessageToRuleQueue = new System.Windows.Forms.Button();
            this.button_Test_TokenService = new System.Windows.Forms.Button();
            this.button_Test_RuleService = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Test_RecieveMessageFromRuleQueue
            // 
            this.button_Test_RecieveMessageFromRuleQueue.Location = new System.Drawing.Point(12, 23);
            this.button_Test_RecieveMessageFromRuleQueue.Name = "button_Test_RecieveMessageFromRuleQueue";
            this.button_Test_RecieveMessageFromRuleQueue.Size = new System.Drawing.Size(285, 23);
            this.button_Test_RecieveMessageFromRuleQueue.TabIndex = 0;
            this.button_Test_RecieveMessageFromRuleQueue.Text = "Test_RecieveMessageFromRuleQueue";
            this.button_Test_RecieveMessageFromRuleQueue.UseVisualStyleBackColor = true;
            this.button_Test_RecieveMessageFromRuleQueue.Click += new System.EventHandler(this.button_Test_RecieveMessageFromRuleQueue_Click);
            // 
            // button_Test_TransferMessage
            // 
            this.button_Test_TransferMessage.Location = new System.Drawing.Point(12, 52);
            this.button_Test_TransferMessage.Name = "button_Test_TransferMessage";
            this.button_Test_TransferMessage.Size = new System.Drawing.Size(285, 23);
            this.button_Test_TransferMessage.TabIndex = 1;
            this.button_Test_TransferMessage.Text = "Test_TransferMessage";
            this.button_Test_TransferMessage.UseVisualStyleBackColor = true;
            this.button_Test_TransferMessage.Click += new System.EventHandler(this.button_Test_TransferMessage_Click);
            // 
            // button_Test_SendMessageToRuleQueue
            // 
            this.button_Test_SendMessageToRuleQueue.Location = new System.Drawing.Point(12, 255);
            this.button_Test_SendMessageToRuleQueue.Name = "button_Test_SendMessageToRuleQueue";
            this.button_Test_SendMessageToRuleQueue.Size = new System.Drawing.Size(285, 23);
            this.button_Test_SendMessageToRuleQueue.TabIndex = 2;
            this.button_Test_SendMessageToRuleQueue.Text = "Test_SendMessageToRuleQueue";
            this.button_Test_SendMessageToRuleQueue.UseVisualStyleBackColor = true;
            this.button_Test_SendMessageToRuleQueue.Click += new System.EventHandler(this.button_Test_SendMessageToRuleQueue_Click);
            // 
            // button_Test_TokenService
            // 
            this.button_Test_TokenService.Location = new System.Drawing.Point(318, 23);
            this.button_Test_TokenService.Name = "button_Test_TokenService";
            this.button_Test_TokenService.Size = new System.Drawing.Size(297, 23);
            this.button_Test_TokenService.TabIndex = 3;
            this.button_Test_TokenService.Text = "Test_TokenService";
            this.button_Test_TokenService.UseVisualStyleBackColor = true;
            this.button_Test_TokenService.Click += new System.EventHandler(this.button_Test_TokenService_Click);
            // 
            // button_Test_RuleService
            // 
            this.button_Test_RuleService.Location = new System.Drawing.Point(318, 55);
            this.button_Test_RuleService.Name = "button_Test_RuleService";
            this.button_Test_RuleService.Size = new System.Drawing.Size(297, 23);
            this.button_Test_RuleService.TabIndex = 4;
            this.button_Test_RuleService.Text = "Test_RuleService";
            this.button_Test_RuleService.UseVisualStyleBackColor = true;
            this.button_Test_RuleService.Click += new System.EventHandler(this.button_Test_RuleService_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Test_RuleService);
            this.Controls.Add(this.button_Test_TokenService);
            this.Controls.Add(this.button_Test_SendMessageToRuleQueue);
            this.Controls.Add(this.button_Test_TransferMessage);
            this.Controls.Add(this.button_Test_RecieveMessageFromRuleQueue);
            this.Name = "MainTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Test_RecieveMessageFromRuleQueue;
        private System.Windows.Forms.Button button_Test_TransferMessage;
        private System.Windows.Forms.Button button_Test_SendMessageToRuleQueue;
        private System.Windows.Forms.Button button_Test_TokenService;
        private System.Windows.Forms.Button button_Test_RuleService;
        private System.Windows.Forms.Button button1;
    }
}

