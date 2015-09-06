using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConverter_v2.Const;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using System.Linq;
using WordConvTool.Const;

namespace WordConverter_v2.Forms
{
    public partial class Login : Form
    {
        private static readonly Login _instance = new Login();
        public static Login Instance
        {
            get
            {
                return _instance;
            }
        }

        private Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ログインボタンクリックアクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            bool isNgRequired = false;
            if (String.IsNullOrEmpty(this.UserId.Text))
            {
                errorProvider1.SetError(this.UserId, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (isNgRequired)
            {
                return;
            }

            UserInfoBo userInfo = new UserInfoBo();
            this.startModeSetting(ref userInfo, this);

            try
            {
                this.loginAction(this, userInfo);
                return;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

        }

        private void loginAction(Login form, UserInfoBo userInfo)
        {
            using (var context = new MyContext())
            {
                long condtion = Convert.ToInt64(form.UserId.Text);
                var w = context.UserMst.Where(x => x.emp_id == condtion && x.sanka_kahi == 0).ToArray();

                if (w.Count() == 0)
                {
                    MessageBox.Show(
                        MessageConst.ERR_007,
                        System.Windows.Forms.Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                if (w.Count() == 1)
                {
                    WordConverter_v2.Settings1.Default.UserId = this.UserId.Text;
                    WordConverter_v2.Settings1.Default.FukusuRiyou = this.fukusuRdo.Checked;
                    WordConverter_v2.Settings1.Default.KojinRiyou = this.kojinRdo.Checked;
                    WordConverter_v2.Settings1.Default.Save();

                    userInfo.kengen = w[0].kengen;
                    userInfo.userId = w[0].user_id;
                    userInfo.empId = w[0].emp_id;
                    userInfo.hotKey = WordConverter_v2.Settings1.Default.HotKey;
                    BaseForm bForm = new BaseForm(userInfo);

                    this.Close();
                    return;
                }
            }
        }

        private void startModeSetting(ref UserInfoBo userInfo, Login form)
        {
            CommonFunction common = new CommonFunction();
            if (form.kojinRdo.Checked)
            {
                common.setSqliteDbContextPath(WordConverter_v2.Settings1.Default.SqliteContextString);
                userInfo.startUpMode = (int)StartUpMode.個人;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Server=" + WordConverter_v2.Settings1.Default.ServerName);
                sb.Append(";Port=" + WordConverter_v2.Settings1.Default.DbPortNo);
                sb.Append(";User Id=" + WordConverter_v2.Settings1.Default.DbUserId);
                sb.Append(";Password=" + WordConverter_v2.Settings1.Default.DbPassword);
                sb.Append(";Database=" + WordConverter_v2.Settings1.Default.DbName);
                common.setPostgresDbContext(sb.ToString());
                userInfo.startUpMode = (int)StartUpMode.複数人;
            }
        }

        /// <summary>
        /// 初期表示アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            CommonFunction common = new CommonFunction();
            this.UserId.Text = WordConverter_v2.Settings1.Default.UserId;
            this.fukusuRdo.Checked = WordConverter_v2.Settings1.Default.FukusuRiyou;
            this.kojinRdo.Checked = WordConverter_v2.Settings1.Default.KojinRiyou;

        }

        /// <summary>
        /// 参照アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbConnectBtn_Click(object sender, EventArgs e)
        {
            DbConnectInBo dbConnectInBo = new DbConnectInBo();
            dbConnectInBo.selectedIndex = this.fukusuRdo.Checked ? (int)StartUpMode.複数人 : (int)StartUpMode.個人;
            DbConnect form = DbConnect.Instance;
            this.Close();
            form.moveDbConnect(dbConnectInBo);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void UserId_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.UserId, "");
        }
    }
}
