﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConvTool.Const;

namespace WordConverter_v2.Forms
{
    public partial class DbConnect : Form
    {
        private static CommonFunction common = new CommonFunction();
        private static readonly DbConnect _instance = new DbConnect();
        private DbConnectInBo inBo;

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
        }

        public void moveDbConnect(DbConnectInBo dbConnectInBo)
        {
            this.inBo = dbConnectInBo;
            this.tabControl1.SelectedIndex = this.inBo.selectedIndex;
            this.Show();
            this.Activate();
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            common.tabDrawItem(ref sender, ref e);
        }

        private void postgresTestConnectBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Server=" + this.serverName.Text);
            sb.Append("; Port=" + this.dbPortNo.Text);
            sb.Append("; User Id=" + this.dbUserId.Text);
            sb.Append("; Password=" + this.dbPassword.Text);
            sb.Append("; Database=" + this.dbName.Text);

            if (common.isExistPostgresDb(sb.ToString()) && common.isExistPostgresDbTable(sb.ToString()))
            {
                this.endPostgresTestConnectProc(sb.ToString());
                return;
            }
            else if (common.isExistPostgresDb(sb.ToString()))
            {
                common.ExecutePostgresDDL(sb.ToString());
                this.endPostgresTestConnectProc(sb.ToString());
                return;

            }
            StringBuilder eSb = new StringBuilder();
            eSb.AppendLine("DB接続失敗");
            MessageBox.Show(eSb.ToString());
        }

        private void endPostgresTestConnectProc(String path)
        {
            MessageBox.Show("DB接続に成功しました！！");
            this.postgresDbConnectablePath.Text = path;
            this.serverName.Enabled = false;
            this.dbName.Enabled = false;
            this.dbPortNo.Enabled = false;
            this.dbUserId.Enabled = false;
            this.dbPassword.Enabled = false;
            this.saveBtn.Visible = true;
            this.postgressTestConnectBtn.Visible = false;
        }

        private void DbConnect_Load(object sender, EventArgs e)
        {
            if (this.inBo.selectedIndex == (int)StartUpMode.複数人)
            {
                this.showPostgresSetthing(this);

            }
            else
            {
                this.tabControl1.SelectedIndex = (int)StartUpMode.個人;
                this.sqliteDbFilePath.Text = this.getSqliteDbFilePath();
                this.sqliteSaveBtn.Visible = false;
            }
        }

        private void showPostgresSetthing(DbConnect dbConnect)
        {
            this.tabControl1.SelectedIndex = (int)StartUpMode.複数人;
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
            this.postgresDbConnectablePath.Text = sb.ToString();

            this.saveBtn.Visible = false;
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (this.tabControl1.SelectedIndex == (int)StartUpMode.複数人)
            {
                this.showPostgresSetthing(this);
            }
            else
            {
                this.sqliteDbFilePath.Text = this.getSqliteDbFilePath();
                this.sqliteSaveBtn.Visible = false;
            }
        }

        private string getSqliteDbFilePath()
        {
            String dbPath = WordConverter_v2.Settings1.Default.SqliteContextString;
            dbPath = dbPath.Replace("Data Source=", "");
            dbPath = dbPath.Replace(";foreign keys=true;", "");
            return dbPath;
        }

        private void postgresSaveBtn_Click(object sender, EventArgs e)
        {
            WordConverter_v2.Settings1.Default.ServerName = this.serverName.Text;
            WordConverter_v2.Settings1.Default.DbName = this.dbName.Text;
            WordConverter_v2.Settings1.Default.DbPortNo = this.dbPortNo.Text;
            WordConverter_v2.Settings1.Default.DbUserId = this.dbUserId.Text;
            WordConverter_v2.Settings1.Default.DbPassword = this.dbPassword.Text;
            WordConverter_v2.Settings1.Default.Save();
            common.setPostgresDbContext(this.postgresDbConnectablePath.Text);
            MessageBox.Show("DB接続設定を保存しました。アプリケーションを再起動してください。");
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.serverName.Enabled = true;
            this.dbName.Enabled = true;
            this.dbPortNo.Enabled = true;
            this.dbUserId.Enabled = true;
            this.dbPassword.Enabled = true;
            this.saveBtn.Visible = false;
            this.postgressTestConnectBtn.Visible = true;
        }

        private void DbConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }


        internal void setInBo(DbConnectInBo inBo)
        {
            this.inBo = inBo;
        }

        private void sqliteTestConnectBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Data Source=" + this.sqliteDbFilePath.Text);
            sb.Append(";foreign keys=true;");
            CommonFunction common = new CommonFunction();

            if (common.isExistSqliteDb(sb.ToString()) && common.isExistSqliteDbTable(sb.ToString()))
            {
                this.endSqliteTestConnectProc(sb.ToString());
                return;
            }
            else if (!common.isExistSqliteDbTable(sb.ToString()))
            {
                common.ExecuteSqliteDDL();
                this.endSqliteTestConnectProc(this.getSqliteDbFilePath());
                return;
            }

            StringBuilder eSb = new StringBuilder();
            eSb.AppendLine("DB接続失敗");
            MessageBox.Show(eSb.ToString());
        }

        private void endSqliteTestConnectProc(string path)
        {
            MessageBox.Show("DB接続に成功しました！！");
            this.sqliteConnectableDbPath.Text = path;
            this.sqliteDbFilePath.Text = path.Replace("Data Source=", "");
            this.sqliteSaveBtn.Visible = true;
            this.sqliteDbFilePath.Enabled = false;
        }

        private void sqliteSaveBtn_Click(object sender, EventArgs e)
        {
            WordConverter_v2.Settings1.Default.SqliteContextString = this.sqliteConnectableDbPath.Text;
            WordConverter_v2.Settings1.Default.Save();
            common.setSqliteDbContextPath(this.sqliteConnectableDbPath.Text);
            MessageBox.Show("DB接続設定を保存しました。アプリケーションを再起動してください。");
        }

        private void sqliteOpenFileBtn_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.sqliteDbFilePath.Text = ofd.FileName;
                this.sqliteSaveBtn.Visible = false;
            }
        }
    }
}

