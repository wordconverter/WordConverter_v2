using System.Windows.Forms;
namespace WordConverter_v2.Forms
{
    partial class Ichiran
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ichiranDataGridView = new System.Windows.Forms.DataGridView();
            this.wordList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.単一登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kanriUserContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.プロパティ作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.プロパティ作成コメントありToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物理名から作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物理名からプロパティ作成アノテーションありToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一括登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ゲッター作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formHeanderLabel = new System.Windows.Forms.Label();
            this.closeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.アプリ閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ippanUserContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.申請ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.プロパティ作成ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ichiranDataGridView)).BeginInit();
            this.kanriUserContextMenuStrip.SuspendLayout();
            this.closeContextMenuStrip.SuspendLayout();
            this.ippanUserContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ichiranDataGridView
            // 
            this.ichiranDataGridView.AllowUserToResizeColumns = false;
            this.ichiranDataGridView.AllowUserToResizeRows = false;
            this.ichiranDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.ichiranDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ichiranDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ichiranDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wordList});
            this.ichiranDataGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ichiranDataGridView.Location = new System.Drawing.Point(0, 9);
            this.ichiranDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.ichiranDataGridView.Name = "ichiranDataGridView";
            this.ichiranDataGridView.RowHeadersVisible = false;
            this.ichiranDataGridView.RowTemplate.Height = 21;
            this.ichiranDataGridView.Size = new System.Drawing.Size(330, 491);
            this.ichiranDataGridView.TabIndex = 0;
            this.ichiranDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.ichiranDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.ichiranDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // wordList
            // 
            this.wordList.HeaderText = "wordList";
            this.wordList.MinimumWidth = 330;
            this.wordList.Name = "wordList";
            this.wordList.ReadOnly = true;
            this.wordList.Visible = false;
            this.wordList.Width = 330;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 495);
            this.label1.TabIndex = 1;
            // 
            // 単一登録ToolStripMenuItem
            // 
            this.単一登録ToolStripMenuItem.Name = "単一登録ToolStripMenuItem";
            this.単一登録ToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.単一登録ToolStripMenuItem.Text = "単一登録";
            this.単一登録ToolStripMenuItem.Click += new System.EventHandler(this.単一登録ToolStripMenuItem_Click);
            // 
            // kanriUserContextMenuStrip
            // 
            this.kanriUserContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.単一登録ToolStripMenuItem,
            this.ゲッター作成ToolStripMenuItem,
            this.プロパティ作成ToolStripMenuItem,
            this.プロパティ作成コメントありToolStripMenuItem,
            this.物理名から作成ToolStripMenuItem,
            this.物理名からプロパティ作成アノテーションありToolStripMenuItem,
            this.一括登録ToolStripMenuItem});
            this.kanriUserContextMenuStrip.Name = "contextMenuStrip1";
            this.kanriUserContextMenuStrip.Size = new System.Drawing.Size(299, 180);
            // 
            // プロパティ作成ToolStripMenuItem
            // 
            this.プロパティ作成ToolStripMenuItem.Name = "プロパティ作成ToolStripMenuItem";
            this.プロパティ作成ToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.プロパティ作成ToolStripMenuItem.Text = "プロパティ作成";
            this.プロパティ作成ToolStripMenuItem.Click += new System.EventHandler(this.プロパティ作成ToolStripMenuItem_Click);
            // 
            // プロパティ作成コメントありToolStripMenuItem
            // 
            this.プロパティ作成コメントありToolStripMenuItem.Name = "プロパティ作成コメントありToolStripMenuItem";
            this.プロパティ作成コメントありToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.プロパティ作成コメントありToolStripMenuItem.Text = "プロパティ作成（アノテーションあり）";
            this.プロパティ作成コメントありToolStripMenuItem.Click += new System.EventHandler(this.プロパティ作成アノテーションありToolStripMenuItem_Click);
            // 
            // 物理名から作成ToolStripMenuItem
            // 
            this.物理名から作成ToolStripMenuItem.Name = "物理名から作成ToolStripMenuItem";
            this.物理名から作成ToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.物理名から作成ToolStripMenuItem.Text = "物理名からプロパティ作成";
            this.物理名から作成ToolStripMenuItem.Click += new System.EventHandler(this.物理名からプロパティ作成ToolStripMenuItem_Click);
            // 
            // 物理名からプロパティ作成アノテーションありToolStripMenuItem
            // 
            this.物理名からプロパティ作成アノテーションありToolStripMenuItem.Name = "物理名からプロパティ作成アノテーションありToolStripMenuItem";
            this.物理名からプロパティ作成アノテーションありToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.物理名からプロパティ作成アノテーションありToolStripMenuItem.Text = "物理名からプロパティ作成（アノテーションあり）";
            this.物理名からプロパティ作成アノテーションありToolStripMenuItem.Click += new System.EventHandler(this.物理名からプロパティ作成アノテーションありToolStripMenuItem_Click);
            // 
            // 一括登録ToolStripMenuItem
            // 
            this.一括登録ToolStripMenuItem.Enabled = false;
            this.一括登録ToolStripMenuItem.Name = "一括登録ToolStripMenuItem";
            this.一括登録ToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.一括登録ToolStripMenuItem.Text = "一括登録";
            this.一括登録ToolStripMenuItem.Visible = false;
            this.一括登録ToolStripMenuItem.Click += new System.EventHandler(this.一括登録ToolStripMenuItem_Click);
            // 
            // ゲッター作成ToolStripMenuItem
            // 
            this.ゲッター作成ToolStripMenuItem.Name = "ゲッター作成ToolStripMenuItem";
            this.ゲッター作成ToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.ゲッター作成ToolStripMenuItem.Text = "ゲッター作成";
            this.ゲッター作成ToolStripMenuItem.Click += new System.EventHandler(this.ゲッター作成ToolStripMenuItem_Click);
            // 
            // formHeanderLabel
            // 
            this.formHeanderLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.formHeanderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formHeanderLabel.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.formHeanderLabel.Location = new System.Drawing.Point(0, 0);
            this.formHeanderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.formHeanderLabel.Name = "formHeanderLabel";
            this.formHeanderLabel.Size = new System.Drawing.Size(330, 27);
            this.formHeanderLabel.TabIndex = 3;
            this.formHeanderLabel.Text = "WordConverter_v2";
            this.formHeanderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formHeanderLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formHeanderLabel_MouseClick);
            this.formHeanderLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.formHeanderLabel_MouseDoubleClick);
            this.formHeanderLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ichiran_MouseDown);
            this.formHeanderLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ichiran_MouseMove);
            // 
            // closeContextMenuStrip
            // 
            this.closeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アプリ閉じるToolStripMenuItem});
            this.closeContextMenuStrip.Name = "contextMenuStrip2";
            this.closeContextMenuStrip.Size = new System.Drawing.Size(131, 26);
            // 
            // アプリ閉じるToolStripMenuItem
            // 
            this.アプリ閉じるToolStripMenuItem.Name = "アプリ閉じるToolStripMenuItem";
            this.アプリ閉じるToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.アプリ閉じるToolStripMenuItem.Text = "アプリ閉じる";
            this.アプリ閉じるToolStripMenuItem.Click += new System.EventHandler(this.アプリ閉じるToolStripMenuItem_Click);
            // 
            // ippanUserContextMenuStrip
            // 
            this.ippanUserContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.申請ToolStripMenuItem1,
            this.プロパティ作成ToolStripMenuItem1});
            this.ippanUserContextMenuStrip.Name = "ippanUserContextMenuStrip";
            this.ippanUserContextMenuStrip.Size = new System.Drawing.Size(143, 48);
            // 
            // 申請ToolStripMenuItem1
            // 
            this.申請ToolStripMenuItem1.Name = "申請ToolStripMenuItem1";
            this.申請ToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.申請ToolStripMenuItem1.Text = "申請";
            this.申請ToolStripMenuItem1.Click += new System.EventHandler(this.申請ToolStripMenuItem_Click);
            // 
            // プロパティ作成ToolStripMenuItem1
            // 
            this.プロパティ作成ToolStripMenuItem1.Name = "プロパティ作成ToolStripMenuItem1";
            this.プロパティ作成ToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.プロパティ作成ToolStripMenuItem1.Text = "プロパティ作成";
            this.プロパティ作成ToolStripMenuItem1.Click += new System.EventHandler(this.プロパティ作成ToolStripMenuItem_Click);
            // 
            // Ichiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(330, 500);
            this.Controls.Add(this.formHeanderLabel);
            this.Controls.Add(this.ichiranDataGridView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ichiran";
            this.Text = "Ichiran";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ichiran_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ichiranDataGridView)).EndInit();
            this.kanriUserContextMenuStrip.ResumeLayout(false);
            this.closeContextMenuStrip.ResumeLayout(false);
            this.ippanUserContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView ichiranDataGridView;
        private DataGridViewTextBoxColumn wordList;
        private ToolStripMenuItem 単一登録ToolStripMenuItem;
        private ContextMenuStrip kanriUserContextMenuStrip;
        private Label label1;
        private Label formHeanderLabel;
        private ToolStripMenuItem 一括登録ToolStripMenuItem;
        private ToolStripMenuItem プロパティ作成ToolStripMenuItem;
        private ContextMenuStrip closeContextMenuStrip;
        private ToolStripMenuItem アプリ閉じるToolStripMenuItem;
        private ContextMenuStrip ippanUserContextMenuStrip;
        private ToolStripMenuItem 申請ToolStripMenuItem1;
        private ToolStripMenuItem プロパティ作成ToolStripMenuItem1;
        private ToolStripMenuItem プロパティ作成コメントありToolStripMenuItem;
        private ToolStripMenuItem 物理名から作成ToolStripMenuItem;
        private ToolStripMenuItem 物理名からプロパティ作成アノテーションありToolStripMenuItem;
        private ToolStripMenuItem ゲッター作成ToolStripMenuItem;
    }
}

