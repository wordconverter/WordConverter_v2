using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WordConverter_v2.Common;
using WordConverter_v2.Interface;
using WordConverter_v2.Models;
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

            if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(keys[0]))
            {
                CommonFunction common = new CommonFunction();
                string dbConnectionString = common.getSqliteDbConnectionString();

                if (keys.Count() == 1)
                {
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        SQLiteCommand cmd = (SQLiteCommand)this.setQueryCommandSingle(cn, keys);
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
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        SQLiteCommand cmd = (SQLiteCommand)this.setQueryCommandMultiple(cn, keys);
                        List<IchiranWordBo> dbWordList = new List<IchiranWordBo>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!dict.ContainsKey(reader["ronri_name1"].ToString()))
                                {
                                    dict.Add(reader["ronri_name1"].ToString(), reader["butsuri_name"].ToString());
                                }
                            }
                        }
                        cn.Close();
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
                    //this.makeMultipleWordList(dbConnectionString, keys, word, wordList);
                }
            }
            this.makeIchiranDispList(ref outBo, this.inBo, wordList, word);
            return outBo;
        }
    }
}
