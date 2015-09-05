using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConverter_v2.Const;
using WordConverter_v2.Models;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConverter_v2.Services;
using WordConvTool.Const;

namespace WordConverter_v2.Forms
{
    public partial class Henshu : Form
    {
        /// <summary>
        /// 共通関数インクルード
        /// </summary>
        private static CommonFunction common = new CommonFunction();
        private HenshuInBo henshuInBo = new HenshuInBo();
        private int lastRows;

        private static readonly Henshu _instance = new Henshu();
        public static Henshu Instance
        {
            get
            {
                return _instance;
            }
        }
        private Henshu()
        {
            InitializeComponent();
        }


        internal void moveHenshu(string clipBoardText, int selectedIndex)
        {
            this.ronrimei1TextBox.Text = clipBoardText;
            this.tabControl1.SelectedIndex = selectedIndex;

        }


        /// <summary>
        /// 「読み込み」アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readFile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.filePath.Text))
            {
                errorProvider1.SetError(this.filePath, MessageConst.ERR_001);
                return;
            }

            IkkatsuTorokuReadFileService readFileService = new IkkatsuTorokuReadFileService();
            IkkatsuTorokuReadFileServiceInBo readFileServiceInBo = new IkkatsuTorokuReadFileServiceInBo();
            readFileServiceInBo.Filename = this.filePath.Text;
            readFileService.setInBo(readFileServiceInBo);
            IkkatsuTorokuReadFileServiceOutBo registServiceOutBo = readFileService.execute();

            if (!String.IsNullOrEmpty(registServiceOutBo.errorMessage))
            {
                MessageBox.Show(
                    registServiceOutBo.errorMessage,
                    MessageConst.ERR_003,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
        }

        private void ProgressDialog_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            //パラメータを取得する
            int stopTime = (int)e.Argument;

            //時間のかかる処理を開始する
            for (int i = 1; i <= lastRows; i++)
            {
                //キャンセルされたか調べる
                if (bw.CancellationPending)
                {
                    //キャンセルされたとき
                    e.Cancel = true;
                    return;
                }

                //指定された時間待機する
                System.Threading.Thread.Sleep(stopTime);

                //ProgressChangedイベントハンドラを呼び出し、
                //コントロールの表示を変更する
                bw.ReportProgress(i, i.ToString() + "% 終了しました");
            }

            //結果を設定する
            e.Result = stopTime * lastRows;
        }


        /// <summary>
        /// 「開く」アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.filePath.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 検索アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.searchAction(ref this.tanitsuDataGridView, this);

        }

        /// <summary>
        /// 検索サービス
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="henshu"></param>
        private void searchAction(ref DataGridView dataGridView, Henshu henshu)
        {
            TanitsuTorokuSearchServiceInBo torokuSearchServiceInBo = new TanitsuTorokuSearchServiceInBo();
            TanitsuTorokuSearchService torokuSearchService = new TanitsuTorokuSearchService();
            torokuSearchServiceInBo.ronrimei1TextBox = henshu.ronrimei1TextBox.Text;
            torokuSearchServiceInBo.butsurimeiTextBox = henshu.butsurimeiTextBox.Text;
            torokuSearchService.setInBo(torokuSearchServiceInBo);
            TanitsuTorokuSearchServiceOutBo torokuSearchServiceOutBo = torokuSearchService.execute();
            this.henshuViewDispSetthing(ref dataGridView, torokuSearchServiceOutBo.wordList);
        }


