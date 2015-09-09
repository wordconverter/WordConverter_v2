using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConverter_v2.Services;
using WordConvTool.Const;

namespace WordConverter_v2.Forms
{
    public partial class Ichiran : Form
    {
        private static readonly Ichiran _instance = new Ichiran();
        public static Ichiran Instance
        {
            get
            {
                return _instance;
            }
        }
        private Ichiran()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 一覧画面フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ホットキーの登録抹消
            //UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        public void ichiran_Load()
        {
            IchiranInitServiceFukusuninMode initServiceFukusunin = new IchiranInitServiceFukusuninMode();
            IchiranInitServiceKojinMode initServiceKojin = new IchiranInitServiceKojinMode();

            IchiranInitServiceInBo initServiceInBo = new IchiranInitServiceInBo();
            initServiceInBo.clipboardText = Clipboard.GetText();
            initServiceInBo.dispNumber = BaseForm.UserInfo.dispNumber;
            initServiceFukusunin.setInBo(initServiceInBo);
            initServiceKojin.setInBo(initServiceInBo);

            IchiranInitServiceOutBo initServiceOutBo = new IchiranInitServiceOutBo();

            if (BaseForm.UserInfo.startUpMode == (int)StartUpMode.複数人)
            {
                initServiceOutBo = initServiceFukusunin.execute();
            }
            else if (BaseForm.UserInfo.startUpMode == (int)StartUpMode.個人)
            {
                initServiceOutBo = initServiceKojin.execute();
            }

            ichiranDataGridView.DataSource = initServiceOutBo.wordList;
            ichiranDataGridView.Columns["ronri_name1"].Width = 110;
            ichiranDataGridView.Columns["butsuri_name"].Width = 195;
            ichiranDataGridView.Columns["data_type"].Width = 0;
            ichiranDataGridView.Columns["data_type"].Visible = false;
            ichiranDataGridView.ReadOnly = true;

            //隠していたフォームを表示する
            this.Show();
            this.Activate();

            //透過性
            this.Opacity = 0.94;
        }

        /// <summary>
        /// 変換候補一覧のダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.setClipBordMyValue();
        }

        /// <summary>
        /// 変換候補一覧のエンターイベントイベント
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.setClipBordMyValue();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //マウスのクリック位置を記憶
        private Point mousePoint;

