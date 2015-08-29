namespace WordConverter_v2.Forms
{
    partial class DbConnect
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
            this.serverName = new System.Windows.Forms.TextBox();
            this.dbPortNo = new System.Windows.Forms.TextBox();
            this.dbName = new System.Windows.Forms.TextBox();
            this.dbUserId = new System.Windows.Forms.TextBox();
            this.dbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.testConnectBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dbConnectablePath = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.sqliteSaveBtn = new System.Windows.Forms.Button();
            this.sqliteTestConnectBtn = new System.Windows.Forms.Button();
            this.sqliteOpenFileBtn = new System.Windows.Forms.Button();
            this.sqliteDbFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(110, 13);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(236, 19);
            this.serverName.TabIndex = 0;
            // 
            // dbPortNo
            // 
            this.dbPortNo.Location = new System.Drawing.Point(432, 12);
            this.dbPortNo.Name = "dbPortNo";
            this.dbPortNo.Size = new System.Drawing.Size(73, 19);
            this.dbPortNo.TabIndex = 1;
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(110, 48);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(236, 19);
            this.dbName.TabIndex = 2;
            // 
            // dbUserId
            // 
            this.dbUserId.Location = new System.Drawing.Point(110, 83);
            this.dbUserId.Name = "dbUserId";
            this.dbUserId.Size = new System.Drawing.Size(236, 19);
            this.dbUserId.TabIndex = 3;
            // 
            // dbPassword
            // 
            this.dbPassword.Location = new System.Drawing.Point(110, 118);
            this.dbPassword.Name = "dbPassword";
            this.dbPassword.Size = new System.Drawing.Size(236, 19);
            this.dbPassword.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "サーバー名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "データベース名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(18, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "DBユーザーID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(18, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "パスワード";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(363, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "ポート番号";
            // 
            // testConnectBtn
            // 
            this.testConnectBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.testConnectBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.testConnectBtn.Location = new System.Drawing.Point(58, 162);
            this.testConnectBtn.Name = "testConnectBtn";
            this.testConnectBtn.Size = new System.Drawing.Size(114, 23);
            this.testConnectBtn.TabIndex = 10;
            this.testConnectBtn.Text = "テスト接続";
            this.testConnectBtn.UseVisualStyleBackColor = false;
            this.testConnectBtn.Click += new System.EventHandler(this.testConnectBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.saveBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.saveBtn.Location = new System.Drawing.Point(334, 162);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(114, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 237);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.dbConnectablePath);
            this.tabPage1.Controls.Add(this.clearBtn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.saveBtn);
            this.tabPage1.Controls.Add(this.serverName);
            this.tabPage1.Controls.Add(this.testConnectBtn);
            this.tabPage1.Controls.Add(this.dbPortNo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dbName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dbUserId);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dbPassword);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Postgres";
            // 
            // dbConnectablePath
            // 
            this.dbConnectablePath.AutoSize = true;
            this.dbConnectablePath.Location = new System.Drawing.Point(390, 89);
            this.dbConnectablePath.Name = "dbConnectablePath";
            this.dbConnectablePath.Size = new System.Drawing.Size(63, 12);
            this.dbConnectablePath.TabIndex = 13;
            this.dbConnectablePath.Text = "接続OKパス";
            this.dbConnectablePath.Visible = false;
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clearBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clearBtn.Location = new System.Drawing.Point(196, 162);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(114, 23);
            this.clearBtn.TabIndex = 12;
            this.clearBtn.Text = "クリア";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.sqliteSaveBtn);
            this.tabPage2.Controls.Add(this.sqliteTestConnectBtn);
            this.tabPage2.Controls.Add(this.sqliteOpenFileBtn);
            this.tabPage2.Controls.Add(this.sqliteDbFilePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(533, 211);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQLite";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(41, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "DBファイルパス";
            // 
            // sqliteSaveBtn
            // 
            this.sqliteSaveBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sqliteSaveBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sqliteSaveBtn.Location = new System.Drawing.Point(253, 108);
            this.sqliteSaveBtn.Name = "sqliteSaveBtn";
            this.sqliteSaveBtn.Size = new System.Drawing.Size(138, 23);
            this.sqliteSaveBtn.TabIndex = 3;
            this.sqliteSaveBtn.Text = "保存";
            this.sqliteSaveBtn.UseVisualStyleBackColor = false;
            this.sqliteSaveBtn.Click += new System.EventHandler(this.sqliteSaveBtn_Click);
            // 
            // sqliteTestConnectBtn
            // 
            this.sqliteTestConnectBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sqliteTestConnectBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sqliteTestConnectBtn.Location = new System.Drawing.Point(74, 108);
            this.sqliteTestConnectBtn.Name = "sqliteTestConnectBtn";
            this.sqliteTestConnectBtn.Size = new System.Drawing.Size(138, 23);
            this.sqliteTestConnectBtn.TabIndex = 2;
            this.sqliteTestConnectBtn.Text = "テスト接続";
            this.sqliteTestConnectBtn.UseVisualStyleBackColor = false;
            this.sqliteTestConnectBtn.Click += new System.EventHandler(this.sqliteTestConnectBtn_Click);
            // 
            // sqliteOpenFileBtn
            // 
            this.sqliteOpenFileBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sqliteOpenFileBtn.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sqliteOpenFileBtn.Location = new System.Drawing.Point(421, 45);
            this.sqliteOpenFileBtn.Name = "sqliteOpenFileBtn";
            this.sqliteOpenFileBtn.Size = new System.Drawing.Size(75, 23);
            this.sqliteOpenFileBtn.TabIndex = 1;
            this.sqliteOpenFileBtn.Text = "参照";
            this.sqliteOpenFileBtn.UseVisualStyleBackColor = false;
            this.sqliteOpenFileBtn.Click += new System.EventHandler(this.sqliteOpenFileBtn_Click);
            // 
            // sqliteDbFilePath
            // 
            this.sqliteDbFilePath.Location = new System.Drawing.Point(62, 45);
            this.sqliteDbFilePath.Name = "sqliteDbFilePath";
            this.sqliteDbFilePath.Size = new System.Drawing.Size(342, 19);
            this.sqliteDbFilePath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DbConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(572, 243);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DbConnect";
            this.Text = "DB接続文字列設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DbConnect_FormClosing);
            this.Load += new System.EventHandler(this.DbConnect_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.TextBox dbPortNo;
        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.TextBox dbUserId;
        private System.Windows.Forms.TextBox dbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button testConnectBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox sqliteDbFilePath;
        private System.Windows.Forms.Button sqliteOpenFileBtn;
        private System.Windows.Forms.Button sqliteSaveBtn;
        private System.Windows.Forms.Button sqliteTestConnectBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label dbConnectablePath;
    }
}