        /// <summary>
        /// クリアアクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.ronrimei1TextBox.Text = "";
            this.butsurimeiTextBox.Text = "";
        }


        /// <summary>
        /// 追加アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            bool isNgRequired = false;
            if (String.IsNullOrEmpty(this.ronrimei1TextBox.Text))
            {
                errorProvider1.SetError(this.ronrimei1TextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.dataTypeCbx.Text))
            {
                errorProvider1.SetError(this.dataTypeCbx, MessageConst.ERR_001);
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
            TanitsuTorokuAddServiceInBo addServiseInBo = new TanitsuTorokuAddServiceInBo();
            TanitsuTorokuAddService addService = new TanitsuTorokuAddService();
            addServiseInBo.ronrimei1TextBox = this.ronrimei1TextBox.Text;
            addServiseInBo.butsurimeiTextBox = this.butsurimeiTextBox.Text;
            addServiseInBo.dataType = this.dataTypeCbx.Text;
            addServiseInBo.tanitsuDataGridView = this.tanitsuDataGridView;
            addServiseInBo.registeredPairsFlg = this.registeredPairsCbx.Checked;
            addService.setInBo(addServiseInBo);
            TanitsuTorokuAddServiceOutBo addServiseOutBo = addService.execute();

            if (!String.IsNullOrEmpty(addServiseOutBo.errorMessage))
            {
                MessageBox.Show(
                    addServiseOutBo.errorMessage,
                    MessageConst.ERR_003,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            this.henshuViewDispSetthing(ref this.tanitsuDataGridView, addServiseOutBo.wordList);
        }



        /// <summary>
        /// 単一登録・登録アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registBtn_Click(object sender, EventArgs e)
        {
            if (!this.registrationPreCheck(this.tanitsuDataGridView)) { return; }

            TanitsuTorokuRegistService tanitsuRegistService = new TanitsuTorokuRegistService();
            TanitsuTorokuRegistServiceInBo tanitsuRegistServiceInBo = new TanitsuTorokuRegistServiceInBo();
            tanitsuRegistServiceInBo.tanitsuDataGridView = this.tanitsuDataGridView;
            tanitsuRegistService.setInBo(tanitsuRegistServiceInBo);
            TanitsuTorokuRegistServiceOutBo tanitsuRegistServiceOutBo = tanitsuRegistService.execute();

            this.searchAction(ref this.tanitsuDataGridView, this);
            MessageBox.Show(MessageConst.CONF_001);
        }


        /// 登録事前チェック
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private bool registrationPreCheck(DataGridView dataGridView)
        {
            bool isExistCheckWord = false;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null
                    || (bool)dataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                isExistCheckWord = true;
            }

            if (!isExistCheckWord)
            {
                MessageBox.Show(
                    "単語が選択されていません。\n",
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null
                    || (bool)dataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                if (dataGridView.Rows[i].Cells["data_type"].Value != null
                    && !string.IsNullOrWhiteSpace(dataGridView.Rows[i].Cells["data_type"].Value.ToString())
                    && dataGridView.Rows[i].Cells["butsuri_name"].Value != null
                    && !string.IsNullOrWhiteSpace(dataGridView.Rows[i].Cells["butsuri_name"].Value.ToString()))
                {
                    continue;
                }

                MessageBox.Show(
                        "必須項目が入力されていません。",
                        "入力エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                return false;

            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null
                    || (bool)dataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                if (this.isCorrectDataType(dataGridView.Rows[i].Cells["data_type"].Value.ToString()))
                {
                    continue;
                }

                MessageBox.Show(
                        "データ型が不正です。",
                        "入力エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                return false;

            }

            DialogResult result = MessageBox.Show(
                "選択された単語を登録してもよろしいですか？",
                "登録確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 一括登録・登録アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ikkatsuRegistBtn_Click(object sender, EventArgs e)
        {
            IkkatsuTorokuIkkatsuRegistService ikkatsuRegistService = new IkkatsuTorokuIkkatsuRegistService();
            IkkatsuTorokuIkkatsuRegistServiceInBo ikkatsuRegistServiceInBo = new IkkatsuTorokuIkkatsuRegistServiceInBo();
            ikkatsuRegistServiceInBo.ikkatsuDataGridView = this.ikkatsuDataGridView;
            ikkatsuRegistService.setInBo(ikkatsuRegistServiceInBo);
            IkkatsuTorokuIkkatsuRegistServiceOutBo outBo = ikkatsuRegistService.execute();
            MessageBox.Show("辞書テーブルに登録・更新しました。");
        }


        /// <summary>
        /// 削除アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            if (!this.deletePreCheck(this.tanitsuDataGridView)) { return; }
            TanitsuTorokuDeleteService deleteService = new TanitsuTorokuDeleteService();
            TanitsuTorokuDeleteServiceInBo deleteServiceInBo = new TanitsuTorokuDeleteServiceInBo();
            deleteServiceInBo.tanitsuDataGridView = this.tanitsuDataGridView;
            deleteService.setInBo(deleteServiceInBo);
            TanitsuTorokuDeleteServiceOutBo deleteServiceOutBo = (TanitsuTorokuDeleteServiceOutBo)deleteService.execute();
            this.searchAction(ref this.tanitsuDataGridView, this);
        }

        /// <summary>
        /// 削除事前チェック
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private bool deletePreCheck(DataGridView dataGridView)
        {
            bool isExistCheckWord = false;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null
                    || (bool)dataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                isExistCheckWord = true;
            }

            if (!isExistCheckWord)
            {
                MessageBox.Show(
                    "単語が選択されていません。\n",
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells["word_id"].Value.ToString().ToIntType() == 0)
                {
                    MessageBox.Show(
                        "登録されていない単語の削除はできません。\n",
                        "入力エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }

            DialogResult result = MessageBox.Show(
                "選択された単語を削除してもよろしいですか？",
                "削除確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// タブコントロール初期表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == Constant.TANITSU_TOROKU)
            {
                this.searchAction(ref this.tanitsuDataGridView, this);

            }
            else if (e.TabPageIndex == Constant.IKKATSU_TOROKU)
            {
                IkkatsuTorokuInitService ikkatsuService = new IkkatsuTorokuInitService();
                IkkatsuTorokuInitServiceInBo inBo = new IkkatsuTorokuInitServiceInBo();
                inBo.clipboardText = this.henshuInBo.clipBoardText;
                ikkatsuService.setInBo(inBo);
                IkkatsuTorokuInitServiceOutBo outBo = ikkatsuService.execute();
                this.henshuViewDispSetthing(ref this.ikkatsuDataGridView, outBo.henshuWordBoList);
                this.searchAction(ref this.ikkatsuDataGridView, this);
            }
        }

        /// <summary>
        /// 編集画面データグリッドビュー表示設定処理
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="wordList"></param>
        private void henshuViewDispSetthing(ref DataGridView dataGridView, List<HenshuWordBo> wordList)
        {
            dataGridView.DataSource = wordList;
            common.addCheckBox(ref dataGridView, 0);
            common.checkBoxWidthSetting(ref dataGridView, 20, 120);

            this.kensu.Text = wordList.Count.ToString();

            dataGridView.Columns["ronri_name1"].HeaderText = "論理名1";
            dataGridView.Columns["butsuri_name"].HeaderText = "物理名";
            dataGridView.Columns["data_type"].HeaderText = "データ型";
            dataGridView.Columns["user_name"].HeaderText = "登録ユーザー";
            dataGridView.Columns["cre_date"].HeaderText = "登録日付";
            dataGridView.Columns["word_id"].Visible = false;
            dataGridView.Columns["version"].Visible = false;
            dataGridView.Columns["ronri_name1"].ReadOnly = true;
            dataGridView.Columns["butsuri_name"].ReadOnly = true;
            dataGridView.Columns["data_type"].ReadOnly = true;
            dataGridView.Columns["user_name"].ReadOnly = true;
            dataGridView.Columns["cre_date"].ReadOnly = true;
            dataGridView.Columns["ronri_name1"].Width = 150;
            dataGridView.Columns["butsuri_name"].Width = 150;
            dataGridView.Columns["data_type"].Width = 80;
            dataGridView.Columns["user_name"].Width = 100;
            dataGridView.Columns["cre_date"].Width = 130;

            dataGridView.Columns["ronri_name1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["butsuri_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["data_type"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["user_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["cre_date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 要素重複判定メソッド
        /// </summary>
        /// <param name="tango"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        private bool isContains(string tango, List<HenshuWordBo> wordList)
        {
            if (wordList.Count > 0)
            {
                foreach (HenshuWordBo obj in wordList)
                {
                    if (obj.butsuri_name == tango)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 検索アクションサービス
        /// </summary>
        /// <param name="dataGridView"></param>
        private void searchAction(ref DataGridView dataGridView)
        {
            TanitsuTorokuSearchServiceInBo torokuSearchServiceInBo = new TanitsuTorokuSearchServiceInBo();
            TanitsuTorokuSearchService torokuSearchService = new TanitsuTorokuSearchService();
            torokuSearchServiceInBo.ronrimei1TextBox = this.ronrimei1TextBox.Text;
            //torokuSearchServiceInBo.ronrimei2TextBox = this.ronrimei2TextBox.Text;
            torokuSearchServiceInBo.butsurimeiTextBox = this.butsurimeiTextBox.Text;
            torokuSearchService.setInBo(torokuSearchServiceInBo);
            TanitsuTorokuSearchServiceOutBo torokuSearchServiceOutBo = torokuSearchService.execute();
            this.henshuViewDispSetthing(ref dataGridView, torokuSearchServiceOutBo.wordList);
        }

        /// <summary>
        /// 編集画面初期処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Henshu_Load(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == Constant.TANITSU_TOROKU)
            {
                this.searchAction(ref this.tanitsuDataGridView, this);
            }
            else if (tabControl1.SelectedIndex == Constant.IKKATSU_TOROKU)
            {
                IkkatsuTorokuInitService ikkatsuService = new IkkatsuTorokuInitService();
                IkkatsuTorokuInitServiceInBo inBo = new IkkatsuTorokuInitServiceInBo();
                inBo.clipboardText = this.henshuInBo.clipBoardText;
                ikkatsuService.setInBo(inBo);
                IkkatsuTorokuInitServiceOutBo outBo = ikkatsuService.execute();
                this.henshuViewDispSetthing(ref this.ikkatsuDataGridView, outBo.henshuWordBoList);
            }
        }

        private void Henshu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        private void ronrimei1TextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.ronrimei1TextBox, "");
        }

        private void butsurimeiTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.butsurimeiTextBox, "");
        }

        private void tanitsuDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tanitsuDataGridView != null && this.tanitsuDataGridView.Rows.Count > 0)
            {
                //列のインデックスを確認する
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    this.columnsReadOnlyValueChange(ref this.tanitsuDataGridView, e.RowIndex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="rowIndex"></param>
        private void columnsReadOnlyValueChange(ref DataGridView dataGridView1, int rowIndex)
        {
            dataGridView1.Rows[rowIndex].Cells["butsuri_name"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["butsuri_name"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["data_type"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["data_type"].ReadOnly;
            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = common.switchRowBackColor(dataGridView1.Rows[rowIndex]);
        }

        private void tanitsuDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tanitsuDataGridView.CurrentCellAddress.X == 0 && tanitsuDataGridView.IsCurrentCellDirty)
            {
                //コミットする
                tanitsuDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            common.tabDrawItem(ref sender, ref e);
        }

        private void tanitsuDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
        }

        private void tanitsuDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //新しい行のセルでなく、セルの内容が変更されている時だけ検証する
            if (e.RowIndex == dgv.NewRowIndex || !dgv.IsCurrentCellDirty)
            {
                return;
            }

            if (dgv.Columns[e.ColumnIndex].Name == "butsuri_name" &&
                string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                dgv.Rows[e.RowIndex].Cells["butsuri_name"].ErrorText = "値が入力されていません。";
            }
            if (dgv.Columns[e.ColumnIndex].Name == "butsuri_name" &&
                !string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                dgv.Rows[e.RowIndex].Cells["butsuri_name"].ErrorText = "";
            }
            if (dgv.Columns[e.ColumnIndex].Name == "data_type" &&
                string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                dgv.Rows[e.RowIndex].Cells["data_type"].ErrorText = "値が入力されていません。";

            }
            if (dgv.Columns[e.ColumnIndex].Name == "data_type" &&
                !string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                dgv.Rows[e.RowIndex].Cells["data_type"].ErrorText = "";

            }
            if (dgv.Columns[e.ColumnIndex].Name == "data_type" &&
                !this.isCorrectDataType(e.FormattedValue.ToString()))
            {
                dgv.Rows[e.RowIndex].Cells["data_type"].ErrorText = "データ型が不正です。";

            }
            if (dgv.Columns[e.ColumnIndex].Name == "data_type" &&
                this.isCorrectDataType(e.FormattedValue.ToString()))
            {
                dgv.Rows[e.RowIndex].Cells["data_type"].ErrorText = "";

            }
        }

        private bool isCorrectDataType(string dataType)
        {
            List<String> dataTypeList = new List<string>();

            dataTypeList.Add("String");
            dataTypeList.Add("Integer");
            dataTypeList.Add("int");
            dataTypeList.Add("Boolean");
            dataTypeList.Add("boolean");
            dataTypeList.Add("byte");
            dataTypeList.Add("Byte");
            dataTypeList.Add("short");
            dataTypeList.Add("Short");
            dataTypeList.Add("long");
            dataTypeList.Add("Long");
            dataTypeList.Add("char");
            dataTypeList.Add("float");
            dataTypeList.Add("Float");
            dataTypeList.Add("double");
            dataTypeList.Add("Double");

            if (dataTypeList.Contains(dataType))
            {
                return true;
            }

            return false;
        }

        private void dataTypeCbx_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.dataTypeCbx, "");
        }

    }
}
