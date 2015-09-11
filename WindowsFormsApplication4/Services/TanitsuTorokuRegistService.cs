using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConvertTool;
using System.Linq;
using WordConverter_v2.Forms;
using WordConverter_v2.Interface;
using System;

namespace WordConverter_v2.Services
{
    public class TanitsuTorokuRegistService : IService<TanitsuTorokuRegistServiceInBo, TanitsuTorokuRegistServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        public TanitsuTorokuRegistServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(TanitsuTorokuRegistServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TanitsuTorokuRegistServiceOutBo execute()
        {
            TanitsuTorokuRegistServiceOutBo outBo = new TanitsuTorokuRegistServiceOutBo();

            for (int i = 0; i < this.inBo.tanitsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value == null
                    || (bool)this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.inBo.tanitsuDataGridView.Rows[i].Cells["word_id"].Value.ToString());
                    var upWord = context.WordDic
                        .Where(x => x.word_id == condtion);

                    if (upWord.Count() == 1)
                    {
                        var w = context.WordDic.Single(x => x.word_id == condtion);
                        w.ronri_name1 = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["ronri_name1"].Value);
                        w.butsuri_name = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["butsuri_name"].Value);
                        w.data_type = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["data_type"].Value);
                        w.cre_date = System.DateTime.Now.ToString();
                        w.user_id = BaseForm.UserInfo.userId;
                        context.SaveChanges();
                        continue;
                    }

                    WordDic word = new WordDic();
                    word.ronri_name1 = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["ronri_name1"].Value);
                    word.butsuri_name = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["butsuri_name"].Value);
                    word.data_type = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["data_type"].Value);
                    word.cre_date = System.DateTime.Now.ToString();
                    word.user_id = BaseForm.UserInfo.userId;
                    context.WordDic.Add(word);
                    context.SaveChanges();
                }

            }
            return outBo;
        }
    }
}
