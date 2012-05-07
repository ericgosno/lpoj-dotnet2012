namespace CompilerDotNet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnRun = new System.Windows.Forms.Button();
            this.TxtLog = new System.Windows.Forms.RichTextBox();
            this.TmrRun = new System.Windows.Forms.Timer(this.components);
            this.TmrCheckThread = new System.Windows.Forms.Timer(this.components);
            this.TmrCheckLog = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BtnRun
            // 
            this.BtnRun.Location = new System.Drawing.Point(12, 12);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(103, 40);
            this.BtnRun.TabIndex = 0;
            this.BtnRun.Text = "&Run";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // TxtLog
            // 
            this.TxtLog.Location = new System.Drawing.Point(15, 58);
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.Size = new System.Drawing.Size(422, 238);
            this.TxtLog.TabIndex = 1;
            this.TxtLog.Text = "";
            this.TxtLog.TextChanged += new System.EventHandler(this.TxtLog_TextChanged);
            // 
            // TmrRun
            // 
            this.TmrRun.Tick += new System.EventHandler(this.TmrRun_Tick);
            // 
            // TmrCheckThread
            // 
            this.TmrCheckThread.Interval = 1000;
            this.TmrCheckThread.Tick += new System.EventHandler(this.TmrCheckThread_Tick);
            // 
            // TmrCheckLog
            // 
            this.TmrCheckLog.Enabled = true;
            this.TmrCheckLog.Tick += new System.EventHandler(this.TmrCheckLog_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 308);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.BtnRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.RichTextBox TxtLog;
        private System.Windows.Forms.Timer TmrRun;
        private System.Windows.Forms.Timer TmrCheckThread;
        private System.Windows.Forms.Timer TmrCheckLog;
    }
}

