using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConvertTool;

namespace WordConverter_v2.Services
{
    class TanitsuTorokuInitService : IService<TanitsuTorokuInitServiceInBo, TanitsuTorokuInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private TanitsuTorokuInitServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(TanitsuTorokuInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TanitsuTorokuInitServiceOutBo execute()
        {
            TanitsuTorokuInitServiceOutBo outBo = new TanitsuTorokuInitServiceOutBo();
            List<HenshuWordBo> wordList = new List<HenshuWordBo>();

            if (!String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                string ronriName = this.inBo.clipboardText;
                using (var context = new MyContext())
                {
                    IQueryable<HenshuWordBo> words = from a in context.WordDic
                                                     join b in context.UserMst on a.user_id equals b.user_id
                                                     select new HenshuWordBo
                                                     {
                                                         word_id = a.word_id,
                                                         ronri_name1 = a.ronri_name1,
                                                         butsuri_name = a.butsuri_name,
                                                         user_name = b.user_name,
                                                         cre_date = a.cre_date,
                                                         version = (int)a.version
                                                     };
                    String condition = ronriName.Trim();
                    HenshuWordBo[] dispWords = words.Where(x => x.ronri_name1.IndexOf(condition) > -1).ToArray();

                    foreach (var word in dispWords)
                    {
                        HenshuWordBo w = new HenshuWordBo();
                        w.word_id = word.word_id;
                        w.ronri_name1 = word.ronri_name1;
                        w.butsuri_name = word.butsuri_name;
                        w.user_name = word.user_name;
                        w.cre_date = word.cre_date;
                        w.version = (int)word.version;
                        wordList.Add(w);
                    }
                }
            }
            outBo.henshuWordBoList = wordList;
            return outBo;
        }
    }
}
