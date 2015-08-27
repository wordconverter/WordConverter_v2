using SQLite.Services;
using System;
using WordConverter_v2.Common;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using System.Linq;

namespace WordConverter_v2.Services
{

    public class IkkatsuTorokuIkkatsuRegistService : IService<IkkatsuTorokuIkkatsuRegistServiceInBo, IkkatsuTorokuIkkatsuRegistServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private static CommonFunction common = new CommonFunction();
        
        /// <summary>
        /// 
        /// </summary>
        private IkkatsuTorokuIkkatsuRegistServiceInBo inBo = new IkkatsuTorokuIkkatsuRegistServiceInBo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InBo"></param>
        internal void setInBo(IkkatsuTorokuIkkatsuRegistServiceInBo InBo)
        {
            this.inBo = InBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal IkkatsuTorokuIkkatsuRegistServiceOutBo execute()
        {
            IkkatsuTorokuIkkatsuRegistServiceOutBo outBo = new IkkatsuTorokuIkkatsuRegistServiceOutBo();

            for (int i = 0; i < this.inBo.ikkatsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.ikkatsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.inBo.ikkatsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.inBo.ikkatsuDataGridView.Rows[i].Cells["word_id"].Value.ToString());
                        var upWord = context.WordDic
                            .Where(x => x.word_id == condtion);


                        String butsuriName = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["butsuri_name"].Value);
                        butsuriName = butsuriName.ToPascalCase();

                        if (upWord.Count() == 1)
                        {
                            var w = context.WordDic.Single(x => x.word_id == condtion);
                            w.ronri_name1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["ronri_name1"].Value);
                            w.butsuri_name = butsuriName;
                            w.cre_date = System.DateTime.Now.ToString();
                            context.SaveChanges();
                            continue;
                        }

                        WordDic word = new WordDic();
                        word.ronri_name1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["ronri_name1"].Value);
                        word.butsuri_name = butsuriName;
                        word.cre_date = System.DateTime.Now.ToString();
                        context.WordDic.Add(word);
                        context.SaveChanges();
                    }
                }
            }

            return outBo;
        }

        void IService<IkkatsuTorokuIkkatsuRegistServiceInBo, IkkatsuTorokuIkkatsuRegistServiceOutBo>.setInBo(IkkatsuTorokuIkkatsuRegistServiceInBo inBo)
        {
            throw new NotImplementedException();
        }

        IkkatsuTorokuIkkatsuRegistServiceOutBo IService<IkkatsuTorokuIkkatsuRegistServiceInBo, IkkatsuTorokuIkkatsuRegistServiceOutBo>.execute()
        {
            throw new NotImplementedException();
        }
    }
}
