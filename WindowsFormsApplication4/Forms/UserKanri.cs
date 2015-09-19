using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConverter_v2.Const;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConverter_v2.Services;
using WordConvTool.Const;
using System.Linq;
using System.ComponentModel;
using WordConverter_v2.Models.Entity;

namespace WordConverter_v2.Forms
{
    public partial class UserKanri : Form
    {
        private static CommonFunction common = new CommonFunction();
        List<int> kengenValList = new List<int>();
        List<bool> sankaValList = new List<bool>();
        List<bool> checkValList = new List<bool>();

        /// <summary>
        /// 
        /// </summary>
        private static readonly UserKanri _instance = new UserKanri();
        private static bool isClickedAddBtn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static UserKanri Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private UserKanri()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_Click(object sender, EventArgs e)
        {
            this.searchAction(ref userKanriDataGridView1, this, false);

        }

        /// <summary>
        /// 検索アクション
        /// </summary>
        /// <param name="userKanriDataGridView1"></param>
        /// <param name="userKanri"></param>
        /// <param name="isDoneRegist"></param>
        private void searchAction(ref DataGridView userKanriDataGridView1, UserKanri userKanri, bool isDoneRegist)
        {
            errorProvider1.SetError(userKanri.empId, "");
            errorProvider1.SetError(userKanri.userName, "");
            errorProvider1.SetError(userKanri.kengen, "");

            if (!isDoneRegist && !this.searchPreCheck(userKanriDataGridView1))
            {
                return;
            }

            UserKanriSearchServiceInBo userSearchServiceInBo = new UserKanriSearchServiceInBo();
            UserKanriSearchService userSearchService = new UserKanriSearchService();
            userSearchServiceInBo.empId = userKanri.empId.Text;
            userSearchServiceInBo.userName = userKanri.userName.Text;
            userSearchServiceInBo.kengenSelectedIndex = userKanri.kengen.SelectedIndex;
            userSearchService.setInBo(userSearchServiceInBo);
            UserKanriSearchServiceOutBo userSearchServiceOutBo = userSearchService.execute();
            userKanriDataGridView1.DataSource = userSearchServiceOutBo.usersList;
            this.kensu.Text = userSearchServiceOutBo.usersList.Count.ToString();

            this.userKanriViewSetthing(ref userKanriDataGridView1);
        }

