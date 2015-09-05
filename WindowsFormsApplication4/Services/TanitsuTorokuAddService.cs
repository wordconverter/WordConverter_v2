using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Common;
using WordConverter_v2.Const;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConverter_v2.Services;
using WordConvertTool;

namespace WordConverter_v2.Services
{
    public class TanitsuTorokuAddService : IService<TanitsuTorokuAddServiceInBo, TanitsuTorokuAddServiceOutBo>
    {
        private TanitsuTorokuAddServiceInBo inBo;
        private static CommonFunction common = new CommonFunction();

        public void setInBo(TanitsuTorokuAddServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public TanitsuTorokuAddServiceOutBo execute()
        {
            TanitsuTorokuAddServiceOutBo outBo = new TanitsuTorokuAddServiceOutBo();

            using (var context = new MyContext())
            {
                var products = context.WordDic
                    .Where(x => x.ronri_name1 == this.inBo.ronrimei1TextBox)
                    .ToArray();

                if (products.Count() > 0)
                {
                    outBo.errorMessage = MessageConst.ERR_002;
                    return outBo;

                }
            }

            List<HenshuWordBo> wordList = new List<HenshuWordBo>();
            HenshuWordBo word = new HenshuWordBo();

            for (int i = 0; i < this.inBo.tanitsuDataGridView.Rows.Count; i++)
            {
                word = new HenshuWordBo();
                word.word_id = this.inBo.tanitsuDataGridView.Rows[i].Cells["word_id"].Value.ToString().ToIntType();
                word.ronri_name1 = this.inBo.tanitsuDataGridView.Rows[i].Cells["ronri_name1"].Value.ToString();
                word.butsuri_name = this.inBo.tanitsuDataGridView.Rows[i].Cells["butsuri_name"].Value.ToString();
                word.data_type = this.inBo.tanitsuDataGridView.Rows[i].Cells["data_type"].Value.ToString();
                word.user_name = common.nullAble(this.inBo.tanitsuDataGridView.Rows[i].Cells["user_name"].Value);
                word.version = common.nullAbleInt(this.inBo.tanitsuDataGridView.Rows[i].Cells["version"].Value);
                word.cre_date = common.nullAble(this.inBo.tanitsuDataGridView.Rows[i].Cells["cre_date"].Value);
                wordList.Add(word);
            }

            word = new HenshuWordBo();
            word.ronri_name1 = this.inBo.ronrimei1TextBox;
            word.butsuri_name = this.inBo.butsurimeiTextBox;
            word.data_type = this.inBo.dataType;
            wordList.Add(word);

            if (this.inBo.registeredPairsFlg)
            {
                word = new HenshuWordBo();
                word.ronri_name1 = this.inBo.butsurimeiTextBox;
                word.butsuri_name = this.inBo.ronrimei1TextBox;
                word.data_type = this.inBo.dataType;
                wordList.Add(word);
            }

            outBo.wordList = wordList;
            return outBo;
        }
    }
}
