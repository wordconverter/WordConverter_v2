using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConverter_v2.Const;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConverter_v2.Services;
using WordConvTool.Const;
using System.Linq;

namespace WordConverter_v2.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Shinsei : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private static CommonFunction common = new CommonFunction();
        public string kensakuWord { get; set; }
        public bool allCheckBoxValue { get; set; }


        private static readonly Shinsei _instance = new Shinsei();
        public static Shinsei Instance
        {
            get
            {
                return _instance;
            }
        }

        private Shinsei()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void moveShinsei(string text)
        {
            this.ronrimei1TextBox.Text = text.Trim();
            if (BaseForm.UserInfo.kengen == Constant.IPPAN)
            {
                this.shounin.Enabled = false;
                this.kyakka.Enabled = false;
            }
            if (BaseForm.UserInfo.kengen == Constant.KANRI)
            {
                this.shinseiButton.Enabled = false;
                this.clearButton.Enabled = false;
                this.ronrimei1TextBox.Enabled = false;
                this.ronrimei2TextBox.Enabled = false;
                this.butsurimeiTextBox.Enabled = false;
                errorProvider1.SetError(this.ronrimei1TextBox, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shinseiButton_Click(object sender, EventArgs e)
        {
            bool isNgRequired = false;
            if (String.IsNullOrEmpty(this.ronrimei1TextBox.Text))
            {
                errorProvider1.SetError(this.ronrimei1TextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.ronrimei2TextBox.Text))
            {
                errorProvider1.SetError(this.ronrimei2TextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.butsurimeiTextBox.Text))
            {
                errorProvider1.SetError(this.butsurimeiTextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (isNgRequired)
            {
                return;
            }

            ShinseiShinseiServiceInBo shinseiServiseInBo = new ShinseiShinseiServiceInBo();
            ShinseiShinseiService shinseiService = new ShinseiShinseiService();
            shinseiServiseInBo.clipboardText = Clipboard.GetText();
            shinseiServiseInBo.ronrimei1TextBox = this.ronrimei1TextBox.Text;
            shinseiServiseInBo.ronrimei2TextBox = this.ronrimei2TextBox.Text;
            shinseiServiseInBo.butsurimeiTextBox = this.butsurimeiTextBox.Text;
            shinseiService.setInBo(shinseiServiseInBo);
            ShinseiShinseiServiceOutBo shinseiServiseOutBo = shinseiService.execute();

            if (!String.IsNullOrEmpty(shinseiServiseOutBo.errorMessage))
            {
                MessageBox.Show(shinseiServiseOutBo.errorMessage, MessageConst.ERR_003, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Shinsei_Load(sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.ronrimei1TextBox.Clear();
            this.ronrimei2TextBox.Clear();
            this.butsurimeiTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Shinsei_Load(object sender, EventArgs e)
        {
            ShinseiInitServiceInBo initServiceInBo = new ShinseiInitServiceInBo();
            ShinseiInitService initService = new ShinseiInitService();
            initServiceInBo.clipboardText = Clipboard.GetText();
            initService.setInBo(initServiceInBo);
            ShinseiInitServiceOutBo initServiceOutBo = initService.execute();
            this.shinseiDataGridView1.DataSource = initServiceOutBo.dispShinseiList;

            this.kensu.Text = initServiceOutBo.dispShinseiList.Count.ToString();

            common.addCheckBox(ref shinseiDataGridView1, 0);
            common.checkBoxWidthSetting(ref shinseiDataGridView1, 20, 100);

            shinseiDataGridView1.Columns["ronri_name1"].HeaderText = "論理名1";
            shinseiDataGridView1.Columns["ronri_name2"].HeaderText = "論理名2";
            shinseiDataGridView1.Columns["butsuri_name"].HeaderText = "物理名";
            shinseiDataGridView1.Columns["status"].HeaderText = "ステータス";
            shinseiDataGridView1.Columns["user_name"].HeaderText = "登録ユーザー名";
            shinseiDataGridView1.Columns["cre_date"].HeaderText = "登録日付";
            shinseiDataGridView1.Columns["shinsei_id"].Visible = false;
            shinseiDataGridView1.Columns["version"].Visible = false;
            shinseiDataGridView1.Columns["ronri_name1"].ReadOnly = true;
            shinseiDataGridView1.Columns["ronri_name2"].ReadOnly = true;
            shinseiDataGridView1.Columns["butsuri_name"].ReadOnly = true;
            shinseiDataGridView1.Columns["status"].ReadOnly = true;
            shinseiDataGridView1.Columns["user_name"].ReadOnly = true;
            shinseiDataGridView1.Columns["cre_date"].ReadOnly = true;
            shinseiDataGridView1.Columns["status"].Width = 80;
            shinseiDataGridView1.Columns["user_name"].Width = 120;
            shinseiDataGridView1.Columns["cre_date"].Width = 120;
            shinseiDataGridView1.Columns["ronri_name1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            shinseiDataGridView1.Columns["ronri_name2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            shinseiDataGridView1.Columns["butsuri_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            shinseiDataGridView1.Columns["user_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            shinseiDataGridView1.Columns["cre_date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shounin_Click(object sender, EventArgs e)
        {
            if (!this.shouninPreCheck(this.shinseiDataGridView1)) { return; }

            for (int i = 0; i < shinseiDataGridView1.Rows.Count; i++)
            {
                if (shinseiDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)shinseiDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.shinseiDataGridView1.Rows[i].Cells["shinsei_id"].Value.ToString());

                    var w = context.WordShinsei.Single(x => x.shinsei_id == condtion);
                    w.cre_date = System.DateTime.Now.ToString();
                    w.status = 1;

                    WordDic word = new WordDic();
                    word.ronri_name1 = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["ronri_name1"].Value);
                    word.ronri_name2 = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["ronri_name2"].Value);
                    word.butsuri_name = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["butsuri_name"].Value);
                    word.user_id = BaseForm.UserInfo.userId;
                    word.cre_date = System.DateTime.Now.ToString();
                    context.WordDic.Add(word);
                    context.SaveChanges();
                }
            }
            MessageBox.Show(MessageConst.CONF_002);
            this.Shinsei_Load(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private bool shouninPreCheck(DataGridView dataGridView)
        {
            int upCount = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null
                    || (bool)dataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                upCount++;
            }
            if (upCount == 0)
            {
                MessageBox.Show(MessageConst.ERR_004);
                return false;
            }

            DialogResult result = MessageBox.Show(
                MessageConst.CONF_006,
                "承認確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kyakka_Click(object sender, EventArgs e)
        {
            if (!this.kyakkaPreCheck(this.shinseiDataGridView1)) { return; }

            for (int i = 0; i < shinseiDataGridView1.Rows.Count; i++)
            {
                if (shinseiDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)shinseiDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.shinseiDataGridView1.Rows[i].Cells["shinsei_id"].Value.ToString());
                    var w = context.WordShinsei.Single(x => x.shinsei_id == condtion);
                    w.cre_date = System.DateTime.Now.ToString();
                    w.status = 2;
                    context.SaveChanges();
                }
            }
            MessageBox.Show(MessageConst.CONF_003);
            this.Shinsei_Load(sender, e);
        }

        private bool kyakkaPreCheck(DataGridView dataGridView)
        {
            int upCount = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null
                    || (bool)dataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                upCount++;
            }
            if (upCount == 0)
            {
                MessageBox.Show(MessageConst.ERR_004);
                return false;
            }

            DialogResult result = MessageBox.Show(
                MessageConst.CONF_007,
                "却下確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void Shinsei_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ronrimei2TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ronrimei2TextBox.Text)
                && !Regex.IsMatch(this.ronrimei2TextBox.Text, @"^\p{IsHiragana}*$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.ronrimei2TextBox, "ひらがな以外が入力されました。");
            }
        }

        private void ronrimei1TextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.ronrimei1TextBox, "");
        }

        private void ronrimei2TextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.ronrimei2TextBox, "");

        }

        private void butsurimeiTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.butsurimeiTextBox, "");
        }

        private void shinseiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