        /// <summary>
        /// 検索前チェック
        /// </summary>
        /// <param name="userKanriDataGridView1"></param>
        /// <returns></returns>
        private bool searchPreCheck(DataGridView userKanriDataGridView1)
        {
            for (int i = 0; i < userKanriDataGridView1.Rows.Count; i++)
            {
                if (userKanriDataGridView1.Rows[i].Cells["user_id"].Value.ToString().ToIntType() == 0)
                {
                    MyRepository rep = new MyRepository();
                    bool isExistUser = rep.IsExistUser(userKanriDataGridView1.Rows[i].Cells["emp_id"].Value.ToString().ToKeyType());
                    if (isExistUser)
                    {
                        continue;
                    }
                    DialogResult result = MessageBox.Show(
                        "追加した単語がクリアされますがよろしいですか？",
                        "確認",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ユーザー管理データグリッドを設定
        /// </summary>
        /// <param name="dataGridView1"></param>
        private void userKanriViewSetthing(ref DataGridView dataGridView1)
        {
            this.setKengenComboBox(ref dataGridView1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sankaValList = new List<bool>();
                sankaValList.Add((bool)dataGridView1.Rows[i].Cells["sanka_kahi"].Value);
            }
            common.addCheckBox(ref dataGridView1, dataGridView1.Columns["sanka_kahi"].Index);
            common.addCheckBox(ref dataGridView1, 0);
            common.checkBoxWidthSetting(ref dataGridView1, 20, 100);

            dataGridView1.Columns["emp_id"].HeaderText = "ユーザーID";
            dataGridView1.Columns["user_name"].HeaderText = "ユーザー名";
            dataGridView1.Columns["kengen"].HeaderText = "権限";
            dataGridView1.Columns["mail_id"].HeaderText = "メールID";
            dataGridView1.Columns["mail_address"].HeaderText = "メールアドレス";
            dataGridView1.Columns["password"].HeaderText = "パスワード";
            dataGridView1.Columns["sanka_kahi"].HeaderText = "参加可否";
            dataGridView1.Columns["cre_date"].HeaderText = "更新日付";
            dataGridView1.Columns["user_id"].Visible = false;
            dataGridView1.Columns["delete_flg"].Visible = false;
            dataGridView1.Columns["version"].Visible = false;
            dataGridView1.Columns["emp_id"].ReadOnly = true;
            dataGridView1.Columns["user_name"].ReadOnly = true;
            dataGridView1.Columns["kengen"].ReadOnly = true;
            dataGridView1.Columns["mail_id"].ReadOnly = true;
            dataGridView1.Columns["mail_address"].ReadOnly = true;
            dataGridView1.Columns["password"].ReadOnly = true;
            dataGridView1.Columns["sanka_kahi"].ReadOnly = true;
            dataGridView1.Columns["delete_flg"].ReadOnly = true;
            dataGridView1.Columns["version"].ReadOnly = true;
            dataGridView1.Columns["cre_date"].ReadOnly = true;
            dataGridView1.Columns["mail_address"].Width = 150;
            dataGridView1.Columns["kengen"].Width = 70;
            dataGridView1.Columns["sanka_kahi"].Width = 70;
            dataGridView1.Columns["cre_date"].Width = 110;
            dataGridView1.Columns["emp_id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["user_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["kengen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["mail_id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["mail_address"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["password"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["sanka_kahi"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["cre_date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["user_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 権限コンボボックスを作成
        /// </summary>
        /// <param name="dataGridView1"></param>
        private void setKengenComboBox(ref DataGridView dataGridView1)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                kengenValList = new List<int>();
                kengenValList.Add((int)dataGridView1.Rows[i].Cells["Kengen"].Value);
            }
            bool isExistComboBox = false;
            foreach (Object obj in dataGridView1.Columns)
            {
                if (obj is DataGridViewComboBoxColumn)
                {
                    isExistComboBox = true;
                }
            }
            if (!isExistComboBox)
            {
                DataTable kengenTable = new DataTable("Kengen");
                kengenTable.Columns.Add("Display", typeof(string));
                kengenTable.Columns.Add("Value", typeof(int));
                kengenTable.Rows.Add("管理", 0);
                kengenTable.Rows.Add("一般", 1);
                kengenTable.Rows.Add("メーリングリスト", 2);
                DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                column.DataPropertyName = dataGridView1.Columns["Kengen"].DataPropertyName;
                column.DataSource = kengenTable;
                column.ValueMember = "Value";
                column.DisplayMember = "Display";
                int index = dataGridView1.Columns["Kengen"].Index;
                dataGridView1.Columns.Remove("Kengen");
                dataGridView1.Columns.Insert(index, column);
                dataGridView1.Columns[index].Name = "Kengen";
            }
        }

        /// <summary>
        /// 追加ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {
            if (!this.addPreCheck(this))
            {
                return;
            }

            UserKanriAddServiceInBo userAddServiceInBo = new UserKanriAddServiceInBo();
            userAddServiceInBo.empId = this.empId.Text.ToString();
            userAddServiceInBo.userName = this.userName.Text.ToString();
            userAddServiceInBo.kengenSelectedIndex = this.kengen.SelectedIndex;
            userAddServiceInBo.userKanriDataGridView1 = this.userKanriDataGridView1;
            UserKanriAddService userAddService = new UserKanriAddService();
            userAddService.setInBo(userAddServiceInBo);
            UserKanriAddServiceOutBo shinseiServiseOutBo = userAddService.execute();

            if (!String.IsNullOrEmpty(shinseiServiseOutBo.errorMessage))
            {
                MessageBox.Show(
                    shinseiServiseOutBo.errorMessage,
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            this.userKanriDataGridView1.DataSource = shinseiServiseOutBo.userList;
            this.userKanriViewSetthing(ref this.userKanriDataGridView1);
            this.setCheckValList(ref this.userKanriDataGridView1);

        }

        /// <summary>
        /// 追加前チェック
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private bool addPreCheck(UserKanri form)
        {
            bool isNgRequired = false;
            if (String.IsNullOrEmpty(form.empId.Text))
            {
                errorProvider1.SetError(form.empId, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(form.userName.Text))
            {
                errorProvider1.SetError(form.userName, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(form.kengen.Text) || form.kengen.Text.ToIntType() == 2)
            {
                errorProvider1.SetError(form.kengen, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (isNgRequired)
            {
                return false;
            }

            MyRepository rep = new MyRepository();
            UserMst mailUser = rep.FindMailingListUser();

            if (!String.IsNullOrEmpty(mailUser.user_name) && form.kengen.SelectedIndex == (int)KengenKbn.メーリングリスト)
            {
                errorProvider1.SetError(form.kengen, MessageConst.ERR_008);
                return false;
            }

            checkValList = new List<bool>();
            for (int i = 0; i < form.userKanriDataGridView1.Rows.Count; i++)
            {
                if (form.userKanriDataGridView1.Rows[i].Cells[0].Value != null &&
                    (bool)form.userKanriDataGridView1.Rows[i].Cells[0].Value != false)
                {
                    checkValList.Add((bool)form.userKanriDataGridView1.Rows[i].Cells[0].Value);
                    continue;
                }
                checkValList.Add(false);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        private void setCheckValList(ref DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells["emp_id"].Value.ToString().ToIntType()
                    != this.empId.Text.ToString().ToIntType())
                {
                    dataGridView.Rows[i].Cells[0].Value = checkValList[i];
                    continue;
                }
                dataGridView.Rows[i].Cells[0].Value = true;
                break;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value != null &&
                    (bool)dataGridView.Rows[i].Cells[0].Value == true)
                {
                    dataGridView.Rows[i].Cells["user_name"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["kengen"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["mail_id"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["mail_address"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["password"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["sanka_kahi"].ReadOnly = false;
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Constant.CHECK_BOX_ON_COLOR;
                }
            }
        }

        /// <summary>
        /// 登録ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regist_Click(object sender, EventArgs e)
        {
            UserKanriRegistServiceInBo userRegistServiceInBo = new UserKanriRegistServiceInBo();
            userRegistServiceInBo.empId = this.empId.Text.ToString();
            userRegistServiceInBo.userName = this.userName.Text.ToString();
            userRegistServiceInBo.kengenSelectedIndex = this.kengen.SelectedIndex;
            userRegistServiceInBo.userKanriDataGridView1 = this.userKanriDataGridView1;
            UserKanriRegistService userRegistService = new UserKanriRegistService();
            userRegistService.setInBo(userRegistServiceInBo);
            UserKanriRegistServiceOutBo userRegistServiceOutBo = userRegistService.execute();

            if (!String.IsNullOrEmpty(userRegistServiceOutBo.errorMessage))
            {
                MessageBox.Show(
                    userRegistServiceOutBo.errorMessage,
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(MessageConst.CONF_004);
            if (BaseForm.UserInfo.empId == userRegistServiceOutBo.empId)
            {
                MessageBox.Show(MessageConst.CONF_009);
            }
            bool isDoneRegist = true;
            this.searchAction(ref userKanriDataGridView1, this, isDoneRegist);
        }


        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            if (!this.deletePreCheck(this))
            {
                return;
            }
            for (int i = 0; i < this.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                MyRepository rep = new MyRepository();
                rep.DeleteUserByUserId(this.userKanriDataGridView1.Rows[i].Cells["user_id"].Value.ToString().ToKeyType());
            }
            MessageBox.Show(MessageConst.CONF_005);
            this.searchAction(ref userKanriDataGridView1, this, false);
        }

        /// <summary>
        /// 削除前チェック
        /// </summary>
        /// <param name="userKanri"></param>
        /// <returns></returns>
        private bool deletePreCheck(UserKanri userKanri)
        {
            bool isExistCheck = false;
            for (int i = 0; i < userKanri.userKanriDataGridView1.Rows.Count; i++)
            {
                if (userKanri.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(userKanri.userKanriDataGridView1.Rows[i].Cells["user_id"].Value.ToString());
                    var u = context.UserMst.Single(x => x.user_id == condtion);
                    u.delete_flg = 1;
                    u.cre_date = System.DateTime.Now.ToString();
                    context.SaveChanges();
                }
                isExistCheck = true;
            }
            if (!isExistCheck)
            {
                MessageBox.Show(
                    MessageConst.ERR_005,
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            DialogResult result = MessageBox.Show(
                MessageConst.CONF_010,
                "確認",
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
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.userKanriDataGridView1 != null && this.userKanriDataGridView1.Rows.Count > 0)
            {
                //列のインデックスを確認する
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    if (!this.isAddMode(this.userKanriDataGridView1))
                    {
                        this.columnsReadOnlyValueChange(ref this.userKanriDataGridView1, e.RowIndex);
                    }
                }
            }
        }

        /// <summary>
        /// 追加モードか判定
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private bool isAddMode(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(dataGridView.Rows[i].Cells["user_id"].Value.ToString().ToIntType());
                if (dataGridView.Rows[i].Cells["user_id"].Value.ToString().ToIntType() == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="rowIndex"></param>
        private void columnsReadOnlyValueChange(ref DataGridView dataGridView1, int rowIndex)
        {
            dataGridView1.Rows[rowIndex].Cells["user_name"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["user_name"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["kengen"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["kengen"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["mail_id"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["mail_id"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["mail_address"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["mail_address"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["password"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["password"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["sanka_kahi"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["sanka_kahi"].ReadOnly;
            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = common.switchRowBackColor(dataGridView1.Rows[rowIndex]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (userKanriDataGridView1.CurrentCellAddress.X == 0 && userKanriDataGridView1.IsCurrentCellDirty)
            {
                //コミットする
                userKanriDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex < kengenValList.Count - 1)
                {
                    string val = ((KengenKbn)kengenValList[e.RowIndex]).ToString();
                    e.Value = val;
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex < sankaValList.Count - 1)
                {
                    bool val = (bool)sankaValList[e.RowIndex];
                    e.Value = val;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserKanri_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empId_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.empId, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.userName, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kengen_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.kengen, "");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.empId.Text = "";
            this.userName.Text = "";
            this.kengen.Text = "";
        }

        private void UserKanri_Load(object sender, EventArgs e)
        {
            this.searchAction(ref userKanriDataGridView1, this, false);
        }

    }
}