        /// <summary>
        /// マウス移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        /// <summary>
        /// マウス移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        /// <summary>
        /// データグリッドマウスクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //右クリックのときのみ
            if (e.Button == MouseButtons.Right)
            {
                int idx = ichiranDataGridView.CurrentCell.RowIndex;
                int rowindex = e.RowIndex;
                //マウスカーソルの位置を画面座標で取得
                Point p = Control.MousePosition;

                if (BaseForm.UserInfo.kengen == Constant.KANRI)
                {
                    //コンテキストメニューを表示する
                    this.kanriUserContextMenuStrip.Show();
                    this.kanriUserContextMenuStrip.Top = p.Y;
                    this.kanriUserContextMenuStrip.Left = p.X;
                }
                if (BaseForm.UserInfo.kengen == Constant.IPPAN)
                {
                    //コンテキストメニューを表示する
                    this.ippanUserContextMenuStrip.Show();
                    this.ippanUserContextMenuStrip.Top = p.Y;
                    this.ippanUserContextMenuStrip.Left = p.X;
                }

            }
        }

        /// <summary>
        /// コンテキストメニュー（申請）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 申請ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Shinsei shinsei = Shinsei.Instance;
            shinsei.Show();
            shinsei.Activate();
            shinsei.moveShinsei(Clipboard.GetText());
        }

        /// <summary>
        /// コンテキストメニュー（単一登録）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 単一登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Henshu henshu = Henshu.Instance;
            henshu.moveHenshu(Clipboard.GetText(), Constant.TANITSU_TOROKU);
            henshu.Show();
            henshu.Activate();
        }


        /// <summary>
        /// コンテキストメニュー（一括登録）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 一括登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Henshu henshu = Henshu.Instance;
            henshu.moveHenshu(Clipboard.GetText(), Constant.IKKATSU_TOROKU);
            henshu.Show();
            henshu.Activate();
        }


        /// <summary>
        /// データグリッドビューバインド完了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ichiranDataGridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ichiranDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        /// <summary>
        /// フォームヘッダーラベルマウスクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formHeanderLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// クリップボードに変換候補一覧の値を設定
        /// </summary>
        private void setClipBordMyValue()
        {
            StringBuilder val = new StringBuilder();
            int index = 0;
            foreach (DataGridViewCell c in ichiranDataGridView.SelectedCells)
            {
                if (!String.IsNullOrEmpty(c.Value.ToString()))
                {
                    if (index > 0)
                    {
                        val.AppendLine();
                    }
                    val.Append(c.Value);
                    index++;
                }
            }
            if (val.ToString().Trim() != Constant.NONE_WORD)
            {
                this.Close();
                Clipboard.SetText(val.ToString());
            }
            else
            {
                this.Close();
                if (BaseForm.UserInfo.kengen == Constant.KANRI)
                {
                    Henshu henshu = Henshu.Instance;
                    henshu.Show();
                    henshu.Activate();
                    henshu.moveHenshu(Clipboard.GetText(), Constant.TANITSU_TOROKU);
                }
                else
                {
                    Shinsei shinsei = Shinsei.Instance;
                    shinsei.Show();
                    shinsei.Activate();
                    shinsei.moveShinsei(Clipboard.GetText());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formHeanderLabel_MouseClick(object sender, MouseEventArgs e)
        {
            //右クリックのときのみ
            if (e.Button == MouseButtons.Right)
            {
                //コンテキストメニューを表示する
                this.closeContextMenuStrip.Show();
                //マウスカーソルの位置を画面座標で取得
                Point p = Control.MousePosition;
                this.closeContextMenuStrip.Top = p.Y;
                this.closeContextMenuStrip.Left = p.X;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void アプリ閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Ichiran_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// コンテキストメニュー（Bo作成）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void プロパティ作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IchiranBoCreateService boCreateService = new IchiranBoCreateService();
            IchiranBoCreateServiceInBo boCreateServiceInBo = new IchiranBoCreateServiceInBo();
            boCreateServiceInBo.ichiranDataGridView = this.ichiranDataGridView;
            boCreateServiceInBo.shoriMode = PropertyShoriMode.プロパティ作成;
            boCreateService.setInBo(boCreateServiceInBo);
            IchiranBoCreateServiceOutBo registServiceOutBo = boCreateService.execute();
            Clipboard.SetText(registServiceOutBo.boText);
            this.Close();
        }

        private void プロパティ作成アノテーションありToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IchiranBoCreateService boCreateService = new IchiranBoCreateService();
            IchiranBoCreateServiceInBo boCreateServiceInBo = new IchiranBoCreateServiceInBo();
            boCreateServiceInBo.ichiranDataGridView = this.ichiranDataGridView;
            boCreateServiceInBo.shoriMode = PropertyShoriMode.プロパティ作成アノテーションあり;
            boCreateService.setInBo(boCreateServiceInBo);
            IchiranBoCreateServiceOutBo registServiceOutBo = boCreateService.execute();
            Clipboard.SetText(registServiceOutBo.boText);
            this.Close();
        }

        private void 物理名からプロパティ作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IchiranBoCreateService boCreateService = new IchiranBoCreateService();
            IchiranBoCreateServiceInBo boCreateServiceInBo = new IchiranBoCreateServiceInBo();
            boCreateServiceInBo.ichiranDataGridView = this.ichiranDataGridView;
            boCreateServiceInBo.shoriMode = PropertyShoriMode.物理名からプロパティ作成;
            boCreateService.setInBo(boCreateServiceInBo);
            IchiranBoCreateServiceOutBo registServiceOutBo = boCreateService.execute();
            Clipboard.SetText(registServiceOutBo.boText);
            this.Close();
        }

        private void 物理名からプロパティ作成アノテーションありToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IchiranBoCreateService boCreateService = new IchiranBoCreateService();
            IchiranBoCreateServiceInBo boCreateServiceInBo = new IchiranBoCreateServiceInBo();
            boCreateServiceInBo.ichiranDataGridView = this.ichiranDataGridView;
            boCreateServiceInBo.shoriMode = PropertyShoriMode.物理名からプロパティ作成アノテーションあり;
            boCreateService.setInBo(boCreateServiceInBo);
            IchiranBoCreateServiceOutBo registServiceOutBo = boCreateService.execute();
            Clipboard.SetText(registServiceOutBo.boText);
            this.Close();
        }
    }
}
