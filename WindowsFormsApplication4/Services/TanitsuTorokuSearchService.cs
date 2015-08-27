using SQLite.Services;
using System.Collections.Generic;
using System.Linq;
using WordConverter_v2.Common;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
{
    class TanitsuTorokuSearchService : IService<TanitsuTorokuSearchServiceInBo, TanitsuTorokuSearchServiceOutBo>
    {
        private TanitsuTorokuSearchServiceInBo inBo;

        public void setInBo(TanitsuTorokuSearchServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public TanitsuTorokuSearchServiceOutBo execute()
        {
            TanitsuTorokuSearchServiceOutBo outBo = new TanitsuTorokuSearchServiceOutBo();

            using (var context = new MyContext())
            {
                IQueryable<HenshuWordBo> ws = from a in context.WordDic
                                              join b in context.UserMst on a.user_id equals b.user_id
                                              select new HenshuWordBo
                                              {
                                                  word_id = a.word_id,
                                                  ronri_name1 = a.ronri_name1,
                                                  ronri_name2 = a.ronri_name2,
                                                  butsuri_name = a.butsuri_name,
                                                  user_name = b.user_name,
                                                  cre_date = a.cre_date,
                                                  version = (int)a.version
                                              };

                object[] keywords = new object[3];
                keywords[0] = this.inBo.ronrimei1TextBox;
                keywords[1] = this.inBo.ronrimei2TextBox;
                keywords[2] = this.inBo.butsurimeiTextBox;

                IQueryable<HenshuWordBo> words = ws.WordDicWhereLike(keywords);

                List<HenshuWordBo> wordList = new List<HenshuWordBo>();
                if (words.Count() > 0)
                {
                    wordList = words.ToList();
                }
                outBo.wordList = wordList;
            }

            return outBo;
        }
    }
}
