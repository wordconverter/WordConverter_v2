using System;
using System.Linq;
using System.Windows.Forms;
using WordConverter_v2.Forms;
using WordConverter_v2.Interface;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConvTool.Const;

namespace WordConverter_v2.Services
{
    class ShinseiShinseiService : IService<ShinseiShinseiServiceInBo, ShinseiShinseiServiceOutBo>
    {
        private ShinseiShinseiServiceInBo inBo;

        public void setInBo(ShinseiShinseiServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public ShinseiShinseiServiceOutBo execute()
        {
            ShinseiShinseiServiceOutBo outBo = new ShinseiShinseiServiceOutBo();
            outBo = this.inputCheck(this.inBo);

            if (!String.IsNullOrEmpty(outBo.errorMessage))
            {
                return outBo;
            }

            string message = "";
            message += "論理名　：" + this.inBo.ronrimei1TextBox + System.Environment.NewLine;
            message += "よみがな：" + this.inBo.ronrimei2TextBox + System.Environment.NewLine;
            message += "物理名　：" + this.inBo.butsurimeiTextBox + System.Environment.NewLine + System.Environment.NewLine;
            DialogResult result = MessageBox.Show(message + "申請してもよろしいですか？", "申請確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                using (var context = new MyContext())
                {
                    WordShinsei shinsei = new WordShinsei();
                    shinsei.ronri_name1 = this.inBo.ronrimei1TextBox;
                    shinsei.ronri_name2 = this.inBo.ronrimei2TextBox;
                    shinsei.butsuri_name = this.inBo.butsurimeiTextBox;
                    shinsei.status = 0;
                    shinsei.user_id = BaseForm.UserInfo.userId;
                    shinsei.cre_date = System.DateTime.Now.ToString();
                    context.WordShinsei.Add(shinsei);
                    context.SaveChanges();
                }
            }
            return outBo;
        }

        private ShinseiShinseiServiceOutBo inputCheck(ShinseiShinseiServiceInBo inBo)
        {
            ShinseiShinseiServiceOutBo outBo = new ShinseiShinseiServiceOutBo();

            if (String.IsNullOrEmpty(inBo.ronrimei1TextBox)
                || String.IsNullOrEmpty(inBo.ronrimei2TextBox)
                || String.IsNullOrEmpty(inBo.butsurimeiTextBox))
            {
                outBo.errorMessage = "論理名、よみがな、物理名は必須項目です。";
                return outBo;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(inBo.ronrimei2TextBox, @"^[あ-ん]*$"))
            {
                outBo.errorMessage = "ひらがな以外が含まれています。";
                return outBo;
            }

            using (var context = new MyContext())
            {
                string condtion = inBo.ronrimei1TextBox;
                var upWord = context.WordDic
                    .Where(x => x.ronri_name1 == condtion);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "辞書テーブルに既に存在する単語です。";
                    return outBo;
                }
            }

            using (var context = new MyContext())
            {
                string condtion = inBo.ronrimei1TextBox;
                var upWord = context.WordShinsei
                    .Where(x => x.ronri_name1 == condtion && x.status == (int)ShinseiKbn.申請中);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "既に申請中の単語です。";
                    return outBo;
                }
            }

            using (var context = new MyContext())
            {
                string condtion = inBo.ronrimei1TextBox;
                var upWord = context.WordShinsei
                    .Where(x => x.ronri_name1 == condtion && x.status == 2);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "既に却下済みの単語です。";
                    return outBo;
                }
            }

            return outBo;
        }
    }
}
