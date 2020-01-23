namespace WindowsForms_Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ReceiveMsg = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.Msg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClientLIst = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Log = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ReceiveMsg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Msg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 341);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息区";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReceiveMsg
            // 
            this.ReceiveMsg.HideSelection = false;
            this.ReceiveMsg.Location = new System.Drawing.Point(6, 126);
            this.ReceiveMsg.Name = "ReceiveMsg";
            this.ReceiveMsg.Size = new System.Drawing.Size(416, 209);
            this.ReceiveMsg.TabIndex = 1;
            this.ReceiveMsg.UseCompatibleStateImageBehavior = false;
            this.ReceiveMsg.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "接收消息";
            // 
            // Msg
            // 
            this.Msg.Location = new System.Drawing.Point(109, 42);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(201, 28);
            this.Msg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入消息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClientLIst);
            this.groupBox2.Location = new System.Drawing.Point(461, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 341);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务端IP";
            // 
            // ClientLIst
            // 
            this.ClientLIst.HideSelection = false;
            this.ClientLIst.Location = new System.Drawing.Point(6, 27);
            this.ClientLIst.Name = "ClientLIst";
            this.ClientLIst.Size = new System.Drawing.Size(283, 308);
            this.ClientLIst.TabIndex = 0;
            this.ClientLIst.UseCompatibleStateImageBehavior = false;
            this.ClientLIst.View = System.Windows.Forms.View.List;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Log);
            this.groupBox3.Location = new System.Drawing.Point(4, 371);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(746, 185);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志显示";
            // 
            // Log
            // 
            this.Log.HideSelection = false;
            this.Log.Location = new System.Drawing.Point(9, 27);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(731, 152);
            this.Log.TabIndex = 0;
            this.Log.UseCompatibleStateImageBehavior = false;
            this.Log.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = " 客户端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ReceiveMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Msg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView ClientLIst;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView Log;
    }
}

