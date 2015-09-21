using System;
using System.Windows.Forms;
using WordConverter_v2.Forms;
using WordConverter_v2.Interface;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
{
    class TanitsuTorokuDeleteService : IService<TanitsuTorokuDeleteServiceInBo, TanitsuTorokuDeleteServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private TanitsuTorokuDeleteServiceInBo inBo;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(TanitsuTorokuDeleteServiceInBo inBo)
        {
            this.inBo = (TanitsuTorokuDeleteServiceInBo)inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TanitsuTorokuDeleteServiceOutBo execute()
        {
            TanitsuTorokuDeleteServiceOutBo outBo = new TanitsuTorokuDeleteServiceOutBo();

            for (int i = 0; i < this.inBo.tanitsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext(BaseForm.UserInfo.dbType))
                    {
                        long condtion = Convert.ToInt64(this.inBo.tanitsuDataGridView.Rows[i].Cells["word_id"].Value.ToString());
                        var toRemoveWord = new WordDic { word_id = condtion };
                        context.WordDic.Attach(toRemoveWord);
                        context.WordDic.Remove(toRemoveWord);
                        context.SaveChanges();
                    }
                }
            }
            MessageBox.Show("辞書テーブルから削除されました。");
            return outBo;
        }
    }
}
