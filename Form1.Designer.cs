namespace HTTP_Request_GetHowKteam
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
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnGetDataCookie = new System.Windows.Forms.Button();
            this.btnPostLogin = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.btnCapcha = new System.Windows.Forms.Button();
            this.btnRecaptcha = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(12, 12);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnGetDataCookie
            // 
            this.btnGetDataCookie.Location = new System.Drawing.Point(93, 12);
            this.btnGetDataCookie.Name = "btnGetDataCookie";
            this.btnGetDataCookie.Size = new System.Drawing.Size(131, 23);
            this.btnGetDataCookie.TabIndex = 1;
            this.btnGetDataCookie.Text = "GetData_Cookie\r\n";
            this.btnGetDataCookie.UseVisualStyleBackColor = true;
            this.btnGetDataCookie.Click += new System.EventHandler(this.btnGetDataCookie_Click);
            // 
            // btnPostLogin
            // 
            this.btnPostLogin.Location = new System.Drawing.Point(230, 12);
            this.btnPostLogin.Name = "btnPostLogin";
            this.btnPostLogin.Size = new System.Drawing.Size(75, 23);
            this.btnPostLogin.TabIndex = 2;
            this.btnPostLogin.Text = "Post Login";
            this.btnPostLogin.UseVisualStyleBackColor = true;
            this.btnPostLogin.Click += new System.EventHandler(this.btnPostLogin_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(311, 12);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFile.TabIndex = 3;
            this.btnUploadFile.Text = "Upload File";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // btnCapcha
            // 
            this.btnCapcha.Location = new System.Drawing.Point(393, 11);
            this.btnCapcha.Name = "btnCapcha";
            this.btnCapcha.Size = new System.Drawing.Size(116, 23);
            this.btnCapcha.TabIndex = 4;
            this.btnCapcha.Text = "Normal Capcha Vtc";
            this.btnCapcha.UseVisualStyleBackColor = true;
            this.btnCapcha.Click += new System.EventHandler(this.btnCapcha_Click);
            // 
            // btnRecaptcha
            // 
            this.btnRecaptcha.Location = new System.Drawing.Point(516, 11);
            this.btnRecaptcha.Name = "btnRecaptcha";
            this.btnRecaptcha.Size = new System.Drawing.Size(154, 23);
            this.btnRecaptcha.TabIndex = 5;
            this.btnRecaptcha.Text = "Recaptchar-ThayTrucTuyen";
            this.btnRecaptcha.UseVisualStyleBackColor = true;
            this.btnRecaptcha.Click += new System.EventHandler(this.btnRecaptcha_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRecaptcha);
            this.Controls.Add(this.btnCapcha);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.btnPostLogin);
            this.Controls.Add(this.btnGetDataCookie);
            this.Controls.Add(this.btnGetData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnGetDataCookie;
        private System.Windows.Forms.Button btnPostLogin;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Button btnCapcha;
        private System.Windows.Forms.Button btnRecaptcha;
    }
}

