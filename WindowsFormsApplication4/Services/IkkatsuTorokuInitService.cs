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
    public class IkkatsuTorokuInitService : IService<IkkatsuTorokuInitServiceInBo, IkkatsuTorokuInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private IkkatsuTorokuInitServiceInBo inBo = new IkkatsuTorokuInitServiceInBo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InBo"></param>
        internal void setInBo(IkkatsuTorokuInitServiceInBo InBo)
        {
            this.inBo = InBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal IkkatsuTorokuInitServiceOutBo execute()
        {
            IkkatsuTorokuInitServiceOutBo outBo = new IkkatsuTorokuInitServiceOutBo();
            List<HenshuWordBo> wordList = new List<HenshuWordBo>();

            if (!String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                string key = this.inBo.clipboardText;
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);
                foreach (String ronriName in keys)
                {
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
                        HenshuWordBo[] dbWords = words.Where(x => x.ronri_name1 == condition).ToArray();

                        if (dbWords.Length == 0)
                        {
                            HenshuWordBo w = new HenshuWordBo();
                            w.ronri_name1 = ronriName;
                            wordList.Add(w);
                        }
                    }
                }
            }
            outBo.henshuWordBoList = wordList;
            return outBo;
        }

        void IService<IkkatsuTorokuInitServiceInBo, IkkatsuTorokuInitServiceOutBo>.setInBo(IkkatsuTorokuInitServiceInBo inBo)
        {
            throw new NotImplementedException();
        }

        IkkatsuTorokuInitServiceOutBo IService<IkkatsuTorokuInitServiceInBo, IkkatsuTorokuInitServiceOutBo>.execute()
        {
            throw new NotImplementedException();
        }
    }
}
