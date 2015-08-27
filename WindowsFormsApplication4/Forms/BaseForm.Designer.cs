namespace WordConverter_v2.Forms
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.一般ユーザーcontextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申請ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.個人設定ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.管理ユーザーcontextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.申請ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.個人設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ユーザー管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一般ユーザーcontextMenuStrip2.SuspendLayout();
            this.管理ユーザーcontextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.一般ユーザーcontextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WordConverter_v2";
            // 
            // 一般ユーザーcontextMenuStrip2
            // 
            this.一般ユーザーcontextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem,
            this.申請ToolStripMenuItem1,
            this.個人設定ToolStripMenuItem1});
            this.一般ユーザーcontextMenuStrip2.Name = "一般ユーザーcontextMenuStrip2";
            this.一般ユーザーcontextMenuStrip2.Size = new System.Drawing.Size(125, 70);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了toolStripMenuItem_Click);
            // 
            // 申請ToolStripMenuItem1
            // 
            this.申請ToolStripMenuItem1.Name = "申請ToolStripMenuItem1";
            this.申請ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.申請ToolStripMenuItem1.Text = "申請";
            this.申請ToolStripMenuItem1.Click += new System.EventHandler(this.申請ToolStripMenuItem_Click);
            // 
            // 個人設定ToolStripMenuItem1
            // 
            this.個人設定ToolStripMenuItem1.Name = "個人設定ToolStripMenuItem1";
            this.個人設定ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.個人設定ToolStripMenuItem1.Text = "個人設定";
            this.個人設定ToolStripMenuItem1.Click += new System.EventHandler(this.個人設定ToolStripMenuItem_Click);
            // 
            // 管理ユーザーcontextMenuStrip1
            // 
            this.管理ユーザーcontextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.申請ToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.個人設定ToolStripMenuItem,
            this.ユーザー管理ToolStripMenuItem});
            this.管理ユーザーcontextMenuStrip1.Name = "contextMenuStrip1";
            this.管理ユーザーcontextMenuStrip1.Size = new System.Drawing.Size(149, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "終了";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.終了toolStripMenuItem_Click);
            // 
            // 申請ToolStripMenuItem
            // 
            this.申請ToolStripMenuItem.Name = "申請ToolStripMenuItem";
            this.申請ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.申請ToolStripMenuItem.Text = "申請";
            this.申請ToolStripMenuItem.Click += new System.EventHandler(this.申請ToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.編集ToolStripMenuItem.Text = "編集";
            this.編集ToolStripMenuItem.Click += new System.EventHandler(this.編集ToolStripMenuItem_Click);
            // 
            // 個人設定ToolStripMenuItem
            // 
            this.個人設定ToolStripMenuItem.Name = "個人設定ToolStripMenuItem";
            this.個人設定ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.個人設定ToolStripMenuItem.Text = "個人設定";
            this.個人設定ToolStripMenuItem.Click += new System.EventHandler(this.個人設定ToolStripMenuItem_Click);
            // 
            // ユーザー管理ToolStripMenuItem
            // 
            this.ユーザー管理ToolStripMenuItem.Name = "ユーザー管理ToolStripMenuItem";
            this.ユーザー管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ユーザー管理ToolStripMenuItem.Text = "ユーザー管理";
            this.ユーザー管理ToolStripMenuItem.Click += new System.EventHandler(this.ユーザー管理ToolStripMenuItem_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 172);
            this.Name = "BaseForm";
            this.Text = "BaseForm1";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.一般ユーザーcontextMenuStrip2.ResumeLayout(false);
            this.管理ユーザーcontextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip 管理ユーザーcontextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 申請ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 個人設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ユーザー管理ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip 一般ユーザーcontextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申請ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 個人設定ToolStripMenuItem1;
    }
}