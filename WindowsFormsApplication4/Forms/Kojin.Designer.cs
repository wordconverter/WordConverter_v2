namespace WordConverter_v2.Forms
{
    partial class Kojin
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
            this.hotKey = new System.Windows.Forms.TextBox();
            this.displayNumberRadioBtn1 = new System.Windows.Forms.RadioButton();
            this.displayNumberRadioBtn2 = new System.Windows.Forms.RadioButton();
            this.displayNumberRadioBtn3 = new System.Windows.Forms.RadioButton();
            this.pascalCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.camelCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.snakeCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regist = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.displayNumberRadioBtn4 = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // hotKey
            // 
            this.hotKey.BackColor = System.Drawing.Color.White;
            this.hotKey.Location = new System.Drawing.Point(29, 36);
            this.hotKey.Name = "hotKey";
            this.hotKey.ReadOnly = true;
            this.hotKey.Size = new System.Drawing.Size(262, 19);
            this.hotKey.TabIndex = 0;
            this.hotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotKey_KeyDown);
            // 
            // displayNumberRadioBtn1
            // 
            this.displayNumberRadioBtn1.AutoSize = true;
            this.displayNumberRadioBtn1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.displayNumberRadioBtn1.Location = new System.Drawing.Point(44, 88);
            this.displayNumberRadioBtn1.Name = "displayNumberRadioBtn1";
            this.displayNumberRadioBtn1.Size = new System.Drawing.Size(40, 21);
            this.displayNumberRadioBtn1.TabIndex = 1;
            this.displayNumberRadioBtn1.TabStop = true;
            this.displayNumberRadioBtn1.Text = "10";
            this.displayNumberRadioBtn1.UseVisualStyleBackColor = true;
            // 
            // displayNumberRadioBtn2
            // 
            this.displayNumberRadioBtn2.AutoSize = true;
            this.displayNumberRadioBtn2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.displayNumberRadioBtn2.Location = new System.Drawing.Point(85, 88);
            this.displayNumberRadioBtn2.Name = "displayNumberRadioBtn2";
            this.displayNumberRadioBtn2.Size = new System.Drawing.Size(40, 21);
            this.displayNumberRadioBtn2.TabIndex = 2;
            this.displayNumberRadioBtn2.TabStop = true;
            this.displayNumberRadioBtn2.Text = "20";
            this.displayNumberRadioBtn2.UseVisualStyleBackColor = true;
            // 
            // displayNumberRadioBtn3
            // 
            this.displayNumberRadioBtn3.AutoSize = true;
            this.displayNumberRadioBtn3.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.displayNumberRadioBtn3.Location = new System.Drawing.Point(126, 88);
            this.displayNumberRadioBtn3.Name = "displayNumberRadioBtn3";
            this.displayNumberRadioBtn3.Size = new System.Drawing.Size(40, 21);
            this.displayNumberRadioBtn3.TabIndex = 3;
            this.displayNumberRadioBtn3.TabStop = true;
            this.displayNumberRadioBtn3.Text = "30";
            this.displayNumberRadioBtn3.UseVisualStyleBackColor = true;
            // 
            // pascalCaseCheckBox
            // 
            this.pascalCaseCheckBox.AutoSize = true;
            this.pascalCaseCheckBox.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pascalCaseCheckBox.Location = new System.Drawing.Point(45, 145);
            this.pascalCaseCheckBox.Name = "pascalCaseCheckBox";
            this.pascalCaseCheckBox.Size = new System.Drawing.Size(84, 21);
            this.pascalCaseCheckBox.TabIndex = 4;
            this.pascalCaseCheckBox.Text = "PascalCase";
            this.pascalCaseCheckBox.UseVisualStyleBackColor = true;
            this.pascalCaseCheckBox.Validating += new System.ComponentModel.CancelEventHandler(this.pascalCaseCheckBox_Validating);
            this.pascalCaseCheckBox.Validated += new System.EventHandler(this.pascalCaseCheckBox_Validated);
            // 
            // camelCaseCheckBox
            // 
            this.camelCaseCheckBox.AutoSize = true;
            this.camelCaseCheckBox.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.camelCaseCheckBox.Location = new System.Drawing.Point(45, 167);
            this.camelCaseCheckBox.Name = "camelCaseCheckBox";
            this.camelCaseCheckBox.Size = new System.Drawing.Size(83, 21);
            this.camelCaseCheckBox.TabIndex = 5;
            this.camelCaseCheckBox.Text = "camelCase";
            this.camelCaseCheckBox.UseVisualStyleBackColor = true;
            this.camelCaseCheckBox.Validating += new System.ComponentModel.CancelEventHandler(this.camelCaseCheckBox_Validating);
            this.camelCaseCheckBox.Validated += new System.EventHandler(this.camelCaseCheckBox_Validated);
            // 
            // snakeCaseCheckBox
            // 
            this.snakeCaseCheckBox.AutoSize = true;
            this.snakeCaseCheckBox.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.snakeCaseCheckBox.Location = new System.Drawing.Point(45, 189);
            this.snakeCaseCheckBox.Name = "snakeCaseCheckBox";
            this.snakeCaseCheckBox.Size = new System.Drawing.Size(98, 21);
            this.snakeCaseCheckBox.TabIndex = 6;
            this.snakeCaseCheckBox.Text = "SNAKE_CASE";
            this.snakeCaseCheckBox.UseVisualStyleBackColor = true;
            this.snakeCaseCheckBox.Validating += new System.ComponentModel.CancelEventHandler(this.snakeCaseCheckBox_Validating);
            this.snakeCaseCheckBox.Validated += new System.EventHandler(this.snakeCaseCheckBox_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(28, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 92);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "変換形式";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(27, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 48);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表示件数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "起動ホットキー";
            // 
            // regist
            // 
            this.regist.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.regist.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.regist.Location = new System.Drawing.Point(57, 258);
            this.regist.Name = "regist";
            this.regist.Size = new System.Drawing.Size(90, 23);
            this.regist.TabIndex = 10;
            this.regist.Text = "登録";
            this.regist.UseVisualStyleBackColor = false;
            this.regist.Click += new System.EventHandler(this.regist_Click);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clear.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clear.Location = new System.Drawing.Point(176, 258);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(90, 23);
            this.clear.TabIndex = 11;
            this.clear.Text = "クリア";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // displayNumberRadioBtn4
            // 
            this.displayNumberRadioBtn4.AutoSize = true;
            this.displayNumberRadioBtn4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.displayNumberRadioBtn4.Location = new System.Drawing.Point(165, 88);
            this.displayNumberRadioBtn4.Name = "displayNumberRadioBtn4";
            this.displayNumberRadioBtn4.Size = new System.Drawing.Size(70, 21);
            this.displayNumberRadioBtn4.TabIndex = 12;
            this.displayNumberRadioBtn4.TabStop = true;
            this.displayNumberRadioBtn4.Text = "制限なし";
            this.displayNumberRadioBtn4.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Kojin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(327, 316);
            this.Controls.Add(this.displayNumberRadioBtn4);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.regist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.snakeCaseCheckBox);
            this.Controls.Add(this.camelCaseCheckBox);
            this.Controls.Add(this.pascalCaseCheckBox);
            this.Controls.Add(this.displayNumberRadioBtn3);
            this.Controls.Add(this.displayNumberRadioBtn2);
            this.Controls.Add(this.displayNumberRadioBtn1);
            this.Controls.Add(this.hotKey);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Kojin";
            this.Opacity = 0.98D;
            this.Text = "個人設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kojin_FormClosing);
            this.Load += new System.EventHandler(this.Kojin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hotKey;
        private System.Windows.Forms.RadioButton displayNumberRadioBtn1;
        private System.Windows.Forms.RadioButton displayNumberRadioBtn2;
        private System.Windows.Forms.RadioButton displayNumberRadioBtn3;
        private System.Windows.Forms.CheckBox pascalCaseCheckBox;
        private System.Windows.Forms.CheckBox camelCaseCheckBox;
        private System.Windows.Forms.CheckBox snakeCaseCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button regist;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.RadioButton displayNumberRadioBtn4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}