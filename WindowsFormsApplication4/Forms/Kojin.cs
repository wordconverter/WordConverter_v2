using System;
using System.Windows.Forms;
using WordConverter_v2.Const;
using WordConverter_v2.Forms;
using WordConverter_v2.Models;
using WordConvertTool;

namespace WordConverter_v2.Forms
{
    public partial class Kojin : Form    {

        private static readonly Kojin _instance = new Kojin();

        public static Kojin Instance
        {
            get
            {
                return _instance;
            }
        }

        private Kojin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.hotKey.Text))
            {
                MessageBox.Show(
                "ホットキーは必須です。",
                "入力エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return;
            }

            if (!this.hotKey.Text.Contains("Ctrl")
                && !this.hotKey.Text.Contains("Shift")
                && !this.hotKey.Text.Contains("Alt"))
            {
                MessageBox.Show(
                "ホットキーには「修飾キー」を含める必要があります。",
                "入力エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return;
            }

            if (this.hotKey.Text.Equals("Ctrl")
                || this.hotKey.Text.Equals("Shift")
                || this.hotKey.Text.Equals("Alt"))
            {
                MessageBox.Show(
                "ホットキーは「修飾キー」+「一般キー」で設定してください。",
                "入力エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return;
            }

            if (this.camelCaseCheckBox.Checked == false
                || this.pascalCaseCheckBox.Checked == false
                || this.snakeCaseCheckBox.Checked == false)
            {
                errorProvider1.SetError(this.groupBox1, MessageConst.ERR_009);

                return;
            }

            WordConverter_v2.Settings1.Default.Pascal = this.pascalCaseCheckBox.Checked;
            WordConverter_v2.Settings1.Default.Camel = this.camelCaseCheckBox.Checked;
            WordConverter_v2.Settings1.Default.Snake = this.snakeCaseCheckBox.Checked;
            WordConverter_v2.Settings1.Default.DispNumber = this.getDisplayNumber(this);
            WordConverter_v2.Settings1.Default.HotKey = this.hotKey.Text;
            WordConverter_v2.Settings1.Default.Save();

            UserInfoBo userInfo = new UserInfoBo();
            userInfo.hotKey = WordConverter_v2.Settings1.Default.HotKey;
            userInfo.dispNumber = WordConverter_v2.Settings1.Default.DispNumber;
            BaseForm form = new BaseForm(userInfo);

            MessageBox.Show("設定を登録しました。");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kojin"></param>
        /// <returns></returns>
        private int getDisplayNumber(Kojin kojin)
        {
            if (this.displayNumberRadioBtn1.Checked)
            {
                return 10;
            }
            if (this.displayNumberRadioBtn2.Checked)
            {
                return 20;
            }
            if (this.displayNumberRadioBtn3.Checked)
            {
                return 30;
            }
            return 0;
        }

        private void clear_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kojin_Load(object sender, EventArgs e)
        {
            this.hotKey.Text = WordConverter_v2.Settings1.Default.HotKey;
            this.pascalCaseCheckBox.Checked = WordConverter_v2.Settings1.Default.Pascal;
            this.camelCaseCheckBox.Checked = WordConverter_v2.Settings1.Default.Camel;
            this.snakeCaseCheckBox.Checked = WordConverter_v2.Settings1.Default.Snake;

            switch (WordConverter_v2.Settings1.Default.DispNumber)
            {
                case 10:
                    this.displayNumberRadioBtn1.Checked = true;
                    break;
                case 20:
                    this.displayNumberRadioBtn2.Checked = true;
                    break;
                case 30:
                    this.displayNumberRadioBtn3.Checked = true;
                    break;
                case 0:
                    this.displayNumberRadioBtn4.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotKey_KeyDown(object sender, KeyEventArgs e)
        {
            string str = "";

            if ((e.KeyData & Keys.Modifiers) == Keys.Shift)
            {
                str = "Shift";
            }
            if ((e.KeyData & Keys.Modifiers) == Keys.Control)
            {
                str = "Ctrl";
            }
            if ((e.KeyData & Keys.Modifiers) == Keys.Alt)
            {
                str = "Alt";
            }

            string s = e.KeyCode.ToString();
            s = s.Replace("ControlKey", "");
            s = s.Replace("ShiftKey", "");
            s = s.Replace("AltKey", "");

            if (s.Length == 1 && System.Text.RegularExpressions.Regex.IsMatch(
                s.ToUpper(), @"[A-Z]"))
            {
                if (String.IsNullOrEmpty(str))
                {
                    str += s.ToUpper();
                }
                else
                {
                    str += " + " + s.ToUpper();
                }
            }

            this.hotKey.Text = str;
        }

        private void Kojin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void pascalCaseCheckBox_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(this.groupBox1, "");
        }

        private void camelCaseCheckBox_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(this.groupBox1, "");
        }

        private void snakeCaseCheckBox_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(this.groupBox1, "");
        }

        private void pascalCaseCheckBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetError(this.groupBox1, "");
        }

        private void camelCaseCheckBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetError(this.groupBox1, "");
        }

        private void snakeCaseCheckBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetError(this.groupBox1, "");
        }
    }
}
