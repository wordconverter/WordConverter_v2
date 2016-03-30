using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WordConverter_v2.Common;
using WordConverter_v2.Forms;
using WordConverter_v2.Interface;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
{
    public class IchiranInitServiceKojinMode : IchiranInitServiceBase, IService<IchiranInitServiceInBo, IchiranInitServiceOutBo>
    {

        public void setInBo(IchiranInitServiceInBo inBo)
        {
            base.inBo = inBo;
        }

        public IchiranInitServiceOutBo execute()
        {
            IchiranInitServiceOutBo outBo = new IchiranInitServiceOutBo();
            List<IchiranWordBo> wordList = new List<IchiranWordBo>();
            IchiranWordBo word = new IchiranWordBo();

            string key = this.inBo.clipboardText;
            String[] keys = key.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> list = this.makeList(keys);

            if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(list[0]))
            {
                CommonFunction common = new CommonFunction();
                string dbConnectionString = common.getSqliteDbConnectionString();

                if (list.Count() == 1)
                {
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        SQLiteCommand cmd = (SQLiteCommand)this.setQueryCommandSingle(cn, list);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!this.makeSingleWordList(reader, ref wordList, ref word)) { continue; };
                            }
                        }
                        cn.Close();
                    }
                }
                else
                {
                    Dictionary<String, String> dict = new Dictionary<String, String>();
                    MyRepository rep = new MyRepository(BaseForm.UserInfo.dbType);
                    List<WordDic> dbWordList = rep.FindDispWordDic(list);
                    foreach (WordDic wordD in dbWordList)
                    {
                        if (!dict.ContainsKey(wordD.ronri_name1))
                        {
                            dict.Add(wordD.ronri_name1, wordD.butsuri_name);
                        }
                    }

                    if (dict.Count != 0)
                    {
                        int keyIndex = 0;
                        while (keyIndex < keys.Length && !String.IsNullOrEmpty(keys[keyIndex]))
                        {
                            word = new IchiranWordBo();
                            word.ronri_name1 = keys[keyIndex];
                            if (dict.ContainsKey(keys[keyIndex]))
                            {
                                word.butsuri_name = dict[keys[keyIndex]];
                            }
                            else
                            {
                                word.butsuri_name = "-";
                            }
                            wordList.Add(word);
                            keyIndex++;
                        }
                    }
                }
            }
            this.makeIchiranDispList(ref outBo, this.inBo, wordList, word);
            return outBo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        private List<string> makeList(String[] keys)
        {

            List<string> list = new List<string>();
            list.AddRange(keys);

            List<string> ret = new List<string>();

            foreach (String str in list)
            {
                if (String.IsNullOrEmpty(str))
                {
                    continue;
                }
                ret.Add(str.Trim());
            }

            return ret;
        }
    }
}
