using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WordConverter_v2.Models;
using WordConvTool.Const;

namespace WordConverter_v2.Forms
{
    public partial class BaseForm : Form
    {
        protected const int MOD_ALT = 0x0001;
        protected const int MOD_CONTROL = 0x0002;
        protected const int MOD_SHIFT = 0x0004;
        protected const int WM_HOTKEY = 0x0312;
        protected const int HOTKEY_ID = 0x0001;  // 0x0000～0xbfff 内の適当な値でよい
        protected const int HOTKEY2_ID = 0x0002;
        protected static IntPtr Handles;
        private static UserInfoBo userInfo;


        public static UserInfoBo UserInfo
        {
            get
            {

                return userInfo;
            }
        }

        [DllImport("user32.dll")]
        extern static int RegisterHotKey(IntPtr HWnd, int ID, int MOD_KEY, int KEY);
        [DllImport("user32.dll")]
        extern static int UnregisterHotKey(IntPtr HWnd, int ID);

        /// <summary>
        /// コンストラクタ（初期処理）
        /// </summary>
        public BaseForm()
        {
            this.InitializeComponent();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            Login form = new Login();
            form.Show();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uInfo"></param>
        public BaseForm(UserInfoBo uInfo)
        {
            userInfo = uInfo;

            this.InitializeComponent();
            this.notifyIcon1.Visible = true;

            if (BaseForm.userInfo.kengen == Constant.KANRI)
            {
                this.notifyIcon1.ContextMenuStrip = this.管理ユーザーcontextMenuStrip1;
            }
            else if (BaseForm.userInfo.kengen == Constant.IPPAN)
            {
                this.notifyIcon1.ContextMenuStrip = this.一般ユーザーcontextMenuStrip2;
            }

            UnregisterHotKey(this.Handle, HOTKEY_ID);
            this.updateRegisterHotKey(uInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uInfo"></param>
        private void updateRegisterHotKey(UserInfoBo uInfo)
        {
            String[] hotKey = uInfo.hotKey.ToString().Split('+');
            int modKey = MOD_CONTROL;
            int regKey = (int)Keys.E;
            switch (hotKey[0].Trim())
            {
                case "Ctrl":
                    modKey = MOD_CONTROL;
                    break;
                case "Shift":
                    modKey = MOD_SHIFT;
                    break;
                case "Alt":
                    modKey = MOD_ALT;
                    break;
                default:
                    break;
            }

            if (hotKey.Length > 1)
            {
                foreach (int i in Enum.GetValues(typeof(Keys)))
                {
                    if (((Keys)i).ToString() == hotKey[1].Trim())
                    {
                        regKey = i;
                        break;
                    }
                }
            }

            RegisterHotKey(this.Handle, HOTKEY_ID, modKey, regKey);
        }


        /// <summary>
        /// キーイベント検出処理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                //一覧起動のショートカットキーが押された場合
                if ((int)m.WParam == HOTKEY_ID)
                {
                    if (Kojin.Instance.Visible)
                    {
                        return;
                    }
                    userInfo.pascal = WordConverter_v2.Settings1.Default.Pascal;
                    userInfo.camel = WordConverter_v2.Settings1.Default.Camel;
                    userInfo.snake = WordConverter_v2.Settings1.Default.Snake;
                    userInfo.dispNumber = WordConverter_v2.Settings1.Default.DispNumber;

                    Ichiran ichiran = Ichiran.Instance;
                    ichiran.ichiran_Load();
                    ichiran.Show();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void 申請ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shinsei form = Shinsei.Instance;
            form.Show();
            form.Activate();
            form.moveShinsei("");
        }

        private void 編集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Henshu form = Henshu.Instance;
            form.Activate();
            form.Show();
        }

        private void 個人設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kojin form = Kojin.Instance;
            form.Activate();
            form.Show();
        }

        private void ユーザー管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserKanri form = UserKanri.Instance;
            form.Activate();
            form.Show();
        }

        private void 終了toolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
