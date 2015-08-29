using System.Windows.Forms;
using WordConverter_v2;
using WordConverter_v2.Common;

namespace WordConverter_v2.Forms
{
    partial class UserKanri
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.userKanriDataGridView1 = new System.Windows.Forms.DataGridView();
            this.regist = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.kengen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.clear = new System.Windows.Forms.Button();
            this.kensu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.empId = new WordConverter_v2.Common.NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.userKanriDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // userKanriDataGridView1
            // 
            this.userKanriDataGridView1.AllowUserToResizeColumns = false;
            this.userKanriDataGridView1.AllowUserToResizeRows = false;
            this.userKanriDataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.userKanriDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.userKanriDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userKanriDataGridView1.Location = new System.Drawing.Point(22, 176);
            this.userKanriDataGridView1.Name = "userKanriDataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.userKanriDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.userKanriDataGridView1.RowHeadersVisible = false;
            this.userKanriDataGridView1.RowTemplate.Height = 21;
            this.userKanriDataGridView1.Size = new System.Drawing.Size(826, 235);
            this.userKanriDataGridView1.TabIndex = 6;
            this.userKanriDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.userKanriDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.userKanriDataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // regist
            // 
            this.regist.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.regist.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.regist.Location = new System.Drawing.Point(269, 432);
            this.regist.Name = "regist";
            this.regist.Size = new System.Drawing.Size(156, 25);
            this.regist.TabIndex = 7;
            this.regist.Text = "登録";
            this.regist.UseVisualStyleBackColor = false;
            this.regist.Click += new System.EventHandler(this.regist_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.delete.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.delete.Location = new System.Drawing.Point(447, 432);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(156, 25);
            this.delete.TabIndex = 8;
            this.delete.Text = "削除";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(153, 47);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(320, 22);
            this.userName.TabIndex = 2;
            this.userName.Validated += new System.EventHandler(this.userName_Validated);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.search.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.search.Location = new System.Drawing.Point(207, 127);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(132, 23);
            this.search.TabIndex = 4;
            this.search.Text = "検索";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.add.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.add.Location = new System.Drawing.Point(525, 127);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(132, 23);
            this.add.TabIndex = 5;
            this.add.Text = "追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // kengen
            // 
            this.kengen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kengen.FormattingEnabled = true;
            this.kengen.Items.AddRange(new object[] {
            "管理",
            "一般",
            "メーリングリスト",
            ""});
            this.kengen.Location = new System.Drawing.Point(153, 79);
            this.kengen.Name = "kengen";
            this.kengen.Size = new System.Drawing.Size(149, 23);
            this.kengen.TabIndex = 3;
            this.kengen.Validated += new System.EventHandler(this.kengen_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(83, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "ユーザー名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(83, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "権限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(83, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "ユーザーID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clear.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clear.Location = new System.Drawing.Point(366, 127);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(132, 23);
            this.clear.TabIndex = 11;
            this.clear.Text = "クリア";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // kensu
            // 
            this.kensu.AutoSize = true;
            this.kensu.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kensu.Location = new System.Drawing.Point(783, 147);
            this.kensu.Name = "kensu";
            this.kensu.Size = new System.Drawing.Size(0, 17);
            this.kensu.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(745, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "件数：";
            // 
            // empId
            // 
            this.empId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.empId.Location = new System.Drawing.Point(153, 18);
            this.empId.Name = "empId";
            this.empId.Size = new System.Drawing.Size(148, 22);
            this.empId.TabIndex = 1;
            this.empId.Validated += new System.EventHandler(this.empId_Validated);
            // 
            // UserKanri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(872, 481);
            this.Controls.Add(this.kensu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.empId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kengen);
            this.Controls.Add(this.add);
            this.Controls.Add(this.search);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.regist);
            this.Controls.Add(this.userKanriDataGridView1);
            this.Font = new System.Drawing.Font("メイリオ", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserKanri";
            this.Opacity = 0.98D;
            this.Text = "ユーザー管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserKanri_FormClosing);
            this.Load += new System.EventHandler(this.UserKanri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userKanriDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView userKanriDataGridView1;
        private System.Windows.Forms.Button regist;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ComboBox kengen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private NumericTextBox empId;
        private ErrorProvider errorProvider1;
        private Button clear;
        private Label kensu;
        private Label label5;
    }
}