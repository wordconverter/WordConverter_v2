using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConvTool.Const;

namespace WordConverter_v2.Forms
{
    public partial class DbConnect : Form
    {
        private static CommonFunction common = new CommonFunction();
        private static readonly DbConnect _instance = new DbConnect();

        public static DbConnect Instance
        {
            get
            {
                return _instance;
            }
        }

        private DbConnect()
        {
            InitializeComponent();
            this.Show();
            this.Activate();
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            common.tabDrawItem(ref sender, ref e);
        }

        private void testConnectBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Server=" + this.serverName.Text);
            sb.Append("; Port=" + this.dbPortNo.Text);
            sb.Append("; User Id=" + this.dbUserId.Text);
            sb.Append("; Password=" + this.dbPassword.Text);
            sb.Append("; Database=" + this.dbName.Text);

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(sb.ToString()))
                {
                    cn.Open();
                    MessageBox.Show("DB接続に成功しました！！");
                    this.dbConnectablePath.Text = sb.ToString();
                    this.serverName.Enabled = false;
                    this.dbName.Enabled = false;
                    this.dbPortNo.Enabled = false;
                    this.dbUserId.Enabled = false;
                    this.dbPassword.Enabled = false;
                    this.saveBtn.Visible = true;
                    this.testConnectBtn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB接続失敗");
            }
        }

        private void DbConnect_Load(object sender, EventArgs e)
        {
            this.serverName.Text = WordConverter_v2.Settings1.Default.ServerName;
            this.dbName.Text = WordConverter_v2.Settings1.Default.DbName;
            this.dbPortNo.Text = WordConverter_v2.Settings1.Default.DbPortNo;
            this.dbUserId.Text = WordConverter_v2.Settings1.Default.DbUserId;
            this.dbPassword.Text = WordConverter_v2.Settings1.Default.DbPassword;
            StringBuilder sb = new StringBuilder();
            sb.Append("Server=" + this.serverName.Text);
            sb.Append(";Port=" + this.dbPortNo.Text);
            sb.Append(";User Id=" + this.dbUserId.Text);
            sb.Append(";Password=" + this.dbPassword.Text);
            sb.Append(";Database=" + this.dbName.Text);
            this.dbConnectablePath.Text = sb.ToString();
            this.saveBtn.Visible = false;
            
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            WordConverter_v2.Settings1.Default.ServerName = this.serverName.Text;
            WordConverter_v2.Settings1.Default.DbName = this.dbName.Text;
            WordConverter_v2.Settings1.Default.DbPortNo = this.dbPortNo.Text;
            WordConverter_v2.Settings1.Default.DbUserId = this.dbUserId.Text;
            WordConverter_v2.Settings1.Default.DbPassword = this.dbPassword.Text;
            CommonFunction common = new CommonFunction();
            common.setPostgresDbPath(this.dbConnectablePath.Text);
            WordConverter_v2.Settings1.Default.Save();
            MessageBox.Show("DB接続設定を保存しました。");
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.serverName.Enabled = true;
            this.dbName.Enabled = true;
            this.dbPortNo.Enabled = true;
            this.dbUserId.Enabled = true;
            this.dbPassword.Enabled = true;
            this.saveBtn.Visible = false;
            this.testConnectBtn.Visible = true;
        }

        private void DbConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            Login form = Login.Instance;
            form.Show();
            form.Activate();
        }
    }
}

