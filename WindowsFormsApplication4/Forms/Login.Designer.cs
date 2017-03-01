namespace WordConverter_v2.Forms
{
    partial class Login
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
            this.UserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.loginBtn = new System.Windows.Forms.Button();
            this.kojinRdo = new System.Windows.Forms.RadioButton();
            this.fukusuRdo = new System.Windows.Forms.RadioButton();
            this.dbConnectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(82, 17);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(273, 19);
            this.UserId.TabIndex = 1;
            this.UserId.Validated += new System.EventHandler(this.UserId_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "ユーザーID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.loginBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.loginBtn.Location = new System.Drawing.Point(106, 96);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(161, 25);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "ログイン";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // kojinRdo
            // 
            this.kojinRdo.AutoSize = true;
            this.kojinRdo.Checked = true;
            this.kojinRdo.Location = new System.Drawing.Point(101, 58);
            this.kojinRdo.Name = "kojinRdo";
            this.kojinRdo.Size = new System.Drawing.Size(71, 16);
            this.kojinRdo.TabIndex = 14;
            this.kojinRdo.TabStop = true;
            this.kojinRdo.Text = "個人利用";
            this.kojinRdo.UseVisualStyleBackColor = true;
            // 
            // fukusuRdo
            // 
            this.fukusuRdo.AutoSize = true;
            this.fukusuRdo.Location = new System.Drawing.Point(185, 58);
            this.fukusuRdo.Name = "fukusuRdo";
            this.fukusuRdo.Size = new System.Drawing.Size(83, 16);
            this.fukusuRdo.TabIndex = 15;
            this.fukusuRdo.Text = "複数人利用";
            this.fukusuRdo.UseVisualStyleBackColor = true;
            // 
            // dbConnectBtn
            // 
            this.dbConnectBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dbConnectBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbConnectBtn.Location = new System.Drawing.Point(291, 51);
            this.dbConnectBtn.Name = "dbConnectBtn";
            this.dbConnectBtn.Size = new System.Drawing.Size(73, 25);
            this.dbConnectBtn.TabIndex = 11;
            this.dbConnectBtn.Text = "接続文字列";
            this.dbConnectBtn.UseVisualStyleBackColor = false;
            this.dbConnectBtn.Click += new System.EventHandler(this.dbConnectBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(426, 138);
            this.Controls.Add(this.dbConnectBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.fukusuRdo);
            this.Controls.Add(this.kojinRdo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.Opacity = 0.98D;
            this.Text = "ログイン";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.RadioButton fukusuRdo;
        private System.Windows.Forms.RadioButton kojinRdo;
        private System.Windows.Forms.Button dbConnectBtn;
    }
}